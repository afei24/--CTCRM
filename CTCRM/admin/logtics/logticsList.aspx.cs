using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using CTCRM.Components;
using CTCRM.DAL;
using Top.Api.Domain;
using TOPCRM;
using System.IO;


namespace CTCRM.admin.logtics
{
    public partial class logticsList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_buyer_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#999999'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
            }
        }

        protected void gv_buyer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //gv_buyer.PageIndex = e.NewPageIndex;
            //loadMember();
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

            #region 订单id
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("订单id");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
            #endregion
            #region 订单金额
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("订单金额");
            FormatCellInBlue(worksheet.Cells[row, col++]);//01
            #endregion

            #region 订单时间
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("订单时间");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
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
                worksheet.Cells[row, col].PutValue(rows["tid"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                //buyer_nick
                worksheet.Cells[row, col].PutValue(rows["payment"]);
                FormatCell(worksheet.Cells[row, col++]);
                //tid
                worksheet.Cells[row, col].PutValue(rows["createdate"]);
                FormatDateCell(worksheet.Cells[row, col++]);

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
                string filename = "导出订单.xls";
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

        protected void bt_Export_Click(object sender, EventArgs e)
        {
            //DownloadToExcel(tb_member);
            ExportDataGridToCSV(tb_member);
        }

        static DataTable tb_member = null;
        protected void bt_sosuo_Click(object sender, EventArgs e)
        {
            //搜索卖家已发货的订单
            //DataTable dt = new DataTable();
            //DataColumn dc = null;
            //dc = dt.Columns.Add("reciverName", Type.GetType("System.String"));
            //dc = dt.Columns.Add("cellPhone", Type.GetType("System.String"));
            //if (tb_nick.Text == "") { return; }
            //DataTable trade = TradeBLL.GetTradeData(tb_nick.Text.Trim(), "taobao_trade_TradeSellerShip");
            //Trade tradeInfo = null;
            //if (trade != null && trade.Rows.Count > 0)
            //{
            //    string key = SellersBLL.GetSellerSessionKey(tb_nick.Text);
            //    foreach (DataRow row in trade.Rows)//轮训订单
            //    {
            //        //获取订单id
            //        string tid = row["tid"].ToString();
            //        //调用淘宝接口获取订单详细交易信息
            //        tradeInfo = TBTrade.GetTradeContact(Convert.ToInt64(tid), key);
            //        string cellPhone = tradeInfo == null ? "" : tradeInfo.ReceiverMobile;
            //        string reciverName = tradeInfo == null ? "" : tradeInfo.ReceiverName;
            //        DataRow drow = dt.NewRow();
            //        drow["reciverName"] = reciverName;
            //        drow["cellPhone"] = cellPhone;
            //        dt.Rows.Add(drow);

            //    }
            //}
            //tb_member = dt;
            //gv_buyer.DataSource = dt.DefaultView;
            //gv_buyer.DataBind();
            //loadMember();
        }

        void loadMember()
        {
            //gv_buyer.DataSource = tb_member;
            //gv_buyer.DataBind();

        }

        /// <summary>
        /// Export the data from datatable to CSV file
        /// </summary>
        /// <param name="grid"></param>
        public void ExportDataGridToCSV(DataTable dt)
        {
            //string strFile = "";
            //string path = "";

            ////File info initialization
            //strFile = tb_nick.Text;
            //strFile = strFile + DateTime.Now.ToString("yyyyMMddhhmmss");
            //strFile = strFile + ".csv";
            //path = Server.MapPath(strFile);

            //System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            //StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            ////Tabel header
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    sw.Write(dt.Columns[i].ColumnName);
            //    sw.Write("\t");
            //}
            //sw.WriteLine("");
            ////Table body
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    for (int j = 0; j < dt.Columns.Count; j++)
            //    {
            //        sw.Write(DelQuota(dt.Rows[i][j].ToString()));
            //        sw.Write("\t");
            //    }
            //    sw.WriteLine("");
            //}
            //sw.Flush();
            //sw.Close();
            //HyperLink1.NavigateUrl = strFile;
            // DownLoadFile(path);
        }

        private bool DownLoadFile(string _FileName)
        {
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenRead(_FileName);
                byte[] FileData = new byte[fs.Length];
                fs.Read(FileData, 0, (int)fs.Length);
                Response.Clear();
                Response.AddHeader("Content-Type", "application/notepad");
                string FileName = System.Web.HttpUtility.UrlEncode(System.Text.Encoding.UTF8.GetBytes(_FileName));
                Response.AddHeader("Content-Disposition", "inline;filename=" + System.Convert.ToChar(34) + FileName + System.Convert.ToChar(34));
                Response.AddHeader("Content-Length", fs.Length.ToString());
                Response.BinaryWrite(FileData);
                fs.Close();
                System.IO.File.Delete(_FileName);
                Response.Flush();
                Response.End();
                return true;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
        }

        /// <summary>
        /// Delete special symbol
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string DelQuota(string str)
        {
            string result = str;
            string[] strQuota = { "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "`", ";", "'", ",", ".", "/", ":", "/,", "<", ">", "?" };
            for (int i = 0; i < strQuota.Length; i++)
            {
                if (result.IndexOf(strQuota[i]) > -1)
                    result = result.Replace(strQuota[i], "");
            }
            return result;
        }

        protected void btnMsgSend_Click(object sender, ImageClickEventArgs e)
        {
            string nick = TextBox4.Text.Trim();
            if (string.IsNullOrEmpty(nick))
            {
                Response.Write("<script language='javascript'>alert('填写卖家名称！');</script>");
                return;
            }
            BindData();
        }

        protected void BindData()
        {
            DataTable dt = new DataTable();
            DataColumn dc = null;
            string nick = TextBox4.Text.Trim();
           
            string startDate = txt_StartTime.Value;
            string endDate = txt_EndTime.Value;
            string startPay = TextBox2.Text.Trim(); 
            string endDPay = TextBox3.Text.Trim();
            try
            {
                if (!string.IsNullOrEmpty(startPay))
                {
                    Convert.ToInt32(startPay);
                }
                if (!string.IsNullOrEmpty(endDPay))
                {
                    Convert.ToInt32(endDPay);
                }

            }
            catch (Exception e)
            {
                Response.Write("<script language='javascript'>alert('输入正确格式的金额！');</script>");
                return;
            }

            dc = dt.Columns.Add("reciverName", Type.GetType("System.String"));
            dc = dt.Columns.Add("cellPhone", Type.GetType("System.String"));
            if (string.IsNullOrEmpty(nick) == true) { return; }
            DataTable trade = null;
            string select = drpSType.SelectedValue.ToString();
            switch (select)
            {
                case "sign_notSure":
                    trade = TradeBLL.GetTradeData(nick, startDate, endDate, startPay, endDPay, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSign":
                    trade = TradeBLL.GetTradeDataNosign(nick, startDate, endDate, startPay, endDPay, "taobao_trade_TradeSellerShip");
                    break;
                case "sure_notSucce":
                    trade = TradeBLL.GetTradeDataNoSuccess(nick, startDate, endDate, startPay, endDPay, "taobao_trade_TradeSellerShip");
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