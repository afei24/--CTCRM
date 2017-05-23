<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendHisReminder.aspx.cs" Inherits="CTCRM.admin.message.sendHisReminder" %>

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
         <asp:HiddenField ID="IsAll" runat="server" />
        <asp:HiddenField ID="Buyer" runat="server" />
                <div class="title">
            <p>
                物流短信发送记录汇总</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table class="tb_yingxiao">
                <tr>
                    <td class="auto-style11">
                        卖家昵称：
                    </td>
                     
                    <td>
                        <asp:TextBox ID="tb_SellerCount" CssClass="pinpt3" runat="server"></asp:TextBox>
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
                AllowPaging="True" BorderWidth="1px" CellPadding="4" OnPageIndexChanging="grdCus_PageIndexChanging" EnableModelValidation="True" OnRowCommand="gd_All_RowCommand">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="30%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="msgCount" HeaderText="发送条数">
                        <HeaderStyle BackColor="#D6E0EF" Width="5%" Font-Size="14px" />
                        <ItemStyle Width="30%" HorizontalAlign=Center VerticalAlign="Middle" Font-Size="14px" />
                    </asp:BoundField>
                    <asp:ButtonField  Text="显示详细数据" CommandName="Show" >
                    <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:ButtonField>
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
        <div class="title">
            <p>
                物流提醒发送记录</p>
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
                    <td class="auto-style8">
                        <asp:TextBox ID="tbHours1" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label1" runat="server" Text="时"></asp:Label>
                        <asp:TextBox ID="tbMin1" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label2" runat="server" Text="分"></asp:Label>
                        <asp:TextBox ID="tbSecond1" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label3" runat="server" Text="秒"></asp:Label>
                        </td>
                    <td>
                        结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="tbHours2" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label4" runat="server" Text="时"></asp:Label>
                        <asp:TextBox ID="tbMin2" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label5" runat="server" Text="分"></asp:Label>
                        <asp:TextBox ID="tbSecond2" runat="server" Width="16px"></asp:TextBox><asp:Label ID="Label6" runat="server" Text="秒"></asp:Label>
                        </td>
                     <td>
                        发送类型：
                    </td>
                    <td>
                        <asp:DropDownList ID="drpSendType" Width="125px" runat="server">
                            <asp:ListItem>---全部---</asp:ListItem>
                            <asp:ListItem>发货提醒</asp:ListItem>
                            <asp:ListItem>延时发货提醒</asp:ListItem>
                            <asp:ListItem>催款提醒</asp:ListItem>
                            <asp:ListItem>到货提醒</asp:ListItem>
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
                <tr><td colspan="5" align="right">
                        <asp:Button ID="btnExport" runat="server" Text=" 导出记录 " CssClass="pinpt4" OnClick="btnExport_Click" 
                             />&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        &nbsp;&nbsp;&nbsp;&nbsp;
                    </td></tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" 
                Width="100%" Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid"
                AllowPaging="True" BorderWidth="1px" CellPadding="4" PageSize="10" OnPageIndexChanging="grdCus_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="4%" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="买家昵称" SortExpression="buyerMemberId">
                        <ItemTemplate>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("buyerMemberId") %>'></asp:Label>
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
                    <asp:BoundField DataField="helpSellerNick" HeaderText="备注">
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
                                备注
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
                      &nbsp;<asp:Button ID="Button2" runat="server" Text=" 清除记录 " CssClass="pinpt4" OnClick="btnDelete_Click" OnClientClick="return confirm('删除后无法恢复，您确认要删除吗？')" />
                  </td>
              </tr>
          </table>
        </div>
    </div>
    </form>
</body>
</html>
