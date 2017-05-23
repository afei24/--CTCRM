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
    public partial class huoyue : System.Web.UI.Page
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
        #region 活跃度较低但购买力较强的会员
        /// <summary>
        /// 活跃度较低但购买力较强的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnHuoYueDiGouMaiDi_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetHuoYueDiGouMaiQiangBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbHuoYueDiGouMaiQiang.Text = tb.Rows.Count.ToString() + "人";
            
            }
            else
            {
                lbHuoYueDiGouMaiQiang.Text = "0人";
             
            }
            imgbtnHuoYueDiGouMaiDi.Visible = false;
            lbHuoYueDiGouMaiQiang.Visible = true;

        }
        #endregion

        #region 活跃度一般购物能力也一般的会员
        /// <summary>
        /// 活跃度一般购物能力也一般的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnHuoYueYiBan_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetHuoYueBanGouMaiBanBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbHuoYueYiBan.Text = tb.Rows.Count.ToString() + "人";            
            }
            else
            {
                lbHuoYueYiBan.Text = "0人";      
            }
            imgbtnHuoYueYiBan.Visible = false;
            lbHuoYueYiBan.Visible = true;
        }
        #endregion

        #region 活跃度高购物能力一般的会员
        /// <summary>
        /// 活跃度高购物能力一般的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void benimgHuoYueGaoGouBan_Click(object sender, ImageClickEventArgs e)
        {  
            DataTable tb = SmartBLL.GetHuoYueGaoGouMaiBanBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbHuoYueGaoGouMaiBan.Text = tb.Rows.Count.ToString() + "人";
              
            }
            else
            {
                lbHuoYueGaoGouMaiBan.Text = "0人";
              
            }
            benimgHuoYueGaoGouBan.Visible = false;
            lbHuoYueGaoGouMaiBan.Visible = true;
        }
        #endregion

        #region 活跃度高且购物能力强的会员
        /// <summary>
        /// 活跃度高且购物能力强的会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnHuoYueGaoGouGao_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetHuoYueGaoGouMaiGaoBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbGaoGao.Text = tb.Rows.Count.ToString() + "人";
               
            }
            else
            {
                lbGaoGao.Text = "0人";
               
            }
            imgbtnHuoYueGaoGouGao.Visible = false;
            lbGaoGao.Visible = true;

        }
        #endregion
    }
}