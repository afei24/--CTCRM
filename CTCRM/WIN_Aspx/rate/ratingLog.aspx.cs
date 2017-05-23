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

namespace CTCRM.WIN_Aspx.rate
{
    public partial class ratingLog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //datePickerStart.Value = DateTime.Now.AddMonths(-1).ToShortDateString();
                //datePickerEnd.Value = DateTime.Now.ToShortDateString();
                this.grdRateLogList.DataSource = null;
                this.grdRateLogList.DataBind();
                versionControl.Visible = false;
            }
        }

        protected void BindData()
        {
            RatingBLL objDal = new RatingBLL();
            string startDate = datePickerStart.Value;
            string endDate = datePickerEnd.Value;
            DataTable ds = objDal.GetAutoRateListByNick(Users.Nick, startDate, endDate);
            //根据分页情况将数据写入或者更新到数据库
            this.grdRateLogList.DataSource = ds;
            this.grdRateLogList.DataBind();
        }

        protected void grdRateLogList_PageIndexChanging(object sender, GridViewPageEventArgs e)
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

        protected void btnimgSearch_Click(object sender, ImageClickEventArgs e)
        {
            BindData();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            string startDate = datePickerStart.Value;
            string endDate = datePickerEnd.Value;
            RatingBLL objDal = new RatingBLL();
            DataTable tb = objDal.GetAutoRateListByNick(Users.Nick, startDate, endDate);
            try
            {
                if (tb != null && tb.Rows.Count > 0)
                {
                    DownloadToExcel(tb);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('没有可以导出的日期！');</script>");
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
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
            worksheet.Name = "评价日志";


            //获取数据源
            DataTable dt = tb;
            //设置第行的宽度
            worksheet.Cells.SetColumnWidth(0, 0.4);

            #region 生成标题行

            //设置行的高度
            worksheet.Cells.SetRowHeight(row, 20);

            #region 评价时间
            worksheet.Cells.SetColumnWidth(col, 8.9);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("评价时间");
            FormatCellInBlue(worksheet.Cells[row, col++]); // 01
            #endregion

            #region 订单编号
            worksheet.Cells.SetColumnWidth(col, 12);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("订单编号");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
            #endregion

            #region 评价内容
            worksheet.Cells.SetColumnWidth(col, 11.6);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("评价内容");
            FormatCellInBlue(worksheet.Cells[row, col++]);//03
            #endregion

            row++;

            #endregion

            #region 放值

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //定义行数为1
                col = 0;
                DataRow rows = dt.Rows[i];
                //评价时间
                worksheet.Cells[row, col].PutValue(rows["created"].ToString());
                FormatDateCell(worksheet.Cells[row, col++]);  // 01
                //订单编号
                worksheet.Cells[row, col].PutValue(rows["tid"]);
                FormatCell(worksheet.Cells[row, col++]);
                //评价内容
                worksheet.Cells[row, col].PutValue(rows["content"]);
                FormatCell(worksheet.Cells[row, col++]);

                row++;
            }
            #endregion
            string filepath = "";

            #region Sending file
            try
            {
                filepath = Server.MapPath(".");
                string filename = "rateLog.xls";
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
    }
}