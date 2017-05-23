<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="seller.aspx.cs" Inherits="CTCRM.crmad.seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link href="style/admin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="right">
            <div class="title">
                <p>
                    卖家信息管理
                </p>
            </div>
            <!-- title End -->
            <div class="jsuo">
                <table width="100%">
                    <tr>
                        <td align="right">
                             <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                                CssClass="pinpt4" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                           &nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </div>
            <!-- jsuo End -->
            <div class="nrkuai">
                <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False"
                    Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                    AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="20" OnPageIndexChanging="grdCus_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="NICK" HeaderText="卖家昵称">
                            <HeaderStyle Width="4%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CellPhone" HeaderText="电话号码">
                            <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CreatedDate" HeaderText="订购日期">
                            <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                            <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                        </asp:BoundField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                            style="border-collapse: collapse; width: 900px">
                            <tr>
                                <th scope="col">卖家昵称
                                </th>
                                <th scope="col">电话号码
                                </th>
                                <th align="center" scope="col">订购日期
                                </th>
                            </tr>
                            <tr>
                                <td colspan="5">没有数据！
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
