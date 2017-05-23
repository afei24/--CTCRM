using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class ymyData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string openId = Request.Form["openId"];
            Response.Write(GetYMYData(openId));
        }
        public string GetYMYData(string openId)
        {
            try
            {
                string retuVal = "0";
                DataTable tb = tuiGuangBLL.GetTuiGuangItemsForYMY(openId);
                if (tb != null && tb.Rows.Count > 0)
                {
                    retuVal = JsonConvert.SerializeObject(tb);
                }
                return retuVal;

            }
            catch (Exception ex)
            {
                return "0";
            }

        }
    }
}