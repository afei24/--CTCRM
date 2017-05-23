using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTCRM.DAL;
using Top.Api.Domain;
using System.Data;

namespace CTCRM.Components
{
    public class TradeBLL
    {

        public static bool AddTrade(Trade o)
        {
            return TradeDAL.AddTrade(o);
        }

        public static bool AddOrder(Order o, long tid)
        {
            return TradeDAL.AddOrder(o, tid);
        }

        public static Boolean CheckOrderIsExit(long oid)
        {
            return TradeDAL.CheckOrderIsExit(oid);
        }

        public static Boolean CheckTradeIsExit(long tid)
        {
            return TradeDAL.CheckTradeIsExit(tid);
        }
        public static bool UpdateTrade(Trade o)
        {
            return TradeDAL.UpdateTrade(o);
        }

        public static DataTable GetOrderByOID(string oid)
        {
            return TradeDAL.GetOrderByOID(oid);
        }
        public static bool UpdateOrder(Order o, long tid)
        {
            return TradeDAL.UpdateOrder(o, tid);
        }
        public static DataTable GetTradeByTID(string tid)
        {
            return TradeDAL.GetTradeByTID(tid);
        }
        public static DataTable GetTradeData(string sellerNick)
        {
            return TradeDAL.GetTradeData(sellerNick);
        }
        public static DataTable GetTradeData(string sellerNick, string status)
        {
            return TradeDAL.GetTradeData(sellerNick, status);
        }
        /// <summary>
        /// 查询卖家已经确认收获，但物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNosign(string sellerNick, string status)
        {
            return TradeDAL.GetTradeDataNosign(sellerNick, status);
        }

        public static DataTable GetTradeDataNoSuccess(string sellerNick, string status)
        {
            return TradeDAL.GetTradeDataNoSuccess(sellerNick, status);
        }

        /// <summary>
        /// 查询卖家物流已经签收，但未确认收货的买家的订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeData(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            return TradeDAL.GetTradeData(sellerNick, startDate, endDate, startPay, endDPay, status);
        }

        /// <summary>
        /// 查询卖家已经确认收获，但物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNosign(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            return TradeDAL.GetTradeDataNosign(sellerNick, startDate, endDate, startPay, endDPay, status);
        }

        /// <summary>
        /// 查询物流未签收的买家订单
        /// </summary>
        /// <param name="sellerNick"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static DataTable GetTradeDataNoSuccess(string sellerNick, string startDate, string endDate, string startPay, string endDPay, string status)
        {
            return TradeDAL.GetTradeDataNoSuccess(sellerNick, startDate, endDate, startPay, endDPay, status);
        }
    }
}
