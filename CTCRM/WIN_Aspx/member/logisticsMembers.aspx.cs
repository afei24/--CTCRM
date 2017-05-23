using CTCRM.Components;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TOPCRM;
using System.IO;
using CTCRM.DAL;
using Top.Api.Domain;
using CTCRM.Common;
using System.Collections;
using CTCRM.Entity;
using Top.Api.Util;

namespace CTCRM.WIN_Aspx.member
{
    public partial class logisticsMember : System.Web.UI.Page
    {
        static DataTable tb_member = null;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMsgSend_Click(object sender, ImageClickEventArgs e)
        {
            BindData();

        }

        protected void BindData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            string nick = Users.Nick;
            dc = dt.Columns.Add("reciverName", Type.GetType("System.String"));
            dc = dt.Columns.Add("cellPhone", Type.GetType("System.String"));
            if (string.IsNullOrEmpty(nick) == true) { return; }
            DataTable trade = null;
            string select = drpSType.SelectedValue.ToString();
            switch (select)
            {
                case "sign_notSure":
                    trade = TradeBLL.GetTradeData(nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSign": 
                    trade = TradeBLL.GetTradeDataNosign(nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSucce": 
                trade = TradeBLL.GetTradeDataNoSuccess(nick, "taobao_trade_TradeSellerShip");
                    break;
            }
            Trade tradeInfo = null;
            if (trade != null && trade.Rows.Count > 0)
            {
                string key = SellersBLL.GetSellerSessionKey(nick);
                foreach (DataRow row in trade.Rows)//轮训订单
                {
                    //获取订单id
                    string tid = row["tid"].ToString();
                    //调用淘宝接口获取订单详细交易信息
                    tradeInfo = TBTrade.GetTradeContact(Convert.ToInt64(tid), key);
                    string cellPhone = tradeInfo == null ? "" : tradeInfo.ReceiverMobile;
                    string reciverName = tradeInfo == null ? "" : tradeInfo.ReceiverName;
                    DataRow drow = dt.NewRow();
                    drow["reciverName"] = reciverName;
                    drow["cellPhone"] = cellPhone;
                    dt.Rows.Add(drow);

                }
            }
            tb_member = dt;
            grdBuyer.DataSource = trade;
            grdBuyer.DataBind();
        }

        protected void grdBuyer_PageIndexChanging(object sender, GridViewPageEventArgs e)
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
            BindData();
        }

        #region EXCEL私有方法

        private void FormatCell(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.IsTextWrapped = true;
        }

        private void FormatNumberCell(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.IsTextWrapped = true;
            cell.Style.HorizontalAlignment = Aspose.Cells.TextAlignmentType.Center;
        }

        private void FormatDateCell(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            // TODO: add date formatting information
            cell.Style.Custom = "yy 年 mm 月 dd 日 hh : mm : ss";

        }

        private void FormatCellInBlue(Aspose.Cells.Cell cell)
        {
            //cell.Style.Borders = .SetStyle(Aspose.Cells.CellBorderType.Thin);
            // cell.Style.Borders.SetColor(System.Drawing.Color.Black);
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 255);
            cell.Style.Pattern = Aspose.Cells.BackgroundType.Solid;
        }

        private void FormatCellInYellow(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.ForegroundColor = System.Drawing.Color.Yellow;
            cell.Style.Pattern = Aspose.Cells.BackgroundType.Solid;

        }

        private void FormatCellInGreen(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.ForegroundColor = System.Drawing.Color.FromArgb(153, 204, 0);
            cell.Style.Pattern = Aspose.Cells.BackgroundType.Solid;


        }

