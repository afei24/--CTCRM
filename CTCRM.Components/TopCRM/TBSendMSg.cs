using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.Components.TopCRM
{
    public class TBSendMSg
    {
        /// <summary>
        /// 调用淘宝大于接口
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="nick"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        //public static string SendMsg(string phone, string nick, string msg)
        //{
        //    try
        //    {
        //        ITopClient client = TBManager.GetClient();
        //        AlibabaAliqinTaSmsNumSendRequest req = new AlibabaAliqinTaSmsNumSendRequest();
        //        req.Extend = "123456";
        //        req.SmsType = "normal";
        //        req.SmsFreeSignName = "上海重岛";
        //        req.SmsParam = "{\"conter\":\"" + msg + "\"}";
        //        req.RecNum = phone;
        //        req.SmsTemplateCode = "SMS_39250111";

        //        AlibabaAliqinTaSmsNumSendResponse rsp = client.Execute(req);
        //        File.AppendAllText(@"D:\log\SendMsg.txt", rsp.ErrCode + rsp.Body, Encoding.Default);
        //        return rsp.ErrCode;
        //    }
        //    catch (Exception e)
        //    {
        //        File.AppendAllText(@"D:\log\SendMsg.txt", e.Message, Encoding.Default);
        //        return "1";
        //    }
        //}
        public static string SendMsg(string phone, string nick, string msg)
        {
            try
            {
                ITopClient client = CTCRM.Components.TopCRM.TBManager.GetClient();
                AlibabaAliqinTaSmsNumSendRequest req = new AlibabaAliqinTaSmsNumSendRequest();
                req.Extend = "123456";
                req.SmsType = "normal";
                req.SmsFreeSignName = nick;
                req.SmsParam = "{\"conter\":\"" + msg + "\"}";
                req.RecNum = phone;
                req.SmsTemplateCode = "SMS_38420043";

                AlibabaAliqinTaSmsNumSendResponse rsp = client.Execute(req);
                return rsp.ErrCode;
            }
            catch (Exception e)
            {
                return "1";
            }

        }
    }
}
