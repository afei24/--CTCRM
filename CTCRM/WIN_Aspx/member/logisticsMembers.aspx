<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="~/WIN_Aspx/member/logisticsMembers.aspx.cs" Inherits="CTCRM.WIN_Aspx.member.logisticsMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <base target="_self" />
    <script src="../../Js/jquery.js" type="text/javascript"></script>
    <script src="../../Js/TBApply.js" type="text/javascript"></script>
    <script src="../../Js/DialogMsg.js" type="text/javascript"></script>
    <script src="../../Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style type="text/css">
        .tb_tiaojian 
        {
            margin-top:5px;
        }
            .tb_tiaojian td
            {
                text-align:left;
                border:none;
            }
        .auto-style3
        {
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                   <li><a href="index.aspx">会员关怀</a></li>
                     <li><a href="retureGoods.aspx">退货处理</a></li>
                   <li class="on"><a href="reminderHis.aspx">提醒记录</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <div class="pDiv2">
                    <div class="div_zhandian">
                        <span class="zhandian">会员管理 >> 物流未签收</span>
                    </div>
                    
                    <div class="contt4" >  
                        <div class="div_tishi">
                            <p>温馨提示:系统无法搜索到没有物流信息的买家。</p>
                        </div>                     
                        <table border="0" cellpadding="0" cellspacing="0" class="tb_tiaojian">
                            <tr>
                                 <td class="auto-style3" >选择类型：
                                    <asp:DropDownList ID="drpSType" runat="server" CssClass="ui-widget-content ui-corner-all" Width="360px">
                                        <asp:ListItem Value="sign_notSure">物流已经签收，但未确认收货的买家</asp:ListItem>
                                        <asp:ListItem Value="sure_notSign">已经确认收货，但物流未签收的买家</asp:ListItem>
                                        <asp:ListItem Value="sure_notSucce">未签收，未收货的买家</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="~/Images/search.png" OnClientClick="dialog.DOpen2(this);"
                                        OnClick="btnMsgSend_Click" />
                                     
                                </td>
                                <td class="auto-style3" >
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../../Win_Image/doen.png" OnClick="ImageButton2_Click" />
                                    </td>
                                </tr>
                        </table>
                        <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" 
                            AllowPaging="True" PageSize="20" OnPageIndexChanging="grdBuyer_PageIndexChanging" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="buyer_nick" HeaderText="买家昵称">
                                    <HeaderStyle Width="100px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
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
                </div>
                <div id="msgDiv2" style="width: 350px; height: 13px; position: absolute; left: 260px; top: 80px; display: none; z-index: 9999;">
                    <h1>
                        <font color="#00BFE9">数据查询中,请稍等........</font></h1>
                </div>
                <div id="zhezhang2" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 260px; top: 110px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                <div class="contt4" >  
                        <div class="div_tishi">
                            <p>温馨提示:给查询出的买家发送短信。</p>
                        </div>                     
                        <table border="0" cellpadding="0" cellspacing="0" class="tb_tiaojian">
                            <tr>
                                 <td class="auto-style3" >发送内容：
                                </td>
                                </tr>
                            <tr>
                                 <td class="auto-style3" >
                                   <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="64px" Width="793px"></asp:TextBox>
                                </td>
                                </tr>
                            <tr>
                                 <td class="auto-style3" >
                                     <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../../Win_Image/sendmsg.png" OnClick="ImageButton1_Click" />
                                 </td>
                                </tr>
                        </table>
                    </div>
                <script type="text/javascript">
                    document.getElementById("A5").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
