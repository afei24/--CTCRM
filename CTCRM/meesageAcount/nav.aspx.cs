using System;
using System.Collections;
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
using System.Collections.Generic;
using Com.Alipay;
using Top.Api;
using TOPCRM;
using Top.Api.Request;
using Top.Api.Response;
using CTCRM.Components;
using Top.Api.Util;
using Top.Api.Domain;
using CTCRM.Entity;
using System.IO;
using System.Text;
using System.Net;

namespace CTCRM.meesageAcount
{
    public partial class nav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bool b = UserTempMsgOrderBLL.Delete(Users.Nick);
            string orderType = Request.QueryString["type"].ToString();
            if (!string.IsNullOrEmpty(orderType))
            {
                
                switch (orderType)
                {
                    case "FW_GOODS-1000305107":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000305512":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306533":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306628":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306704":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306705":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306433":
                        OrderMessage(orderType);
                        break;
                    case "FW_GOODS-1000306706":
                        OrderMessage(orderType);
                        break;
                    default:
                        break;

                }

            }
        }

        private void OrderMessage(string totalFee, string tradeNo)
        {
            //把请求参数打包成数组
            SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            sParaTemp.Add("partner", Config.Partner);
            sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            sParaTemp.Add("service", "create_direct_pay_by_user");
            sParaTemp.Add("payment_type", "1");
            sParaTemp.Add("notify_url", "http://crm.new9channel.com/meesageAcount/notify_url.aspx");
            sParaTemp.Add("return_url", "http://crm.new9channel.com/meesageAcount/return_url.aspx");
            sParaTemp.Add("seller_email", Config.Seller_email);
            sParaTemp.Add("out_trade_no", tradeNo);
            sParaTemp.Add("subject", "短信套餐");
            sParaTemp.Add("total_fee", totalFee);
            sParaTemp.Add("body", "");
            sParaTemp.Add("show_url", "");
            sParaTemp.Add("anti_phishing_key", "");
            sParaTemp.Add("exter_invoke_ip", "");
            //建立请求
            string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            Response.Write(sHtmlText);
        }

        private void OrderMessage(string articleCode)
        {
            string outTradeCode;
            string outOrderId;
            string tradeNo = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
                    + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            outTradeCode = tradeNo;
            outOrderId = tradeNo;
            if (!BuyMessage(articleCode))
            {
                
                string s = OrderConfirm(articleCode + "-1", outTradeCode);
                XElement root = XElement.Parse(s.Remove(0,39));
                string value = root.Element("url").Value;
                
                bool b = UserTempMsgOrderBLL.Add(outTradeCode, Users.Nick, articleCode);
                if (!b)
                {
                    Response.Write("<script language='javascript'>alert('跳转失败，请联系客服人员！');</script>");
                    return;
                }
                Response.Redirect(value);
                //string result1 = PostToServer(value);
                //if (result1 == null)
                //{
                //    return;
                //}
                //File.AppendAllText(@"D:\log\test1.txt", result1, Encoding.Default);
                //if (result1.Contains("taobao_fuwu_OrderPaid"))
                //{
                //    string res = OrderPay(outOrderId);
                //    IDictionary resultDic = TopUtils.ParseJson(res);
                //    string result =  PostToServer(resultDic["url"].ToString());
                //    File.AppendAllText(@"D:\log\OrderPay.txt", result, Encoding.Default);
                //    if (result.Contains("taobao_fuwu_OrderPaid"))
                //    {
                //        switch (articleCode)
                //        {
                //            case "FW_GOODS-1000305107":
                //                OrderMsg("1000", 35, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000305512":
                //                OrderMsg("2000", 70, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306533":
                //                OrderMsg("5000", 175, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306628":
                //                OrderMsg("10000", 350, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306704":
                //                OrderMsg("20000", 700, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306705":
                //                OrderMsg("50000", 1750, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306433":
                //                OrderMsg("100000", 3500, "0.035元/条");
                //                break;
                //            case "FW_GOODS-1000306706":
                //                OrderMsg("200000", 6800, "0.034元/条");
                //                break;
                //            default:
                //                break;

                //        }
                //    }
                //}
            }
        }

        private static bool BuyMessage(string articleCode)
        {
            try
            {
                //File.AppendAllText(@"D:\log\BuyMessage.txt", "BuyMessage_start", Encoding.Default);
                ITopClient client = TBManager.GetClient();
                FuwuSkuGetRequest req = new FuwuSkuGetRequest();
                req.ArticleCode = articleCode;
                req.Nick = Users.Nick;
                req.AppKey = "21088197";
                FuwuSkuGetResponse rsp = client.Execute(req, Users.SessionKey);
                bool b = rsp.IsError;
                //File.AppendAllText(@"D:\log\BuyMessage.txt", b.ToString(), Encoding.Default);
                return b;
                
            }
            catch (Exception e)
            {
                File.AppendAllText(@"D:\log\BuyMessageerro.txt", e.Message, Encoding.Default);
                return true;
            }

            
        }

        static string OrderConfirm(string itemCode, string outTradeCode)
        {
            ITopClient client = TBManager.GetClient();
            FuwuPurchaseOrderConfirmRequest req = new FuwuPurchaseOrderConfirmRequest();
            OrderConfirmQueryDto obj1 = new OrderConfirmQueryDto();
            obj1.AppKey = "21088197";
            obj1.ItemCode = itemCode;
            obj1.CycUnit = "2";
            obj1.CycNum = "3";
            obj1.OutTradeCode = outTradeCode;
            obj1.DeviceType = "pc";
            obj1.Quantity = "23";
            req.ParamOrderConfirmQueryDTO_ = obj1;
            FuwuPurchaseOrderConfirmResponse rsp = client.Execute(req);
            return rsp.Body;
        }

        static string OrderPay(string outOrderId)
        {
            ITopClient client = TBManager.GetClient();
            FuwuPurchaseOrderPayRequest req = new FuwuPurchaseOrderPayRequest();
            req.Appkey = "21088197";
            req.OutOrderId = outOrderId;
            req.DeviceType = "pc";
            FuwuPurchaseOrderPayResponse rsp = client.Execute(req);
            return rsp.Body;
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

        public static string PostToServer(string url)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=GBK";
                //string urlText = postData;
                //byte[] bs = Encoding.GetEncoding("GBK").GetBytes(urlText);
                //httpWebRequest.ContentLength = bs.Length;
                //Stream newStream = httpWebRequest.GetRequestStream();//把传递的值写到流中   
                //newStream.Write(bs, 0, bs.Length);
                //newStream.Close();//必须要关闭 请求
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("gbk"));
                string retValue = sr.ReadToEnd();
                //MessageBox.Show(retValue);
                sr.Close();
                httpWebResponse.Close();
                //WebClient.DownloadString(url);
                return retValue;

                
                //HttpWebRequest webrequest = (HttpWebRequest)HttpWebRequest.Create(url);
                //HttpWebResponse webreponse = (HttpWebResponse)webrequest.GetResponse();
                //Stream stream = webreponse.GetResponseStream();
                //byte[] rsByte = new Byte[webreponse.ContentLength];  //save data in the stream
                //stream.Read(rsByte, 0, (int)webreponse.ContentLength);
                //return System.Text.Encoding.UTF8.GetString(rsByte, 0, rsByte.Length).ToString();

            }
            catch (Exception e)
            {
                File.AppendAllText(@"D:\log\PostToServereerro.txt", e.Message, Encoding.Default);
                return "";
            }
        }

    }
}
