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
using System.Threading;

namespace CTCRM.WIN_Aspx.Smart
{
    public partial class msgHis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindData();
        }

        protected void BindData()
        {
            string startDate = datePicker.Value.Trim();
            string endDate = datePickerEnd.Value.Trim();
            DataTable ds = MsgBLL.GetMsgTransBySellerNick(Users.Nick, startDate, endDate);
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

        //protected void btnMsgSend_Click(object sender, ImageClickEventArgs e)
        //{
        //    //Thread.Sleep(10000000);
        //    BindData();
        //}

        protected void bt_search_Click(object sender, EventArgs e)
        {
            BindData();
        }

        //protected void grdBuyer_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        //会员详细
        //        ((HyperLink)e.Row.FindControl("HyperLinkEdit")).Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
        //        ((HyperLink)e.Row.FindControl("HyperLinkEdit")).Attributes.Add("onclick", "javascript:var iTop2 = (window.screen.availHeight - 350) / 2; var iLeft2 = (window.screen.availWidth - 600) / 2; var params = 'menubar:no;dialogHeight=200px;dialogWidth=600px;dialogLeft=' + iLeft2 + 'px;dialogTop=' + iTop2 + 'px;resizable=yes;scrollbars=0;resizeable=0;center=yes;location:no;status:no';var bLogged = showModalDialog( 'msgContent.aspx?transNumber= " + grdBuyer.DataKeys[e.Row.RowIndex].Value.ToString() + "', 'window',params);");
        //    }
        //}



    }
}