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
    public class BuyerexportDAL
    {
        public  int CheckEndStatus(string sellerId)
        {
            try
            {
                string query = "select top 1 export_status from Buyer_export where buyer_SellerId = @buyer_SellerId order by id desc";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_SellerId",sellerId),
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["export_status"]);
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }  
        }

        public  int InsertExport(string sellerId, string buyer_nick)
        {
            try
            {
                string query = "insert into Buyer_export(buyer_SellerId,buyer_nick,export_time,export_status) values(@buyer_SellerId,@buyer_nick,@export_time,@export_status)";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_nick",buyer_nick),
                new SqlParameter("@buyer_SellerId",sellerId),
                new SqlParameter("@export_time",DateTime.Now.ToString()),
                new SqlParameter("@export_status",1)
            };
                int count = DataBase.ExecuteSql(query, param);
                return count;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }  
        }

        //插入导出语句
        public static int InsertBuyer_ExportSql(string sellerId, string sqlString)
        {
            try
            {
                string query = "insert into Buyer_ExportSql(buyer_SellerId,sqlString) values(@buyer_SellerId,@sqlString)";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sqlString",sqlString),
                new SqlParameter("@buyer_SellerId",sellerId),
            };
                int count = DataBase.ExecuteSql(query, param);
                return count;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }

        //获取导出语句
        public static string GetExportSql(string sellerId)
        {
            try
            {
                string query = "select top 1 sqlString  from Buyer_ExportSql where buyer_SellerId = @buyer_SellerId order by id desc";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_SellerId",sellerId),
            };
                DataTable dt = DataBase.ExecuteDt(query,param,CommandType.Text);
                return dt.Rows[0]["sqlString"].ToString();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public  int UpdateExport(string sellerId,int status)
        {
            try
            {
                string query = "update Buyer_export set  export_status = @export_status where buyer_SellerId = @buyer_SellerId";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_SellerId",sellerId),
                new SqlParameter("@export_status",status)
            };
                int count = DataBase.ExecuteSql(query, param);
                return count;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }  
        }

        public int UpdateExport(string buyer, string time, int status)
        {
            try
            {
                string query = "update Buyer_export set  export_status = @export_status where export_time = @export_time and buyer_nick=@buyer_SellerId";
                // 设置SQL参数
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@export_time",time),
                new SqlParameter("@buyer_SellerId",buyer),
                new SqlParameter("@export_status",status)
            };
                int count = DataBase.ExecuteSql(query, param);
                return count;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }
        //获取申请中的记录
        public  DataTable GetBuyerExport()
        {
            try
            {
                string query = "select buyer_nick,export_time from Buyer_export where export_status =1";

                DataTable dt = DataBase.ExecuteDt(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        //获取全部申请的记录
        public static DataTable GetBuyerExportAll(string sellerId)
        {
            try
            {
                string query = "select export_time as 申请时间,(case export_status WHEN 0 THEN '申请结束' WHEN 1 THEN '申请中' WHEN 2 THEN '申请通过' end) as 申请状态 from Buyer_export where buyer_SellerId=@buyer_SellerId";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@buyer_SellerId",sellerId)
            };
                DataTable dt = DataBase.ExecuteDt(query, param,CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }
    }
}
