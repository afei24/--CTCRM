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
using CTCRM.Common;

namespace CTCRM.admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //设置焦点
            txtUserName.Focus();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            bool userIsExist = false;
            if (txtUserName.Text.Trim() == "kim"
                && txtPwd.Text.Trim() == "kim..com")
            {
                userIsExist = true;
            }
            if (userIsExist)
            {
                //初始化Profiles对象并设置cookie
                FormsAuthentication.SetAuthCookie("LOGINSESSION", true);
                Session["LOGINUSERNAME"] = txtUserName.Text.Trim();
                Response.Redirect("/admin/main.aspx?");
            }
        }
    }
}
