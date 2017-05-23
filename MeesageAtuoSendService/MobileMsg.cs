using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Configuration;
using System.Web;
using CTCRM.Common;


namespace MeesageAtuoSendService
{
   public class MobileMsg
    {

       //移动
       //public static string PostDataToMyServerTX(string mobile, string content, string longnum)
       //{
       //    string encode = HttpUtility.UrlEncode(content, Encoding.Default);
       //    string postData = string.Format("username={0}&pwd={1}&p={2}&msg={3}", "xby2", "e65e873c11c8791855221c193e97367d", mobile, encode);
       //    postData = "http://api.app2e.com/smsSend.api.php?" + postData;
       //    return Get(postData, "GBK");
       //}

       /// <summary>
       /// 发送移动短信
       /// 2016-06-20 crete yao
       /// </summary>
       /// <param name="mobile">要发送短信的移动号码</param>
       /// <param name="content">发送的内容</param>
       /// <param name="longnum"></param>
       /// <returns>发送结果0表示发送成功</returns>
       public static string PostDataToMyServerTX(string mobile, string content, string longnum)
       {
           return SendMsgHubeiYDPost(mobile,content);
           //return Mobile.sendMsgJiuFang(mobile, content, "100057", "c9bf7c4cb27c5527c4d757765514498e");
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
           string userName =  ConfigurationManager.AppSettings["HuBeiUserName"].ToString();
           userName = string.IsNullOrEmpty(userName) ? "320078" : userName;
           string pwd = ConfigurationManager.AppSettings["HuBeiUserPwd"].ToString();
           pwd = string.IsNullOrEmpty(pwd) ? "6c21phjez" : pwd;
           string url = ConfigurationManager.AppSettings["HuBeiMsgUrl"].ToString();
           url = string.IsNullOrEmpty(url) ? "http://218.204.70.58:28083/CmppWebServiceJax/sendsms.jsp" : url;
           HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
           httpWebRequest.Method = "POST";
           httpWebRequest.ContentType = "application/x-www-form-urlencoded;charset=GBK";
           string urlText = "spid=" + userName + "&password=" + pwd + "&nr=" + content + "&mobs=" + mobile + "&kzm=";
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

       //电信联通
       public static string PostDataToMyServer(string mobile, string content, string longnum)
       {
           //string encode = HttpUtility.UrlEncode(content, Encoding.Default);
           //string postData = string.Format("username={0}&pwd={1}&p={2}&msg={3}", "liantong139", "74cf4477ab50804e17694e704f43c262", mobile, encode);
           //postData = "http://api.app2e.com/smsSend.api.php?" + postData;
           //return Get(postData, "GBK");
           //-----2016-06-20 update yao start
           string encode = content;
           string postData = string.Format("pwd={0}&username={1}&p={2}&msg={3}", "74cf4477ab50804e17694e704f43c262", "liantong139", mobile, encode);
           string url = "http://api.app2e.com/smsBigSend.api.php";
           return Post(url, postData);
           //-----2016-06-20 update yao end
       }

       /// <summary>
       /// 电信联通post方法
       /// 2016-06-20 create yao
       /// </summary>
       /// <param name="url">接口地址</param>
       /// <param name="postData">参数</param>
       /// <returns>发送结果status 100表示成功</returns>
       public static string Post(string url, string postData)
       {
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
    }
}
