using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;

namespace CTCRM.Components.TopCRM
{
   public class TBCrmGrademkt
    {
       public Boolean SetGradeMKT(string strSessionKey, string buyerNick)
       {
           try
           {
               //ITopClient client = TBManager.GetClient();
               //CrmGrademktMemberDetailCreateRequest req = new CrmGrademktMemberDetailCreateRequest();
               //req.Fields = @"tid,buyer_nick,seller_nick,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_mobile";
               //req.BuyerNick = buyerNick;
               //CrmGrademktMemberDetailCreateResponse response = client.Execute(req, strSessionKey);
               //return response.Trades;
               return true;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return false;
           }
       }
    }
}
