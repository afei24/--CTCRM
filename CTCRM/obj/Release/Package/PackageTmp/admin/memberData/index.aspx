<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CTCRM.admin.memberData.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>会员数据导出权限</title>
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
                已导出会员数据卖家</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width=100%>
                <tr align=left>
                    <td style="width:40px;">
                        昵称：
                    </td>
                   <td style="width:60px;">
                        <asp:TextBox ID="txtTitle" Width="70px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:90px;">
                        订购开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                   <td style="width:90px;">
                        订购结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td> 
                     <td style="width:40px;">
                        状态：
                    </td>
                    <td>
                        <asp:DropDownList ID="drpStatus" Width="100px" runat="server">
                            <asp:ListItem Value="">全部</asp:ListItem>
                            <asp:ListItem Value="0">正常</asp:ListItem>
                            <asp:ListItem Value="1">不可用</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False"
                Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="15" OnPageIndexChanging="grdCus_PageIndexChanging"
                OnRowDataBound="grdCus_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="5%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="订购日期" SortExpression="createDate">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("createDate").ToString()%>' />
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
                            <th scope="col">
                                开通日期
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
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
       <div>
           <table border="0" cellpadding="0" cellspacing="0">
               <tr>
                   <td>
                       卖家昵称：
                   </td>
                   <td>
                       <asp:TextBox ID="TextBox1" runat="server" Width="170px"></asp:TextBox>
                   </td>
                   <td>
                       <asp:Button ID="btnAdd" runat="server" Text=" 添 加 "
                            CssClass="pinpt4" OnClick="btnAdd_Click" />
                   </td>
                   <td>
                       <asp:Label ID="Label1" runat="server" Text="" ForeColor="Blue"></asp:Label>
                   </td>
               </tr>
           </table>
       </div>
    </div>
    </form>
</body>
</html>
