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
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Common;
using Top.Api.Util;

namespace CTCRM.admin.logtics
{
    public partial class bklst : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGINUSERNAME"] == null && !Convert.ToString(Session["LOGINUSERNAME"]).Equals("kimluo"))
            {
                Response.Redirect("~/admin/Login.aspx?");
            }
            lbmsg.Text = "";
           // BindData();
            if (!Page.IsPostBack)
            {
                //lbMsgCount.Text = "当前短信账户剩余条数：" + Mobile.GetAcountMsgCount2(); GetCountSYXuNi
                string sendStatus=  Mobile.GetCountSYXuNi();
                IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                lbMsgCount.Text = "当前短信账户剩余条数：" + resultDic["balance"].ToString();
                BindData();
            }
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string sellerNick = txtTitle.Text.Trim();
            if (string.IsNullOrEmpty(sellerNick))
            {
                lbmsg.Text = "不能为空！";
                return;
            }
            WhiteList obj = new WhiteList();
            obj.SellerNick = sellerNick;
            if (!BlcakLstBLL.ChekWhitelist(obj))
            {
                BlcakLstBLL.AddWhitelist(obj);
                lbmsg.Text = "添加成功！";
            }
            else
            {
                lbmsg.Text = "已经存在该卖家！";
            }
            BindData();
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
                string sellerNick = ((LinkButton)sender).CommandArgument;
                BlcakLstBLL.DeleteWhitelist(sellerNick);
                //重新绑定
                BindData();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void BindData()
        {
            DataTable ds = BlcakLstBLL.GetWhitelist();
            //根据分页情况将数据写入或者更新到数据库
            this.grdbadList.DataSource = ds;
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            BatchShippingBLL.AddLogisticCompany();
            Label1.Text = "同步物流公司信息成功！";
        }

    }
}
