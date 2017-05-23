using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;

namespace CTCRM.WIN_Aspx
{
    public partial class home : System.Web.UI.Page
    {
        public string userName = "";
        public string deadline =  "";
        public string msgCount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    userName = Users.Nick == null ? "美国佐敦飞人" : Users.Nick;
                    deadline = Users.Deadline == null ? "当前" : Users.Deadline;
                }
                DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                if (tb != null && tb.Rows.Count > 0)
                {
                    msgCount = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                }
                else
                {
                    msgCount = "0条";
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
    }
}