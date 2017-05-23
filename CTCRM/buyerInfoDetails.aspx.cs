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
using CTCRM.Entity;
using Top.Api.Domain;
using CTCRM.Components.TopCRM;
using System.Collections.Generic;
using System.Drawing;

namespace CTCRM
{
    public partial class buyerInfoDetails : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var buyerID = Request.QueryString["buyer_id"].ToString();
                if (!string.IsNullOrEmpty(buyerID))
                {
                    Buyers buyer = new Buyers();
                    buyer.BuyerId = Convert.ToInt64(buyerID);
                    buyer.BuyerNick = BuyerBLL.GetBuyerNickByID(buyerID);
                    buyer.SELLER_ID = Users.Nick;
                    DataTable tbBuyerBaseInfo = BuyerBLL.GetBuyerListFromDB(buyer);
                    if (tbBuyerBaseInfo != null && tbBuyerBaseInfo.Rows.Count > 0)
                    {
                        //会员基本信息
                        lbBuyerNick.Text = tbBuyerBaseInfo.Rows[0]["buyer_nick"].ToString();
                        lbBuyerLevel.Text = tbBuyerBaseInfo.Rows[0]["grade"].ToString();
                        lbBuyerStatus.Text = tbBuyerBaseInfo.Rows[0]["status"].ToString();
                        lbTradeAmount.Text = tbBuyerBaseInfo.Rows[0]["trade_amount"].ToString();
                        lbTradeCount.Text = tbBuyerBaseInfo.Rows[0]["trade_count"].ToString();
                        lbTradeProductCount.Text = tbBuyerBaseInfo.Rows[0]["item_num"].ToString();
                        lbCloseTradeCount.Text = tbBuyerBaseInfo.Rows[0]["close_trade_count"].ToString();
                        lbCloseTradeAmount.Text = tbBuyerBaseInfo.Rows[0]["close_trade_amount"].ToString();
                        if (lbCloseTradeAmount.Text != "0.00")
                        {
                            lbCloseTradeAmount.ForeColor = Color.Red;
                        }
                        lbBuyerCredit.Text = tbBuyerBaseInfo.Rows[0]["buyer_credit"].ToString();
                        if (!string.IsNullOrEmpty(lbBuyerCredit.Text))
                        {
                            imgcredit.ImageUrl = "Images/credit/" + lbBuyerCredit.Text.Trim() + ".png";
                            lbBuyerCredit.Visible = false;
                        }
                        else {
                            lbBuyerCredit.Visible = true;
                            imgcredit.Visible = false;
                        }

                        lbisRefund.Text = tbBuyerBaseInfo.Rows[0]["hasRefund"].ToString();
                        if (lbisRefund.Text.Equals("是"))
                        {
                            lbisRefund.ForeColor = Color.Red;
                        }
                        lbRealName.Text = tbBuyerBaseInfo.Rows[0]["buyer_reallName"].ToString();
                        lbCellPhone.Text = tbBuyerBaseInfo.Rows[0]["cellPhone"].ToString();
                        lbQQ.Text = tbBuyerBaseInfo.Rows[0]["qq"].ToString();
                        lbPhone.Text = tbBuyerBaseInfo.Rows[0]["Phone"].ToString();
                        lbAddress.Text = tbBuyerBaseInfo.Rows[0]["address"].ToString();
                        lbZipCode.Text = tbBuyerBaseInfo.Rows[0]["zipCode"].ToString();
                        lbBirthDay.Text = tbBuyerBaseInfo.Rows[0]["birthDay"].ToString();
                        lbmemo.Text = tbBuyerBaseInfo.Rows[0]["memo"].ToString();  
                    }
                } 
            }
        }


    }
}