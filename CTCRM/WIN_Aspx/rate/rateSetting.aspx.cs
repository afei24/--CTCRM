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
using CTCRM.Entity;
using Top.Api;
using CTCRM.Components.TopCRM;
using Top.Api.Request;
using Top.Api.Response;
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using System.Drawing;
using Top.Api.Domain;

namespace CTCRM.WIN_Aspx.rate
{
    //修改代码
    //修改人：LU
    //时间：20160908
    public partial class rateSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //ExceptionReporter.WriteLog("OrderVersion:" + Users.OrderVersion, ExceptionPostion.TBApply_Data, ExceptionRank.important);
                //if (!Users.OrderVersion.Equals("自动评价版") && !Users.OrderVersion.Equals("全功能版"))
                //{
                //    Response.Write("<script languge='javascript'>alert('没有权限使用，请订购对应的软件版本'); window.location.href='http://fuwu.taobao.com/ser/detail.htm?service_code=ts-1811102'</script>");
                //    return;
                //}
                //versionControl.Visible = false;
                //HyperLink1.Visible = false;
                //初始化页面配置
                RatingBLL objBll = new RatingBLL();
                DataTable tb = objBll.GetRateConfigByNick(Users.Nick);
                if (tb != null && tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["isAutoRating"].ToString().Equals("1"))
                    {
                        imgBtnOpenRatingAtuo.ImageUrl = "~/Win_Image/2open.png";
                    }
                    else
                    {
                        imgBtnOpenRatingAtuo.ImageUrl = "~/Win_Image/1close.png";
                    }
                    if (tb.Rows[0]["isMiaoRate"].ToString().Equals("1"))
                    {
                        rdoMiaoPing.Checked = true;
                    }
                    if (tb.Rows[0]["isWaitBuyerRate"].ToString().Equals("1"))
                    {
                        rdoBuyerRated.Checked = true;
                    }
                    drpFangAn2Day.SelectedValue = tb.Rows[0]["waitBuyerTimeDay"].ToString();
                    drpFangAn2Hour.SelectedValue = tb.Rows[0]["waitBuyerTimeHour"].ToString();
                    drpFangAn2Minute.SelectedValue = tb.Rows[0]["waitBuyerTimeFen"].ToString();

                    if (tb.Rows[0]["blackBuyerRatedIsRate"].ToString().Equals("1")) { rdoFangAn2NotAtuo.Checked = true; }
                    if (tb.Rows[0]["blackBuyerRatedIsRate"].ToString().Equals("2")) { rdoFangAn2AtuoGoodRate.Checked = true; }
                    if (tb.Rows[0]["blackBuyerRatedIsRate"].ToString().Equals("3")) { rdoFangAn2AtuoNureRate.Checked = true; }
                    if (tb.Rows[0]["blackBuyerRatedIsRate"].ToString().Equals("4")) { rdoFangAn2AtuoPoolRate.Checked = true; }

                    drpFangAn2BacklstDay.SelectedValue = tb.Rows[0]["blackBuyerNoRateQiangRateDay"].ToString();
                    drpFangAn2BacklstHour.SelectedValue = tb.Rows[0]["blackBuyerNoRateQiangRateHour"].ToString();
                    drpFangAn2BacklstMinute.SelectedValue = tb.Rows[0]["blackBuyerNoRateQiangRateFen"].ToString();



                    if (tb.Rows[0]["isQiangRate"].ToString().Equals("1"))
                    {
                        rdoAutoRate.Checked = true;
                    }
                    drpFangAn3Day.SelectedValue = tb.Rows[0]["qiangRateTimeDay"].ToString();
                    drpFangAn3Hour.SelectedValue = tb.Rows[0]["qiangRateTimeHour"].ToString();
                    drpFangAn3Minute.SelectedValue = tb.Rows[0]["qiangRateTimeFen"].ToString();
                    if (tb.Rows[0]["atuoAddBlackListBadRate"].ToString().Equals("1"))
                    {
                        cbBlakList.Checked = true;
                    }
                    if (tb.Rows[0]["atuoAddBlackListTuiKuan"].ToString().Equals("1"))
                    {
                        cbAddBlacklstTuikuan.Checked = true;
                    }

                    drpContentChoice.SelectedValue = tb.Rows[0]["contentChoice"].ToString();
                    txtPoolRateContent.Text = tb.Rows[0]["badRateContent"].ToString();

