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
using Top.Api.Domain;
using CTCRM.Components;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;
using CTCRM.Common;
using System.Drawing;
using CTCRM.Components.TopCRM;
using System.Collections.Generic;

namespace CTCRM
{
    public partial class addbuyer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbResult.Text = "";
            lberror.Text = "";
            lbPhoneError.Text = "";
            lbCellPhoneError.Text = "";
            lbQQError.Text = "";
            lbZIPError.Text = "";
            lbMsg.Text = "";
            lbResult.Text = "";
        }

        protected void imgSubmit_Click(object sender, ImageClickEventArgs e)
        {
            //判断输入格式
            if (!String.IsNullOrEmpty(txtCellphone.Text.Trim()) && !Utility.IsCellPhone(txtCellphone.Text.Trim()))
            {
                lbCellPhoneError.Text = "手机号码格式不正确！";
                return;
            }
            if (string.IsNullOrEmpty(txtCellphone.Text.Trim()))
            {
                lbCellPhoneError.Text = "手机号码不能为空！";
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

            //相同手机号码只能添加一次
            if (BuyerBLL.CheckTheSameHPNoIsExit(Users.Nick, txtCellphone.Text.Trim()))
            {
                lbMsg.Text = "手机号码重复,系统已经存在该号码！";
                lbMsg.ForeColor = Color.Red;
                txtCellphone.Focus();
                return;
            }

            Buyers objBuyer = new Buyers();
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            objBuyer.BuyerId = Convert.ToInt64(ran.Next().ToString());
            objBuyer.SELLER_ID = Users.Nick;
            objBuyer.BuyerNick = txtNick.Text.Trim();
            objBuyer.Buyer_reallName = txtRealName.Text.Trim();
            objBuyer.CellPhone = txtCellphone.Text.Trim();
            objBuyer.Phone = txtPhone.Text.Trim();
            objBuyer.QQ = txtQQ.Text.Trim();
            objBuyer.MSN = txtMSN.Text.Trim();
            objBuyer.ZipCode = txtZIPCode.Text.Trim();
            objBuyer.Email = txtEmail.Text.Trim();
            objBuyer.SinaWeibo = txtsinaWeibo.Text.Trim();
            objBuyer.QQWeibo = txtQQWeibo.Text.Trim();
            objBuyer.BuyerProvince = drpArea.SelectedValue.ToString();
            objBuyer.City = txtCity.Text.Trim();
            objBuyer.birthDay = datebirthday.Value.ToString(); 
            objBuyer.BuyerType = "2";
            try
            {
                if (BuyerBLL.AddBuyerBySeller(objBuyer))
                {
                    lbMsg.Text = "会员信息添加成功！";
                    lbMsg.ForeColor = Color.Blue;
                    txtCellphone.Focus();
                    txtCellphone.Text = "";
                }
            }
            catch (Exception ex)
            {
                lbMsg.Text = "添加会员失败！";
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);

            } 
        }

        //protected void btnSave2_Click(object sender, ImageClickEventArgs e)
        //{
        //    string taobaoUsers = txtTaobaoUser.Text.Trim();
        //    if (!string.IsNullOrEmpty(taobaoUsers))
        //    {
        //        TBBuyer objTb = new TBBuyer();
        //        List<User> tbUsers = objTb.GetBuyersInfo(taobaoUsers);
        //        if (tbUsers != null && tbUsers.Count > 0)
        //        { //查询出其他店铺买家的基本信息，写入DB
        //            try
        //            {
        //                foreach (User user in tbUsers)
        //                {
        //                    Buyers objBuyer = new Buyers();
        //                    long tick = DateTime.Now.Ticks;
        //                    Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
        //                    objBuyer.BuyerId = Convert.ToInt64(ran.Next().ToString());
        //                    objBuyer.SELLER_ID = Users.Nick;
        //                    objBuyer.BuyerNick = user.Nick;
        //                    objBuyer.Province = user.Location.State;
        //                    objBuyer.City = user.Location.City;
        //                    objBuyer.Buyer_credit = user.BuyerCredit.Level.ToString();
        //                    objBuyer.Address = user.Location.Address;
        //                    objBuyer.BuyerType = "1";
        //                    BuyerBLL.AddBuyerOtherShop(objBuyer);
        //                }
        //                lbResult.Text = "会员信息添加成功！";
        //                lbResult.ForeColor = Color.Blue;
        //                txtTaobaoUser.Text = "";
        //                txtTaobaoUser.Focus();
        //            }
        //            catch (Exception ex)
        //            {
        //                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
        //                lbResult.Text = "添加会员失败！";
        //            }
        //        }
        //        else
        //        {
        //            lbResult.Text = "添加会员失败！";
        //        }
        //    }
        //    else
        //    {
        //        txtTaobaoUser.Focus();
        //        lberror.Text = "请输入淘宝用户昵称！";
        //    }
        //}
    }
}
