using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.crmad
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
            if (txtUserName.Text.Trim() == "zhaopin"
                && txtPwd.Text.Trim() == "zhaopin6688")
            {
                userIsExist = true;
            }
            if (userIsExist)
            {
                //初始化Profiles对象并设置cookie
                FormsAuthentication.SetAuthCookie("LOGINSESSIONs", true);
                Session["LOGINUSERNAMEs"] = txtUserName.Text.Trim();
                Response.Redirect("/crmad/main.aspx?");
            }
        }
    }
}