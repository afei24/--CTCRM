using CTCRM.Components;
using CTCRM.Components.TopCRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.SessionState;

namespace CTCRM.CRMHandler
{
    /// <summary>
    /// BatchHandler 的摘要说明
    /// </summary>
    public class BatchHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var command = context.Request.Form["command"];

            if (!string.IsNullOrEmpty(command))
            {
                switch (command)
                {
                    #region batchSend
                    case "batchSend":
                        {
                            DataTable tb = BatchShippingBLL.GetBatchOrderDataForSending(Users.Nick);
                            if (tb != null && tb.Rows.Count > 0)
                            {
                                for (int i = 0; i < tb.Rows.Count; i++)
                                {
                                    try
                                    {
                                        string orderId = tb.Rows[i]["OrderNo"].ToString();
                                        string subOrderId = tb.Rows[i]["subOrderNo"].ToString();
                                        string yundanNo = tb.Rows[i]["yunDanNo"].ToString();
                                        string company = tb.Rows[i]["commpany"].ToString();
                                        string code = BatchShippingBLL.GetLogistCodeByName(company);
                                        string id = tb.Rows[i]["id"].ToString();
                                        string type = context.Request.Form["type"]; 
                                        if (TBlogisticsSend.orderBatchSending(orderId, yundanNo, code))
                                        {
                                            BatchShippingBLL.DeleteOrderByID(id);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                }
                                context.Response.Write("ok");
                                context.Response.End();
                            }
                            else
                            {
                                context.Response.Write("0");
                                context.Response.End();
                            }
                          
                        }
                        break;
                    #endregion  

                    #region clearSend
                    case "clearSend":
                        {
                            BatchShippingBLL.DeleteAllOrder(Users.Nick);
                            context.Response.Write("ok");
                            context.Response.End();
                        }
                        break;
                    #endregion  

                    #region checkBatchSend
                    case "checkBatchSend":
                        {
                            DataTable tb = HttpContext.Current.Session["DataSource"] as DataTable;
                            BatchShippingBLL.CheckOrder(tb, Users.Nick);
                            context.Response.Write("ok");
                            context.Response.End();
                        }
                        break;
                    #endregion  

                    #region clearBatchSend
                    case "clearBatchSend":
                        {
                            if (BatchShippingBLL.ClearUnusedOrder(Users.Nick))
                            {
                                context.Response.Write("ok");
                                context.Response.End();
                            }
                            else
                            {
                                context.Response.Write("0");
                                context.Response.End();
                            }
                        }
                        break;
                    #endregion  

                }
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