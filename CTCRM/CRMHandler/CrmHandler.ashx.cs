using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Entity;
using System.Collections.Generic;

namespace CTCRM.CRMHandler
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class CrmHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            var method = context.Request.Form["method"];
            switch (method)
            {
                case "sendTestMsg":
                    if (context.Request.Form["testNo"] != null)
                    {
                        var cellphoneNo = context.Request.Form["testNo"].ToString();
                        if (string.IsNullOrEmpty(cellphoneNo))
                        {
                            context.Response.Write("{\"phoneNoError\":\"0\"}");
                            context.Response.End();
                        }
                        else {
                            if (!Utility.IsCellPhone(cellphoneNo))
                            {
                                context.Response.Write("{\"phoneNoError2\":\"0\"}");
                                context.Response.End();
                            }
                        }
                    }
                    if (context.Request.Form["msgContentVa"] != null)
                    {
                        var msgContent = context.Request.Form["msgContentVa"].ToString();
                        if (string.IsNullOrEmpty(msgContent))
                        {
                            context.Response.Write("{\"msgContent\":\"0\"}");
                            context.Response.End();
                        }
                    }
                   
                    break;
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
