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
using CTCRM.Components;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Drawing;
using CTCRM.Entity;
using CTCRM.DAL;

namespace CTCRM.admin.message
{
    public partial class sellerMsgAcount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["LOGINUSERNAME"] == null && !Convert.ToString(Session["LOGINUSERNAME"]).Equals("kimluo"))
            //{
            //    Response.Redirect("~/admin/Login.aspx?");
            //}
            //初始化分页控件
            if (!Page.IsPostBack)
            {
                //drpStatus.Items.Insert(0, "---审核状态---");
                MsgDataBind();
                //日期显示为只读
                txt_StartTime.Attributes.Add("readonly", "readonly");
                txt_EndTime.Attributes.Add("readonly", "readonly");
            }
        }

        static DataTable dt = null;
        private void MsgDataBind()
        {
            try
            {
                dt = SellersBLL.GetSellerMsgAccount(txtTitle.Text.Trim(), txt_StartTime.Value, txt_EndTime.Value);
                grdCus.DataSource = dt;
                grdCus.DataBind();
                DataTable tb = SellersBLL.GetUnUsedMsgAccount();
                if (tb != null && tb.Rows.Count == 1)
                {
                    lbMsgCount.Text = "剩余短信： " + tb.Rows[0]["totalCount"].ToString() + " 条"; ;
                    lbSpendFee.Text = "未消费成本：" + tb.Rows[0]["spendMoney"].ToString() + " 元";
                    DateTime dd = Convert.ToDateTime(dt.Rows[0]["unUseDate"]) ;
                }
                else
                {
                    lbMsgCount.Text = "剩余短信： 0 条";
                    lbSpendFee.Text = "未消费成本： 0 元";
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }


        private void CheckValues()
        {
            if (!String.IsNullOrEmpty(txt_StartTime.Value.Trim()) && !String.IsNullOrEmpty(txt_EndTime.Value.Trim()))
            {
                if (DateTime.Parse(txt_StartTime.Value) > DateTime.Parse(txt_EndTime.Value))
                {
                    Response.Write("<script language='javascript'>alert('开始日期必须小于等于结束日期！');</script>");
                    return;
                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CheckValues();
                MsgDataBind();
            }
            catch (Exception ex)
            {
                // 数据检索失败！
                Response.Write("<script language='javascript'>alert('加载数据失败！');</script>");
            }
        }


        protected void grdCus_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void grdCus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string canUseMsg = e.Row.Cells[3].Text.Trim();
                    if (canUseMsg.Equals("0") || canUseMsg.Equals("-1"))
                    {
                        
                       
                        e.Row.Cells[3].ForeColor = Color.Red;
                    }
                    string nick = e.Row.Cells[0].Text.Trim();
                    if (!string.IsNullOrEmpty(nick))
                    {
                        string sydate = SellersBLL.GetSellerSynDate(nick);
                        if (string.IsNullOrEmpty(sydate) == false)
                        {
                            e.Row.Cells[6].Text = sydate;
                        }
                        else
                        {
                            e.Row.Cells[6].Text = "还未同步";
                        }
                    }
                    string msgStatus = e.Row.Cells[5].Text.Trim();
                    if (msgStatus.Equals("False"))
                    {
                        e.Row.Cells[5].ForeColor = Color.Red;
                        e.Row.Cells[5].Text = "不可用";
                    }

                 
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var checkIsExit = MsgBLL.CheckSellerMsgTransIsExit(txtNick.Text.Trim());
            if (String.IsNullOrEmpty(checkIsExit))//卖家第一次订购
            {
                MsgPackage obj = new MsgPackage();
                obj.PackageName = "店铺管家短信套餐(淘宝)" + txtCount.Text.Trim() + "条";
                obj.Type = "赠送短信";
                obj.SellerNick = txtNick.Text.Trim();
                obj.Price = 0;
                obj.PerPrice = "0";
                obj.Rank = "短信套餐(赠送)";
                obj.OrderDate = DateTime.Now;
                obj.PayStatus = true;
                MsgBLL.AddMsgPackage(obj);
                obj.CanUseStartDate = DateTime.Now;
                obj.MsgCanUseCount = Convert.ToInt32(txtCount.Text.Trim());
                obj.MsgTotalCount = Convert.ToInt32(txtCount.Text.Trim());
                obj.ServiceStatus = true;
                MsgBLL.AddMsgTrans(obj);
                lbMsg.Text = "增加成功";
            }
            else
            {
                    MsgPackage obj = new MsgPackage();
                    obj.PackageName = "店铺管家短信套餐(淘宝)" + txtCount.Text.Trim() + "条";
                    obj.Type = "赠送短信";
                    obj.SellerNick = txtNick.Text.Trim();
                    obj.Price = 0;
                    obj.PerPrice = "0";
                    obj.Rank = "短信套餐(手动添加)";
                    obj.OrderDate = DateTime.Now;
                    obj.PayStatus = true;
                    MsgBLL.AddMsgPackage(obj);
                    obj.MsgCanUseCount = Convert.ToInt32(txtCount.Text.Trim());
                    obj.MsgTotalCount = Convert.ToInt32(txtCount.Text.Trim());
                    MsgBLL.UpdateMsgTransForSecond(obj);
                    lbMsg.Text = "追加成功";
                
            }
        }

        protected void bt_all_Click(object sender, EventArgs e)
        {

            int j = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    try
                    {
                        string seller = Convert.ToString(dt.Rows[i]["sellerNick"]);
                        string seller_id = SellersBLL.GetSellerIdByNick(seller);
                        if (!string.IsNullOrEmpty(seller_id))
                        {

                            long count = Convert.ToInt32(BuyerBLL.GetBuyerCount("1", seller));
                            if (count > 0)
                            {

                            }
                            else
                            {
                                SellersDAL sellerdl = new SellersDAL();
                                sellerdl.addBuyerData(seller_id);
                                j++;
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    lb_num.Text = j.ToString();
                }
            }
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {
            int percent = -1;
            try
            {
                percent = Convert.ToInt32(tboxPrecent.Text.Trim());
            }
            catch (Exception ee)
            {
                Response.Write("<script language='javascript'>alert('请正确填写百分数！');</script>");
                return;
            }
            try
            {
                if (percent == -1)
                {
                    Response.Write("<script language='javascript'>alert('请填写百分数！');</script>");
                    return;
                }
                SellersBLL.UpdateSellerMsgsendPrecent(tboxNick.Text.Trim(), percent);
            }
            catch(Exception esss)
            {
                Response.Write("<script language='javascript'>alert('设置失败！');</script>");
            }
        }
    }
}
