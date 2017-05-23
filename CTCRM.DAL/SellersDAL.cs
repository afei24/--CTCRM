using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.Entity;
using System.Data.SqlClient;
using System.Data;
using CHENGTUAN.Entity;
using CHENGTUAN.Components;
using TTNI.Framework.Dao;
using CTCRM.Common;

namespace CTCRM.DAL
{
    public class SellersDAL : GenericDao
    {


        public static DataTable GetBuyerExport()
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


        //添加商家信息
        public  bool Add(Sellers obj)
        {
            try
            {
                string query = @"INSERT INTO SELLER(SELLER_ID,NICK,SELLER_CREADIT,SESSKEY,Refresh_Token,CreatedDate,sellerType,orderDate,endDate,OrderVersion,OrderCyc,shopType)
VALUES(@SELLER_ID,@NICK,@SELLER_CREADIT,@SESSKEY,@Refresh_Token,@CreatedDate,@sellerType,@orderDate,@endDate,@OrderVersion,@OrderCyc,@shopType)";
              

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SELLER_ID",obj.Seller_Id),
                    new SqlParameter("@NICK",obj.Nick),
                    new SqlParameter("@SELLER_CREADIT",obj.Seller_Creadit),
                    new SqlParameter("@SESSKEY",obj.SessionKey),
                    new SqlParameter("@Refresh_Token",obj.Refresh_token),
                    new SqlParameter("@CreatedDate",obj.CreatedDate),
                    new SqlParameter("@sellerType",obj.SellerType == null ? "free":obj.SellerType),
                    new SqlParameter("@orderDate",obj.OrderDate),
                    new SqlParameter("@endDate",obj.EndDate == null ? "":obj.EndDate),
                    new SqlParameter("@OrderVersion",obj.OrderVersion == null ? "":obj.OrderVersion),
                    new SqlParameter("@OrderCyc",obj.OrderCyc),
                    new SqlParameter("@shopType",obj.shopType)
                };
                    DataBase.ExecuteSql(query, param);
                //如果是CRM版本，则创建分表
                    if (!string.IsNullOrEmpty(obj.OrderVersion) && obj.OrderVersion.Equals("会员CRM版"))
                    {

                        ComDbOpen.DbOpen(_DBSession);
                        //清空参数
                        _DBSession.ClearParam();
                        // 设置SQL参数
                        _DBSession.SetInParam("@sellerId", obj.Seller_Id.ToString());
                        _DBSession.ProcVoid("pro_BuyerData");
                        _DBSession.Close();
                    }
                    return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        /// <summary>
        /// 添加一个会员表20160702
        /// </summary>
        /// <param name="seller_id"></param>
        public  void addBuyerData(string seller_id)
        {
            ComDbOpen.DbOpen(_DBSession);
            //清空参数
            _DBSession.ClearParam();
            // 设置SQL参数
            _DBSession.SetInParam("@sellerId", seller_id);
            _DBSession.ProcVoid("pro_BuyerData");
            _DBSession.Close();
        }

        public static void addBuyer(string seller_id)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DataBase.GetSqlConnection());
                connection.Open();
                SqlCommand sqlcmd;
                sqlcmd = new SqlCommand("pro_BuyerData", connection);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.Add(new SqlParameter("sellerId", seller_id));
                //SqlParameter   sqlParme; 
                //sqlParme.Direction = ParameterDirection.Input;
                //sqlParme.Value = shichang.Value.Trim();  
                sqlcmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            } 
        }

        public static int GetSyncMem(string strNick)
        {
            try
            {
                SqlConnection connection = new SqlConnection(DataBase.GetSqlConnection());
                connection.Open(); 
                SqlCommand sqlcmd;
                sqlcmd = new SqlCommand("select SyncMem from Seller where NICK = @snick", connection);
                sqlcmd.Parameters.Add(new SqlParameter("snick", strNick));
                IDataReader sdr = sqlcmd.ExecuteReader();
                int nc = 0;
                while (sdr.Read())
                {
                    nc = sdr.IsDBNull(0) ? 0 : sdr.GetByte(0);
                }
                sdr.Close();
                connection.Close();
                return nc;  
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            } 
        }

        public static Boolean GetTradeFlag(string strNick)
        {
            try
            {
                string query = @"select SynTradeFlag from Seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["SynTradeFlag"] == null ? "0" : dt.Rows[0]["SynTradeFlag"].ToString()) > 0;
                }
                return false;
               
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetSellerIdByNick(string strNick)
        {
            try
            {
                string query = @"select SELLER_ID from Seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["SELLER_ID"].ToString();
                }
                return "";

            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public static string GetSellerOrderDate(string SELLER_ID)
        {
            try
            {
                string query = @"select CreatedDate from Seller where SELLER_ID = @SELLER_ID ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@SELLER_ID",SELLER_ID)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CreatedDate"].ToString();
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetSellerEndDate(string nick)
        {
            try
            {
                string query = @"select endDate from Seller where NICK= @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",nick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["endDate"].ToString();
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetSellerOrderDateByNick(string sellerNick)
        {
            try
            {
                string query = @"select CreatedDate from Seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",sellerNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CreatedDate"].ToString();
                }
                return null;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataRow GetOrderVersion(string strNick)
        {
            try
            {
                string query = @"select OrderVersion,OrderCyc from Seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0];
                }
                return null;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }


        /// <summary>
        /// 检查卖家是否已经同步了数据
        /// </summary>
        /// <param name="strNick"></param>
        /// <returns></returns>
        public static Boolean GetHasSynFlag(string strNick)
        {
            try
            {
                string query = @"select count(1) as memberCount from Buyer where  SELLER_ID = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["memberCount"].ToString()) > 0;
                }
                return false;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }


        public static bool SetSyncMem(string strNick, string strTimespan)
        {
            try
            {
               string query = @"update Seller set SyncMem = 1,SyncTime = @sTime where  NICK = @snick";
               SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@snick",strNick),
                    new SqlParameter("@sTime",strTimespan)
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
        public static bool SetSyncProcess(string strNick, int nProcess)
        {
            try
            {
                string query = @"update Seller set SyncMem = @nProcess where  NICK = @snick";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@snick",strNick),
                    new SqlParameter("@nProcess",nProcess)
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

        public static DataRow GetSelerOrderDate(string sellerNick)
        {
            try
            {
                string query = @"select CreatedDate,OrderVersion,orderDate from Seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",sellerNick)
                };
                DataTable tb = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (tb != null && tb.Rows.Count > 0)
                {
                    return tb.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 交易同步完成后的更新状态
        /// </summary>
        /// <param name="strNick"></param>
        /// <param name="flag"></param>
        /// <returns></returns>
        public static bool SetSyncTradeFlag(string strNick, int flag)
        {
            try
            {
                string query = @"update Seller set SynTradeFlag = @SynTradeFlag where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick),
                    new SqlParameter("@SynTradeFlag",flag)
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
        /// 删除指定昵称的商家信息
        /// </summary>
        /// <param name="strNick"></param>
        /// <returns></returns>
        public static bool DeleteSeller(string strNick)
        {
            try
            {
                string query = @"delete from Seller where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[] {
                    new SqlParameter("@NICK",strNick)                    
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

        public static bool Update(Sellers o)
        {
            try
            {
                string query = @"UPDATE SELLER SET NICK = @NICK,SELLER_CREADIT = @SELLER_CREADIT,
                                SESSKEY = @SESSKEY,Refresh_Token = @Refresh_Token,UpdateDate = @UpdateDate,
                                sellerType = @sellerType,endDate = @endDate,OrderVersion = @OrderVersion WHERE SELLER_ID = @SELLER_ID";
               
                    SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SELLER_ID",o.Seller_Id),
                    new SqlParameter("@NICK",o.Nick),
                    new SqlParameter("@SELLER_CREADIT",o.Seller_Creadit),
                    new SqlParameter("@SESSKEY",o.SessionKey), 
                    new SqlParameter("@Refresh_Token",o.Refresh_token),
                    new SqlParameter("@UpdateDate",o.UpdateDate),
                    new SqlParameter("@sellerType",o.SellerType == null ? "free":o.SellerType),
                    new SqlParameter("@endDate",o.EndDate == null ? "":o.EndDate),
                    new SqlParameter("@OrderVersion",o.OrderVersion == null ? "体验版":o.OrderVersion)
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

        public static Boolean CheckSellerIsExit(string sellerNick)
        {
            try
            {
                string query = @"SELECT 1 FROM ExportMemberAuth WHERE sellerNick = @sellerNick ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
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

        public static bool UpdateSellerSynDate(Sellers entity)
        {
            try
            {
                string query = @"update Seller set synDate = getdate(),updateDate = getdate() WHERE NICK = @sellerNick";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@sellerNick",entity.Nick)
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


        public static bool AddSellerExportAuth(string sellerNick)
        {
            try
            {
                string query = @"INSERT INTO ExportMemberAuth(sellerNick,createDate)VALUES(@sellerNick,getdate())";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
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
        /// 将卖家设置为不可用
        /// </summary>
        /// <param name="SELLER_ID"></param>
        /// <returns></returns>
        public static bool UpdateSellerStatus(string SELLER_ID)
        {
            try
            {
                string query = @"update Seller set currentStatus = 1 where SELLER_ID = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SELLER_ID",SELLER_ID)
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

        public static DataTable GetSellerSynDate(string sellerNick)
        {
            try
            {
                string query = @"select synDate from Seller where NICK = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@SELLER_ID",sellerNick)
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
        /// 获取客户的电话号码
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static DataTable GetSellerCountHavePhone(string sellerNick)
        {
            string query = @"select NICK,CellPhone from seller where CellPhone !='' ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND NICK = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }                     
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }


        public static string GetSellerNickById(string SELLER_ID)
        {
            try
            {
                string query = @"select NICK from Seller where SELLER_ID = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SELLER_ID",SELLER_ID)
                    };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["NICK"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
        }

        /// <summary>
        /// 开启同步操作
        /// </summary>
        /// <param name="strNick">商家昵称</param>
        /// <returns>成功返回true，异常返回false</returns>
        public static Boolean UpdateTradeFlag(string strNick)
        {
            try
            {
                string query = @"update Seller set SynTradeFlag = 1 where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@NICK",strNick)
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
        /// 从数据库中获取卖家sessionKey
        /// </summary>
        /// <param name="SELLER_ID">卖家昵称</param>
        /// <returns></returns>
        public static string GetSellerSessionKey(string SELLER_ID)
        {
            try
            {
                string query = @"select SESSKEY from Seller where nick = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SELLER_ID",SELLER_ID)
                    };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["SESSKEY"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
        }

        /// <summary>
        /// 将不可用卖家的短信账户清除
        /// </summary>
        /// <param name="SELLER_ID"></param>
        /// <returns></returns>
        public static bool UpdateSellerMsgStatus(string SELLER_ID)
        {
            try
            {
                string query = @"update MsgTrans set msgCanUseCount = 0, msgTotalCount = 0, serviceStatus = 0 
                                where sellerNick = @SELLER_ID";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@SELLER_ID",SELLER_ID)
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

        public static bool UpdateSellerSYNData(string SELLER_ID)
        {
            try
            {
                string query = @"update Seller set SynTradeFlag = 0 where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@NICK",SELLER_ID)
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
        /// 删除指定卖家的所有数据
        /// </summary>
        /// <param name="SELLER_ID"></param>
        /// <returns></returns>
        public static bool DeleteSellersInfo(string SELLER_ID)
        {
            try
            {
                string query = @"delete from Buyer where  SELLER_ID = @sellerNick";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query, param);

                string query2 = @"delete from BuyerJifen where  sellerNick = @sellerNick";
                SqlParameter[] param2 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query2, param2);

                string query3 = @"delete from Grade where  sellerNick = @sellerNick";
                SqlParameter[] param3 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query3, param3);

                string query4 = @"delete from MsgPackage where  sellerNick = @sellerNick";
                SqlParameter[] param4 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query4, param4);

                string query5 = @"delete from MsgSendConfig where  sellerNick = @sellerNick";
                SqlParameter[] param5 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query5, param5);

                string query6 = @"delete from MsgSendHis where  sellerNick = @sellerNick";
                SqlParameter[] param6 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query6, param6);

                string query7 = @"delete from MsgTemp where  sellerNick = @sellerNick";
                SqlParameter[] param7 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query7, param7);

                string query8 = @"delete from MsgTrans where  sellerNick = @sellerNick";
                SqlParameter[] param8 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query8, param8);

                string query9 = @"delete from Seller where  NICK = @sellerNick";
                SqlParameter[] param9 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query9, param9);

                string query10 = @"delete from NotifyTrade where  seller_nick = @sellerNick";
                SqlParameter[] param10 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query10, param10);

                string query11 = @"delete from SellerJifenConfig where  sellerNick = @sellerNick";
                SqlParameter[] param11 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query11, param11);

                string query12 = @"delete from SellerShop where  nick = @sellerNick";
                SqlParameter[] param12 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query12, param12);

                string query13 = @"delete from Trade where  seller_nick = @sellerNick";
                SqlParameter[] param13 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query13, param13);

                string query14 = @"delete from TradeOrder where  seller_nick = @sellerNick";
                SqlParameter[] param14 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query14, param14);

                string query15 = @"delete from UserGroup where  sellerNick = @sellerNick";
                SqlParameter[] param15 = new SqlParameter[]{
                new SqlParameter("@sellerNick",SELLER_ID)
                    };
                DataBase.ExecuteSql(query15, param15);

                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }



        /// <summary>
        /// 判断卖家是否已经下载过会员数据
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static bool UpdateExportDataStatus(string sellerNick)
        {
            try
            {
                string query = @"update Seller set IsDownData = 1 where NICK = @nick";
                SqlParameter[] param = new SqlParameter[]{
                new SqlParameter("@nick",sellerNick)
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
        /// 返回开通了全店会员资料导出权限的卖家
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable GetExportDataSeller(string sellerNick, string startDate, string endDate, string auditSatus)
        {
            string query = @"select * from  ExportMemberAuth where 1 = 1 ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND sellerNick = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                query += " AND createDate >= @startDate ";
                SqlParameter p2 = new SqlParameter("@startDate", startDate);
                list.Add(p2);
            }
            query += " order by createDate desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 查询卖家短信账户
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable GetSellerMsgAccount(string sellerNick, string startDate, string endDate)
        {
            string query = @"select sellerNick,packageName,unUseDate,msgCanUseCount,msgTotalCount,serviceStatus,sendPrecent from MsgTrans where 1 = 1 ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND sellerNick = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                query += " AND unUseDate >= @startDate ";
                SqlParameter p2 = new SqlParameter("@startDate", startDate);
                list.Add(p2);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                query += " AND unUseDate <= @endDate";
                SqlParameter p3 = new SqlParameter("@endDate", endDate);
                list.Add(p3);
            }
            query += " order by msgCanUseCount desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }

        public static int UpdateSellerMsgsendPrecent(string sellerNick, int sendPrecent)
        {
            string query = @"update MsgTrans set sendPrecent=@sendPrecent  where 1 = 1 ";
            List<SqlParameter> list = new List<SqlParameter>();
            SqlParameter p2 = new SqlParameter("@sendPrecent", sendPrecent);
            list.Add(p2);
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND sellerNick = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }

            SqlParameter[] strParam = list.ToArray();
            int i = DataBase.ExecuteSql(query, strParam);
            return i;
        }

        public static DataTable GetSellerReminderStatus(string sellerNick, string startDate, string endDate,string type)
        {
            string query = @"select sellerNick,createDate,unPayType,payType,shippingType,delayShippingType,arrivedType,signType,huiZJType from MsgSendConfig where 1 = 1 ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND sellerNick = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!type.Equals("全部"))
            {
                if (type.Equals("发货提醒"))
                {
                    query += " AND shippingType = 1 ";
                }
                if (type.Equals("延时发货提醒"))
                {
                    query += " AND delayShippingType = 1 ";
                }
                if (type.Equals("催款提醒"))
                {
                    query += " AND unPayType = 1 ";
                }
                if (type.Equals("到货提醒"))
                {
                    query += " AND arrivedType = 1 ";
                }
                if (type.Equals("付款提醒"))
                {
                    query += " AND payType = 1 ";
                }
                if (type.Equals("签收提醒"))
                {
                    query += " AND signType = 1 ";
                }
                if (type.Equals("回款提醒"))
                {
                    query += " AND huiZJType = 1 ";
                }
            }
            query += " order by CONVERT(datetime,createDate,0) desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }
        /// <summary>
        /// 增加内容审核功能
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable GetSellerReminderCusAduit(string sellerNick, string startDate, string endDate)
        {
            string query = @"
                            select M.sellerNick,
                            case when M.isUnpayMsgCus = 1 then M.unpayMsgCus end as unpayMsgCus,
                            case when M.isPayMsgCus = 1 then M.payMsgCus end as payMsgCus,
                            case when M.isShippingMsgCus = 1 then M.shippingNofityMsgCus end as shippingNofityMsgCus,
                            case when M.isArrivedMsgCus = 1 then M.arrivedNofityMsgCus end as arrivedNofityMsgCus,
                            case when M.isDelayShippingMsgCus = 1 then M.delayShippingNofityMsgCus end as delayShippingNofityMsgCus,
                            case when M.isHuiZJMsgCus = 1 then M.huiZJNofityMsgCus end as huiZJNofityMsgCus,
                            case when M.isSignMsgCus = 1 then M.signNotifyMsgCus end as signNotifyMsgCus
                            from MsgSendConfig M 
                            INNER JOIN Seller S ON M.sellerNick = S.NICK
                            where (unpayMsgCus is not null 
                            or shippingNofityMsgCus is not null 
                            or arrivedNofityMsgCus is not null) 
                            AND CONVERT(datetime,S.endDate,0) > GETDATE() ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND M.sellerNick = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                query += " AND M.createDate >= @startDate ";
                SqlParameter p2 = new SqlParameter("@startDate", startDate);
                list.Add(p2);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                query += " AND M.createDate <= @endDate";
                SqlParameter p3 = new SqlParameter("@endDate", endDate);
                list.Add(p3);
            }
            query += " order by CONVERT(datetime,M.createDate,0) desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }

        /// <summary>
        /// 系统中短信未使用情况统计
        /// </summary>
        /// <returns></returns>
        public static DataTable GetUnUsedMsgAccount()
        {
            string query = @"select sum(msgCanUseCount) as totalCount, sum(msgCanUseCount)*0.04 as spendMoney from MsgTrans ";
            DataTable dt = DataBase.ExecuteDt(query);
            return dt;
        }

        /// <summary>
        /// 调整卖家的短信条数
        /// </summary>
        /// <returns></returns>
        public static Boolean UpdateMsgAccount(string sellerNick,string msgCount)
        {
            try
            {
                string query = @"update MsgTrans set msgCanUseCount =  @msgCanUseCount, serviceStatus = 1  where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@msgCanUseCount",msgCount),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新用户到期时间 2016-11-06 yao
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static Boolean UpdateUnUseDate(string time,string nick)
        {
            try
            {
                string query = @"update MsgTrans set unUseDate =  @unUseDate  where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@unUseDate",time),
                new SqlParameter("@sellerNick",nick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean UpdateReminderUnConfirmType(string sellerNick, string unConfirmType)
        {
            try
            {
                string query = @"update MsgSendConfig set payType = @payType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@payType",unConfirmType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean UpdateReminderUnPayType(string sellerNick, string unPayType)
        {
            try
            {
                string query = @"update MsgSendConfig set unPayType = @unPayType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@unPayType",unPayType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean UpdateReminderShippingType(string sellerNick, string shippingType)
        {
            try
            {
                string query = @"update MsgSendConfig set shippingType = @shippingType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@shippingType",shippingType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean UpdateReminderArrivedType(string sellerNick, string arrivedType)
        {
            try
            {
                string query = @"update MsgSendConfig set arrivedType = @arrivedType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@arrivedType",arrivedType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean UpdateReminderSignType(string sellerNick, string signType)
        {
            try
            {
                string query = @"update MsgSendConfig set signType = @signType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@signType",signType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static Boolean UpdateReminderHuiZJType(string sellerNick, string type)
        {
            try
            {
                string query = @"update MsgSendConfig set huiZJType = @huiZJType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@huiZJType",type),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static Boolean UpdateReminderDelayShipType(string sellerNick, string delayShipType)
        {
            try
            {
                string query = @"update MsgSendConfig set delayShippingType = @delayShippingType,updateDate = getdate() where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@delayShippingType",delayShipType),
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 查询数据库中已经过期的卖家
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static DataTable GetEndDateSellers(string sellerNick, string startDate, string endDate)
        {
            string query = @"select SELLER_ID,NICK,UpdateDate,endDate from  Seller where endDate < getdate() ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND NICK = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                query += " AND endDate >= @startDate ";
                SqlParameter p2 = new SqlParameter("@startDate", startDate);
                list.Add(p2);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                query += " AND endDate <= @endDate";
                SqlParameter p3 = new SqlParameter("@endDate", endDate);
                list.Add(p3);
            }
            query += " order by endDate desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }


        public static Boolean GetList(Sellers entity)
        {
            try
            {
                string query = @"SELECT 1 FROM SELLER WHERE NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",entity.Nick)
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

        public static int GetSellerOrderdDays(string sellerNick)
        {
            try
            {
                string query = @"select DateDiff(day,cast(orderDate as datetime),cast(endDate as datetime)) as leftDays from seller where NICK = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["leftDays"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }

        public static Boolean HasShop(Sellers entity)
        {
            try
            {
                string query = @"SELECT has_shop FROM SELLER WHERE NICK=@NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",entity.Nick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0]["has_shop"]);
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static bool SetShopName(Sellers obj)
        {
            try
            {
                string query = @"update Seller set SignShopName = @SignShopName,CellPhone = @CellPhone where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@SignShopName",obj.SignShopName),
                    new SqlParameter("@CellPhone",string.IsNullOrEmpty(obj.Cellphone)?"":obj.Cellphone),
                    new SqlParameter("@NICK",obj.Nick)
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

        public static string GetAppendID(Sellers entity)
        {
            try
            {
                string query = @"select Appendid from Seller where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",entity.Nick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["Appendid"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
        }

        public static string GetMAXAppendID(Sellers entity)
        {
            try
            {
                string query = @"select max(Appendid) maxAPID from Seller";
                DataTable dt = DataBase.ExecuteDt(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["maxAPID"].ToString();
                }
                return "0";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }


        public static string GetMAXAppendID()
        {
            try
            {
                string query = @"select max(CAST(Appendid AS int)) as MAXAppendID from Seller";
                DataTable dt = DataBase.ExecuteDt(query);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["MAXAppendID"].ToString();
                }
                return "0";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }

        public static string GetShopName(string nick)
        {
            try
            {
                string query = @"select SignShopName from Seller where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",nick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["SignShopName"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }

           
        }
        public static string GetSellerPhone(string nick)
        {
            try
            {
                string query = @"select CellPhone from Seller where NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",nick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["CellPhone"].ToString();
                }
                return "";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
        }
        public static DataTable getAppID()
        {
            try
            {
                string query = @"select NICK,SignShopName,Appendid,CreatedDate from Seller order by CreatedDate";
                DataTable dt = DataBase.ExecuteDt(query);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public static DataTable getSellerAppID(string nick)
        {
            try
            {
                string query = @"select Appendid from Seller where nick = @nick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nick",nick)
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

        public static bool UpdateAppID(Sellers obj)
        {
            try
            {
                string query = @"update Seller set Appendid = @appendid where nick = @nick";


                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@appendid",obj.Appendid),
                    new SqlParameter("@nick",obj.Nick)
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

        public static DataTable GetSellersAppendID(string sellerNick, string startDate, string endDate)
        {
            string query = @"select NICK,SignShopName,Appendid,CreatedDate from  Seller where 1 = 1 ";
            List<SqlParameter> list = new List<SqlParameter>();
            if (!string.IsNullOrEmpty(sellerNick))
            {
                query += " AND NICK = @sellerNick ";
                SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                list.Add(p1);
            }
            if (!string.IsNullOrEmpty(startDate))
            {
                query += " AND CreatedDate >= @startDate ";
                SqlParameter p2 = new SqlParameter("@startDate", startDate);
                list.Add(p2);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                query += " AND CreatedDate <= @endDate";
                SqlParameter p3 = new SqlParameter("@endDate", endDate);
                list.Add(p3);
            }
            query += " order by CreatedDate desc";
            SqlParameter[] strParam = list.ToArray();
            DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
            return dt;
        }


        public static DataTable GetSellers()
        {
            string query = @"select NICK,CellPhone,CreatedDate from seller ";
            DataTable dt = DataBase.ExecuteDt(query);
            return dt;
        }

        /// <summary>
        /// 获取卖家code
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        public static  DataTable GetSellersCode(string nick)
        {
            string query = @"select * from Seller_code where nick='"+nick+"'";
            DataTable dt = DataBase.ExecuteDt(query);
            return dt;
        }


        /// <summary>
        /// 添加卖家code
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool AddSellersCode(string nick, string code)
        {
            try
            {
                string query = @"INSERT INTO [Seller_code]
                   ([nick]
                   ,[code]
                   ,[updateTime])
             VALUES
                   (@nick
                   ,@code
                   ,@updateTime)";


                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",nick),
                    new SqlParameter("@code",code),
                    new SqlParameter("@updateTime",DateTime.Now)
                };
                int i = DataBase.ExecuteSql(query, param);
                //如果是CRM版本，则创建分表
                if (i <=0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 更新卖家code
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool UpdateSellersCode(string nick, string code)
        {
            try
            {
                string query = @"UPDATE [Seller_code]
                   SET [code] = @code
                      ,[updateTime] = @updateTime
                 WHERE nick=@nick";


                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@nick",nick),
                    new SqlParameter("@code",code),
                    new SqlParameter("@updateTime",DateTime.Now)
                };
                int i = DataBase.ExecuteSql(query, param);
                //如果是CRM版本，则创建分表
                if (i <= 0)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static DataTable GetSellerRecords(string sellernick, string startDate, string endDate)
        {
            try
            {
                string query = @"SELECT [sellernick]
                  ,[type]
                  ,[orderdate]
                  ,[endDate]
                  ,[BuyType]
              FROM [SellerRecords] where 1=1";

                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellernick))
                {
                    query += " AND sellernick = @sellerNick ";
                    SqlParameter p1 = new SqlParameter("@sellerNick", sellernick);
                    list.Add(p1);
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND orderdate >= @startDate ";
                    SqlParameter p2 = new SqlParameter("@startDate", startDate);
                    list.Add(p2);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    query += " AND orderdate <= @endDate";
                    SqlParameter p3 = new SqlParameter("@endDate", endDate);
                    list.Add(p3);
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
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


        //添加商家订购信息
        public bool AddSellerRecords(string sellernick,string type,string endDate ,string BuyType)
        {
            try
            {
                string query = @"INSERT INTO [SellerRecords]
                   ([sellernick]
                   ,[type]
                   ,[orderdate]
                   ,[endDate]
                   ,[BuyType])
             VALUES
                   (@sellernick
                   ,@type
                   ,@orderdate
                   ,@endDate
                   ,@BuyType)";
              

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellernick",sellernick),
                    new SqlParameter("@type",type),
                    new SqlParameter("@orderdate",DateTime.Now),
                    new SqlParameter("@endDate",endDate),
                    new SqlParameter("@BuyType",BuyType)
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
