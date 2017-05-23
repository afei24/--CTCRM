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
    public partial class unpay : System.Web.UI.Page
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
            //if (!MsgBLL.CheckSellerMsgStatus())
            //{
            //    msgAcountCheck.Visible = true;
            //}
            //else
            //{
            //    msgAcountCheck.Visible = false;
            //}
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

        #region 下单未交易成功的会员
        /// <summary>
        /// 下单未交易成功的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgunpay_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetUnPayBuyersCount(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbunpay.Text = tb.Rows.Count.ToString() + "人";
               
            }
            else
            {
                lbunpay.Text = "0人";
              
            }
            btnimgunpay.Visible = false;
            lbunpay.Visible = true;
        }
        #endregion

        #region 下单7天内还未付款的会员
        /// <summary>
        /// 下单7天内还未付款的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnunpay7days_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetUnPay7DaysBuyersCount(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbunpay7days.Text = tb.Rows.Count.ToString() + "人";
              
            }
            else
            {
                lbunpay7days.Text = "0人";
              
            }
            imgbtnunpay7days.Visible = false;
            lbunpay7days.Visible = true;

        }
        #endregion
    }
}