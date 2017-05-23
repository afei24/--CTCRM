<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Temp/Common.Master"
    CodeBehind="grade.aspx.cs" Inherits="CTCRM.Grade.grade" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />

    <script src="../Js/jquery.js" type="text/javascript"></script>

    <script src="../Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>

    <script src="../Js/Dialog.js" language="javascript" charset="utf-8" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 570px">
        <div class="infoArea">
            <div class="smallTitle">
                系统默认等级管理
            </div>
            <div class="content">
                <table>
                    <tbody>
                        <tr>
                            <td style="width: 300px; font-weight: bold;">
                                普通会员
                            </td>
                            <td style="width: 90px" align="right">
                                <asp:Label ID="lbBuyerNick" runat="server" Text="消费金额(￥)："></asp:Label>
                            </td>
                            <td style="width: 60px">
                                <asp:TextBox ID="txtMin1" Height="20px"  runat="server" Text="1"></asp:TextBox>
                            </td>
                            <td style="width: 10px">
                                到
                            </td>
                            <td>
                                <asp:TextBox ID="txtMax1" runat="server" Height="20px"  Text="100"></asp:TextBox>
                                <asp:Label ID="lbError1" runat="server" ForeColor=Red Text=""></asp:Label>
                        </tr>
                        <tr>
                            <td style="width: 300px; font-weight: bold;">
                                高级会员
                            </td>
                            <td style="width: 90px" align="right">
                                <asp:Label ID="Label1" runat="server" Text="消费金额(￥)："></asp:Label>
                            </td>
                            <td style="width: 60px">
                                <asp:TextBox ID="txtMin2" runat="server" Height="20px"  Text="100"></asp:TextBox>
                            </td>
                            <td style="width: 10px">
                                到
                            </td>
                            <td>
                                <asp:TextBox ID="txtMax2" runat="server"  Height="20px" Text="300"></asp:TextBox>
                                 <asp:Label ID="lbError2" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px; font-weight: bold;">
                                VIP会员
                            </td>
                            <td style="width: 90px" align="right">
                                <asp:Label ID="txtMissn3" runat="server" Text="消费金额(￥)："></asp:Label>
                            </td>
                            <td style="width: 60px">
                                <asp:TextBox ID="txtMin3" runat="server" Height="20px" Text="300"></asp:TextBox>
                            </td>
                            <td style="width: 10px">
                                到
                            </td>
                            <td>
                                <asp:TextBox ID="txtMax3" runat="server" Height="20px" Text="500"></asp:TextBox>
                                <asp:Label ID="lbError3" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 300px; font-weight: bold;">
                                至尊Vip会员
                            </td>
                            <td style="width: 90px" align="right">
                                <asp:Label ID="Label2" runat="server" Text="消费金额(￥)："></asp:Label>
                            </td>
                            <td style="width: 60px">
                                <asp:TextBox ID="txtMin4" runat="server" Height="20px" Text="500"></asp:TextBox>
                            </td>
                            <td style="width: 10px">
                                到
                            </td>
                            <td>
                                <asp:TextBox ID="txtMax4" runat="server" Height="20px" Text="1000000"></asp:TextBox>
                                <asp:Label ID="lbError4" runat="server" ForeColor=Red Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" align="center">
                                <asp:Button ID="btnUpdate" runat="server" Text="修 改" OnClick="Button1_Click" />&nbsp;&nbsp;<asp:Label
                                    ID="lbMsg" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
