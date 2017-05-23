using System.Web;
using System.Collections.Generic;
using System.Linq;
using CTCRM.Entity;
using CTCRM.Components;
using System;
using CTCRM.Common;

namespace CTCRM.handler
{
    /// <summary>
    /// common 的摘要说明
    /// </summary>
    public class common : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string nick = context.Request.Form["nick"];
            string phone = context.Request.Form["phone"];
            if (!string.IsNullOrEmpty(phone) && !Utility.IsCellPhone(phone))
            {
                context.Response.Write("0");
                context.Response.End();
                return;
            }
            if (!string.IsNullOrEmpty(nick))
            {
                Sellers objSell = new Sellers();
                objSell.Nick = Users.Nick;
                objSell.SignShopName = nick;
                objSell.Cellphone = phone;
                SellersBLL.SetShopName(objSell);
                context.Response.Write("1");
                context.Response.End();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}