using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;

namespace CTCRM.admin.message
{
    public partial class rechargeRecords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            MsgDataBind();
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            string MsgCount = tboxMsgCount.Text.Trim();
            decimal MsgPrice = 0M;
            try
            {
                Convert.ToInt32(MsgCount);
                MsgPrice = Convert.ToDecimal(tboxMsgPrice.Text.Trim());
            }
            catch
            {
                Response.Write("<script language='javascript'>alert('请正确填写短信条数和金额！');</script>");
                return;
            }
            try
            {

                bool result = AdminChongZhiMsgBLL.AddAdminChongZhiMsg(MsgCount, MsgPrice);
                MsgDataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        DataTable dt = new DataTable();
        private void MsgDataBind()
        {
            try
            {
                 dt = AdminChongZhiMsgBLL.GetAdminChongZhiMsg(txt_StartTime.Value, txt_EndTime.Value);
                grdCus.DataSource = dt;
                grdCus.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
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

        protected void grdCus_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void grdCus_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int i =Convert.ToInt32( e.CommandArgument);
                dt = AdminChongZhiMsgBLL.GetAdminChongZhiMsg(txt_StartTime.Value, txt_EndTime.Value);
                string id = dt.Rows[i]["id"].ToString();
                AdminChongZhiMsgBLL.DeleteAdminChongZhiMsg(id);
                MsgDataBind();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('删除成功！');</script>");
            }
        }

        protected void grdCus_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
        }

        protected void grdCus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        DataTable dtJifei;
        protected void ButtonQuery_Click(object sender, EventArgs e)
        {
            LabelAllMsg.Text = "";
            dtJifei = MsgBLL.GetMsgSendJifen(TextSatrtDate.Value, TextEndDate.Value);
          GridViewJifei.DataSource = dtJifei;
          GridViewJifei.DataBind();

          DataTable dtSum = MsgBLL.GetMsgRecordsSum();
          string msg_count = dtSum.Rows[0]["msg_count"].ToString();
          string msg_Price = dtSum.Rows[0]["msg_Price"].ToString();
          LabelAllMsg.Text = "所有卖家短信使用费用情况：在搜索时间范围内共发送" + msg_count + "条短信，短信费用为" + msg_Price + "元";
        }

        protected void GridViewJifei_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            dtJifei = MsgBLL.GetMsgRecords("");
            GridViewJifei.DataSource = dtJifei;
            GridViewJifei.DataBind();  
        }

        protected void ButtonSNick_Click(object sender, EventArgs e)
        {
            string nick = TextBoxNickSum.Text.Trim();
            dtJifei = MsgBLL.GetMsgRecords(nick);
            GridViewJifei.DataSource = dtJifei;
            GridViewJifei.DataBind();  
        }
    }
}