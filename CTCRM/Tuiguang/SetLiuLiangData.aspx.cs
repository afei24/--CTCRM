using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class SetLiuLiangData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sellerNick = Request.Form["sellerNick"];
            string nick = HttpUtility.UrlDecode(sellerNick, Encoding.UTF8);
            //ExceptionReporter.WriteLog("商家昵称：" + nick, ExceptionPostion.TBApply_Data, ExceptionRank.important);
            Response.Write(SetData(nick));
        }
        public string SetData(string sellerNick)
        {
            try
            {
                string retuVal = "0";
                retuVal = tuiGuangBLL.AddTuiGuangLogForS(sellerNick);
                return retuVal;

            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }
    }
}