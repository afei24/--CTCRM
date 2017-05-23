using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
using CTCRM.Entity;

namespace SynTest
{
    /// <summary>
    /// 交易数据实体
    /// </summary>
 
    public class DBUtil
    {

        public static bool AddNoteTradeToDB(NotifyTrade trade)
        {
            try
            {
                string query = @"INSERT INTO NotifyTrade(tid,buyer_nick,nick,status,oid,payment,seller_nick,createDate)
                                        VALUES(@tid,@buyer_nick,@nick,@status,@oid,@payment,@seller_nick,getdate())";

                SqlParameter[] param = new SqlParameter[] 
                        {
                            new SqlParameter("@tid",trade.Tid),
                            new SqlParameter("@buyer_nick",trade.BuyerNick),  
                            new SqlParameter("@nick",trade.SellerNick),
                            new SqlParameter("@status",trade.Status),
                            new SqlParameter("@oid",trade.Oid),
                            new SqlParameter("@payment",trade.Payment),
                            new SqlParameter("@seller_nick",trade.SellerNick)  
                        };

                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static bool AddTradeOrderDenfense(NotifyTrade trade)
        {
            try
            {
                string query = @"INSERT INTO NotifyTradeForOrderDefense(tid,buyer_nick,oid,seller_nick)
                                 VALUES(@tid,@buyer_nick,@oid,@seller_nick)";

                SqlParameter[] param = new SqlParameter[] 
                        {
                            new SqlParameter("@tid",trade.Tid),
                            new SqlParameter("@buyer_nick",trade.BuyerNick),                            
                            new SqlParameter("@oid",trade.Oid),                      
                            new SqlParameter("@seller_nick",trade.SellerNick)  
                        };
                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static bool UpdateNoteTradeToDB(NotifyTrade trade)
        {
            try
            {
                string query = @"update NotifyTrade set status = @status,modified = getdate() where tid = @tid";

                SqlParameter[] param = new SqlParameter[] 
                        {
                            new SqlParameter("@tid",trade.Tid),
                            new SqlParameter("@status",trade.Status)                          
                        };

                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        public static bool AddNoteMessageToDB(string message)
        {
            try
            {
                string query = @"INSERT INTO MessageFromTOP(message,createDate)VALUES(@message,@createDate)";

                SqlParameter[] param = new SqlParameter[] 
                        {
                            new SqlParameter("@message",message),
                            new SqlParameter("@createDate",DateTime.Now)
                        };

                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static Boolean CheckNoteTradeIsExit(string tid)
        {
            try
            {
                string query = @"select 1 from NotifyTrade where tid = @tid";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@tid",tid)   
            };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
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
    }
}
