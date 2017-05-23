<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="areaStatic.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.areaStatic" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="stylesheet" />
    <link href="CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />

    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
    <link href="CSS/color.css" rel="stylesheet" />

    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script src="Js/DialogMsg.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="Js/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员中心</h4>
                <ul class="items">
                    <li><a href="allmember.aspx">会员管理</a></li>
                    <li><a href="systemReport.aspx">增长分析</a></li>
                    <li class="on"><a href="areaStatic.aspx">区域分析</a></li>
                    <li><a href="blacklist.aspx">黑名单管理</a></li>
                    <li><a href="SynData/buyerExport.aspx">会员导出</a></li>
                    <li><a href="systemSetting.aspx">系统设置</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        会员区域分布
                    </div>
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 120px;" align="right">从
                                    </td>
                                    <td style="width: 10px" align="left">
                                        <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                            id="datePicker" />
                                    </td>
                                    <td style="width: 7px">到
                                    </td>
                                    <td style="width: 70px">
                                        <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                            id="datePickerEnd" />
                                    </td>
                                    <td style="width: 80px" align="left">
                                        <asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/Images/serach.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgBtnSearch_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6" align="center">
                                        <asp:Chart ID="Chart2" runat="server" Height="360px" Width="820px" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)"
                                            Palette="BrightPastel" ImageType="Png" BorderDashStyle="Solid" BackSecondaryColor="White"
                                            BackGradientStyle="TopBottom" BorderWidth="2" BackColor="Transparent" BorderColor="26, 59, 105">
                                            <Series>
                                                <asp:Series Name="buyerProvince" Color="#982301" ChartType="Pie" ChartArea="ChartArea1">
                                                </asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                                                    BackSecondaryColor="White" BackColor="Transparent" ShadowColor="Transparent"
                                                    BackGradientStyle="TopBottom" Area3DStyle-Enable3D="true">
                                                    <Area3DStyle Rotation="60" />
                                                    <AxisY LineColor="64, 64, 64, 64" LineDashStyle="NotSet">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisY>
                                                    <AxisX LineColor="64, 64, 64, 64">
                                                        <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                                        <MajorGrid LineColor="64, 64, 64, 64" />
                                                    </AxisX>
                                                </asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                   <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 300px; top: 180px; display: none; z-index: 9999;">
                    <h1><font color="white">系统查询中........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 300px; top: 210px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>

