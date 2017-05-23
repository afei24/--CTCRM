<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="synData.aspx.cs" Inherits="CTCRM.Help.synData" MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <base target="_self" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 100%">
        <div class="smallTitle">
                        &nbsp;同步店铺数据到店铺管家系统
                    </div>
                    <div class="content">
                        <table>
                            <tbody>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="tnUpdateDate" runat="server" ImageUrl="~/Images/downloadOrder.jpg"
                                            OnClick="tnUpdateDate_Click" CssClass="BtnStyle" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
    </div>
</asp:Content>

