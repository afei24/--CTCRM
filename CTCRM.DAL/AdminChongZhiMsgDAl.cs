using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.DAL
{
    public class AdminChongZhiMsgDAl
    {
        public static bool AddAdminChongZhiMsg(string MsgCount, decimal Price)
        {
            try
            {
                string query = @"INSERT INTO AdminChongZhiMsg
                       ([MsgCount]
                       ,[Price]
                       ,[Date])
                 VALUES
                       (@MsgCount
                       ,@Price
                       ,@Date)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@MsgCount",MsgCount),
                    new SqlParameter("@Price",Price),
                    new SqlParameter("@Date",DateTime.Now)
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

        public static DataTable GetAdminChongZhiMsg(string startDate, string endDate)
        {
            try
            {
                string query = @"SELECT id,
                      [MsgCount]
                      ,[Price]
                      ,[Date]
                  FROM AdminChongZhiMsg";

                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " where Date >= @startDate ";
                    SqlParameter p2 = new SqlParameter("@startDate", startDate);
                    list.Add(p2);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    query += " AND Date <= @endDate";
                    SqlParameter p3 = new SqlParameter("@endDate", endDate);
                    list.Add(p3);
                }
                query += " order by Date desc";
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

        public static bool DeleteAdminChongZhiMsg(string id)
        {
            try
            {
                string query = @"delete from  AdminChongZhiMsg
                       where id=@id";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@id",id)
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