        private void FormatCellInBeige(Aspose.Cells.Cell cell)
        {
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.BottomBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.LeftBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.RightBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].Color = System.Drawing.Color.Black;
            cell.Style.Borders[Aspose.Cells.BorderType.TopBorder].LineStyle = Aspose.Cells.CellBorderType.Thin;
            //把color修改成system.Drawing.Color
            cell.Style.ForegroundColor = System.Drawing.Color.FromArgb(255, 204, 153);
            cell.Style.Pattern = Aspose.Cells.BackgroundType.Solid;
        }

        #endregion

        private void DownloadToExcel(DataTable tb)
        {
            //定义一个行和列的宽度
            int col = 0;
            int row = 1;
            //定义一个执照
            Aspose.Cells.License license = new Aspose.Cells.License();
            license.SetLicense("Aspose.Cells.lic");
            //license.SetLicense("License.lic");
            //定义 excel一个工作薄
            Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();
            //定义一个工作页名称
            Aspose.Cells.Worksheet worksheet = workbook.Worksheets[0];
            //工作页的名称
            worksheet.Name = "物流未签收";
            //获取数据源
            DataTable dt = tb;
            //设置第行的宽度
            worksheet.Cells.SetColumnWidth(0, 0.4);

            #region 生成标题行
            //设置行的高度
            worksheet.Cells.SetRowHeight(row, 20);

            #region 买家昵称
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("买家昵称");
            FormatCellInBlue(worksheet.Cells[row, col++]);//01
            #endregion

            #region 订单状态
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("订单状态");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
            #endregion

            row++;

            #endregion

            #region 放值

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //定义行数为1
                col = 0;
                DataRow rows = dt.Rows[i];
                //buyer_nick
                worksheet.Cells[row, col].PutValue(rows["buyer_nick"]);
                FormatCell(worksheet.Cells[row, col++]);
                //tid
                worksheet.Cells[row, col].PutValue(rows["stutas"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                row++;
            }
            #endregion
            string filepath = "";
            #region Sending file
            try
            {
                filepath = Server.MapPath(".");
                string filename = Users.Nick + ".xls";
                workbook.Save(filepath + "\\" + filename);
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                Response.WriteFile(filepath + "\\" + filename);
                Response.Flush();
                System.IO.File.Delete(filepath + "\\" + filename);
                Response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            #endregion

            dt.Dispose();
        }




        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (string.IsNullOrEmpty(TextBox2.Text))
            {
                Response.Write("<script language='javascript'>alert('请输入发送内容！');</script>");
                return;
            }

            DataTable trade = null;
            string sigName = "【" + SellersBLL.GetSignName(Users.Nick) + "】";
            string select = drpSType.SelectedValue.ToString();
            switch (select)
            {
                case "sign_notSure":
                    trade = TradeBLL.GetTradeData(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSign":
                    trade = TradeBLL.GetTradeDataNosign(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSucce":
                    trade = TradeBLL.GetTradeDataNoSuccess(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
            }
            if (trade == null || trade.Rows.Count == 0)
            {
                Response.Write("<script language='javascript'>alert('无数据！');</script>");
                return;
            }
            for (int i = 0; i < trade.Rows.Count; i++)
            {
                DataTable ds = BuyerBLL.GetBuyerInfo(trade.Rows[i]["buyer_nick"].ToString(), "all", "all", "all", "", "", "", Users.Nick, "");
                if (ds == null || ds.Rows.Count == 0)
                {
                    continue;
                }
                string cellPhone = ds.Rows[i]["CellPhone"].ToString();

                try
                {
                    //判断手机
                    if (Utility.IsCellPhone(cellPhone))
                    {
                        if (MsgBLL.CheckSellerMsgStatus())
                        {
                            MsgSendHis objHis = new MsgSendHis();
                            objHis.TransNumber = DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + cellPhone;//手机号码 2016 yao c
                            objHis.SellerNick = Users.Nick;
                            //objHis.SellerNick = "澄腾科技"; 
                            objHis.Buyer_nick = "*****";
                            objHis.CellPhone = cellPhone;
                            objHis.SendDate = DateTime.Now;
                            objHis.SendType = "手工发送";
                            objHis.SendStatus = "0";
                            objHis.Count = "1";
                            //objHis.MsgContent = "【" + SellersBLL.GetSignName(Users.Nick) + "】" + txtContent.Text.Trim();// +"退订回T";
                            objHis.MsgContent = sigName + TextBox2.Text + " 退订回N";
                            if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                            {
                                objHis.HelpSellerNick = "电信联通";
                            }
                            else
                            {
                                objHis.HelpSellerNick = "移动";
                            }
                            //if (true) test
                            if (SmartBLL.AddMsgSendHis(objHis))
                            {
                                try
                                {
                                    objHis.MsgContent = objHis.MsgContent.Replace(" ", "");
                                    if (objHis.MsgContent.Length <= 70)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 1);
                                    }
                                    else if (objHis.MsgContent.Length > 70 && objHis.MsgContent.Length <= 134)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 2);
                                    }
                                    else if (objHis.MsgContent.Length > 134 && objHis.MsgContent.Length <= 195)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 3);
                                    }
                                    else if (objHis.MsgContent.Length > 195 && objHis.MsgContent.Length <= 260)
                                    {
                                        MsgBLL.UpdateMsgTransUseCount(Users.Nick, 4);
                                    }


                                    if (!Utility.IsYiDongCellPhoneNo(cellPhone))
                                    {
                                        //string sendStatus = Mobile.SendMsgKeTongDX(cellPhone, objHis.MsgContent);

                                        string sendStatus = Mobile.PostDataToMyServer(cellPhone, objHis.MsgContent.Trim());//20160626 yao c
                                        IDictionary resultDic = TopUtils.ParseJson(sendStatus);
                                        SmartBLL.UpdateSendStatus(resultDic["status"].ToString(), objHis.TransNumber);
                                    }
                                    else
                                    {
                                        string sendStatus = Mobile.SendMsgHubeiYDPost(cellPhone, objHis.MsgContent);//\r\n\r\n\r\n\r\n0
                                        sendStatus = sendStatus.Replace("\r", "").Replace("\n", "");
                                        if (sendStatus.Equals("0")) { sendStatus = "100"; }
                                        SmartBLL.UpdateSendStatus(sendStatus, objHis.TransNumber);

                                    }

                                }
                                catch (Exception ex)
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Response.Write("<script language='javascript'>alert('余额不足！');</script>");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            Response.Write("<script language='javascript'>alert('发送成功！');</script>");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            DataTable trade = null;
            string select = drpSType.SelectedValue.ToString();
            switch (select)
            {
                case "sign_notSure":
                    trade = TradeBLL.GetTradeData(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSign":
                    trade = TradeBLL.GetTradeDataNosign(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSucce":
                    trade = TradeBLL.GetTradeDataNoSuccess(Users.Nick, "taobao_trade_TradeSellerShip");
                    break;
            }
            DownloadToExcel(trade);
        }

    }
}