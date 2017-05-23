<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyerInfoDetails.aspx.cs" Inherits="CTCRM.buyerInfoDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员详细信息</title>
    <link href="CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
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
                                    <td style="width:90px;">
                                        买家昵称：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbBuyerNick" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width:110px;">
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
                                <tr>
                                    <td>
                                        累计交易次数：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTradeCount" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        累计交易商品(件)：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTradeProductCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        累计关闭次数：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCloseTradeCount" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        累计关闭交易金额：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCloseTradeAmount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        买家信誉：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbBuyerCredit" runat="server" Text=""></asp:Label>
                                        <asp:Image ID="imgcredit" runat="server" />
                                    </td>
                                    <td>
                                        是否退过货：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbisRefund" runat="server" Text=""></asp:Label>
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
                                    <td style="width:90px;">
                                        真实姓名：
                                    </td>
                                    <td style="width:255px;">
                                        <asp:Label ID="lbRealName" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        手机号码：
                                    </td>
                                    <td>
                                         <asp:Label ID="lbCellPhone" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        固定电话：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbPhone" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        QQ：
                                    </td>
                                    <td>
                                         <asp:Label ID="lbQQ" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        生日：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbBirthDay" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td>
                                        邮政编码：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbZipCode" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        收货地址：
                                    </td>
                                    <td colspan=3>
                                        <asp:Label ID="lbAddress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        备注：
                                    </td>
                                    <td colspan=3>
                                        <asp:Label ID="lbmemo" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="center">
                                        <asp:ImageButton ID="ImageButton1" runat="server" OnClientClick="window.close();"
                                            ImageUrl="~/Images/close.jpg" />
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
