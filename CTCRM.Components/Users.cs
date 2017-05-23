using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using CTCRM.Common;
using CTCRM.Components.TopCRM;
using Top.Api.Response;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Domain;

namespace CTCRM.Components
{
    public class Users
    {
        private static string cookieMode = ConfigurationManager.AppSettings["cookieMode"];

        /// <summary>
        /// 用户的淘宝帐户
        /// </summary>
        public static string Nick
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["nick"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197", false);
                    return null;
                }
                return CTCRM.Common.DES.Decrypt(cookie.Values["nick"]);
            }
        }

        /// <summary>
        /// 本系统自动为用户分配的数字ID编号
        /// </summary>
        public static string Uid
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["uid"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    return null;

                }
                return CTCRM.Common.DES.Decrypt(cookie.Values["uid"]);
            }
        }

        /// <summary>
        /// 用户的淘宝SESSION值
        /// </summary>
        public static string SessionKey
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["sess"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    return null;
                }
                return cookie.Values["sess"];
            }
        }

        /// <summary>
        /// 卖家的ID
        /// </summary>
        public static string SellerId
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["SellerId"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    return null;
                }
                return cookie.Values["SellerId"];
            }
        }

        /// <summary>
        /// 到期时间
        /// </summary>
        public static string Deadline
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["Deadline"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    return null;

                }
                return cookie.Values["Deadline"];
            }
        }

        /// <summary>
        /// 软件版本
        /// </summary>
        public static string OrderVersion
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["OrderVersion"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    return null;
                }
                return CTCRM.Common.DES.Decrypt(cookie.Values["OrderVersion"]);
            }
        }
        public static string SellerOrderDate
        {
            get
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Top"];
                if (cookie == null || cookie.Values["CreatedDate"] == null)
                {
                    //HttpContext.Current.Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197");
                    //return null;
                    //return "2015-06-31";
                }
                return cookie.Values["CreatedDate"];
            }
        }
    }
}
