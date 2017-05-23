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
using CTCRM.Components;
using System.Drawing;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using System.IO;
using Top.Api.Domain;
using CTCRM.DAL;




namespace CTCRM.admin.memberData
{
    public partial class sysDataOpen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGINUSERNAME"] == null && !Convert.ToString(Session["LOGINUSERNAME"]).Equals("kimluo"))
            {
                Response.Redirect("~/admin/Login.aspx?");
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                if (SellersBLL.UpdateTradeFlag(txtTitle.Text.Trim()))
                {
                    lbMsg.Text = "同步操作重新开启！";
                    lbMsg.ForeColor = Color.Blue;
                }
                else
                {
                    lbMsg.Text = "开启失败！";
                    lbMsg.ForeColor = Color.Red;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //从数据库中查询出sessionkey
            lbSession.Text = SellersBLL.GetSellerSessionKey(TextBox1.Text.Trim()); 
        }

        //读取会员api
        protected void Button2_Click(object sender, EventArgs e)
        {
            string sellerNick = TextBox2.Text.Trim();
            string session = txtSession.Text.Trim();
            //如果没有会员，则尝试建立会员列表  20160704 yao
            string memberNum = BuyerBLL.GetBuyerCount("1", sellerNick);
            if (memberNum.Equals("0")==true)
            {
                if (string.IsNullOrEmpty(sellerNick) == true) { lbError.Text = "请输入昵称！"; return; };
                string seller_id = SellersBLL.GetSellerIdByNick(sellerNick);
                if (string.IsNullOrEmpty(seller_id) == false)
                {
                   SellersDAL sellerdl = new SellersDAL();
                    sellerdl.addBuyerData(seller_id);
                }
            }

            try
            {
                //下载淘宝数据到本地
                //初始化系统分组
                InitGroup(sellerNick);
                BuyerBLL buyerObj = new BuyerBLL();
                if (buyerObj.SynicBuyersInformation(sellerNick, session))
                {
                    //将最新同步数据时间更新写入DB
                    Sellers objSeller = new Sellers();
                    objSeller.Nick = sellerNick;
                    SellersBLL.UpdateSellerSynDate(objSeller);
                }
                lbError.Text = "会员同步完成！";
                lbError.ForeColor = Color.Blue;
            }
            catch (Exception err)
            {
                ExceptionReporter.WriteLog(err, ExceptionPostion.TBApply_Data);
                lbError.Text = "会员同步完成,但出现异常，详情请看日志！";
            }
        }

        #region 初始化卖家的买家系统分组
        /// <summary>
        /// 初始化卖家的买家系统分组；另外功能还需要提供卖家自定义分组。
        /// </summary>
        private void InitGroup(string strNick)
        {
            //同步系统分组功能
            CTCRM.Entity.Group obj = new CTCRM.Entity.Group();
            obj.Group_name = "新客户";
            obj.SellerNick = strNick;
            obj.Memo = "";
            obj.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "新客户"))
            {
                //BuyerBLL.AddBuyerGroup(obj);
                BuyerBLL.AddGroup(obj);
            }

