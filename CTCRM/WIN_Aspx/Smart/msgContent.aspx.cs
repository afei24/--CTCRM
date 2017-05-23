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
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM.WIN_Aspx.Smart
{
    public partial class msgContent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    var transNumber = Request.QueryString["transNumber"].ToString();
                    if (!string.IsNullOrEmpty(transNumber))
                    {
                        DataTable tbMsgContent = MsgBLL.GetMsgContentByTransID(transNumber);
                        if (tbMsgContent != null && tbMsgContent.Rows.Count > 0)
                        {
                            lbTransNo.Text = transNumber;
                            lbMsgContent.Text = tbMsgContent.Rows[0]["msgContent"].ToString();
                        }
                        Label1.Text = transNumber;
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