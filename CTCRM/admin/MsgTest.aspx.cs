using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Common;
using CTCRM.Components;

namespace CTCRM.admin
{
    public partial class MsgTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //JiuFangSendMsg();
            setTime();
        }

       void setTime()
        {
            SellersBLL.UpdateUnUseDate("2016-11-06", "至美欧旗舰店");
        }

        public void JiuFangSendMsg()
        {
          //TextBox1.Text = Mobile.sendMsgJiuFang("13621708662", "【急钻风】老板，您已经开启物流提醒服务，退订回复T！", "100057", "c9bf7c4cb27c5527c4d757765514498e");

         //TextBox1.Text = Mobile.getPortJiuFang("100057", "c9bf7c4cb27c5527c4d757765514498e");

          //TextBox1.Text = Mobile.getReplyJiuFang("100057", "c9bf7c4cb27c5527c4d757765514498e");

         //string returnValue = Mobile.getBalanceJiuFang("100057", "c9bf7c4cb27c5527c4d757765514498e");
         //showBalance(returnValue);


            //string d=  Mobile.PostDataToMyServer("15800930232", "【急钻风】老板，您已经开启物流提醒服");
            //string f = Mobile.SendMsgHubeiYDPost("15800930232", "【澄腾科技】老板，您已经开启物流提醒服务，退订回复T！");
            string f = Mobile.SendMsgHubeiYDPost("15800930232", "【急钻风】老板，您已经开启物流提醒服！");
        }

        void showBalance(string balance)
        {
            if (!string.IsNullOrEmpty(balance))
            {
                string[] str = balance.Split('}');
                if (str.Length > 0)
                {
                    TextBox1.Text = "查询成功，账户余额为" + str[1];
                }
            
            }
        }
    }
}