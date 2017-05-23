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
using System.Collections.Generic;
using CTCRM.Components;
using CTCRM.Entity;
using System.Threading;

namespace CTCRM.WIN_Aspx.rate
{
    public partial class badList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //datePickerStart.Value = DateTime.Now.AddMonths(-6).ToShortDateString();
                //datePickerEnd.Value = DateTime.Now.ToShortDateString();
                this.grdbadList.DataSource = null;
                this.grdbadList.DataBind();
            }
        }

        protected void BindData()
        {
            RatingBLL objDal = new RatingBLL();
            string startDate = datePickerStart.Value;
            string endDate = datePickerEnd.Value;
            //根据分页情况将数据写入或者更新到数据库
            List<TradeRateChild> lstRate = objDal.GetSellerRate(startDate, endDate, "mandav6");
            this.grdbadList.DataSource = lstRate;
            this.grdbadList.DataBind();
        }

        protected void grdbadList_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void btnimgSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindData();
            System.Web.HttpContext.Current.Session["TotalPoolRates"] = null;
        }

    }
}