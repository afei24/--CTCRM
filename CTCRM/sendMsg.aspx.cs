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
using System.Threading;
using System.IO;
using System.Drawing;
using CTCRM.Common;
using CTCRM.Entity;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Collections.Generic;
using Top.Api.Util;

namespace CTCRM
{
    public partial class sendMsg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MsgDataBind();
                //if (RatingBLL.isBshop(Users.Nick))
                //{
                //    HiddenField1.Value = "【天猫】";
                //}
                //else {
                //    HiddenField1.Value = "【淘宝】";
                //}
               
                HiddenField1.Value = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
            }
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            lbMsg.Text = "";
        }

        private void MsgDataBind()
        {
            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(Users.Nick);
            if (String.IsNullOrEmpty(checkIsExit) || !Convert.ToBoolean(checkIsExit))//账户未开通
            {
                imgMsgISCanUse.ImageUrl = "../Images/cannotuse.png";
                imgMsgISCanUse.ToolTip = "短信账户尚未开通";
            }
            else
            {//账户开通
                imgMsgISCanUse.ImageUrl = "../Images/canuse.png";
                imgMsgISCanUse.ToolTip = "短信账户已开通";
            }
            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbMsgCanUseCount.Text = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
            }
            else
            {
                lbMsgCanUseCount.Text = "0条";
            }
        }
    }
}

