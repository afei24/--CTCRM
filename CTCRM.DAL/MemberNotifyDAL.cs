using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;

namespace CTCRM.DAL
{
    public class MemberNotifyDAL
    {
        public static DataTable GetUnpayNotifyByNick(string startDate, string endDate, string buyerNick, string sellerNick)
        {
            try
            {
                string query = @"SELECT distinct B.cellPhone,M.tid,M.buyer_nick,M.created,M.title,M.total_fee FROM Buyer B INNER JOIN (
                                SELECT T.tid,O.buyer_nick,Convert(char,cast(T.created as datetime),111) as created,O.title,O.total_fee FROM TradeOrder O 
                                LEFT JOIN Trade T ON O.tid = T.tid WHERE O.status = 'WAIT_BUYER_PAY' ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(buyerNick))
                {
                    query += " AND O.buyer_nick = @buyer_nick ";
                    SqlParameter p1 = new SqlParameter("@buyer_nick", buyerNick);
                    list.Add(p1);
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND T.created >= @startDate ";
                    SqlParameter p2 = new SqlParameter("@startDate", startDate);
                    list.Add(p2);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    query += " AND T.created <= @endDate";
                    SqlParameter p3 = new SqlParameter("@endDate", endDate);
                    list.Add(p3);
                }
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND O.seller_nick = @seller_nick";
                    SqlParameter p4 = new SqlParameter("@seller_nick", sellerNick);
                    list.Add(p4);
                }
                query += ") M ON B.buyer_nick = M.buyer_nick order by M.created desc";
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

        public static DataTable GetConfirmNotifyByNick(string startDate, string endDate, string buyerNick, string sellerNick)
        {
            try
            {
                string query = @"SELECT distinct B.cellPhone,M.tid,M.buyer_nick,M.modified,M.title,M.total_fee FROM Buyer B INNER JOIN (
                                SELECT T.tid,O.buyer_nick,Convert(char,cast(T.created as datetime),111) as created,O.title,O.total_fee FROM TradeOrder O 
                                LEFT JOIN Trade T ON O.tid = T.tid WHERE O.status = 'WAIT_BUYER_CONFIRM_GOODS' ";
                List<SqlParameter> list = new List<SqlParameter>();
                if (!string.IsNullOrEmpty(buyerNick))
                {
                    query += " AND O.buyer_nick = @buyer_nick ";
                    SqlParameter p1 = new SqlParameter("@buyer_nick", buyerNick);
                    list.Add(p1);
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND T.created >= @startDate ";
                    SqlParameter p2 = new SqlParameter("@startDate", startDate);
                    list.Add(p2);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    query += " AND T.created <= @endDate";
                    SqlParameter p3 = new SqlParameter("@endDate", endDate);
                    list.Add(p3);
                }
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND O.seller_nick = @seller_nick";
                    SqlParameter p4 = new SqlParameter("@seller_nick", sellerNick);
                    list.Add(p4);
                }
                query += ") M ON B.buyer_nick = M.buyer_nick order by M.modified desc";
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

        //检查参数
        //修改人：LU
        //日期：20160909
        public static bool AddMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"insert into MsgSendConfig(
sellerNick,unPayType,unpayMsg,payType,payMsg,shippingType,shippingNofityMsg,delayShippingType,delayShippingNofityMsg,
arrivedType,arrivedNofityMsg,signType,signNofityMsg,returnGoodsType,returnGoodsMsg,buyerLevel,amount,shopName,createDate)
values(
@sellerNick,@unPayType,@unpayMsg,@payType,@payMsg,@shippingType,@shippingNofityMsg,@delayShippingType,@delayShippingNofityMsg,
@arrivedType,@arrivedNofityMsg,@signType,@signNofityMsg,@returnGoodsType,@returnGoodsMsg,@buyerLevel,@amount,@shopName,getdate())";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@unPayType",o.UnPayType),
                    new SqlParameter("@unpayMsg",string.IsNullOrEmpty(o.UnpayMsg)?"":o.UnpayMsg),
                    new SqlParameter("@payType",o.PayType),
                    new SqlParameter("@payMsg",string.IsNullOrEmpty(o.PayMsg)?"":o.PayMsg),
                    new SqlParameter("@shippingType",o.ShippingType),
                    new SqlParameter("@shippingNofityMsg",string.IsNullOrEmpty(o.ShippingNofityMsg)?"":o.ShippingNofityMsg),
                    new SqlParameter("@delayShippingType",o.DelayShippingType),
                    new SqlParameter("@delayShippingNofityMsg", string.IsNullOrEmpty(o.DelayShippingNofityMsg)?"":o.DelayShippingNofityMsg),
                    new SqlParameter("@arrivedType",o.ArrivedType),
                    new SqlParameter("@arrivedNofityMsg", string.IsNullOrEmpty(o.ArrivedNofityMsg)?"":o.ArrivedNofityMsg),
                    new SqlParameter("@signType",o.SignType),
                    new SqlParameter("@signNofityMsg", string.IsNullOrEmpty(o.SignNofityMsg)?"":o.SignNofityMsg),
                    new SqlParameter("@returnGoodsType",o.ReturnGoodsType),
                    new SqlParameter("@returnGoodsMsg",string.IsNullOrEmpty(o.ReturnGoodsMsg)?"未设置":o.ReturnGoodsMsg),
                    new SqlParameter("@buyerLevel",o.BuyerLevel),
                    new SqlParameter("@shopName",o.ShopName),
                    new SqlParameter("@amount",o.Amount)
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

