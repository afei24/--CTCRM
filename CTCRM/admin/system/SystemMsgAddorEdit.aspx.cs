using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Components;

namespace CTCRM.admin
{
    public partial class SystemMsgAddorEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SystemMsgID"] == null)
                {
                    return;
                }
                DataTable dt = SystemMessagesBLL.GetMsgById(Request.QueryString["SystemMsgID"].ToString());
                if (dt != null || dt.Rows.Count > 0)
                {
                    TextBoxMsg.Text = dt.Rows[0]["SystemMsg"].ToString();
                    TextBoxLink.Text = dt.Rows[0]["SystemLink"].ToString();
                }
            }
            
        }

        protected void ButtonCancle_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("SystemMessages.aspx");
        }

        protected void ButtonOk_Click(object sender, ImageClickEventArgs e)
        {
            string link = String.IsNullOrEmpty(TextBoxLink.Text.Trim()) == true ? "" : TextBoxLink.Text.Trim();
            if (String.IsNullOrEmpty(TextBoxMsg.Text.Trim()))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('请填写公告信息！');</script>");
                return;
            }
            if (HiddenField1.Value.Length <= 0)
            {

                SystemMessagesBLL.Insert(TextBoxMsg.Text.Trim(), link, Convert.ToInt32(DropDownListStatus.SelectedValue));
                
            }
            else
            {
                SystemMessagesBLL.Update(TextBoxMsg.Text.Trim(), link, Convert.ToInt32(DropDownListStatus.SelectedValue), HiddenField1.Value);
            }
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('保存成功！');</script>");
            Response.Redirect("SystemMessages.aspx");
        }
    }
}