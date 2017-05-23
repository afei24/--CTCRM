<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sellerMsgAcount.aspx.cs" Inherits="CTCRM.admin.message.sellerMsgAcount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   <title></title>
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
                卖家当前短信账户查询</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width=100%>
                <tr align=left>
                    <td style="width:40px;">
                        昵称：
                    </td>
                   <td style="width:60px;">
                        <asp:TextBox ID="txtTitle" Width="130px" CssClass="pinpt3" runat="server"></asp:TextBox>
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
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
         &nbsp;&nbsp;&nbsp;<asp:Label ID="lbMsgCount" Font-Bold="true" Font-Size="16px" runat="server" Text="0"></asp:Label>&nbsp;&nbsp;<asp:Label ID="lbSpendFee" Font-Bold="true" Font-Size="16px" runat="server" Text="0"></asp:Label>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" 
                Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="10" OnPageIndexChanging="grdCus_PageIndexChanging"
                OnRowDataBound="grdCus_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="3%" />
                    </asp:BoundField>
                     <asp:BoundField DataField="packageName" HeaderText="短信包">
                        <HeaderStyle Width="4%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="到期日期" SortExpression="unUseDate">
                        <ItemTemplate>
                            <asp:Label ID="Label5" runat="server" Text='<%#Eval("unUseDate").ToString()%>' />
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="msgCanUseCount" HeaderText="剩余条数">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgTotalCount" HeaderText="总条数">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="serviceStatus" HeaderText="账户状态">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                   
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                        style="border-collapse: collapse; width:900px">
                        <tr>
                            <th scope="col">
                                卖家昵称
                            </th>
                            <th scope="col">
                                是否下载数据
                            </th>
                            <th align="center" scope="col">
                                订购日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                到期日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                最后登录日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                卖家状态
                            </th>
                            <th align="center" valign="middle" scope="col">
                                操作
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
     <div>
         &nbsp;&nbsp;&nbsp;昵称：<asp:TextBox ID="txtNick" runat="server"></asp:TextBox>&nbsp;&nbsp;调整条数：<asp:TextBox
             ID="txtCount" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button 
             ID="btnSave" runat="server"
                 Text="更 改" Height="27px" Width="94px" onclick="btnSave_Click" />&nbsp;&nbsp;<asp:Label ForeColor=Blue Font-Bold=true Font-Size=Large
                     ID="lbMsg" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
