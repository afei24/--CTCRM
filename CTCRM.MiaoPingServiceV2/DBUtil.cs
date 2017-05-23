using System;
using System.Collections.Generic;
using System.Text;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data;
using CTCRM.Entity;
using Top.Api.Domain;
using System.Data.SqlClient;

namespace CTCRM.MiaoPingServiceV2
{
  public  class DBUtil
    {

        /// <summary>
        /// 检查秒评用户是否是黑名单用户
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="buerNick"></param>
        /// <returns></returns>
        public static Boolean CheckIsBlacklst(string sellerNick, string buerNick)
        {
            try
            {
                string query = @"select 1 from BlakList where sellerNick = @sellerNick and blakName = @blakName";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@blakName",buerNick)   
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

      /// <summary>
      /// 删除秒评后的无效数据
      /// </summary>
      /// <returns></returns>
        public static bool DeleteValidTradeForMiaoRate(string tid)
        {
            try
            {
                string query = @"delete from NotifyTrade where tid = @tid";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@tid",tid) 
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

        /// <summary>
        /// 查询主动通知信息从DB开始用于发送短信:只取交易完成的数据用于秒评
        /// </summary>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick)
        {
            try
            {
                string query = @"select tid,seller_nick,status,buyer_nick,createDate,payment from NotifyTrade where status = 'taobao_trade_TradeSuccess'  ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " and seller_nick = @seller_nick ";
                    SqlParameter p1 = new SqlParameter("@seller_nick", sellerNick);
                    list.Add(p1);
                }
                SqlParameter[] strParam = list.ToArray();
                DataTable dt = DataBaseTool.ExecuteDt(query, strParam, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 检查差评师用户是否是黑名单用户
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="buerNick"></param>
        /// <returns></returns>
        public static Boolean CheckCloseOrderIsBlacklst(string sellerNick, string buerNick)
        {
            try
            {
                string query = @"select 1 from BlakListCloseOrder where sellerNick = @sellerNick and blakName = @blakName";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick),
                new SqlParameter("@blakName",buerNick)   
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

        /// <summary>
        /// 判断卖家是否开通秒评
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="buerNick"></param>
        /// <returns></returns>
        public static Boolean CheckSellerIsOpenMiao(string sellerNick)
        {
            try
            {
                string query = @"select 1 from RateConfig where sellerNick = @sellerNick and isMiaoRate = 1 and isAutoRating = 1";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",sellerNick)
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

        /// <summary>
        /// 地址拦截配置
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static DataTable GetCloseOrderAddressConfig(string sellerNick, string receiverName, string phone, string receiverAddress)
        {
            try
            {
                string query = @"select matchType,receiverName,receiverAddress,phone from CloseAddressConfig 
                                 where sellerNick = @sellerNick 
                                 and (receiverName = @receiverName or phone = @phone or receiverAddress like @receiverAddress)";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick),
                     new SqlParameter("@receiverName",receiverName),
                      new SqlParameter("@phone",phone),
                       new SqlParameter("@receiverAddress","%" + receiverAddress + "%")
                };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 订单拦截日志
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool AddCloseOrderLog(CloseOrderLog obj)
        {
            try
            {
                string query = @"insert into CloseOrderLog(buyerNick,sellerNick,ordreNo,closeReason,closeTime,closeResult,faildReason)
values(@buyerNick,@sellerNick,@ordreNo,@closeReason,@closeTime,@closeResult,@faildReason)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@buyerNick",obj.BuyerNick),
                    new SqlParameter("@sellerNick",obj.SellerNick),
                    new SqlParameter("@ordreNo",obj.OrdreNo),
                    new SqlParameter("@closeReason",obj.CloseReason),
                    new SqlParameter("@closeTime",DateTime.Now),
                    new SqlParameter("@closeResult",obj.CloseResult),
                    new SqlParameter("@faildReason",obj.FaildReason)
                };
                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                //主键重复，发生异常。ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 获取卖家订单基础拦截策略
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static DataTable GetCloseOrderConfig(string sellerNick)
        {
            try
            {
                string query = @"select * from dbo.CloseOrderConfig where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick) 
                };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 获取卖家对应的SESSIONKEY
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static string GetSellerSessionKey(string sellerNick)
        {
            try
            {
                string query = @"select S.SESSKEY from Seller S
                inner join RateConfig R on S.NICK = R.sellerNick 
                where S.endDate > getdate() and R.isAutoRating = 1
                and S.NICK = @NICK";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",sellerNick)
            };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
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
        /// 获取开通了订单关闭的卖家SESSIONKEY
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static string GetCloseOrderSessionKey(string sellerNick)
        {
            try
            {
                string query = @"select S.SESSKEY from Seller S
                inner join CloseOrderConfig R on S.NICK = R.sellerNick 
                where S.endDate > getdate() and R.isAutoCloseOrder = 1
                and S.NICK = @NICK ";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@NICK",sellerNick)
            };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
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
        /// 获取卖家保存的评价策略
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static DataTable GetSellerRateConfig(string sellerNick)
        {
            try
            {
                string query = @"select content1,content2,content3,result from RateConfig where isAutoRating = 1 and sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick) 
                };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 获取卖家保存的自动评价策略
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public static DataTable GetSellerAutoRateConfig(string sellerNick)
        {
            try
            {
                string query = @"SELECT  [sellerNick]
                  ,[isMiaoRate]
                  ,[isWaitBuyerRate]
                  ,[waitBuyerTimeDay]
                  ,[waitBuyerTimeHour]
                  ,[waitBuyerTimeFen]
                  ,[blackBuyerRatedIsRate]
                  ,[blackBuyerNoRateQiangRateDay]
                  ,[blackBuyerNoRateQiangRateHour]
                  ,[blackBuyerNoRateQiangRateFen]
                  ,[isQiangRate]
                  ,[qiangRateTimeDay]
                  ,[qiangRateTimeHour]
                  ,[qiangRateTimeFen]
                  ,[atuoAddBlackListBadRate]
                  ,[atuoAddBlackListTuiKuan]
                  ,[badRateContent]
                  ,[result]
                  ,[content1]
                  ,[content2]
                  ,[content3]
                  ,[contentChoice]
                  ,[isAutoRating]
              FROM [RateConfig] where isAutoRating = 1 and sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",sellerNick) 
                };
                DataTable dt = DataBaseTool.ExecuteDt(query, param, CommandType.Text);
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 添加卖家评价
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool AddRateHisWithSeller(TradeRate obj,string rateType)
        {
            try
            {
                string query = @"insert into SellerRateHis(oid,tid,nick,result,created,content,rateType)
                                 values(@oid,@tid,@nick,@result,@created,@content,@rateType)";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@oid",obj.Oid),
                    new SqlParameter("@tid",obj.Tid),
                    new SqlParameter("@nick",obj.Nick == null ? "" : obj.Nick),
                    new SqlParameter("@result",obj.Result == null ? "" : obj.Result),
                    new SqlParameter("@created",obj.Created == null ? "" : obj.Created),
                    new SqlParameter("@content",obj.Content == null ? "" : obj.Content),
                    new SqlParameter("@rateType",rateType)
                };
                DataBaseTool.ExecuteSql(query, param);
                return true;
            }
            catch (Exception ex)
            {
                //主键重复，发生异常。ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Data);
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

        public static bool UpdateNoteTradeToDB(NotifyTrade trade)
        {
            try
            {
                string query = @"update NotifyTrade set status = @status where tid = @tid";

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

    }
}
