using System;
using System.Collections.Generic;
using System.Text;
using Top.Api.Domain;
using Top.Api.Response;
using Top.Api;
using Top.Api.Request;

namespace CTCRM.RatingServiceHouTai.TOPRating
{
  public  class TBTrade
    {
        /// <summary>
        /// 获取指定时间段内的交易信息和明细
        /// TradesSoldGetRequest 获取单笔交易的详细信息 
        /// </summary>
        /// <param name="sellerNick">根据买家昵称获取交易信息</param>
        /// <returns></returns>
        public static List<Trade> GetBuyerTrade(string sellerNick, DateTime startDate, DateTime endDate, ref bool hasNextPage, string sessionKey, long pageNo)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                TradesSoldGetRequest req = new TradesSoldGetRequest();
                req.Fields = @"tid,seller_rate,orders.oid,orders.end_time,orders.buyer_rate,buyer_nick,end_time";
                if (!String.IsNullOrEmpty(startDate.ToShortDateString()))
                {
                    req.StartCreated = startDate;
                }
                if (!String.IsNullOrEmpty(endDate.ToShortDateString()))
                {
                    req.EndCreated = endDate;
                }
                req.Status = "TRADE_FINISHED";//交易成功后才可以评价
                req.PageNo = pageNo;
                req.PageSize = 100L;
                req.UseHasNext = true;
                TradesSoldGetResponse response = client.Execute(req, sessionKey);
                hasNextPage = response.HasNext;
                return response.Trades;
            }
            catch (Exception ex)
            {
                CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TopApi);
                return null;
            }
        }

    }
}
