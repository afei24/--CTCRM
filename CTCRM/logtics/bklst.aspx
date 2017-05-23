<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bklst.aspx.cs" Inherits="CTCRM.admin.logtics.bklst" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                卖家物流提醒白名单</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr align="left">
                    <td style="width: 40px;">
                        昵称：
                    </td>
                    <td style="width: 60px;">
                        <asp:TextBox ID="txtTitle" Width="150px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbmsg" runat="server" Text="" ForeColor="Blue" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                     <td>
                    站内账户：<asp:Label ID="lbMsgCount" Font-Bold="true" Font-Size="16px" runat="server" Text=""></asp:Label>&nbsp;&nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSearch" runat="server" Text=" 添   加 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                   
                    <td>
                     <asp:Button ID="Button1" runat="server" Text=" 查  询 " 
                            CssClass="pinpt4" onclick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
        <asp:GridView CssClass="table2" Width="100%" ID="grdbadList" runat="server" DataKeyNames="sellerNick" 
                    AutoGenerateColumns="False" AllowPaging="True" PageSize="10" OnPageIndexChanging="grdbadList_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="sellerNick" HeaderText="旺旺昵称">
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="createDate" HeaderText="添加时间">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("sellerNick") %>' OnClientClick="return(confirm('确认要删除该用户？'));"
                                    OnClick="Allow_click">删除</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#B00000" Width="20%" Font-Size="14px" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table2">
                            <tr>
                                <th>
                                    旺旺昵称
                                </th>
                                <th>
                                    添加时间
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    当前没有卖家
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
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />
                            页
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                CommandName="Page" Text="GO" />
                        </center>
                    </PagerTemplate>
                </asp:GridView>
        </div>
        <div style="text-align:center">
            <asp:Button ID="Button2" runat="server" Text="一键同步物流公司信息" OnClick="Button2_Click" /><asp:Label ID="Label1" ForeColor="Blue" Font-Bold="true" Font-Size="18px" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
