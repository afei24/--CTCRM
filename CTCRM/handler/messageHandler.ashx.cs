using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Top.Api.Util;
using System.IO;
using CTCRM.Components.TopCRM;

namespace CTCRM.handler
{
    /// <summary>
    /// messageHandler 的摘要说明
    /// </summary>
    public class messageHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var command = context.Request.Form["command"];          
            if (!string.IsNullOrEmpty(command))
            {
                switch (command)
                {
                    #region msgConSave
                    case "msgConSave":
                        {
                            string content = context.Request.Form["msgContent"];
                            if (MsgBLL.UpdateSellerCusMsgContent(Users.Nick, content))
                            {
                                context.Response.Write("1");
                            }
                            else
                            {
                                context.Response.Write("0");
                            }
                            context.Response.End();
                        }
                        break;
                    #endregion

                    #region getConSave
                    case "getConSave":
                        {
                            string content = MsgBLL.GetSellerSendMsgCusContent(Users.Nick);
                            context.Response.Write(content);
                            context.Response.End();
                        }
                        break;
                    #endregion

                    #region sendTestMsg
                    case "sendTestMsg":
                        {
                            string sigNames = SellersBLL.GetSignName(Users.Nick);
                            string sigName = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
                            string phoneNo = context.Request.Form["phone"];
                            string content = context.Request.Form["content"];
                            string[] noWenmings = new string[] { "傻逼","草","靠","黄片","尼玛","你妈","屌丝","逗比","你妹","装逼","妈蛋","逼格","撕逼","卧草","我日","我擦"
                ,"滚粗","蛋疼","婊砸","跪舔","婊","碧池","土肥圆","矮穷挫"};
                            for (int s = 0; s < noWenmings.Length - 1; s++)
                            {
                                if (content.IndexOf(noWenmings[s]) > 0)
                                {
                                    context.Response.Write("6");
                                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                                    return;
                                }
                            }
                            if (Utility.IsCellPhone(phoneNo))
                            {
                                if (MsgBLL.CheckSellerMsgStatus())
                                {
                                    string msgContent =content.Trim() + " 退订回N";
                                    //string msgContent = "";
                                    //if (RatingBLL.isBshop(Users.Nick))
                                    //{
                                    //    msgContent = "【天猫】"+ content.Trim() + " 退订N";
                                    //}
                                    //else
                                    //{
                                    //    msgContent = "【淘宝】"+ content.Trim() + " 退订N";
                                    //}
                                  
                                    MsgSendHis objHis = new MsgSendHis();
                                    //objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + phoneNo;//手机号码
                                    objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + phoneNo;//手机号码 2016 yao c
                                    objHis.SellerNick = Users.Nick;
                                    objHis.Buyer_nick = "*****";
                                    objHis.CellPhone = phoneNo;
                                    objHis.SendDate = DateTime.Now;
                                    objHis.SendType = "自测短信";
                                    objHis.SendStatus = "0";
                                    objHis.Count = "1";
                                    objHis.MsgContent = sigName+msgContent;
                                    if (Utility.IsYiDongCellPhoneNo(phoneNo))
                                    {
                                        objHis.HelpSellerNick = "移动";
                                    }
                                    if (SmartBLL.AddMsgSendHis(objHis))
                                    { 
                                        //把号码添加到测试池
                                        SmartBLL.AddMsgSendHisIntoTestTable(Users.Nick, phoneNo);   
                                        if (Convert.ToInt32(msgContent.Trim().Length) <= 70)
                                        {
                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                        }
                                        else if (Convert.ToInt32(msgContent.Trim().Length) > 70 && Convert.ToInt32(msgContent.Trim().Length) <= 134)
                                        {
                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                        }
                                        else if (Convert.ToInt32(msgContent.Trim().Length) > 134 && Convert.ToInt32(msgContent.Trim().Length) <= 195)
                                        {
                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                        }
                                        else if (Convert.ToInt32(msgContent.Trim().Length) > 195 && Convert.ToInt32(msgContent.Trim().Length) <= 260)
                                        {
                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                        }
                                        string sendStatus = "0";
                                        if (Utility.IsYiDongCellPhoneNo(phoneNo))
                                        {
                                            sendStatus = TBSendMSg.SendMsg(phoneNo, sigNames, objHis.MsgContent.Replace(sigName, ""));
                                            //sendStatus = Mobile.SendMsgHubeiYDPost(phoneNo, msgContent);
                                            //sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                            if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                            //sendStatus = Mobile.sendMsgJiuFang(phoneNo, msgContent,"100057", "c9bf7c4cb27c5527c4d757765514498e");//20160621 yao
                                            //更新发送状态
                                            SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                            //sendStatus = Mobile.SendMsgZhuTongYD(phoneNo, msgContent);
                                        }
                                        else
                                        {
                                            sendStatus = TBSendMSg.SendMsg(phoneNo, sigNames, objHis.MsgContent.Replace(sigName, ""));
                                            //sendStatus = Mobile.PostDataToMyServer(phoneNo, msgContent);
                                            //IDictionary resultDic = null;
                                            //resultDic = TopUtils.ParseJson(sendStatus);
                                            //string realStaus = resultDic["status"].ToString();
                                            //更新发送状态
                                            SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                            //sendStatus = Mobile.SendMsgKeTongDX(phoneNo, msgContent); 
                                        }  

                                        context.Response.Write("发送成功");
                                    }
                                    else
                                    {
                                        context.Response.Write("发送阻塞");
                                    }
                                }
                                else
                                {
                                    context.Response.Write("余额不足");
                                    //更新短信账户状态
                                    MsgBLL.UpdateMsgTransServiceStatus(Users.Nick, false);
                                }
                            }
                            else
                            {
                                context.Response.Write("手机号码格式不正确");
                            }
                            context.Response.End();
                        }
                        break;
                    #endregion

                    #region sendMsg
                    case "sendMsg":
                        {
                            string content = context.Request.Form["content"];
                            string[] noWenmings = new string[] { "傻逼","草","靠","黄片","尼玛","你妈","屌丝","逗比","你妹","装逼","妈蛋","逼格","撕逼"
                ,"滚粗","蛋疼","婊砸","跪舔","婊","碧池","土肥圆","矮穷挫"};
                            for (int s = 0; s < noWenmings.Length - 1; s++)
                            {
                                if (content.IndexOf(noWenmings[s]) > 0)
                                {
                                    context.Response.Write("6");
                                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                                    return;
                                }
                            }
                            //控制是否过滤移动号码
                            string flag = context.Request.Form["falg"];
                            string signShopName = SellersBLL.GetSignName(Users.Nick);
                            MsgSendHis objHis = null;
                            string msgContent = "【" + signShopName + "】" + content.Trim() + " 退订回N";                          
                            DataTable tb = HttpContext.Current.Session["MsgData"] as DataTable;
                            if (tb != null && tb.Rows.Count > 0)
                            {
                                for (int i = 0; i < tb.Rows.Count; i++)
                                {
                                    try
                                    {
                                        BlakList objbk = new BlakList();
                                        objbk.SellerNick = Users.Nick;
                                        objbk.BlakName = tb.Rows[i]["buyer_nick"].ToString();
                                        //黑名单
                                        if (!BlcakLstBLL.ChekBlaklist(objbk))
                                        {
                                            var cellpone = tb.Rows[i]["cellPhone"].ToString();
                                            if (Utility.IsCellPhone(cellpone) && !string.IsNullOrEmpty(cellpone))
                                            {
                                               #region 短信发送
                                                    if (MsgBLL.CheckSellerMsgStatus())
                                                    {
                                                        objHis = new MsgSendHis();
                                                        //objHis.TransNumber = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                                                        //                     + DateTime.Now.Day.ToString() + cellpone;
                                                        objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellpone;//手机号码 2016 yao c
                                                        objHis.SellerNick = Users.Nick;
                                                        objHis.Buyer_nick = tb.Rows[i]["buyer_nick"].ToString();
                                                        objHis.CellPhone = cellpone;
                                                        objHis.SendDate = DateTime.Now;
                                                        objHis.SendType = "短信促销";
                                                        objHis.SendStatus = "0";
                                                        objHis.Count = "1";
                                                        objHis.MsgContent = msgContent;
                                                        if (Utility.IsYiDongCellPhoneNo(cellpone))
                                                        {
                                                            objHis.HelpSellerNick = "移动";
                                                        }
                                                        else
                                                        {
                                                            objHis.HelpSellerNick = "电信联通";
                                                        }
                                                        if (SmartBLL.AddMsgSendHis(objHis))
                                                        {
                                                            try
                                                            {
                                                                //string sendStatus = Mobile.sendMsg(lstCellPhoneNo, msgContent);
                                                                if (Convert.ToInt32(msgContent.Trim().Length) <= 70)
                                                                {
                                                                    MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                                                }
                                                                else if (Convert.ToInt32(msgContent.Trim().Length) > 70 && Convert.ToInt32(msgContent.Trim().Length) <= 134)
                                                                {
                                                                    MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                                                }
                                                                else if (Convert.ToInt32(msgContent.Trim().Length) > 134 && Convert.ToInt32(msgContent.Trim().Length) <= 195)
                                                                {
                                                                    MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                                                }
                                                                else if (Convert.ToInt32(msgContent.Trim().Length) > 195 && Convert.ToInt32(msgContent.Trim().Length) <= 260)
                                                                {
                                                                    MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                                                }
                                                                    if (Utility.IsYiDongCellPhoneNo(cellpone))
                                                                    {
                                                                        //string sendStatus = Mobile.SendMsgHuBeiYD(cellpone, msgContent);
                                                                        //string sendStatus = Mobile.sendMsgJiuFang(cellpone, msgContent, "100057", "c9bf7c4cb27c5527c4d757765514498e");//20160625 yao
                                                                        string sendStatus = Mobile.SendMsgHubeiYDPost(cellpone, msgContent);
                                                                        sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                                                        if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                                                        SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                                                    }
                                                                    else//电信联通号码全部群发
                                                                    {
                                                                        string sendStatus = Mobile.PostDataToMyServer(cellpone, msgContent.Trim());
                                                                        IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                                                        SmartBLL.UpdateSendStatus(resultDic["status"].ToString(), objHis.TransNumber);
                                                                    }                                                             
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                                                                continue;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        //更新短信账户状态
                                                        MsgBLL.UpdateMsgTransServiceStatus(Users.Nick, false);
                                                        context.Response.Write("余额不足");
                                                        context.Response.End();
                                                        break;
                                                    }
                                                    #endregion
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                }
                                HttpContext.Current.Session["MsgData"] = null;     
                                //发送成功
                                context.Response.Write("发送成功");
                                context.Response.End();
                            }
                            else {
                                context.Response.Write("没有会员");
                                context.Response.End();
                            }                           
                        }
                        break;
                    #endregion

                    #region sendSmartMsg
                    case "sendSmartMsg":
                        {
                            string content = context.Request.Form["content"];
                            string sendType = context.Request.Form["sendType"];
                            string province = context.Request.Form["provinces"];
                            MsgSendHis objHis = null;
                            string msgContent = "【" + SellersBLL.GetSignName(Users.Nick) + "】" + content.Trim() + " 退订回N";
                            //if (RatingBLL.isBshop(Users.Nick))
                            //{
                            //    msgContent = "【天猫】" + content.Trim() + " 退订N";
                            //}
                            //else
                            //{
                            //    msgContent = "【淘宝】" + content.Trim() + " 退订N";
                            //}
                            DataTable tb = null;

                            #region 新会员
                            if (sendType.Equals("10"))
                            {
                                tb = SmartBLL.GetNewBuyer10Days(Users.SellerId);
                            } 
                            if (sendType.Equals("30"))
                            {
                                tb = SmartBLL.GetNewBuyer30Days(Users.SellerId);
                            }
                            #endregion

                            #region 会员等级
                            if (sendType.Equals("puTongBuyer"))
                            {
                                tb = SmartBLL.GetBuyersCount(1, Users.SellerId);
                            }
                            if (sendType.Equals("gaoJiBuyer"))
                            {
                                tb = SmartBLL.GetBuyersCount(2, Users.SellerId);
                            }
                            if (sendType.Equals("vipBuyer"))
                            {
                                tb = SmartBLL.GetBuyersCount(3, Users.SellerId);
                            }
                            if (sendType.Equals("gaoJiVIPBuyer"))
                            {
                                tb = SmartBLL.GetBuyersCount(4, Users.SellerId);
                            }
                            #endregion

                            #region 活跃度
                            if (sendType.Equals("HuoYueDiGouMaiQiang"))
                            {
                                tb = SmartBLL.GetHuoYueDiGouMaiQiangBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("HuoYueBanGouMaiBan"))
                            {
                                tb = SmartBLL.GetHuoYueBanGouMaiBanBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("HuoYueGaoGouMaiBan"))
                            {
                                tb = SmartBLL.GetHuoYueGaoGouMaiBanBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("HuoYueGaoGouMaiGao"))
                            {
                                tb = SmartBLL.GetHuoYueGaoGouMaiGaoBuyersCount(Users.SellerId);
                            }
                            #endregion

                            #region 节假日
                            if (sendType.Equals("yuandan"))
                            {
                                string date = DateTime.Now.AddYears(-1).Year.ToString() + "-01-01";
                                string date2 = DateTime.Now.Year.ToString() + "-01-01";
                                tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
                            }
                            if (sendType.Equals("qinren"))
                            {
                                string date2 = DateTime.Now.AddYears(-1).Year.ToString() + "-02-14";
                                string date22 = DateTime.Now.Year.ToString() + "-02-14";
                                tb = SmartBLL.GetHuoDongBuyersCount(date2, Users.SellerId, date22);
                            }
                            if (sendType.Equals("funv"))
                            {
                                string date3 = DateTime.Now.AddYears(-1).Year.ToString() + "-03-18";
                                string date33 = DateTime.Now.Year.ToString() + "-03-18";
                                tb = SmartBLL.GetHuoDongBuyersCount(date3, Users.SellerId, date33);
                            }
                            if (sendType.Equals("wuyi"))
                            {
                                string date4 = DateTime.Now.AddYears(-1).Year.ToString() + "-05-01";
                                string date44 = DateTime.Now.Year.ToString() + "-05-01";
                                tb = SmartBLL.GetHuoDongBuyersCount(date4, Users.SellerId, date44);
                            }
                            if (sendType.Equals("fuqin"))
                            {
                                string date5 = DateTime.Now.AddYears(-1).Year.ToString() + "-06-17";
                                string date55 = DateTime.Now.Year.ToString() + "-06-17";
                                tb = SmartBLL.GetHuoDongBuyersCount(date5, Users.SellerId, date55);
                            }
                            if (sendType.Equals("qixi"))
                            {
                                string date6 = DateTime.Now.AddYears(-1).Year.ToString() + "-08-23";
                                string date66 = DateTime.Now.Year.ToString() + "-08-23";
                                tb = SmartBLL.GetHuoDongBuyersCount(date6, Users.SellerId, date66);
                            }
                            if (sendType.Equals("zhongqiu"))
                            {
                                string date7 = DateTime.Now.AddYears(-1).Year.ToString() + "-09-30";
                                string date77 = DateTime.Now.Year.ToString() + "-09-30";
                                tb = SmartBLL.GetHuoDongBuyersCount(date7, Users.SellerId, date77);
                            }
                            if (sendType.Equals("guoqing"))
                            {
                                string date8 = DateTime.Now.AddYears(-1).Year.ToString() + "-10-01";
                                string date88 = DateTime.Now.Year.ToString() + "-10-01";
                                tb = SmartBLL.GetHuoDongBuyersCount(date8, Users.SellerId, date88);
                            }
                            if (sendType.Equals("11"))
                            {
                                string date9 = DateTime.Now.AddYears(-1).Year.ToString() + "-11-11";
                                string date99 = DateTime.Now.Year.ToString() + "-11-11";
                                tb = SmartBLL.GetHuoDongBuyersCount(date9, Users.SellerId, date99);
                            }
                            if (sendType.Equals("12"))
                            {
                                string date10 = DateTime.Now.AddYears(-1).Year.ToString() + "-12-12";
                                string date1010 = DateTime.Now.Year.ToString() + "-12-12";
                                tb = SmartBLL.GetHuoDongBuyersCount(date10, Users.SellerId, date1010);
                            }
                            if (sendType.Equals("shengdan"))
                            {
                                string date11 = DateTime.Now.AddYears(-1).Year.ToString() + "-12-25";
                                string date1111 = DateTime.Now.Year.ToString() + "-12-25";
                                tb = SmartBLL.GetHuoDongBuyersCount(date11, Users.SellerId, date1111);
                            }
                            #endregion

                            #region 未交易客户营销
                            if (sendType.Equals("unpay"))
                            {
                                tb = SmartBLL.GetUnPayBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("unpay7days"))
                            {
                                tb = SmartBLL.GetUnPay7DaysBuyersCount(Users.SellerId);
                            }
                            #endregion

                            #region 地区营销
                            if (sendType.Equals("baifang"))
                            {
                                tb = SmartBLL.GetBaiFangBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("nanfang"))
                            {
                                tb = SmartBLL.GetNanFangBuyersCount(Users.SellerId);
                            }
                            if (sendType.Equals("province"))
                            {
                                List<string> list = new List<string>(province.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                                tb = SmartBLL.GetProvinceBuyersCount(Users.SellerId, list);
                            }
                            #endregion

                            if (tb != null && tb.Rows.Count > 0)
                            {
                                for (int i = 0; i < tb.Rows.Count; i++)
                                {
                                    try
                                    {
                                        BlakList objbk = new BlakList();
                                        objbk.SellerNick = Users.Nick;
                                        objbk.BlakName = tb.Rows[i]["buyer_nick"].ToString();
                                        //黑名单
                                        if (!BlcakLstBLL.ChekBlaklist(objbk))
                                        {
                                            var cellpone = tb.Rows[i]["cellPhone"].ToString();
                                            if (Utility.IsCellPhone(cellpone) && !string.IsNullOrEmpty(cellpone))
                                            {
                                                #region 短信发送
                                                if (MsgBLL.CheckSellerMsgStatus())
                                                {
                                                    objHis = new MsgSendHis();
                                                    //objHis.TransNumber = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString()
                                                    //                     + DateTime.Now.Day.ToString() + cellpone;
                                                    objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellpone;//手机号码 2016 yao c
                                                    objHis.SellerNick = Users.Nick;
                                                    objHis.Buyer_nick = tb.Rows[i]["buyer_nick"].ToString();
                                                    objHis.CellPhone = cellpone;
                                                    objHis.SendDate = DateTime.Now;
                                                    objHis.SendType = "智能营销";
                                                    objHis.SendStatus = "0";
                                                    objHis.Count = "1";
                                                    objHis.MsgContent = msgContent;
                                                    if (Utility.IsYiDongCellPhoneNo(cellpone))
                                                    {
                                                        objHis.HelpSellerNick = "移动";
                                                    }
                                                    else
                                                    {
                                                        objHis.HelpSellerNick = "电信联通";
                                                    }
                                                    if (SmartBLL.AddMsgSendHis(objHis))
                                                    {
                                                        try
                                                        {
                                                            if (Convert.ToInt32(msgContent.Trim().Length) <= 70)
                                                            {
                                                                MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                                            }
                                                            else if (Convert.ToInt32(msgContent.Trim().Length) > 70 && Convert.ToInt32(msgContent.Trim().Length) <= 134)
                                                            {
                                                                MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                                            }
                                                            else if (Convert.ToInt32(msgContent.Trim().Length) > 134 && Convert.ToInt32(msgContent.Trim().Length) <= 195)
                                                            {
                                                                MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                                            }
                                                            else if (Convert.ToInt32(msgContent.Trim().Length) > 195 && Convert.ToInt32(msgContent.Trim().Length) <= 260)
                                                            {
                                                                MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                                            }                                                           
                                                            if (Utility.IsYiDongCellPhoneNo(cellpone))
                                                            {
                                                                //string sendStatus = Mobile.SendMsgHuBeiYD(cellpone, msgContent);
                                                                //string sendStatus = Mobile.sendMsgJiuFang(cellpone, msgContent, "100057", "c9bf7c4cb27c5527c4d757765514498e");//20160625 yao
                                                                string sendStatus = Mobile.SendMsgHubeiYDPost(cellpone, msgContent);
                                                                sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                                                if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                                                SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                                            }
                                                            else
                                                            {
                                                                string sendStatus = Mobile.PostDataToMyServer(cellpone, msgContent.Trim());
                                                                IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                                                SmartBLL.UpdateSendStatus(resultDic["status"].ToString(), objHis.TransNumber);
                                                            }                                                             
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                                                            continue;
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    //更新短信账户状态
                                                    MsgBLL.UpdateMsgTransServiceStatus(Users.Nick, false);
                                                    context.Response.Write("余额不足");
                                                    context.Response.End();
                                                    break;
                                                }
                                                #endregion
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                }
                                //发送成功
                                context.Response.Write("发送成功");
                                context.Response.End();
                            }
                            else
                            {
                                context.Response.Write("没有会员");
                                context.Response.End();
                            }
                        }
                        break;
                    #endregion

                    #region getMsgCount
                    case "getMsgCount":
                        {
                            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                            string count = "0";
                            if (tb != null && tb.Rows.Count > 0)
                            {
                                count = "剩余短信：" + tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                            }
                            else
                            {
                                count = "剩余短信：0条";
                            }
                            context.Response.Write(count);
                            context.Response.End();
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