        //       public static bool UpdateMsgContent(MsgSendConfig o)
        //       {
        //           try
        //           {
        //               string query = @"update MsgSendConfig set unPayType = @unPayType,payType = @payType,
        //                                shippingType = @shippingType,buyerLevel=@buyerLevel,amount = @amount,shippingNofityMsg = @shippingNofityMsg, 
        //                                updateDate = GETDATE() where sellerNick = @sellerNick";

        //               SqlParameter[] param = new SqlParameter[] 
        //                {
        //                    new SqlParameter("@unPayType",o.UnPayType),
        //                    new SqlParameter("@payType",o.PayType),
        //                    new SqlParameter("@shippingType",o.ShippingType),
        //                    new SqlParameter("@buyerLevel",o.BuyerLevel),
        //                    new SqlParameter("@amount",o.Amount),
        //                    new SqlParameter("@shippingNofityMsg",o.ShippingNofityMsg), 
        //                    new SqlParameter("@sellerNick",o.SellerNick)
        //                };
        //               DataBase.ExecuteSql(query, param);

        //               return true;
        //           }
        //           catch (Exception ex)
        //           {
        //               ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
        //               return false;
        //           }
        //       }

        public static bool UpdateMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set
                                unPayType = @unPayType,
                                unpayMsg = @unpayMsg,
                                unpayMsgCus = @unpayMsgCus,
                                isUnpayMsgCus = @isUnpayMsgCus,

                                payType = @payType,
                                payMsg = @payMsg,
                                payMsgCus = @payMsgCus,
                                isPayMsgCus = @isPayMsgCus,

                                shippingType  = @shippingType,
                                shippingNofityMsg = @shippingNofityMsg,
                                shippingNofityMsgCus = @shippingNofityMsgCus,
                                isShippingMsgCus = @isShippingMsgCus,
                                
                                delayShippingType  = @delayShippingType,
                                delayShippingNofityMsg = @delayShippingNofityMsg,
                                delayShippingNofityMsgCus = @delayShippingNofityMsgCus,
                                isDelayShippingMsgCus = @isDelayShippingMsgCus,

                                arrivedType = @arrivedType,
                                arrivedNofityMsg = @arrivedNofityMsg,
                                arrivedNofityMsgCus = @arrivedNofityMsgCus,
                                isArrivedMsgCus = @isArrivedMsgCus,

