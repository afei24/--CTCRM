using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace MeesageAtuoSendService.TOPCRM
{
     
   public class TBTrade
    {
       public static Trade GetTradeContact(long tid, string sessionKey)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               TradeFullinfoGetRequest req = new TradeFullinfoGetRequest();
               req.Fields = "consign_time,receiver_mobile,receiver_city,receiver_name";
               req.Tid = tid;
               TradeFullinfoGetResponse response = client.Execute(req, sessionKey);
               return  response.Trade;
           }
           catch (Exception ex)
           {
               CHENGTUAN.Components.ExceptionReporter.WriteLog(ex, CHENGTUAN.Entity.ExceptionPostion.TBApply_Components);
               return null;
           }
       }
    }
}
