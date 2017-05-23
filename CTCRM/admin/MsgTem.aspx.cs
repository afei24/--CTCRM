using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Components;
using System.Data;
using CTCRM.Entity;

namespace CTCRM.admin
{
    public partial class MsgTem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadList();
            }
        }

        void loadList()
        {
            DataTable tab = MsgContentsBLL.getMsgByPageType();
            if (tab != null && tab.Rows.Count > 0)
            {
                gv_msg.DataSource = tab.DefaultView;
                gv_msg.DataBind();
            }
        }

        protected void gv_msg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_msg.PageIndex = e.NewPageIndex;
            loadList();
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            string type = tb_type.Text.Trim();
            string msgContent = tb_msg.Text.Trim();
            if (string.IsNullOrEmpty(type) == false && string.IsNullOrEmpty(msgContent) == false)
            {
                MsgContents msg = new MsgContents();
                msg.PageType = type;
                msg.TypeTitle = "";
                msg.MsgContent = msgContent;
                if (rbt_warn.Checked == true)
                {
                    msg.msgUse = 0;
                }
                else {
                    msg.msgUse = 1;
                }
                if (MsgContentsBLL.addMsg(msg) == true)
                {
                    //成功
                    loadList();
                    //Response.Write("<script language='javascript'>alert('请正确填写时分秒');</script>");
                }
            }
            else
            {
                //信息没有填写完整
                Response.Write("<script language='javascript'>alert('请填写类型或短信内容！');</script>");
            }
        }

        protected void gv_msg_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv_msg.EditIndex = -1;
            loadList();
        }

        protected void gv_msg_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv_msg.EditIndex = e.NewEditIndex;
            loadList();
            
        }

        protected void gv_msg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string id = ((TextBox)(gv_msg.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString().Trim();
            string type = ((TextBox)(gv_msg.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string msg = ((TextBox)(gv_msg.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            int ret = 0;
            if (rbt_warn.Checked == true)
            {
                ret = 1;
            }
            MsgContentsBLL.updateMsg(id,type,msg,ret);
            gv_msg.EditIndex = -1;
            loadList();
        }

        protected void gv_msg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = gv_msg.Rows[e.RowIndex].Cells[1].Text;
            MsgContentsBLL.deleteMsg(id);
            loadList();
        }


    }
}