                                signType = @signType,
                                signNofityMsg = @signNofityMsg,
                                signNotifyMsgCus = @signNotifyMsgCus,
                                isSignMsgCus = @isSignMsgCus,
                                
                                huiZJType = @huiZJType,
                                huiZJNofityMsg = @huiZJNofityMsg,
                                huiZJNofityMsgCus = @huiZJNofityMsgCus,
                                isHuiZJMsgCus = @isHuiZJMsgCus,

                                buyerLevel= @buyerLevel,
                                amount = @amount, 
                                shopName = @shopName,
                                updateDate = GETDATE()
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@unPayType",o.UnPayType),
                    new SqlParameter("@unpayMsg",o.UnpayMsg),
                    new SqlParameter("@unpayMsgCus",o.UnpayMsgCus),
                    new SqlParameter("@isUnpayMsgCus",o.IsUnpayMsgCus),

                    new SqlParameter("@payType",o.PayType),
                    new SqlParameter("@payMsg",o.PayMsg),
                    new SqlParameter("@payMsgCus",o.PayMsgCus),
                    new SqlParameter("@isPayMsgCus",o.IsPayMsgCus),

                    new SqlParameter("@shippingType",o.ShippingType),
                    new SqlParameter("@shippingNofityMsg",o.ShippingNofityMsg),
                    new SqlParameter("@shippingNofityMsgCus",o.ShippingNofityMsgCus),
                    new SqlParameter("@isShippingMsgCus",o.IsShippingMsgCus),

                    new SqlParameter("@delayShippingType",o.DelayShippingType),
                    new SqlParameter("@delayShippingNofityMsg",o.DelayShippingNofityMsg),
                    new SqlParameter("@delayShippingNofityMsgCus",o.DelayShippingNofityMsgCus),
                    new SqlParameter("@isDelayShippingMsgCus",o.IsDelayShippingMsgCus),

                    new SqlParameter("@arrivedType",o.ArrivedType),
                    new SqlParameter("@arrivedNofityMsg",o.ArrivedNofityMsg),
                    new SqlParameter("@arrivedNofityMsgCus",o.ArrivedNofityMsgCus),
                    new SqlParameter("@isArrivedMsgCus",o.IsArrivedMsgCus),

                    new SqlParameter("@signType",o.SignType),
                    new SqlParameter("@signNofityMsg",o.SignNofityMsg),
                    new SqlParameter("@signNotifyMsgCus",o.SignNotifyMsgCus),
                    new SqlParameter("@isSignMsgCus",o.IsSignMsgCus),

                    new SqlParameter("@huiZJType",o.HuiZJType),
                    new SqlParameter("@huiZJNofityMsg",o.HuiZJNofityMsg),
                    new SqlParameter("@huiZJNofityMsgCus",o.HuiZJNofityMsgCus),
                    new SqlParameter("@isHuiZJMsgCus",o.IsHuiZJMsgCus),

