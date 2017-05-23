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
    public partial class index1 : System.Web.UI.Page
    {
        public static DataTable tb = null;
        const string notPalyMsg = "亲！您**下单时间**拍的宝贝小店已为您备好，付款后我们立即发货，谢谢光临!";
        const string palyMsg = "亲爱的主人,感谢您拍下宝贝啦，店家会在3个工作日内将我送出哟，偶一定不贪玩，一般2到5天就会飞奔到你了身边了哦";
        const string deliveryMsg = "亲，时刻关心您的购物心情，您在我店购买的宝贝已于**发货时间**由**快递公司**：**快递单号**发货，欢迎下次光临";
        const string delayMsg = "亲爱的主人,感谢您拍下宝贝啦，店家会在3个工作日内将我送出哟，偶一定不贪玩，一般2到5天就会飞奔到你了身边了哦";
        const string arrivedMsg = "亲，您的宝贝已到**当前位置**，请注意查收。";
        const string singMsg = "亲爱的**收货人**,物流显示您的订单已签收，如对产品服务满意,请全打5分好评鼓励我们;如果不满意，请联系我们。祝您生活愉快";
        const string receivableMsg = "亲爱的**收货人**，我们的交易已经成功，希望您能确认+好评，我们才有充裕的资金流转,来提高店铺质量和服务，祝您生活愉快！";
        public string shopName = string.Empty;
        public static string mark = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.MaintainScrollPositionOnPostBack = true;
            shopName = SellersBLL.GetSignName(Users.Nick);
            users.Value = shopName;
            if (!Page.IsPostBack)
            {
                string type = string.Empty;
                if (Request.QueryString["type"] != null)
                {
                    type = Request.QueryString["type"].ToString();
                }
                else
                {
                    type = "notplay";
                }
                //初始化短信发送条件配置
                MsgSendConfig o = new MsgSendConfig();
                o.warnType = type;
                mark = type;
                //o.SellerNick = "TestAcc001";
                o.SellerNick = Users.Nick;
                if (MemberNotifyBLL.CheckMsgConfigTypeIsExit(o))
                {
                    InitAutoControl(o);
                }
                else
                {
                    clearValue(o.warnType);
                }
            }
        }
     
        //初始化
        private void InitAutoControl(MsgSendConfig o)
        {
            clearValue(o.warnType);
            tb = MemberNotifyBLL.getWarnInfo(o.SellerNick,o.warnType);
            Label25.Text = getNameByType(o.warnType);
            lb_phoneMsg.Text = "【" + shopName + "】"+ getMsgByType(o.warnType);
            mark = o.warnType;
            if (tb != null && tb.Rows.Count > 0)
            {
                //是否开启
                int ret = Convert.ToInt16(tb.Rows[0]["unPayType"] == DBNull.Value ? 0 : tb.Rows[0]["unPayType"]);
                if (ret == 1)
                {
                    radio_off.Checked = false;
                    radio_on.Checked = true;
                }
                else
                {
                    radio_on.Checked = false;
                    radio_off.Checked = true;
                }
                //短信内容
                txt_div_nopay_msg.Text = Convert.ToString(tb.Rows[0]["unpayMsg"]);
                //发送短信的金额条件
                txtAmount.Text = Convert.ToString(tb.Rows[0]["amount"]);
                txtAmount01.Text = Convert.ToString(tb.Rows[0]["amountMax"]);
                //txtAmount01.Text = tb.Rows[0]["amountMax"].ToString();
                //黑名单
                string blacklist = Convert.ToString(tb.Rows[0]["blackListType"]);
                if (blacklist.Equals("1"))
                {
                    cbx_blackList.Checked = true;
                }
                ////3天内发送过的会员
                if (Convert.ToString(tb.Rows[0]["threeDayType"]).Equals("1"))
                {
                    cbx_threeDay.Checked = true;
                }
                ////顾虑的地区不发送
                if (Convert.ToString(tb.Rows[0]["areaType"]).Equals("1"))
                {
                    cbx_area.Checked = true;
                    tbx_area.Text = Convert.ToString(tb.Rows[0]["areaList"]);
                }
            }
        }

        void clearValue(string type)
        {
            radio_on.Checked = false;
            radio_off.Checked = true;
            txtAmount.Text = "0";
            txtAmount01.Text = "0";
            cbx_area.Checked = false;
            cbx_blackList.Checked = false;
            cbx_threeDay.Checked = false;
            tbx_area.Text = "";
            txt_div_nopay_msg.Text =getMsgByType(type);
            Label25.Text = getNameByType(type);
            lb_phoneMsg.Text = "【" + shopName + "】" + txt_div_nopay_msg.Text;
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {
            bool isOk = false;
            MsgSendConfig msc = getMsgObj();
            msc.warnType = mark;
            int amount = 0;
            int amount01 = 0;
            try
            {
                amount = Convert.ToInt32(txtAmount.Text.Trim());
                amount01 = Convert.ToInt32(txtAmount01.Text.Trim());
                if (amount >= amount01)
                {
                    Alert("请输入正确的订单金额！");
                }
            }
            catch
            {
                Alert("请输入正确的金额！");
                return;
            }
            msc.Amount = amount.ToString();
            msc.AmountMax = amount01.ToString();
            //是否开启提醒  统一使用UnPayType作为短信内容
            if (radio_on.Checked)
            {
                msc.UnPayType = "1";
            }
            else {
                msc.UnPayType = "0";
            }
            //是否开启黑名单过滤
            if (cbx_blackList.Checked == true)
            {
                msc.blackListType = 1;
            }
            else
            {
                msc.blackListType = 0;
            }
            //是否开启3天过滤
            if (cbx_threeDay.Checked == true)
            {
                msc.threeDayType = 1;
            }
            else
            {
                msc.threeDayType = 0;
            }//是否开启地区过滤
            if (cbx_area.Checked == true)
            {
                msc.areType = 1;
                msc.areList = tbx_area.Text.Trim();
            }
            //金额过滤
            msc.Amount = txtAmount.Text.Trim();
            //短信内容  统一使用UnpayMsg作为短信内容
            msc.UnpayMsg = txt_div_nopay_msg.Text.Trim();
            msc.warnType = mark;
            if (MemberNotifyBLL.CheckMsgConfigTypeIsExit(msc))
            {
                isOk = MemberNotifyBLL.updateWarn(msc);
            }
            else
            {
                isOk = MemberNotifyBLL.addWarnConfig(msc);
            }
            if (isOk)
            {
                Alert("保存成功！");
              
            }
            else
            {
                Alert("保存失败！");
            }
        }

        MsgSendConfig getMsgObj()
        {
            MsgSendConfig o = new MsgSendConfig();
            o.SellerNick = Users.Nick;
            //o.SellerNick = "TestAcc001";
            o.ShopName = shopName;
            return o;
        }

        string getMsgByType(string type)
        {
            string msg = string.Empty;
            switch (type)
            {
                case "notplay":
                    msg += notPalyMsg;
                    break;
                case "pay":
                    msg += palyMsg;
                    break;
                case "startSend":
                    msg += deliveryMsg;
                    break;
                case "delaySend":
                    msg += delayMsg;
                    break;
                case "arivde":
                    msg += arrivedMsg;
                    break;
                case "sign":
                    msg += singMsg;
                    break;
                case "refund":
                    msg += receivableMsg;
                    break;
            }
            return msg;
        }


        string getNameByType(string type)
        {
            string name = string.Empty;
            switch (type)
            {
                case "notplay":
                    name = "未付款提醒";
                    break;
                case "pay":
                    name = "付款提醒";
                    break;
                case "startSend":
                    name = "发货提醒";
                    break;
                case "delaySend":
                    name = "延时发货提醒";
                    break;
                case "arivde":
                    name = "到达提醒";
                    break;
                case "sign":
                    name = "签收提醒";
                    break;
                case "refund":
                    name = "回款提醒";
                    break;
            }
            return name;
        }


        /// <summary>
        /// 催款提醒
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void notpaying_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            notpaying.ImageUrl = @"../../Win_Image/unfahuo01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "notplay";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void pay_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            pay.ImageUrl = @"../../Win_Image/fukuan01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "pay";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void delivery_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            delivery.ImageUrl = @"../../Win_Image/fahuo01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "startSend";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void delay_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            delay.ImageUrl = @"../../Win_Image/yanchi01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "delaySend";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void arrived_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            arrived.ImageUrl = @"../../Win_Image/daoda01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "arivde";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void Sign_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            Sign.ImageUrl = @"../../Win_Image/qianshou01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "sign";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        protected void receivable_Click(object sender, ImageClickEventArgs e)
        {
            InitImgUrl();
            receivable.ImageUrl = @"../../Win_Image/huikuan01.jpg";
            MsgSendConfig o = getMsgObj();
            o.warnType = "refund";
            InitAutoControl(o);
            Label25.Text = getNameByType(o.warnType);
        }

        /// <summary>
        /// 弹出信息
        /// </summary>
        public static void Alert(string message)
        {
            string js = "<script language=javascript>alert('{0}');</script>";
            HttpContext.Current.Response.Write(string.Format(js, message));
        }

        private void InitImgUrl()
        {
            notpaying.ImageUrl = @"../../Win_Image/unfahuo.jpg";
            pay.ImageUrl = @"../../Win_Image/fukuan.jpg";
            delivery.ImageUrl = @"../../Win_Image/fahuo.jpg";
            delay.ImageUrl = @"../../Win_Image/yanchi.jpg";
            arrived.ImageUrl = @"../../Win_Image/daoda.jpg";
            Sign.ImageUrl = @"../../Win_Image/qianshou.jpg";
            receivable.ImageUrl = @"../../Win_Image/huikuan.jpg";
        }
    }
}