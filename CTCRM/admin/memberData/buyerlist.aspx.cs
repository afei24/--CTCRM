using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CTCRM.Components;
using System.Data;
using System.IO;

namespace CTCRM.admin
{
    public partial class buyerlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_seller_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string nick = e.Row.Cells[0].Text;
                string count = BuyerBLL.GetBuyerCount("1", nick);
                if (string.IsNullOrEmpty(count)) { count = "0"; }
                e.Row.Cells[3].Text = count;
                e.Row.Attributes.Add("onmouseover", "c=this.style.backgroundColor;this.style.backgroundColor='#999999'");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=c");
                ((LinkButton)e.Row.Cells[3].FindControl("lbt_qBuerys")).CommandName = e.Row.Cells[0].Text;
            }
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
            gv_buyer.PageIndex = e.NewPageIndex;
            loadMember();
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
            worksheet.Name = "短信账户";
            //获取数据源
            DataTable dt = tb;
            //设置第行的宽度
            worksheet.Cells.SetColumnWidth(0, 0.4);

            #region 生成标题行
            //设置行的高度
            worksheet.Cells.SetRowHeight(row, 20);

            #region 手机号码
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("手机号码");
            FormatCellInBlue(worksheet.Cells[row, col++]);//01
            #endregion

            #region 发送日期
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("最后一次交易日期");
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
                //手机号码
                worksheet.Cells[row, col].PutValue(rows["CellPhone"]);
                FormatCell(worksheet.Cells[row, col++]);
                //发送日期
                worksheet.Cells[row, col].PutValue(rows["last_trade_time"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                row++;
            }
            #endregion
            string filepath = "";
            #region Sending file
            try
            {
                filepath = Server.MapPath(".");
                string filename = tb_nick.Text + ".csv";
                workbook.Save(filepath + "\\" + filename);
                HyperLink1.NavigateUrl =filename;
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
            if (tb_nick.Text == "") { return; }

            loadMember();

        }

        void loadMember()
        {
            string start = string.Empty;
            string end = string.Empty;
            start = txt_StartTime.Value;
            end = txt_EndTime.Value;
            if (start == "")
            {
                //查近三个月
                 end= DateTime.Now.Date.ToShortDateString();
                 start = DateTime.Now.Date.AddMonths(-3).ToShortDateString();
            }

            //开始查找数据
            tb_member = null;
            gv_buyer.DataSource = null;
            gv_buyer.DataBind();
            lb_buyerCount.Text = "";
            string nick_id = SellersBLL.GetSellerIdByNick(tb_nick.Text);
            if (!string.IsNullOrEmpty(nick_id))
            {
                tb_member = BuyerBLL.GetExportBuyers(tb_nick.Text, start, end, nick_id);
                if (tb_member != null && tb_member.Rows.Count > 0)
                {
                    gv_buyer.DataSource = tb_member.DefaultView;
                    gv_buyer.DataBind();
                    lb_buyerCount.Text = "（总计:" + tb_member.Rows.Count.ToString() + "行)";
                }
            }
        }



        /// <summary>
        /// Export the data from datatable to CSV file
        /// </summary>
        /// <param name="grid"></param>
        public void ExportDataGridToCSV(DataTable dt)
        {
            string strFile = "";
            string path = "";

            //File info initialization
            strFile = tb_nick.Text;
            strFile = strFile + DateTime.Now.ToString("yyyyMMddhhmmss");
            strFile = strFile + ".csv";
            path = Server.MapPath(strFile);
            
            System.IO.FileStream fs = new FileStream(path, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, new System.Text.UnicodeEncoding());
            //Tabel header
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sw.Write(dt.Columns[i].ColumnName);
                sw.Write("\t");
            }
            sw.WriteLine("");
            //Table body
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    sw.Write(DelQuota(dt.Rows[i][j].ToString()));
                    sw.Write("\t");
                }
                sw.WriteLine("");
            }
            sw.Flush();
            sw.Close();
            HyperLink1.NavigateUrl = strFile;
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
    }
}