            CTCRM.Entity.Group obj2 = new CTCRM.Entity.Group();
            obj2.Group_name = "老客户";
            obj2.SellerNick = strNick;
            obj2.Memo = "";
            obj2.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "老客户"))
            {
                BuyerBLL.AddGroup(obj2);
            }

            CTCRM.Entity.Group obj3 = new CTCRM.Entity.Group();
            obj3.Group_name = "休眠3个月";
            obj3.SellerNick = strNick;
            obj3.Memo = "";
            obj3.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "休眠3个月"))
            {
                BuyerBLL.AddGroup(obj3);
            }

            CTCRM.Entity.Group obj5 = new CTCRM.Entity.Group();
            obj5.Group_name = "潜在客户";
            obj5.SellerNick = strNick;
            obj5.Memo = "";
            obj5.OpenStatus = true;
            //如果添加分组成功
            if (!BuyerBLL.CheckGroupIsExit(strNick, "潜在客户"))
            {
                BuyerBLL.AddGroup(obj5);
            }
        }
        #endregion


        protected void Button3_Click(object sender, EventArgs e)
        {
            string sellerNick = TextBox2.Text.Trim();
            string session = txtSession.Text.Trim();
            //DateTime startTradeDate = Convert.ToDateTime(DateTime.Now.AddMonths(-3).ToShortDateString());
            //DateTime endTradeDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //if (BuyerBLL.SynicTrade(session, startTradeDate, endTradeDate, sellerNick))
            //{
            //    if (SellersBLL.SetSyncTradeFlag(sellerNick, 1))
            //    {
            //        lbError.Text = "订单同步完成！";
            //        lbError.ForeColor = Color.Blue;
            //    }
            //}
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string nick = TextBox3.Text.Trim();
            Label5.Text = "店铺会员总数为：" + BuyerBLL.GetBuyerCount("1", nick) + "个";
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string nick = TextBox3.Text.Trim();
            Label6.Text ="店铺有效会员总数为：" + BuyerBLL.GetBuyerCount("0",nick) + "个";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
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
                        string sellerId = SellersBLL.GetSellerIdByNick(TextBox4.Text.Trim());
                        DataTable tbSource = BuyerBLL.GetSellerNoDetailsInfo(sellerId);
                        foreach (DataRow row in tb.Rows)
                        {
                            try
                            {
                                o = new Trade();
                                o.Tid = Convert.ToInt64(string.IsNullOrEmpty(row["订单编号"].ToString()) ? "000000" : row["订单编号"].ToString());
                                o.BuyerNick = row["买家会员名"].ToString();
                                o.SellerNick = TextBox4.Text.Trim();
                                o.ReceiverAddress = row["收货地址 "].ToString();
                                o.ReceiverName = row["收货人姓名"].ToString();
                                o.ReceiverPhone = row["联系电话 "].ToString();
                                o.ReceiverMobile = row["联系手机"].ToString();
                                //更新买家信息表数据
                                objBuyer = new Buyers();
                                //objBuyer.BuyerId = Convert.ToInt64(BuyerBLL.GetBuyerIdByBuyerNick(o.BuyerNick, Users.Nick));
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
                                //objBuyer.Buyer_alipay_no = o.BuyerAlipayNo;
                                objBuyer.SELLER_ID = TextBox4.Text.Trim();
                                if (SellersBLL.SearchBuyers(tbSource,objBuyer.BuyerNick))
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

            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                Label9.Text = "导入报表失败,请联系客服！";
                return;
            }
            Label9.Text = "导入报表数据成功！";
            Label9.ForeColor = Color.Blue;
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtSellerName.Text.Trim()))
            {
                Label8.Text = "卖家昵称不能为空！";
                return;
            }
            SellersBLL.SetSyncProcess(txtSellerName.Text.Trim(), 0);
            Label8.Text = "结束成功！";
        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            string nick = TextBox3.Text.Trim();
            Label10.Text = "店铺会员总数为：" + BuyerBLL.GetOldBuyerCount("1", nick) + "个";
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            string nick = TextBox3.Text.Trim();
            Label11.Text = "店铺有效会员总数为：" + BuyerBLL.GetOldBuyerCount("0", nick) + "个";
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            string sellerNick = TextBox2.Text.Trim();
            string session = txtSession.Text.Trim();

            DateTime startTradeDate = Convert.ToDateTime(DateTime.Now.AddMonths(-3).ToShortDateString());
            DateTime endTradeDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            if (BuyerBLL.SynicOldTrade(session, startTradeDate, endTradeDate, sellerNick))
            {
                if (SellersBLL.SetSyncTradeFlag(sellerNick, 1))
                {
                    lbError.Text = "订单同步完成！";
                    lbError.ForeColor = Color.Blue;
                }
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            //从seller表中删除该用户
            SellersBLL.DeleteSeller(TextBox5.Text.Trim());
            Label13.Text = "删除成功！";
        }
       
    }
}
