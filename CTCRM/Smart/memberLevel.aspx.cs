using CTCRM.Common;
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
    public partial class memberLevel : System.Web.UI.Page
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
        protected void imgbtnPuTongBuyer_Click(object sender, ImageClickEventArgs e)
        {
            //初始化买家会员级别
            DataTable tbbuyerlevel = SmartBLL.GetBuyersCount(1, Users.SellerId);
            if (tbbuyerlevel != null)
            {
                 lbPuTongBuyerCount.Text = tbbuyerlevel.Rows.Count.ToString() + "人";
            }
            else
            {
                lbPuTongBuyerCount.Text = "0人";
            }
            imgbtnPuTongBuyer.Visible = false;
            lbPuTongBuyerCount.Visible = true;
        }

        protected void imgbtnGaoJiBuyerCount_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tbbuyerlevel = SmartBLL.GetBuyersCount(2, Users.SellerId);
            if (tbbuyerlevel != null)
            {
                lbGaoJiBuyersCount.Text = tbbuyerlevel.Rows[2]["grade"].ToString() + "人";
            }
            else
            {
                lbGaoJiBuyersCount.Text = "0人";
            }
            imgbtnGaoJiBuyerCount.Visible = false;
            lbGaoJiBuyersCount.Visible = true;
        }

        protected void imgbtnVIPBuyersCount_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tbbuyerlevel = SmartBLL.GetBuyersCount(3, Users.SellerId);
            if (tbbuyerlevel != null)
            {
                lbVIPBuyersCount.Text = tbbuyerlevel.Rows[3]["grade"].ToString() + "人";
            }
            else
            {
                lbVIPBuyersCount.Text = "0人";
            }
            imgbtnVIPBuyersCount.Visible = false;
            lbVIPBuyersCount.Visible = true;
        }

        protected void imgbtnGoJiVIP_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tbbuyerlevel = SmartBLL.GetBuyersCount(4, Users.SellerId);
            if (tbbuyerlevel != null)
            {
                lbGaoJiVIPBuyersCount.Text = tbbuyerlevel.Rows[4]["grade"].ToString() + "人";
            }
            else
            {
                lbGaoJiVIPBuyersCount.Text = "0人";
            }
            imgbtnGoJiVIP.Visible = false;
            lbGaoJiVIPBuyersCount.Visible = true;
        }
    }
}