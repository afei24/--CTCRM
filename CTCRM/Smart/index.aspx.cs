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
using Top.Api.Domain;
using CTCRM.Common;
using System.Threading;

namespace CTCRM.Smart
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HiddenField1.Value = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
                //if (RatingBLL.isBshop(Users.Nick))
                //{
                //    HiddenField1.Value = "【天猫】";
                //}
                //else
                //{
                //    HiddenField1.Value = "【淘宝】";
                //}
            }
            //检查卖家短信账户
            if (!MsgBLL.CheckSellerMsgStatus())
            {
                msgAcountCheck.Visible = true;
            }
            else
            {
                msgAcountCheck.Visible = false;
            }
            GetMsgCount();
        }
        private void GetMsgCount()
        {
            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbMsgCount.Text = "剩余短信：" + tb.Rows[0]["msgCanUseCount"].ToString() + "条";
            }
            else
            {
                lbMsgCount.Text = "剩余短信：0条";
            }
        }
       
        #region 最近10天新会员
         /// <summary>
        /// 最近10天新会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tbnewBuyer10 = SmartBLL.GetNewBuyer10Days(Users.SellerId);
            if (tbnewBuyer10 != null && tbnewBuyer10.Rows.Count > 0)
            {
                lbUserCount.Text = tbnewBuyer10.Rows.Count.ToString() + "人";
                
            }
            else
            {
                lbUserCount.Text = "0人";
               
            }
            ImageButton1.Visible = false;
            lbUserCount.Visible = true;
        }

        #endregion

        #region 最近30天新会员
        /// <summary>
        /// 最近30天新会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tbnewBuyer30 = SmartBLL.GetNewBuyer30Days(Users.SellerId);
            if (tbnewBuyer30 != null && tbnewBuyer30.Rows.Count > 0)
            {
                lbUserCount30.Text = tbnewBuyer30.Rows.Count.ToString() + "人";       
            }
            else
            {
                lbUserCount30.Text = "0人";
            }
            ImageButton4.Visible = false;
            lbUserCount30.Visible = true;
        }

        #endregion

    }
}
