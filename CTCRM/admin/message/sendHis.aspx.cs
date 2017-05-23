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
using System.Drawing;

namespace CTCRM.admin.message
{
    public partial class sendHis : System.Web.UI.Page
    {
        public DataTable dtMsgCount = MsgBLL.GetMsgSendHisCount("");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LOGINUSERNAME"] == null && !Convert.ToString(Session["LOGINUSERNAME"]).Equals("kimluo"))
            {
                Response.Redirect("~/admin/Login.aspx?");
            }
            //初始化分页控件
            if (!Page.IsPostBack)
            {
                //drpStatus.Items.Insert(0, "---审核状态---");
                //日期显示为只读
                txt_StartTime.Attributes.Add("readonly", "readonly");
                txt_EndTime.Attributes.Add("readonly", "readonly");

                txt_StartTime1.Attributes.Add("readonly", "readonly");
                txt_EndTime1.Attributes.Add("readonly", "readonly");

                //txtStartDiff.Attributes.Add("readonly", "readonly");
                //txtEndDiff.Attributes.Add("readonly", "readonly");

                //txtStartDiff.Value = DateTime.Now.ToShortDateString();
                //txtEndDiff.Value = DateTime.Now.AddDays(1).ToShortDateString();
                
                gd_All.DataSource = dtMsgCount;
                gd_All.DataBind();
            }
        }

