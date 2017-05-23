using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Top.Api;

namespace TOPCRM
{
   public class TBManager
    {
        public readonly static string DO__URL = "http://gw.api.taobao.com/router/rest";
        public static string appKey = System.Configuration.ConfigurationManager.AppSettings["appKey"];
        public static string appSecret = System.Configuration.ConfigurationManager.AppSettings["appSecret"];

        public static ClusterTopClient GetClient()
        {
            return new ClusterTopClient(DO__URL, (string.IsNullOrEmpty(appKey) ? "21088197" : appKey), (string.IsNullOrEmpty(appSecret) ? "1c178c273e89d4df8c3f535a5caaabf8" : appSecret));
        }
    }
}
