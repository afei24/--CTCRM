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

namespace CTCRM
{
    public partial class main : System.Web.UI.Page
    {
        public string userName = string.Empty;
        public string orderVersion = string.Empty;
        public string deadline = string.Empty;
        public string msgCount = string.Empty;
        public string systemMsg = @" <div><a href='#'><label style='float: left'>暂无公告</label></a></div>";
        string title1 = string.Empty;
        string title2 = string.Empty;
        string title3 = string.Empty;
        string title4 = string.Empty;
        string title5 = string.Empty;
        string news = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                try
                {
                    //var result = SellersBLL.CheckSeller();
                    //if (result == "0")
                    //{
                    //    Response.Redirect("http://container.api.taobao.com/container/transform?appkey=21088197", false);
                    //}

                    userName = Users.Nick == null ? "未登录的用户" : Users.Nick;
                    orderVersion = string.IsNullOrEmpty(Users.OrderVersion) ? "最高版本" : Users.OrderVersion.ToString();
                    deadline = Users.Deadline == null ? "当前" : Users.Deadline;
                    deadline = deadline.Substring(0, 11);
                    DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        msgCount = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                    }
                    else
                    {
                        msgCount = "0条";
                    }
                    string medo = @" <div><a href='{1}'><lable style='float: left'>{0}</lable><br /></a></div>";
                    DataTable dt = SystemMessagesBLL.QueryShowMsg();
                    if (dt == null || dt.Rows.Count <= 0)
                    { return; }
                    systemMsg = "";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        systemMsg += string.Format(medo, dt.Rows[i]["SystemMsg"].ToString(), dt.Rows[i]["SystemLink"].ToString());
                    }
                }
                catch (Exception ex)
                {

                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                }
            }
        }
    }
}