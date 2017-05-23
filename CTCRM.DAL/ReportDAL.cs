using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.DAL
{
   public class ReportDAL
    {
       public static DataTable GetNewCusByMonth(string sellerNick,string year, bool week, bool month,bool ji)
       {
           try
           {
               string query = @"select count(1) as newCusCount,@year + ' 年 '+ cast(datepart(month,last_trade_time) as nvarchar(50)) + ' 月' as Cusmonth  from Buyer
                                where  SELLER_ID = @seller_nick ";

               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(year))
               {
                   query += " AND datepart(year,last_trade_time)  = @year ";
                   SqlParameter p1 = new SqlParameter("@year", year);
                   list.Add(p1);
               }
               if (week)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 7 ";
               }
               if (month)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 30 ";
               }
               if (ji)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 90 ";
               }
               query += @" and buyer_nick in  
                        (
                        select T.buyer_nick from (
                        select  count(buyer_nick) as buyerCount,buyer_nick from Trade where seller_nick = @seller_nick and status = 'TRADE_FINISHED'
                        group by buyer_nick having count(buyer_nick) = 1  
                        ) as T
                        inner join Buyer B on B.buyer_nick = T.buyer_nick where B.SELLER_ID = @seller_nick and B.trade_amount > 0 group by T.buyer_nick
                        ) group by datepart(month,last_trade_time) ";
               if (!string.IsNullOrEmpty(sellerNick))
               {
                   SqlParameter p2 = new SqlParameter("@seller_nick", sellerNick);
                   list.Add(p2);
               }
               SqlParameter[] strParam = list.ToArray();
              return DataBase.ExecuteDt(query, strParam, CommandType.Text);
             
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }

       public static DataTable GetOldCusByMonth(string sellerNick, string year, bool week, bool month, bool ji)
       {
           try
           {
               string query = @"select count(1) as oldCusCount,@year + ' 年 '+ cast(datepart(month,last_trade_time) as nvarchar(50)) + ' 月' as Cusmonth  from Buyer
                                where SELLER_ID = @seller_nick ";

               List<SqlParameter> list = new List<SqlParameter>();
               if (!string.IsNullOrEmpty(year))
               {
                   query += " AND datepart(year,last_trade_time)  = @year ";
                   SqlParameter p1 = new SqlParameter("@year", year);
                   list.Add(p1);
               }
               if (week)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 7 ";
               }
               if (month)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 30 ";
               }
               if (ji)
               {
                   query += " and DATEDIFF(day,last_trade_time,getdate()) <= 90 ";
               }
               query += @" and buyer_nick in  
                        (
                        select T.buyer_nick from (
                        select  count(buyer_nick) as buyerCount,buyer_nick from Trade where seller_nick = @seller_nick and status = 'TRADE_FINISHED'
                        group by buyer_nick having count(buyer_nick) > 1  
                        ) as T
                        inner join Buyer B on B.buyer_nick = T.buyer_nick where B.SELLER_ID = @seller_nick and B.trade_amount > 0 group by T.buyer_nick
                        ) group by datepart(month,last_trade_time) ";
               if (!string.IsNullOrEmpty(sellerNick))
               {
                   SqlParameter p2 = new SqlParameter("@seller_nick", sellerNick);
                   list.Add(p2);
               }
               SqlParameter[] strParam = list.ToArray();
               return DataBase.ExecuteDt(query, strParam, CommandType.Text);

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }


       public static DataTable GetBuyerProviceReport(string sellerNick, string startDate, string endDate)
       {
           try
           {
               string query = @"select count(1) as areacount,province + ':' + cast(count(1) as nvarchar(50)) as province from buyer 
                                where province != '0' and SELLER_ID = @SELLER_ID and last_trade_time >= @startDate and last_trade_time <= @endDate 
                                group by province";
               SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SELLER_ID",sellerNick),
                    new SqlParameter("@startDate",startDate),
                    new SqlParameter("@endDate",endDate)                  
                };
               return DataBase.ExecuteDt(query, param, CommandType.Text);

           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
               return null;
           }
       }


    }
}
