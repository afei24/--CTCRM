using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.print
{
    public partial class printer_aspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (!Users.OrderVersion.Equals("订单打印版") && !Users.OrderVersion.Equals("全功能版"))
                //{
                //    Response.Write("<script languge='javascript'>alert('没有权限使用，请订购对应的软件版本'); window.location.href='http://fuwu.taobao.com/ser/detail.htm?service_code=ts-1811102'</script>");
                //    return;
                //}
            }
            string printUrl = ConfigurationManager.AppSettings["printUrl"].ToString();
            string url = printUrl + "/platform/return?code=" + Users.SellerId + "&app_id=8";
            Response.Redirect(url);

        }
    }
}