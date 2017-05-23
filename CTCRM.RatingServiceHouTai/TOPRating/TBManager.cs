using System;
using System.Collections.Generic;
using System.Text;
using Top.Api;

namespace CTCRM.RatingServiceHouTai.TOPRating
{
   public class TBManager
    {
        public readonly static string DO__URL = "http://gw.api.taobao.com/router/rest";
        public static string appKey = System.Configuration.ConfigurationManager.AppSettings["appKey"];
        public static string appSecret = System.Configuration.ConfigurationManager.AppSettings["appSecret"];

        public static DefaultTopClient GetClient()
        {
            return new DefaultTopClient(DO__URL, (string.IsNullOrEmpty(appKey) ? "21487808" : appKey), (string.IsNullOrEmpty(appSecret) ? "8fc49df2093162bb7f926ee04f9f1bba" : appSecret));
        }
    }
}
