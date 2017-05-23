using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Smart
{
    public partial class area : System.Web.UI.Page
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
        #region 北方地区
        /// <summary>
        /// 北方地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgBaiFang_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetBaiFangBuyersCount(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbBaiFang.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbBaiFang.Text = "0人";
            }
            lbBaiFang.Visible = true;
            btnimgBaiFang.Visible = false;
        }
        #endregion

        #region 南方地区
        /// <summary>
        /// 南方地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnNanfang_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetNanFangBuyersCount(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbNanfang.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbNanfang.Text = "0人";
            }
            lbNanfang.Visible = true;
            imgbtnNanfang.Visible = false;

        }
        #endregion
    
    }
}