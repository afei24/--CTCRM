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
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;
using Top.Api.Domain;

namespace CTCRM.admin.logtics
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGINUSERNAME"] == null && !Convert.ToString(Session["LOGINUSERNAME"]).Equals("kimluo"))
            {
                Response.Redirect("~/admin/Login.aspx?");
            }
            //初始化分页控件
            if (!Page.IsPostBack)
            {
                //drpStatus.Items.Insert(0, "---审核状态---");
                MsgDataBind();
                //日期显示为只读
                txt_StartTime.Attributes.Add("readonly", "readonly");
                txt_EndTime.Attributes.Add("readonly", "readonly");
            }
        }

        private void MsgDataBind()
        {
            try
            {
                grdCus.DataSource = SellersBLL.GetSellerReminderStatus(txtTitle.Text.Trim(), txt_StartTime.Value, txt_EndTime.Value,drpSendType.SelectedValue);
                grdCus.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                MsgDataBind();
            }
            catch (Exception ex)
            {
                // 数据检索失败！
                Response.Write("<script language='javascript'>alert('加载数据失败！');</script>");
            }
        }


        protected void grdCus_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            MsgDataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string status = "0";
            if (rdoCloseOpen.SelectedValue.Equals("开启")){
                status = "1";
            }
            if (rdoReminderType.SelectedValue.Equals("付款提醒"))
            {
                if (SellersBLL.UpdateReminderUnConfirmType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("催款提醒"))
            {
                if (SellersBLL.UpdateReminderUnPayType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("发货提醒"))
            {
                if (SellersBLL.UpdateReminderShippingType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("延迟发货提醒"))
            {
                if (SellersBLL.UpdateReminderDelayShipType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("达到提醒"))
            {
                if (SellersBLL.UpdateReminderArrivedType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("签收提醒"))
            {
                if (SellersBLL.UpdateReminderSignType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            if (rdoReminderType.SelectedValue.Equals("回款提醒"))
            {
                if (SellersBLL.UpdateReminderHuiZJType(txtNick.Text.Trim(), status))
                {
                    lbMsg.Text = "修改成功";
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (RadioButtonList1.SelectedValue.Equals("开启"))
            {

                ITopClient client = TBManager.GetClient();
                TmcUserPermitRequest req = new TmcUserPermitRequest();
                //req.Topics = "taobao_trade_TradeCreate,taobao_refund_RefundCreate";
                TmcUserPermitResponse response = client.Execute(req, txtSession.Text.Trim());
                if (response.IsSuccess)
                {
                    lbMsg2.Text = "开启成功！";
                }
                else {
                    lbMsg2.Text = response.ErrMsg;
                }
            }
            if (RadioButtonList1.SelectedValue.Equals("关闭"))
            {
                ITopClient client = TBManager.GetClient();
                TmcUserCancelRequest req = new TmcUserCancelRequest();
                req.Nick = sellerNick.Text.Trim();
                TmcUserCancelResponse response = client.Execute(req);
                if (response.IsSuccess)
                {
                    lbMsg2.Text = "关闭成功！";
                }
                else
                {
                    if (string.IsNullOrEmpty(response.ErrMsg))
                    {
                       
                    }
                    else
                    {
                        lbMsg2.Text = response.ErrMsg;
                    }
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNickName.Text.Trim()))
            {
                lbSessionKey.Text = SellersBLL.GetSellerSessionKey(txtNickName.Text.Trim());
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextBox1.Text.Trim()))
            {
                SellersBLL.UpdateSellerSYNData(TextBox1.Text.Trim());
                Label3.Text = "同步数据重新开通";
            }
        }

    }
}
