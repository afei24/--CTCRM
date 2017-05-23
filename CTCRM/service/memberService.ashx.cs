using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CTCRM.Components;
using System.Data;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CTCRM.Common;
using CTCRM.Entity;
using Top.Api.Util;
using CTCRM.Components.TopCRM;

namespace CTCRM.sevice
{
    /// <summary>
    /// memberService 的摘要说明
    /// 修改人：LU 
    /// 日期：20160910   修改发送短信
    /// 日期：201601005  修改过滤黑名单
    /// </summary>
    public class memberService : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            getCmd(context);
        }

        void getCmd(HttpContext context)
        {
            string cmd = context.Request.Form["cmd"];
            switch (cmd)
            {
                //查询会员
                case "getMember":
                    getMember(context);
                    break;
                //发送短信
                case "sendMsg":
                    sendMsg(context);
                    break;
                case "getMsgCount":
                    context.Response.Write(getMsgCountByNick());
                    break;
                case "getNews":
                    context.Response.Write(getNews());
                    break;
                case "getTempMsg":
                    context.Response.Write(getTempMsg(context));
                    break;

            };
        }

        string getTempMsg(HttpContext context)
        {
            int ret = Convert.ToInt16(context.Request.Form["type"]);
            DataTable dt = MsgContentsBLL.getMsgByPageType(ret);
            ArrayList list = new ArrayList();
            if (dt != null && dt.Rows.Count > 0)
            {
                string json_obj = "{'msg':[";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string type = Convert.ToString(dt.Rows[i]["page_type"]);
                    if (string.IsNullOrEmpty(type) == true)
                    {
                        return "{'ret':'1'}";
                    };
                    if (list.Count <= 0)
                    {
                        list.Add(type);
                    }
                    else
                    {
                        if (list.IndexOf(type) < 0)
                        {
                            list.Add(type);
                        }
                    }
                    json_obj += "{";
                    json_obj += @"'pageType':'" + Convert.ToString(dt.Rows[i]["page_type"]) + "',";
                    json_obj += @"'typeTitle':'" + Convert.ToString(dt.Rows[i]["type_title"]) + "',";
                    json_obj += @"'msgContent':'" + Convert.ToString(dt.Rows[i]["msg_content"]) + "'";
                    json_obj += "}";
                    if (i != dt.Rows.Count - 1)
                    {
                        json_obj += ",";
                    }
                }
                json_obj += "],'ret':'0',typelist:'" + listToString(list) + "'}";
                return json_obj;
            }
            return "";
        }

        string listToString(ArrayList list)
        {
            string returnStr = string.Empty;
            foreach (string type in list)
            {
                if (returnStr.Equals(string.Empty) == true)
                {
                    returnStr = type;
                }
                else {
                    returnStr += "," + type;
                }
            }
            return returnStr;
        }

        /// <summary>
        /// 获取用户短信条数
        /// </summary>
        /// <param name="nick"></param>
        /// <returns></returns>
        string getMsgCountByNick()
        {

            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                return tb.Rows[0]["msgCanUseCount"].ToString();
            }
            return "0";
        }

        //发送短信
        void sendMsg(HttpContext context)
        {
            string sigNames = SellersBLL.GetSignName(Users.Nick);
            string sigName = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
            string msgContent = Convert.ToString(context.Request.Form["msgContent"]);
            msgContent =msgContent.Trim() ;
            string data = context.Request.Form["data"];
            JObject o = JObject.Parse(data);
            JArray ja = JArray.Parse(o["members"].ToString());

            if (ja != null && ja.Count > 0)
            {
                foreach (var member in ja)
                {
                    string name = member["nick"].ToString();
                    string phone = member["phone"].ToString();
                    string content = context.Request.Form["content"];
                    //控制是否过滤移动号码
                    string flag = context.Request.Form["falg"];
                    string signShopName = SellersBLL.GetSignName(Users.Nick);
                    MsgSendHis objHis = null;
                    //string msgContent = "【" + signShopName + "】" + content.Trim() + " 退订回N";
                    try
                    {
                        BlakList objbk = new BlakList();
                        objbk.SellerNick = Users.Nick;
                        objbk.BlakName = name;
                        //黑名单
                        if (!BlcakLstBLL.ChekBlaklist(objbk))
                        {
                            var cellpone = phone;
                            if (Utility.IsCellPhone(cellpone) && !string.IsNullOrEmpty(cellpone))
                            {
                                #region 短信发送
                                if (MsgBLL.CheckSellerMsgStatus())
                                {
                                    objHis = new MsgSendHis();
                                    objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString()
                                        + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellpone;//手机号码 2016 yao c
                                    objHis.SellerNick = Users.Nick;
                                    objHis.Buyer_nick = name;
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
                                            string sendStatus = TBSendMSg.SendMsg(cellpone, sigNames, objHis.MsgContent.Trim().Replace(sigName, ""));
                                            if (Utility.IsYiDongCellPhoneNo(cellpone))
                                            {
                                                //string sendStatus = Mobile.SendMsgHuBeiYD(cellpone, msgContent);
                                                //string sendStatus = Mobile.sendMsgJiuFang(cellpone, msgContent, "100057", "c9bf7c4cb27c5527c4d757765514498e");//20160625 yao
                                                //string sendStatus = Mobile.SendMsgHubeiYDPost(cellpone, msgContent);
                                                //sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                                if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                                SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                            }
                                            else//电信联通号码全部群发
                                            {
                                                //string sendStatus = Mobile.PostDataToMyServer(cellpone, msgContent.Trim());
                                                //IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                                SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
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
            }
        }

        string getNews()
        {
            DataTable dt = SystemMessagesBLL.QueryShowMsg();
            if (dt != null && dt.Rows.Count > 0)
            {
                string json_obj = "{'news':[";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    json_obj += "{";
                    json_obj += "'title':'" + Convert.ToString(dt.Rows[i]["SystemLink"]) + "',";
                    json_obj += "'content':'" + Convert.ToString(dt.Rows[i]["SystemMsg"]) + "',";
                    json_obj += "'date':'" + Convert.ToString(dt.Rows[i]["SystemDate"]) + "',";
                    json_obj += "}";
                    if (i != dt.Rows.Count - 1)
                    {
                        json_obj += ",";
                    }
                }
                json_obj += "],'ret':'0'}";
                return json_obj;
            }
            //lb_memberNum.Text = "0个会员";
            return ("{'ret':'1'}");
        }

        void getMember(HttpContext context)
        {
            string buyerNick = context.Request.Form["nick"];
            string lastTradeDate1 = context.Request.Form["tradeStartTime"];
            string lastTradeDate2 = context.Request.Form["tradeEndTime"];
            string grade = context.Request.Form["level"];
            string num1 = context.Request.Form["txt_good_count01"];
            string num2 = context.Request.Form["txt_good_count02"];
            string area = context.Request.Form["area"];
            string tradeAmount1 = context.Request.Form["money01"];
            string tradeAmount2 = context.Request.Form["money02"];
            string tradePinNv = context.Request.Form["interval"];
            string buyCount = context.Request.Form["count"];
            string day = context.Request.Form["day"];
            //bool comment = context.Request.Form["comment"];
            string blaklist = context.Request.Form["blacklist"];

            DataTable dtBlackList = new DataTable();
            if (blaklist.ToLower() == "true")
            {
                dtBlackList = BlcakLstBLL.GetBlaklist(Users.Nick);
            }
            string drpDay = "";
            DataTable ds = BuyerBLL.GetBuyerInfoToMsg(buyerNick, lastTradeDate1, lastTradeDate2, grade, num1, num2,
            area, tradeAmount1, tradeAmount2, Users.Nick, drpDay, tradePinNv, buyCount);

            if (ds != null && ds.Rows.Count > 0)
            {

                string json_obj = "{'members':[";
                for (int i = 0; i < ds.Rows.Count; i++)
                {
                    if (dtBlackList != null && dtBlackList.Rows.Count > 0)
                    {
                        DataRow[] dr = dtBlackList.Select("blakName='" + ds.Rows[i]["buyer_nick"] + "'");
                        if (dr.Length > 0 && dr != null)
                        {
                            continue;
                        }
                    }
                    json_obj += "{";
                    json_obj += "'nick':'" + Convert.ToString(ds.Rows[i]["buyer_nick"]) + "',";
                    json_obj += "'phone':'" + Convert.ToString(ds.Rows[i]["cellPhone"]) + "',";
                    json_obj += "'tradeTime':'" + Convert.ToString(ds.Rows[i]["last_trade_time"]) + "',";
                    json_obj += "'tradeAmount':'" + Convert.ToString(ds.Rows[i]["trade_amount"]) + "',";
                    json_obj += "'groupId':'" + Convert.ToString(ds.Rows[i]["group_id"]) + "'";
                    json_obj += "}";
                    if (i != ds.Rows.Count)
                    {
                        json_obj += ",";
                    }
                }
                json_obj += "],'ret':'0'}";
                context.Response.Write(json_obj);
                //context.Response.End();
            }
            else
            {
                //lb_memberNum.Text = "0个会员";
                context.Response.Write("{'ret':'1'}");
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