using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;

namespace CTCRM.Components.TopCRM
{
   public class RatingTop
    {
        public static VasSubscribeGetResponse GetSellerSubscrib(string sellerNick, string articleCode)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                VasSubscribeGetRequest req = new VasSubscribeGetRequest();
                req.Nick = sellerNick;
                req.ArticleCode = articleCode;
                VasSubscribeGetResponse response = client.Execute(req);
                return response;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 调用API进行批量评价
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pagesize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public TradeRate BuyerTradeRate(RateConfig rateObj, ref string content)
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
                TraderateListAddResponse response = client.Execute(req, Users.SessionKey);
                return response.TradeRate;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        public TradeRate BuyerTradeRateOneByOne(RateConfig rateObj, ref string content)
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
                TraderateAddResponse response = client.Execute(req, Users.SessionKey);
                return response.TradeRate;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
                return null;
            }
        }

        /// <summary>
        /// 根据条件关闭订单
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="closeReason"></param>
        /// <returns></returns>
        public Trade CloseTradeOrders(long tid, string closeReason)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                TradeCloseRequest req = new TradeCloseRequest();
                req.Tid = tid;
                req.CloseReason = closeReason;
                TradeCloseResponse response = client.Execute(req, Users.SessionKey);
                return response.Trade;
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
        public List<TradeRate> GetTradeRate(Int64 currentPage, Int64 pagesize, string getStartDate, string getEndDate, ref Int64 total)
        {

            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1L;
                }
                if (pagesize == 0)
                {
                    pagesize = 100;
                }
                ITopClient client = TBManager.GetClient();
                TraderatesGetRequest req = new TraderatesGetRequest();
                req.Fields = "tid,nick,result,created,item_title,content";
                req.RateType = "get";
                //req.Role = "seller";
                req.Role = "buyer";
                //req.Result = "good";
                req.PageNo = currentPage;
                req.PageSize = pagesize;
                if (!string.IsNullOrEmpty(getStartDate))
                {
                    req.StartDate = Convert.ToDateTime(getStartDate);
                }
                if (!string.IsNullOrEmpty(getEndDate))
                {
                    req.EndDate = Convert.ToDateTime(getEndDate);
                }
                TraderatesGetResponse response = client.Execute(req, Users.SessionKey);
                total = response.TotalResults;
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
