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
using CTCRM.Entity;

namespace CTCRM.rate
{
    public partial class blacklist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void BindData()
        {
            RatingBLL objDal = new RatingBLL();
            DataTable ds = objDal.GetBlakListByNick(Users.Nick);
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

        protected void btnImgAddBlakList_Click(object sender, ImageClickEventArgs e)
        {
            RatingBLL objDal = new RatingBLL();
            int blakCount = objDal.GetBlakListCount(Users.Nick);
            if (blakCount > 10000)
            {
                Response.Write("<script>alert('添加黑名单数已达上限！');</script>");
                return;
            }
            string blakList = txtBlackList.Text.Trim();
            if (string.IsNullOrEmpty(blakList) || blakList.Equals("请输入黑名单"))
            {
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
                    if (!objDal.ChekBlaklist(objList))
                    {
                        objDal.AddBlaklist(objList);
                    }
                }
            }
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
                RatingBLL objDal = new RatingBLL();
                string blakLstID = ((LinkButton)sender).CommandArgument;
                objDal.DeleteBlaklist(blakLstID);
                //重新绑定
                BindData();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
    }
}
