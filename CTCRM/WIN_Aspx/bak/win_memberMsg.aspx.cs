using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTCRM.Components;
using System.Web.Script.Services;


namespace CTCRM.WIN_Aspx
{
    public partial class win_memberMsg : System.Web.UI.Page
    {
        public static string member_num ="0";
        public static string userNick = "未知";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //userNick = Users.Nick;
            }
        }
        DataTable ds = null;
        protected void bt_seach_Click(object sender, EventArgs e)
        {

            //string buyerNick = tbx_nick.Text.Trim();
            //string lastTradeDate1 = tbx_trade_start.Value.Trim();
            //string lastTradeDate2 = tbx_trade_end.Value.Trim();
            //string grade = ddl_level.SelectedValue.ToString();
            //string num1 = tbx_buy_count01.Text.Trim();
            //string num2 = tbx_buy_count02.Text.Trim();
            //string area = ddl_province.SelectedValue.ToString();
            //string tradeAmount1 = tbx_money01.Text.Trim();
            //string tradeAmount2 = tbx_money02.Text.Trim();
            //string tradePinNv = ddl_pinlv.SelectedValue.ToString();
            //string buyCount = tbx_buy_count.Text.Trim();
            //string drpDay = "";
            ////drpDay = ddl_day.SelectedValue.ToString();
            //ds = BuyerBLL.GetBuyerInfoToMsg(buyerNick, lastTradeDate1, lastTradeDate2, grade, num1, num2,
            //   area, tradeAmount1, tradeAmount2, "cuud旗舰店", drpDay, tradePinNv, buyCount);
            //Session["MsgData"] = ds;
            //if (ds != null && ds.Rows.Count > 0)
            //{
            //    //string msgC = "亲~本次群发会员数为：" + ds.Rows.Count.ToString() + " 个,注意检查短信账户余额!由于数据过大，会员数据不会显示在下面的列表中，请直接群发！";
            //    gv_member.DataSource = ds.DefaultView;
            //    gv_member.DataBind();
            //    //lb_memberNum.Text = ds.Rows.Count.ToString() + "个会员";
            //    member_num = ds.Rows.Count.ToString();
            //}
            //else
            //{
            //    //lb_memberNum.Text = "0个会员";
            //}
        }

        void loadData()
        {
            //if (ds != null && ds.Rows.Count > 0)
            //{
            //    gv_member.DataSource = ds.DefaultView;
            //    gv_member.DataBind();
            //}
        }

        protected void gv_member_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gv_member.PageIndex = e.NewPageIndex;
            //loadData();
        }

        protected void gv_member_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#999999'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                ((Label)e.Row.Cells[3].FindControl("lb_serial")).Text = (e.Row.RowIndex + 1).ToString();
                CheckBox cb = ((CheckBox)e.Row.Cells[3].FindControl("cbx_select"));
                cb.Checked = true;
                cb.Attributes.Add("onclick", "ChangeGet(" + cb.Checked + ")");
                //e.Row.Attributes["onclick"] = chk.ClientID + ".checked=!" + chk.ClientID + ".checked;";
                ////停止事件冒泡，防止选中状态混乱
                //chk.Attributes["onclick"] = "window.event.cancelBubble = true;";
            }
        }

        void ChangeGet(bool  po)
        { 
        
        }


        protected void cbx_select_CheckedChanged(object sender, EventArgs e)
        {
            int i = Convert.ToInt16(member_num);
            if (((CheckBox)sender).Checked == true)
            {
                member_num = (i + 1).ToString();
            }
            else
            {
                if (i > 0)
                {
                    member_num = (i - 1).ToString();
                }
            }
        }

        protected void gv_member_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cbx")
            {
                int i = Convert.ToInt16(member_num);
                if (((CheckBox)sender).Checked == true)
                {
                    member_num = (i + 1).ToString();
                }
                else
                {
                    if (i > 0)
                    {
                        member_num = (i - 1).ToString();
                    }
                }
            }
        }

      
       
    }
}