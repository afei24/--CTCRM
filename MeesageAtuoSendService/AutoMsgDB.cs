using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;

namespace MeesageAtuoSendService
{
  public  class AutoMsgDB
    {
        /// <summary>
        /// 读取卖家设置的短信发送规则
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAutoMsgRuleData(string sellerNick)
        {
            try
            {
                string query = @"select * from tab_MsgConfig where sellerNick = @sellerNick ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
            return null;
        }

        public static DataTable GetSellerInfo(string sellerNick)
        {
            try
            {
                string query = @"select SESSKEY,SignShopName from seller where NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",sellerNick)
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

        public static bool UpdateMsgSendHisStatus(string transNumber, string status, string helpSellerNick)
        {
            try
            {
                string query = @"update MsgSendHisForReminder set sendStatus = @sendStatus,helpSellerNick = @helpSellerNick where transNumber = @transNumber";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",transNumber),
                    new SqlParameter("@helpSellerNick",helpSellerNick),
                    new SqlParameter("@sendStatus",status)
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

        public static Boolean IsAutoMsgWhiteList(string sellerNick)
        {
            try
            {
                string query = @"select sellerNick from WhiteList where sellerNick = @sellerNick ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    //int sendCount = Convert.ToInt32(GetTodaySendCounts(sellerNick));
                    //if (sendCount <= 20)//每个白名单商家每天最多发100条短信
                    //{
                    //    return true;
                    //}
                    return true;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
            return false;
        }

      /// <summary>
      /// 返回达到时间
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="buyerNick"></param>
      /// <returns></returns>
        public static string GetArrivedDate(string sellerNick,string buyerNick)
        {
            try
            {
                string query = @"select sendDate from MsgSendHis where sellerNick = @sellerNick and sendType = '到货提醒' and buyer_nick = @buyer_nick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@buyer_nick",buyerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["sendDate"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
            return "";
        }

      /// <summary>
      /// 返回发货时间
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="buyerNick"></param>
      /// <returns></returns>
        public static string GetShippingDate(string sellerNick, string buyerNick)
        {
            try
            {
                string query = @"select sendDate from MsgSendHis where sellerNick = @sellerNick and sendType = '发货提醒' and buyer_nick = @buyer_nick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@buyer_nick",buyerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["sendDate"].ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "";
            }
            return "";
        }

        public static bool UpdateAccessToken(string token, string refreshToken, string sellerNick)
        {
            try
            {
                string query = @"update Seller set SESSKEY = @sessionKey,Refresh_Token = @Refresh_Token where NICK = @nick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sessionKey",token),
                    new SqlParameter("@Refresh_Token",refreshToken),
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
        /// 有效交易发送成功后删除
      /// </summary>
      /// <param name="tid"></param>
      /// <returns></returns>
        public static bool DeleteValidTid(string tid)
        {
            try
            {
                string query = @"delete from NotifyTrade where tid = @tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",tid)
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

        public static bool DeleteValidTrade()
        {
            try
            {
                string query = @"delete from NotifyTrade where createDate < DATEADD(DAY, -1, getdate()) and status != 'taobao_trade_TradeSellerShip'";
                DataBase.ExecuteSql(query);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public static bool DeleteValidTrade2()
        {
            try
            {
                string query = @"delete from NotifyTrade where createDate < DATEADD(DAY, -7, getdate()) ";
                DataBase.ExecuteSql(query);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 获取卖家店铺名称
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static string GetSellerShopName(string sellerNick)
        {
            try
            {
                string query = @"select title from SellerShop where nick = @nick ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@nick",sellerNick)
            };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                string shopName = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    shopName = dt.Rows[0]["title"].ToString().Trim();
                    if (shopName.Length > 10) { shopName = shopName.Substring(0, shopName.Length - 1) + "..."; }
                }
                return shopName;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 检查卖家当前账户短信足够发送和是否到期
        /// </summary>
        public static Boolean CheckSellerMsgStatus(string sellerNick)
        {
            DataTable tbmsgCanUseCount = GetSellerMsgStatus(sellerNick);
            if (tbmsgCanUseCount != null && tbmsgCanUseCount.Rows.Count > 0)
            {
                var msgCanUseCount = tbmsgCanUseCount.Rows[0]["msgCanUseCount"].ToString();
                var msgEnddate = tbmsgCanUseCount.Rows[0]["unUseDate"].ToString();
                if (!string.IsNullOrEmpty(msgCanUseCount) && Convert.ToInt32(msgCanUseCount) > 0 &&
                    !string.IsNullOrEmpty(msgEnddate) && Convert.ToDateTime(msgEnddate) >= DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }

        public static DataTable GetSellerMsgStatus(string sellerNick)
        {
            try
            {
                string query = @"SELECT msgCanUseCount,unUseDate FROM MsgTrans WHERE sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
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


        public static bool UpdateMsgTransUseCount(string sellerNick, int perMsgCount)
        {
            try
            {
                string query = @"update MsgTrans set msgCanUseCount = msgCanUseCount - @perMsgCount where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@perMsgCount",perMsgCount)
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

        public static bool AddMsgSendHis(MsgSendHis o)
        {
            try
            {
                string query = @"insert into MsgSendHisForReminder(transNumber,sellerNick,buyerMemberId,cellPhone,sendDate,sendStatus,sendType)
                                 values(@transNumber,@sellerNick,@buyerMemberId,@cellPhone,@sendDate,@sendStatus,@sendType)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",o.TransNumber),
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@buyerMemberId",o.Buyer_nick),
                    new SqlParameter("@cellPhone",o.CellPhone),
                    new SqlParameter("@sendDate",o.SendDate),
                    new SqlParameter("@sendStatus",o.SendStatus),
                    new SqlParameter("@sendType",o.SendType),
                };
                DataBase.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                //主键重复，发生异常。ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 更新短信发送成功
        /// </summary>
        /// <param name="transNumber"></param>
        /// <returns></returns>
        public static bool UpdateMsgSendHis(string transNumber, string msgContent)
        {
            try
            {
                string query = @"update MsgSendHisForReminder set msgContent = @msgContent where transNumber = @transNumber";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@transNumber",transNumber),
                    new SqlParameter("@msgContent",msgContent)
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
       /// delete nofify data by tid when send msg successfully.
       /// </summary>
       /// <param name="tid"></param>
       /// <returns></returns>
        public static bool DeleteNotifyByTid(string tid)
        {
            try
            {
                string query = @"delete from NotifyTrade where tid = @tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",tid) 
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
        /// 获得已经开通短信服务的卖家信息:有效期内开通了会员关怀提醒并且短信条数大于0的卖家
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSellerMsgAcount(string sellerNick)
        {
            try
            {
                string query = @"select msgCanUseCount from MsgTrans  
                                where sellerNick = @sellerNick and  msgCanUseCount > 0";//20161022 yao u

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick) 
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
        /// 获取该卖家今天是生日的会员
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAutoMsgBirthDay(string sellerNick)
        {
            try
            {
                string query = @"select trade_amount,buyer_reallName,cellPhone from Buyer where  birthDay = getdate()  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    new SqlParameter("@sellerNick", sellerNick);
                }
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

        public static DataTable GetSellerMaserData(string sellerNick)
        {
            try
            {
                string query = @"select * from SellerReminderMaster where sellerNick = @sellerNick  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    new SqlParameter("@sellerNick", sellerNick);
                }
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

      /// <summary>
      /// 判断短信历史发送记录是否重复
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <param name="buyerNick"></param>
      /// <returns></returns>
        public static Boolean CheckHisSend(string sellerNick, string buyerNick, string sendType)
        {
            try
            {
                string query = @"select 1 as aa from MsgSendHisForReminder 
                                 where sellerNick = @sellerNick and buyerMemberId = @buyerMemberId and sendType = @sendType";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                    new SqlParameter("@buyerMemberId",buyerNick),
                    new SqlParameter("@sendType",sendType)
                };
                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt != null && dt.Rows.Count >= 1)
                {
                    return Convert.ToInt32(dt.Rows[0]["aa"].ToString()) > 0;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
            
        }


        /// <summary>
        /// 查询主动通知信息从DB开始用于发送短信
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick)
        {
            try
            {
                string query = @"select tid,seller_nick,status,buyer_nick,createDate,modified,payment from NotifyTrade  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " where seller_nick = @seller_nick ";
                    SqlParameter p1 = new SqlParameter("@seller_nick", sellerNick);
                    list.Add(p1);
                }
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

      /// <summary>
      /// 查询当天卖家发出去的短信条数
      /// </summary>
      /// <param name="sellerNick"></param>
      /// <returns></returns>
        public static string GetTodaySendCounts(string sellerNick)
        {
            try
            {
                string query = @"select count(1) todayCount from MsgSendHis where sellerNick = @sellerNick and CONVERT(varchar(100),sendDate, 111) = CONVERT(varchar(100), GETDATE(), 111)  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    SqlParameter p1 = new SqlParameter("@sellerNick", sellerNick);
                    list.Add(p1);
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBase.ExecuteDt(query, strParam, CommandType.Text);
                if (dt != null && dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["todayCount"].ToString();
                }
                return "0";
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }

      /// <summary>
      /// 检查买家是否在卖的黑名单里
      /// </summary>
      /// <param name="name"></param>
      /// <param name="operType"></param>
      /// <returns></returns>
      public static bool IsBlackListName(string sellerName,string blackName,string operType)
      {
          try
          {
              string query = @"select * from BlakList where sellerNick = @sellerNick and blakName=@blakName and (operType=@operType or operType='全局') ";
              List<SqlParameter> list = new List<SqlParameter>();
              SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerName),
                    new SqlParameter("@operType",operType),
                    new SqlParameter("@blakName",blackName)
                   
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
              ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
              return false;
          }
      }

    }
}
