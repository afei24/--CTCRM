using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.WIN_Aspx.member
{
    public partial class reminderHis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnMsgSend_Click(object sender, ImageClickEventArgs e)
        {
            BindData();
        }
        protected void BindData()
        {
            string startDate = datePicker.Value.Trim();
            string endDate = datePickerEnd.Value.Trim();
            string type = drpSType.SelectedValue.ToString();
            DataTable ds = new DataTable();
            if (string.IsNullOrEmpty(type) || type == "all")
            {
                ds = MsgBLL.GetMsgReminderHisBySellerNick(Users.Nick, startDate, endDate);
            }
            else
            {
                ds = MsgBLL.GetMsgReminderHisBySellerNick(Users.Nick, startDate, endDate,type);
            }
            //根据分页情况将数据写入或者更新到数据库
            this.grdBuyer.DataSource = ds;
            this.grdBuyer.DataBind();
        }

        protected void grdBuyer_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            BindData();
        }
    }
}