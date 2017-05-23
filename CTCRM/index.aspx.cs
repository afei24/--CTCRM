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
using CTCRM.Components;
using CTCRM.Entity;
using System.Collections.Generic;
using Top.Api.Domain;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;

namespace CTCRM
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //*判断卖家是否是第一次登陆，
                //将卖家信息写入DB
                if (!Page.IsPostBack)
                {
                        //初始化买家会员级别
                        DataTable tbbuyerlevel = ShopsBLL.GetBuyerGrade(Users.Nick);
                        if (tbbuyerlevel != null)
                        {
                            lbQianZai.Text = tbbuyerlevel.Rows[0]["grade"].ToString();
                            lbCommonBuyer.Text = tbbuyerlevel.Rows[1]["grade"].ToString();
                            lbAdvanceBuyer.Text = tbbuyerlevel.Rows[2]["grade"].ToString();
                            lbVIP.Text = tbbuyerlevel.Rows[3]["grade"].ToString();
                            lbTopVIP.Text = tbbuyerlevel.Rows[4]["grade"].ToString();
                        }
                        else
                        {
                            lbQianZai.Text = "0";
                            lbCommonBuyer.Text = "0";
                            lbAdvanceBuyer.Text = "0";
                            lbVIP.Text = "0";
                            lbTopVIP.Text = "0";
                        }
                       
                        //从数据库读取最近30天活跃会员总金额排行榜 
                        grdTopBuyerTradeAmount.DataSource = null;
                        grdTopBuyerTradeAmount.DataBind();
                        //获取销量最好的前10条宝贝
                        grdTopSales.DataSource = SellersBLL.GetTop10Sales(Users.Nick);
                        grdTopSales.DataBind();
                        //获取店铺统计信息
                        DataTable tbsellerStatic = ShopsBLL.GetShopeInfoStatic(Users.Nick);
                        if (tbsellerStatic != null)
                        {
                            lbTotalSales.Text = "￥" + tbsellerStatic.Rows[0]["Result_Flag"].ToString();
                            var orderCount = tbsellerStatic.Rows[1]["Result_Flag"].ToString();
                            lbOrderCount.Text = orderCount.Substring(0, orderCount.Length - 3);
                            var userCount = tbsellerStatic.Rows[2]["Result_Flag"].ToString();
                            lbUserCount.Text = userCount.Substring(0, userCount.Length - 3);
                            var orderPrice = tbsellerStatic.Rows[3]["Result_Flag"].ToString();
                            lbPerOrderPirce.Text = "￥" + orderPrice.Substring(0, orderPrice.Length - 3);

                            var newUserOrderCount = tbsellerStatic.Rows[4]["Result_Flag"].ToString();
                            lbNewUserOrderCount.Text = newUserOrderCount.Substring(0, newUserOrderCount.Length - 3);

                            var newBuyerCount = tbsellerStatic.Rows[4]["Result_Flag"].ToString();
                            lbNewBuyerCount.Text = newBuyerCount.Substring(0, newBuyerCount.Length - 3);
                            var refundOrderCount = tbsellerStatic.Rows[5]["Result_Flag"].ToString();
                            lbRefundOrderCount.Text = refundOrderCount.Substring(0, refundOrderCount.Length - 3);
                            var qianzaiBuyerCount = tbsellerStatic.Rows[6]["Result_Flag"].ToString();
                            QianZaiBuyerCount.Text = qianzaiBuyerCount.Substring(0, qianzaiBuyerCount.Length - 3);
                            var threeMonthsNoLoginCount = tbsellerStatic.Rows[7]["Result_Flag"].ToString();
                            lb3MonthsNoLoginCount.Text = threeMonthsNoLoginCount.Substring(0, threeMonthsNoLoginCount.Length - 3);
                            var oldBuyerCount = tbsellerStatic.Rows[8]["Result_Flag"].ToString();
                            if (oldBuyerCount.Length > 0)
                            {
                                lbOldBuyerCount.Text = oldBuyerCount.Substring(0, oldBuyerCount.Length - 3);
                            }
                            else {
                                lbOldBuyerCount.Text = "0";
                            
                            }
                        }
                        else
                        {
                            lbTotalSales.Text = "0";
                            lbOrderCount.Text = "0";
                            lbUserCount.Text = "0";
                            lbPerOrderPirce.Text = "0";
                            lbNewUserOrderCount.Text = "0";
                            lbRefundOrderCount.Text = "0";
                            lbNewBuyerCount.Text = "0";
                            QianZaiBuyerCount.Text = "0";
                            lb3MonthsNoLoginCount.Text = "0";
                            lbOldBuyerCount.Text = "0";
                        }

                        //左上角店铺信息初始化
                        DataTable tbShop = ShopsBLL.GetSellerShopInfo(Users.Nick);
                        if (tbShop != null && tbShop.Rows.Count > 0)
                        {
                            shopImg.ImageUrl = "http://logo.taobao.com/shop-logo" + tbShop.Rows[0]["pic_path"].ToString().Trim();
                            lbNickName.Text = Users.Nick;
                            string shopName = tbShop.Rows[0]["title"].ToString().Trim();
                            if (shopName.Length > 10) { shopName = shopName.Substring(0, shopName.Length - 1) + "..."; }
                            lbShopName.Text = shopName;
                            Session["ShopName"] = lbShopName.Text;
                            //订购服务到期时间
                            //ArticleUserSubscribe userSub = Users.GetDeadLineDate("ts-1811102", Users.Nick);
                            lbUptoDate.Text = "";//userSub == null ? DateTime.Now.AddMonths(1).ToShortDateString() : Convert.ToDateTime(userSub.Deadline).ToShortDateString();
                        }
                        DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            lbUnUseMsgCount.Text = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
                        }
                        else
                        {
                            lbUnUseMsgCount.Text = "0条";
                        }
                    }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }


        protected void tnUpdateDate_Click(object sender, ImageClickEventArgs e)
        {
            
        }
    }
}
