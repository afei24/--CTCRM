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
            <table width="100%">
                <tr align="left">
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
                                <tr>
                    <td>
                        </td>
                    <td>
                        </td>
                    <td>
                        </td>
                    </tr>
                <tr>
                    <td>卖家昵称：
                        </td>
                    <td>
                        <asp:TextBox ID="tboxNick" runat="server"></asp:TextBox>
                        </td>
                     <td>发送短信百分比：
                        </td>
                    <td>
                        <asp:TextBox ID="tboxPrecent" runat="server"></asp:TextBox>%
                        </td>
                    <td>
                                                <asp:Button ID="btnSet" runat="server" Text=" 设  置 "
                            CssClass="pinpt4" OnClick="btnSet_Click" />
                    
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
                Width="100%" Height="15px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="30" OnPageIndexChanging="grdCus_PageIndexChanging"
                OnRowDataBound="grdCus_RowDataBound" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                    </asp:BoundField>
                     <asp:BoundField DataField="packageName" HeaderText="短信包">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="unUseDate" HeaderText="到期时间">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgCanUseCount" HeaderText="剩余条数">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgTotalCount" HeaderText="总条数">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="serviceStatus" HeaderText="账户状态">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                   <asp:BoundField HeaderText="最后同步时间">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sendPrecent" HeaderText="营销短信发送百分比" >
                         <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
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
         &nbsp;&nbsp;&nbsp;昵称：<asp:TextBox ID="txtNick" runat="server"></asp:TextBox>&nbsp;&nbsp;添加条数：<asp:TextBox
             ID="txtCount" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:Button 
             ID="btnSave" runat="server"
                 Text="添 加" Height="27px" Width="94px" onclick="btnSave_Click" />&nbsp;&nbsp;<asp:Label ForeColor=Blue Font-Bold=true Font-Size=Large
                     ID="lbMsg" runat="server" Text=""></asp:Label>
         <asp:Button ID="bt_all" runat="server" Text="一件补表" OnClick="bt_all_Click" Enabled="false" />
         <asp:Label ID="lb_num" runat="server" Text="*" ></asp:Label>
        </div>
    </form>
</body>
</html>
