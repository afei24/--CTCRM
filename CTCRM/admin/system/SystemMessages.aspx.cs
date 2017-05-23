using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Components;

namespace CTCRM.admin.system
{
    public partial class SystemMessages : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            dt = SystemMessagesBLL.QueryAll();
            DataTable dat = dt.DefaultView.ToTable(false, new string[] { "SystemMsg", "SystemLink", "Status", "SystemDate" });
            GridViewSystem.DataSource = dat;
            GridViewSystem.DataBind();
        }

        protected void GridViewSystem_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            bool i = false;
            if (e.CommandName == "buttonDel")
            {
                int idx = Convert.ToInt16(e.CommandArgument.ToString());
                string buyer = dt.Rows[idx]["SystemMsgID"].ToString();
                i = SystemMessagesBLL.Delete(buyer);
                if (i == true)
                {
                    Reset();
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('删除成功！');</script>");
                }
            }
            if (e.CommandName == "buttonEdit")
            {
                int idx = Convert.ToInt16(e.CommandArgument.ToString());
                string SystemMsgID = dt.Rows[idx]["SystemMsgID"].ToString();
                string SystemLink = dt.Rows[idx]["SystemLink"].ToString();
                string SystemMsg = dt.Rows[idx]["SystemMsg"].ToString();
                string Status = dt.Rows[idx]["Status"].ToString();
                int s = 0;
                if (Status == "显示")
                {
                    s = 1;
                }
                string url = string.Format("SystemMsgAddorEdit.aspx?type=edit&SystemMsgID={0}&SystemLink={1}&SystemMsg={2}&Status={3}",
                    SystemMsgID, SystemLink, SystemMsg, s);
                Response.Redirect(url);
            }
            
        }

        public void Reset()
        {
            dt = SystemMessagesBLL.QueryAll();
            DataTable dat = dt.DefaultView.ToTable(false, new string[] { "SystemMsg", "SystemLink", "Status", "SystemDate" });
            GridViewSystem.DataSource = dat;
            GridViewSystem.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach(GridViewRow rowview in GridViewSystem.Rows) //遍历Gridview中的每一行 
            {
            //假设gridview中的复选框放在第一列，id是“CheckBox1”
                CheckBox check = (CheckBox)GridViewSystem.Rows[0].Cells[0].FindControl("CheckBox1");//找到了checkbox控件
 
            if(check.Checked)//如果被选中
 
            {

                //假设把每一行的id放在第二列
                //string myid = GridViewSystem.Rows[0].Cells[1].Text;//这就是所在行的id，赋值给了myid
            }
 
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("SystemMsgAddorEdit.aspx");
        }
    }
}