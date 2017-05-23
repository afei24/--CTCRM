<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CTCRM.admin.rate.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
                评价日志管理</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table>
                <tr>
                    <td>
                        昵称：
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                    <td>
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td>
                    <td>
                        评价类型：
                    </td>
                    <td>
                        <asp:DropDownList ID="drpSendType" Width="125px" runat="server">
                            <asp:ListItem>---全部---</asp:ListItem>
                            <asp:ListItem>自动评价</asp:ListItem>
                            <asp:ListItem>秒评</asp:ListItem>
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
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" DataKeyNames="tid"
                Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="10" OnPageIndexChanging="grdCus_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="卖家昵称" SortExpression="packageName">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("nick") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="6%" Font-Size="15px" />
                        <ItemStyle Width="6%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="result" HeaderText="评价结果">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="评价内容" SortExpression="price">
                        <ItemTemplate>
                            <asp:Label ID="Label63" runat="server" Text='<%# Eval("content")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="30%" Font-Size="14px" />
                        <ItemStyle Width="3%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="评价日期" SortExpression="sellerNick">
                        <ItemTemplate>
                            <asp:Label ID="Labe5l3" runat="server" Text='<%# Eval("created")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="rateType" HeaderText="评价类型">
                        <HeaderStyle Width="5%" />
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
                                卖家昵称
                            </th>
                            <th align="center" scope="col">
                                评价结果
                            </th>
                            <th align="center" valign="middle" scope="col">
                                评价内容
                            </th>
                            <th align="center" valign="middle" scope="col">
                                评价日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                评价类型
                            </th>
                        </tr>
                        <tr>
                            <td colspan="7">
                                没有评价历史数据！
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
    <div class="right">
        <div class="title">
            <p>
                评价历史记录删除</p>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
          <table > 
              <tr>
                   <td>
                        开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime1" />
                    </td>
                    <td>
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime1" />
                    </td>
                  <td>
                      &nbsp;<asp:Button ID="Button2" runat="server" Text=" 清除记录 " CssClass="pinpt4" OnClick="btnDelete_Click" />
                  </td>
              </tr>
          </table>
        </div>
    </div>
    </form>
</body>
</html>
