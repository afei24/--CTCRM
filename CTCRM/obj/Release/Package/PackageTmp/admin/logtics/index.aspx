<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CTCRM.admin.logtics.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
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
                卖家物流提醒查询</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr align="left">
                    <td style="width: 40px;">
                        昵称：
                    </td>
                    <td style="width: 60px;">
                        <asp:TextBox ID="txtTitle" Width="130px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 90px;">
                        订购开始日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                    </td>
                    <td style="width: 90px;">
                        订购结束日期：
                    </td>
                    <td>
                        <input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                    </td>
                    <td>
                        提醒类型：
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
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 搜  索 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
            </table>
        </div>
        <!-- jsuo End -->
        <div class="nrkuai">
            <asp:GridView ID="grdCus" runat="server" AutoGenerateColumns="False" Width="100%"
                Height="10px" BackColor="White" BorderColor="Gainsboro" BorderStyle="Solid" AllowPaging="True"
                BorderWidth="1px" CellPadding="4" PageSize="10" OnPageIndexChanging="grdCus_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="sellerNick" HeaderText="卖家昵称">
                        <HeaderStyle Width="3%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="unPayType" HeaderText="催款通知">
                        <HeaderStyle Width="4%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="payType" HeaderText="付款提醒">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="shippingType" HeaderText="发货通知">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="delayShippingType" HeaderText="延迟发货通知">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="arrivedType" HeaderText="达到通知">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                     <asp:BoundField DataField="signType" HeaderText="签收通知">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                     <asp:BoundField DataField="huiZJType" HeaderText="回款通知">
                        <HeaderStyle Width="3%" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <EmptyDataTemplate>
                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                        style="border-collapse: collapse; width: 900px">
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
        &nbsp;&nbsp;&nbsp;昵称：<asp:TextBox ID="txtNick" runat="server"></asp:TextBox>&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;开通选项：&nbsp;<asp:RadioButtonList ID="rdoCloseOpen" runat="server"
            RepeatDirection="Horizontal">
            <asp:ListItem>开启</asp:ListItem>
            <asp:ListItem>关闭</asp:ListItem>
        </asp:RadioButtonList>
        &nbsp;<asp:RadioButtonList ID="rdoReminderType" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>付款提醒</asp:ListItem>
            <asp:ListItem>催款提醒</asp:ListItem>
            <asp:ListItem>发货提醒</asp:ListItem>
            <asp:ListItem>延迟发货提醒</asp:ListItem>
            <asp:ListItem>达到提醒</asp:ListItem>
            <asp:ListItem>签收提醒</asp:ListItem>
            <asp:ListItem>回款提醒</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button ID="btnSave" runat="server" Text="更 改" Height="27px" Width="94px" OnClick="btnSave_Click" />&nbsp;&nbsp;<asp:Label
            ForeColor="Blue" Font-Bold="true" Font-Size="Large" ID="lbMsg" runat="server"
            Text=""></asp:Label>
    </div>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                新版本：卖家昵称
            </td>
            <td>
                <asp:TextBox ID="sellerNick" runat="server" Height="17px" Width="117px"></asp:TextBox>
            </td>
            <td>
                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>开启</asp:ListItem>
                    <asp:ListItem>关闭</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                SessionKey:<asp:TextBox ID="txtSession" runat="server" Width="318px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="Button1" runat="server" Text="更改" Height="29px" OnClick="Button1_Click"
                    Width="78px" />
            </td>
        </tr>
        <tr>
            <td colspan="5">
                <asp:Label ID="lbMsg2" runat="server" ForeColor="Blue" Font-Bold="true" Font-Size="Large"
                    Text=""></asp:Label>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="Label1" runat="server" Text="卖家昵称："></asp:Label><asp:TextBox ID="txtNickName"
                runat="server"></asp:TextBox>
        </td>
        <td colspan=4>
            <asp:Button ID="Button2" runat="server" Text="查 询 SESSIONKEY" 
                onclick="Button2_Click" />&nbsp;&nbsp;<asp:Label ID="lbSessionKey" Font-Bold=true Font-Size="15px"
                runat="server" Text=""></asp:Label>
        </td>
        </tr>
         <tr>
        <td>
            <asp:Label ID="Label2" runat="server" Text="卖家昵称："></asp:Label><asp:TextBox ID="TextBox1"
                runat="server"></asp:TextBox>
        </td>
        <td colspan=4>
            <asp:Button ID="Button3" runat="server" Text="开通数据同步" onclick="Button3_Click" 
                />&nbsp;&nbsp;<asp:Label ID="Label3" Font-Bold=true Font-Size="15px"
                runat="server" Text=""></asp:Label>
        </td>
        </tr>
    </table>
    </form>
</body>
</html>