        private void MsgDataBind()
        {
            int hours1 =0;
            int min1 =0;
            int sec1 = 0;
            int hours2 =0;
            int min2 =0;
            int sec2 =0;
            try
            {
                 hours1 = string.IsNullOrEmpty(tbHours1.Text.Trim())? 0: Convert.ToInt32(tbHours1.Text.Trim());
                 min1 =string.IsNullOrEmpty(tbMin1.Text.Trim())? 0: Convert.ToInt32(tbMin1.Text.Trim());
                 sec1 =string.IsNullOrEmpty(tbSecond1.Text.Trim())? 0: Convert.ToInt32(tbSecond1.Text.Trim());
                 hours2 =string.IsNullOrEmpty(tbHours2.Text.Trim())? 0: Convert.ToInt32(tbHours2.Text.Trim());
                 min2 =string.IsNullOrEmpty(tbMin2.Text.Trim())? 0: Convert.ToInt32(tbMin2.Text.Trim());
                 sec2 =string.IsNullOrEmpty(tbSecond2.Text.Trim())? 0: Convert.ToInt32(tbSecond2.Text.Trim());
                if (hours1 > 23 || min1 > 59 || sec1 > 59 || min2 > 59 || sec2 > 59 || hours2 > 23)
                {
                    Response.Write("<script language='javascript'>alert('请正确填写时分秒');</script>");
                    return;
                }
            }
            catch (Exception e)
            {
                Response.Write("<script language='javascript'>alert('请正确填写时分秒');</script>");
                return;
            }
            string startTime;
            if (string.IsNullOrEmpty(txt_StartTime.Value))
            {
                startTime = txt_StartTime.Value;
            }
            else
            {
                startTime = txt_StartTime.Value + " " + hours1 + ":" + min1 + ":" + sec1;
            }
            string endTime;
            if (string.IsNullOrEmpty(txt_EndTime.Value))
            {
                endTime = txt_EndTime.Value;
            }
            else
            {
                endTime = txt_EndTime.Value + " " + hours2 + ":" + min2 + ":" + sec2;
            }
            if (string.IsNullOrEmpty(txt_StartTime.Value) && string.IsNullOrEmpty(txt_EndTime.Value))
            {
                startTime = DateTime.Now.Date.ToString();
            }
            if (IsAll.Value=="1")
            {
                DataTable tb = MsgBLL.GetSellerMsgSendHis(txtTitle.Text.Trim(), startTime,
                    endTime, drpSendType.SelectedValue, "", txtPhone.Text.Trim(), drpStaus.SelectedValue);
                grdCus.DataSource = tb;
                grdCus.DataBind();
            }
            else
            {
                DataTable tb = MsgBLL.GetSellerMsgSendHis(Buyer.Value, "",
                "", "---全部---", "", "", "---全部---");
                grdCus.DataSource = tb;
                grdCus.DataBind();
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
                IsAll.Value="1";
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

       
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sellerNick = txtSellerName.Text.Trim();
            if (MsgBLL.DeleteMsgHis(sellerNick, txt_StartTime1.Value, txt_EndTime1.Value, drpSendType.SelectedValue))
            {
                Response.Write("<script language='javascript'>alert('删除成功！');</script>");
            }
            else {
                Response.Write("<script language='javascript'>alert('删除失败！');</script>");
            }
            //重新绑定
            MsgDataBind();
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

            #region 卖家昵称
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("卖家昵称");
            FormatCellInBlue(worksheet.Cells[row, col++]);//01
            #endregion

            #region 发送日期
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("发送日期");
            FormatCellInBlue(worksheet.Cells[row, col++]);//02
            #endregion

            #region 手机号码
            worksheet.Cells.SetColumnWidth(col, 13);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("手机号码");
            FormatCellInBlue(worksheet.Cells[row, col++]);//03
            #endregion

            #region 发送状态
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("发送状态");
            FormatCellInBlue(worksheet.Cells[row, col++]);
            #endregion

            #region 发送类型
            worksheet.Cells.SetColumnWidth(col, 10);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("发送类型");
            FormatCellInBlue(worksheet.Cells[row, col++]);
            #endregion

            #region 发送内容
            worksheet.Cells.SetColumnWidth(col, 100);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("发送内容");
            FormatCellInBlue(worksheet.Cells[row, col++]);
            #endregion

            #region 号码类型
            worksheet.Cells.SetColumnWidth(col, 100);
            worksheet.Cells[row, col].Style.IsTextWrapped = true;
            worksheet.Cells[row, col].PutValue("号码类型");
            FormatCellInBlue(worksheet.Cells[row, col++]);
            #endregion

         

            row++;

            #endregion

            #region 放值

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //定义行数为1
                col = 0;
                DataRow rows = dt.Rows[i];

                //卖家昵称
                worksheet.Cells[row, col].PutValue(rows["sellerNick"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                //发送日期
                worksheet.Cells[row, col].PutValue(rows["sendDate"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                //手机号码
                worksheet.Cells[row, col].PutValue(rows["cellPhone"]);
                FormatCell(worksheet.Cells[row, col++]);
                //发送状态
                worksheet.Cells[row, col].PutValue(rows["sendStatus"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                //发送类型
                worksheet.Cells[row, col].PutValue(rows["sendType"]);
                FormatDateCell(worksheet.Cells[row, col++]);
                //发送内容
                worksheet.Cells[row, col].PutValue(rows["msgContent"]);
                FormatCell(worksheet.Cells[row, col++]);
                //号码类型
                worksheet.Cells[row, col].PutValue(rows["helpSellerNick"]);
                FormatCell(worksheet.Cells[row, col++]);
                
                row++;
            }
            #endregion
            string filepath = "";

            #region Sending file
            try
            {
                filepath = Server.MapPath(".");
                string filename = "sellerCellPhone.xls";
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

        protected void btnExport_Click(object sender, EventArgs e)
        {
            //DataTable tb = MsgBLL.GetSellerMsgSendHis(txtTitle.Text.Trim(), txt_StartTime.Value, txt_EndTime.Value, drpSendType.SelectedValue,"",txtPhone.Text.Trim(),"");
            int hours1 = 0;
            int min1 = 0;
            int sec1 = 0;
            int hours2 = 0;
            int min2 = 0;
            int sec2 = 0;
            try
            {
                hours1 = string.IsNullOrEmpty(tbHours1.Text.Trim()) ? 0 : Convert.ToInt32(tbHours1.Text.Trim());
                min1 = string.IsNullOrEmpty(tbMin1.Text.Trim()) ? 0 : Convert.ToInt32(tbMin1.Text.Trim());
                sec1 = string.IsNullOrEmpty(tbSecond1.Text.Trim()) ? 0 : Convert.ToInt32(tbSecond1.Text.Trim());
                hours2 = string.IsNullOrEmpty(tbHours2.Text.Trim()) ? 0 : Convert.ToInt32(tbHours2.Text.Trim());
                min2 = string.IsNullOrEmpty(tbMin2.Text.Trim()) ? 0 : Convert.ToInt32(tbMin2.Text.Trim());
                sec2 = string.IsNullOrEmpty(tbSecond2.Text.Trim()) ? 0 : Convert.ToInt32(tbSecond2.Text.Trim());
                if (hours1 > 23 || min1 > 59 || sec1 > 59 || min2 > 59 || sec2 > 59 || hours2 > 23)
                {
                    Response.Write("<script language='javascript'>alert('请正确填写时分秒');</script>");
                    return;
                }
            }
            catch (Exception eaa)
            {
                Response.Write("<script language='javascript'>alert('请正确填写时分秒');</script>");
                return;
            }
            string startTime;
            if (string.IsNullOrEmpty(txt_StartTime.Value))
            {
                startTime = txt_StartTime.Value;
            }
            else
            {
                startTime = txt_StartTime.Value + " " + hours1 + ":" + min1 + ":" + sec1;
            }
            string endTime;
            if (string.IsNullOrEmpty(txt_EndTime.Value))
            {
                endTime = txt_EndTime.Value;
            }
            else
            {
                endTime = txt_EndTime.Value + " " + hours2 + ":" + min2 + ":" + sec2;
            }
            DataTable tb = MsgBLL.GetSellerMsgSendHis(txtTitle.Text.Trim(), startTime,
                endTime, drpSendType.SelectedValue, "", txtPhone.Text.Trim(), drpStaus.SelectedValue);
           if (tb != null) {
                    DownloadToExcel(tb);
             }  
        }

        protected void btnSearchDiff_Click(object sender, EventArgs e)
        {
            //DataTable tb = MsgBLL.GetSellerMsgSendHis(txtStartDiff.Value, txtEndDiff.Value);
            //grdCus.DataSource = tb;
            //grdCus.DataBind();
        }

        protected void btnSet_Click(object sender, EventArgs e)
        {

        }

        protected void gd_All_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Show")
            {
                IsAll.Value="0";
                int idx = Convert.ToInt16(e.CommandArgument.ToString());
                string buyer = dtMsgCount.Rows[idx]["sellerNick"].ToString();
                Buyer.Value = buyer;
                DataTable tb = MsgBLL.GetSellerMsgSendHis(buyer, "",
                "", "---全部---", "", "", "---全部---");
                grdCus.DataSource = tb;
                grdCus.DataBind();

            }
        }

        protected void Btn_SelectCount_Click(object sender, EventArgs e)
        {
            string buyer = tb_SellerCount.Text.Trim();
            DataTable tb = MsgBLL.GetMsgSendHisCount(buyer);
            gd_All.DataSource = tb;
            gd_All.DataBind();
        }
    }
}
