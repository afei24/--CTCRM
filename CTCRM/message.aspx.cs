using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CTCRM.Components;
using CTCRM.Common;
using System.Drawing;
using CTCRM.Entity;
using System.Collections.Generic;
using System.Threading;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM
{
   
    public partial class message : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetMsgCount();               
                
                HiddenField1.Value = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
               
            }
                cbNotSendYD.Visible = false;
                lbMsgTip.Text = "";
                lbError.Text = ""; 
                lbSaveMsgInfo.Text = "";
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
        protected void btnMsgSend_Click(object sender, ImageClickEventArgs e)
        {
            BindData();
        }

        protected string CheckBuyerLevel(string value)
        {
            if (value.Equals("1")) { return "普通会员"; }
            if (value.Equals("2")) { return "高级会员"; }
            if (value.Equals("3")) { return "VIP会员"; }
            if (value.Equals("4")) { return "至尊VIP会员"; }
            return "潜在会员";
        }

        protected void BindData()
        {
            string buyerNick = txtNickName.Text.Trim();
            string lastTradeDate1 = datePicker.Value.Trim();
            string lastTradeDate2 = datePickerEnd.Value.Trim();
            string grade = drpGrade.SelectedValue.ToString();
            string num1 = txtNum1.Text.Trim();
            string num2 = txtNum2.Text.Trim();
            string area = drpArea.SelectedValue.ToString();
            string tradeAmount1 = txtTradAmount1.Text.Trim();
            string tradeAmount2 = txtTradAmount2.Text.Trim();
            string tradePinNv = drpTradePinNv.SelectedValue.ToString();
            string buyCount = txtBuyCount.Text.Trim();
            string drpDay ="";
            if(cbDays.Checked){
                drpDay = drpSendDays.SelectedValue.ToString();
            }

            DataTable ds = BuyerBLL.GetBuyerInfoToMsg(buyerNick, lastTradeDate1, lastTradeDate2, grade, num1, num2,
                area, tradeAmount1, tradeAmount2, Users.Nick, drpDay, tradePinNv, buyCount);
            Session["MsgData"] = ds;
            if (ds != null && ds.Rows.Count > 10000)
            {
                string msgC = "亲~本次群发会员数为：" + ds.Rows.Count.ToString() + " 个,注意检查短信账户余额!由于数据过大，会员数据不会显示在下面的列表中，请直接群发！";
                lbMsgTip.Text = msgC;
              
            }
            else
            {
                if (ds != null && ds.Rows.Count > 0)
                {
                    string msgC = "亲~能发送短信的有效客户数有：" + ds.Rows.Count.ToString() + " 个,注意检查短信账户余额是否足够，以及是否已经同步了店铺所有会员信息!";
                    lbMsgTip.Text = msgC;
                }
            }
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            BindData();
        }
        protected void btnOfflineSend_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("sendMsg.aspx", true);
        }
    }
}
