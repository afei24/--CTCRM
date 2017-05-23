using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTCRM.Components;


namespace CTCRM.WIN_Aspx
{
    public partial class win_memberMsg_old : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bt_seach_Click(object sender, EventArgs e)
        {

            string buyerNick = tbx_nick.Text.Trim();;
            string lastTradeDate1 = tbx_trade_start.Value.Trim();
            string lastTradeDate2 = tbx_trade_end.Value.Trim();
            string grade = ddl_level.SelectedValue.ToString();
            string num1 = tbx_buy_count01.Text.Trim();
            string num2 =tbx_buy_count02.Text.Trim();
            string area =  ddl_province.SelectedValue.ToString();
            string tradeAmount1=tbx_money01.Text.Trim();
             string tradeAmount2=tbx_money02.Text.Trim();
            string tradePinNv = ddl_pinlv.SelectedValue.ToString();
            string buyCount = tbx_buy_count.Text.Trim();
            string drpDay = "";
            drpDay = ddl_day.SelectedValue.ToString();
            DataTable ds = BuyerBLL.GetBuyerInfoToMsg(buyerNick, lastTradeDate1, lastTradeDate2, grade, num1, num2,
                area, tradeAmount1, tradeAmount2, Users.Nick, drpDay, tradePinNv, buyCount);
            Session["MsgData"] = ds;
            if (ds != null && ds.Rows.Count > 10000)
            {
                //string msgC = "亲~本次群发会员数为：" + ds.Rows.Count.ToString() + " 个,注意检查短信账户余额!由于数据过大，会员数据不会显示在下面的列表中，请直接群发！";
                gv_member.DataSource = ds.DefaultView;
                gv_member.DataBind();
            }
            else
            {
                //if (ds != null && ds.Rows.Count > 0)
                //{
                //    string msgC = "亲~能发送短信的有效客户数有：" + ds.Rows.Count.ToString() + " 个,注意检查短信账户余额是否足够，以及是否已经同步了店铺所有会员信息!";
                //}
            }
        }

        void loadData()
        { 
        
        }
    }
}