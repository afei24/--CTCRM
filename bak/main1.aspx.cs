using System;
using System.Collections.Generic;
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
        public string userName = "";
        public string orderVersion = "";
        public string deadline = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    userName = Users.Nick == null ? "美国佐敦飞人" : Users.Nick;
                    orderVersion = string.IsNullOrEmpty(Users.OrderVersion) ? "最高版本" : Users.OrderVersion.ToString();
                    deadline = Users.Deadline == null ? "当前" : Users.Deadline;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
    }
}