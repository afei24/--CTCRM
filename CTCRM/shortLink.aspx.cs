using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using CTCRM.Components.TopCRM;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM
{
    public partial class shortLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            if (!Page.IsPostBack)
            {
                urlAd.Visible = false;
                urlAd2.Visible = false;
                Trproduct.Visible = false;
                TrTrade.Visible = false;
                MsgDataBind();
            }
           
        }
        private void MsgDataBind()
        {
            grdHisMsg.DataSource = ShortLinkBLL.GetShortLinkByNick(Users.Nick);
            grdHisMsg.DataBind();
        }

        protected void grdHisMsg_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                SellerShortLink obj = new SellerShortLink();
                if (string.IsNullOrEmpty(txtName.Text.Trim()))
                {
                    lbMsg.Text = "请输入短链名称！";
                    lbMsg.ForeColor = Color.Red;
                    return;
                }
                if (txtName.Text.Trim().Length > 16)
                {
                    lbMsg.Text = "最多只能16个中文字符！";
                    lbMsg.ForeColor = Color.Red;
                    return;
                }
                string type = DropDownList1.SelectedValue.ToString();
                if (type == "0")
                {
                    lbMsg.Text = "请选择需要生成的短链类型！";
                    lbMsg.ForeColor = Color.Red;
                    return;
                }
                string val = "";
                string msg = "";
                if (DropDownList1.SelectedValue.Equals("LT_ITEM"))
                {
                    obj.Memo = "生成短链的商品ID：" + txtProID.Text.Trim();
                    val = TBShortlink.SetShortLink(txtName.Text.Trim(), type, txtProID.Text.Trim(), ref msg);
                }
                else if (DropDownList1.SelectedValue.Equals("LT_SHOP"))
                {
                    obj.Memo = "";
                    val = TBShortlink.SetShortLink(txtName.Text.Trim(), type, "shop", ref msg);
                }
                else if (DropDownList1.SelectedValue.Equals("LT_ACTIVITY"))
                {
                    obj.Memo = "";
                    val = TBShortlink.SetShortLink(txtName.Text.Trim(), type, txtLinkURL.Text.Trim(), ref msg);
                }
                else if (DropDownList1.SelectedValue.Equals("LT_TRADE"))
                {
                    obj.Memo = "";
                    val = TBShortlink.SetShortLink(txtName.Text.Trim(), type, txtTradeID.Text.Trim(), ref msg);
                }
                //修改 val=="0" 时短链创建失败
                if (!string.IsNullOrEmpty(msg) || val=="0")
                {
                    //lbMsg.Text = msg;
                    //lbMsg.ForeColor = Color.Red;
                    LabelShortLink.Visible = true;
                    return;
                }
                obj.SellerNick = Users.Nick;
                obj.LinkType = DropDownList1.SelectedItem.Text;
                obj.LinkUrl = val;
                ShortLinkBLL.AddShortLink(obj);
                lbLink.Text = val;
                MsgDataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                lbMsg.Text = "短链创建失败，请联系客服！";
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList1.SelectedValue.Equals("LT_SHOP"))
            {
                urlAd.Visible = false;
                urlAd2.Visible = false;
                Trproduct.Visible = false;
                TrTrade.Visible = false;
            }else if (DropDownList1.SelectedValue.Equals("LT_ITEM"))
            {
                Trproduct.Visible = true;
                urlAd.Visible = false;
                urlAd2.Visible = false;
                TrTrade.Visible = false;
            }else if (DropDownList1.SelectedValue.Equals("LT_ACTIVITY"))
            {
                Trproduct.Visible = false;
                urlAd.Visible = true;
                urlAd2.Visible = true;
                TrTrade.Visible = false;
            }
            else if (DropDownList1.SelectedValue.Equals("LT_TRADE"))
            {
                Trproduct.Visible = false;
                urlAd.Visible = false;
                urlAd2.Visible = false;
                TrTrade.Visible = true;
            }
            else
            {
                Trproduct.Visible = false;
                TrTrade.Visible = false;
                urlAd.Visible = true;
                urlAd2.Visible = true;
            }
        }
    }
}