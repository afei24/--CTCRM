using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class Item : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lab_Nick.Text = Users.Nick;
                lbVersion.Text = Users.OrderVersion;
            }
            lbMsg.Text = "";
            DataBindForPro();
            this.MaintainScrollPositionOnPostBack = true;
        }

        private void DataBindForPro()
        {
            DataTable tb = tuiGuangBLL.GetTuiGuangItems();
            rptProducts.DataSource = tb;
            rptProducts.DataBind();
        }

        protected void btnCreateTask_Click(object sender, ImageClickEventArgs e)
        {
            string Deadline = Users.Deadline;
            if (!string.IsNullOrEmpty(Deadline))
            {
                DateTime dtDealine = Convert.ToDateTime(Deadline);
                TimeSpan tdspan = dtDealine - DateTime.Now;
                if (tdspan.Days <= 15)
                {
                    lbMsg.Text = "免费版不支持创建推广，请升级付费版！";
                    return;
                }
                else
                {
                    string itemNo = "";
                    if (string.IsNullOrEmpty(s_key.Value) || s_key.Value.Equals("你要推广的宝贝地址,例如：https://item.taobao.com/item.htm?id=529108600343"))
                    {
                        lbMsg.Text = "请输入要推广的宝贝地址！";
                        return;
                    }
                    if (s_key.Value.IndexOf("tmall") > -1)
                    {
                        itemNo = GetValue(s_key.Value, "&id=", "&");
                    }
                    if (s_key.Value.IndexOf("taobao") > -1)
                    {
                        itemNo = s_key.Value.Substring(s_key.Value.IndexOf("id=") + 3);
                    }

                    if (string.IsNullOrEmpty(itemNo))
                    {
                        lbMsg.Text = "输入的宝贝地址不正确！";
                        return;
                    }
                    if (tuiGuangBLL.ChekTuiGuangItem(itemNo))
                    {
                        lbMsg.Text = "该宝贝已经存在推广列表中！";
                        s_key.Value = "";
                        s_key.Focus();
                        return;
                    }
                    if (tuiGuangBLL.ChekTuiGuangMaxItems())
                    {
                        lbMsg.Text = "亲,您已经超过最大上架商品数,6个！";
                        s_key.Value = "";
                        s_key.Focus();
                        return;
                    }
                    if (tuiGuangBLL.AddTask(itemNo))
                    {
                        DataBindForPro();
                        s_key.Value = "";
                        s_key.Focus();
                    }
                    else
                    {
                        lbMsg.Text = "添加失败，请联系客服！";
                    }
                }
            }
            else
            {
                lbMsg.Text = "没有权限，请联系客服！";
            }

        }

        public static string GetValue(string str, string s, string e)
        {
            Regex rg = new Regex("(?<=(" + s + "))[.\\s\\S]*?(?=(" + e + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(str).Value;
        }

        protected void btnDown_click(object sender, EventArgs e)
        {
            try
            {
                string itemNo = ((ImageButton)sender).CommandArgument;
                tuiGuangBLL.UpdateTuiPro(itemNo, "0");
                //重新绑定
                DataBindForPro();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void btnAddTask_click(object sender, EventArgs e)
        {
            try
            {
                string itemNo = ((ImageButton)sender).CommandArgument;
                tuiGuangBLL.UpdateTuiPro(itemNo, "1");
                //重新绑定
                DataBindForPro();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void btnDeleteTask_click(object sender, EventArgs e)
        {
            try
            {
                string itemNo = ((ImageButton)sender).CommandArgument;
                if (!tuiGuangBLL.DeleteTuiPro(itemNo))
                {
                    lbMsg.Text = "删除宝贝失败！";
                }
                //重新绑定
                DataBindForPro();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void rptProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int row = e.Item.ItemIndex;
                HiddenField hfId = e.Item.FindControl("hfId") as HiddenField;
                string itemNo = hfId.Value;
                if (!string.IsNullOrEmpty(itemNo))
                {
                    Image btnTui = e.Item.FindControl("btnTuiing") as Image;
                    ImageButton btnDown = e.Item.FindControl("btnDown") as ImageButton;
                    ImageButton btnDeleteTask = e.Item.FindControl("btnDeleteTask") as ImageButton;
                    ImageButton btnAddTask = e.Item.FindControl("btnAddTask") as ImageButton;

                    string status = tuiGuangBLL.GetTuiSataus(itemNo);
                    if (status.Equals("1"))//上架中
                    {
                        if (btnTui != null) { btnTui.Visible = true; }
                        if (btnDown != null) { btnDown.Visible = true; }
                        if (btnDeleteTask != null) { btnDeleteTask.Visible = false; }
                        if (btnAddTask != null) { btnAddTask.Visible = false; }
                    }
                    if (status.Equals("0"))//下架中
                    {
                        if (btnTui != null) { btnTui.Visible = false; }
                        if (btnDown != null) { btnDown.Visible = false; }
                        if (btnDeleteTask != null) { btnDeleteTask.Visible = true; }
                        if (btnAddTask != null) { btnAddTask.Visible = true; }
                    }
                }
            }
        }

    }
}