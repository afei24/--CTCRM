using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using CTCRM.Components;
using Top.Api.Domain;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Entity;

namespace CTCRM.Temp
{
    public partial class Common : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    //lab_Nick.Text = Users.Nick == null?"店铺小二":Users.Nick;
                    //lbVersion.Text = string.IsNullOrEmpty(Users.OrderVersion) ? "" : Users.OrderVersion.ToString();
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void linkbtn_Exit_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["Top"] != null)
            {
                Response.Cookies["Top"].Expires = DateTime.Now.AddDays(-1);//将这个Cookie过期掉.  
            }
        }
    }
}
