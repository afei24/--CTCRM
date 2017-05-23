using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using CTCRM.Common;
using Top.Api;
using CTCRM.Entity;
using Top.Api.Request;
using CTCRM.DAL;
using Top.Api.Util;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Collections;
using Top.Api.Response;
using Top.Api.Domain;
using System.Threading;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
namespace CTCRM.Components.TopCRM
{
   public class TBManager
    {
        //正式测试环境
        public readonly static string DO__URL = "http://gw.api.taobao.com/router/rest";
     
        public static string appKey = System.Configuration.ConfigurationManager.AppSettings["appKey"];
        public static string appSecret = System.Configuration.ConfigurationManager.AppSettings["appSecret"];
        public static string redirect_URL = System.Configuration.ConfigurationManager.AppSettings["redirect_uri"];

        public const string sUserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.2; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        public const string sContentType = "application/x-www-form-urlencoded";
        public const string sRequestEncoding = "ascii";
        public const string sResponseEncoding = "utf-8";

        public static ClusterTopClient GetClient()
        {
            return new ClusterTopClient(DO__URL, (string.IsNullOrEmpty(appKey) ? "21088197" : appKey), (string.IsNullOrEmpty(appSecret) ? "1c178c273e89d4df8c3f535a5caaabf8" : appSecret));
        }


        #region Post 方法

        /// <summary> 
        /// Post data到url 
        /// </summary> 
        /// <param name="data">要post的数据</param> 
        /// <param name="url">目标url</param> 
        /// <returns>服务器响应</returns> 
       public static string PostDataToUrl(string data, string url)
        {
            Encoding encoding = Encoding.GetEncoding(sRequestEncoding);
            byte[] bytesToPost = encoding.GetBytes(data);
            return PostDataToUrl(bytesToPost, url);
           
        }

        /// <summary> 
        /// Post data到url 
        /// </summary> 
        /// <param name="data">要post的数据</param> 
        /// <param name="url">目标url</param> 
        /// <returns>服务器响应</returns> 
        static string PostDataToUrl(byte[] data, string url)
        {
            #region 创建httpWebRequest对象
            WebRequest webRequest = WebRequest.Create(url);
            HttpWebRequest httpRequest = webRequest as HttpWebRequest;
            if (httpRequest == null)
            {
                throw new ApplicationException(
                    string.Format("Invalid url string: {0}", url)
                    );
            }
            #endregion

            #region 填充httpWebRequest的基本信息
            httpRequest.UserAgent = sUserAgent;
            httpRequest.ContentType = sContentType;
            httpRequest.Method = "POST";
            #endregion

            #region 填充要post的内容
            httpRequest.ContentLength = data.Length;
            Stream requestStream = httpRequest.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();
            #endregion

           
            #region 发送post请求到服务器并读取服务器返回信息
            Stream responseStream = null;
            try
            {
                responseStream = httpRequest.GetResponse().GetResponseStream();
            }
            catch (Exception e)
            {
                e.ToString();//20160907 yao c
                // log error 
                //Console.WriteLine(
                //    string.Format("POST操作发生异常：{0}", e.Message)
                //    );//20160907 yao z
                //throw e;
                return null;//20160907 yao c
            }
            #endregion

            #region 读取服务器返回信息
            string stringResponse = string.Empty;
            using (StreamReader responseReader =
                new StreamReader(responseStream, Encoding.GetEncoding(sResponseEncoding)))
            {
                stringResponse = responseReader.ReadToEnd();
            }
            responseStream.Close();
            #endregion

            return stringResponse;
        }

        #endregion
        
