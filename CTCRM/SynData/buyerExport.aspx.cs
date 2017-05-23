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
using CHENGTUAN.Components;
using CHENGTUAN.Entity;
using CTCRM.Components;
using Top.Api.Domain;

namespace CTCRM.Download
{
    public partial class buyerExport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                versionControl.Visible = false;
            }
            //防止二次提交
            imgbtnExport.Attributes.Add("onclick", "this.disabled=true;" + this.ClientScript.GetPostBackEventReference(imgbtnExport, "")); 
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
            worksheet.Name = "会员信息";


            //获取数据源
            DataTable dt = tb;
            //设置第行的宽度
            worksheet.Cells.SetColumnWidth(0, 0.4);

            #region 生成标题行

            //设置行的高度
            worksheet.Cells.SetRowHeight(row, 20);

            #region 买家昵称
            worksheet.Cells.SetColumnWidth(col, 8.9);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("买家昵称");
            FormatCellInBlue(worksheet.Cells[row, col++]); // 01
            #endregion

            #region 姓名
            worksheet.Cells.SetColumnWidth(col, 12);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("姓名");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
            #endregion

            #region 所在省份
            worksheet.Cells.SetColumnWidth(col, 11.6);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("所在省份");
            FormatCellInBlue(worksheet.Cells[row, col++]);//03
            #endregion

            #region 手机号码
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("手机号码");
            FormatCellInBlue(worksheet.Cells[row, col++]);//04
            #endregion

            #region 会员级别
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("会员级别");
            FormatCellInBlue(worksheet.Cells[row, col++]);//05
            #endregion

            #region 消费金额
            worksheet.Cells.SetColumnWidth(col, 9.8);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("消费金额");
            FormatCellInBlue(worksheet.Cells[row, col++]);//06
            #endregion

            #region 购买宝贝数
            worksheet.Cells.SetColumnWidth(col, 11);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("购买宝贝数");
            FormatCellInBlue(worksheet.Cells[row, col++]);//07
            #endregion

            #region 最近交易日期
            worksheet.Cells.SetColumnWidth(col, 12);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("最近交易日期");
            FormatCellInBlue(worksheet.Cells[row, col++]);//08
            #endregion

            #region 地址
            worksheet.Cells.SetColumnWidth(col, 35);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("地址");
            FormatCellInBlue(worksheet.Cells[row, col++]);//09
            #endregion


            //#region 是否退过货
            //worksheet.Cells.SetColumnWidth(col, 11);
            //worksheet.Cells[row, col].Style.IsTextWrapped = true;
            //worksheet.Cells[row, col].PutValue("是否退过货");
            //FormatCellInBlue(worksheet.Cells[row, col++]);//10
            //#endregion

            //#region 是否有过关闭交易
            //worksheet.Cells.SetColumnWidth(col, 11);
            //worksheet.Cells[row, col].Style.IsTextWrapped = true;
            //worksheet.Cells[row, col].PutValue("是否有过关闭交易");
            //FormatCellInBlue(worksheet.Cells[row, col++]);//10
            //#endregion

            row++;

            #endregion

            #region 放值

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //定义行数为1
                col = 0;
                DataRow rows = dt.Rows[i];
                //买家昵称
                worksheet.Cells[row, col].PutValue(rows["buyer_nick"].ToString());
                FormatCell(worksheet.Cells[row, col++]);  // 01
                //姓名
                worksheet.Cells[row, col].PutValue(rows["buyer_reallName"]);
                FormatCell(worksheet.Cells[row, col++]);
                //所在省份
                worksheet.Cells[row, col].PutValue(rows["province"]);
                FormatCell(worksheet.Cells[row, col++]);
                //手机号码
                worksheet.Cells[row, col].PutValue(rows["cellPhone"]);
                FormatCell(worksheet.Cells[row, col++]);
                //会员级别
                worksheet.Cells[row, col].PutValue(rows["grade"]);
                FormatCell(worksheet.Cells[row, col++]);
                //消费金额
                worksheet.Cells[row, col].PutValue(rows["trade_amount"]);
                FormatCell(worksheet.Cells[row, col++]);
                //购买宝贝数
                worksheet.Cells[row, col].PutValue(rows["item_num"].ToString());
                FormatNumberCell(worksheet.Cells[row, col++]);
                //最近交易日期
                worksheet.Cells[row, col].PutValue(rows["last_trade_time"].ToString());
                FormatDateCell(worksheet.Cells[row, col++]);

                //地址
                worksheet.Cells[row, col].PutValue(rows["address"].ToString());
                FormatCell(worksheet.Cells[row, col++]);

                //是否退过货
                //worksheet.Cells[row, col].PutValue(rows["isRefundBuyer"].ToString());
                //if (!string.IsNullOrEmpty(rows["isRefundBuyer"].ToString()) && rows["isRefundBuyer"].ToString().Equals("是"))
                //{
                //    FormatCellInYellow(worksheet.Cells[row, col++]);
                //}
                //else
                //{
                //    FormatCell(worksheet.Cells[row, col++]);
                //}

                row++;
            }
            #endregion
            string filepath = "";

            #region Sending file
            try
            {
                filepath = Server.MapPath(".");
                string filename = "buyresInfo.xls";
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


        protected void imgbtnExport_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //高级版以上用户才可以设置
                if (SellersBLL.CheckSellerIsExit(Users.Nick))
                {
                    DataTable tb = null;
                    if (rdoAllMember.Checked)//全部会员资料导出
                    {
                        tb = BuyerBLL.GetExportBuyers(Users.Nick);
                    }
                    else
                    { //部分会员资料导出
                        tb = BuyerBLL.GetExportBuyers(Users.Nick, datePicker.Value, datePickerEnd.Value, drpArea.SelectedValue, txtTradeAmountFrom.Text.Trim(), txtTradeAmountTo.Text.Trim());
                    }
                    if (tb != null && tb.Rows.Count > 0)
                    {
                        DownloadToExcel(tb);
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('没有要下载的会员数据！');</script>");

                    }
                }
                else
                {
                    versionControl.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
    }
}
