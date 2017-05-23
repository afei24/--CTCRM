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
using Top.Api;
using Top.Api.Request;
using CTCRM.Components.TopCRM;
using Top.Api.Response;
using Top.Api.Domain;
using CTCRM.Common;
using System.Collections.Generic;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.member
{
    public partial class retureGoods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbMsg.Text = "";
            lbMsg2.Text = "";
            msgAcountCheck.Visible = false;
        }

        private void OpenMsgService()
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
            }
        }

        private void CloseMsgService()
        {
            if (AppCusBLL.CheckAppCusIsExit(Users.Nick))
            {
                ITopClient client = TBManager.GetClient();
                TmcUserCancelRequest req = new TmcUserCancelRequest();
                req.Nick = Users.Nick;
                TmcUserCancelResponse response = client.Execute(req);
                if (response.IsSuccess)
                {
                    AppCusBLL.DeleteSellerNifty(Users.Nick);
                }
            }
        }

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

        protected void btnByhand_Click(object sender, ImageClickEventArgs e)
        {

            if (!CheckIsOpenMsgAcount())
            { return; }

            string cellPhone = txtCellPhone.Text.Trim();
            if (string.IsNullOrEmpty(cellPhone))
            {
                lbMsg2.Text = "请填写手机号码内容！";
                txtCellPhone.Focus();
                return;
            }
            if (!Utility.IsCellPhone(cellPhone))
            {
                lbMsg2.Text = "请填写正确的手机号码内容！";
                txtCellPhone.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtByHandContent.Text.Trim()))
            {
                lbMsg.Text = "提醒内容不能为空！";
                txtByHandContent.Focus();
                return;
            }
            if (MsgBLL.CheckSellerMsgStatus())
            {
                MsgSendHis objHis = new MsgSendHis();
                objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + cellPhone;//手机号码
                objHis.SellerNick = Users.Nick;
                objHis.Buyer_nick = "*****";
                objHis.CellPhone = cellPhone;
                objHis.SendDate = DateTime.Now;
                objHis.SendType = "手工退货提醒发送";
                objHis.SendStatus = "0";
                objHis.MsgContent = "【" + SellersBLL.GetSignName(Users.Nick) + "】" + txtByHandContent.Text.Trim();
                objHis.HelpSellerNick = "";
                if (SmartBLL.AddMsgSendHis(objHis))
                {
                    try
                    {
                        List<string> lstCellPhoneNo = new List<string>();
                        lstCellPhoneNo.Add(cellPhone.ToString());
                        if (objHis.MsgContent.Length <= 70)
                        {
                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                        }
                        else if (objHis.MsgContent.Length > 70 && objHis.MsgContent.Length <= 134)
                        {
                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                        }
                        else if (objHis.MsgContent.Length > 134 && objHis.MsgContent.Length <= 195)
                        {
                            MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                        }
                        string sendStatus = Mobile.sendMsgReminder(lstCellPhoneNo, objHis.MsgContent);  
                    }
                    catch (Exception ex)
                    {
                        ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                    }
                }
                lbmsg5.Text = "提醒发送成功";
                txtCellPhone.Text = "";
                txtCellPhone.Focus();
            }
        }
    }
}
