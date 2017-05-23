using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class Popularize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lab_Nick.Text = Users.Nick;
                lbVersion.Text = Users.OrderVersion;
            }

        }
    }
}