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
using System.Drawing;
using CTCRM.Entity;
using CTCRM.Components;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM
{
    public partial class blacklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
            lbMsg.Text = "";

        }

        protected void BindData()
        {
            DataTable ds = BlcakLstBLL.GetBlaklist(Users.Nick);
            //根据分页情况将数据写入或者更新到数据库
            this.grdbadList.DataSource = ds;
            this.grdbadList.DataBind();
            if (ds != null && ds.Rows.Count > 0)
            {
                lbCount.Text = ds.Rows.Count.ToString();
            }
            else
            {
                lbCount.Text = "0";
            }
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
        /// <summary>
        /// 允许事件单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Allow_click(object sender, EventArgs e)
        {
            try
            {
                string blakLstID = ((LinkButton)sender).CommandArgument;
                BlcakLstBLL.DeleteBlaklist(blakLstID);
                //重新绑定
                BindData();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
        protected void imgbtnSave_Click(object sender, ImageClickEventArgs e)
        {
            string blakList = txtBlackList.Text.Trim();
            if (string.IsNullOrEmpty(blakList))
            {
                lbMsg.Text = "黑名单内容不能为空！";
                lbMsg.ForeColor = Color.Red;
                txtBlackList.Focus();
                return;
            }
            string[] sArray = blakList.Split(',');

            BlakList objList = null;
            if (sArray.Length > 0)
            {
                for (int i = 0; i < sArray.Length; i++)
                {
                    objList = new BlakList();
                    objList.SellerNick = Users.Nick;
                    objList.BlakName = sArray[i].ToString();
                    objList.OperType = drpOperType.SelectedValue.ToString();
                    if (!BlcakLstBLL.ChekBlaklist(objList))
                    {
                        BlcakLstBLL.AddBlaklist(objList);
                    }
                }
            }
            lbMsg.Text = "添加成功！";
            lbMsg.ForeColor = Color.Blue;
            BindData();
        }
    }
}
