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

namespace CTCRM.admin.memberData
{
    public partial class deleteData : System.Web.UI.Page
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
                grdCus.DataSource = SellersBLL.GetEndDateSellers(txtTitle.Text.Trim(), txt_StartTime.Value, txt_EndTime.Value);
                grdCus.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        private void CheckValues()
        {
            if (!String.IsNullOrEmpty(txt_StartTime.Value.Trim()) && !String.IsNullOrEmpty(txt_EndTime.Value.Trim()))
            {
                if (DateTime.Parse(txt_StartTime.Value) > DateTime.Parse(txt_EndTime.Value))
                {
                    Response.Write("<script language='javascript'>alert('开始日期必须小于等于结束日期！');</script>");
                    return;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CheckValues();
                MsgDataBind();
            }
            catch (Exception ex)
            {
                // 数据检索失败！
                Response.Write("<script language='javascript'>alert('加载数据失败！');</script>");
            }
        }

        /// <summary>
        /// 允许事件单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Allow_click(object sender, EventArgs e)
        {
            try
            {
                string sellerID = ((LinkButton)sender).CommandArgument;
                if (SellersBLL.DeleteSellersInfo(sellerID))
                {
                    Response.Write("<script language='javascript'>alert('操作成功！');</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('操作失败！');</script>");
                }
                MsgDataBind();
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

    }
}
