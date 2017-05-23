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
using System.Drawing;
using CTCRM.Entity;
using CTCRM.Common;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using Top.Api.Domain;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;

namespace CTCRM.WIN_Aspx.member
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MaintainScrollPositionOnPostBack = true;
            if (!Page.IsPostBack)
            {
                //初始化短信发送条件配置
                MsgSendConfig o = new MsgSendConfig();
                o.SellerNick = Users.Nick;

                if (!MemberNotifyBLL.CheckMsgConfigIsExit(o))
                {
                    o.BuyerLevel = 0;
                    o.Amount = "0";

                    o.UnPayType = "0";
                    o.PayType = "0";
                    o.ShippingType = "0";
                    o.DelayShippingType = "0";
                    o.ArrivedType = "0";
                    o.SignType = "0";
                    o.ReturnGoodsType = "0";

                    o.UnpayMsg = rdounpayTemp1.Text.Trim();
                    o.PayMsg = rdoPayType1.Text.Trim();
                    o.ShippingNofityMsg = rdoShippingCont1.Text.Trim();
                    o.DelayShippingNofityMsg = rdoDelayShipping.Text.Trim();
                    o.ArrivedNofityMsg = RadioButton4.Text.Trim();
                    o.SignNofityMsg = rdoSign1.Text.Trim();
                    o.ReturnGoodsMsg = "";
                    o.ShopName = SellersBLL.GetSignName(Users.Nick);
                    MemberNotifyBLL.AddMsgConfig(o);
                }
                else
                {
                    InitAutoControl(o);
                }

                if (AppCusBLL.CheckAppCusIsExit(Users.Nick))
                {
                    btnAuothOpen.ImageUrl = "~/Images/rate/2open.png";
                }
                lbShopSignPre.Text = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
            }
            lbMsg.Text = "";
            lberror2.Text = "";
            lberror.Text = "";
            lbSignMsg.Text = "";
            versionControl.Visible = false;
            if (!Utility.CheckCanSendEmail())
            {
                msgReminder.Visible = true;
            }
            else
            {
                msgReminder.Visible = false;
            }
            msgAcountCheck.Visible = false;

        }

        /// <summary>
        /// 检查卖家当前短信账户状态
        /// </summary>
        private Boolean CheckIsOpenMsgAcount()
        {
            //短信账户判断
            if (!MsgBLL.CheckSellerMsgStatus())
            {
                msgAcountCheck.Visible = true;
                return false;
            }
            else
            {
                msgAcountCheck.Visible = false;
            }
            return true;
        }

        private void InitAutoControl(MsgSendConfig o)
        {
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                //未付款提醒
                if (tb.Rows[0]["unPayType"].ToString().Equals("1"))
                {
                    btnimgAutoStart.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnimgAutoStart.ImageUrl = "~/Images/work_off.gif";
                }
                //付款提醒
                if (tb.Rows[0]["payType"].ToString().Equals("1"))
                {
                    btnimgUnconfirmType.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnimgUnconfirmType.ImageUrl = "~/Images/work_off.gif";
                }

                //发货通知
                if (tb.Rows[0]["shippingType"].ToString().Equals("1"))
                {
                    btnimgshippingType.ImageUrl = "~/Images/work_on.gif";
                    //rdoShipingStatus(true);
                }
                else
                {
                    btnimgshippingType.ImageUrl = "~/Images/work_off.gif";
                    //rdoShipingStatus(false);
                }
                //延迟发货
                if (tb.Rows[0]["delayShippingType"].ToString().Equals("1"))
                {
                    btnDelayShipping.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnDelayShipping.ImageUrl = "~/Images/work_off.gif";
                }

                //达到提醒
                if (tb.Rows[0]["arrivedType"].ToString().Equals("1"))
                {
                    btnArrivedType.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnArrivedType.ImageUrl = "~/Images/work_off.gif";
                }
                //签收
                if (tb.Rows[0]["signType"].ToString().Equals("1"))
                {
                    imgbtnSign.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    imgbtnSign.ImageUrl = "~/Images/work_off.gif";
                }

                //回款
                if (tb.Rows[0]["huiZJType"].ToString().Equals("1"))
                {
                    btnHuiZJ.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnHuiZJ.ImageUrl = "~/Images/work_off.gif";
                }

                //催款
                if (rdounpayTemp1.Text.Equals(tb.Rows[0]["unpayMsg"].ToString()))
                {
                    rdounpayTemp1.Checked = true;
                }
                if (rdounpayTemp2.Text.Equals(tb.Rows[0]["unpayMsg"].ToString()))
                {
                    rdounpayTemp2.Checked = true;
                }
                if (rdounpayTemp3.Text.Equals(tb.Rows[0]["unpayMsg"].ToString()))
                {
                    rdounpayTemp3.Checked = true;
                }
                if (tb.Rows[0]["isUnpayMsgCus"].ToString().Equals("1"))
                {
                    rdoUnpayCus.Checked = true;
                }
                txtUnpayCusContent.Text = tb.Rows[0]["unpayMsgCus"].ToString();

                //付款
                if (rdoPayType1.Text.Equals(tb.Rows[0]["payMsg"].ToString()))
                {
                    rdoPayType1.Checked = true;
                }
                if (rdoPayType2.Text.Equals(tb.Rows[0]["payMsg"].ToString()))
                {
                    rdoPayType2.Checked = true;
                }
                if (rdoPayType3.Text.Equals(tb.Rows[0]["payMsg"].ToString()))
                {
                    rdoPayType3.Checked = true;
                }
                if (tb.Rows[0]["isPayMsgCus"].ToString().Equals("1"))
                {
                    rdoPayTypeCus.Checked = true;
                }
                txtPayCus.Text = tb.Rows[0]["payMsgCus"].ToString();

                //发货
                if (rdoShippingCont1.Text.Equals(tb.Rows[0]["shippingNofityMsg"].ToString()))
                {
                    rdoShippingCont1.Checked = true;
                }
                if (rdoShippingCont2.Text.Equals(tb.Rows[0]["shippingNofityMsg"].ToString()))
                {
                    rdoShippingCont2.Checked = true;
                }
                if (rdoShippingCont3.Text.Equals(tb.Rows[0]["shippingNofityMsg"].ToString()))
                {
                    rdoShippingCont3.Checked = true;
                }
                if (tb.Rows[0]["isShippingMsgCus"].ToString().Equals("1"))
                {
                    rdoShiping.Checked = true;
                }
                txtShippingContent.Text = tb.Rows[0]["shippingNofityMsgCus"].ToString();

                //延迟发货
                if (rdoDelayShipping.Text.Equals(tb.Rows[0]["delayShippingNofityMsg"].ToString()))
                {
                    rdoDelayShipping.Checked = true;
                }
                if (tb.Rows[0]["isDelayShippingMsgCus"].ToString().Equals("1"))
                {
                    rdoDelayShipCus.Checked = true;
                }
                txtDelayShippingCus.Text = tb.Rows[0]["delayShippingNofityMsgCus"].ToString();

                //达到
                if (RadioButton4.Text.Equals(tb.Rows[0]["arrivedNofityMsg"].ToString()))
                {
                    RadioButton4.Checked = true;
                }
                if (RadioButton5.Text.Equals(tb.Rows[0]["arrivedNofityMsg"].ToString()))
                {
                    RadioButton5.Checked = true;
                }
                if (RadioButton6.Text.Equals(tb.Rows[0]["arrivedNofityMsg"].ToString()))
                {
                    RadioButton6.Checked = true;
                }
                if (tb.Rows[0]["isArrivedMsgCus"].ToString().Equals("1"))
                {
                    RadioButton7.Checked = true;
                }
                txtArrivedContent.Text = tb.Rows[0]["arrivedNofityMsgCus"].ToString();

                //签收
                if (rdoSign1.Text.Equals(tb.Rows[0]["signNofityMsg"].ToString()))
                {
                    rdoSign1.Checked = true;
                }
                if (rdoSign2.Text.Equals(tb.Rows[0]["signNofityMsg"].ToString()))
                {
                    rdoSign2.Checked = true;
                }
                if (rdoSign3.Text.Equals(tb.Rows[0]["signNofityMsg"].ToString()))
                {
                    rdoSign3.Checked = true;
                }
                if (tb.Rows[0]["isSignMsgCus"].ToString().Equals("1"))
                {
                    rdoSignCus.Checked = true;
                }
                txtSignCus.Text = tb.Rows[0]["signNotifyMsgCus"].ToString();

                //回款
                if (rdoHuiZJCont.Text.Equals(tb.Rows[0]["huiZJNofityMsg"].ToString()))
                {
                    rdoHuiZJCont.Checked = true;
                }
                if (tb.Rows[0]["isHuiZJMsgCus"].ToString().Equals("1"))
                {
                    rdoHuiZJCus.Checked = true;
                }
                txtHuiZJContent.Text = tb.Rows[0]["huiZJNofityMsgCus"].ToString();

                txtArrivedContent.Text = tb.Rows[0]["arrivedNofityMsgCus"].ToString();
                txtAmount.Text = tb.Rows[0]["amount"].ToString();
            }
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //检查输入项的值是否正确
                if (String.IsNullOrEmpty(txtAmount.Text.Trim())) { lberror2.Text = "金额不能为空！"; return; }
                if (!Utility.IsINT(txtAmount.Text.Trim())) { lberror2.Text = "金额必须为正整数！"; return; }
                MsgSendConfig o = new MsgSendConfig();
                o.SellerNick = Users.Nick;
                o.ShopName = SellersBLL.GetSignName(Users.Nick);
                string strUnpayType = "0";
                string payType = "0";
                string shippingType = "0";
                string arrivedType = "0";
                string signType = "0";
                string delayShipType = "0";
                string huiZJType = "0";

                DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
                if (tb != null && tb.Rows.Count > 0)
                {
                    strUnpayType = tb.Rows[0]["unPayType"].ToString();
                    payType = tb.Rows[0]["payType"].ToString();
                    shippingType = tb.Rows[0]["shippingType"].ToString();
                    arrivedType = tb.Rows[0]["arrivedType"].ToString();
                    signType = tb.Rows[0]["signType"].ToString();
                    delayShipType = tb.Rows[0]["delayShippingType"].ToString();
                    huiZJType = tb.Rows[0]["huiZJType"].ToString();
                }

                #region 催款

                string strUnpayMsg = "";

                string unpayMsgCus = "";
                string isUnpayMsgCus = "0";

                if (rdounpayTemp1.Checked)
                {
                    strUnpayMsg = rdounpayTemp1.Text.Trim();
                }
                if (rdounpayTemp2.Checked)
                {
                    strUnpayMsg = rdounpayTemp2.Text.Trim();
                }
                if (rdounpayTemp3.Checked)
                {
                    strUnpayMsg = rdounpayTemp3.Text.Trim();
                }
                if (rdoUnpayCus.Checked)
                {
                    unpayMsgCus = txtUnpayCusContent.Text.Trim();
                    isUnpayMsgCus = "1";
                }
                else
                {
                    unpayMsgCus = "";
                    isUnpayMsgCus = "0";
                }
                o.UnpayMsg = strUnpayMsg;
                o.UnPayType = strUnpayType;
                o.UnpayMsgCus = unpayMsgCus;
                o.IsUnpayMsgCus = isUnpayMsgCus;
                #endregion

                #region 付款

                string payMsg = "";
                string payMsgCus = "";
                string isPayMsgCus = "0";

                if (rdoPayType1.Checked)
                {
                    payMsg = rdoPayType1.Text.Trim();
                }
                if (rdoPayType2.Checked)
                {
                    payMsg = rdoPayType2.Text.Trim();
                }
                if (rdoPayType3.Checked)
                {
                    payMsg = rdoPayType3.Text.Trim();
                }
                if (rdoPayTypeCus.Checked)
                {
                    payMsgCus = txtPayCus.Text.Trim();
                    isPayMsgCus = "1";
                }
                else
                {
                    payMsgCus = "";
                    isPayMsgCus = "0";
                }
                o.PayMsg = payMsg;
                o.PayType = payType;
                o.PayMsgCus = payMsgCus;
                o.IsPayMsgCus = isPayMsgCus;

                #endregion

                #region 发货

                string shippingNofityMsg = "";
                string shippingNofityMsgCus = "";
                string isShippingMsgCus = "0";

                if (rdoShippingCont1.Checked)
                {
                    shippingNofityMsg = rdoShippingCont1.Text.Trim();
                }
                if (rdoShippingCont2.Checked)
                {
                    shippingNofityMsg = rdoShippingCont2.Text.Trim();
                }
                if (rdoShippingCont3.Checked)
                {
                    shippingNofityMsg = rdoShippingCont3.Text.Trim();
                }
                if (rdoShiping.Checked)
                {
                    shippingNofityMsgCus = txtShippingContent.Text.Trim();
                    isShippingMsgCus = "1";
                }
                else
                {
                    shippingNofityMsgCus = "";
                    isShippingMsgCus = "0";
                }
                o.ShippingNofityMsg = shippingNofityMsg;
                o.ShippingType = shippingType;
                o.ShippingNofityMsgCus = shippingNofityMsgCus;
                o.IsShippingMsgCus = isShippingMsgCus;
                #endregion

                #region 延时发货

                string delayShippingNofityMsg = "";
                string delayShippingNofityMsgCus = "";
                string isDelayShippingMsgCus = "0";

                if (rdoDelayShipping.Checked)
                {
                    delayShippingNofityMsg = rdoDelayShipping.Text.Trim();
                }
                if (rdoDelayShipCus.Checked)
                {
                    delayShippingNofityMsgCus = txtDelayShippingCus.Text.Trim();
                    isDelayShippingMsgCus = "1";
                }
                else
                {
                    delayShippingNofityMsgCus = "";
                    isDelayShippingMsgCus = "0";
                }
                o.DelayShippingNofityMsg = delayShippingNofityMsg;
                o.DelayShippingType = delayShipType;
                o.DelayShippingNofityMsgCus = delayShippingNofityMsgCus;
                o.IsDelayShippingMsgCus = isDelayShippingMsgCus;
                #endregion

                #region 达到

                string arrivedNofityMsg = "";
                string arrivedNofityMsgCus = "";
                string isArrivedMsgCus = "0";

                if (RadioButton4.Checked)
                {
                    arrivedNofityMsg = RadioButton4.Text.Trim();
                }
                if (RadioButton5.Checked)
                {
                    arrivedNofityMsg = RadioButton5.Text.Trim();
                }
                if (RadioButton6.Checked)
                {
                    arrivedNofityMsg = RadioButton6.Text.Trim();
                }
                if (RadioButton7.Checked)
                {
                    arrivedNofityMsgCus = txtArrivedContent.Text.Trim();
                    isArrivedMsgCus = "1";
                }
                else
                {
                    arrivedNofityMsgCus = "";
                    isArrivedMsgCus = "0";
                }
                o.ArrivedNofityMsg = arrivedNofityMsg;
                o.ArrivedType = arrivedType;
                o.ArrivedNofityMsgCus = arrivedNofityMsgCus;
                o.IsArrivedMsgCus = isArrivedMsgCus;
                #endregion

                #region 签收

                string signNofityMsg = "";

                string signNotifyMsgCus = "";
                string isSignMsgCus = "0";
                if (rdoSign1.Checked)
                {
                    signNofityMsg = rdoSign1.Text.Trim();
                }
                if (rdoSign2.Checked)
                {
                    signNofityMsg = rdoSign2.Text.Trim();
                }
                if (rdoSign3.Checked)
                {
                    signNofityMsg = rdoSign3.Text.Trim();
                }
                if (rdoSignCus.Checked)
                {
                    signNotifyMsgCus = txtSignCus.Text.Trim();
                    isSignMsgCus = "1";
                }
                else
                {
                    signNotifyMsgCus = "";
                    isSignMsgCus = "0";
                }
                o.SignNofityMsg = signNofityMsg;
                o.SignType = signType;
                o.SignNotifyMsgCus = signNotifyMsgCus;
                o.IsSignMsgCus = isSignMsgCus;
                #endregion

                #region 回款

                string huiZJNofityMsg = "";

                string huiZJNotifyMsgCus = "";
                string isHuiZJMsgCus = "0";
                if (rdoHuiZJCont.Checked)
                {
                    huiZJNofityMsg = rdoHuiZJCont.Text.Trim();
                }

                if (rdoHuiZJCus.Checked)
                {
                    huiZJNotifyMsgCus = txtHuiZJContent.Text.Trim();
                    isHuiZJMsgCus = "1";
                }
                else
                {
                    huiZJNotifyMsgCus = "";
                    isHuiZJMsgCus = "0";
                }
                o.HuiZJNofityMsg = huiZJNofityMsg;
                o.HuiZJType = huiZJType;
                o.HuiZJNofityMsgCus = huiZJNotifyMsgCus;
                o.IsHuiZJMsgCus = isHuiZJMsgCus;
                #endregion

                //if (tb != null && tb.Rows.Count > 0)
                //{
                o.Amount = txtAmount.Text.Trim().ToString();
                o.BuyerLevel = 0;
                if (MemberNotifyBLL.UpdateMsgConfig(o))
                {
                    lbMsg.Text = "条件保存成功！";
                    lbMsg.ForeColor = Color.Blue;
                }
                else
                {
                    lbMsg.Text = "条件保存失败，请联系客服";
                }
                //}
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                lbMsg.Text = "条件保存失败，请联系客服";
            }
        }

        /// <summary>
        /// unpay付款提醒自动通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgAutoStart_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strUnpayMsg = "";
            if (rdounpayTemp1.Checked)
            {
                strUnpayMsg = rdounpayTemp1.Text.Trim();
            }
            if (rdounpayTemp2.Checked)
            {
                strUnpayMsg = rdounpayTemp2.Text.Trim();
            }
            if (rdounpayTemp3.Checked)
            {
                strUnpayMsg = rdounpayTemp3.Text.Trim();
            }
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["unPayType"].ToString().Equals("1"))
                {
                    o.UnPayType = "0";
                    btnimgAutoStart.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnimgAutoStart.ImageUrl = "~/Images/work_off.gif";
                    o.UnPayType = "1";
                }
                o.UnpayMsg = strUnpayMsg;
                if (rdoUnpayCus.Checked)
                {
                    o.UnpayMsgCus = txtUnpayCusContent.Text.Trim();
                    o.IsUnpayMsgCus = "1";
                }
                else
                {
                    o.UnpayMsgCus = "";
                    o.IsUnpayMsgCus = "0";
                }
                MemberNotifyBLL.UpdateUnPayMsgConfig(o);
                InitAutoControl(o);
            }

        }

        /// <summary>
        /// 付款短信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgUnconfirmType_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string payMsg = "";
            if (rdoPayType1.Checked)
            {
                payMsg = rdoPayType1.Text.Trim();
            }
            if (rdoPayType2.Checked)
            {
                payMsg = rdoPayType2.Text.Trim();
            }
            if (rdoPayType3.Checked)
            {
                payMsg = rdoPayType3.Text.Trim();
            }
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["payType"].ToString().Equals("1"))//unConfirmType：此后的业务意思是付款提醒字段
                {
                    o.PayType = "0";
                    btnimgUnconfirmType.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnimgUnconfirmType.ImageUrl = "~/Images/work_off.gif";
                    o.PayType = "1";
                }
                //o.Amount = tb.Rows[0]["amount"].ToString();
                //o.BuyerLevel = int.Parse(tb.Rows[0]["buyerLevel"].ToString());
                o.PayMsg = payMsg;
                if (rdoPayTypeCus.Checked)
                {
                    o.PayMsgCus = txtPayCus.Text.Trim();
                    o.IsPayMsgCus = "1";
                }
                else
                {
                    o.PayMsgCus = "";
                    o.IsPayMsgCus = "0";
                }
                MemberNotifyBLL.UpdatePayMsgConfig(o);
                InitAutoControl(o);
            }
        }

        /// <summary>
        /// 发货通知
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgshippingType_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strShippingMsg = "";
            if (rdoShippingCont1.Checked)
            {
                strShippingMsg = rdoShippingCont1.Text.Trim();
            }
            if (rdoShippingCont2.Checked)
            {
                strShippingMsg = rdoShippingCont2.Text.Trim();
            }
            if (rdoShippingCont3.Checked)
            {
                strShippingMsg = rdoShippingCont3.Text.Trim();
            }
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["shippingType"].ToString().Equals("1"))
                {
                    o.ShippingType = "0";
                    btnimgshippingType.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnimgshippingType.ImageUrl = "~/Images/work_off.gif";
                    o.ShippingType = "1";
                }
                o.ShippingNofityMsg = strShippingMsg;
                if (rdoShiping.Checked)
                {
                    o.ShippingNofityMsgCus = txtShippingContent.Text.Trim();
                    o.IsShippingMsgCus = "1";
                }
                else
                {
                    o.ShippingNofityMsgCus = "";
                    o.IsShippingMsgCus = "0";
                }
                MemberNotifyBLL.UpdateShippingMsgConfig(o);
                InitAutoControl(o);
            }
        }

        #region 授权
        protected void btnAuothOpen_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                DataRow orderDate = SellersBLL.GetSelerOrderDate(Users.Nick);
                if (orderDate != null)
                {
                    if (orderDate["OrderVersion"].Equals("体验版"))
                    {
                        Response.Redirect("http://crm.new9channel.com/version/versionTip.aspx");
                        return;
                    }

                    if (AppCusBLL.CheckAppCusIsExit(Users.Nick))
                    {
                        ITopClient client = TBManager.GetClient();
                        TmcUserCancelRequest req = new TmcUserCancelRequest();
                        req.Nick = Users.Nick;
                        TmcUserCancelResponse response = client.Execute(req);
                        if (response.IsSuccess)
                        {
                            AppCusBLL.DeleteSellerNifty(Users.Nick);
                            btnAuothOpen.ImageUrl = "~/Images/rate/closed.png";
                        }
                        else
                        {
                            lberror.Text = response.ErrMsg;
                        }
                    }
                    else
                    {
                        ITopClient client = TBManager.GetClient();
                        TmcUserPermitRequest req = new TmcUserPermitRequest();
                        TmcUserPermitResponse response = client.Execute(req, Users.SessionKey);
                        AppCustomer appCus = null;
                        if (response.IsSuccess)
                        {
                            appCus = new AppCustomer();
                            appCus.Status = "1";
                            appCus.Nick = Users.Nick;
                            appCus.Created = DateTime.Now.ToShortDateString();
                            AppCusBLL.AddAppCus(appCus);
                            btnAuothOpen.ImageUrl = "~/Images/rate/2open.png";
                        }
                        else
                        {
                            lberror.Text = response.ErrMsg;
                        }
                    }
                    btnAuothOpen.Width = Unit.Pixel(80);
                    btnAuothOpen.Height = Unit.Pixel(25);
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }

        }
        #endregion

        /// <summary>
        /// 到达提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnArrivedType_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strArrieMsg = "";
            if (RadioButton4.Checked)
            {
                strArrieMsg = RadioButton4.Text.Trim();
            }
            if (RadioButton5.Checked)
            {
                strArrieMsg = RadioButton5.Text.Trim();
            }
            if (RadioButton6.Checked)
            {
                strArrieMsg = RadioButton6.Text.Trim();
            }
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["arrivedType"].ToString().Equals("1"))
                {
                    o.ArrivedType = "0";
                    btnArrivedType.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnArrivedType.ImageUrl = "~/Images/work_off.gif";
                    o.ArrivedType = "1";
                }
                o.ArrivedNofityMsg = strArrieMsg;
                if (RadioButton7.Checked)
                {
                    o.ArrivedNofityMsgCus = txtArrivedContent.Text.Trim();
                    o.IsArrivedMsgCus = "1";
                }
                else
                {
                    o.ArrivedNofityMsgCus = "";
                    o.IsArrivedMsgCus = "0";
                }
                MemberNotifyBLL.UpdateArrivedMsgConfig(o);
                InitAutoControl(o);
            }
        }

        /// <summary>
        /// 签收
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnSign_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strSignMsg = "";
            if (rdoSign1.Checked)
            {
                strSignMsg = rdoSign1.Text.Trim();
            }
            if (rdoSign2.Checked)
            {
                strSignMsg = rdoSign2.Text.Trim();
            }
            if (rdoSign3.Checked)
            {
                strSignMsg = rdoSign3.Text.Trim();
            }
            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["signType"].ToString().Equals("1"))
                {
                    o.SignType = "0";
                    imgbtnSign.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    imgbtnSign.ImageUrl = "~/Images/work_off.gif";
                    o.SignType = "1";
                }
                o.SignNofityMsg = strSignMsg;
                if (rdoSignCus.Checked)
                {
                    o.SignNotifyMsgCus = txtSignCus.Text.Trim();
                    o.IsSignMsgCus = "1";
                }
                else
                {
                    o.SignNotifyMsgCus = "";
                    o.IsSignMsgCus = "0";
                }
                MemberNotifyBLL.UpdateSignMsgConfig(o);
                InitAutoControl(o);
            }
        }

        /// <summary>
        /// 延时发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnDelayShipping_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strDelayMsg = "";
            if (rdoDelayShipping.Checked)
            {
                strDelayMsg = rdoDelayShipping.Text.Trim();
            }

            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["delayShippingType"].ToString().Equals("1"))
                {
                    o.DelayShippingType = "0";
                    btnDelayShipping.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnDelayShipping.ImageUrl = "~/Images/work_off.gif";
                    o.DelayShippingType = "1";
                }
                o.DelayShippingNofityMsg = strDelayMsg;
                if (rdoDelayShipCus.Checked)
                {
                    o.DelayShippingNofityMsgCus = txtDelayShippingCus.Text.Trim();
                    o.IsDelayShippingMsgCus = "1";
                }
                else
                {
                    o.DelayShippingNofityMsgCus = "";
                    o.IsDelayShippingMsgCus = "0";
                }
                MemberNotifyBLL.UpdateDelayShippingMsgConfig(o);
                InitAutoControl(o);
            }
        }

        /// <summary>
        /// 回款提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnHuiZJ_Click(object sender, ImageClickEventArgs e)
        {
            if (!CheckIsOpenMsgAcount())
            { return; }

            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            string strHuiZJMsg = "";
            if (rdoHuiZJCont.Checked)
            {
                strHuiZJMsg = rdoHuiZJCont.Text.Trim();
            }

            DataTable tb = MemberNotifyBLL.GetMsgConfigByBuyerSellerNick(o);
            if (tb != null && tb.Rows.Count > 0)
            {
                if (tb.Rows[0]["huiZJType"].ToString().Equals("1"))
                {
                    o.HuiZJType = "0";
                    btnHuiZJ.ImageUrl = "~/Images/work_on.gif";
                }
                else
                {
                    btnHuiZJ.ImageUrl = "~/Images/work_off.gif";
                    o.HuiZJType = "1";
                }
                o.HuiZJNofityMsg = strHuiZJMsg;
                if (rdoHuiZJCus.Checked)
                {
                    o.HuiZJNofityMsgCus = txtHuiZJContent.Text.Trim();
                    o.IsHuiZJMsgCus = "1";
                }
                else
                {
                    o.HuiZJNofityMsgCus = "";
                    o.IsHuiZJMsgCus = "0";
                }
                MemberNotifyBLL.UpdateHuiZJMsgConfig(o);
                InitAutoControl(o);
            }
        }

        protected void imgBtnSetSign_Click(object sender, ImageClickEventArgs e)
        {
            if (String.IsNullOrEmpty(txtShopSign.Text.Trim())) { lbSignMsg.Text = "自定义签名不能为空！"; return; }
            Sellers objSell = new Sellers();
            objSell.Nick = Users.Nick;
            objSell.SignShopName = txtShopSign.Text.Trim();
            objSell.Cellphone = "";
            if (SellersBLL.SetShopName(objSell))
            {
                lbSignMsg.Text = "签名修改成功,物流提醒将使用此签名！";
                lbSignMsg.ForeColor = Color.Blue;
                lbShopSignPre.Text = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
            }
            else
            {
                lbSignMsg.Text = "签名保存失败,联系客服！";
            }
        }
    }
}