<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteData.aspx.cs" Inherits="CTCRM.admin.memberData.deleteData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
     <title>到期未续费卖家列表</title>
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
</head>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                到期未续费卖家</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width=100%>
                <tr align=left>
                    <td style="width:65px;">
                        卖家昵称：
                    </td>
                   <td style="width:60px;">
                        <asp:TextBox ID="txtTitle" Width="70px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:90px;">
                        开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                   <td style="width:90px;">
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td> 
                    <td colspan=3>
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" DataKeyNames="NICK"
                Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="20" OnPageIndexChanging="grdCus_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="NICK" HeaderText="卖家昵称">
                        <HeaderStyle Width="5%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="到期日期" SortExpression="endDate">
                        <ItemTemplate>
                            <asp:Label ID="Label436" runat="server" Text='<%# Eval("endDate").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="6%" Font-Size="14px" />
                        <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="最后登录日期" SortExpression="UpdateDate">
                        <ItemTemplate>
                            <asp:Label ID="Label46" runat="server" Text='<%# Eval("UpdateDate") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="6%" Font-Size="14px" />
                        <ItemStyle Width="6%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作(一键清除该卖家数据)">
                        <ItemTemplate>
                            <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("NICK") %>'
                                OnClick="Allow_click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                        style="border-collapse: collapse; width:900px">
                        <tr>
                            <th scope="col">
                                卖家昵称
                            </th>
                            <th align="center" valign="middle" scope="col">
                                到期日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                最后登录日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                操作
                            </th>
                        </tr>
                        <tr>
                            <td colspan="4">
                                没有数据！
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <PagerTemplate>
                    <center>
                        当前第:
                        <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                        页/共:
                        <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                        页
                        <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                            Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                            CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                            Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                        <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                            Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                        转到第
                        <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                            CommandName="Page" Text="GO" />
                    </center>
                </PagerTemplate>
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>