                    txtRateTemp1.Text = tb.Rows[0]["content1"].ToString();
                    txtRateTemp2.Text = tb.Rows[0]["content2"].ToString();
                    txtRateTemp3.Text = tb.Rows[0]["content3"].ToString();
                }
            }
            lberror2.Text = "";
            Label2.Text = "";
            Page.MaintainScrollPositionOnPostBack = true;
        }

        //保存评价配置
        protected void btnSaveRateConfig_Click(object sender, ImageClickEventArgs e)
        {
            //DataRow orderDate = SellersBLL.GetSelerOrderDate(Users.Nick);
            //if (orderDate != null)
            //{
            //    if (orderDate["OrderVersion"].Equals("体验版"))
            //    {
            //        versionControl.Visible = true;
            //        return;
            //    }
            //}
            RateConfig rateObj = new RateConfig();
            rateObj.SellerNick = Users.Nick;
            RatingBLL objBll = new RatingBLL();

            #region 自动评价设置
            //秒评
            if (rdoMiaoPing.Checked)
            {
                rateObj.IsMiaoRate = 1;
                //选择秒评,则自动开启主动通知授权
                ITopClient client = TBManager.GetClient();
                TmcUserPermitRequest req = new TmcUserPermitRequest();
                TmcUserPermitResponse response = client.Execute(req, Users.SessionKey);
                AppCustomer appCus = null;
                if (response.IsSuccess)
                {
                    appCus = new AppCustomer();
                    appCus.Status = "1";
                    appCus.Nick = Users.Nick;
                    appCus.Created = DateTime.Now.ToShortDateString();

                    //检查卖家是否开启自动评价，如果已开启略过，未开启则开启
                    if (!objBll.CheckAppCusIsExit(Users.Nick))
                    {
                        objBll.AddAppCus(appCus);
                    }
                }
                else
                {
                    lberror2.Text = response.ErrMsg;
                    //Response.Write("<script>alert('" + response.ErrMsg + "');</script>");
                    //lberror2.ForeColor = Color.Red;
                }
            }
            else //其它情况则关闭主动通知消息,删除的前提是用户没有开通差评自动拦截
            {

                //检查卖家是否开启自动评价，如果已开启关闭，未开启则略过
                if (objBll.CheckAppCusIsExit(Users.Nick))
                {
                    //检查卖家差评自动拦截开关是否开启
                    if (!objBll.CheckIsAutoCloseOrder(Users.Nick))
                    {
                        ITopClient client = TBManager.GetClient();
                        TmcUserCancelRequest req = new TmcUserCancelRequest();
                        req.Nick = Users.Nick;
                        TmcUserCancelResponse response = client.Execute(req);
                        if (response.IsSuccess)
                        {
                            objBll.DeleteSellerNifty(Users.Nick);
                        }
                        else
                        {
                            lberror2.Text = response.ErrMsg;
                            Response.Write("<script>alert('" + response.ErrMsg + "');</script>");
                            //lberror2.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        lberror2.Text = "请先关闭差评自动拦截开关！";
                        //lberror2.ForeColor = Color.Red;
                    }

                }
            }
            //买家评价以后评价
            if (rdoBuyerRated.Checked)
            {
                rateObj.IsWaitBuyerRate = 1;
                rateObj.WaitBuyerTimeDay = Convert.ToInt32(drpFangAn2Day.SelectedValue);
                rateObj.WaitBuyerTimeHour = Convert.ToInt32(drpFangAn2Hour.SelectedValue);
                rateObj.WaitBuyerTimeFen = Convert.ToInt32(drpFangAn2Minute.SelectedValue);
                if (rdoFangAn2NotAtuo.Checked)
                {
                    rateObj.BlackBuyerRatedIsRate = 1;
                }
                if (rdoFangAn2AtuoGoodRate.Checked)
                {
                    rateObj.BlackBuyerRatedIsRate = 2;
                }
                if (rdoFangAn2AtuoNureRate.Checked)
                {
                    rateObj.BlackBuyerRatedIsRate = 3;
                }
                if (rdoFangAn2AtuoPoolRate.Checked)
                {
                    rateObj.BlackBuyerRatedIsRate = 4;
                }
                rateObj.BlackBuyerNoRateQiangRateDay = Convert.ToInt32(drpFangAn2BacklstDay.SelectedValue);
                rateObj.BlackBuyerNoRateQiangRateHour = Convert.ToInt32(drpFangAn2BacklstHour.SelectedValue);
                rateObj.BlackBuyerNoRateQiangRateFen = Convert.ToInt32(drpFangAn2BacklstMinute.SelectedValue);
                rateObj.BadRateContent = txtPoolRateContent.Text.Trim();
            }
            //在交易完成后多长时间评价
            if (rdoAutoRate.Checked)
            {
                rateObj.IsQiangRate = 1;
                rateObj.QiangRateTimeDay = Convert.ToInt32(drpFangAn3Day.SelectedValue);
                rateObj.QiangRateTimeHour = Convert.ToInt32(drpFangAn3Hour.SelectedValue);
                rateObj.QiangRateTimeFen = Convert.ToInt32(drpFangAn3Minute.SelectedValue);
            }
            #endregion

            #region 中差评设置
            if (cbBlakList.Checked)
            {
                //自动把给我中差评的买家加入黑名单
                rateObj.AtuoAddBlackListBadRate = 1;
            }
            if (cbAddBlacklstTuikuan.Checked)
            {
                //把半年内有退款申请的买家加入黑名单
                rateObj.AtuoAddBlackListTuiKuan = 1;
            }
            #endregion

            //默认为好评
            rateObj.Result = "good";
            //rateObj.Result = "bad"; 
            if (!string.IsNullOrEmpty(txtRateTemp1.Text.Trim()))
            {
                rateObj.Content1 = txtRateTemp1.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtRateTemp2.Text.Trim()))
            {
                rateObj.Content2 = txtRateTemp2.Text.Trim();
            }
            if (!string.IsNullOrEmpty(txtRateTemp3.Text.Trim()))
            {
                rateObj.Content3 = txtRateTemp3.Text.Trim();
            }
            rateObj.ContentChoice = int.Parse(drpContentChoice.SelectedValue);

            //检查评价配置表是否存在卖家
            if (!objBll.CheckRateConfigIsExit(Users.Nick))
            {
                try
                {
                    objBll.AddRateConfig(rateObj);
                    if (string.IsNullOrEmpty(lberror2.Text))
                    {
                        lberror2.Text = "评价条件设置保存成功！";
                        //Response.Write("<script>alert('评价条件设置保存成功,请确保开启自动评价开关！');</script>");
                        //lberror2.ForeColor = Color.Blue;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                    Response.Write("<script>alert('评价条件修改失败！');</script>");
                }
            }
            else
            { //更新评价配置策略
                objBll.UpdateRateConfig(rateObj);
                if (string.IsNullOrEmpty(lberror2.Text))
                {
                    lberror2.Text = "评价条件修改成功！";
                    //Response.Write("<script>alert('评价条件修改成功！');</script>");
                   // lberror2.ForeColor = Color.Blue;
                }
            }
        }

        /// <summary>
        /// 开启和关闭自动评价
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgBtnOpenRatingAtuo_Click(object sender, ImageClickEventArgs e)
        {
            RatingBLL objRate = new RatingBLL();
            if (!objRate.CheckRateConfigIsExit(Users.Nick))
            {
                //Response.Write("<script>alert('先保存评价设置，才能开启自动评价！');</script>");
                Label2.Text = "先保存评价设置，才能开启自动评价！";
                Label2.Visible = true;
                return;
            }
            else if (RatingBLL.isBshop(Users.Nick))//检查卖家店铺类型
            {
                Label2.Text = "天猫卖家不能使用自动评价功能！";
                Label2.Visible = true;
                return;
            }
            else
            {
                DataTable tb = objRate.GetRateConfigByNick(Users.Nick);
                //开启或关闭自动评价
                if (tb != null && tb.Rows.Count > 0)
                {
                    if (tb.Rows[0]["isAutoRating"].ToString().Equals("1"))
                    {
                        imgBtnOpenRatingAtuo.ImageUrl = "~/Win_Image/1close.png";
                        objRate.UpdateAutoRatingStatus(Users.Nick, 0);
                    }
                    else
                    {
                        imgBtnOpenRatingAtuo.ImageUrl = "~/Win_Image/2open.png";
                        objRate.UpdateAutoRatingStatus(Users.Nick, 1);
                    }
                }
            }
        }



    }
}