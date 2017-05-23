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
using Top.Api.Domain;
using CTCRM.Components;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Data.OleDb;
using System.IO;
using CTCRM.Common;
using CTCRM.Entity;
using System.Drawing;
using System.Threading;

namespace CTCRM.WIN_Aspx.Download
{
    //修改人：LU
    //日期：201609058
    public partial class download : System.Web.UI.Page, ICallbackEventHandler
    {
        private string strCallback;
        //卖家id
        string sellerId = "";
        //没手机号的会员
        DataTable tbSource = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //注册客户端(前端)函数的引用
            String cbReference = Page.ClientScript.GetCallbackEventReference(this, "arg", "ReceiveData", "context");
            String callbackScript = "function CallServer(arg, context) {\n" + cbReference + ";\n}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "CallServer", callbackScript, true);



            //获取卖家id
            sellerId = SellersBLL.GetSellerIdByNick(Users.Nick);

            //获取没手机号的会员
            tbSource = BuyerBLL.GetSellerNoDetailsInfo(sellerId);
            if (tbSource != null && tbSource.Rows.Count >= 0)
            {
                LabelNoNum.Text = tbSource.Rows.Count.ToString();
            }

            //获取上次卖家手工同步数据的时间
            string synDate = SellersBLL.GetSellerSynDate(Users.Nick);
            if (!string.IsNullOrEmpty(synDate))
            {
                lbsynDate.Text = "上次同步成功完成（上次同步时间：" + synDate + ")";
            }
            else
            {
                lbsynDate.Text = "您还没有同步过数据！";
            }

            if (!Page.IsPostBack)
            {

                
            }
            else
            {
                if (Request.Form["__EVENTARGUMENT"] == "updatetime")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "success", "msgbox('会员资料同步完成！');", true);
                }
            }
        }
        public void RaiseCallbackEvent(String eventArgument)
        {
            if (eventArgument == "progress")
            {
                strCallback = "progress," + SellersBLL.GetSyncMem(Users.Nick).ToString();
            }
            else if (eventArgument == "syncmember")
            {
                bool br;
                br = SellersBLL.SetSyncMem(Users.Nick);
                if (br)
                {
                    strCallback = "syncmember,success";
                    Client.CreateSyncEvent();
                }
                else
                    strCallback = "syncmember,failed";
            }
        }

        public string GetCallbackResult()
        {
            return strCallback;
        }

        protected void imgImportData_Click(object sender, ImageClickEventArgs e)
        {
            //Thread.Sleep(1000000);
            try
            {
                #region 订单交易导入
                if (!String.IsNullOrEmpty(fileOrderUpload.PostedFile.FileName))
                {

                    //文件扩展名
                    string fileExtend = "";
                    string filePath = "";
                    //文件大小
                    long fileSize = 0;
                    filePath = fileOrderUpload.PostedFile.FileName.ToLower().Trim();

                    //取得上传前的文件(存在于客户端)的文件或文件夹的名称
                    string[] names = filePath.Split('\\');
                    //取得文件名
                    string name = names[names.Length - 1];
                    //获得服务器端的根目录
                    string serverPath = Server.MapPath("~/SellerReport");

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
                    fileOrderUpload.PostedFile.SaveAs(filePath);


                    //得到扩展名
                    fileExtend = filePath.Substring(filePath.LastIndexOf("."));
                    if (fileExtend != ".csv")
                    {
                        lbError.Text = "只支持CSV格式的文件！";
                        lbError.ForeColor = Color.Red;
                        return;
                    }

                    System.IO.FileInfo f = new FileInfo(filePath);
                    fileSize = f.Length;
                    int size = Convert.ToInt32(fileSize) / (1024 * 1024);
                    if (size >= 20)
                    {
                        lbError.Text = "最大可上传文件大小为20M！";
                        lbError.ForeColor = Color.Red;
                        return;
                    }

                    CSVHelper obj = new CSVHelper(fileImprtPath, fileOrderUpload.FileName.ToLower().Trim());
                    DataTable tb = obj.Read();
                    //将订单交易信息写入到DB，同时更新买家表信息
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        Trade o = null;
                        Buyers objBuyer = null;


                        foreach (DataRow row in tb.Rows)
                        {
                            try
                            {
                                o = new Trade();
                                o.Tid = Convert.ToInt64(string.IsNullOrEmpty(row["订单编号"].ToString()) ? "000000" : row["订单编号"].ToString());
                                o.BuyerNick = row["买家会员名"].ToString();
                                o.SellerNick = Users.Nick;
                                o.ReceiverAddress = row["收货地址 "].ToString();
                                o.ReceiverName = row["收货人姓名"].ToString();
                                o.ReceiverPhone = row["联系电话 "].ToString();
                                o.ReceiverMobile = row["联系手机"].ToString();

                                //更新买家信息表数据
                                objBuyer = new Buyers();
                                objBuyer.Address = o.ReceiverAddress;
                                if (!String.IsNullOrEmpty(o.ReceiverAddress))
                                {
                                    string[] info = o.ReceiverAddress.Split(new char[] { ' ' });
                                    if (info.Length > 0)
                                    {
                                        objBuyer.BuyerProvince = info[0].ToString();
                                    }
                                }
                                objBuyer.BuyerNick = o.BuyerNick;
                                objBuyer.CellPhone = o.ReceiverMobile == null ? "" : o.ReceiverMobile.Replace("'", "");
                                objBuyer.Phone = o.ReceiverPhone == null ? "" : o.ReceiverPhone.Replace("'", "");
                                objBuyer.Buyer_reallName = String.IsNullOrEmpty(o.ReceiverName) ? "unknown!" : o.ReceiverName;
                                objBuyer.SELLER_ID = Users.Nick;
                                if (SellersBLL.SearchBuyers(tbSource, objBuyer.BuyerNick))
                                {
                                    BuyerBLL.UpdateForHistory(objBuyer, sellerId);

                                }
                            }
                            catch (Exception ex)
                            {
                                //ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                                continue;
                            }
                        }
                        //将最新同步数据时间更新写入DB
                        Sellers objSeller = new Sellers();
                        objSeller.Nick = Users.Nick;
                        SellersBLL.UpdateSellerSynDate(objSeller);
                    }

                    lbError.Text = "导入报表数据成功！";
                }
                else
                {
                    lbError.Text = "请选择小于20M的CSV格式文件！";
                }
               
                #endregion
             }
       
            catch(Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                //lbError.Text = "导入报表失败,请联系客服！";
                lbError.Text = "导入报表失败,报表内容格式不正确！";
                lbError.ForeColor = Color.Red;
                return;
            }
            
        
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    BuyerBLL ob = new BuyerBLL();
        //    ob.SynicBuyersInformation(Users.Nick, Users.SessionKey);
        //}

        //protected void btnSynTrade_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Thread.Sleep(1000000);
        //     DateTime startTradeDate = Convert.ToDateTime(DateTime.Now.AddMonths(-3).ToShortDateString());
        //     DateTime endTradeDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        //     if (BuyerBLL.SynicTrade(Users.SessionKey, startTradeDate, endTradeDate,Users.Nick))
        //     {
        //         if (SellersBLL.SetSyncTradeFlag(Users.Nick,1))
        //         {
        //             btnSynTrade.Enabled = false;
        //             btnSynTrade.ImageUrl = "~/Images/done.png";
        //         }
        //     }
        //}
    }
}
