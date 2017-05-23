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

namespace CTCRM.admin.notify
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
                //日期显示为只读
                txt_StartTime.Attributes.Add("readonly", "readonly");
                //MsgDataBind();
            }

        }

        private void MsgDataBind()
        {
            try
            {
                grdCus.DataSource = AppCusBLL.GetNotifyData(txtNick.Text.Trim());
                grdCus.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string date = txt_StartTime.Value;
            if (!string.IsNullOrEmpty(date)) {
                date = Convert.ToDateTime(date).ToString("yyyyMMdd");
                if (AppCusBLL.DeleteDataByDateTime(date))
                {
                    Response.Write("<script language='javascript'>alert('删除成功！');</script>");
                }

            }
            if (!string.IsNullOrEmpty(txtNick.Text.Trim()))
            {
                if (AppCusBLL.DeleteDataByNick(txtNick.Text.Trim()))
                {
                    Response.Write("<script language='javascript'>alert('删除成功！');</script>");
                }

            }
            MsgDataBind();
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

        protected void Button1_Click(object sender, EventArgs e)
        {  //重新绑定
            MsgDataBind();
        }


    }
}
