<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="notifyMember.aspx.cs" Inherits="CTCRM.WIN_Aspx.member.notifyMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会员关怀提醒</title>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>

    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="rightside">
        <asp:Menu ID="Menu1" runat="server" StaticEnableDefaultPopOutImage="false" Orientation="Horizontal">
            <Items>
                <asp:MenuItem ImageUrl="~/Images/next1.jpg"></asp:MenuItem>
            </Items>
        </asp:Menu>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">
            <asp:View ID="View1" runat="server">
                <div>
                    <div class="smallTitle">
                        <table>
                            <tr>
                                <td align="right">
                                    开始时间：
                                </td>
                                <td>
                                    <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                        id="datePickerStart" />
                                </td>
                                <td align="right">
                                    结束时间:
                                </td>
                                <td>
                                    <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                        id="datePickerEnd" />
                                </td>
                                <td align="right">
                                    买家昵称:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNickName" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnSearch" ImageUrl="~/Images/serach.jpg" runat="server"
                                        OnClick="imgbtnSearch_Click" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="content">
                        <asp:GridView ID="grdUnpay" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            PageSize="6" OnPageIndexChanging="grdUnpay_PageIndexChanging" BackColor="#F1FCD7">
                            <Columns>
                                <asp:BoundField DataField="tid" HeaderText="交易编号" />
                                <asp:BoundField DataField="buyer_nick" HeaderText="买家昵称" />
                                <asp:BoundField DataField="created" HeaderText="创建时间" />
                                <asp:TemplateField HeaderText="宝贝名称" SortExpression="title">
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# GetTitle(Eval("title").ToString())%>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="total_fee" HeaderText="金额" />
                                <asp:BoundField DataField="cellPhone" HeaderText="收货人手机号" />
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer"
                                    style="border-collapse: collapse">
                                    <tr>
                                        <th scope="col">
                                            交易编号
                                        </th>
                                        <th scope="col">
                                            买家昵称
                                        </th>
                                        <th scope="col">
                                            创建时间
                                        </th>
                                        <th scope="col">
                                            宝贝名称
                                        </th>
                                        <th scope="col">
                                            金额
                                        </th>
                                        <th scope="col">
                                            收货人手机号
                                        </th>
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
            </asp:View>
            <asp:View ID="View2" runat="server">
                <div class="infoArea">
                    <div class="smallTitle">
                        请选择短信模板
                    </div>
                    <div class="content">
                        <div style="height: 170px;">
                            <table>
                                <tr>
                                    <td style="background-color: #F1FCD7">
                                        <span>
                                            <asp:RadioButton GroupName="Msg" ID="rdoMsgTemp1" Text="亲！您**下单时间**拍的宝贝小店已为您备好，付款后我们立即发货，谢谢光临**店铺名称**"
                                                runat="server" AutoPostBack="True" OnCheckedChanged="rdoMsgTemp1_CheckedChanged" /></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #F1FCD7">
                                        <span>
                                            <asp:RadioButton GroupName="Msg" ID="rdoMsgTemp2" Text="亲！**店铺名称**时刻关心您的购物心情：您**下单时间**拍的宝贝还有货哦,或者您还可以看看其他宝贝."
                                                runat="server" AutoPostBack="True" OnCheckedChanged="rdoMsgTemp2_CheckedChanged" /></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #F1FCD7">
                                        <span>
                                            <asp:RadioButton GroupName="Msg" ID="rdoMsgTemp3" Text="亲！您**下单时间**拍的宝贝小店已为您备好,请尽快付.款，时间过长会自动关闭的哦**店铺名称**"
                                                runat="server" AutoPostBack="True" OnCheckedChanged="rdoMsgTemp3_CheckedChanged" /></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="ui-state-error ui-corner-all" style="width: 370px;">
                                            <strong>&nbsp;&nbsp;温馨提示:</strong> 每条短信超过65个字数就会增加短信条数.当前字数:&nbsp;<span id="smsLength"
                                                style="color: Green"><asp:Label ID="lbFontCount" runat="server" Text="0"></asp:Label></span></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #990000">
                                        <asp:Label ID="Label1" runat="server" Font-Bold="true" ForeColor="White" Text="内容预览："></asp:Label><asp:Label
                                            ID="lbMessageView" ForeColor="White" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="vertical-align: middle; background-color: #F1FCD7">
                                        发给自己:&nbsp;<asp:TextBox ID="txtTestMsg" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:ImageButton
                                            ID="ImageButton2" runat="server" ImageUrl="~/Images/sendtestmsg.jpg" OnClick="ImageButton2_Click" />&nbsp;
                                        <asp:Label ID="lbMsg" runat="server" Font-Bold="true" Font-Size="18px" ForeColor="Red"
                                            Text=""></asp:Label><a href="../messageSetting.aspx" target="_blank">
                                    <asp:Label ID="lbOrderMsg" runat="server" Font-Size="18px" Font-Bold="true" ForeColor="Red"
                                        Text="" /></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
            </asp:View>
            <asp:View ID="View3" runat="server">
                <div style="height: 200px; text-align: center; background-color: #F1FCD7">
                    <br />
                    <h2>
                        <img alt="" src="../../Images/okey.png" />亲，您的提醒请求已成功提交。</h2>
                    <p>
                        您现在可以： <a href="../Smart/msgHis.aspx" target="_blank"><img alt="" src="../../Images/sendHis.png" />
                    </p>
                </div>
            </asp:View>
        </asp:MultiView>
    </div>
    <div style="text-align: center">
        <table>
            <tr style="background-color: #F1FCD7">
                <td runat="server" id="tdNext">
                    <asp:ImageButton ID="imgbtnNext" runat="server" ImageUrl="~/Images/next.jpg" OnClick="imgbtnNext_Click" />
                </td>
                <td runat="server" id="tdLast">
                    <asp:ImageButton ID="imgbtnLast" runat="server" ImageUrl="~/Images/last.jpg" OnClick="imgbtnLast_Click" />
                </td>
                <td runat="server" id="tdFinish">
                    <asp:ImageButton ID="imgbtnFinish" ImageUrl="~/Images/confirmsend.jpg" runat="server"
                        OnClick="imgbtnFinish_Click" />
                </td>
                <td>
                    <asp:ImageButton ID="imgbtnClose" runat="server" OnClientClick="window.close();"
                        ImageUrl="~/Images/close.jpg" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
