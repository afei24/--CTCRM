using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CTCRM.Entity;
using CTCRM.Components;
using System.Drawing;
using CTCRM.Common;
using System.Xml;
using System.Collections.Generic;
using Top.Api;
using TOPCRM;
using Top.Api.Request;
using Top.Api.Response;
using System.Text;
using System.IO;

namespace CTCRM.WIN_Aspx
{
    public partial class messageSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MsgDataBind();

            }
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            //lbMsg.Text = "";
            //lbError.Text = "";

            //检查卖家订购的套餐使用情况。

        }

        private void MsgDataBind()
        {
            grdHisMsg.DataSource = MsgBLL.GetMsgHisByNick(Users.Nick);
            grdHisMsg.DataBind();

            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(Users.Nick);
            if (String.IsNullOrEmpty(checkIsExit) || !Convert.ToBoolean(checkIsExit))//账户未开通
            {
                MsgISCanUse.Text = "未开通";
            }
            else
            {//账户开通
                MsgISCanUse.Text = "已开通";
            }
            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbMsgCanUseCount.Text = tb.Rows[0]["msgCanUseCount"].ToString() + "条";
            }
            else
            {
                lbMsgCanUseCount.Text = "0条";
            }
        }



        private void MsgNofiySeller(String msg)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "msg", "alert('" + msg + "');", true);
            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "", "alert('确定!')", true);
        }

        protected void grdMessageTemp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -3)
            {
                //点击了Go按钮
                TextBox txtNewPageIndex = null;

                //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                GridViewRow pagerRow = theGrid.BottomPagerRow;

                if (pagerRow != null)
                {
                    //得到text控件
                    txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                }
                if (txtNewPageIndex != null)
                {
                    //得到索引
                    newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                }
            }
            else
            {
                //点击了其他的按钮
                newPageIndex = e.NewPageIndex;
            }
            //防止新索引溢出
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            //得到新的值
            theGrid.PageIndex = newPageIndex;

            //重新绑定
            MsgDataBind();
        }

        protected void grdMessageTemp_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string msgType = e.Row.Cells[3].Text.Trim();
                if (msgType.Equals("系统创建"))
                {
                    e.Row.Cells[4].Visible = false;
                }
            }
        }

        protected void grdHisMsg_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // 得到该控件
            GridView theGrid = sender as GridView;
            int newPageIndex = 0;
            if (e.NewPageIndex == -3)
            {
                //点击了Go按钮
                TextBox txtNewPageIndex = null;

                //GridView较DataGrid提供了更多的API，获取分页块可以使用BottomPagerRow 或者TopPagerRow，当然还增加了HeaderRow和FooterRow
                GridViewRow pagerRow = theGrid.BottomPagerRow;

                if (pagerRow != null)
                {
                    //得到text控件
                    txtNewPageIndex = pagerRow.FindControl("txtNewPageIndex") as TextBox;
                }
                if (txtNewPageIndex != null)
                {
                    //得到索引
                    newPageIndex = int.Parse(txtNewPageIndex.Text) - 1;
                }
            }
            else
            {
                //点击了其他的按钮
                newPageIndex = e.NewPageIndex;
            }
            //防止新索引溢出
            newPageIndex = newPageIndex < 0 ? 0 : newPageIndex;
            newPageIndex = newPageIndex >= theGrid.PageCount ? theGrid.PageCount - 1 : newPageIndex;

            //得到新的值
            theGrid.PageIndex = newPageIndex;

            //重新绑定
            MsgDataBind();
        }

        protected void imgNavSendMsg_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("message.aspx");
        }

        protected void ImageButton_Ok_Click(object sender, ImageClickEventArgs e)
        {
            

            DataTable dt = UserTempMsgOrderBLL.GetBuyerNick(Users.Nick);
            if (dt == null || dt.Rows.Count == 0)
            {
                //Response.Write("<script language='javascript'>alert('输入正确格式的条件！');</script>");
                return;
            }
            else
            {
                string orderid = dt.Rows[0]["orderId"].ToString();
                string FW_GOODS = dt.Rows[0]["FW_GOODS"].ToString();
                string CreateDate = dt.Rows[0]["CreateDate"].ToString();
                DateTime da = Convert.ToDateTime(CreateDate);
                DateTime daa = da.AddMinutes(-5);
                List<Top.Api.Domain.ArticleBizOrder> body = OrderPay(FW_GOODS, Users.Nick, daa.ToString());
                File.AppendAllText(@"D:\log\body.txt", body.Count.ToString(), Encoding.Default);
                //int s = body.IndexOf("<deadline>");
                //string deadline = body.Substring(s + 10, 19);
                ////XElement root = XElement.Parse(body.Remove(0, 39));
                //File.AppendAllText(@"D:\log\deadline.txt", deadline, Encoding.Default);
                if (body.Count>0)
                {
                    switch (FW_GOODS)
                    {
                        case "FW_GOODS-1000305107":
                            File.AppendAllText(@"D:\log\1000305107.txt", FW_GOODS, Encoding.Default);
                            OrderMsg("1000", 35, "0.035元/条");
                            break;
                        case "FW_GOODS-1000305512":
                            OrderMsg("2000", 70, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306533":
                            OrderMsg("5000", 175, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306628":
                            OrderMsg("10000", 350, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306704":
                            OrderMsg("20000", 700, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306705":
                            OrderMsg("50000", 1750, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306433":
                            OrderMsg("100000", 3500, "0.035元/条");
                            break;
                        case "FW_GOODS-1000306706":
                            OrderMsg("200000", 6800, "0.034元/条");
                            break;
                        default:
                            break;

                    }
                    MsgDataBind();
                    
                }
            }
        }

        protected void ImageButton_Cancle_Click(object sender, ImageClickEventArgs e)
        {

        }

        private string OrderPay(string FW_GOODS, string nick)
        {
            ITopClient client = TBManager.GetClient();
           VasSubscribeGetRequest req = new VasSubscribeGetRequest();
           req.ArticleCode = FW_GOODS;
           req.Nick = nick;
            VasSubscribeGetResponse rsp = client.Execute(req);
            return rsp.Body;
        }

        private List<Top.Api.Domain.ArticleBizOrder> OrderPay(string FW_GOODS, string nick, string StartCreated)
        {
            ITopClient client = TBManager.GetClient();
            VasOrderSearchRequest req = new VasOrderSearchRequest();
            req.ArticleCode = FW_GOODS;
            req.ItemCode = FW_GOODS+"-1";
            req.Nick = nick;
            req.StartCreated = DateTime.Parse(StartCreated);
            req.PageSize = 20L;
            req.PageNo = 1L;
            VasOrderSearchResponse rsp = client.Execute(req);
            return rsp.ArticleBizOrders;
        }

        private void OrderMsg(string msgCount, int price, string perPrice)
        {
            MsgPackage obj = new MsgPackage();
            obj.PackageName = "店铺管家短信套餐(淘宝)" + msgCount + "条";
            obj.Type = "永久有效";
            obj.SellerNick = Users.Nick;
            obj.Price = price;
            obj.PerPrice = perPrice;
            obj.Rank = "短信套餐(短信充值)";
            obj.OrderDate = DateTime.Now;
            obj.PayStatus = true;
            bool b = MsgBLL.AddMsgPackage(obj);
            File.AppendAllText(@"D:\log\AddMsgPackage.txt", b.ToString(), Encoding.Default);
            obj.CanUseStartDate = DateTime.Now;
            obj.MsgCanUseCount = Convert.ToInt32(msgCount);
            obj.MsgTotalCount = Convert.ToInt32(msgCount);
            MsgPagke(obj);

        }
        private void MsgPagke(MsgPackage obj)
        {
            bool b = false;
            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(obj.SellerNick);
            obj.ServiceStatus = true;
            if (String.IsNullOrEmpty(checkIsExit))//卖家第一次订购
            {
                b = MsgBLL.AddMsgTrans(obj);
            }
            else if (Convert.ToBoolean(checkIsExit))//如果成立，表示卖家短信套餐还未用完时继续充值，则叠加之前的短信条数
            {
                b = MsgBLL.UpdateMsgTransForSecond(obj);
            }
            else//表示卖家之前的短信套餐已经用完，再次充值。
            {
                b = MsgBLL.UpdateMsgTrans(obj);
            }

            File.AppendAllText(@"D:\log\UpdateMsgTrans.txt", b.ToString(), Encoding.Default);
        }

    }
}