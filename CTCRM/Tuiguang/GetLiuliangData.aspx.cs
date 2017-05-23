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
    public partial class GetLiuliangData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(GetValidData());
        }
        public string GetValidData()
        {
            try
            {
                string retuVal = "0";
                DataTable tb = tuiGuangBLL.GetValidData();
                if (tb != null && tb.Rows.Count > 0)
                {
                    retuVal = JsonConvert.SerializeObject(tb);
                }
                return retuVal;
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Data);
                return "0";
            }
        }
    }
}