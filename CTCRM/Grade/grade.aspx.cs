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
using CTCRM.Entity;
using System.Drawing;
using CTCRM.Common;
using Top.Api.Domain;

namespace CTCRM.Grade
{
    public partial class grade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ControlStatus(false);
                CTCRM.Entity.Grade o = new CTCRM.Entity.Grade();
                o.SellerNick = Users.Nick;
                DataTable tb = BuyerBLL.GetGradeByID(o);
                if (tb != null && tb.Rows.Count > 0)
                {
                    txtMin1.Text = tb.Rows[0]["tradeAmontFrom"].ToString();
                    txtMax1.Text = tb.Rows[0]["tradeAmountTo"].ToString();
                    txtMin2.Text = tb.Rows[1]["tradeAmontFrom"].ToString();
                    txtMax2.Text = tb.Rows[1]["tradeAmountTo"].ToString();
                    txtMin3.Text = tb.Rows[2]["tradeAmontFrom"].ToString();
                    txtMax3.Text = tb.Rows[2]["tradeAmountTo"].ToString();
                    txtMin4.Text = tb.Rows[3]["tradeAmontFrom"].ToString();
                    txtMax4.Text = tb.Rows[3]["tradeAmountTo"].ToString();
                }
            }
        }

        private void ControlStatus(Boolean flag) {

            txtMin1.Enabled = flag;
            txtMin2.Enabled = flag;
            txtMin3.Enabled = flag;
            txtMin4.Enabled = flag;
            txtMax1.Enabled = flag;
            txtMax2.Enabled = flag;
            txtMax3.Enabled = flag;
            txtMax4.Enabled = flag;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
