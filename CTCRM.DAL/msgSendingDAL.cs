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
    public  class msgSendingDAL
    {
        public static bool Add(string sellerID)
        {
            try
            {
                string query = @"INSERT INTO [msgSending]
                       ([sellerNick]
                       ,[sendStaus]
                       ,[sendDate]
                       ,[count])
                 VALUES
                      ( @sellerNick
                       ,0
                       ,@sendDate
                       ,0)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerID),
                    new SqlParameter("@sendDate",DateTime.Now)
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

        public static DataTable Select(string sellerID)
        {
            try
            {
                string query = @"select * from [msgSending]
                       WHERE sellerNick=@sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerID)
                };
                return DataBase.ExecuteDt(query, param, CommandType.Text);
                
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public static bool update(string sellerID,int status,int count)
        {
            try
            {
                string query = @"UPDATE [msgSending]
                   SET [sendStaus] = @sendStaus
                      ,[sendDate] = @sendDate
                      ,[count] = @count
                 WHERE sellerNick=@sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerID),
                    new SqlParameter("@sendStaus",status),
                    new SqlParameter("@count",count),
                    new SqlParameter("@sendDate",DateTime.Now)
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

        public static bool update(string sellerID, int status)
        {
            try
            {
                string query = @"UPDATE [msgSending]
                   SET [sendStaus] = @sendStaus
                      ,[sendDate] = @sendDate
                 WHERE sellerNick=@sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerID),
                    new SqlParameter("@sendStaus",status),
                    new SqlParameter("@sendDate",DateTime.Now)
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
