using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using System.Data;
using CHENGTUAN.Entity;
using Top.Api.Domain;

namespace CTCRM.DAL
{
   public class BuyerDAL
    {

       public static bool Add(Buyers o, string strNick, string groupNo, string Seller_Id)
        {
            try
            {
                string query = @"insert into Buyer_" + Seller_Id + @"(buyer_id,SELLER_ID,buyer_nick,avg_price,status,close_trade_count,close_trade_amount,
item_close_count,last_trade_time,item_num,trade_amount,grade,city,trade_count,createDate,groupNo,buyerType,
buyer_reallName,cellPhone,province,buyer_credit,address)
   values(@buyer_id,@SELLER_ID,@buyer_nick,@avg_price,@status,@close_trade_count,@close_trade_amount,
@item_close_count,@last_trade_time,@item_num,@trade_amount,@grade,@city,@trade_count,@createDate,@groupNo,@buyerType,
@buyer_reallName,@cellPhone,@province,@buyer_credit,@address)";
               
                    SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@SELLER_ID",strNick),
                    new SqlParameter("@buyer_nick",o.Buyer_nick),
                    new SqlParameter("@avg_price",string.IsNullOrEmpty(o.AvgPrice)?"0":o.AvgPrice),
                    new SqlParameter("@status",string.IsNullOrEmpty(o.Status)?"":o.Status),
                    new SqlParameter("@close_trade_count",o.CloseTradeCount),
                    new SqlParameter("@close_trade_amount",string.IsNullOrEmpty(o.CloseTradeAmount)?"0":o.CloseTradeAmount),
                    new SqlParameter("@item_close_count",o.ItemCloseCount),
                    new SqlParameter("@last_trade_time",string.IsNullOrEmpty(o.LastTradeTime)?"":o.LastTradeTime),
                    new SqlParameter("@item_num",o.ItemNum),
                    new SqlParameter("@trade_amount",string.IsNullOrEmpty(o.TradeAmount)?"0":o.TradeAmount),
                    new SqlParameter("@grade",o.Grade),
                    new SqlParameter("@city",o.City==null?"":o.City),
                    new SqlParameter("@trade_count",o.TradeCount),
                    new SqlParameter("@createDate",DateTime.Now),
                    new SqlParameter("@groupNo",int.Parse(groupNo)),
                    new SqlParameter("@buyerType","0"),//0表示自己店铺的会员
                    new SqlParameter("@buyer_reallName",string.IsNullOrEmpty(o.Buyer_reallName)?"":o.Buyer_reallName),
                    new SqlParameter("@cellPhone",string.IsNullOrEmpty(o.CellPhone)?"":o.CellPhone),
                    new SqlParameter("@province",string.IsNullOrEmpty(o.BuyerProvince)?"":o.BuyerProvince),
                    new SqlParameter("@buyer_credit","1"),
                    new SqlParameter("@email",string.IsNullOrEmpty(o.Email)?"":o.Email),
                    new SqlParameter("@address",string.IsNullOrEmpty(o.Address)?"":o.Address)
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

       public static bool UpdateBuyerInfo(CrmMember o, string sellerNick, string groupNo, string Seller_Id)
       {
           try
           {
               string query = @"update Buyer_" + Seller_Id + @" set avg_price = @avg_price,status = @status,close_trade_count = @close_trade_count,
                                close_trade_amount = @close_trade_amount,item_close_count = @item_close_count,last_trade_time = @last_trade_time,
                                item_num = @item_num,trade_amount = @trade_amount,grade = @grade,trade_count = @trade_count,updateDate = getdate(),
                                groupNo = @groupNo
                                WHERE buyer_id = @buyer_id and SELLER_ID = @SELLER_ID";
             
                   SqlParameter[] param = new SqlParameter[] 
                {
                     new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@avg_price",string.IsNullOrEmpty(o.AvgPrice)?"0":o.AvgPrice),
                    new SqlParameter("@status",string.IsNullOrEmpty(o.Status)?"":o.Status),
                    new SqlParameter("@close_trade_count",o.CloseTradeCount),
                    new SqlParameter("@close_trade_amount",string.IsNullOrEmpty(o.CloseTradeAmount)?"0":o.CloseTradeAmount),
                    new SqlParameter("@item_close_count",o.ItemCloseCount),
                    new SqlParameter("@last_trade_time",string.IsNullOrEmpty(o.LastTradeTime)?"":o.LastTradeTime),
                    new SqlParameter("@item_num",o.ItemNum),
                    new SqlParameter("@trade_amount",string.IsNullOrEmpty(o.TradeAmount)?"0":o.TradeAmount),
                    new SqlParameter("@grade",o.Grade),
                    new SqlParameter("@trade_count",o.TradeCount),
                    new SqlParameter("@groupNo",groupNo),
                    new SqlParameter("@SELLER_ID",sellerNick)
                };
                   DataBase.ExecuteSql(query, param);
             
               return true;
           }
           catch (Exception ex)
           {
               ExceptionManager exceptionManager = new ExceptionManager();
               exceptionManager.WriteFileLog("查询中差评错误", ex.Message, ex.Message);
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return false;
           }
       
       }

       public static bool UpdateGrade(Buyers o, string Seller_Id)
       {
           try
           {
               string query = @"update Buyer_" + Seller_Id + " set grade = @grade,updateDate=getdate() WHERE buyer_id = @buyer_id and SELLER_ID = @SELLER_ID";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@grade",o.Grade),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID)
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



       public static String GetBuyerNick(string buyerID, string sellerNick, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_nick from Buyer_" + Seller_Id + " where buyer_id = @buyer_id and SELLER_ID = @SELLER_ID";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",buyerID),
                    new SqlParameter("@SELLER_ID",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count == 1)
               {
                   return dt.Rows[0]["buyer_nick"].ToString();
               }
               return "";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "";
           }
       }

       public static String GetBuyerCount(string flag, string sellerNick, string Seller_Id)
       {
           if (string.IsNullOrEmpty(Seller_Id) == true || string.IsNullOrEmpty(sellerNick)==true) { return "0"; }
           try
           {
               string query = "";
               if (!string.IsNullOrEmpty(flag) && flag.Equals("1"))
               {
                   query = @"select count(1) as buyerCount from Buyer_" + Seller_Id + " where SELLER_ID = @nick";
               }
               else
               {
                   query = @"select count(1) as buyerCount from Buyer_" + Seller_Id + " where SELLER_ID = @nick and cellPhone !=''";
               }

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",sellerNick)
                };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count == 1)
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

       public static DataTable GetSellerNoDetailsInfo(string Seller_Id)
       {
           try
           {
               string query = @"select SELLER_ID,buyer_nick from Buyer_" + Seller_Id + @" where cellPhone =''";
               return  DataBase.ExecuteDt(query);
           }
           catch (Exception ex)
           {
               return null;
           }
       }

       public static bool Update(Buyers o, string Seller_Id)
        {
            try
            {
                string query = @"update Buyer_" + Seller_Id + @" 
                                set buyer_reallName = @buyer_reallName,
                                cellPhone = @cellPhone,                           
                                province = @province,
                                buyer_credit = @buyer_credit,
                                address = @address,
                                updateDate = getdate()                               
                                WHERE buyer_id = @buyer_id and SELLER_ID = @SELLER_ID";
              
                    SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@buyer_reallName",o.Buyer_reallName == null?"":o.Buyer_reallName),
                    new SqlParameter("@cellPhone",o.CellPhone == null ?"":o.CellPhone),
                    new SqlParameter("@province",o.BuyerProvince == null?"":o.BuyerProvince.ToString()),
                    new SqlParameter("@buyer_credit",o.Buyer_credit==null?"1":o.Buyer_credit),
                    new SqlParameter("@address",o.Address==null?"":o.Address),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID)
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

       public static bool UpdateForHistory(Buyers o, string Seller_Id)
       {
           try
           {
               string query = @"update Buyer_"+Seller_Id+@" 
                                set buyer_reallName = @buyer_reallName,
                                cellPhone = @cellPhone,                           
                                province = @province,
                                buyer_credit = @buyer_credit,
                                address = @address,
                                updateDate = getdate()                               
                                WHERE buyer_nick = @buyer_nick and SELLER_ID = @SELLER_ID";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_nick",o.BuyerNick == null?"":o.BuyerNick),
                    new SqlParameter("@buyer_reallName",o.Buyer_reallName == null?"":o.Buyer_reallName),
                    new SqlParameter("@cellPhone",o.CellPhone == null ?"":o.CellPhone),
                    new SqlParameter("@province",o.BuyerProvince == null?"":o.BuyerProvince.ToString()),
                    new SqlParameter("@buyer_credit",o.Buyer_credit==null?"1":o.Buyer_credit),
                    new SqlParameter("@address",o.Address==null?"":o.Address),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID)
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

       public static bool UpdateBuyerDetails(Buyers o, string Seller_Id)
       {
           try
           {
               string query = @"update Buyer_"+Seller_Id+@" 
                                set buyer_reallName = @buyer_reallName,
                                cellPhone = @cellPhone,
                                Phone = @Phone,
                                qq = @qq,
                                birthDay = @birthDay,
                                zipCode = @zipCode,
                                email = @email,
                                address = @address,
                                updateDate=getdate(),
                                memo = @memo 
                                WHERE buyer_id = @buyer_id and SELLER_ID = @SELLER_ID";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@buyer_reallName",o.Buyer_reallName),
                    new SqlParameter("@cellPhone",o.CellPhone),
                    new SqlParameter("@Phone",o.Phone),
                    new SqlParameter("@qq",o.QQ),
                    new SqlParameter("@birthDay",o.birthDay),
                    new SqlParameter("@zipCode",o.ZipCode),
                    new SqlParameter("@email",o.Email),
                    new SqlParameter("@memo",o.Memo),
                    new SqlParameter("@address",o.Address),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID)
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


       public static Boolean CheckBuyerIsExit(string buyer_nick, string sellerNick, string Seller_Id)
        {
            try
            {
                string query = @"SELECT 1 FROM Buyer_" + Seller_Id + " WHERE buyer_nick = @buyer_nick and SELLER_ID = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_nick",buyer_nick),
                new SqlParameter("@SELLER_ID",sellerNick)
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




       public static DataTable GetBuyerByBuyerID(Buyers entity, string Seller_Id)
       {
           try
           {
               string query = @"SELECT B.buyer_nick,case B.grade WHEN 0 THEN '潜在会员' when 1 THEN '普通客户' WHEN 2 THEN '高级会员' WHEN 3 THEN 'VIP会员'
                                WHEN 4 THEN '至尊VIP会员' END AS grade,CASE B.status WHEN 'normal' THEN '正常' WHEN 'delete' THEN '被买家删除'
                                WHEN 'blacklist' THEN '黑名单' END AS status,B.trade_amount,B.trade_count,B.item_num,B.buyer_credit,B.close_trade_count,B.close_trade_amount,
                                B.last_trade_time,B.cellPhone,B.Phone,B.address,B.qq,B.birthDay,B.memo,B.buyer_reallName,B.province,B.email,B.city,B.zipCode,B.buyer_alipay_no,G.group_name,dbo.GetRefundBuyer(@buyer_nick,@SELLER_ID) as hasRefund FROM Buyer_" + Seller_Id + " B LEFT JOIN UserGroup G ON B.group_id = G.groupID WHERE B.buyer_id=@buyer_id and B.SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_id",entity.BuyerId),
                new SqlParameter("@SELLER_ID",entity.SELLER_ID),
                new SqlParameter("@buyer_nick",entity.BuyerNick)
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

       public static DataTable GetBuyerNoPhone(string sellerNick, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_id,buyer_nick from Buyer_" + Seller_Id + " where SELLER_ID = @sellerNick and cellPhone is null ";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
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
       /// 根据buyerID查询买家昵称
       /// </summary>
       /// <param name="buyerID"></param>
       /// <returns></returns>
       public static string GetBuyerNickByID(string buyerID, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_nick from Buyer_" + Seller_Id + " where buyer_id= @buyer_id";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_id",buyerID)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0) { return dt.Rows[0]["buyer_nick"].ToString(); }
               return "";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "";
           }
       }


       public static DataTable GetBuyerInfoBySellerNick(string sellerNick, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_id,grade,trade_amount from Buyer_" + Seller_Id + " where SELLER_ID = @SELLER_ID ";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query,param, CommandType.Text);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static string GetBuyerIdByBuyerNick(string buyerNick, string sellerNick, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_id from Buyer_" + Seller_Id + " where buyer_nick = @buyer_nick and SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_nick",buyerNick),
                new SqlParameter("@SELLER_ID",sellerNick)
            };
               DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
               if (dt != null && dt.Rows.Count > 0)
               {
                   return dt.Rows[0]["buyer_id"].ToString();
               }
               return "";
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return "";
           }
       }


