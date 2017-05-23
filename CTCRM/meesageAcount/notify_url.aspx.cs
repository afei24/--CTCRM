using Com.Alipay;
using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace CTCRM.meesageAcount
{
    public partial class notify_url : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SortedDictionary<string, string> sPara = GetRequestPost();
            if (sPara.Count > 0)//判断是否有带返回参数
            {
                Notify aliNotify = new Notify();
                bool verifyResult = aliNotify.Verify(sPara, Request.Form["notify_id"], Request.Form["sign"]);

                if (verifyResult)//验证成功
                {
                    //商户订单号
                    string out_trade_no = Request.QueryString["out_trade_no"];
                    //支付宝交易号
                    string trade_no = Request.QueryString["trade_no"];
                    //交易状态
                    string trade_status = Request.QueryString["trade_status"];
                    if (Request.Form["trade_status"] == "TRADE_SUCCESS")
                    {
                        string orderType = out_trade_no.Substring(out_trade_no.IndexOf("-") + 1);
                        switch (orderType)
                        {
                            case "1000":
                                OrderMsg("1000", 35, "0.035元/条");
                                break;
                            case "2000":
                                OrderMsg("2000", 70, "0.035元/条");
                                break;
                            case "5000":
                                OrderMsg("5000", 175, "0.035元/条");
                                break;
                            case "10000":
                                OrderMsg("10000", 350, "0.035元/条");
                                break;
                            case "20000":
                                OrderMsg("20000", 700, "0.035元/条");
                                break;
                            case "50000":
                                OrderMsg("50000", 1750, "0.035元/条");
                                break;
                            case "100000":
                                OrderMsg("100000", 3500, "0.035元/条");
                                break;
                            case "200000":
                                OrderMsg("200000", 6800, "0.034元/条");
                                break;
                            default:
                                break;

                        }
                        Response.Write("success");  //请不要修改或删除
                    }
                    else
                    {

                    } 
                }
                else//验证失败
                {
                    Response.Write("fail");
                }
            }
            else
            {
                Response.Write("无通知参数");
            }
        }

        private void OrderMsg(string msgCount, int price, string perPrice)
        {
            MsgPackage obj = new MsgPackage();
            obj.PackageName = "店铺管家短信套餐(淘宝)" + msgCount + "条";
            obj.Type = "永久有效";
            obj.SellerNick = Users.Nick;
            obj.Price = price;
            obj.PerPrice = perPrice;
            obj.Rank = "短信套餐(短信充值)";
            obj.OrderDate = DateTime.Now;
            obj.PayStatus = true;
            MsgBLL.AddMsgPackage(obj);

            obj.CanUseStartDate = DateTime.Now;
            obj.MsgCanUseCount = Convert.ToInt32(msgCount);
            obj.MsgTotalCount = Convert.ToInt32(msgCount);
            MsgPagke(obj);
            //发送短信提醒
            MsgNofity(obj.PackageName);

        }
        private void MsgPagke(MsgPackage obj)
        {
            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(obj.SellerNick);
            obj.ServiceStatus = true;
            if (String.IsNullOrEmpty(checkIsExit))//卖家第一次订购
            {
                MsgBLL.AddMsgTrans(obj);
            }
            else if (Convert.ToBoolean(checkIsExit))//如果成立，表示卖家短信套餐还未用完时继续充值，则叠加之前的短信条数
            {
                MsgBLL.UpdateMsgTransForSecond(obj);
            }
            else//表示卖家之前的短信套餐已经用完，再次充值。
            {
                MsgBLL.UpdateMsgTrans(obj);
            }
        }

        /// <summary>
        /// 短信通知短信订购
        /// </summary>
        /// <param name="content"></param>
        private void MsgNofity(string content)
        {
            //string sendResut = Mobile.PostDataToMyServer("18502840601", "订单" + content + "【店铺管家】", "");

        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public SortedDictionary<string, string> GetRequestPost()
        {
            int i = 0;
            SortedDictionary<string, string> sArray = new SortedDictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], Request.Form[requestItem[i]]);
            }
            return sArray;
        }
    }
}
