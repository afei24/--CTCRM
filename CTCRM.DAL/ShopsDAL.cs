using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Domain;

namespace CTCRM.DAL
{
   public class ShopsDAL
    {
       /// <summary>
       /// 获取卖家当前买家的级别
       /// </summary>
       /// <param name="nickName"></param>
       /// <returns></returns>
       public static DataTable GetBuyerGrade(string nickName) { 
       
             try
            {
                string query = @"select count(grade) as grade from Buyer where  SELLER_ID = @SELLER_ID and grade = 0
union all 
select count(grade) as grade from Buyer where  SELLER_ID = @SELLER_ID and grade = 1
union all 
select count(grade) as grade from Buyer where  SELLER_ID = @SELLER_ID and grade = 2
union all 
select count(grade) as grade from Buyer where  SELLER_ID = @SELLER_ID and grade = 3
union all 
select count(grade) as grade from Buyer where  SELLER_ID = @SELLER_ID and grade = 4";
                SqlParameter[] param = new SqlParameter[]
            {
                 new SqlParameter("@SELLER_ID",nickName)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }     
       }
       /// <summary>
       /// 一次读取店铺相关统计信息：销售额 	订单数 	会员数 	客单价 	新客户订单数 	退款笔数 
       /// </summary>
       /// <param name="sellerNickName"></param>
       /// <returns></returns>
       public static DataTable GetShopeInfoStatic(string sellerNickName)
       {
           try
           {
               string query = @"select sum(trade_amount) as Result_Flag from Buyer where SELLER_ID = @SELLER_ID
union all
select count(1) as orderCount from Trade where seller_nick = @SELLER_ID
union all
select count(1) as buyerCount from Buyer where SELLER_ID = @SELLER_ID
union all
select cast(sum(avg_price)/count(1) as decimal(18,2)) as avg_price  from Buyer where SELLER_ID = @SELLER_ID
union all
select count(T.buyer_nick) as newCount from (
	select  count(buyer_nick) as buyerCount,buyer_nick from Trade where seller_nick = @SELLER_ID and status = 'TRADE_FINISHED'
	group by buyer_nick  having count(buyer_nick) = 1 
) as T inner join Buyer B on B.buyer_nick = T.buyer_nick where B.SELLER_ID = @SELLER_ID and B.trade_amount > 0
union all
select count(1) as refundCount from TradeOrder where refund_status = 'SUCCESS' and seller_nick = @SELLER_ID 
union all
select count(1) as unpayCount from Buyer where trade_amount = 0 and SELLER_ID = @SELLER_ID
union all
select count(1) as nologin3Months from Buyer where trade_amount > 0 and DATEDIFF(day,last_trade_time,getdate()) >= 90 and SELLER_ID = @SELLER_ID
union all
select count(T.buyer_nick) as oldBuyerCount from (
select count(buyer_nick) as buyerCount,buyer_nick from Trade where seller_nick = @SELLER_ID and status = 'TRADE_FINISHED'
group by buyer_nick having count(buyer_nick) > 1 
) as T inner join Buyer B on B.buyer_nick = T.buyer_nick where B.SELLER_ID = @SELLER_ID and B.trade_amount > 0";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static string GetShopeTradeAmount(string sellerNickName)
       {
           try
           {
               string query = @"select sum(trade_amount) as trade_amount from Buyer where SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["trade_amount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeTradeOrder(string sellerNickName)
       {
           try
           {
               string query = @"select count(1) as orderCount from Trade where seller_nick = @seller_nick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["orderCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeBuyerCount(string sellerNickName)
       {
           try
           {
               string query = @"select count(1) as buyerCount from Buyer where SELLER_ID = @seller_nick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["buyerCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeAvgPrice(string sellerNickName)
       {
           try
           {
               string query = @"select cast(sum(avg_price)/count(1) as decimal(18,2)) as avg_price  from Buyer where SELLER_ID = @seller_nick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["avg_price"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeNewOrderCount(string sellerNickName)
       {
           try
           {
               string query = @"select count(T.buyer_nick) as newCount from (
                                select  count(buyer_nick) as buyerCount,buyer_nick from Trade group by buyer_nick,seller_nick having count(buyer_nick) = 1 and seller_nick = @seller_nick) as T 
                                inner join Buyer B on B.buyer_nick = T.buyer_nick where B.trade_amount > 0";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["newCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeRefundCount(string sellerNickName)
       {
           try
           {
               string query = @"select count(1) as refundCount from TradeOrder where refund_status = 'SUCCESS' and seller_nick = @seller_nick";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@seller_nick",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["refundCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       public static string GetShopeUnPayOrderCount(string sellerNickName)
       {
           try
           {
               string query = @"select count(1) as unpayCount from Buyer where trade_amount = 0 and SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["unpayCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }


       public static string GetShopeNoLogin3Months(string sellerNickName)
       {
           try
           {
               string query = @"select count(1) as nologin3Months from Buyer where trade_amount > 0 and DATEDIFF(day,last_trade_time,getdate()) >= 90 and SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["nologin3Months"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }

       /// <summary>
       /// 
       /// </summary>
       /// <param name="sellerNickName"></param>
       /// <returns></returns>
       public static string GetShopeOldBuyerCount(string sellerNickName)
       {
           try
           {
               string query = @"select count(T.buyer_nick) as oldBuyerCount from (
select  count(buyer_nick) as buyerCount,buyer_nick from Trade 
group by buyer_nick,seller_nick having count(buyer_nick) > 1 and seller_nick = @SELLER_ID) as T inner join Buyer B on B.buyer_nick = T.buyer_nick where B.trade_amount > 0";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNickName)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["oldBuyerCount"].ToString();
               }
               return "0";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "0";
           }
       }


       public static bool AddShop(Shop o)
       {
           try
           {
               string query = @"insert into SellerShop(sid,cid,nick,title,pic_path,created,modified)values(@sid,@cid,@nick,@title,@pic_path,@created,@modified)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sid",o.Sid),
                    new SqlParameter("@cid",o.Cid),
                    new SqlParameter("@nick",o.Nick),
                    new SqlParameter("@title",o.Title),
                    new SqlParameter("@pic_path",o.PicPath),
                    new SqlParameter("@created",o.Created),
                    new SqlParameter("@modified",o.Modified)
                };
               DataBase.ExecuteSql(query, param);
               return true;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }


       public static bool UpdateShopInfo(Shop o)
       {
           try
           {
               string query = @"update SellerShop set cid =@cid,title=@title,pic_path=@pic_path,modified = @modified where sid = @sid";

               SqlParameter[] param = new SqlParameter[] 
                {
                     new SqlParameter("@cid",o.Cid),
                    new SqlParameter("@title",o.Title),
                    new SqlParameter("@pic_path",o.PicPath),
                    new SqlParameter("@modified",o.Modified),
                    new SqlParameter("@sid",o.Sid)
                };
               DataBase.ExecuteSql(query, param);

               return true;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }

       }



       public static Boolean CheckShopIsExit(string sid)
       {
           try
           {
               string query = @"SELECT 1 FROM SellerShop WHERE sid=@sid";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sid",sid)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt.Rows.Count > 0)
               {
                   return true;
               }
               return false;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       }


       public static DataTable GetSellerShopInfo(string sellerNick)
       {
           try
           {
               string query = @"select title,pic_path from SellerShop where nick = @nick ";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nick",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }



    }
}
