<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logticsList.aspx.cs" Inherits="CTCRM.admin.logtics.logticsList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
 <script  type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>    
 <title></title>
     <style type="text/css">
        .gv_sellser {
            width: 100%;
        }

        .table {
            width: 100%;
        }
         .tb_tiaojian td {
            text-align:center;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    已经签收但是未确认收货买家查询<asp:Label ID="lb_buyerCount" runat="server"></asp:Label>
                    <hr />
                    <div>
                        <%--<div>
                            用户昵称<asp:TextBox ID="tb_nick" runat="server"></asp:TextBox>
                            &nbsp;<asp:Button ID="bt_sosuo" runat="server" Text="搜索" OnClick="bt_sosuo_Click"  />
                            &nbsp;
                            <asp:Button ID="bt_Export" runat="server" Text="生成下载链接" OnClick="bt_Export_Click" />&nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server">下载</asp:HyperLink>
                        </div>--%>
                        <table border="0" cellpadding="0" cellspacing="0" class="tb_tiaojian">
                            <tr>
                                 <td class="auto-style3" >卖家名称：<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                     
                                </td>
                                 
                                <td class="auto-style3" >
                                    价格:从<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>至<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                    </td>
                                <td class="auto-style12">
                                    &nbsp;开始日期：<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                                </td>
                                 <td class="auto-style10">
                                    &nbsp;结束日期：<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                                </td>

                                </tr>
                            <tr>
                                 <td class="auto-style3" >
                                </td>
                                <td class="auto-style3" >
                                    
                                    </td>
                                <td class="auto-style3" >
                                    
                                    </td>
                                <td class="auto-style3" >
                                    &nbsp;
                                    </td>
                                </tr>
                            <tr>
                                 <td class="auto-style3" >选择类型：
                                    <asp:DropDownList ID="drpSType" runat="server" CssClass="ui-widget-content ui-corner-all" Width="360px">
                                        <asp:ListItem Value="sign_notSure">物流已经签收，但未确认收货的买家</asp:ListItem>
                                        <asp:ListItem Value="sure_notSign">已经确认收货，但物流未签收的买家</asp:ListItem>
                                        <asp:ListItem Value="sure_notSucce">未签收，未收货的买家</asp:ListItem>
                                    </asp:DropDownList>

                                    
                                     
                                </td>
                                <td class="auto-style3" >
                                    <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="~/Images/search.png" OnClientClick="dialog.DOpen2(this);"
                                        OnClick="btnMsgSend_Click" />
                                    </td>
                                <td class="auto-style3" >
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../Win_Image/doen.png" OnClick="ImageButton2_Click" />
                                    </td>
                                <td class="auto-style3" >
                                    
                                    </td>
                                </tr>
                        </table>
                        <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" PageSize="20" OnPageIndexChanging="grdBuyer_PageIndexChanging" EnableModelValidation="True" Width="1343px">
                            <Columns>
                                <asp:BoundField DataField="buyer_nick" HeaderText="买家昵称">
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50%" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tid" HeaderText="订单号" />
                                <asp:BoundField DataField="payment" HeaderText="订单金额" />
                                <asp:BoundField DataField="createdate" HeaderText="订单时间" />
                                <asp:BoundField DataField="stutas" HeaderText="订单状态">
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer" class="table2"
                                    style="width:100%;">
                                    <tr>
                                        <td colspan="5">当前没有该类型物流
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
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <script type="text/javascript">
            function setValue(hid_id, value) {
                document.getElementById(hid_id).innerText = value;
            }
        </script>
    </form>
</body>
</html>
