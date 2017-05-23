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
using System.Drawing;

namespace CTCRM.admin.rate
{
    public partial class rateQuery : System.Web.UI.Page
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
                RatingBLL obj = new RatingBLL();
                DataTable tb = obj.GetSellerRateConfig(txtTitle.Text.Trim(), txt_StartTime.Value, txt_EndTime.Value);
                grdCus.DataSource = tb; 
                grdCus.DataBind();
                lbTip.Text = tb.Rows.Count.ToString() + " 个";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox1.Text.Trim()))
            {
                Label1.Text = "昵称不能为空！";
                Label1.ForeColor = Color.Red;
                return;
            }
            string nick = TextBox1.Text.Trim();
            string openSatus = "";
            if(RadioButtonList1.SelectedValue.Equals("0"))
            {
                openSatus = "0";
            }
            if (RadioButtonList1.SelectedValue.Equals("1"))
            {
                openSatus = "1";
            }
             RatingBLL obj = new RatingBLL();
             if (obj.ManageRateStatus(nick, openSatus))
             {
                 Label1.Text = "更新成功!";
                 Label1.ForeColor = Color.Blue;
             }
             else
             {
                 Label1.Text = "更新失败!";
                 Label1.ForeColor = Color.Red;
             }

        }


    }
}
