using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CTCRM.WIN_Aspx.Smart
{
    public partial class area : System.Web.UI.Page
    {
        public string provinces;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HiddenField1.Value = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
                //if (RatingBLL.isBshop(Users.Nick))
                //{
                //    HiddenField1.Value = "【天猫】";
                //}
                //else
                //{
                //    HiddenField1.Value = "【淘宝】";
                //}
            }
            //检查卖家短信账户
            //if (!MsgBLL.CheckSellerMsgStatus())
            //{
            //    msgAcountCheck.Visible = true;
            //}
            //else
            //{
            //    msgAcountCheck.Visible = false;
            //}
            GetMsgCount();
        }
        private void GetMsgCount()
        {
            DataTable tb = MsgBLL.GetSellerMsgStatus(Users.Nick);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbMsgCount.Text = "剩余短信：" + tb.Rows[0]["msgCanUseCount"].ToString() + "条";
            }
            else
            {
                lbMsgCount.Text = "剩余短信：0条";
            }
        }
        #region 北方地区
        /// <summary>
        /// 北方地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnimgBaiFang_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetBaiFangBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbBaiFang.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbBaiFang.Text = "0人";
            }
            lbBaiFang.Visible = true;
            btnimgBaiFang.Visible = false;
        }
        #endregion

        #region 南方地区
        /// <summary>
        /// 南方地区
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void imgbtnNanfang_Click(object sender, ImageClickEventArgs e)
        {
            DataTable tb = SmartBLL.GetNanFangBuyersCount(Users.SellerId);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbNanfang.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbNanfang.Text = "0人";
            }
            lbNanfang.Visible = true;
            imgbtnNanfang.Visible = false;

        }
        #endregion

        protected void ButtonOk_Click(object sender, EventArgs e)
        {
            List<string> province = new List<string>();
            #region 选择省份
            if (CheckBoxBeijing.Checked)
            {
                province.Add("北京");
            }
            if (CheckBoxtTianjin.Checked)
            {
                province.Add("天津");
            }
            if (CheckBoxHebei.Checked)
            {
                province.Add("河北");
            }
            if (CheckBoxShanxi.Checked)
            {
                province.Add("山西");
            }
            if (CheckBoxNei.Checked)
            {
                province.Add("内蒙古");
            }
            if (CheckBoxLiao.Checked)
            {
                province.Add("辽宁");
            }
            if (CheckBoxJi.Checked)
            {
                province.Add("吉林");
            }
            if (CheckBoxHei.Checked)
            {
                province.Add("黑龙江");
            }
            if (CheckBoxShanghai.Checked)
            {
                province.Add("上海");
            }
            if (CheckBoxJiangsu.Checked)
            {
                province.Add("江苏");
            }
            if (CheckBoxZhejiang.Checked)
            {
                province.Add("浙江");
            }
            if (CheckBoxAnhui.Checked)
            {
                province.Add("安徽");
            }
            if (CheckBoxFujian.Checked)
            {
                province.Add("福建");
            }
            if (CheckBoxJiangxi.Checked)
            {
                province.Add("江西");
            }
            if (CheckBoxShandong.Checked)
            {
                province.Add("山东");
            }
            if (CheckBoxHenan.Checked)
            {
                province.Add("河南");
            }
            if (CheckBoxHubei.Checked)
            {
                province.Add("湖北");
            }
            if (CheckBoxHunan.Checked)
            {
                province.Add("湖南");
            }
            if (CheckBoxGuangdong.Checked)
            {
                province.Add("广东");
            }
            if (CheckBoxGuangxi.Checked)
            {
                province.Add("广西");
            }
            if (CheckBoxHainan.Checked)
            {
                province.Add("海南");
            }
            if (CheckBoxChongqing.Checked)
            {
                province.Add("重庆");
            }
            if (CheckBoxSichuang.Checked)
            {
                province.Add("四川");
            }
            if (CheckBoxGuizhou.Checked)
            {
                province.Add("贵州");
            }
            if (CheckBoxYunnan.Checked)
            {
                province.Add("云南");
            }
            if (CheckBoxXizang.Checked)
            {
                province.Add("西藏");
            }
            if (CheckBoxXi.Checked)
            {
                province.Add("陕西");
            }
            if (CheckBoxGansu.Checked)
            {
                province.Add("甘肃");
            }
            if (CheckBoxQinghai.Checked)
            {
                province.Add("青海");
            }
            if (CheckBoxNingxia.Checked)
            {
                province.Add("宁夏");
            }
            if (CheckBoxXinjiang.Checked)
            {
                province.Add("新疆");
            }
            if (CheckBoxTaiwan.Checked)
            {
                province.Add("台湾");
            }
            if (CheckBoxXianggang.Checked)
            {
                province.Add("香港");
            }
            if (CheckBoxAomen.Checked)
            {
                province.Add("澳门");
            }
           
            #endregion

            DataTable tb = SmartBLL.GetProvinceBuyersCount(Users.SellerId, province);
            if (tb != null && tb.Rows.Count > 0)
            {
                lbShengfen.Text = tb.Rows.Count.ToString() + "人";
            }
            else
            {
                lbShengfen.Text = "0人";
            }
            lbShengfen.Visible = true;

                for (int i = 0; i < province.Count; i++)
                {
                   provinces += province[i]+",";
                }
        }

        protected void ButtonCancle_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

    }
}