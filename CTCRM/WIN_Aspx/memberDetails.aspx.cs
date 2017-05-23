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
using CTCRM.Entity;
using CTCRM.Components;
using CTCRM.Common;
using System.Drawing;
using Top.Api.Domain;

namespace WIN_Aspx
{
    public partial class memberDetails : System.Web.UI.Page
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
                    buyer.SELLER_ID = Users.Nick;
                    buyer.BuyerNick = BuyerBLL.GetBuyerNickByID(buyerID);
                    DataTable tbBuyerBaseInfo = BuyerBLL.GetBuyerListFromDB(buyer);
                    if (tbBuyerBaseInfo != null && tbBuyerBaseInfo.Rows.Count > 0)
                    {
                        //会员基本信息
                        lbBuyerNick.Text = tbBuyerBaseInfo.Rows[0]["buyer_nick"].ToString();
                        lbBuyerLevel.Text = tbBuyerBaseInfo.Rows[0]["grade"].ToString();
                        lbBuyerStatus.Text = tbBuyerBaseInfo.Rows[0]["status"].ToString();
                        lbTradeAmount.Text = "￥"+tbBuyerBaseInfo.Rows[0]["trade_amount"].ToString();
                        //详细区域
                        txtRealName.Text = tbBuyerBaseInfo.Rows[0]["buyer_reallName"].ToString();
                        txtCellphone.Text = tbBuyerBaseInfo.Rows[0]["cellPhone"].ToString();
                        txtPhone.Text = tbBuyerBaseInfo.Rows[0]["Phone"].ToString();
                        txtQQ.Text = tbBuyerBaseInfo.Rows[0]["qq"].ToString();
                        dateBirthDay.Value = tbBuyerBaseInfo.Rows[0]["birthDay"].ToString();
                        txtZIPCode.Text = tbBuyerBaseInfo.Rows[0]["zipCode"].ToString();
                        txtEmail.Text = tbBuyerBaseInfo.Rows[0]["email"].ToString();
                        lbJifen.Text = "0";
                        txtAddress.Text = tbBuyerBaseInfo.Rows[0]["address"].ToString();
                        txtMemo.Text = tbBuyerBaseInfo.Rows[0]["memo"].ToString();
                    }
                }
            }
        }

        private void InitControls()
        {
            lbCellPhoneError.Text = "";
            lbPhoneError.Text = "";
            lbQQError.Text = "";
            lbZIPError.Text = "";
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {

            //判断输入格式
            if (!String.IsNullOrEmpty(txtCellphone.Text.Trim()) && !Utility.IsCellPhone(txtCellphone.Text.Trim()))
            {
                lbCellPhoneError.Text = "手机号码格式不正确！";
                return;
            }
            if (!String.IsNullOrEmpty(txtPhone.Text.Trim()) && !Utility.IsPhone(txtPhone.Text.Trim()))
            {
                lbPhoneError.Text = "座机号码格式不正确！";
                return;
            }
            if (!String.IsNullOrEmpty(txtQQ.Text.Trim()) && !Utility.IsNumeric(txtQQ.Text.Trim()))
            {
                lbQQError.Text = "QQ号码应该都是数字！";
                return;
            }
            if (!String.IsNullOrEmpty(txtEmail.Text.Trim()) && !Utility.IsEmail(txtEmail.Text.Trim()))
            {
                lbQQError.Text = "Email格式不正确！";
                return;
            }
            if (!String.IsNullOrEmpty(txtZIPCode.Text.Trim()) && !Utility.IsZIPCode(txtZIPCode.Text.Trim()))
            {
                lbZIPError.Text = "邮编格式不正确！";
                return;
            }
            Buyers objBuyer = new Buyers();
            objBuyer.SELLER_ID = Users.Nick;
            objBuyer.BuyerId = Convert.ToInt64(Request.QueryString["buyer_id"].ToString());
            objBuyer.Buyer_reallName = txtRealName.Text.Trim();
            objBuyer.CellPhone = txtCellphone.Text.Trim();
            objBuyer.Phone = txtPhone.Text.Trim();
            objBuyer.QQ = txtQQ.Text.Trim();
            objBuyer.birthDay = dateBirthDay.Value.ToString();
            objBuyer.Email = txtEmail.Text.Trim();
            objBuyer.ZipCode = txtZIPCode.Text.Trim();
            objBuyer.Address = txtAddress.Text.Trim();
            objBuyer.Memo = txtMemo.Text.Trim();
            if (BuyerBLL.UpdateBuyerDetails(objBuyer))
            {
                InitControls();
                lbMsg.Text = "会员信息修改成功！";
                lbMsg.ForeColor = Color.Blue;
            }
        }
    }
}
