<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SellerRecords.aspx.cs" Inherits="CTCRM.admin.message.SellerRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
    .tb_yingxiao{
        width:100%;
    }
        .auto-style6
        {
            width: 122px;
        }
        .auto-style7
        {
            width: 147px;
        }
        .auto-style8
        {
            width: 161px;
        }
        .auto-style9
        {
            width: 128px;
        }
        .auto-style10
        {
            width: 72px;
        }
        .auto-style11
        {
            width: 71px;
        }
        .auto-style12
        {
            width: 77px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                卖家订购记录</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table class="tb_yingxiao">
                <tr>
                    <td class="auto-style11">
                        卖家昵称：
                    </td>
                     
                    <td>
                        <asp:TextBox ID="tb_Seller" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        订购开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime1" />
                    </td>
                    <td>
                        订购结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime1" />
                    </td>
                    
                    <td >
                        <asp:Button ID="Btn_SelectCount" runat="server" Text=" 搜  索 " 
                            CssClass="pinpt4" OnClick="Btn_SelectCount_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="nrkuai">
        
            <asp:GridView ID="gd_All" runat="server" AutoGenerateColumns="False" 
                Width="89%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="gd_All_PageIndexChanging" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="type" HeaderText="项目类型">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="30%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="orderdate" HeaderText="订购日期" />
                    <asp:BoundField DataField="endDate" HeaderText="结束日期" />
                    <asp:BoundField DataField="BuyType" HeaderText="订购类型" />
                </Columns>
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