       public static int GetBuyerTotalCount(string sellerNick, string Seller_Id)
       {
           var totalCount = 0;
           var query = " select count(1)  as totalCount from Buyer_" + Seller_Id + " where SELLER_ID = @SELLER_ID";
           SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNick)
            };
           DataTable ds = DataBase.ExecuteDt(query, param, CommandType.Text);
           if (ds != null && ds.Rows.Count > 0)
           {
               totalCount = Convert.ToInt32(ds.Rows[0]["totalCount"].ToString());
           } 
            return  totalCount;
       }

       /// <summary>
       /// 获取所有会员信息
       /// </summary>
       /// <returns></returns>
       public static DataTable GetBuyerInfo(string buyerNick,string status,string area,string grade,string group,string tradeAmount1,
           string tradeAmount2, string sellerNick2, string buyCount, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_id,buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,status,grade,province,trade_amount,trade_count,group_id,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time from Buyer_"+Seller_Id+" where SELLER_ID = @SELLER_ID  ";
               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(buyerNick))
               {
                   query += " AND buyer_nick = @buyerNick ";
                   SqlParameter p1 = new SqlParameter("@buyerNick", buyerNick);  
                    list.Add(p1);
               }
               if (!status.Equals("all"))
               {
                   query += " AND status = @status ";
                   SqlParameter P2 = new SqlParameter("@status", status);
                   list.Add(P2);
               }
               if (!area.Equals("all"))
               {
                   query += " AND province like @area ";
                   SqlParameter P3 = new SqlParameter("@area", "%" + area + "%");
                   list.Add(P3);
               }
               if (!grade.Equals("all"))
               {
                   query += " AND grade = @grade ";
                  SqlParameter P4 = new SqlParameter("@grade", grade);
                   list.Add(P4);
               }         
               if (!string.IsNullOrEmpty(tradeAmount1))
               {
                   query += " AND trade_amount >= @tradeAmount1 ";
                   SqlParameter P5 = new SqlParameter("@tradeAmount1", tradeAmount1);
                   list.Add(P5);
               }
               if (!string.IsNullOrEmpty(tradeAmount2))
               {
                   query += " AND trade_amount <= @tradeAmount2 ";
                   SqlParameter P6 = new SqlParameter("@tradeAmount2", tradeAmount2);
                   list.Add(P6);
               }
               if (!string.IsNullOrEmpty(buyCount))
               {
                   query += " AND trade_count = @buyCount ";
                   SqlParameter P66 = new SqlParameter("@buyCount", buyCount);
                   list.Add(P66);
               }
               if (!group.Equals("全部") && !String.IsNullOrEmpty(group))
               {
                   if (group.Equals("新客户")) {
                       query += "AND buyer_nick in(select T.buyer_nick from (select  count(buyer_nick) as buyerCount,buyer_nick from Trade where status = 'TRADE_FINISHED' group by buyer_nick,seller_nick having count(buyer_nick) = 1 and seller_nick = @seller_nick1) as T inner join Buyer B on B.buyer_nick = T.buyer_nick where B.trade_amount > 0 group by T.buyer_nick)";
                       SqlParameter P7 = new SqlParameter("@seller_nick1", sellerNick2);
                       list.Add(P7);
                   }
                   if (group.Equals("老客户"))
                   {
                       query += "AND buyer_nick in(select T.buyer_nick from (select  count(buyer_nick) as buyerCount,buyer_nick from Trade where status = 'TRADE_FINISHED' group by buyer_nick,seller_nick having count(buyer_nick) > 1 and seller_nick = @seller_nick1) as T inner join Buyer B on B.buyer_nick = T.buyer_nick where B.trade_amount > 0 group by T.buyer_nick)";
                       SqlParameter P8 = new SqlParameter("@seller_nick1", sellerNick2);
                       list.Add(P8);
                   }
                   if (group.Equals("休眠3个月"))
                   {
                       query += "AND buyer_nick in(select buyer_nick from Buyer where trade_amount > 0 and DATEDIFF(day,last_trade_time,getdate()) >= 90 and SELLER_ID = @seller_nick1 group by buyer_nick) ";
                       SqlParameter P9 = new SqlParameter("@seller_nick1", sellerNick2);
                       list.Add(P9);
                   }
                   if (group.Equals("潜在客户"))
                   {
                       query += "AND buyer_nick in(select buyer_nick from Buyer where trade_amount = 0 and SELLER_ID = @seller_nick1) ";
                       SqlParameter P10 = new SqlParameter("@seller_nick1", sellerNick2);
                       list.Add(P10);
                   }
                  
               }

               SqlParameter P11 = new SqlParameter("@SELLER_ID", sellerNick2);
               list.Add(P11);

               query += " order by last_trade_time desc ";
               SqlParameter[] strParam = list.ToArray();
               DataTable ds = DataBase.ExecuteDt(query, strParam, CommandType.Text);
               return ds;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 发送短信查询
       /// </summary>
       /// <returns></returns>
       public static DataTable GetBuyerInfoToMsg(string buyerNick, string lastTradeDate1, string lastTradeDate2, string grade,string num1, string num2,
           string area, string tradeAmount1, string tradeAmount2, string sellerNick2, string drpDay, string tradePinNv, string buyCount, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_id,buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,status,grade,province,
                                trade_amount,group_id,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time,memo from Buyer_"+Seller_Id+@" where cellPhone != '' and SELLER_ID = @SELLER_ID  ";
               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(drpDay))
               {
                   //过滤几天内发了的不再发
                   query += "and cellPhone not in (select cellPhone from MsgSendHis  where DATEDIFF(dd,sendDate,getdate()) >= @filterDays and sellerNick = @SELLER_ID)";
                   SqlParameter p = new SqlParameter("@filterDays", drpDay);
                   list.Add(p);
                   //query += " and  buyer_nick in( SELECT buyer_nick FROM TradeOrder WHERE seller_nick = @SELLER_ID AND status = 'TRADE_FINISHED' AND title like @productTitle) ";
                   //SqlParameter p = new SqlParameter("@productTitle", "%" + productTitle + "%");
                   //list.Add(p);

               }
               if (!string.IsNullOrEmpty(buyerNick))
               {
                   query += " AND buyer_nick = @buyerNick ";
                   SqlParameter p1 = new SqlParameter("@buyerNick", buyerNick);
                   list.Add(p1);
               }
               if (!string.IsNullOrEmpty(lastTradeDate1))
               {
                   query += " AND last_trade_time >= @last_trade_time1 ";
                   SqlParameter P2 = new SqlParameter("@last_trade_time1", Convert.ToDateTime(lastTradeDate1));
                   list.Add(P2);
               }
               if (!string.IsNullOrEmpty(lastTradeDate2))
               {
                   query += " AND last_trade_time <= @last_trade_time2 ";
                   SqlParameter P3 = new SqlParameter("@last_trade_time2", Convert.ToDateTime(lastTradeDate2));
                   list.Add(P3);
               }
               if (!grade.Equals("all"))
               {
                   query += " AND grade = @grade ";
                   SqlParameter P4 = new SqlParameter("@grade", grade);
                   list.Add(P4);
               }
               if (!string.IsNullOrEmpty(num1))
               {
                   query += " AND item_num >= @item_num1 ";
                   SqlParameter P5 = new SqlParameter("@item_num1", num1);
                   list.Add(P5);
               }
               if (!string.IsNullOrEmpty(num2))
               {
                   query += " AND item_num <= @item_num2 ";
                   SqlParameter P6 = new SqlParameter("@item_num2", num2);
                   list.Add(P6);
               }
               if (!area.Equals("all"))
               {
                   query += " AND province like @area ";
                   SqlParameter P7 = new SqlParameter("@area", "%" + area + "%");
                   list.Add(P7);
               }
               if (!string.IsNullOrEmpty(tradeAmount1))
               {
                   query += " AND trade_amount >= @tradeAmount1 ";
                   SqlParameter P8 = new SqlParameter("@tradeAmount1", tradeAmount1);
                   list.Add(P8);
               }
               if (!string.IsNullOrEmpty(tradeAmount2))
               {
                   query += " AND trade_amount <= @tradeAmount2 ";
                   SqlParameter P9 = new SqlParameter("@tradeAmount2", tradeAmount2);
                   list.Add(P9);
               }
               if (!string.IsNullOrEmpty(buyCount))
               {
                   query += " AND trade_count = @buyCount ";
                   SqlParameter P99 = new SqlParameter("@buyCount", buyCount);
                   list.Add(P99);
               }
               //按客户购买频率
               if (!tradePinNv.Equals("all"))
               {
                   if (tradePinNv.Equals("3"))
                   {
                       query += " AND last_trade_time <= DateAdd(m,-3,getdate()) ";
                   }
                   if (tradePinNv.Equals("6"))
                   {
                       query += " AND last_trade_time <= DateAdd(m,-6,getdate()) ";
                   }
                   if (tradePinNv.Equals("12"))
                   {
                       query += " AND last_trade_time <= DateAdd(m,-12,getdate()) ";
                   } 
               }
               SqlParameter P11 = new SqlParameter("@SELLER_ID", sellerNick2);
               list.Add(P11);
               query += " order by last_trade_time desc ";
               SqlParameter[] strParam = list.ToArray();
               DataTable ds = DataBase.ExecuteDt(query, strParam, CommandType.Text);
               return ds;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }



       /// <summary>
       /// EXCEL导出会员数据
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetExportBuyers(string SELLER_ID, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,case grade when 0 then '潜在会员'
                                when 1 then '普通会员' when 2 then '高级会员' when 3 then 'VIP会员' when 4 then '至尊VIP会员' end as grade,
                                province,trade_amount,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time,address, birthDay
                                from Buyer_" + Seller_Id + @" where SELLER_ID = @SELLER_ID";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",SELLER_ID)   
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

       public static DataTable GetExportBuyers(string sql)
       {
           try
           {
               string query = sql;
              
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }

       }

       public static DataTable GetExportBuyers(string SELLER_ID, string startDate, string endDate, string area, string tradeAmountFrom, string tradeAmountTo, string Seller_Id)
       {
           try
           {
               string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,case grade when 0 then '潜在会员'
                                when 1 then '普通会员' when 2 then '高级会员' when 3 then 'VIP会员' when 4 then '至尊VIP会员' end as grade,
                                province,trade_amount,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time,address, birthDay
                                from Buyer_" + Seller_Id + " where 1 = 1 ";

               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(SELLER_ID))
               {
                   query += " AND SELLER_ID = @SELLER_ID ";
                   SqlParameter p1 = new SqlParameter("@SELLER_ID", SELLER_ID);
                   list.Add(p1);
               }
               if (!string.IsNullOrEmpty(startDate))
               {
                   query += " AND last_trade_time >= @startDate ";
                   SqlParameter P2 = new SqlParameter("@startDate", startDate);
                   list.Add(P2);
               }
               if (!string.IsNullOrEmpty(endDate))
               {
                   query += " AND last_trade_time <= @endDate ";
                   SqlParameter P3 = new SqlParameter("@endDate", endDate);
                   list.Add(P3);
               }
               if (!area.Equals("all"))
               {
                   query += " AND province like @area ";
                   SqlParameter P4 = new SqlParameter("@area", "%" + area + "%");
                   list.Add(P4);
               }
               if (!string.IsNullOrEmpty(tradeAmountFrom))
               {
                   query += " AND trade_amount >= @tradeAmountFrom ";
                   SqlParameter P5 = new SqlParameter("@tradeAmountFrom", tradeAmountFrom);
                   list.Add(P5);
               }
               if (!string.IsNullOrEmpty(tradeAmountTo))
               {
                   query += " AND trade_amount <= @tradeAmountTo ";
                   SqlParameter P6 = new SqlParameter("@tradeAmountTo", tradeAmountTo);
                   list.Add(P6);
               }
               query += " order by last_trade_time desc";
               SqlParameter[] strParam = list.ToArray();
               DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 手工添加用户时，检查是否有相同手机号码
       /// </summary>
       /// <param name="buyerID"></param>
       /// <param name="sellerNick"></param>
       /// <returns></returns>
       public Boolean CheckTheSameHPNoIsExit(string sellerNick, string cellphone, string Seller_Id)
       {
           try
           {
               string query = @"SELECT 1 FROM Buyer_" + Seller_Id + " WHERE SELLER_ID = @sellerNick AND cellPhone = @cellPhone";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@cellPhone",cellphone)
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

       /// <summary>
       /// 卖家手动添加买家基本信息.
       /// </summary>
       /// <param name="o"></param>
       /// <param name="sellerID"></param>
       /// <returns></returns>
       public bool AddBuyerBySeller(Buyers o, string Seller_Id)
       {
           try
           {
               string query = @"insert into Buyer_"+Seller_Id+ @"(buyer_id,SELLER_ID,buyer_nick,buyer_reallName,cellPhone,Phone,qq,msn,zipCode,
                                email,sinaWeibo,qqWeibo,province,city,createDate,buyerType,last_trade_time,trade_amount,item_num,trade_count,grade)
                                values(@buyer_id,@SELLER_ID,@buyer_nick,@buyer_reallName,@cellPhone,@Phone,@qq,@msn,@zipCode,
                                @email,@sinaWeibo,@qqWeibo,@province,@city,getdate(),@buyerType,@last_trade_time,@trade_amount,@item_num,@trade_count,@grade)";
               SqlParameter[] param = new SqlParameter[] 
                {
                   new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID),
                    new SqlParameter("@buyer_nick",o.BuyerNick),
                    new SqlParameter("@buyer_reallName",o.Buyer_reallName==null?"":o.Buyer_reallName),
                    new SqlParameter("@cellPhone",o.CellPhone==null?"":o.CellPhone),
                    new SqlParameter("@Phone",o.Phone==null?"":o.Phone),
                    new SqlParameter("@qq",o.QQ==null?"":o.QQ),
                    new SqlParameter("@msn",o.MSN==null?"":o.MSN),
                    new SqlParameter("@zipCode",o.ZipCode==null?"":o.ZipCode),
                    new SqlParameter("@email",o.Email==null?"":o.Email),
                    new SqlParameter("@sinaWeibo",o.SinaWeibo==null?"":o.SinaWeibo),
                    new SqlParameter("@qqWeibo",o.QQWeibo==null?"":o.QQWeibo),
                    new SqlParameter("@province",o.BuyerProvince.ToString()==null?"":o.BuyerProvince.ToString()),
                    new SqlParameter("@city",o.City==null?"":o.City),
                    new SqlParameter("@last_trade_time",o.LastTradeTime==null?"":o.LastTradeTime),
                    new SqlParameter("@trade_amount",o.TradeAmount.ToString()==null?"":o.TradeAmount.ToString()),
                    new SqlParameter("@item_num",o.ItemNum==null?1L:o.ItemNum),
                    new SqlParameter("@trade_count",o.TradeCount==null?1L:o.TradeCount),
                    new SqlParameter("@grade",o.Grade),
                    new SqlParameter("@buyerType","0"),//0表示自己店铺的会员
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


       /// <summary>
       /// 卖家手动添加其他店铺的买家基本信息.
       /// </summary>
       /// <param name="o"></param>
       /// <param name="sellerID"></param>
       /// <returns></returns>
       public bool AddBuyerOtherShop(Buyers o, string Seller_Id)
       {
           try
           {
               string query = @"insert into Buyer_"+Seller_Id+@"(buyer_id,SELLER_ID,buyer_nick,province,city,address,buyer_credit,createDate,buyerType)
                                values(@buyer_id,@SELLER_ID,@buyer_nick,@province,@city,@address,@buyer_credit,getdate(),@buyerType)";
               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",o.BuyerId),
                    new SqlParameter("@SELLER_ID",o.SELLER_ID),
                    new SqlParameter("@buyer_nick",o.BuyerNick),
                    new SqlParameter("@province",o.BuyerProvince.ToString()),
                    new SqlParameter("@city",o.City==null?"":o.City),
                    new SqlParameter("@address",o.Address == null ? "" : o.Address),
                    new SqlParameter("@buyerType",o.BuyerType),
                     new SqlParameter("@buyer_credit",o.Buyer_credit == null ? "0" : o.Buyer_credit)
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

       /// <summary>
       /// 更新买家到黑名单
       /// </summary>
       /// <param name="o"></param>
       /// <returns></returns>
       public static bool UpdateBuyerToBlackList(string buyerId, string Seller_Id)
       {
           try
           {
               string query = @"update Buyer_" + Seller_Id + " set status = 'black' where buyer_id = @buyer_id";
               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyer_id",buyerId)
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

    }
}
