using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magic.Common.CSVHelper
{
    /// <summary>
    /// 用户进度报告缓冲区
    /// </summary>
    public class UserProcessRepoter
    {
        private UserProcessRepoter()
        {

        }
        private static object obj = new object();
        private static UserProcessRepoter _instance;

        public static UserProcessRepoter Instance
        {
            get { lock (obj) { if (_instance == null)  _instance = new UserProcessRepoter(); return _instance; } }
        }
        public ProcessDetail this[string UserNick]
        {
            get
            {
                return ReadCache(UserNick);

            }
            set { WriteCache(UserNick, value); }
        }
        System.Web.Caching.Cache currentCahce;
        public void WriteCache(string userNick, ProcessDetail value)
        {

            if (currentCahce == null)
                currentCahce = System.Web.HttpRuntime.Cache;
            //currentCahce.Add(userNick, value, null, System.DateTime.Now, TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            currentCahce[userNick] = value;
        }
        public ProcessDetail ReadCache(string UserNick)
        {
            if (currentCahce != null)
                return currentCahce[UserNick] as ProcessDetail;
            else
                return null;
        }
        public void RemoveCache(string userNick)
        {
            if (currentCahce != null) ;
            currentCahce.Remove(userNick);
        }
    }
}
