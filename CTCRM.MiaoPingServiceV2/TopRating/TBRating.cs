using System;
using System.Collections.Generic;
using System.Text;
using CTCRM.Entity;
using Top.Api.Domain;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.MiaoPingServiceV2.TopRating
{
   public class TBRating
    {
        /// <summary>
        /// 调用API进行批量评价
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public TradeRate BuyerTradeRate(RateConfig rateObj, ref string content, string sesionKey)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                TraderateListAddRequest req = new TraderateListAddRequest();
                req.Tid = rateObj.Tid;
                req.Result = rateObj.Result;
                req.Role = "seller";
                string[] strs = { rateObj.Content1, rateObj.Content2, rateObj.Content3 };//随机选择评价内容
                Random rand = new Random(System.Guid.NewGuid().GetHashCode());
                req.Content = strs[rand.Next(0, strs.Length)];
                content = req.Content;
                TraderateListAddResponse response = client.Execute(req, sesionKey);
                return response.TradeRate;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 新增单个评价
        /// </summary>
        /// <param name="rateObj"></param>
        /// <param name="content"></param>
        /// <param name="sesionKey"></param>
        /// <returns></returns>
        public TradeRate BuyerTradeRateOneByOne(RateConfig rateObj, ref string content, string sesionKey)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                TraderateAddRequest req = new TraderateAddRequest();
                req.Tid = rateObj.Tid;
                req.Oid = rateObj.Oid;
                req.Result = rateObj.Result;
                req.Role = "seller";
                string[] strs = { rateObj.Content1, rateObj.Content2, rateObj.Content3 };//随机选择评价内容
                Random rand = new Random(System.Guid.NewGuid().GetHashCode());
                req.Content = strs[rand.Next(0, strs.Length)];
                content = req.Content;
                TraderateAddResponse response = client.Execute(req, sesionKey);
                return response.TradeRate;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 搜索评价信息:只能获取距今180天内的评价记录(只支持查询卖家给出或得到的评价)
        /// </summary>
        /// <param name="rateObj"></param>
        /// <returns></returns>
        public List<TradeRate> GetTradeRate(string sessionKey)
        {

            try
            {
                ITopClient client = TBManager.GetClient();
                TraderatesGetRequest req = new TraderatesGetRequest();
                req.Fields = "tid,nick,result,created,item_title,content";
                req.RateType = "get";
                //req.Role = "seller";
                req.Role = "buyer";
                //req.Result = "good";
                TraderatesGetResponse response = client.Execute(req, sessionKey);
                long  total = response.TotalResults;
                return response.TradeRates;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }
    }
}
