using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Response;
using CTCRM.Components.TopCRM;

namespace CTCRM.Components
{
   public class UserSubscribe
    {
       public static ArticleUserSubscribe GetDeadLineDate(string articleCode, string sellerNick)
       {
           try
           {
               VasSubscribeGetResponse response = UserSubscribes.GetSellerSubscrib(sellerNick, articleCode);
               if (response != null && response.ArticleUserSubscribes != null && response.ArticleUserSubscribes.Count > 0)
               {
                   return response.ArticleUserSubscribes[0];
               }
           }
           catch (Exception ex)
           {
               //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Components);
               return null;
           }
           return null;
       }
    }
}
