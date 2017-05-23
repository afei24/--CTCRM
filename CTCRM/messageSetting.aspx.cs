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
using CTCRM.Entity;
using CTCRM.Components;
using System.Drawing;
using CTCRM.Common;
using System.Xml;
using System.Collections.Generic;

namespace CTCRM
{
    public partial class messageSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MsgDataBind();
                
            }
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            //lbMsg.Text = "";
            //lbError.Text = "";

            //检查卖家订购的套餐使用情况。

        }

        private void MsgDataBind()
        {
            grdHisMsg.DataSource = MsgBLL.GetMsgHisByNick(Users.Nick);
            grdHisMsg.DataBind();

            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(Users.Nick);
            if (String.IsNullOrEmpty(checkIsExit) || !Convert.ToBoolean(checkIsExit))//账户未开通
            {
                imgMsgISCanUse.ImageUrl = "../Images/cannotuse.png";
                imgMsgISCanUse.ToolTip = "短信账户尚未开通";
            }
            else {//账户开通
                imgMsgISCanUse.ImageUrl = "../Images/canuse.png";
                imgMsgISCanUse.ToolTip = "短信账户已开通";
            }
            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbMsgCanUseCount.Text = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
            }
            else
            {
                lbMsgCanUseCount.Text = "0条";
            }
        }

       

        private void MsgNofiySeller(String msg)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "msg", "alert('" + msg + "');", true);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('确定!')", true);
        }
       
        protected void grdMessageTemp_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void grdMessageTemp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string msgType = e.Row.Cells[3].Text.Trim();
                if (msgType.Equals("系统创建")) {
                    e.Row.Cells[4].Visible = false;
                }
            }
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

        protected void imgNavSendMsg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("message.aspx");
        }

    }
}