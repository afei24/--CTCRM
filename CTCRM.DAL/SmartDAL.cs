using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;

namespace CTCRM.DAL
{
   public class SmartDAL
    {
       /// <summary>
        /// 获得最近10天新会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetNewBuyer10Days(string sellerId)
       {
           try
           {
               string query = @"select buyer_id,buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone from Buyer_" + sellerId + @"
                                where cellPhone != '' and DATEDIFF(day,last_trade_time,getdate())<= 10";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }
       /// <summary>
       /// 构建卖家测试号码池
       /// </summary>
       /// <param name="sellerNick"></param>
       /// <param name="phone"></param>
       /// <returns></returns>
       public static bool AddMsgSendHisIntoTestTable(string sellerNick, string phone)
       {
           try
           {
               string query = @"insert into SellerTestPhone(sellerNick,testPhone,createDate)values(@sellerNick,@testPhone,getdate())";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@testPhone",phone)
                };
               DataBase.ExecuteSql(query, param);
               return true;
           }
           catch (Exception ex)
           {
               //ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
               return false;
           }
       }
       /// <summary>
       /// 获得最近30天新会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetNewBuyer30Days(string sellerId)
       {
           try
           {
               string query = @"select buyer_id,buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone from Buyer_" + sellerId + @"
                                where cellPhone != '' and DATEDIFF(day,last_trade_time,getdate())<= 30";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 会员级别
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetBuyersCount(int gradeLevel,string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from Buyer_" + sellerId + @"  where grade = @gradeLevel and cellPhone !=''";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@gradeLevel",gradeLevel)   
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
       /// 活跃度较低但购买力较强的会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetHuoYueDiGouMaiQiangBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from Buyer_" + sellerId + @"  where trade_amount >= 300 and DATEDIFF(day,last_trade_time,getdate()) > 45 and cellPhone !='' ";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }


       /// <summary>
       /// 活跃度一般购物能力也一般的会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetHuoYueBanGouMaiBanBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from Buyer_" + sellerId + " where trade_amount >= 50 and DATEDIFF(day,last_trade_time,getdate()) > 30 and cellPhone !=''";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 活跃度高购物能力一般的会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetHuoYueGaoGouMaiBanBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from Buyer_" + sellerId + " where trade_amount >= 50 and DATEDIFF(day,last_trade_time,getdate()) > 5 and cellPhone != ''";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 活跃度高且购物能力强的会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetHuoYueGaoGouMaiGaoBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from Buyer_" + sellerId + " where trade_amount >= 300 and DATEDIFF(day,last_trade_time,getdate()) > 5 and cellPhone != ''";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 活动
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetHuoDongBuyersCount(string date,string sellerId,string date2)
       {
           try
           {
               string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone from Buyer_" + sellerId + @" where cellPhone != ''  and  last_trade_time > @date and last_trade_time < @date2";
               SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@date",date),
                 new SqlParameter("@date2",date2)
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
       /// 未交易客户营销
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetUnPayBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone from Buyer_" + sellerId + " where grade = 0 and cellPhone != ''";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 下单7天内还未付款的会员
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetUnPay7DaysBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone from Buyer_" + sellerId + " where grade = 0 and DATEDIFF(day,last_trade_time,getdate()) <= 7 and cellPhone != ''";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 根据省份
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetProvinceBuyersCount(string sellerId, List<string> province)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone,province from buyer_" + sellerId + @"  where cellPhone != '' and (";
               List<string> province1 = province;
               for (int i = 0; i < province1.Count; i++)
                {
                    if (i == 0)
                    {
                        query += "province like '%" + province1[i]+"'";
                    }
                    else
                    {
                        query += "or province like '%" + province1[i]+"'";
                    }
                }
               query += ")";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 北方地区
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetBaiFangBuyersCount(string sellerId)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone,province from buyer_" + sellerId + @"  where cellPhone != '' and (province like '%北京%' or province like '%辽宁%' or province like '%黑龙江%' or province like '%吉林%'
                                or province like '%新疆%' or province like '%青海%' or province like '%宁夏%' or province like '%陕西%'
                                or province like '%甘肃%' or province like '%天津%' or province like '%河北%' or province like '%山西%'
                                or province like '%内蒙古 %' or province like '%安徽 %' or province like '%山东%' or province like '%河南%')";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       /// <summary>
       /// 南方地区
       /// </summary>
       /// <param name="SELLER_ID"></param>
       /// <returns></returns>
       public static DataTable GetNanFangBuyersCount(string SELLER_ID)
       {
           try
           {
               string query = @"select buyer_nick,buyer_reallName,cellPhone from buyer_" + SELLER_ID + @" where cellPhone !='' and (province like '%江苏%' or province like '%浙江%' or province like '%上海%' or province like '%湖北%'
                                or province like '%湖南%' or province like '%四川%' or province like '%广西%' or province like '%江西%'
                                or province like '%福建%' or province like '%广东%' or province like '%海南%' or province like '%西藏%'
                                or province like '%台湾%' or province like '%香港%' or province like '%澳门%') ";
               DataTable dt = DataBase.ExecuteDt(query);
               return dt;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static Boolean UpdateSendStatus(string status, string transNumber)
       {
           try
           {
               string query = @"update MsgSendHis set sendStatus = @sendStatus where transNumber = @transNumber";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",transNumber),
                    new SqlParameter("@sendStatus",status)
                };
               DataBase.ExecuteSql(query, param);
               return true;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
               return false;
           }
       }

       /// <summary>
       /// 短信明细写入DB
       /// </summary>
       /// <param name="o"></param>
       /// <returns></returns>
       public static bool AddMsgSendHis(MsgSendHis o)
       {
           try
           {
               string query = @"insert into MsgSendHis(transNumber,sellerNick,buyer_nick,cellPhone,sendDate,sendStatus,sendType,msgContent,helpSellerNick,count)
                                 values(@transNumber,@sellerNick,@buyer_nick,@cellPhone,@sendDate,@sendStatus,@sendType,@msgContent,@helpSellerNick,@count)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",o.TransNumber),
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@buyer_nick",o.Buyer_nick),
                    new SqlParameter("@cellPhone",o.CellPhone),
                    new SqlParameter("@sendDate",o.SendDate),
                    new SqlParameter("@sendStatus",o.SendStatus),
                    new SqlParameter("@sendType",o.SendType),
                    new SqlParameter("@msgContent",o.MsgContent),
                    new SqlParameter("@helpSellerNick",o.HelpSellerNick == null? "":o.HelpSellerNick),
                    new SqlParameter("@count",o.Count)
                };
               DataBase.ExecuteSql(query, param);
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }
       public static bool AddMsgSendHis(MsgSendHis o,string msgChannel)
       {
           try
           {
               string query = @"insert into MsgSendHis(transNumber,sellerNick,buyer_nick,cellPhone,sendDate,sendStatus,sendType,msgContent,helpSellerNick,count,msgChannel)
                                 values(@transNumber,@sellerNick,@buyer_nick,@cellPhone,@sendDate,@sendStatus,@sendType,@msgContent,@helpSellerNick,@count,@msgChannel)";

               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",o.TransNumber),
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@buyer_nick",o.Buyer_nick),
                    new SqlParameter("@cellPhone",o.CellPhone),
                    new SqlParameter("@sendDate",o.SendDate),
                    new SqlParameter("@sendStatus",o.SendStatus),
                    new SqlParameter("@sendType",o.SendType),
                    new SqlParameter("@msgContent",o.MsgContent),
                    new SqlParameter("@helpSellerNick",o.HelpSellerNick == null? "":o.HelpSellerNick),
                    new SqlParameter("@count",o.Count),
                    new SqlParameter("@msgChannel",string.IsNullOrEmpty(msgChannel)?"0":msgChannel)
                };
               DataBase.ExecuteSql(query, param);
               return true;
           }
           catch (Exception ex)
           {
               return false;
           }
       }
    }
}
