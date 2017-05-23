<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msgHis.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    Inherits="CTCRM.Smart.msgHis" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
        <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <base target="_self" />
    <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <script src="../Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="../message.aspx">短信营销</a></li>
                    <li><a href="index.aspx">智能营销</a></li>
                    <li><a href="../sendMsg.aspx">自有号码群发</a></li>
                    <li class="on"><a href="msgHis.aspx">发送记录</a></li>
                    <li><a href="../shortLink.aspx">短链接生成</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                     <div class="title2">
                        温馨提示: 短信发送历史数据会定期自动清除发送记录
                    </div>
                    <div class="contt4" style="margin-left: 10px">                       
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="right">
                                    <label for="LastTradeTimeStart">
                                        根据发送日期查询：</label>
                                </td>
                                <td>
                                    <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                        id="datePicker" />
                                    至
                <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                    id="datePickerEnd" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="~/Images/serach.jpg" OnClientClick="dialog.DOpen2(this);"
                                        OnClick="btnMsgSend_Click" />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" DataKeyNames="transNumber"
                            AllowPaging="True" PageSize="20" OnPageIndexChanging="grdBuyer_PageIndexChanging">
                            <Columns>
                                <%-- <asp:BoundField DataField="transNumber" HeaderText="事务编号" >
                <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>--%>
                                <asp:BoundField DataField="buyer_nick" HeaderText="买家昵称">
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
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer"
                                    style="border-collapse: collapse;">
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
                        <font color="white">数据查询中,请稍等........</font></h1>
                </div>
                <div id="zhezhang2" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 260px; top: 110px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>
