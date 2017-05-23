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

namespace CTCRM.WIN_Aspx.SynData
{
    public partial class buyerExport : System.Web.UI.Page
    {
        //卖家id
           string   sellerId ="";
        protected void Page_Load(object sender, EventArgs e)
        {
            //获取卖家id
            sellerId = SellersBLL.GetSellerIdByNick(Users.Nick);

            if (!Page.IsPostBack)
            {
            }
            //防止二次提交
            imgbtnExport.Attributes.Add("onclick", "this.disabled=true;" + this.ClientScript.GetPostBackEventReference(imgbtnExport, ""));

            try
            {
                //检查卖家最后一次申请状态
                int status = BuyerexportBLL.CheckEndStatus(sellerId);
                if (status == 2)
                {
                    imgbtnExport.ImageUrl = "~/Win_Image/exportSucess.png";
                    ImageButtonCancle.Visible = false;
                }
                else if (status == 1)
                {
                    imgbtnExport.ImageUrl = "~/Win_Image/exporting.png";
                    ImageButtonCancle.Visible = true;
                }
                else if (status == 0)
                {
                    ImageButtonCancle.Visible = false;
                    imgbtnExport.ImageUrl = "~/Win_Image/export.png";
                }

                DataTable dt = BuyerexportBLL.GetBuyerExportAll(sellerId);
                GridView_Jilv.DataSource = dt;
                GridView_Jilv.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void ReSet() {
            try
            {
                //检查卖家最后一次申请状态
                int status = BuyerexportBLL.CheckEndStatus(Users.SellerId);
                if (status == 2)
                {
                    imgbtnExport.ImageUrl = "~/Win_Image/exportSucess.png";
                    ImageButtonCancle.Visible = false;
                }
                else if (status == 1)
                {
                    imgbtnExport.ImageUrl = "~/Win_Image/exporting.png";
                    ImageButtonCancle.Visible = true;
                }
                else if (status == 0)
                {
                    imgbtnExport.ImageUrl = "~/Win_Image/export.png";
                    ImageButtonCancle.Visible = false;
                }

                DataTable dt = BuyerexportBLL.GetBuyerExportAll(Users.SellerId);
                GridView_Jilv.DataSource = dt;
                GridView_Jilv.DataBind();
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
            ReSet();
        }


        protected void imgbtnExport_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //高级版以上用户才可以设置
                //SellersBLL.CheckSellerIsExit(Users.Nick)
                int status = BuyerexportBLL.CheckEndStatus(sellerId);
                //申请成功，开始导出
                if (status == 2)
                {
                    //获取导出语句
                    string sql = BuyerexportBLL.GetExportSql(Users.Nick.ToString());
                    //通过SQL获取数据
                    DataTable tb = null;
                    tb = BuyerBLL.GetExportBuyers(sql, 0);
                    try
                    {
                        ExceptionManager exceptionManager = new ExceptionManager();
                        exceptionManager.WriteFileLog("导出", tb.Rows.Count.ToString(), tb.Rows.Count.ToString());
                        if (tb != null && tb.Rows.Count > 0)
                        {
                            DownloadToExcel(tb);

                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(Page.GetType(), "message", "<script type='text/javascript' defer=defer>alert('没有要下载的会员数据！');</script>");

                        }
                        BuyerexportBLL.UpdateExport(sellerId, 0);
                    }
                    catch (Exception ee)
                    {
                        BuyerexportBLL.UpdateExport(sellerId, 0);
                        ExceptionManager exceptionManager = new ExceptionManager();
                        exceptionManager.WriteFileLog("导出错误", ee.Message, ee.Message);
                    }
                    //导出成功，将状态设为结束
                    BuyerexportBLL.UpdateExport(sellerId, 0);

                }
                else if (status == 1)//申请中
                {
                    
                }
                else if (status == 0)//开始申请，生成导出资料的语句
                {
                    //提交申请
                    int i = BuyerexportBLL.InsertExport(sellerId, Users.Nick);
                    if (i <= 0)
                    {

                        ExceptionReporter.WriteLog(new Exception("向Buyer_export表插入数据失败！"), ExceptionPostion.TBApply_Web_UI);
                    }
                    #region 生成导出资料的语句
                    if (sources.SelectedValue == "全部")//全部会员资料导出语句
                    {
                        string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,case grade when 0 then '潜在会员'
                                when 1 then '普通会员' when 2 then '高级会员' when 3 then 'VIP会员' when 4 then '至尊VIP会员' end as grade,
                                province,trade_amount,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time,address, birthDay
                                from Buyer_" + sellerId + " where SELLER_ID = '" + Users.Nick.ToString() + "'";
                        int count = BuyerexportBLL.InsertBuyer_ExportSql(Users.Nick.ToString(), query);
                        if (count <= 0)
                        {

                            ExceptionReporter.WriteLog(new Exception("插入全部资料的语句失败！"), ExceptionPostion.TBApply_Web_UI);
                        }
                    }
                    else
                    {
                        //部分会员资料导出语句
                        #region
                        //tb = BuyerBLL.GetExportBuyers(Users.Nick, datePicker.Value, datePickerEnd.Value, drpArea.SelectedValue, txtTradeAmountFrom.Text.Trim(), txtTradeAmountTo.Text.Trim());
                        string query = @"select buyer_nick,ISNULL(buyer_reallName,'unknown') AS buyer_reallName,cellPhone,case grade when 0 then '潜在会员'
                                when 1 then '普通会员' when 2 then '高级会员' when 3 then 'VIP会员' when 4 then '至尊VIP会员' end as grade,
                                province,trade_amount,item_num, CONVERT(varchar(100),last_trade_time, 23) as last_trade_time,address, birthDay
                                from Buyer_" + sellerId + " where SELLER_ID = '" + Users.Nick.ToString() + "' ";

                        if (!string.IsNullOrEmpty(datePicker.Value.ToString()))
                        {
                            query += " AND last_trade_time >= '" + datePicker.Value.ToString() + "'";
                        }
                        if (!string.IsNullOrEmpty(datePickerEnd.Value.ToString()))
                        {
                            query += " AND last_trade_time <=  '" + datePickerEnd.Value.ToString() + "'";
                        }
                        if (!drpArea.SelectedValue.Equals("all"))
                        {
                            query += " AND province like '" + drpArea.SelectedValue+"%'";
                        }
                        if (!string.IsNullOrEmpty(txtTradeAmountFrom.Text.Trim()))
                        {
                            query += " AND trade_amount >=  " + txtTradeAmountFrom.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(txtTradeAmountTo.Text.Trim()))
                        {
                            query += " AND trade_amount <=  " + txtTradeAmountTo.Text.Trim();
                        }
                        if (!drpMember.SelectedValue.Equals("all"))
                        {
                            query += " AND grade =" + drpMember.SelectedValue;
                        }
                        if (!string.IsNullOrEmpty(jiaoyiStart.Text.Trim()))
                        {
                            query += " AND trade_count >=  " + jiaoyiStart.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(jiaoyiEnd.Text.Trim()))
                        {
                            query += " AND trade_count <=  " + jiaoyiEnd.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(countStart.Text.Trim()))
                        {
                            query += " AND item_num >=  " + countStart.Text.Trim();
                        }
                        if (!string.IsNullOrEmpty(countEnd.Text.Trim()))
                        {
                            query += " AND item_num <=  " + countEnd.Text.Trim();
                        }
                        query += " order by last_trade_time desc";
                        #endregion

                        int count = BuyerexportBLL.InsertBuyer_ExportSql(Users.Nick.ToString(), query);
                        if (count <= 0)
                        {

                            ExceptionReporter.WriteLog(new Exception("插入部分资料的语句失败！"), ExceptionPostion.TBApply_Web_UI);
                        }
                    }
                    #endregion

                }

                ReSet();
            }
            catch (Exception ex)
            {
                ExceptionReporter.WriteLog(ex, ExceptionPostion.TBApply_Web_UI);
                ReSet();
            }
        }

        protected void ImageButtonCancle_Click(object sender, ImageClickEventArgs e)
        {
            int status = BuyerexportBLL.CheckEndStatus(sellerId);
            if (status == 2 || status == 1)
            {
                int count = BuyerexportBLL.UpdateExport(sellerId, 0);
                if (count <= 0)
                {

                    ExceptionReporter.WriteLog(new Exception("更新Buyer_export表失败！"), ExceptionPostion.TBApply_Web_UI);
                }
            }

            ReSet();
        }

        protected void imgbtnshowJilu_Click(object sender, ImageClickEventArgs e)
        {
            if (GridView_Jilv.Visible == false)
            {
                GridView_Jilv.Visible = true;
                imgbtnshowJilu.ImageUrl = "~/Win_Image/closeExport.png";
            }
            else
            {
                GridView_Jilv.Visible = false;
                imgbtnshowJilu.ImageUrl = "~/Win_Image/showExport.png";
            }

            ReSet();
        }
    }
}