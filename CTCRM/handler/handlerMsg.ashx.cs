﻿using CTCRM.Common;
using CTCRM.Components;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Collections;
using Top.Api.Util;
using System.Data;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using TOPCRM;
using System.Text;
using CTCRM.Components.TopCRM;

namespace CTCRM.handler
{
    /// <summary>
    /// handlerMsg 的摘要说明
    /// </summary>
    public class handlerMsg : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string sigNames = SellersBLL.GetSignName(Users.Nick);
            string sigName ="【"+ SellersBLL.GetSignName(Users.Nick)+"】";
            //string sigName = "【澄腾科技01】"; 
            HttpFileCollection files = context.Request.Files;
            if (files.Count > 0)
            {
                HttpPostedFile file = files[0];
                string[] noWenmings = new string[] { "傻逼","草","靠","黄片","尼玛","你妈","屌丝","逗比","你妹","装逼","妈蛋","逼格","撕逼"
                ,"滚粗","蛋疼","婊砸","跪舔","婊","碧池","土肥圆","矮穷挫"};
                string content = context.Request.QueryString["msgContent"];
                for (int s = 0; s < noWenmings.Length - 1; s++)
                {
                    if (content.IndexOf(noWenmings[s]) > 0)
                    {
                        context.Response.Write("6");
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
                List<string> phones = new List<string>() ;
                if (!String.IsNullOrEmpty(file.FileName))
                {
                    #region 文件上传
                    //文件扩展名
                    string fileExtend = "";
                    string filePath = "";
                    //文件大小
                    int fileSize = 0;
                    filePath = file.FileName.ToLower().Trim();
                    //取得上传前的文件(存在于客户端)的文件或文件夹的名称
                    string[] names = filePath.Split('\\');
                    //取得文件名
                    string name = names[names.Length - 1];
                    //获得服务器端的根目录
                    string serverPath = context.Server.MapPath("~/SellerReport");
                    //判断是否有该目录
                    if (!Directory.Exists(serverPath))
                    {
                        Directory.CreateDirectory(serverPath);
                    }
                    filePath = serverPath + "\\" + name;
                    var fileImprtPath = serverPath + "\\";
                    //如果存在,删除文件
                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                    }
                    // 上传文件
                    file.SaveAs(filePath);
                    //得到扩展名
                    fileExtend = filePath.Substring(filePath.LastIndexOf("."));
                    if (fileExtend != ".txt" && fileExtend != ".csv")
                    {
                        context.Response.Write("1");
                        context.Response.End();
                    }
                    

                    #endregion
                    // 获得给卖家设置的发送百分之几
                    int i = 100;
                    DataTable dtPrecent = MsgBLL.GetSellerMsgSendPrecent(Users.Nick);
                    if (dtPrecent == null || dtPrecent.Rows.Count == 0 || dtPrecent.Rows[0]["sendPrecent"] == DBNull.Value)
                    {
                        i = 100;
                    }
                    else
                    {
                        try
                        {
                            i = Convert.ToInt32(dtPrecent.Rows[0]["sendPrecent"]);
                        }
                        catch (Exception es)
                        {
                            i = 100;
                        }
                    }
                    //短信发送开始记录
                    msgSendingBLL.update(Users.Nick,1);

                    //CSV格式
                    if (fileExtend == ".csv")
                    {
                        System.IO.FileInfo f = new FileInfo(filePath);
                        CSVHelper obj = new CSVHelper(serverPath + "\\", name);
                        DataTable tb = obj.Read();
                        //将订单交易信息写入到DB，同时更新买家表信息
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            float ftemp = (float)i / 100;
                            //可以发送的短信条数
                            int cansendCount = Convert.ToInt32(tb.Rows.Count * ftemp);
                            int sendedCount = 1;
                            for (int t = 0; t < tb.Rows.Count; t++)
                            {
                                string cellPhone = tb.Rows[t]["联系手机"].ToString();
                                if (string.IsNullOrEmpty(cellPhone) == true) { continue; }
                                    string num_char = cellPhone.Substring(0, 1);
                                    if (Utility.IsINT(num_char) == false)
                                    {
                                        cellPhone = cellPhone.Substring(1, cellPhone.Length - 1);
                                    }
                                    if (phones.Contains(cellPhone) || cellPhone == "")
                                    {
                                        continue;
                                    }
                                    cellPhone = cellPhone.Replace("\'", "");
                                    phones.Add(cellPhone);
                                    try
                                    {
                                        //判断手机
                                        if (Utility.IsCellPhone(cellPhone.Replace("\'", "")))
                                        {
                                            //if(true)
                                            if (MsgBLL.CheckSellerMsgStatus())
                                            {
                                                MsgSendHis objHis = new MsgSendHis();
                                                objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellPhone;//手机号码 2016 yao c
                                                objHis.SellerNick = Users.Nick;
                                                //objHis.SellerNick = "澄腾科技"; 
                                                objHis.Buyer_nick = "*****";
                                                objHis.CellPhone = cellPhone;
                                                objHis.SendDate = DateTime.Now;
                                                objHis.SendType = "手工发送";
                                                objHis.SendStatus = "0";
                                                objHis.Count = "1";
                                                //objHis.MsgContent = "【" + SellersBLL.GetSignName(Users.Nick) + "】" + txtContent.Text.Trim();// +"退订回T";
                                                objHis.MsgContent = sigName + content.Trim() + "退订回N";
                                                if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                                {
                                                    objHis.HelpSellerNick = "电信联通";
                                                }
                                                else
                                                {
                                                    objHis.HelpSellerNick = "移动";
                                                }
                                                //if (true) test
                                                if (SmartBLL.AddMsgSendHis(objHis))
                                                {
                                                    try
                                                    {
                                                        objHis.MsgContent = objHis.MsgContent.Replace(" ", "");
                                                        if (objHis.MsgContent.Length <= 70)
                                                        {
                                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                                        }
                                                        else if (objHis.MsgContent.Length > 70 && objHis.MsgContent.Length <= 134)
                                                        {
                                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                                        }
                                                        else if (objHis.MsgContent.Length > 134 && objHis.MsgContent.Length <= 195)
                                                        {
                                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                                        }
                                                        else if (objHis.MsgContent.Length > 195 && objHis.MsgContent.Length <= 260)
                                                        {
                                                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                                        }

                                                        //File.AppendAllText(@"D:\log\1.txt", "sendedCount:" + t + " cansendCount:" + cansendCount + "\n");
                                                        if (t >= cansendCount)
                                                        {
                                                            SmartBLL.UpdateSendStatus("99", objHis.TransNumber);
                                                        }
                                                        else
                                                        {
                                                            string sendStatus = TBSendMSg.SendMsg(cellPhone, sigNames, objHis.MsgContent.Replace(sigName, ""));
                                                            //SendMsg(cellPhone, sigName, objHis.MsgContent.Trim()); 
                                                            if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                                            {

                                                                //string sendStatus = Mobile.PostDataToMyServer(cellPhone, objHis.MsgContent.Trim());//20160626 yao c
                                                                //IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                                                SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                                            }
                                                            else
                                                            {
                                                                //string sendStatus = Mobile.SendMsgHubeiYDPost(cellPhone, objHis.MsgContent);//\r\n\r\n\r\n\r\n0
                                                                //sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                                                if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                                                SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                                            }


                                                        }

                                                        

                                                    }
                                                    catch (Exception ex)
                                                    {
                                                        continue;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                context.Response.Write("3");//余额不足                                       
                                                //context.Response.End();//使用 Response.End方法，将出现 ThreadAbortException 异常。
                                                HttpContext.Current.ApplicationInstance.CompleteRequest();
                                                return;
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        continue;
                                    }
                                    sendedCount++;

                                }
                            

                        }
                        //短信发送成功记录
                        msgSendingBLL.update(Users.Nick, 2, phones.Count);
                        context.Response.Write("2");
                        //context.Response.End();
                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                    }
                    else if (fileExtend == ".txt")
                    {
                        using (StreamReader Sr = new StreamReader(filePath, true))
                        {
                            /*读取到的每行内容*/
                            string cellPhone1 = String.Empty;
                            while (Sr.EndOfStream != true)
                            {
                                cellPhone1 = Sr.ReadLine().Trim();
                                if (phones.Contains(cellPhone1) || cellPhone1 == "")
                                {
                                    continue;
                                }
                                cellPhone1 = cellPhone1.Replace("\'", "");
                                phones.Add(cellPhone1);
                            }
                            float ftemp = (float)i / 100;
                            //可以发送的短信条数
                            int cansendCount = Convert.ToInt32(phones .Count* ftemp);
                            int sendedCount = 0;
                            #region 发短信
                            foreach (string cellPhone in phones)
                            {

                                int j = 0;
                                try
                                {
                                    //判断手机
                                    if (Utility.IsCellPhone(cellPhone))
                                    {
                                        if (MsgBLL.CheckSellerMsgStatus())
                                        {
                                            MsgSendHis objHis = new MsgSendHis();
                                            objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellPhone;//手机号码 2016 yao c
                                            objHis.SellerNick = Users.Nick;
                                            //objHis.SellerNick = "澄腾科技"; 
                                            objHis.Buyer_nick = "*****";
                                            objHis.CellPhone = cellPhone;
                                            objHis.SendDate = DateTime.Now;
                                            objHis.SendType = "手工发送";
                                            objHis.SendStatus = "0";
                                            objHis.Count = "1";

                                            objHis.MsgContent = sigName + content.Trim() + " 退订回N";
                                            if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                            {
                                                objHis.HelpSellerNick = "电信联通";
                                            }
                                            else
                                            {
                                                objHis.HelpSellerNick = "移动";
                                            }
                                            //if (true) test
                                            if (SmartBLL.AddMsgSendHis(objHis))
                                            {
                                                try
                                                {
                                                    objHis.MsgContent = objHis.MsgContent.Replace(" ", "");
                                                    if (objHis.MsgContent.Length <= 70)
                                                    {
                                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                                    }
                                                    else if (objHis.MsgContent.Length > 70 && objHis.MsgContent.Length <= 134)
                                                    {
                                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                                    }
                                                    else if (objHis.MsgContent.Length > 134 && objHis.MsgContent.Length <= 195)
                                                    {
                                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                                    }
                                                    else if (objHis.MsgContent.Length > 195 && objHis.MsgContent.Length <= 260)
                                                    {
                                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                                    }


                                                    if (sendedCount >= cansendCount)
                                                    {
                                                        SmartBLL.UpdateSendStatus("99", objHis.TransNumber);
                                                    }
                                                    else
                                                    {
                                                        string sendStatus = TBSendMSg.SendMsg(cellPhone, sigNames, objHis.MsgContent.Replace("退订回N", "").Replace(sigName, ""));
                                                        if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                                        {
                                                            //string sendStatus = Mobile.SendMsgKeTongDX(cellPhone, objHis.MsgContent);

                                                            //string sendStatus = Mobile.PostDataToMyServer(cellPhone, objHis.MsgContent.Trim());//20160626 yao c
                                                            //IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                                            //SmartBLL.UpdateSendStatus(resultDic["status"].ToString(), objHis.TransNumber);
                                                            SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);
                                                        }
                                                        else
                                                        {
                                                            //string sendStatus = Mobile.SendMsgHubeiYDPost(cellPhone, objHis.MsgContent);//\r\n\r\n\r\n\r\n0
                                                            //sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                                            if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                                            SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);

                                                        }
                                                    }
                                                    sendedCount++;
                                                    j++;
                                                    //}
                                                    //else
                                                    //{
                                                    //    if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                                    //    {
                                                    //        string sendStatus = Mobile.PostDataToMyServer(cellPhone, objHis.MsgContent.Trim(), "");
                                                    //    }
                                                    //    else
                                                    //    {
                                                    //        Mobile.SendMsgKeTongYD(cellPhone, objHis.MsgContent);
                                                    //    }
                                                    //}
                                                }
                                                catch (Exception ex)
                                                {
                                                    continue;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            context.Response.Write("3");//余额不足
                                            //context.Response.End();//使用 Response.End方法，将出现 ThreadAbortException 异常。
                                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                                            return;
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                            #endregion

                            //短信发送成功记录
                            msgSendingBLL.update(Users.Nick, 2, phones.Count);
                            context.Response.Write("2");
                            //context.Response.End();
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                    }
                }
                else
                {
                    context.Response.Write("0");
                    //context.Response.End();
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                    msgSendingBLL.update(Users.Nick, 2, phones.Count);
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