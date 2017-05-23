using CTCRM.Components;
using CTCRM.Components.TopCRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.handler
{
    /// <summary>
    /// rateHandler 的摘要说明
    /// </summary>
    public class rateHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var command = context.Request.Form["command"];
            if (!string.IsNullOrEmpty(command))
            {
                switch (command)
                {
                    #region OpenDefense
                    case "OpenDefense":
                        {
                            DataRow orderDate = SellersBLL.GetSelerOrderDate(Users.Nick);
                            if (orderDate != null)
                            {
                                if (orderDate["OrderVersion"].Equals("体验版"))
                                {
                                    context.Response.Write("nopower");//试用版不能用
                                    context.Response.End();
                                    return;
                                }
                            }

                            if (!ShieldRulesBLL.CheckCloseOrderConfigIsExit(Users.Nick))
                            {
                                context.Response.Write("noConfig");//保存拦截条件设置，才能开启差评自动防御！
                                context.Response.End();
                            }
                            else
                            {
                                DataTable tb = ShieldRulesBLL.GeCloseOrderConfigByNick(Users.Nick);
                                if (tb != null && tb.Rows.Count > 0)
                                {
                                    if (tb.Rows[0]["isAutoCloseOrder"].ToString().Equals("1"))
                                    {
                                        //btnOpen.ImageUrl = "~/images/closed.png";
                                        ShieldRulesBLL.UpdateAutoCloseOrderStatus(Users.Nick, 0);
                                        //关闭订单自动拦截时先判断用户是否设置了自动秒评，否则关闭后就会出现问题
                                        if (!ShieldRulesBLL.CheckIsMiaoPingAuto(Users.Nick))
                                        {
                                            ITopClient client = TBManager.GetClient();
                                            TmcUserCancelRequest req = new TmcUserCancelRequest();
                                            req.Nick = Users.Nick;
                                            TmcUserCancelResponse response = client.Execute(req);
                                            if (response.IsSuccess){
                                            }                                                                                   
                                        }
                                        context.Response.Write("cloedDefens");//差评自动防御已关闭！
                                        context.Response.End();
                                    }
                                    else
                                    {
                                        //btnOpen.ImageUrl = "~/images/open.png";
                                        ShieldRulesBLL.UpdateAutoCloseOrderStatus(Users.Nick, 1);
                                        //检查是否开启了主动通知
                                        ITopClient client = TBManager.GetClient();
                                        TmcUserPermitRequest req = new TmcUserPermitRequest();
                                        TmcUserPermitResponse response = client.Execute(req, Users.SessionKey);                                       
                                        if (response.IsSuccess){                                          
                                        }
                                        context.Response.Write("openDefens");//差评自动防御已开启！
                                        context.Response.End();
                                    }
                                }
                            }
                           
                        }
                        break;
                    #endregion

                    #region ClearDate
                    case "ClearDate":
                        {
                            if (ShieldRulesBLL.UpdateCloseDate(Users.Nick))
                            {             
                                context.Response.Write("1");//定时间段关闭已清除！
                                context.Response.End();
                            }
                        }
                        break;
                    #endregion

                    #region closeOrder
                    case "closeOrder":
                        {
                            string orderNo = context.Request.Form["orderNo"];
                            string reason = context.Request.Form["reason"];
                            TBTrade objTrade = new TBTrade();
                            Trade trade = objTrade.CloseOrderByTradeID(Convert.ToInt64(orderNo), reason);
                            if (trade != null)
                            {
                                context.Response.Write("1");//关闭成功
                                context.Response.End();                               
                            }
                            if (ShieldRulesBLL.UpdateCloseDate(Users.Nick))
                            {
                                context.Response.Write("0");//关闭失败
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