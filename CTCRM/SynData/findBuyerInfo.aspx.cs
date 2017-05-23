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
using CHENGTUAN.Components;
using System.Drawing;
using CHENGTUAN.Entity;
using CTCRM.Common;
using Top.Api.Domain;
using CTCRM.Entity;
using CTCRM.Components;
using System.IO;
using System.Threading;

namespace CTCRM.SynData
{
    public partial class findBuyerInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //DataRow orderDate = SellersBLL.GetSelerOrderDate(Users.Nick);
            //if (orderDate != null)
            //{
            //    if (orderDate["OrderVersion"].Equals("体验版"))
            //    {
            //        Response.Redirect("http://crm.new9channel.com/version/versionTip.aspx");
            //    }
            //}

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
                    int fileSize = 0;
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
                        return;
                    }

                    CSVHelper obj = new CSVHelper(fileImprtPath, fileOrderUpload.FileName.ToLower().Trim());
                    DataTable tb = obj.Read();
                    //将订单交易信息写入到DB，同时更新买家表信息
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        Trade o = null;
                        Buyers objBuyer = null;
                        string sellerId = SellersBLL.GetSellerIdByNick(Users.Nick);
                        DataTable tbSource = BuyerBLL.GetSellerNoDetailsInfo(sellerId);
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
                    }


                }
               
                #endregion
             }
       
            catch(Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                lbError.Text = "导入报表失败,请联系客服！";
                return;
            }
            lbError.Text = "导入报表数据成功！";
            lbError.ForeColor = Color.Blue;
        }
        
    }
}
