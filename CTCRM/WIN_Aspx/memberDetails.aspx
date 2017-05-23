<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberDetails.aspx.cs"
    Inherits="CTCRM.memberDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员详细信息</title>
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/jquery-1.7.1.min.js"></script>
    <script src="../Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <base target="_self"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightside">
        <div class="infoArea">
            <div class="smallTitle">
                会员基本信息
            </div>
            <div class="content">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                买家昵称：
                            </td>
                            <td>
                                <asp:Label ID="lbBuyerNick" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                会员级别：
                            </td>
                            <td>
                                <asp:Label ID="lbBuyerLevel" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                会员状态：
                            </td>
                            <td>
                                <asp:Label ID="lbBuyerStatus" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                累计交易金额：
                            </td>
                            <td>
                                <asp:Label ID="lbTradeAmount" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <div class="infoArea">
            <div class="smallTitle">
                会员详细信息
            </div>
            <div class="content">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                真实姓名：
                            </td>
                            <td>
                                <asp:TextBox ID="txtRealName" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                            <td>
                                手机号码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCellphone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                <asp:Label ID="lbCellPhoneError" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                固定电话：
                            </td>
                            <td>
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                 <asp:Label ID="lbPhoneError" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                            <td>
                                QQ：
                            </td>
                            <td>
                                <asp:TextBox ID="txtQQ" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                <asp:Label ID="lbQQError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                生日：
                            </td>
                            <td>
                                <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()" id="dateBirthDay" />
                            </td>
                            <td>
                                邮政编码：
                            </td>
                            <td>
                                <asp:TextBox ID="txtZIPCode" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                 <asp:Label ID="lbZIPError" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                邮件：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                 <asp:Label ID="lbEmailError" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                            <td>
                                剩余积分：
                            </td>
                            <td>
                                 <asp:Label ID="lbJifen" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                收货地址：
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtAddress" Width="460px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" align="left">
                                备注：
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtMemo" TextMode="MultiLine" Height="80px" Width="460px" runat="server"
                                    CssClass="ui-widget-content ui-corner-all" Font-Size="12pt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:ImageButton ID="imgSubmit" runat="server" 
                                    ImageUrl="~/Images/submitModify.png" onclick="imgSubmit_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;<%--<asp:ImageButton ID="ImageButton1" runat="server" 
                                    OnClientClick="javascript:$('.moren').hide();$('.detail_div').hide();" ImageUrl="~/Images/close.jpg" />--%> &nbsp;&nbsp;<asp:Label ID="lbMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
