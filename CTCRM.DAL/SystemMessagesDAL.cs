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
    public class SystemMessagesDAL
    {
        public static DataTable QueryAll()
        {
            try
            {
                string query = @"SELECT 
                  [SystemMsg]
                  ,[SystemMsgID]
                  ,[SystemLink]
                  , case [Status] when 1 then '显示' when 0 then '隐藏'  end Status
                  ,[SystemDate]
              FROM [SystemMessages]";


                return DataBase.ExecuteDt(query); ;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public static DataTable GetMsgById(string SystemMsgID)
        {
            try
            {
                string query = @"SELECT 
                  [SystemMsg]
                  ,[SystemMsgID]
                  ,[SystemLink]
                  , case [Status] when 1 then '显示' when 0 then '隐藏'  end Status
                  ,[SystemDate]
              FROM [SystemMessages] where SystemMsgID=@SystemMsgID ";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SystemMsgID",SystemMsgID),

                };

                return DataBase.ExecuteDt(query, param,CommandType.Text);
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 获取显示的系统公告
        /// </summary>
        /// <returns></returns>
        public static DataTable QueryShowMsg()
        {
            try
            {
                string query = @"SELECT top 5 * FROM SystemMessages where Status=1 order by SystemDate desc";
                return DataBase.ExecuteDt(query); ;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public static bool Delete(string SystemMsgID)
        {
            try
            {
                string query = @"delete from  SystemMessages where SystemMsgID = @SystemMsgID";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SystemMsgID",SystemMsgID),

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

        public static bool Insert(string SystemMsg, string SystemLink, int Status)
        {
            
            try
            {
                string query = @"insert into SystemMessages (SystemMsg,SystemLink,Status,SystemDate) values(@SystemMsg,@SystemLink,@Status,@SystemDate)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SystemMsg",SystemMsg),
                    new SqlParameter("@SystemLink",SystemLink),
                    new SqlParameter("@Status",Status),
                    new SqlParameter("@SystemDate",DateTime.Now.ToString())

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

        public static bool Update(string SystemMsg, string SystemLink, int Status,string id)
        {

            try
            {
                string query = @"update SystemMessages set SystemMsg =@SystemMsg,SystemLink = @SystemLink,Status = @Status where SystemMsgID=@SystemMsgID ";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SystemMsg",SystemMsg),
                    new SqlParameter("@SystemLink",SystemLink),
                    new SqlParameter("@SystemMsgID",id),
                    new SqlParameter("@Status",Status)

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
