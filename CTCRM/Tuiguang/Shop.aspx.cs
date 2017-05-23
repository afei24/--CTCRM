using CTCRM.Components;
using CTCRM.Components.TopCRM;
using CTCRM.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.Tuiguang
{
    public partial class Shop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lab_Nick.Text = Users.Nick;
                lbVersion.Text = Users.OrderVersion;
                txt_nick.Text = Users.Nick;
                drpCatsList.DataSource = TBOnSalePro.GetCatsList(Users.SessionKey, Users.Nick);
                drpCatsList.DataTextField = "name";
                drpCatsList.DataValueField = "cid";
                drpCatsList.DataBind();
                drpCatsList.Items.Insert(0, "--选择店铺主营目录--");

                //BandData
                DataTable tb = tuiGuangBLL.GetShopInfo(Users.Nick);
                if (tb != null && tb.Rows.Count == 1)
                {
                    lab_Nick.Text = tb.Rows[0]["shopName"].ToString();
                    drpCatsList.SelectedItem.Text = tb.Rows[0]["cateName"].ToString();
                    if (tb.Rows[0]["type"].ToString().Equals("个人兼职"))
                    {
                    rdoLst1.SelectedIndex = 0;
                    }
                    if (tb.Rows[0]["type"].ToString().Equals("个人全职"))
                    {
                    rdoLst1.SelectedIndex = 1;
                    }
                    if (tb.Rows[0]["type"].ToString().Equals("公司开店"))
                    {
                        rdoLst1.SelectedIndex = 2;
                    }
                    txtAdderss.Text = tb.Rows[0]["address"].ToString();
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("线下批发市场"))
                    {
                        rdoLst2.SelectedIndex = 0;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("实体店拿货"))
                    {
                        rdoLst2.SelectedIndex = 1;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("阿里巴巴批发"))
                    {
                        rdoLst2.SelectedIndex = 2;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("分销/代销"))
                    {
                        rdoLst2.SelectedIndex = 3;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("自己生产"))
                    {
                        rdoLst2.SelectedIndex = 4;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("代工生产"))
                    {
                        rdoLst2.SelectedIndex = 5;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("自由公司渠道"))
                    {
                        rdoLst2.SelectedIndex = 6;
                    }
                    if (tb.Rows[0]["huoyuan"].ToString().Equals("货源还未确定"))
                    {
                        rdoLst2.SelectedIndex = 7;
                    }

                    if (tb.Rows[0]["hasShiTiShop"].ToString().Equals("是"))
                    {
                        rdoLst3.SelectedIndex = 0;
                    }
                    if (tb.Rows[0]["hasShiTiShop"].ToString().Equals("否"))
                    {
                        rdoLst3.SelectedIndex = 1;
                    }
                    if (tb.Rows[0]["hasFactory"].ToString().Equals("是"))
                    {
                        rdoLst4.SelectedIndex = 0;
                    }
                    if (tb.Rows[0]["hasFactory"].ToString().Equals("否"))
                    {
                        rdoLst4.SelectedIndex = 1;
                    }
                }
            }
            lbMsg.Text = "";
        }

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (drpCatsList.SelectedItem.Text.Equals("--选择店铺主营目录--")) { lbMsg.Text = "请选择主营类目！"; return; }
            if (string.IsNullOrEmpty(txtAdderss.Text.Trim())) { lbMsg.Text = "联系地址不能为空！"; return; }
            SellerShopForTuiGuang obj = new SellerShopForTuiGuang();
            obj.SellerNick = Users.Nick;
            obj.ShopName = txt_nick.Text.Trim();
            obj.CateName = drpCatsList.SelectedItem.Text;
            obj.Address = txtAdderss.Text.Trim();
            obj.Type = rdoLst1.SelectedValue;
            obj.Huoyuan = rdoLst2.SelectedValue;
            obj.HasShiTiShop = rdoLst3.SelectedValue;
            obj.HasFactory = rdoLst4.SelectedValue;

            if (!tuiGuangBLL.ChekDianPu())
            {
                if (tuiGuangBLL.AddDianPu(obj))
                {
                    lbMsg.Text = "添加成功！";
                }
                else
                {
                    lbMsg.Text = "添加失败！";
                }
            }
            else
            {
                if (tuiGuangBLL.UpdateDianPu(obj))
                {
                    lbMsg.Text = "修改成功！";
                }
                else
                {
                    lbMsg.Text = "修改失败！";
                }
            }
        }
    }
}