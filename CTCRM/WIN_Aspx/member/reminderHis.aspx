<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="reminderHis.aspx.cs" Inherits="CTCRM.WIN_Aspx.member.reminderHis" %>

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
        .auto-style1
        {
            width: 590px;
        }
        .auto-style3
        {
            width: 176px;
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
                        <span class="zhandian">物流提醒 >> 提醒记录</span>
                    </div>
                    
                    <div class="contt4" >  
                        <div class="div_tishi">
                            <p>温馨提示:该记录为物流提醒短信发送历史数据</p>
                        </div>                     
                        <table border="0" cellpadding="0" cellspacing="0" class="tb_tiaojian">
                            <tr>
                                <td align="right" style="border-style: none; border-color: inherit; border-width: medium;" class="auto-style3">
                                    <label for="LastTradeTimeStart">
                                        根据发送日期查询：</label>
                                </td>
                                <td style="border:none" class="auto-style1">
                                    <p>
                                    <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                        id="datePicker" />
                                    至
                <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                    id="datePickerEnd" /></p>
                                </td>
                                
                                <td style="border:none">
                                    
                                </td>
                            </tr>
                            <tr>
                                 <td class="auto-style3" >提醒类型：
                                </td>
                                <td class="auto-style1">
                                    <asp:DropDownList ID="drpSType" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="催款提醒">催款提醒</asp:ListItem>
                                        <asp:ListItem Value="付款提醒">付款提醒</asp:ListItem>
                                        <asp:ListItem Value="到货提醒">到货提醒</asp:ListItem>
                                        <asp:ListItem Value="回款提醒">回款提醒</asp:ListItem>
                                        <asp:ListItem Value="签收提醒">签收提醒</asp:ListItem>
                                        <asp:ListItem Value="延时发货提醒">延时发货提醒</asp:ListItem>
                                        <asp:ListItem Value="发货提醒">发货提醒</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="border:none">
                                    <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="~/Images/search.png" OnClientClick="dialog.DOpen2(this);"
                                        OnClick="btnMsgSend_Click" />
                                </td>
                                </tr>
                        </table>
                        <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" DataKeyNames="transNumber"
                            AllowPaging="True" PageSize="15" OnPageIndexChanging="grdBuyer_PageIndexChanging">
                            <Columns>
                                <%-- <asp:BoundField DataField="transNumber" HeaderText="事务编号" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>
                                <asp:BoundField DataField="buyerMemberId" HeaderText="买家昵称">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <%-- <asp:BoundField DataField="cellPhone" HeaderText="电话号码" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>
                                <asp:BoundField DataField="sendDate" HeaderText="发送时间">
                                    <HeaderStyle Width="130px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sendType" HeaderText="发送类型">
                                    <HeaderStyle Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="msgContent" HeaderText="发送内容">
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer" class="table2"
                                    style="width:100%;">
                                    <tr>
                                        <th scope="col">买家昵称
                                        </th>
                                        <th scope="col">发送时间
                                        </th>
                                        <th scope="col">发送类型
                                        </th>
                                        <th scope="col">发送内容
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="5">当前没有发送明细
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
                <script type="text/javascript">
                    document.getElementById("A5").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
