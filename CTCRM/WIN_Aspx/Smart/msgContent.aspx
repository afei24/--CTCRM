<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgContent.aspx.cs" Inherits="CTCRM.WIN_Aspx.Smart.msgContent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>短信内容明细</title>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/css.css" rel="stylesheet" type="text/css" />
    <base target="_self"/>
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightside">
        <div class="infoArea">
            <div class="smallTitle">
                短信内容详情
            </div>
            <div class="content">
                <table>
                    <tbody>
                        <tr>
                            <td style="width:70px">
                                明细编号：
                            </td>
                            <td>
                                <asp:Label ID="lbTransNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                短信内容：
                            </td>
                            <td>
                                <asp:Label ID="lbMsgContent" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <a href="#"><img src="../../Images/close.jpg" onclick="window.close();" /></a>&nbsp;<asp:Label ID="Label1"
                                        runat="server" Text=""></asp:Label>
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
