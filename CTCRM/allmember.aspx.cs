using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Top.Api.Domain;
using System.Collections.Generic;
using CTCRM.Components;
using CTCRM.Common;
using System.Drawing;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Threading;

namespace CTCRM
{
    public partial class allmember : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               DataTable tb = BuyerBLL.GetGroupByID(Users.Nick);
               drpGroup.DataSource = tb;
               drpGroup.DataTextField = "group_name";
               drpGroup.DataValueField = "group_name";
               drpGroup.DataBind();
               drpGroup.Items.Insert(0, "全部");
               //BindData();  
               this.grdBuyer.DataSource = null;
               this.grdBuyer.DataBind();
            }
        }

      private  void searchBuyers()
        {
            string buyerNick = txtNickName.Text.Trim();
            string status = drpStatus.SelectedValue.ToString();
            string area = drpArea.SelectedValue.ToString();
            string grade = drpGrade.SelectedValue.ToString();
            string tradeAmount1 = txtMin.Text.Trim();
            string tradeAmount2 = txtMax.Text.Trim();
            string buyCount = txtBuyCount.Text.Trim();

            if (!String.IsNullOrEmpty(Request.QueryString["type"]) && drpGroup.SelectedValue.Equals("全部"))
            {
                if (Request.QueryString["type"].ToString().Equals("newCus") && string.IsNullOrEmpty(ViewState["flag"] as string))
                {
                    drpGroup.SelectedValue = "新客户";
                }
            }
            if (!String.IsNullOrEmpty(Request.QueryString["type"]) && drpGroup.SelectedValue.Equals("全部"))
            {
                if (Request.QueryString["type"].ToString().Equals("oldCus") && string.IsNullOrEmpty(ViewState["flag"] as string))
                {
                    drpGroup.SelectedValue = "老客户";
                }
            }
            string group = drpGroup.SelectedItem.Text.ToString();

            DataTable ds = BuyerBLL.GetBuyerInfo(buyerNick, status, area, grade, group, tradeAmount1, tradeAmount2, Users.Nick, buyCount);
            AspNetPager1.RecordCount = ds.DefaultView.Count;

            this.AspNetPager1.CustomInfoHTML = string.Format("当前第{0}/{1}页 共{2}条记录 每页{3}条", new object[] { this.AspNetPager1.CurrentPageIndex, this.AspNetPager1.PageCount, this.AspNetPager1.RecordCount, this.AspNetPager1.PageSize });
                                                                      
            PagedDataSource pds = new PagedDataSource();
            pds.DataSource = ds.DefaultView;
            pds.AllowPaging = true;
            pds.CurrentPageIndex = AspNetPager1.CurrentPageIndex - 1;
            pds.PageSize = AspNetPager1.PageSize;

            //根据分页情况将数据写入或者更新到数据库
            this.grdBuyer.DataSource = pds;
            this.grdBuyer.DataBind();
        }

        protected string CheckBuyerStatus(string value) {
            if (value.Equals("normal")) { return "正常"; }
            if (value.Equals("delete")) { return "被买家删除"; }
            if (value.Equals("black")) { return "黑名单会员"; }
            return "正常";
        }

        protected string CheckBuyerLevel(string value) {
            if (value.Equals("1")) { return "普通会员"; }
            if (value.Equals("2")) { return "高级会员"; }
            if (value.Equals("3")) { return "VIP会员"; }
            if (value.Equals("4")) { return "至尊VIP会员"; }
            return "潜在会员";
        }

        protected void grdBuyer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //会员级别标识

                Label lbGrade = e.Row.FindControl("Label4") as Label;
                if (lbGrade != null)
                {
                    if (lbGrade.Text.Equals("普通会员")) {
                        lbGrade.ForeColor = Color.FromName("#006666");
                    }
                    if (lbGrade.Text.Equals("潜在会员"))
                    {
                        lbGrade.ForeColor = Color.FromName("#996600");
                    }
                    if (lbGrade.Text.Equals("高级会员"))
                    {
                        lbGrade.ForeColor = Color.FromName("#CC6633");
                    }
                    if (lbGrade.Text.Equals("VIP会员"))
                    {
                        lbGrade.ForeColor = Color.FromName("#99CC00");
                    }
                    if (lbGrade.Text.Equals("至尊VIP会员"))
                    {
                        lbGrade.ForeColor = Color.FromName("#CC0000");
                    }
                }
                Label lbblack = e.Row.FindControl("Label2") as Label;
                LinkButton btnBlack = e.Row.FindControl("btnAddBlackList") as LinkButton;
                if (lbblack != null)
                 {
                     if (lbblack.Text.Equals("黑名单会员"))
                     {
                         btnBlack.Visible = false;
                     }
                     else {
                         btnBlack.Visible = true;
                     }
                 }

                //会员详细
                ((HyperLink)e.Row.FindControl("HyperLinkEdit")).Style.Add(HtmlTextWriterStyle.Cursor, "pointer");
                ((HyperLink)e.Row.FindControl("HyperLinkEdit")).Attributes.Add("onclick", "javascript:var iTop2 = (window.screen.availHeight - 20 - 350) / 2; var iLeft2 = (window.screen.availWidth - 10 - 600) / 2; var params = 'menubar:no;dialogHeight=350px;dialogWidth=600px;dialogLeft=' + iLeft2 + 'px;dialogTop=' + iTop2 + 'px;resizable=yes;scrollbars=0;resizeable=0;center=yes;location:no;status:no';var bLogged = showModalDialog( 'buyerInfoDetails.aspx?buyer_id= " + grdBuyer.DataKeys[e.Row.RowIndex].Value.ToString() + "', 'window',params);"); 
                //会员资料修改
                //((HyperLink)e.Row.FindControl("HyerLinkEditMember")).Attributes.Add("onclick", "window.showModalDialog('memberDetails.aspx?buyer_id=" + grdBuyer.DataKeys[e.Row.RowIndex].Value.ToString() + "','','dialogWidth=600px;dialogHeight=400px;status=no;help=no;scroll=no;center=yes;edge:sunken')");
                ((HyperLink)e.Row.FindControl("HyerLinkEditMember")).Attributes.Add("onclick", "javascript:var iTop2 = (window.screen.availHeight - 20 - 390) / 2; var iLeft2 = (window.screen.availWidth - 10 - 600) / 2; var params = 'menubar:no;dialogHeight=390px;dialogWidth=600px;dialogLeft=' + iLeft2 + 'px;dialogTop=' + iTop2 + 'px;resizable=yes;scrollbars=0;resizeable=0;center=yes;location:no;status:no';var bLogged = showModalDialog( 'memberDetails.aspx?buyer_id= " + grdBuyer.DataKeys[e.Row.RowIndex].Value.ToString() + "', 'window',params);"); 
            }
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            searchBuyers();
        }

        protected void btnimgSearch_Click(object sender, ImageClickEventArgs e)
        {
            //Thread.Sleep(10000000);
            AspNetPager1.CurrentPageIndex = 1;
            searchBuyers();
        }

        protected void btnAddBuyer_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("addbuyer.aspx");
        }

    }
}