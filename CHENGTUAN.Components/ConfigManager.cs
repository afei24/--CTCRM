using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CHENGTUAN.Components;

namespace CHENGTUAN.Components
{
    /// <summary>
    /// XML配置管理器
    /// </summary>
    public abstract class ConfigManager
    {
        public Dictionary<string, string> List
        {
            get
            {
                var obj = System.Web.HttpRuntime.Cache[cacheName] as Dictionary<string, string>;
                if (obj == null)
                {
                    obj = new Dictionary<string, string>();
                    System.Web.HttpRuntime.Cache.Add(cacheName, obj, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

                }
                return obj;
            }
            set
            {
                var obj = System.Web.HttpRuntime.Cache[cacheName] as Dictionary<string, string>;
                if (obj == null)
                {
                    obj = new Dictionary<string, string>();
                    System.Web.HttpRuntime.Cache.Add(cacheName, obj, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);

                }
                obj = value;
            }
        }
        public ConfigManager()
        {
            this.fileUrl = Units.MapPath("~/configs/") + fileName;
        }

        protected abstract string fileName
        {
            get;
        }

        protected abstract string cacheName
        {
            get;
        }

        private string fileUrl = null;
        public void Load()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileUrl);
            var list = doc.GetElementsByTagName("add");
            var obj = System.Web.HttpRuntime.Cache[cacheName] as Dictionary<string, string>;
            if (obj == null)
            {
                obj = new Dictionary<string, string>();
                System.Web.HttpRuntime.Cache.Add(cacheName, obj, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
                foreach (XmlNode item in (XmlNodeList)list)
                {
                    obj.Add(item.Attributes[0].Value, item.Attributes[1].Value);
                }
            }
        }
        public void Save()
        {
            if (List == null || List.Count == 0)
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(fileUrl);
            var list = doc.GetElementsByTagName("add");
            var obj = System.Web.HttpRuntime.Cache[cacheName] as Dictionary<string, string>;

            foreach (XmlNode item in list)
            {
                foreach (KeyValuePair<string, string> pair in List)
                {
                    if (pair.Key == item.Attributes[0].Value && pair.Value != item.Attributes[1].Value)
                    {
                        item.Attributes["value"].Value = pair.Value;
                    }
                }
            }
            doc.Save(fileUrl);
        }

    }
}
