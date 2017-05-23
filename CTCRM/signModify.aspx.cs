using CTCRM.Components;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM
{
    public partial class signModify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             lbSignPrv.Text = "【" + SellersBLL.GetSignName(Users.Nick) + "】"; 
        }

        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string signName = txtSign.Text.Trim();
            if (string.IsNullOrEmpty(signName))
            {
                lbMsg.Text = "店铺签名不能为空！";
                lbMsg.ForeColor = Color.Red;
                return;
            }
            if (signName.Length > 15)
            {
                lbMsg.Text = "店铺签名不能超过15个字符！";
                lbMsg.ForeColor = Color.Red;
                return;
            }
            if (!string.IsNullOrEmpty(signName))
            {
                Sellers objSell = new Sellers();
                objSell.Nick = Users.Nick;
                objSell.SignShopName = signName;
                objSell.Cellphone = "";
                if (SellersBLL.SetShopName(objSell)) {
                    lbMsg.Text = "修改成功！";
                    Page_Load(sender, e);
                }
            }
        }
    }
}