using System;
using System.Collections.Generic;
using System.Text;
using Top.Api.Domain;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.MiaoPingServiceV2.TopRating
{
   public class TBTrade
    {
        /// <summary>
        /// 获取交易对应的信息
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="sesionKey"></param>
        /// <returns></returns>
        public static Trade GetBuyerTrade(string tid, string sesionKey)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                TradeGetRequest req = new TradeGetRequest();
                req.Fields = @"orders.seller_rate,orders.buyer_rate,orders.oid";
                req.Tid = Convert.ToInt64(tid == "" ? "0" : tid);
                TradeGetResponse response = client.Execute(req, sesionKey);
                return response.Trade;
            }
            catch (Exception ex)
            {
                CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
                return null;
            }
        }
    }
}
