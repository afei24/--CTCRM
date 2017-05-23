using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
using System.Data.SqlClient;


namespace MeesageAtuoSendService
{
    public class LogisticsDAL
    {

        /// <summary>
        /// 添加物流信息到数据库
        /// </summary>
        /// <param name="logstic"></param>
        /// <returns></returns>
        public static bool AddLogistics(LogsticDetailTrace logstic)
        {
            try
            {
                string query = @"insert into tab_logistics(tid,action,company_name,out_sid,action_desc,time)
                        values(@tid,@action,@company_name,@out_sid,@desc,@time)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",logstic.Tid),
                    new SqlParameter("@action",logstic.Action),
                    new SqlParameter("@company_name",logstic.Company_name),
                    new SqlParameter("@out_sid",logstic.Out_side),
                    new SqlParameter("@desc",logstic.Desc),
                    new SqlParameter("@time",logstic.Time),
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
        /// 查询该交易订单的物流数据是否已经存在
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static bool TidIsExist(string tid)
        {
            try
            {
                string query = @"select 1 from tab_logistics where tid = @tid";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@tid",tid),
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }

        }

        /// <summary>
        /// 更新物流信息
        /// </summary>
        /// <param name="logstic"></param>
        /// <returns></returns>
        public static bool updateLogistics(LogsticDetailTrace logstic)
        {
            try
            {
                string query = @"update tab_logistics set action=@action,action_desc=@desc,time=@time where tid=@tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",logstic.Tid),
                    new SqlParameter("@action",logstic.Action),
                    new SqlParameter("@desc",logstic.Desc),
                    new SqlParameter("@time",logstic.Time),
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
        /// 获取交易的物流状态
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static string getLogisticsStatusByTid(string tid)
        {
            try
            {
                string query = @"select action from tab_logistics where tid=@tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",tid),
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count == 1)
                {
                    return dt.Rows[0]["action"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return string.Empty;
            }
            return string.Empty;
        }
    }
}
