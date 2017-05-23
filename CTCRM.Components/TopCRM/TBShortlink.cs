using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
   public class TBShortlink
    {
       /// <summary>
        ///  可生成店铺宝贝、店铺首页、活动链接等3种可呼起手机淘宝APP的短链。 
       /// </summary>
       /// <returns></returns>
       public static string SetShortLink(string shortLinkName, string linkType, string shortLinkData, ref string msg)
       {
           try
           {
               ITopClient client = TBManager.GetClient();
               CrmServiceChannelShortlinkCreateRequest req = new CrmServiceChannelShortlinkCreateRequest();
               req.ShortLinkName = shortLinkName;
               req.LinkType = linkType;
               if (!linkType.Equals("LT_SHOP"))
               {
                   req.ShortLinkData = shortLinkData;
               }
               CrmServiceChannelShortlinkCreateResponse response = client.Execute(req, Users.SessionKey);
               msg = response.SubErrCode;
               return response.ShortLink;
           }
           catch (Exception ex)
           {
               ExceptionReporter.WriteLog(ex, ExceptionPostion.TopApi);
               return "0";
           }
       }

    }
}
