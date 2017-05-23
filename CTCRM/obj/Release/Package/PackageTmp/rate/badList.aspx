<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="badList.aspx.cs" Inherits="CTCRM.rate.badList"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/css.css" rel="stylesheet" type="text/css" />
     <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <script src="../Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>
                    评价管理</h4>
                <ul class="items">
                    <li><a href="rateSetting.aspx">自动评价</a></li>
                    <li><a href="blacklist.aspx">黑名单</a></li>
                    <li class="on"><a href="badList.aspx">中差评查询</a></li>
                    <li><a href="ratingLog.aspx">评价日志</a></li> 
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        中差评列表
                    </div>
                    <div class="contt4" style="margin-left: 10px">
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 70px">
                                    &nbsp;开始日期：
                                </td>
                                <td>
                                    &nbsp;<input runat="server" type="text" style="width: 110px;" class="ui-widget-content ui-corner-all"
                                        onclick="WdatePicker()" id="datePickerStart" />
                                </td>
                                <td style="width: 70px">
                                    &nbsp;结束日期：
                                </td>
                                <td>
                                    &nbsp;<input runat="server" type="text" style="width: 110px;" class="ui-widget-content ui-corner-all"
                                        onclick="WdatePicker()" id="datePickerEnd" />
                                </td>
                                <td align="center" valign="middle">
                                    <asp:ImageButton ID="btnimgSearch" runat="server" Width="80px" Height="25px" ImageUrl="~/Images/serach.jpg"
                                        OnClientClick="dialog.DOpen(this);" OnClick="btnimgSearch_Click" />&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <asp:GridView CssClass="table2" Width="100%" ID="grdbadList" runat="server" AutoGenerateColumns="False"
                            AllowPaging="True" OnPageIndexChanging="grdbadList_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="买家昵称" SortExpression="Nick">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBuyerNick" runat="server" Text='<%# Eval("Nick").ToString() %>' />
                                        <a target="_blank" href="http://www.taobao.com/webww/ww.php?ver=3&touid=<%# Eval("Nick").ToString() %>&siteid=cntaobao&status=2&charset=utf-8">
                                            <img border="0" src="http://amos.alicdn.com/realonline.aw?v=2&uid=<%# Eval("Nick").ToString() %>&site=cntaobao&s=2&charset=utf-8"
                                                alt="点击这里给我发消息" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Cellphone" HeaderText="买家电话">
                                    <HeaderStyle HorizontalAlign="center" Width="80px" />
                                    <ItemStyle HorizontalAlign="Center" Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RealName" HeaderText="买家姓名">
                                    <HeaderStyle HorizontalAlign="center" Width="70px" />
                                    <ItemStyle HorizontalAlign="Center" Width="70px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Content" HeaderText="评价内容">
                                    <HeaderStyle HorizontalAlign="center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ItemTitle" HeaderText="宝贝名称">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Result" HeaderText="评价结果">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <HeaderStyle Width="60px" Wrap="false" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Created" HeaderText="评价时间">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table2">
                                    <tr>
                                        <th>
                                            昵称
                                        </th>
                                        <th>
                                            评价内容
                                        </th>
                                        <th>
                                            宝贝名称
                                        </th>
                                        <th>
                                            评价结果
                                        </th>
                                        <th>
                                            评价日期
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            当前没有评价内容
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
                <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 380px;
                    top: 150px; display: none; z-index: 9999;">
                    <h1>
                        <font color="white">中差评查询中,请稍等........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px;
                    height: 13px; position: absolute; left: 380px; top: 180px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif);
                    z-index: 9999;">
                </div>
                 <script type="text/javascript">
                     document.getElementById("A2").className += ' NavSelected';
                 </script> 
            </div>
        </div>
    </div>
</asp:Content>
