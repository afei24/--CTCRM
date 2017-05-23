using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace CTCRM
{
    public partial class areaStatic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                datePicker.Value = DateTime.Now.AddMonths(-3).ToShortDateString();
                datePickerEnd.Value = DateTime.Now.ToShortDateString();
            }
            Chart2.Series["buyerProvince"].ChartType = SeriesChartType.Pie;
            Chart2.Series["buyerProvince"]["PieLabelStyle"] = "Outside";
            // Enable 3D
            Chart2.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;
        }

        protected void drpYears_SelectedIndexChanged(object sender, EventArgs e)
        {           
            BindBuyerProvince();
        }

        protected void imgBtnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //Thread.Sleep(100000);
            BindBuyerProvince();       
        }

        private void BindBuyerProvince()
        {
            string startDate = datePicker.Value.Trim();
            string endDate = datePickerEnd.Value.Trim();
            DataTable tb = ReportBLL.GetBuyerProviceReport(Users.Nick, startDate, endDate);
            if (tb != null)
            {
                Chart2.Series["buyerProvince"].Points.DataBindXY(tb.DefaultView, "province", tb.DefaultView, "areacount");
            }
        }

    }
}