<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rechargeRecords.aspx.cs" Inherits="CTCRM.admin.message.rechargeRecords" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                管理员短信充值记录</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr align="left">
                    <td style="width:90px;">
                        充值开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                   <td style="width:90px;">
                        充值结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td>     
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
                                <tr>
                    <td>
                        &nbsp
                        </td>
                    <td>
                        </td>
                    <td>
                        </td>
                    </tr>
                <tr>
                    <td>充值条数：
                        </td>
                    <td>
                        <asp:TextBox ID="tboxMsgCount" runat="server"></asp:TextBox>
                        </td>
                     <td>充值金额：
                        </td>
                    <td>
                        <asp:TextBox ID="tboxMsgPrice" runat="server"></asp:TextBox>
                        </td>
                    <td>
                                                <asp:Button ID="btnSet" runat="server" Text=" 添  加 "
                            CssClass="pinpt4" OnClick="btnSet_Click" />
                    
                        </td>
                    </tr>
            </table>
        </div>
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" 
                Width="100%" Height="15px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grdCus_PageIndexChanging"
                OnRowDataBound="grdCus_RowDataBound" EnableModelValidation="True" OnRowCommand="grdCus_RowCommand" OnRowDeleted="grdCus_RowDeleted" OnRowDeleting="grdCus_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="MsgCount" HeaderText="充值条数">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Price" HeaderText="充值金额">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="Date" HeaderText="充值日期">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:ButtonField CommandName="Delete" Text="删除">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ButtonField>
                   
                    
                   
                    <asp:ButtonField CommandName="Edit" Text="修改">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ButtonField>
                   
                    
                   
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                        style="border-collapse: collapse; width:900px">
                        <tr>
                            <th scope="col">
                                充值条数
                            </th>
                            <th scope="col">
                                充值金额
                            </th>
                            <th align="center" scope="col">
                                充值日期
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

        <div class="title">
            <p>
                使用短信费用情况</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr align="left">
                    <td style="width:90px;">
                        开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="TextSatrtDate" />
                    </td>
                   <td style="width:90px;">
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="TextEndDate" />
                    </td>     
                    <td>
                        <asp:Button ID="ButtonQuery" runat="server" Text=" 搜  索 " 
                            CssClass="pinpt4" OnClick="ButtonQuery_Click" />
                    </td>
                </tr>
                <tr align="left">
                    
                     <td>卖家昵称：
                        </td>
                    <td>
                        <asp:TextBox ID="TextBoxNickSum" runat="server"></asp:TextBox>
                        </td>
                    <td>
                        <asp:Button ID="ButtonSNick" runat="server" Text=" 搜  索 " 
                            CssClass="pinpt4" OnClick="ButtonSNick_Click"  />
                    </td>
                </tr>
            </table>
        </div>
        <div class="nrkuai">
            <asp:Label ID="LabelAllMsg" runat="server" Text="所有卖家短信使用费用情况："></asp:Label>
            <asp:GridView ID="GridViewJifei" runat="server" AutoGenerateColumns="False" 
                Width="100%" Height="15px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="GridViewJifei_PageIndexChanging"
                OnRowDataBound="grdCus_RowDataBound" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="sellernick" HeaderText="卖家昵称">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgcount" HeaderText="使用条数">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="price" HeaderText="使用金额">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="evPrice" HeaderText="计费详情">
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="40%" />
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
                                使用条数
                            </th>
                            <th scope="col">
                                使用金额
                            </th>
                            <th align="center" scope="col">
                                计费详情
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
