<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="deleteData.aspx.cs" Inherits="CTCRM.admin.notify.deleteData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />

    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                卖家主动通知数据</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr align="left">
                    <td style="width: 120px;">
                        需要删除哪天的数据：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                     <td style="width: 120px;">
                        卖家昵称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtNick" runat="server" Width="134px"></asp:TextBox>
                    </td>
                    <td>
                    <asp:Button ID="Button1" runat="server" Text=" 查 询 " CssClass="pinpt4" 
                            onclick="Button1_Click"  />&nbsp;
                        <asp:Button ID="btnDelete" runat="server" Text=" 删除数据 " CssClass="pinpt4" OnClick="btnDelete_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" Width="100%"
                Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid" AllowPaging="True"
                BorderWidth="1px" CellPadding="4" PageSize="25" OnPageIndexChanging="grdCus_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="tid" HeaderText="交易编号">
                        <HeaderStyle Width="5%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="消息日期" SortExpression="created">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("createDate").ToString()%>' />
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="seller_nick" HeaderText="卖家昵称">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="status" HeaderText="交易状态">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                        style="border-collapse: collapse; width: 900px">
                        <tr>
                            <th scope="col">
                                交易编号
                            </th>
                            <th scope="col">
                                消息日期
                            </th>
                            <th align="center" scope="col">
                                卖家昵称
                            </th>
                            <th align="center" valign="middle" scope="col">
                                交易状态
                            </th>
                        </tr>
                        <tr>
                            <td colspan="7">
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
