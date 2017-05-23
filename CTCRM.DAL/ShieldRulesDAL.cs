using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using System;
using System.Collections.Generic;
using System.Data;
using CTCRM.Entity;
using TTNI.Framework.Dao;

namespace CTCRM.DAL
{
    public class ShieldRulesDAL : GenericDao
    {
        /// <summary>
        /// 检查卖家差评拦截开关是否开启
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckCloseOrderConfigIsExit(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "select 1 from CloseOrderConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
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
        /// 查询卖家设置的防差评策略
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GeCloseOrderConfigByNick(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "select * from CloseOrderConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return dt;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public Boolean UpdateAutoCloseOrderStatus(string sellerNick, int openStatus)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "update CloseOrderConfig set isAutoCloseOrder = @isAutoCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@isAutoCloseOrder", openStatus);
                _DBSession.SetInParam("@sellerNick", sellerNick);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public DataTable GetOrderDenfenseListByNick(string sellerNick, string startDate, string endRateDate)
        {
            try
            {
                string query = @"select * from CloseOrderLog where 1 = 1  ";
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND sellerNick = @sellerNick ";
                    _DBSession.SetInParam("@sellerNick", sellerNick);
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND closeTime >= @startDate ";
                    _DBSession.SetInParam("@startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND closeTime <= @rateDate ";
                    _DBSession.SetInParam("@rateDate", endRateDate);
                }
                query += " order by closeTime desc ";
                DataTable ds = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return ds;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        /// <summary>
        /// 检查用户是否开通了秒评和自动评价
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckIsMiaoPingAuto(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "select isMiaoRate from RateConfig where sellerNick = @sellerNick and isAutoRating = 1";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToBoolean(dt.Rows[0]["isMiaoRate"].ToString());
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
        /// 删除评价日志
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean DeleteDefenseLog(string startDate, string endDate)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"delete from CloseOrderLog where closeTime >= @startDate and closeTime <= @rateDate  ";
                if (!string.IsNullOrEmpty(startDate))
                {
                    _DBSession.SetInParam("@startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endDate))
                {
                    _DBSession.SetInParam("@rateDate", endDate);
                }
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }



        /// <summary>
        /// 添加卖家差评防御配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool AddCloseOrderConfig(CloseOrderConfig obj)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"
insert into CloseOrderConfig(sellerNick,isAutoCloseOrder,buyerRegDays,buyerCreditFen,totalBadRateCount,
totalTuiKuanCount,unCertify,cellPhoneClose,unpayMinutesClose,payQuikAddMemo,closeStartDate,closeEndDate,
orderGreaterThan,closeReason,dangerBuyerCloseAndMemo,dangerBuyerNotCloseAddMemo,memoQiZhi,memoContent,createDate)
values(@sellerNick,0,@buyerRegDays,@buyerCreditFen,@totalBadRateCount,
@totalTuiKuanCount,@unCertify,@cellPhoneClose,@unpayMinutesClose,@payQuikAddMemo,@closeStartDate,@closeEndDate,
@orderGreaterThan,@closeReason,@dangerBuyerCloseAndMemo,@dangerBuyerNotCloseAddMemo,@memoQiZhi,@memoContent,getdate())";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", obj.SellerNick);
                _DBSession.SetInParam("@buyerRegDays", obj.BuyerRegDays);
                _DBSession.SetInParam("@buyerCreditFen", obj.BuyerCreditFen);
                _DBSession.SetInParam("@totalBadRateCount", obj.TotalBadRateCount);
                _DBSession.SetInParam("@totalTuiKuanCount", obj.TotalTuiKuanCount);
                _DBSession.SetInParam("@unCertify", obj.UnCertify);
                _DBSession.SetInParam("@cellPhoneClose", obj.CellPhoneClose);
                _DBSession.SetInParam("@unpayMinutesClose", obj.UnpayMinutesClose);
                _DBSession.SetInParam("@payQuikAddMemo", obj.PayQuikAddMemo);
                _DBSession.SetInParam("@closeStartDate", string.IsNullOrEmpty(obj.CloseStartDate) ? "NULL" : obj.CloseStartDate);
                _DBSession.SetInParam("@closeEndDate", string.IsNullOrEmpty(obj.CloseEndDate)?"NULL":obj.CloseEndDate);
                _DBSession.SetInParam("@orderGreaterThan", obj.OrderGreaterThan);
                _DBSession.SetInParam("@closeReason", obj.CloseReason);
                _DBSession.SetInParam("@dangerBuyerCloseAndMemo", obj.DangerBuyerCloseAndMemo);
                _DBSession.SetInParam("@dangerBuyerNotCloseAddMemo", obj.DangerBuyerNotCloseAddMemo);
                _DBSession.SetInParam("@memoQiZhi", obj.MemoQiZhi);
                _DBSession.SetInParam("@memoContent", obj.MemoContent);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 修改卖家差评防御配置
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool UpdateCloseOrderConfig(CloseOrderConfig obj)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"
                                update CloseOrderConfig
                                set buyerRegDays = @buyerRegDays,
                                buyerCreditFen = @buyerCreditFen,
                                totalBadRateCount = @totalBadRateCount,
                                totalTuiKuanCount = @totalTuiKuanCount,
                                unCertify = @unCertify,
                                cellPhoneClose = @cellPhoneClose,
                                unpayMinutesClose = @unpayMinutesClose,
                                payQuikAddMemo = @payQuikAddMemo,
                                closeStartDate = @closeStartDate,
                                closeEndDate = @closeEndDate,
                                orderGreaterThan = @orderGreaterThan,
                                closeReason = @closeReason,
                                dangerBuyerCloseAndMemo = @dangerBuyerCloseAndMemo,
                                dangerBuyerNotCloseAddMemo = @dangerBuyerNotCloseAddMemo,
                                memoQiZhi = @memoQiZhi,
                                memoContent = @memoContent,
                                updateDate = getdate()
                                where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", obj.SellerNick);
                _DBSession.SetInParam("@buyerRegDays", obj.BuyerRegDays);
                _DBSession.SetInParam("@buyerCreditFen", obj.BuyerCreditFen);
                _DBSession.SetInParam("@totalBadRateCount", obj.TotalBadRateCount);
                _DBSession.SetInParam("@totalTuiKuanCount", obj.TotalTuiKuanCount);
                _DBSession.SetInParam("@unCertify", obj.UnCertify);
                _DBSession.SetInParam("@cellPhoneClose", obj.CellPhoneClose);
                _DBSession.SetInParam("@unpayMinutesClose", obj.UnpayMinutesClose);
                _DBSession.SetInParam("@payQuikAddMemo", obj.PayQuikAddMemo);
                _DBSession.SetInParam("@closeStartDate", string.IsNullOrEmpty(obj.CloseStartDate) ? "NULL" : obj.CloseStartDate);
                _DBSession.SetInParam("@closeEndDate", string.IsNullOrEmpty(obj.CloseEndDate) ? "NULL" : obj.CloseEndDate);
                _DBSession.SetInParam("@orderGreaterThan", obj.OrderGreaterThan);
                _DBSession.SetInParam("@closeReason", obj.CloseReason);
                _DBSession.SetInParam("@dangerBuyerCloseAndMemo", obj.DangerBuyerCloseAndMemo);
                _DBSession.SetInParam("@dangerBuyerNotCloseAddMemo", obj.DangerBuyerNotCloseAddMemo);
                _DBSession.SetInParam("@memoQiZhi", obj.MemoQiZhi);
                _DBSession.SetInParam("@memoContent", obj.MemoContent);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public Boolean UpdateCloseDate(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "update CloseOrderConfig set closeStartDate = null,closeEndDate = null where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 获取订单拦截配置信息
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public DataTable GetCloseOrderConfig(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"select * from CloseOrderConfig where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return dt;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public DataTable GetAddressCloseConfig(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"
                                select id,receiverName,receiverAddress,phone,                               
                                memo,case status when 1 then '已生效' when 0 then '已暂停' end as status
                                from CloseAddressConfig where sellerNick = @sellerNick order by createDate desc";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return dt;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public bool DeleteCloseAddressConfig(CloseAddressConfig obj)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"delete from CloseAddressConfig where id = @id";
                // 设置SQL参数
                _DBSession.SetInParam("@id", obj.Id);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 检查地址拦截策略是否创建
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <returns></returns>
        public Boolean CheckCloseAddressConfigIsExit(string sellerNick, string buyerName,string buyerPhone)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "select 1 from CloseAddressConfig where sellerNick = @sellerNick and receiverName = @receiverName and phone = @phone";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                _DBSession.SetInParam("@receiverName", buyerName);
                _DBSession.SetInParam("@phone", buyerPhone);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
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

        public bool AddCloseAddressConfig(CloseAddressConfig obj)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"insert into CloseAddressConfig(sellerNick,receiverName,phone,status,createDate)
                                 values(@sellerNick,@receiverName,@phone,@status,getdate())";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", obj.SellerNick);
                _DBSession.SetInParam("@receiverName", obj.ReceiverName);              
                _DBSession.SetInParam("@phone", obj.Phone);            
                _DBSession.SetInParam("@status", obj.Status);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        public DataTable GetCloseOrderBlakListByNick(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = @"select * from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return dt;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }

        public int GetBlakListCloseOrderCount(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "select count(1) as blakListCount from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                DataTable dt = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                if (dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0]["blakListCount"].ToString());
                }
                return 0;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return 0;
            }
        }

        public bool DeleteAllCloseOrderBlaklist(string sellerNick)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "delete from BlakListCloseOrder where sellerNick = @sellerNick";
                // 设置SQL参数
                _DBSession.SetInParam("@sellerNick", sellerNick);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }
        /// <summary>
        /// 删除卖家黑名单
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool DeleteCloseOrderBlaklist(string blakListID)
        {
            try
            {
                ComDbOpen.DbOpen(_DBSession);
                //清空参数
                _DBSession.ClearParam();
                string query = "delete from BlakListCloseOrder where blakListID = @blakListID";
                // 设置SQL参数
                _DBSession.SetInParam("@blakListID", blakListID);
                _DBSession.ExecuteNonQuery(query);
                _DBSession.Close();
                return true;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return false;
            }
        }

        /// <summary>
        /// 查询有效期内已开通自动评价总数的卖家
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="startDate"></param>
        /// <param name="endRateDate"></param>
        /// <param name="rateType"></param>
        /// <returns></returns>
        public DataTable GetSellerDenfensRateConfig(string sellerNick, string startDate, string endRateDate)
        {
            try
            {
                string query = @"select sellerNick,(case isAutoCloseOrder when 1 then '已开通' ELSE '未开通' END ) AS isAutoCloseOrder 
from CloseOrderConfig C INNER JOIN Seller S
ON C.sellerNick = S.NICK where C.isAutoCloseOrder = 1 and S.endDate >= getdate()  ";
                if (!string.IsNullOrEmpty(sellerNick))
                {
                    query += " AND C.sellerNick = @sellerNick ";
                    _DBSession.SetInParam("@sellerNick", sellerNick);
                }
                if (!string.IsNullOrEmpty(startDate))
                {
                    query += " AND C.createDate >= @startDate ";
                    _DBSession.SetInParam("@startDate", startDate);
                }
                if (!string.IsNullOrEmpty(endRateDate))
                {
                    query += " AND C.createDate <= @rateDate ";
                    _DBSession.SetInParam("@rateDate", endRateDate);
                }
                query += " order by C.createDate desc ";
                DataTable ds = _DBSession.ExecuteDataTable(query);
                _DBSession.Close();
                return ds;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return null;
            }
        }


    }
}
