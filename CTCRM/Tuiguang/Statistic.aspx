<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistic.aspx.cs" Inherits="CTCRM.Tuiguang.Statistic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>流量宝、流量推广、精准营销提供</title>
    <link href="CSS/TBApplyTemp.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Items.css" rel="stylesheet" type="text/css" />
    <link href="css2/site.css" rel="stylesheet" type="text/css" />
    <link href="css2/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="css2/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="css2/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="css2/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="css2/home.css" rel="stylesheet" />
    <link href="css2/css.css" rel="stylesheet" />
    <script src="JS/jquery.js"></script>
    <script src="JS/My97DatePicker/WdatePicker.js"></script>
</head>
<body>
    <form id="form1" runat="server">
          <div id="main">
            <div id="top">
                <div class="t_c t_c_m">
                    <div class="t_c_t">
                         <ul class="t_c_t_u">
                            <li class="t_c_t_l t_c_t_l_l" style="margin-left:17px"><a href="javascript:void(0)">
                                <asp:Label runat="server" Text="fan" ID="lab_Nick"></asp:Label>|</a></li>
                            <li class="t_c_t_l t_c_t_l_m" style="margin-left:-1px;width:79px;"><a href="javascript:void(0)">
                                <asp:Label ID="lbVersion" runat="server" Text=""></asp:Label>
                                |</a></li>
                            <li class="t_c_t_l">
                               
                            </li>
                        </ul>
                    </div>
                    <div class="t_c_b">
                        <ul class="nav">
                            <li class="n_l n_l_f "><a class="n_a" id="FirstPage" href="Index.aspx">首页</a></li>
                            <li class="n_l"><a class="n_a" id="A10" href="Item.aspx">宝贝推广</a></li>
                            <li class="n_l"><a class="n_a" id="Shop" href="Shop.aspx">提交店铺</a></li>
                            <li class="n_l"><a class="n_a" id="A11" href="Statistic.aspx">推广效果</a></li>
                            <li class="n_l"><a class="n_a" id="introduce" href="Popularize.aspx">推广位介绍</a></li>
                        </ul>
                    </div>
                </div>
            </div>
            <div id="bottom">
                <div class="t_c">
                    <div class="b_t">
                    </div>
                    <div class="b_m">
                        <div class="b_c">
                            <div class="title2" style="margin-left:-21px;">
                                1:系统内部统计: 【精确查询对应时间段访客人数】
                            </div>
                            <div  style="margin-left: -21px;margin-top:5px;">
                                <ul id="items">
                                <li class="data">
                                    <ul>
                                        <li id="d_c" class="da">
                                            <table border="0" class="da">
                                                <tr>
                                                    <td align="left" style="width: 40px;">日期：
                                                    </td>
                                                    <td>
                                                        <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                                            id="datePicker" />
                                                        至
                <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                    id="datePickerEnd" />
                                                    </td>
                                                    <td style="text-align:center;">
                                                        <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="~/Tuiguang/Images/search.png"
                                                            OnClick="btnMsgSend_Click" Width="90px" Height="28px" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" DataKeyNames="transNo"
                                                AllowPaging="True" PageSize="10" OnPageIndexChanging="grdBuyer_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="accessNum" HeaderText="访客数">
                                                        <HeaderStyle Width="100px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>                                                   
                                                    <asp:BoundField DataField="createTime" HeaderText="统计时间">
                                                        <HeaderStyle Width="130px" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table border="0" id="ctl00_ContentPlaceHolder1_grdBuyer"
                                                        style="border-collapse: collapse;margin-left:-5px">
                                                        <tr>
                                                            <th scope="col">访客数
                                                            </th>
                                                            <th scope="col">统计时间
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">当前没有统计数据
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
                                        </li>
                                    </ul>
                                </li>
                            </ul>
                            </div>
                            <br />
                            <div class="title2" style="margin-left:-21px;">
                                2:官方流量统计: 【生意参谋】
                             </div>
                            <div style="margin-top:24px;height:39px;">
                                <a href="https://beta.sycm.taobao.com/index.htm" target="_blank" >【点击进入：生意参谋】</a>
                            </div>
                        </div>
                    </div>
                    <div class="b_b">
                        <script type="text/javascript">
                            document.getElementById("A11").className += ' NavSelected';
                        </script>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
