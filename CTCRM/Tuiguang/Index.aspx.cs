using CTCRM.Components;
using CTCRM.Components.TopCRM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //if (!Users.OrderVersion.Equals("流量推广") && !Users.OrderVersion.Equals("全功能版"))
                //{
                //    Response.Write("<script languge='javascript'>alert('没有权限使用，请订购对应的软件版本'); window.location.href='http://fuwu.taobao.com/ser/detail.htm?service_code=ts-1811102'</script>");
                //    return;
                //}

               lab_Nick.Text = Users.Nick;
               lbVersion.Text = Users.OrderVersion;
               Label1.Text = Users.Nick;
               totalOnsalCount.Text =  TBOnSalePro.GetAllOnSalePro(Users.SessionKey);
               DataTable tb = tuiGuangBLL.GetTuiGuangItems();
               Label2.Text = tb == null ? "0" : tb.Rows.Count.ToString();
            }
        }
    }
}