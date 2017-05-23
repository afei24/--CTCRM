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
using System.Drawing;
using CTCRM.Common;
using CTCRM.Components;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Collections.Generic;

namespace CTCRM.WIN_Aspx.member
{
    public partial class confirmNofity : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataGridBind();
                datePickerStart.Value = DateTime.Now.AddDays(-15).ToShortDateString();
                datePickerEnd.Value = DateTime.Now.ToShortDateString();
                lbMsg.Text = "";
                tdLast.Visible = false;
                tdFinish.Visible = false;
            }
            lbMsg.Text = "";
        }

        protected string GetTitle(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (value.Length > 20)
                {
                    return value.Substring(0, 20) + "....";
                }
                return value;
            }
            return "";
        }

        private void DataGridBind()
        {
            DataTable tbConfirm = MemberNotifyBLL.GetConfirmNotifyByNick(datePickerStart.Value, datePickerEnd.Value, txtNickName.Text.Trim());
            Session["DataSource"] = tbConfirm;
            grdUnpay.DataSource = tbConfirm;
            grdUnpay.DataBind();
            if (tbConfirm == null || tbConfirm.Rows.Count == 0)
            {
                imgbtnNext.Enabled = false;
            }
        }
        protected void imgbtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            DataGridBind();
        }

        protected void grdUnpay_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -3)
            {
                //点击了Go按钮
                TextBox txtNewPageIndex = null;

                //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                GridViewRow pagerRow = theGrid.BottomPagerRow;

                if (pagerRow != null)
                {
                    //得到text控件
                    txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                }
                if (txtNewPageIndex != null)
                {
                    //得到索引
                    newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                }
            }
            else
            {
                //点击了其他的按钮
                newPageIndex = e.NewPageIndex;
            }
            //防止新索引溢出
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            //得到新的值
            theGrid.PageIndex = newPageIndex;

            //重新绑定
            DataGridBind();
        }
        protected void rdoMsgTemp1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoMsgTemp1.Checked)
                {
                    string shopName = "";
                    if (Session["ShopName"] != null)
                    {
                        shopName = Session["ShopName"].ToString();
                    }
                    lbMessageView.Text = "亲！宝贝收到了吗？合您的口味吗？有问题随时联系我，满意请确认收货点亮5颗星星哦，谢谢光顾" + shopName;
                    lbFontCount.Text = lbMessageView.Text.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void rdoMsgTemp2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoMsgTemp2.Checked)
                {
                    string shopName = "";
                    if (Session["ShopName"] != null)
                    {
                        shopName = Session["ShopName"].ToString();
                    }
                    lbMessageView.Text = "亲！宝贝还满意吗？如有问题随时联系我，没问题别忘了确认收货哦，谢谢您的光顾" + shopName;
                    lbFontCount.Text = lbMessageView.Text.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void rdoMsgTemp3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoMsgTemp3.Checked)
                {
                    string shopName = "";
                    if (Session["ShopName"] != null)
                    {
                        shopName = Session["ShopName"].ToString();
                    }
                    lbMessageView.Text = "亲！宝贝还满意吗？有问题请随时我，满意麻烦您确认收货哦，本店最近有新货哦~谢谢您的光顾" + shopName;
                    lbFontCount.Text = lbMessageView.Text.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void rdoMsgTemp4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdoMsgTemp4.Checked)
                {
                    string shopName = "";
                    if (Session["ShopName"] != null)
                    {
                        shopName = Session["ShopName"].ToString();
                    }

                    lbMessageView.Text = "亲！" + shopName + "时刻关心您的购物心情：宝贝收到了吗？还满意么？没问题不要忘了确认收货哦，谢谢您的光顾.";
                    lbFontCount.Text = lbMessageView.Text.Length.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
        {
            tdLast.Visible = true;
            tdFinish.Visible = true;
            tdNext.Visible = false;
            Menu1.Items[0].ImageUrl = "~/Images/next2.jpg";
            MultiView1.ActiveViewIndex = 1;
        }

        protected void imgbtnLast_Click(object sender, ImageClickEventArgs e)
        {
            tdLast.Visible = false;
            tdFinish.Visible = false;
            tdNext.Visible = true;
            Menu1.Items[0].ImageUrl = "~/Images/Confirmnext1.jpg";
            MultiView1.ActiveViewIndex = 0;
        }

        protected void imgbtnFinish_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                if (!rdoMsgTemp1.Checked && !rdoMsgTemp2.Checked && !rdoMsgTemp3.Checked)
                {
                    lbMsg.Text = "请选择短信模版！";
                    return;
                }
                tdLast.Visible = false;
                tdFinish.Visible = false;
                tdNext.Visible = false;
                Menu1.Items[0].ImageUrl = "~/Images/next3.jpg";
                MultiView1.ActiveViewIndex = 2;
                //确认按钮触发短信提醒
                if (Session["DataSource"] != null)
                {
                    DataTable tb = Session["DataSource"] as DataTable;
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        var cellpone = "";
                        for (int i = 0; i < tb.Rows.Count; i++)
                        {
                            cellpone = tb.Rows[i]["cellPhone"].ToString();
                            if (string.IsNullOrEmpty(cellpone))
                            {
                                continue;
                            }
                            if (Utility.IsCellPhone(cellpone))
                            {

                                if (MsgBLL.CheckSellerMsgStatus())
                                {
                                    //Mobile obj = new Mobile();
                                    //发送消息
                                    string msgContent = "";
                                    if (rdoMsgTemp1.Checked)
                                    {
                                        msgContent = rdoMsgTemp1.Text;
                                    }
                                    if (rdoMsgTemp2.Checked)
                                    {
                                        msgContent = rdoMsgTemp2.Text;
                                    }
                                    if (rdoMsgTemp3.Checked)
                                    {
                                        msgContent = rdoMsgTemp3.Text;
                                    }
                                    if (rdoMsgTemp4.Checked)
                                    {
                                        msgContent = rdoMsgTemp4.Text;
                                    }
                                    msgContent = msgContent.Replace("**店铺名称**", Session["ShopName"] == null ? "" : Session["ShopName"].ToString()) + "【" + Users.Nick + "】";

                                    List<string> lstCellPhoneNo = new List<string>();
                                    lstCellPhoneNo.Add(cellpone);
                                    string sendStatus = Mobile.sendMsg(lstCellPhoneNo, msgContent);
                                    //if (sendStatus.Equals("0"))
                                    //{
                                    if (Convert.ToInt32(lbFontCount.Text.ToString()) <= 65)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                    }
                                    else if (Convert.ToInt32(lbFontCount.Text.ToString()) > 65 && Convert.ToInt32(lbFontCount.Text.ToString()) <= 130)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                    }
                                    else if (Convert.ToInt32(lbFontCount.Text.ToString()) > 130 && Convert.ToInt32(lbFontCount.Text.ToString()) <= 195)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                    }
                                    //}
                                    else if (sendStatus.Equals("-4"))
                                    {
                                        lbOrderMsg.Text = "短信账户余额不足,请充值!";
                                        break;
                                    }
                                    else if (sendStatus.Equals("-5"))
                                    {
                                        lbOrderMsg.Text = "短信内容含有禁止关键字,请修改!";
                                        break;
                                    }
                                }
                                else
                                {
                                    //更新短信账户状态
                                    MsgBLL.UpdateMsgTransServiceStatus(Users.Nick, false);
                                    lbOrderMsg.Text = "短信账户余额不足,现在去充值？";
                                    imgbtnFinish.Enabled = false;
                                    Menu1.Items[0].ImageUrl = "~/Images/next2.jpg";
                                    MultiView1.ActiveViewIndex = 1;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mobile obj = new Mobile();
                if (!rdoMsgTemp1.Checked && !rdoMsgTemp2.Checked && !rdoMsgTemp3.Checked && !rdoMsgTemp4.Checked)
                {
                    lbMsg.Text = "请选择短信模版！";
                    return;
                }
                //验证测试手机号码
                if (!String.IsNullOrEmpty(txtTestMsg.Text.Trim()))
                {
                    if (!Utility.IsCellPhone(txtTestMsg.Text.Trim()))
                    {
                        lbMsg.Text = "请输入正确的手机号码！";
                    }
                    else
                    {
                        //发送消息
                        string msgContent = "";
                        if (rdoMsgTemp1.Checked)
                        {
                            msgContent = rdoMsgTemp1.Text;
                        }
                        if (rdoMsgTemp2.Checked)
                        {
                            msgContent = rdoMsgTemp2.Text;
                        }
                        if (rdoMsgTemp3.Checked)
                        {
                            msgContent = rdoMsgTemp3.Text;
                        }
                        if (rdoMsgTemp4.Checked)
                        {
                            msgContent = rdoMsgTemp4.Text;
                        }
                        msgContent = msgContent.Replace("**店铺名称**", Session["ShopName"] == null ? "" : Session["ShopName"].ToString()) + "【" + Users.Nick + "】";
                        List<string> lstCellPhoneNo = new List<string>();
                        lstCellPhoneNo.Add(txtTestMsg.Text.Trim());
                        string sendStatus = Mobile.sendMsg(lstCellPhoneNo, msgContent);
                        if (sendStatus.Equals("0"))//限制测试用户一天只能发送一次。方式利用此漏洞群发。
                        {
                            lbMsg.Text = "发送成功！";
                            lbMsg.ForeColor = Color.Blue;
                            txtTestMsg.Text = "";
                            //更新DB发送标示
                        }
                    }
                }
                else
                {
                    lbMsg.Text = "手机号码不能为空！";
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

    }
}