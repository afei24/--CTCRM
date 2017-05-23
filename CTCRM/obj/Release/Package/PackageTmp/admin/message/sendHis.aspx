<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendHis.aspx.cs" Inherits="CTCRM.admin.message.sendHis" %>

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
                客户短信发送记录</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td>
                        卖家昵称：
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
                        发送类型：
                    </td>
                    <td>
                        <asp:DropDownList ID="drpSendType" Width="125px" runat="server">
                            <asp:ListItem>---全部---</asp:ListItem>
                            <asp:ListItem>发货提醒</asp:ListItem>
                            <asp:ListItem>延时发货提醒</asp:ListItem>
                            <asp:ListItem>自测短信</asp:ListItem>
                            <asp:ListItem>手工发送</asp:ListItem>
                            <asp:ListItem>催款提醒</asp:ListItem>
                            <asp:ListItem>智能营销</asp:ListItem>
                            <asp:ListItem>到货提醒</asp:ListItem>
                            <asp:ListItem>短信促销</asp:ListItem>
                            <asp:ListItem>付款提醒</asp:ListItem>
                            <asp:ListItem>签收提醒</asp:ListItem>
                            <asp:ListItem>回款提醒</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td >
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
                <tr>
                     <td>
                        买家电话：
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="5" align="right">
                        <asp:Button ID="btnExport" runat="server" Text=" 导出号码 " CssClass="pinpt4" 
                            onclick="btnExport_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txtStartDiff" />
                    </td>
                    <td>
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txtEndDiff" />
                    </td>
                    <td  colspan=5>
                        <asp:Button ID="btnSearchDiff" runat="server" Text=" 搜  索 "
                            CssClass="pinpt4" onclick="btnSearchDiff_Click" />(查询指定时间范围内发送明细：排除重复数据)
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
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="4%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="买家昵称" SortExpression="buyer_nick">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("buyer_nick") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="15px" />
                        <ItemStyle Width="5%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="cellPhone" HeaderText="电话号码">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="发送日期" SortExpression="sendDate">
                        <ItemTemplate>
                            <asp:Label ID="Label63" runat="server" Text='<%# Eval("sendDate")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="3%" Font-Size="14px" />
                        <ItemStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="发送类型" SortExpression="sendType">
                        <ItemTemplate>
                            <asp:Label ID="Labe5l3" runat="server" Text='<%# Eval("sendType")%>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:TemplateField>
                      <asp:BoundField DataField="sendStatus" HeaderText="发送状态">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgContent" HeaderText="发送内容">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="helpSellerNick" HeaderText="号码类型">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgChannel" HeaderText="选择通道">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="5%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
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
                                买家昵称
                            </th>
                            <th align="center" scope="col">
                                电话号码
                            </th>
                            <th align="center" valign="middle" scope="col">
                                发送日期
                            </th>
                            <th align="center" valign="middle" scope="col">
                                发送类型
                            </th>
                            <th align="center" valign="middle" scope="col">
                                号码类型
                            </th>
                            <th align="center" valign="middle" scope="col">
                                选择通道
                            </th>
                        </tr>
                        <tr>
                            <td colspan="5">
                                没有需要删除的数据！
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
                客户短信记录删除</p>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
          <table >
              <tr>
                  <td>
                      卖家昵称：
                  </td>
                  <td>
                      <asp:TextBox ID="txtSellerName" CssClass="pinpt3" runat="server" Width="168px"></asp:TextBox>
                  </td>
                  <td>
                  </td>
              </tr>
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