       /// <summary>
       /// 初始信息处理
       /// </summary>
       /// <param name="hasShop"></param>
        public static string  WriteUserInfoToCookies()
        {
            HttpContext context = HttpContext.Current;
            string code = HttpContext.Current.Request.QueryString["code"];
            string state = HttpContext.Current.Request.QueryString["state"];
            string client_id = appKey;
            string client_secret = appSecret;
            string grant_type = "authorization_code";
            string redirect_uri = redirect_URL;
            int s = 0;//记录code获取源

            //从数据库获取code
            if (string.IsNullOrEmpty(code))
            {
                DataTable dt = SellersBLL.GetSellersCode(Users.Nick);
                if (dt != null && dt.Rows.Count > 0)
                {
                    s = 1;
                    code = dt.Rows[0]["code"].ToString();
                }
            }
            #region 获取授权Code
            if (!string.IsNullOrEmpty(code))
            {
                DataTable dt = SellersBLL.GetSellersCode(Users.Nick);
                if (dt != null && dt.Rows.Count > 0 && s==0)
                {
                    SellersBLL.UpdateSellersCode(Users.Nick,code);
                }
                else if (dt == null || dt.Rows.Count == 0)
                {
                    SellersBLL.AddSellersCode(Users.Nick, code);
                }

                //获取访问令牌
                string url = "https://oauth.taobao.com/token?client_id={0}&client_secret={1}&grant_type={2}&code={3}&redirect_uri={4}&scope={5}&view={6}&state={7}";
                string urlS = string.Format(url, client_id, client_secret, grant_type, code, redirect_uri, "item", "web", state);
                string getAuthAcessToken = PostDataToUrl(urlS, urlS);
                if (string.IsNullOrEmpty(getAuthAcessToken)) { return null; }//20160907 yao c
                IDictionary resultDic = TopUtils.ParseJson(getAuthAcessToken);
                context.Request.Cookies.Clear();
                context.Session.Clear();
                //获取卖家昵称
                string nick = HttpUtility.UrlDecode(resultDic["taobao_user_nick"].ToString(), Encoding.UTF8);
                //这里的SessionKey就是access_token
                string sessionKey = resultDic["access_token"].ToString();
                //获取刷新令牌，以便令牌过期时重新获取
                string refresh_token = resultDic["refresh_token"].ToString();
                HttpCookie cookie = new HttpCookie("Top");
                cookie["nick"] = CTCRM.Common.DES.Encrypt(nick);

                UserSellerGetResponse userRsp = null;
                UserSellerGetRequest req = null;
                try
                {
                    Sellers sellers = new Sellers();
                    sellers.Nick = nick;
                    try
                    {
                        ITopClient client = TBManager.GetClient();
                        req = new UserSellerGetRequest();
                        req.Fields = "user_id,type";
                        userRsp = client.Execute(req, sessionKey);
                    }
                    catch (Exception ex)
                    {
                        userRsp = null;
                    }
                    sellers.Seller_Creadit = 0;//short.Parse(userRsp.User.SellerCredit.Level.ToString());  
                    sellers.Seller_Id = userRsp.User==null? 0: userRsp.User.UserId;
                    sellers.shopType = userRsp.User == null ? "B" : userRsp.User.Type;
                    sellers.Created = DateTime.Now;
                    sellers.SessionKey = sessionKey;
                    sellers.Refresh_token = refresh_token;
                    sellers.SellerType = "pay";
                    cookie["SellerId"] = sellers.Seller_Id.ToString();

                    //获取卖家订购信息
                    ArticleUserSubscribe userSub = UserSubscribe.GetDeadLineDate("ts-1811102", nick);
                    if (userSub != null)
                    {
                        sellers.EndDate = userSub.Deadline.ToString();

                        #region 标准版一月送200条
                        if (userSub.ItemCode.Equals("ts-1811102-1"))
                        {
                            sellers.OrderVersion = "标准版一月送200条";
                        }
                        #endregion
                        #region 自动评价版
                        if (userSub.ItemCode.Equals("ts-1811102-2"))
                        {
                            sellers.OrderVersion = "自动评价版";
                        }
                        #endregion
                        #region 订单打印版
                        if (userSub.ItemCode.Equals("ts-1811102-3"))
                        {
                            sellers.OrderVersion = "订单打印版";
                        }
                        #endregion
                        #region 流量推广_6个广告位
                        if (userSub.ItemCode.Equals("ts-1811102-4"))
                        {
                            sellers.OrderVersion = "流量推广_6个广告位";
                        }
                        #endregion
                        #region 订购一年送3000条短信
                        if (userSub.ItemCode.Equals("ts-1811102-5"))
                        {
                            sellers.OrderVersion = "订购一年送3000条短信";
                        }
                        #endregion
                        cookie["Deadline"] = userSub.Deadline.ToString();//比如：2016-07-04 00:00:00
                        cookie["OrderVersion"] = CTCRM.Common.DES.Encrypt(sellers.OrderVersion);
                    }

                    SellersDAL objDal = new SellersDAL();
                    if (!SellersDAL.GetList(sellers))
                    {
                        sellers.CreatedDate = DateTime.Now;//记录卖家的第一次登陆系统时间
                        sellers.OrderDate = DateTime.Now.ToShortDateString();
                        objDal.Add(sellers);

                        if (!objDal.AddSellerRecords(sellers.Nick, sellers.OrderVersion, userSub.Deadline.ToString(), "新订"))
                        {
                            File.WriteAllText(@"D:\log\" + nick + "_订购.txt", "新订失败");
                        }

                    }
                    else
                    {
                        string sellerEndDate = SellersDAL.GetSellerEndDate(nick);
                        sellers.UpdateDate = DateTime.Now;//记录卖家最近一次登陆系统时间
                        File.WriteAllText(@"D:\log\" + nick + "_shijianOld.txt", sellerEndDate);
                        bool sss = SellersDAL.Update(sellers);
                        File.WriteAllText(@"D:\log\" + nick + "_更新.txt", sss.ToString());
                        //判断卖家是否续费软件
                        File.WriteAllText(@"D:\log\" + nick + "_shijianNew.txt", sellers.EndDate);
                        if (sellers.EndDate != sellerEndDate)
                        {
                            if (sellers.OrderVersion == "订购一年送3000条短信")
                            {
                                File.WriteAllText(@"D:\log\" + nick + "_dinggou.txt", sellers.OrderVersion);
                                MsgPackage obj = new MsgPackage();
                                obj.PackageName = "店铺管家短信套餐(淘宝)3000条";
                                obj.Type = "永久有效";
                                obj.SellerNick = nick;
                                obj.Price = 0;
                                obj.PerPrice = "0";
                                obj.Rank = "短信套餐(赠送)";
                                obj.OrderDate = DateTime.Now;
                                obj.PayStatus = true;
                                bool dingg =  MsgBLL.AddMsgPackage(obj);
                                File.WriteAllText(@"D:\log\" + nick + "_tianjia.txt", dingg.ToString());
                                DataTable dtDuanxin = MsgBLL.GetSellerMsgTrans(nick);
                                if (dtDuanxin != null && dtDuanxin.Rows.Count > 0)
                                {
                                    obj.MsgCanUseCount = 3000 + (dtDuanxin.Rows[0]["msgCanUseCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtDuanxin.Rows[0]["msgCanUseCount"]));
                                    obj.MsgTotalCount = 3000 + (dtDuanxin.Rows[0]["msgTotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtDuanxin.Rows[0]["msgTotalCount"]));
                                }
                                else
                                {
                                    obj.MsgCanUseCount = 3000;
                                    obj.MsgTotalCount = 3000;
                                }
                                obj.ServiceStatus = true;
                                obj.CanUseStartDate = DateTime.Now;

                                MsgBLL.UpdateMsgTrans(obj);
                            }
                            else
                            {
                                File.WriteAllText(@"D:\log\" + nick + "_dinggou.txt", sellers.OrderVersion);
                                MsgPackage obj = new MsgPackage();
                                obj.PackageName = "店铺管家短信套餐(淘宝)200条";
                                obj.Type = "永久有效";
                                obj.SellerNick = nick;
                                obj.Price = 0;
                                obj.PerPrice = "0";
                                obj.Rank = "短信套餐(赠送)";
                                obj.OrderDate = DateTime.Now;
                                obj.PayStatus = true;
                                bool dingg = MsgBLL.AddMsgPackage(obj);
                                File.WriteAllText(@"D:\log\" + nick + "_tianjia.txt", dingg.ToString());
                                DataTable dtDuanxin = MsgBLL.GetSellerMsgTrans(nick);
                                if (dtDuanxin != null && dtDuanxin.Rows.Count > 0)
                                {
                                    obj.MsgCanUseCount = 200 + (dtDuanxin.Rows[0]["msgCanUseCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtDuanxin.Rows[0]["msgCanUseCount"]));
                                    obj.MsgTotalCount = 200 + (dtDuanxin.Rows[0]["msgTotalCount"] == DBNull.Value ? 0 : Convert.ToInt32(dtDuanxin.Rows[0]["msgTotalCount"]));
                                }
                                else
                                {
                                    obj.MsgCanUseCount = 200;
                                    obj.MsgTotalCount = 200;
                                }
                                obj.ServiceStatus = true;
                                obj.CanUseStartDate = DateTime.Now;
                                
                                MsgBLL.UpdateMsgTrans(obj);
                            }

                            if (!objDal.AddSellerRecords(sellers.Nick, sellers.OrderVersion, userSub.Deadline.ToString(), "续订"))
                            {
                                File.WriteAllText(@"D:\log\" + nick + "_订购.txt", "续订失败");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    //ExceptionReporter.WriteLog(userRsp.ErrMsg, ex, ExceptionPostion.TopApi, ExceptionRank.urgency);
                }
                cookie["sess"] = sessionKey;
                cookie.Expires = DateTime.Now.AddDays(1d);
                context.Response.Cookies.Add(cookie);
                return "1";
            }
            else { //Code为空的情况下
                return "0";
            }
            #endregion 
        }

        //授权开通物流提醒
        public static  void OpenLogistics(string sellerNick)
        {
            string key = SellersBLL.GetSellerSessionKey(sellerNick);
            ITopClient client = TBManager.GetClient();
            TmcUserPermitRequest req = new TmcUserPermitRequest();
            //req.Topics = "taobao_trade_TradeCreate,taobao_refund_RefundCreate"; 不需要设置
            TmcUserPermitResponse rsp = client.Execute(req, key);
            //Console.WriteLine(rsp.Body);
        }
    }
}
