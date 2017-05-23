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
using CTCRM.Common;
using System.Drawing;
using CTCRM.Entity;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM
{
    public partial class systemSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //会员基本级别划分
                //ControlStatus(false);
                CTCRM.Entity.Grade o = new CTCRM.Entity.Grade();
                o.SellerNick = Users.Nick;
                DataTable tb = BuyerBLL.GetGradeByID(o);
                if (tb != null && tb.Rows.Count > 0)
                {
                    txtMin1.Text = tb.Rows[0]["tradeAmontFrom"].ToString();
                    txtMax1.Text = tb.Rows[0]["tradeAmountTo"].ToString();
                    txtMin2.Text = tb.Rows[1]["tradeAmontFrom"].ToString();
                    txtMax2.Text = tb.Rows[1]["tradeAmountTo"].ToString();
                    txtMin3.Text = tb.Rows[2]["tradeAmontFrom"].ToString();
                    txtMax3.Text = tb.Rows[2]["tradeAmountTo"].ToString();
                    txtMin4.Text = tb.Rows[3]["tradeAmontFrom"].ToString();
                    txtMax4.Text = tb.Rows[3]["tradeAmountTo"].ToString();
                }
                versionControl.Visible = false;             
            }
        }

        private void ControlStatus(Boolean flag)
        {

            txtMin1.Enabled = flag;
            txtMin2.Enabled = flag;
            txtMin3.Enabled = flag;
            txtMin4.Enabled = flag;
            txtMax1.Enabled = flag;
            txtMax2.Enabled = flag;
            txtMax3.Enabled = flag;
            txtMax4.Enabled = flag;
        }

        protected void imgModify_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(txtMin1.Text.Trim()))
            {
                lbError1.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMin1.Text.Trim()))
            {
                lbError1.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMax1.Text.Trim()))
            {
                lbError1.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMax1.Text.Trim()))
            {
                lbError1.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }


            if (String.IsNullOrEmpty(txtMin2.Text.Trim()))
            {
                lbError2.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMin2.Text.Trim()))
            {
                lbError2.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMax2.Text.Trim()))
            {
                lbError2.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMax2.Text.Trim()))
            {
                lbError2.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMin2.Text.Trim()))
            {
                lbError2.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMin2.Text.Trim()))
            {
                lbError2.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMax2.Text.Trim()))
            {
                lbError2.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMax2.Text.Trim()))
            {
                lbError2.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMin3.Text.Trim()))
            {
                lbError3.Text = "金额不能为空！";
                lbMsg.Text = "";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMin3.Text.Trim()))
            {
                lbError3.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMax3.Text.Trim()))
            {
                lbError3.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMax3.Text.Trim()))
            {
                lbError3.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMin4.Text.Trim()))
            {
                lbError4.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMin4.Text.Trim()))
            {
                lbError4.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }

            if (String.IsNullOrEmpty(txtMax4.Text.Trim()))
            {
                lbError4.Text = "金额不能为空！";
                lbMsg.Text = "";
                return;
            }
            if (!Utility.IsPositiveINT(txtMax4.Text.Trim()))
            {
                lbError4.Text = "金额必须为整数！";
                lbMsg.Text = "";
                return;
            }
            try
            {
                ControlStatus(true);
                CTCRM.Entity.Grade o = new CTCRM.Entity.Grade();
                o.SellerNick = Users.Nick;
                DataTable tb = BuyerBLL.GetGradeByID(o);
                bool showLbMsg = true;
                if (tb != null && tb.Rows.Count > 0)
                {
                    o.Id = Convert.ToInt32(tb.Rows[0]["id"].ToString());
                    o.TradeAmontFrom = Convert.ToInt32(txtMin1.Text.Trim().ToString());
                    o.TradeAmountTo = Convert.ToInt32(txtMax1.Text.Trim().ToString());
                    BuyerBLL.UpdateGrade(o);
                    o.Id = Convert.ToInt32(tb.Rows[1]["id"].ToString());
                    o.TradeAmontFrom = Convert.ToInt32(txtMin2.Text.Trim().ToString());
                    o.TradeAmountTo = Convert.ToInt32(txtMax2.Text.Trim().ToString());
                    BuyerBLL.UpdateGrade(o);
                    o.Id = Convert.ToInt32(tb.Rows[2]["id"].ToString());
                    o.TradeAmontFrom = Convert.ToInt32(txtMin3.Text.Trim().ToString());
                    o.TradeAmountTo = Convert.ToInt32(txtMax3.Text.Trim().ToString());
                    BuyerBLL.UpdateGrade(o);
                    o.Id = Convert.ToInt32(tb.Rows[3]["id"].ToString());
                    o.TradeAmontFrom = Convert.ToInt32(txtMin4.Text.Trim().ToString());
                    o.TradeAmountTo = Convert.ToInt32(txtMax4.Text.Trim().ToString());
                    BuyerBLL.UpdateGrade(o);
                    //控制更新提示标签的状态
                    if (Convert.ToInt32(tb.Rows[0]["tradeAmontFrom"].ToString()) == Convert.ToInt32(txtMin1.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[0]["tradeAmountTo"].ToString()) == Convert.ToInt32(txtMax1.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[1]["tradeAmontFrom"].ToString()) == Convert.ToInt32(txtMin2.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[1]["tradeAmountTo"].ToString()) == Convert.ToInt32(txtMax2.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[2]["tradeAmontFrom"].ToString()) == Convert.ToInt32(txtMin3.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[2]["tradeAmountTo"].ToString()) == Convert.ToInt32(txtMax3.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[3]["tradeAmontFrom"].ToString()) == Convert.ToInt32(txtMin4.Text.Trim().ToString())
                        && Convert.ToInt32(tb.Rows[3]["tradeAmountTo"].ToString()) == Convert.ToInt32(txtMax4.Text.Trim().ToString())
                        )
                    {
                        showLbMsg = false;
                    }
                }
                if (showLbMsg)
                {
                    lbMsg.Text = "会员级别调整成功！";
                }
                lbMsg.ForeColor = Color.Blue;
                // ControlStatus(false);
                //更新成功后，同步会员的级别
                DataTable tbBuyer = BuyerBLL.GetBuyerInfoBySellerNick(Users.Nick);
                if (tbBuyer != null && tbBuyer.Rows.Count > 0)
                {
                    for (int i = 0; i < tbBuyer.Rows.Count; i++)
                    {
                        var tradeAmount = tbBuyer.Rows[i]["trade_amount"].ToString();
                        Buyers obj = new Buyers();
                        obj.BuyerId = Convert.ToInt64(tbBuyer.Rows[i]["buyer_id"].ToString());
                        obj.SELLER_ID = Users.Nick;
                        if (Convert.ToDecimal(tradeAmount) > Convert.ToInt32(txtMin1.Text.Trim().ToString()) && Convert.ToDecimal(tradeAmount) <= Convert.ToInt32(txtMax1.Text.Trim().ToString()))
                        {
                            obj.Grade = 1;
                        }
                        if (Convert.ToDecimal(tradeAmount) > Convert.ToInt32(txtMin2.Text.Trim().ToString()) && Convert.ToDecimal(tradeAmount) <= Convert.ToInt32(txtMax2.Text.Trim().ToString()))
                        {
                            obj.Grade = 2;
                        }
                        if (Convert.ToDecimal(tradeAmount) > Convert.ToInt32(txtMin3.Text.Trim().ToString()) && Convert.ToDecimal(tradeAmount) <= Convert.ToInt32(txtMax3.Text.Trim().ToString()))
                        {
                            obj.Grade = 3;
                        }
                        if (Convert.ToDecimal(tradeAmount) > Convert.ToInt32(txtMin4.Text.Trim().ToString()) && Convert.ToDecimal(tradeAmount) <= Convert.ToInt32(txtMax4.Text.Trim().ToString()))
                        {
                            obj.Grade = 4;
                        }
                        BuyerBLL.UpdateGrade(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "会员级别调整失败！";
                lbMsg.ForeColor = Color.Red;
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

    }
}