                    new SqlParameter("@buyerLevel",o.BuyerLevel),
                    new SqlParameter("@amount",o.Amount),
                     new SqlParameter("@shopName",o.ShopName),
                    new SqlParameter("@sellerNick",o.SellerNick)
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
        /// 20160828 create yao
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool UpdateOtherParm(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig set amount = @amount, updateDate = GETDATE() where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@amount",o.Amount),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdatePayMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig set payType = @payType,payMsg = @payMsg,payMsgCus= @payMsgCus,isPayMsgCus = @isPayMsgCus, 
                                updateDate = GETDATE() where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@payType",o.PayType),
                    new SqlParameter("@payMsg",o.PayMsg),
                    new SqlParameter("@payMsgCus",o.PayMsgCus),
                    new SqlParameter("@isPayMsgCus",o.IsPayMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateUnPayMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                unPayType = @unPayType,
                                unpayMsg = @unpayMsg,
                                unpayMsgCus = @unpayMsgCus,
                                isUnpayMsgCus = @isUnpayMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@unPayType",o.UnPayType),
                    new SqlParameter("@unpayMsg",o.UnpayMsg),
                    new SqlParameter("@unpayMsgCus",o.UnpayMsgCus),
                    new SqlParameter("@isUnpayMsgCus",o.IsUnpayMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateShippingMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                shippingType = @shippingType,
                                shippingNofityMsg = @shippingNofityMsg,
                                shippingNofityMsgCus= @shippingNofityMsgCus,
                                isShippingMsgCus = @isShippingMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@shippingType",o.ShippingType),
                    new SqlParameter("@shippingNofityMsg",o.ShippingNofityMsg),
                    new SqlParameter("@shippingNofityMsgCus",o.ShippingNofityMsgCus),
                    new SqlParameter("@isShippingMsgCus",o.IsShippingMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateArrivedMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                arrivedType = @arrivedType,
                                arrivedNofityMsg = @arrivedNofityMsg,
                                arrivedNofityMsgCus= @arrivedNofityMsgCus,
                                isArrivedMsgCus = @isArrivedMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@arrivedType",o.ArrivedType),
                    new SqlParameter("@arrivedNofityMsg",o.ArrivedNofityMsg),
                    new SqlParameter("@arrivedNofityMsgCus",o.ArrivedNofityMsgCus),
                    new SqlParameter("@isArrivedMsgCus",o.IsArrivedMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateDelayShippingMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                delayShippingType = @delayShippingType,
                                delayShippingNofityMsg = @delayShippingNofityMsg,
                                delayShippingNofityMsgCus= @delayShippingNofityMsgCus,
                                isDelayShippingMsgCus = @isDelayShippingMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@delayShippingType",o.DelayShippingType),
                    new SqlParameter("@delayShippingNofityMsg",o.DelayShippingNofityMsg),
                    new SqlParameter("@delayShippingNofityMsgCus",o.DelayShippingNofityMsgCus),
                    new SqlParameter("@isDelayShippingMsgCus",o.IsDelayShippingMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateReturnGoodsMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                returnGoodsType = @returnGoodsType,
                                returnGoodsMsg = @returnGoodsMsg,
                                returnGoodsMsgCus= @returnGoodsMsgCus,
                                isReturnGoodsCus = @isReturnGoodsCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@returnGoodsType",o.ReturnGoodsType),
                    new SqlParameter("@returnGoodsMsg",o.ReturnGoodsMsg),
                    new SqlParameter("@returnGoodsMsgCus",o.ReturnGoodsMsgCus),
                    new SqlParameter("@isReturnGoodsCus",o.IsReturnGoodsCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateSignMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                signType = @signType,
                                signNofityMsg = @signNofityMsg,
                                signNotifyMsgCus= @signNotifyMsgCus,
                                isSignMsgCus = @isSignMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@signType",o.SignType),
                    new SqlParameter("@signNofityMsg",o.SignNofityMsg),
                    new SqlParameter("@signNotifyMsgCus",o.SignNotifyMsgCus),
                    new SqlParameter("@isSignMsgCus",o.IsSignMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static bool UpdateHuiZJMsgConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"update MsgSendConfig 
                                set 
                                huiZJType = @huiZJType,
                                huiZJNofityMsg = @huiZJNofityMsg,
                                huiZJNofityMsgCus= @huiZJNofityMsgCus,
                                isHuiZJMsgCus = @isHuiZJMsgCus, 
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@huiZJType",o.HuiZJType),
                    new SqlParameter("@huiZJNofityMsg",o.HuiZJNofityMsg),
                    new SqlParameter("@huiZJNofityMsgCus",o.HuiZJNofityMsgCus),
                    new SqlParameter("@isHuiZJMsgCus",o.IsHuiZJMsgCus),
                    new SqlParameter("@sellerNick",o.SellerNick)
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

        public static Boolean CheckMsgConfigIsExit(MsgSendConfig o)
        {
            try
            {
                string query = @"SELECT 1 FROM MsgSendConfig WHERE sellerNick=@sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",o.SellerNick)  
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

        /// <summary>
        /// 检查这种类型是否存在 2016-10-09 yao c
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean CheckMsgConfigTypeIsExit(MsgSendConfig o)
        {
            try
            {
                string query = @"SELECT 1 FROM tab_MsgConfig WHERE sellerNick=@sellerNick and warnType=@warnType";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",o.SellerNick),
                new SqlParameter("@warnType",o.warnType)  
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

        /// <summary>
        /// 获取单个某一个提醒类型的信息
        /// </summary>
        /// <param name="selleNick"></param>
        /// <param name="warnType"></param>
        /// <returns></returns>
        public static DataTable getWarnInfo(string selleNick, string warnType)
        {
            try
            {
                string query = @"select * from tab_MsgConfig where sellerNick=@sellerNick and warnType=@warnType";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",selleNick),
                new SqlParameter("@warnType",warnType)  
            };

                DataTable dt = DataBase.ExecuteDt(query, param, CommandType.Text);
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 添加警告2016-10-09 yao c
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean addWarnConfig(MsgSendConfig o)
        {
            try
            {
                string query = @"insert into tab_MsgConfig(sellerNick,unPayType,unpayMsg,threeDayType,blackListType,areaList,areaType,warnType,createDate,amount,amountMax)" +
                    "values(@sellerNick,@unPayType,@unpayMsg,@threeDayType,@blackListType,@areaList,@areaType,@warnType,getdate(),@amount,@amountMax)";
                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@unPayType",o.UnPayType),
                    new SqlParameter("@unpayMsg",string.IsNullOrEmpty(o.UnpayMsg)?"":o.UnpayMsg),
                    new SqlParameter("@threeDayType",o.threeDayType),
                    new SqlParameter("@blackListType",o.blackListType),
                    new SqlParameter("@areaList",string.IsNullOrEmpty(o.areList)?"":o.areList),
                    new SqlParameter("@areaType",o.areType),
                    new SqlParameter("@warnType",o.warnType),
                    new SqlParameter("@amount",o.Amount),
                    new SqlParameter("@amountMax",o.AmountMax)
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
        /// 添加警告2016-10-09 yao c
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Boolean updateWarn(MsgSendConfig o)
        {
            try
            {
                string query = @"update tab_MsgConfig 
                                set 
                                unPayType = @unPayType,
                                unpayMsg = @unpayMsg,
                                threeDayType= @threeDayType,
                                blackListType = @blackListType, 
                                areaType = @areaType, 
                                areaList=@areaList,
                                amount=@amount,
                                 amountMax=@amountMax,
                                updateDate = GETDATE() 
                                where sellerNick = @sellerNick and warnType=@warnType ";

                SqlParameter[] param = new SqlParameter[] 
                {
                    new SqlParameter("@sellerNick",o.SellerNick),
                    new SqlParameter("@warnType",o.warnType),
                    new SqlParameter("@unPayType",o.UnPayType),
                    new SqlParameter("@unpayMsg",string.IsNullOrEmpty(o.UnpayMsg)?"":o.UnpayMsg),
                    new SqlParameter("@threeDayType",o.threeDayType),
                    new SqlParameter("@blackListType",o.blackListType),
                    new SqlParameter("@areaType",o.areType),
                    new SqlParameter("@areaList",string.IsNullOrEmpty(o.areList)?"":o.areList),
                    new SqlParameter("@amount",o.Amount),
                    new SqlParameter("@amountMax",o.AmountMax)
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

        public static DataTable GetMsgConfigByBuyerSellerNick(MsgSendConfig entity)
        {
            try
            {
                string query = @"select * from MsgSendConfig where sellerNick = @sellerNick";
                SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@sellerNick",entity.SellerNick)
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


    }
}
