using CTCRM.Components;
using CTCRM.Components.TopCRM;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CTCRM.handler
{
    /// <summary>
    /// remainder 的摘要说明
    /// </summary>
    public class remainder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var command = context.Request.Form["command"];
            var action = context.Request.Form["action"];
            if (!string.IsNullOrEmpty(command) && !string.IsNullOrEmpty(action))
            {
                switch (command)
                {
                    case "unPay":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string startTime = context.Request.Form["startTime"];
                                    string endTime = context.Request.Form["endTime"];
                                    string swich = context.Request.Form["swich"];
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];
                                    string zhouqi = context.Request.Form["zhouqi"];
                                    UnpayReminderConfig obj = new UnpayReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.FromTime = startTime;
                                    obj.ToTime = endTime;
                                    obj.Swichs = swich;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                    obj.Zhouqi = zhouqi;
                                    if (RemainderBLL.CheckUnPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateUnPayBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddUnPayBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 高级信息
                            if (action.Equals("top"))
                            {
                                try
                                {
                                    string flag = context.Request.Form["flag"];
                                    string isBlack = context.Request.Form["isBlack"];
                                    UnpayReminderConfig objU = new UnpayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.Flag = flag;
                                    objU.IsAddBlackList = isBlack;
                                    if (RemainderBLL.CheckUnPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateUnPayTop(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddUnPayTop(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];                                   
                                    UnpayReminderConfig objU = new UnpayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckUnPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateUnPayMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddUnPayMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存催付信息

                            if (action.Equals("saveUnpayConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    UnpayReminderConfig objU = new UnpayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckUnPayIsExit(Users.Nick))
                                    {
                                        objU.FromTime = "09:00";
                                        objU.ToTime = "22:00";
                                        objU.Swichs = "1";//超出时间不催付
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.Zhouqi = "2小时";
                                        objU.Flag = "0";
                                        objU.IsAddBlackList = "0";
                                        objU.MsgContent = "亲！您**下单时间**拍的宝贝小店已为您备好，付款后我们立即发货，谢谢光临!";
                                        RemainderBLL.AddUnPay(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.UnpayOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForUnpay(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string unpayOpen = tbMaster.Rows[0]["unpayOpen"].ToString();
                                        if (unpayOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.UnpayOpen = "0";
                                            RemainderBLL.UpdateUnPayMaster(obj);
                                            UnpayReminderConfig obj2 = new UnpayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdateUnPayBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.UnpayOpen = "1";
                                            RemainderBLL.UpdateUnPayMaster(obj);
                                            UnpayReminderConfig obj2 = new UnpayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdateUnPayBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }
                                    
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                    case "shipping":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string startTime = context.Request.Form["startTime"];
                                    string endTime = context.Request.Form["endTime"];
                                    string swich = context.Request.Form["swich"];
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];
                                    ShippingReminderConfig obj = new ShippingReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.FromTime = startTime;
                                    obj.ToTime = endTime;
                                    obj.Swichs = swich;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                   
                                    if (RemainderBLL.CheckShippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateShippingBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddShippingBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 高级信息
                            if (action.Equals("top"))
                            {
                                try
                                {
                                    string flag = context.Request.Form["flag"];
                                    string isBlack = context.Request.Form["isBlack"];
                                    ShippingReminderConfig objU = new ShippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.Flag = flag;
                                    objU.IsAddBlackList = isBlack;
                                    if (RemainderBLL.CheckShippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateShippingTop(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddShippingTop(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    ShippingReminderConfig objU = new ShippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckShippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateShippingMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddShippingMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存发货信息

                            if (action.Equals("saveShippingConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    ShippingReminderConfig objU = new ShippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckShippingIsExit(Users.Nick))
                                    {
                                        objU.FromTime = "09:00";
                                        objU.ToTime = "22:00";
                                        objU.Swichs = "1";//超出时间不催付
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.Flag = "0";
                                        objU.IsAddBlackList = "0";
                                        objU.MsgContent = "亲！您的宝贝于**发货时间**发货,快递公司为：**快递公司**：单号为：**快递单号**，多谢惠顾。";
                                        RemainderBLL.AddShipping(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.ShippingOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForShipping(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string shippingOpen = tbMaster.Rows[0]["shippingOpen"].ToString();
                                        if (shippingOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ShippingOpen = "0";
                                            RemainderBLL.UpdateShippingMaster(obj);
                                            ShippingReminderConfig obj2 = new ShippingReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdateShippingBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ShippingOpen = "1";
                                            RemainderBLL.UpdateShippingMaster(obj);
                                            ShippingReminderConfig obj2 = new ShippingReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdateShippingBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                    case "arrived":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];
                                    ArrivedReminderConfig obj = new ArrivedReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                    if (RemainderBLL.CheckArrivedIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateArrivedBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddArrivedBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 高级信息
                            if (action.Equals("top"))
                            {
                                try
                                {
                                    string flag = context.Request.Form["flag"];
                                    string isBlack = context.Request.Form["isBlack"];
                                    ArrivedReminderConfig objU = new ArrivedReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.Flag = flag;
                                    objU.IsAddBlackList = isBlack;
                                    if (RemainderBLL.CheckArrivedIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateArrivedTop(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddArrivedTop(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    ArrivedReminderConfig objU = new ArrivedReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckArrivedIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateArrivedMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddArrivedMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存到达信息

                            if (action.Equals("saveArrivedConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    ArrivedReminderConfig objU = new ArrivedReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckArrivedIsExit(Users.Nick))
                                    {
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.Flag = "0";
                                        objU.IsAddBlackList = "0";
                                        objU.MsgContent = "亲，您的宝贝已到**当前位置**，请注意查收。";
                                        RemainderBLL.AddArrived(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.ArrivedOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForArrived(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string arrivedOpen = tbMaster.Rows[0]["arrivedOpen"].ToString();
                                        if (arrivedOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ArrivedOpen = "0";
                                            RemainderBLL.UpdateArrivedMaster(obj);
                                            ArrivedReminderConfig obj2 = new ArrivedReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdateArrivedBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ArrivedOpen = "1";
                                            RemainderBLL.UpdateArrivedMaster(obj);
                                            ArrivedReminderConfig obj2 = new ArrivedReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdateArrivedBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                    case "sign":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];
                                    SignReminderConfig obj = new SignReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                    if (RemainderBLL.CheckSignIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateSignBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddSignBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 高级信息
                            if (action.Equals("top"))
                            {
                                try
                                {
                                    string flag = context.Request.Form["flag"];
                                    string isBlack = context.Request.Form["isBlack"];
                                    SignReminderConfig objU = new SignReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.Flag = flag;
                                    objU.IsAddBlackList = isBlack;
                                    if (RemainderBLL.CheckSignIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateSignTop(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddSignTop(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    SignReminderConfig objU = new SignReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckSignIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateSignMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddSignMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存签收信息

                            if (action.Equals("saveSignConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    SignReminderConfig objU = new SignReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckSignIsExit(Users.Nick))
                                    {
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.Flag = "0";
                                        objU.IsAddBlackList = "0";
                                        objU.MsgContent = "亲爱的**收货人**,物流显示您的订单已签收，如对产品服务满意,请全打5分好评鼓励我们;如果不满意，请联系我们。";
                                        RemainderBLL.AddSign(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.SignOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForSign(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string signOpen = tbMaster.Rows[0]["signOpen"].ToString();
                                        if (signOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.SignOpen = "0";
                                            RemainderBLL.UpdateSignMaster(obj);
                                            SignReminderConfig obj2 = new SignReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdateSignBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.SignOpen = "1";
                                            RemainderBLL.UpdateSignMaster(obj);
                                            SignReminderConfig obj2 = new SignReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdateSignBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion

                        }
                        break;
                    case "delaySipping":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string sendType = context.Request.Form["sendType"];
                                    string days = context.Request.Form["days"];
                                    if (string.IsNullOrEmpty(days)) {
                                        days = "0";
                                    }
                                    DelaySippingReminderConfig obj = new DelaySippingReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.SendType = sendType;
                                    obj.Days = days;
                                    if (RemainderBLL.CheckDelaySippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateDelaySippingBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddDelaySippingBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 高级信息
                            if (action.Equals("top"))
                            {
                                try
                                {
                                    string flag = context.Request.Form["flag"];
                                    string isBlack = context.Request.Form["isBlack"];
                                    DelaySippingReminderConfig objU = new DelaySippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.Flag = flag;
                                    objU.IsAddBlackList = isBlack;
                                    if (RemainderBLL.CheckDelaySippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateDelaySippingTop(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddDelaySippingTop(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    DelaySippingReminderConfig objU = new DelaySippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckDelaySippingIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateDelaySippingMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddDelaySippingMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存延迟发货信息

                            if (action.Equals("savedelaySippingConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    DelaySippingReminderConfig objU = new DelaySippingReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckDelaySippingIsExit(Users.Nick))
                                    {
                                        objU.SendType = "0";
                                        objU.Days = "0";
                                        objU.Flag = "0";
                                        objU.IsAddBlackList = "0";
                                        objU.MsgContent = "主人，偶是你的宝贝啦，店家会在3个工作日内将我发出噢,偶一定不贪玩,一般3到5天左右就飞奔到你的身边了哦!";
                                        RemainderBLL.AddDelaySipping(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.DelayShipingOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForDelayShipping(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string delayShipingOpen = tbMaster.Rows[0]["delayShipingOpen"].ToString();
                                        if (delayShipingOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.DelayShipingOpen = "0";
                                            RemainderBLL.UpdateDelaySippingMaster(obj);
                                            DelaySippingReminderConfig obj2 = new DelaySippingReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdateDelaySippingBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.DelayShipingOpen = "1";
                                            RemainderBLL.UpdateDelaySippingMaster(obj);
                                            DelaySippingReminderConfig obj2 = new DelaySippingReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdateDelaySippingBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                    case "pay":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string startTime = context.Request.Form["startTime"];
                                    string endTime = context.Request.Form["endTime"];
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];

                                    PayReminderConfig obj = new PayReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.FromTime = startTime;
                                    obj.ToTime = endTime;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                    if (RemainderBLL.CheckPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdatePayBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddPayBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    PayReminderConfig objU = new PayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdatePayMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddPayMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存付款提醒信息

                            if (action.Equals("savePayConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    PayReminderConfig objU = new PayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckPayIsExit(Users.Nick))
                                    {
                                        objU.FromTime = "09:00";
                                        objU.ToTime = "22:00";
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.MsgContent = "亲爱的**收货人**,感谢购买我们的商品！我们将随时跟踪播报状态，方便您及时了解.亲如果有问题可以联系客服哟";
                                        RemainderBLL.AddPay(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.PayOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForPay(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string payOpen = tbMaster.Rows[0]["payOpen"].ToString();
                                        if (payOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.PayOpen = "0";
                                            RemainderBLL.UpdatePayMaster(obj);
                                            PayReminderConfig obj2 = new PayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdatePayBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.PayOpen = "1";
                                            RemainderBLL.UpdatePayMaster(obj);
                                            PayReminderConfig obj2 = new PayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdatePayBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                    case "confirm":
                        {
                            #region 基本信息
                            if (action.Equals("basic"))
                            {
                                try
                                {
                                    string startTime = context.Request.Form["startTime"];
                                    string endTime = context.Request.Form["endTime"];
                                    string amountFrm = context.Request.Form["amountFrm"];
                                    string amountTo = context.Request.Form["amountTo"];
                                    string zhouqi = context.Request.Form["zhouqi"];
                                    ConfirmPayReminderConfig obj = new ConfirmPayReminderConfig();
                                    obj.SellerNick = Users.Nick;
                                    obj.FromTime = startTime;
                                    obj.ToTime = endTime;
                                    obj.AmountFrom = amountFrm;
                                    obj.AmountTo = amountTo;
                                    obj.ZhouQi = zhouqi;
                                    if (RemainderBLL.CheckConfirmPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateConfirmPayBasic(obj);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddPayConfirmBasic(obj);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 短信内容信息
                            if (action.Equals("msg"))
                            {
                                try
                                {
                                    string content = context.Request.Form["content"];
                                    ConfirmPayReminderConfig objU = new ConfirmPayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    objU.MsgContent = content;
                                    if (RemainderBLL.CheckConfirmPayIsExit(Users.Nick))
                                    {
                                        RemainderBLL.UpdateConfirmPayMsg(objU);
                                    }
                                    else
                                    {
                                        RemainderBLL.AddPayConfirmMsg(objU);
                                    }
                                    context.Response.Write("1");
                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();
                            }
                            #endregion

                            #region 保存回款提醒信息

                            if (action.Equals("savePayConfirmConfig"))
                            {
                                try
                                {
                                    //判断短信余额
                                    if (!CheckIsOpenMsgAcount())
                                    {
                                        context.Response.Write("4");
                                        return;
                                    }
                                    //开通消息通知
                                    TBNotify.StartNotify();

                                    ConfirmPayReminderConfig objU = new ConfirmPayReminderConfig();
                                    objU.SellerNick = Users.Nick;
                                    if (!RemainderBLL.CheckConfirmPayIsExit(Users.Nick))
                                    {
                                        objU.FromTime = "09:00";
                                        objU.ToTime = "22:00";
                                        objU.AmountFrom = "0";
                                        objU.AmountTo = "0";
                                        objU.ZhouQi = "0";
                                        objU.MsgContent = "亲爱的**收货人**，我们的交易已经成功，希望您能确认+好评，我们才有充裕的资金流转,来提高店铺质量和服务，祝您生活愉快！";
                                        RemainderBLL.AddPayConfirm(objU);
                                    }
                                    if (!RemainderBLL.CheckConfigMasterIsExit(Users.Nick))
                                    {
                                        SellerReminderMaster obj = new SellerReminderMaster();
                                        obj.SellerNick = Users.Nick;
                                        obj.ConfirmPayOpen = "0";
                                        RemainderBLL.AddSellerReminderMasterForPayConfrim(obj);
                                    }
                                    DataTable tbMaster = RemainderBLL.GetMaster(Users.Nick);
                                    if (tbMaster != null && tbMaster.Rows.Count > 0)
                                    {
                                        string confirmPayOpen = tbMaster.Rows[0]["confirmPayOpen"].ToString();
                                        if (confirmPayOpen.Equals("1"))
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ConfirmPayOpen = "0";
                                            RemainderBLL.UpdatePayConfirmMaster(obj);
                                            ConfirmPayReminderConfig obj2 = new ConfirmPayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "0";
                                            RemainderBLL.UpdatePayConfirmBasicIsOpen(obj2);
                                            context.Response.Write("2");//closed
                                        }
                                        else
                                        {
                                            SellerReminderMaster obj = new SellerReminderMaster();
                                            obj.SellerNick = Users.Nick;
                                            obj.ConfirmPayOpen = "1";
                                            RemainderBLL.UpdatePayConfirmMaster(obj);
                                            ConfirmPayReminderConfig obj2 = new ConfirmPayReminderConfig();
                                            obj2.SellerNick = Users.Nick;
                                            obj2.IsOpen = "1";
                                            RemainderBLL.UpdatePayConfirmBasicIsOpen(obj2);
                                            context.Response.Write("3");//opened
                                        }
                                    }

                                }
                                catch (Exception ex)
                                {
                                    context.Response.Write("0");
                                }
                                context.Response.End();

                            }
                            #endregion
                        }
                        break;
                }
            }
        }

        private Boolean CheckIsOpenMsgAcount()
        {
            //短信账户判断
            if (!MsgBLL.CheckSellerMsgStatus())
            {
                return false;
            }
            return true;
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