using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Net;
using System.Configuration;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Collections.Specialized;

namespace CTCRM.Common
{
   public class Mobile
   {
        #region 国都
       /// <summary>
        /// 此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
        /// </summary>
        /// <param name="newURL"></param>
        /// <returns>提交状态</returns>
        private string getUrl(string newURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(newURL);
            request.Method = "GET";
            request.ContentType = "text/html;charset=GBK";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("GBK"));
            string reqxml = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();
            return reqxml;
        }

       //----------------------------------------------------------国都短信接口------------------------------------------------------------------------>
        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="username">帐号 </param>
        /// <param name="password">密码</param>
        /// <param name="appendid">//客户要使用得 附加号码  可以为空</param>
        /// <param name="DesMobiles">接收手机号集合,多个号码之间请用（英文）逗号隔开。</param>
        /// <param name="content">短信内容</param>
        /// <param name="contentType"> 消息类型,取值有15和8。15：以普通短信形式下发,8：以长短信形式下发,默认为:8</param>
        /// <returns></returns>
        public static string sendMsg(List<string> DesMobiles, string content, string appendid)
        {
            string username = ConfigurationManager.AppSettings["userName"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwd"].ToString();
            string validTime = "";
            string sendTime = "";
            //string appendid = "";
            int contentType = 8;
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string DesMobile = "";                                          //发送的手机号串

            for (int i = 0; i < DesMobiles.Count; i++)
            {
                DesMobile = DesMobile + "," + DesMobiles[i].ToString();         //拼接手机号串格式：，手机号1，手机号2，手机号3，……
            }
            DesMobile = DesMobile.Substring(1, DesMobile.Length - 1);           //去掉手机号串前的第一个“，”
            string url = "http://221.179.180.158:9007/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        public static string sendMsg(List<string> DesMobiles, string content)
        {
            string username = ConfigurationManager.AppSettings["userName"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwd"].ToString();
            string validTime = "";
            string sendTime = "";
            string appendid = "";
            int contentType = 8;
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string DesMobile = "";                                          //发送的手机号串

            for (int i = 0; i < DesMobiles.Count; i++)
            {
                DesMobile = DesMobile + "," + DesMobiles[i].ToString();         //拼接手机号串格式：，手机号1，手机号2，手机号3，……
            }
            DesMobile = DesMobile.Substring(1, DesMobile.Length - 1);           //去掉手机号串前的第一个“，”
            string url = "http://221.179.180.158:9007/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        public static string sendMsgReminder(List<string> DesMobiles, string content, string appendid)
        {
            string username = ConfigurationManager.AppSettings["userName2"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwd2"].ToString();
            string validTime = "";
            string sendTime = "";
            //string appendid = "";
            int contentType = 8;
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string DesMobile = "";                                          //发送的手机号串

            for (int i = 0; i < DesMobiles.Count; i++)
            {
                DesMobile = DesMobile + "," + DesMobiles[i].ToString();         //拼接手机号串格式：，手机号1，手机号2，手机号3，……
            }
            DesMobile = DesMobile.Substring(1, DesMobile.Length - 1);           //去掉手机号串前的第一个“，”
            string url = "http://221.179.180.158:9007/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            //string url = "http://218.241.67.213:9001/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        public static string sendMsgReminder(List<string> DesMobiles, string content)
        {
            string username = ConfigurationManager.AppSettings["userName2"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwd2"].ToString();
            string validTime = "";
            string sendTime = "";
            string appendid = "";
            int contentType = 8;
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string DesMobile = "";                                          //发送的手机号串

            for (int i = 0; i < DesMobiles.Count; i++)
            {
                DesMobile = DesMobile + "," + DesMobiles[i].ToString();         //拼接手机号串格式：，手机号1，手机号2，手机号3，……
            }
            DesMobile = DesMobile.Substring(1, DesMobile.Length - 1);           //去掉手机号串前的第一个“，”
            string url = "http://221.179.180.158:9007/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            //string url = "http://218.241.67.213:9001/QxtSms/QxtFirewall?OperID=" + username + "&OperPass=" + password + "&SendTime=" + sendTime + "&ValidTime=" + validTime + "&AppendID=" + appendid + "&DesMobile=" + DesMobile + "&Content=" + contentStr + "&ContentType=" + contentType;
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        //国都短信余额查询
        public static string GetAcountMsgCount()
        {
            Mobile qxt = new Mobile();
            string username = ConfigurationManager.AppSettings["userName"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwd"].ToString();
            string url = "http://221.179.180.158:8081/QxtSms_surplus/surplus?OperID=" + username + "&OperPass=" + password;
            //string url = "http://218.241.67.213:9001/QxtSms/surplus?OperID=" + username + "&OperPass=" + password;
            string returnStr = qxt.getUrl(url);//此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
       //物流提醒账户
        public static string GetAcountMsgCount2()
        {
            Mobile qxt = new Mobile();
            string username = ConfigurationManager.AppSettings["userName2"].ToString();
            string password = ConfigurationManager.AppSettings["pwd2"].ToString();
            string url = "http://221.179.180.158:8081/QxtSms_surplus/surplus?OperID=" + username + "&OperPass=" + password;
            string returnStr = qxt.getUrl(url);
            return returnStr;
        }
       #endregion

        #region 悦信
        public static string sendMsgByYueXin(string DesMobiles, string content)
        {
            string username = ConfigurationManager.AppSettings["userNameYX"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwdYX"].ToString();
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string url = "http://mt.549k.com/send.do?Account=" + username + "&Password=" + password + "&Mobile=" + DesMobiles + "&Content=" + content + "&Exno=0";
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        //
        public static string GetAcountMsgCountByYueXin()
        {
            Mobile qxt = new Mobile();
            string username = ConfigurationManager.AppSettings["userNameYX"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwdYX"].ToString();
            string url = "http://mt.549k.com/getUser.do?Account=" + username + "&Password=" + password;
            string returnStr = qxt.getUrl(url);//此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }
        #endregion

        #region 联信众达

       /// <summary>
        /// 联信众达
       /// </summary>
       /// <param name="DesMobiles"></param>
       /// <param name="content"></param>
       /// <returns></returns>
        public static string sendMsgByLXZD(string DesMobiles, string content)
        {
            string username = ConfigurationManager.AppSettings["userNameDZ"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwdDZ"].ToString();
            string sendTime = "";
            string appendid = "";
            List<string> mobiles = new List<string>();
            Mobile qxt = new Mobile();
            byte[] gbk = Encoding.GetEncoding("GBK").GetBytes(content);     //对内容进行GBK编码
            string contentStr = "";
            foreach (byte b in gbk)
            {
                contentStr += "%" + String.Format("{0:X2}", b);
            }
            string url = "http://203.195.182.240:7890/SendMT/SendMessage?UserName=" + username + "&UserPass=" + password + "&SendTime=" + sendTime + "&Subid=" + appendid + "&Mobile=" + DesMobiles + "&Content=" + contentStr;
            string returnStr = qxt.getUrl(url);                             //此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }

       /// <summary>
        /// 联信众达
       /// </summary>
       /// <returns></returns>
        public static string GetAcountMsgLXZDCount()
        {
            Mobile qxt = new Mobile();
            string username = ConfigurationManager.AppSettings["userNameDZ"].ToString(); ;
            string password = ConfigurationManager.AppSettings["pwdDZ"].ToString();
            string url = "http://203.195.182.240:7890/SendMT/SendMessage?UserName=" + username + "&UserPass=" + password;
            //string url = "http://218.241.67.213:9001/QxtSms/surplus?OperID=" + username + "&OperPass=" + password;
            string returnStr = qxt.getUrl(url);//此get方法返回一个xml字符串，用户可以自己解析xml读取里面的参数。
            return returnStr;
        }

        #endregion

        #region 北京聚信分享通讯科技有限公司

        public static string GetCountSYXuNi()
        {
            string username = ConfigurationManager.AppSettings["JuXinUserName"].ToString();//20160622 c yao
            string password = ConfigurationManager.AppSettings["JuXinUserPwd"].ToString();//20160622 c yao
            string postData = string.Format("username={0}&pwd={1}", username, password);//20160622 u yao
            postData = "http://api.app2e.com/getBalance.api.php?" + postData;
            return Get(postData, "GBK");
        }
        
        public static string PostDataToMyServerXuNi(string mobile, string content, string longnum)
        {
            
            string encode = HttpUtility.UrlEncode(content, Encoding.Default);
            string postData = string.Format("username={0}&pwd={1}&p={2}&msg={3}", "xby3", "c7373d787276d6ed944b5386bde8224b", mobile, encode);
            postData = "http://api.app2e.com/smsSend.api.php?" + postData; 
            return Get(postData, "GBK");
        }

        /// <summary>
        /// 提醒
        /// </summary>
        /// <param name="mobile"></param>
        /// <param name="content"></param>
        /// <param name="longnum"></param>
        /// <returns></returns>
        public static string PostDataToMyServerTX(string mobile, string content, string longnum)
        {
            string encode = HttpUtility.UrlEncode(content, Encoding.Default);
            string postData = string.Format("username={0}&pwd={1}&p={2}&msg={3}", "xby2", "e65e873c11c8791855221c193e97367d", mobile, encode);
            postData = "http://api.app2e.com/smsSend.api.php?" + postData;
            return Get(postData, "GBK");
        }
        public static string GetCountTX()
        {
            string postData = string.Format("username={0}&pwd={1}", "xby2", "e65e873c11c8791855221c193e97367d");
            postData = "http://api.app2e.com/getBalance.api.php?" + postData;
            return Get(postData, "GBK");
        }

        public static string GetCountSY()
        {
            string postData = string.Format("username={0}&pwd={1}", "xby", "96c1bea2a2db86c9c934af26b123a928");
            postData = "http://api.app2e.com/getBalance.api.php?" + postData;
            return Get(postData, "GBK");
        }
        public static string PostDataToMyServer(string mobile, string content, string longnum)
        {
            string userName =ConfigurationManager.AppSettings["JuXinUserName"].ToString();
            string userPwd = ConfigurationManager.AppSettings["JuXinUserPwd"].ToString();

            string encode = HttpUtility.UrlEncode(content, Encoding.Default);
            string postData = string.Format("username={0}&pwd={1}&p={2}&msg={3}", userName, userPwd, mobile, encode);
            postData = "http://api.app2e.com/smsSend.api.php?" + postData;
            return Get(postData, "GBK");
        }

        /// <summary>
        /// 电信联通post方法
        /// 2016-06-20 create yao
        /// </summary>
        /// <param name="url">接口地址</param>
        /// <param name="postData">参数</param>
        /// <returns>发送结果status 100表示成功</returns>
        public static string PostDataToMyServer(string mobile, string content)
        {
            string url = "http://api.app2e.com/smsBigSend.api.php";
            string userName = ConfigurationManager.AppSettings["JuXinUserName"].ToString();
            string userPwd = ConfigurationManager.AppSettings["JuXinUserPwd"].ToString();
            string postData = string.Format("pwd={0}&username={1}&p={2}&msg={3}", userPwd, userName, mobile, content);
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=GBK";
            string urlText = postData;
            byte[] bs = Encoding.GetEncoding("GBK").GetBytes(urlText);
            httpWebRequest.ContentLength = bs.Length;
            Stream newStream = httpWebRequest.GetRequestStream();//把传递的值写到流中   
            newStream.Write(bs, 0, bs.Length);
            newStream.Close();//必须要关闭 请求
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("gbk"));
            string retValue = sr.ReadToEnd();
            //MessageBox.Show(retValue);
            sr.Close();
            httpWebResponse.Close();
            return retValue;
        }

       public static  string Post(string url, string postdata, string encoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Accept = "*/*";
            request.AllowAutoRedirect = false;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.0; .NET CLR 1.0.3705)";
            request.ContentType = "text/html";

            byte[] data = System.Text.Encoding.GetEncoding(encoding).GetBytes(postdata);
            request.AllowAutoRedirect = true;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding(encoding));
            string content = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return content;
        }
      public static string Get(string url, string encoding)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.Accept = "*/*";
            request.AllowAutoRedirect = false;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; " + "Windows NT 5.0; .NET CLR 1.0.3705)";
            request.ContentType = "text/html";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding(encoding));
            string content = sr.ReadToEnd();
            sr.Close();
            response.Close();
            return content;
        }
        #endregion

        #region 北京空间畅想信息技术有限责任公司
      /// <summary>
      /// 短信发送静态函数
      /// </summary>
      /// <param name="ua">账户</param>
      /// <param name="pw">密码</param>
      /// <param name="mobiles">手机号，多个手机号用英文逗号分隔</param>
      /// <param name="message">短信内容</param>
      /// <returns></returns>
      public static string sendMt(string mobiles, string message)
      {
          string url = "http://42.121.122.61:18002/send.do?ua={0}&pw={1}&mb={2}&ms={3}"; // 下行接口
          url = string.Format(url, "cdct", "637424", mobiles, message);
          return send(url);
      }
      public static string GetChangXiangBalance()
      {
          string url = "http://42.121.122.61:18005/balance.do?ua={0}&pw={1}"; // 下行接口
          url = string.Format(url, "cdct", "637424");
          return send(url);
      }

      private static string send(string url, string method = "GET", string encode = "UTF-8")
      {
          string result = string.Empty;
          string querystring = string.Empty;
          if (url.IndexOf("?") != -1)
          {
              string[] reqinfo = url.Split('?');
              url = reqinfo[0];
              querystring = reqinfo[1];
              querystring = UrlEncode(querystring, Encoding.GetEncoding(encode));
          }
          HttpWebRequest request = null;
          try
          {
              if (method == "GET")
              {
                  request = (HttpWebRequest)WebRequest.Create(url + (querystring == string.Empty ? "" : "?" + querystring));
              }
              else
              {
                  byte[] data = Encoding.GetEncoding(encode).GetBytes(querystring);
                  request = (HttpWebRequest)WebRequest.Create(url);
                  request.Method = "POST";
                  request.Accept = "text/html,application/xhtml+xml,*/*";
                  request.ContentType = "application/x-www-form-urlencoded";
                  request.ContentLength = data.Length;
                  request.GetRequestStream().Write(data, 0, data.Length);
              }
              HttpWebResponse response = (HttpWebResponse)request.GetResponse();
              using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encode)))
              {
                  result = reader.ReadToEnd();
              }
          }
          catch (Exception ex)
          {
              result = ex.Message;
          }
          return result;
      }

      private static string UrlEncode(string queryString, Encoding e = null)
      {
          if (e == null)
          {
              e = Encoding.UTF8;
          }
          StringBuilder sb = new StringBuilder();
          string[] nvc = queryString.Split('&');
          for (int i = 0, j = nvc.Length; i < j; i++)
          {
              string[] nv = nvc[i].Split('=');
              sb.Append(string.Format("&{0}={1}", HttpUtility.UrlEncode(nv[0], e), HttpUtility.UrlEncode(nv.Length > 1 ? nv[1] : string.Empty, e)));
          }
          return sb.ToString().Substring(1);
      }
      private static NameValueCollection UrlEncode(NameValueCollection collection, Encoding e)
      {
          if (e == null)
          {
              e = Encoding.UTF8;
          }
          NameValueCollection t = new NameValueCollection(collection.Count);
          foreach (string key in collection)
          {
              t.Add(HttpUtility.UrlEncode(key, e), HttpUtility.UrlEncode(collection[key], e));
          }
          return t;
      }

      #endregion

        #region 领先


        #endregion

        #region 上海客通

      #region 移动接口
      /// <summary>
       /// 移动接口
       /// </summary>
       /// <param name="mobile"></param>
       /// <param name="content"></param>
       /// <returns></returns>
      public static string SendMsgKeTongYD(string mobile, string content)
      {
          string strURL = "http://api.ktsms.cn/sendSmsApi?username=chengtuanyd&password=3ddOGAnC&mobile=" + mobile + "&content=" + content + "&dstime=";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;         
      }
       /// <summary>
       /// 移动接口
       /// </summary>
       /// <returns></returns>
      public static string GetKeTongYDCount()
      {
          string strURL = "http://api.ktsms.cn/smsBalance?username=chengtuanyd&password=3ddOGAnC&mobile";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;     
      }
      #endregion

      #region 电信联通接口

      /// <summary>
      /// 电信联通接口
      /// </summary>
      /// <param name="mobile"></param>
      /// <param name="content"></param>
      /// <returns></returns>
      public static string SendMsgKeTongDX(string mobile, string content)
      {
          string strURL = "http://api.ktsms.cn/sendSmsApi?username=chengtuanlt&password=QtqfdV9d&mobile=" + mobile + "&content=" + content + "&dstime=";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;
      }
      /// <summary>
      /// 电信联通接口
      /// </summary>
      /// <returns></returns>
      public static string GetKeTongDXCount()
      {
          string strURL = "http://api.ktsms.cn/smsBalance?username=chengtuanlt&password=QtqfdV9d&mobile";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;
      }

      #endregion

      #endregion

        #region 湖北汉禹软通

      public static string SendMsgHuBeiYD(string mobile, string content)
      {
          string userName = ConfigurationManager.AppSettings["HuBeiUserName"].ToString();
          string pwd = ConfigurationManager.AppSettings["HuBeiUserPwd"].ToString();
          string strURL = "http://218.204.70.58:28081/CmppWebServiceJax/sendsms.jsp?spid=" + userName + "&password=" + pwd + "&mobs=" + mobile + "&nr=" + content + "&kzm=";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;
      }

       /// <summary>
      /// 湖北汉禹软通移动短信接口POST发送方法
       /// 2016-06-20 Create yao
       /// </summary>
       /// <param name="mobile">需要发送短信的移动号码</param>
       /// <param name="content">短信的发送内容，格式为【签名】短信内容</param>
       /// <returns>发送短信结果,0表示成功</returns>
      public static string SendMsgHubeiYDPost(string mobile, string content)
      {
          //读取配置文件
          string userName = ConfigurationManager.AppSettings["HuBeiUserName"].ToString();
          string pwd = ConfigurationManager.AppSettings["HuBeiUserPwd"].ToString();
          //营销帐号,签名需要报备，发送内容要追加‘退订回复T’
          //string userName = "177357";
          //string pwd = "7563215";
          //行业帐号，签名不需要报备，可以随意填写
          //string userName = "177356";
          //string pwd = "2135878";
          //HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://218.204.70.58:28080/CmppWebServiceJax/sendsms.jsp");
          HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://218.204.70.58:28083/CmppWebServiceJax/sendsms.jsp");
          httpWebRequest.Method = "POST";
          httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=GBK";
          string urlText = "spid="+ userName +"&password="+ pwd+"&nr="+ content +"&mobs="+ mobile +"&kzm=";
          byte[] bs = Encoding.GetEncoding("GBK").GetBytes(urlText);
          httpWebRequest.ContentLength = bs.Length;
          Stream newStream = httpWebRequest.GetRequestStream();//把传递的值写到流中   
          newStream.Write(bs, 0, bs.Length);
          newStream.Close();//必须要关闭 请求
          HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
          StreamReader sr = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("gbk"));
          string retValue = sr.ReadToEnd();
          sr.Close();
          httpWebResponse.Close();
          return retValue;
      }
      #endregion

        #region 上海助通

      #region 移动接口
      /// <summary>
      /// 移动接口
      /// </summary>
      /// <param name="mobile"></param>
      /// <param name="content"></param>
      /// <returns></returns>
      public static string SendMsgZhuTongYD(string mobile, string content)
      {
          string strURL = "http://www.ztsms.cn:8800/sendXSms.do?username=chengtuan&password=Chengtuan88&mobile=" + mobile + "&content=" + content + "&dstime=&productid=411623&xh=";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;
      }
      /// <summary>
      /// 移动接口
      /// </summary>
      /// <returns></returns>
      public static string GetZhuTongYDCount()
      {
          string strURL = "http://www.ztsms.cn:8800/balance.do?username=chengtuan&password=Chengtuan88&productid=411623";
          WebRequest wRequest = WebRequest.Create(strURL);
          WebResponse wResponse = wRequest.GetResponse();
          Stream stream = wResponse.GetResponseStream();
          StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
          string r = reader.ReadToEnd();
          wResponse.Close();
          return r;
      }
      #endregion

      #endregion

       #region 成都罗九方科技（移动）20160624 yao c
       /// <summary>
       /// 成都罗九方科技发送短信接口
       /// </summary>
       /// <param name="mobile">发送号码,多个号码时以逗号隔开</param>
       /// <param name="content">发送内容</param>
       /// <param name="userName">短信接口acc</param>
       /// <param name="pwd">短信接口pwd</param>
       /// <returns>发送成功返回100</returns>
       public static string sendMsgJiuFang(string mobile,string content,string userName,string pwd)
       {
           //string userName = ConfigurationManager.AppSettings["JiuFangUserName"].ToString();
           //string pwd = ConfigurationManager.AppSettings["JiuFangUserPwd"].ToString();
           string encode = HttpUtility.UrlEncode(content, Encoding.Default);
           string strURL = "http://202.85.221.72:9885/c123/sendsms?uid=" + userName + "&pwd=" + pwd + "&mobile=" + mobile + "&content=" + encode;
           WebRequest wRequest = WebRequest.Create(strURL);
           WebResponse wResponse = wRequest.GetResponse();
           Stream stream = wResponse.GetResponseStream();
           StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
           string r = reader.ReadToEnd();
           wResponse.Close();
           return r;
       }

       /// <summary>
       /// 获取成都罗九方科技短信账户余额
       /// </summary>
       /// <param name="userName">短信接口acc</param>
       /// <param name="pwd">短信接口pwd</param>
       /// <returns>发送成功返回100,格式状态码{&}账户余额</returns>
       public static string getBalanceJiuFang( string userName, string pwd)
       {
           string strURL = "http://202.85.221.72:9885/c123/querymoney?uid=" + userName + "&pwd=" + pwd;
           WebRequest wRequest = WebRequest.Create(strURL);
           WebResponse wResponse = wRequest.GetResponse();
           Stream stream = wResponse.GetResponseStream();
           StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
           string r = reader.ReadToEnd();
           wResponse.Close();
           return r;
       }

       /// <summary>
       /// 获取成都罗九方科技短信发送状态报告
       /// </summary>
       /// <param name="userName">短信接口acc</param>
       /// <param name="pwd">短信接口pwd</param>
       /// <returns>状态码100表示成功，消息状态0成功，1失败。状态码{&}任务ID||手机号||消息状态||错误码{&},示例：100{&}10000||13912345678||0||DELIVRD</returns>
       public static string getPortJiuFang(string userName, string pwd)
       {
           string strURL = "http://202.85.221.72:9885/c123/statusreport?uid=" + userName + "&pwd=" + pwd;
           WebRequest wRequest = WebRequest.Create(strURL);
           WebResponse wResponse = wRequest.GetResponse();
           Stream stream = wResponse.GetResponseStream();
           StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
           string r = reader.ReadToEnd();
           wResponse.Close();
           return r;
       }

       /// <summary>
       /// 获取成都罗九方科技回复状态报告
       /// </summary>
       /// <param name="userName">短信接口acc</param>
       /// <param name="pwd">短信接口pwd</param>
       /// <returns>状态码100表示成功，格式为状态码{&}回复号码||回复内容||子号 {&}回复号码||回复内容||子号</returns>
       public static string getReplyJiuFang(string userName, string pwd)
       {
           string strURL = "http://202.85.221.72:9885/c123/recvsms?uid=" + userName + "&pwd=" + pwd;
           WebRequest wRequest = WebRequest.Create(strURL);
           WebResponse wResponse = wRequest.GetResponse();
           Stream stream = wResponse.GetResponseStream();
           StreamReader reader = new StreamReader(stream, System.Text.Encoding.Default);
           string r = reader.ReadToEnd();
           wResponse.Close();
           return r;
       }
       #endregion

       //获取状态报告
       string getReports(String spid, String password) 
       {
           string postData = string.Format("spid ={0}&password ={1}&p={2}&msg={3}", spid, password);
           postData = "http://ip:port/CmppWebServiceJax/getreport.jsp" + postData;
           return Get(postData, "GBK").ToString() ;

       }
   }
}
