using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CTCRM.DAL
{
    public class UserTempMsgOrderDAL
    {
        public static bool Add(string orderId, string nick, string FW_GOODS)
        {
            try
            {
                string query = @"INSERT INTO [UserTempMsgOrder]
                   ([orderId]
                   ,[nick]
                   ,[status]
                    ,CreateDate
                   ,[FW_GOODS])
             VALUES
                   (@orderId
                   ,@nick
                   ,@status
                    ,@CreateDate
                   ,@FW_GOODS)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@orderId",orderId),
                    new SqlParameter("@nick",nick),
                    new SqlParameter("@status","create"),
                    new SqlParameter("@CreateDate",DateTime.Now),
                    new SqlParameter("@FW_GOODS",FW_GOODS)
                    
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
        public static DataTable GetBuyerNick(string nick, string CreateDate)
        {
            try
            {
                string query = @"SELECT * 
          FROM [UserTempMsgOrder] where nick = @nick and CreateDate<=@CreateDate";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",nick),
                    new SqlParameter("@CreateDate",CreateDate)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count == 1)
                {
                    return dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }
        public static DataTable GetBuyerNick(string nick)
        {
            try
            {
                string query = @"SELECT * 
          FROM [UserTempMsgOrder] where nick = @nick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",nick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count == 1)
                {
                    return dt;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public static bool Delete(string nick)
        {
            try
            {
                string query = @"DELETE FROM [UserTempMsgOrder]
                    WHERE nick=@nick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",nick)
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
