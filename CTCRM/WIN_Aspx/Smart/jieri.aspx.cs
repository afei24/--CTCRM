using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.WIN_Aspx.Smart
{
    public partial class jieri : System.Web.UI.Page
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

        #region 元旦活动
        /// <summary>
        /// 元旦活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnYuanDan_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-01-01  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-01-01  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbYuanDan.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbYuanDan.Text = "0人";
            }
            btnYuanDan.Visible = false;
            lbYuanDan.Visible = true;
        }
        #endregion

        #region 情人节活动
        /// <summary>
        /// 情人节活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnQinRen_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-02-14  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-02-14  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbQinRen.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbQinRen.Text = "0人";

            }
            btnQinRen.Visible = false;
            lbQinRen.Visible = true;
        }

        #endregion

        #region 妇女节活动
        /// <summary>
        /// 妇女节活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnFuNv_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-03-18  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-03-18  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbFuNv.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbFuNv.Text = "0人";

            }
            btnFuNv.Visible = false;
            lbFuNv.Visible = true;
        }
        #endregion

        #region 五一劳动节活动
        /// <summary>
        /// 五一劳动节活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnwuyi_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-05-01  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-05-01  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbwuyi.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbwuyi.Text = "0人";

            }
            btnwuyi.Visible = false;
            lbwuyi.Visible = true;
        }
        #endregion

        #region 父亲节活动
        /// <summary>
        /// 父亲节活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnfuqin_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-06-17  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-06-17  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbfuqin.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbfuqin.Text = "0人";

            }
            imgbtnfuqin.Visible = false;
            lbfuqin.Visible = true;
        }
        #endregion

        #region 七夕情人节
        /// <summary>
        /// 七夕情人节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnqixi_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-08-23  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-08-23  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbqixi.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbqixi.Text = "0人";

            }
            imgbtnqixi.Visible = false;
            lbqixi.Visible = true;
        }
        #endregion

        #region 中秋节
        /// <summary>
        /// 中秋节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnzhongqiu_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-09-30  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-09-30  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbzhongqiu.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbzhongqiu.Text = "0人";

            }
            imgbtnzhongqiu.Visible = false;
            lbzhongqiu.Visible = true;
        }
        #endregion

        #region 国庆节
        /// <summary>
        /// 国庆节
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnguoqing_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-10-01  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-10-01  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbguoqing.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbguoqing.Text = "0人";

            }
            imgbtnguoqing.Visible = false;
            lbguoqing.Visible = true;
        }
        #endregion

        #region 双11活动
        /// <summary>
        /// 双11活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn11_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-11-11  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-11-11  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lb11.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lb11.Text = "0人";

            }
            imgbtn11.Visible = false;
            lb11.Visible = true;
        }
        #endregion

        #region 双12活动
        /// <summary>
        /// 双12活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtn12_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-12-12  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-12-12  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lb12.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lb12.Text = "0人";

            }
            imgbtn12.Visible = false;
            lb12.Visible = true;

        }
        #endregion

        #region 圣诞节活动
        /// <summary>
        /// 圣诞节活动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgshengdan_Click(object sender, ImageClickEventArgs e)
        {
            string date = DateTime.Now.AddYears(-1).Year.ToString() + "-12-25  00:00:00.000";
            string date2 = DateTime.Now.Year.ToString() + "-12-25  00:00:00.000";
            DataTable tb = SmartBLL.GetHuoDongBuyersCount(date, Users.SellerId, date2);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbshengdan.Text = tb.Rows.Count.ToString() + "人";

            }
            else
            {
                lbshengdan.Text = "0人";

            }
            btnimgshengdan.Visible = false;
            lbshengdan.Visible = true;
        }
        #endregion
    }
}