using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Components;
using CTCRM.DAL;

namespace CTCRM.admin.memberData
{
    public partial class buyer_application : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = BuyerexportBLL.GetBuyerExport();
            gv_buyer.DataSource = dt;
            gv_buyer.DataBind();
        }

        protected void gv_buyer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gv_buyer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }

        protected void gv_buyer_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int i = 0;
            if (e.CommandName == "buttonOk")
            {
                int idx = Convert.ToInt16(e.CommandArgument.ToString());
                string buyer =  gv_buyer.Rows[idx].Cells[0].Text.ToString();
                string time = gv_buyer.Rows[idx].Cells[1].Text.ToString();
                i = BuyerexportBLL.UpdateExport(buyer, time,2);


             }
            else if (e.CommandName == "buttonCancle")
            {
                int idx = Convert.ToInt16(e.CommandArgument.ToString());
                string buyer = gv_buyer.Rows[idx].Cells[0].Text.ToString();
                string time = gv_buyer.Rows[idx].Cells[1].Text.ToString();
                i = BuyerexportBLL.UpdateExport(buyer, time, 0);
            }

            DataTable dt = BuyerexportBLL.GetBuyerExport();
            gv_buyer.DataSource = dt;
            gv_buyer.DataBind();
        }
    }
}