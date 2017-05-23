<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyerExport.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.Download.buyerExport" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/css.css" rel="stylesheet" type="text/css" />

    <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script src="../Js/Dialog.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员中心</h4>
                <ul class="items">
                    <li ><a href="../allmember.aspx">会员管理</a></li>
                    <li><a href="../blacklist.aspx">黑名单管理</a></li>
                    <li class="on"><a href="buyerExport.aspx">会员导出</a></li>
                   
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        会员数据导出
                    </div>
                    <div class="contt4">

                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="font-size: 13px; font-weight: bold">&nbsp;担心店铺会员资料丢失？别急，您可以在这里导出并保存到自己的电脑硬盘上哟！
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 13px; color: Red; font-weight: bold">&nbsp;&nbsp;温馨提示：导出数据过程中不要关闭页面，如果您店铺的会员比较多，那么请耐心等待，下载完成后系统将提示已经完成。
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;<asp:RadioButton ID="rdoAllMember" GroupName="export" Checked="true" Text="导出所有会员资料。" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;<asp:RadioButton ID="rdoPartMember" GroupName="export" Text="只导出" runat="server" /><input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                    id="datePicker" />&nbsp;至 &nbsp;<input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                        id="datePickerEnd" />&nbsp;时间范围内且会员所属地区在：<asp:DropDownList ID="drpArea" runat="server" Width="80px" CssClass="ui-widget-content ui-corner-all">
                                            <asp:ListItem Value="all">全部</asp:ListItem>
                                            <asp:ListItem Value="北京">北京市</asp:ListItem>
                                            <asp:ListItem Value="上海">上海市</asp:ListItem>
                                            <asp:ListItem Value="天津">天津市</asp:ListItem>
                                            <asp:ListItem Value="重庆">重庆市</asp:ListItem>
                                            <asp:ListItem Value="河北">河北省</asp:ListItem>
                                            <asp:ListItem Value="山西">山西省</asp:ListItem>
                                            <asp:ListItem Value="内蒙古">内蒙古自治区</asp:ListItem>
                                            <asp:ListItem Value="辽宁">辽宁省</asp:ListItem>
                                            <asp:ListItem Value="吉林">吉林省</asp:ListItem>
                                            <asp:ListItem Value="黑龙江">黑龙江省</asp:ListItem>
                                            <asp:ListItem Value="江苏">江苏省</asp:ListItem>
                                            <asp:ListItem Value="浙江">浙江省</asp:ListItem>
                                            <asp:ListItem Value="安徽">安徽省</asp:ListItem>
                                            <asp:ListItem Value="福建">福建省</asp:ListItem>
                                            <asp:ListItem Value="江西">江西省</asp:ListItem>
                                            <asp:ListItem Value="山东">山东省</asp:ListItem>
                                            <asp:ListItem Value="河南">河南省</asp:ListItem>
                                            <asp:ListItem Value="湖北">湖北省</asp:ListItem>
                                            <asp:ListItem Value="湖南">湖南省</asp:ListItem>
                                            <asp:ListItem Value="广东">广东省</asp:ListItem>
                                            <asp:ListItem Value="广西">广西壮族自治区</asp:ListItem>
                                            <asp:ListItem Value="海南">海南省</asp:ListItem>
                                            <asp:ListItem Value="贵州">贵州省</asp:ListItem>
                                            <asp:ListItem Value="云南">云南省</asp:ListItem>
                                            <asp:ListItem Value="四川">四川省</asp:ListItem>
                                            <asp:ListItem Value="西藏">西藏自治区</asp:ListItem>
                                            <asp:ListItem Value="陕西">陕西省</asp:ListItem>
                                            <asp:ListItem Value="甘肃">甘肃省</asp:ListItem>
                                            <asp:ListItem Value="宁夏">宁夏回族自治区</asp:ListItem>
                                            <asp:ListItem Value="青海">青海省</asp:ListItem>
                                            <asp:ListItem Value="新疆">新疆维吾尔自治区</asp:ListItem>
                                            <asp:ListItem Value="香港">香港特别行政区</asp:ListItem>
                                            <asp:ListItem Value="澳门">澳门特别行政区</asp:ListItem>
                                            <asp:ListItem Value="台湾">台湾省</asp:ListItem>
                                            <asp:ListItem Value="其它">其它</asp:ListItem>
                                        </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;且消费金额在
                                    <asp:TextBox ID="txtTradeAmountFrom" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>至
                         <asp:TextBox ID="txtTradeAmountTo" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>的会员资料。
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="vertical-align: middle">
                                    <asp:HyperLink ID="versionControl" Font-Bold="true" Font-Size="16px" Target="_blank"
                                        ForeColor="Red" runat="server" NavigateUrl="http://fuwu.taobao.com/ser/detail.htm?spm=a1z13.1113643.1113643.61.0Jlk1A&service_code=ts-1811102&tracelog=search&scm=&ppath=&labels="
                                        Text="仅限订购软件一年用户,现在去升级？"></asp:HyperLink>&nbsp;<asp:ImageButton ID="imgbtnExport" ImageUrl="~/Images/export.png"
                                            runat="server" OnClick="imgbtnExport_Click"
                                            OnClientClick="return(confirm('导出会员数据比较慢，特别是等级较高的店铺，下载过程中不要离开此页面！'));" />&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
