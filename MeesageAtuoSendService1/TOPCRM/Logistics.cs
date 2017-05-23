using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Response;
using Top.Api;
using Top.Api.Request;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Domain;

namespace MeesageAtuoSendService.TOPCRM
{
   public class Logistics
    {
        /// <summary>
        /// 查看当前卖家的物流状态
        /// </summary>
        /// <param name="tid"></param>
        /// <param name="seller_nick"></param>
        /// <returns></returns>
        public LogisticsTraceSearchResponse GetLogisticsInfo(long tid, string seller_nick)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                LogisticsTraceSearchRequest req = new LogisticsTraceSearchRequest();
                req.Tid = tid;
                req.SellerNick = seller_nick;
                LogisticsTraceSearchResponse response = client.Execute(req);
                return response;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            return null;
        }


       /// <summary>
       /// 
       /// </summary>
       /// <param name="tid"></param>
       /// <param name="sessionKey"></param>
       /// <returns></returns>
        public  List<Shipping> GetLogisticsBuyerInfo(long tid, string sessionKey)
        {
            try
            {
                ITopClient client = TBManager.GetClient();
                LogisticsOrdersDetailGetRequest req = new LogisticsOrdersDetailGetRequest();
                req.Fields = "receiver_location,receiver_phone,company_name,status";
                req.Tid = tid;
                LogisticsOrdersDetailGetResponse response = client.Execute(req, sessionKey);
                return response.Shippings;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
            }
            return null;
        }

    }
}
