<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Temp/Common.Master"
    CodeBehind="messageSetting.aspx.cs" Inherits="CTCRM.messageSetting" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" type="text/javascript"></script>

    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
    <script src="Js/jquery.min.js" type="text/javascript"></script>
    <script src="Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        function orderMsg() {
            $.messager.alert('店铺管家', '短信在线充值支付接口出现问题，会尽快修复开通，订购短信请直接联系客服开通即可！', 'info');
            return;
        }
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>短信账户</h4>
                <ul class="items">
                    <li class="on"><a href="messageSetting.aspx">短信订购</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        短信套餐包
                    </div>
                    <div class="contt4">
                        <table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
                            <tr>
                                <td scope="col" style="width: 80px;">
                                    <asp:Image ID="Image3" ImageUrl="~/Images/1111.png" runat="server" />
                                </td>
                                <td style="width: 110px; vertical-align: middle">
                                    <asp:Image ID="imgMsgISCanUse" runat="server" />
                                </td>
                                <td scope="col" style="width: 80px;">
                                    <asp:Image ID="Image4" ImageUrl="~/Images/021.png" runat="server" />
                                </td>
                                <td style="width: 154px; margin-top: 300px; vertical-align: middle" colspan="3">
                                    <asp:Label ID="lbMsgCanUseCount" Font-Size="16px" runat="server" Text="" ForeColor="red"></asp:Label>
                                </td>
                                <td>
                                    <a href="Smart/msgHis.aspx" target="_blank">
                                        <img alt="" src="Images/sendHis.png" />
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td valign="middle">
                                        <strong>&nbsp;&nbsp;提示:</strong> 各位亲~订购短信过程中如果遇到问题，请<a target="_blank"
                                                href="http://www.taobao.com/webww/ww.php?ver=3&touid=ljhkim6&siteid=cntaobao&status=1&charset=utf-8"><img
                                                    border="0" src="http://amos.alicdn.com/realonline.aw?v=2&uid=ljhkim6&site=cntaobao&s=1&charset=utf-8"
                                                    alt="点击这里给我发消息" /></a> BTW：付款完成后不要直接关闭支付宝页面，否则会出现短信不到账的问题！
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div>
                                            <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                                style="border-collapse: collapse;">
                                                <tr>
                                                    <th scope="col">套餐名称
                                                    </th>
                                                    <th align="center" valign="middle" scope="col">有效期
                                                    </th>
                                                    <th align="center" valign="middle" scope="col">价格
                                                    </th>
                                                    <th align="center" valign="middle" scope="col">单价
                                                    </th>
                                                    <th align="center" valign="middle" scope="col">适用范围
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)1000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">35.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">5分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp <a href="meesageAcount/nav.aspx?type=2" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)2000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">70.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">4.8分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=3" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)5000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">175.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">4.7分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=4" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)10000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">350.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">4.6分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=5" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)20000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">700.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">4.5分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=6" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)50000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">1750.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font color="red">4.4分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=7" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center" class="datagrid-header-row">店铺管家CRM(淘宝)100000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">3500.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row"><span style="text-decoration:line-through;"><font color="red">4分/条</font></span>&nbsp;3.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" class="datagrid-header-row">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=8" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center" class="datagrid-header-row">店铺管家CRM(淘宝)200000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">6800.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row"><span style="text-decoration:line-through;"><font color="red">4.1分/条</font></span>&nbsp;3.4分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" class="datagrid-header-row">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a href="meesageAcount/nav.aspx?type=9" target="_blank">
                                                        <img src="Images/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                        </div>
                                        <div class="smallTitle">
                                            订购历史
                                        </div>
                                        <div>
                                            <asp:GridView ID="grdHisMsg" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                PageSize="15" OnPageIndexChanging="grdHisMsg_PageIndexChanging">
                                                <Columns>
                                                    <asp:BoundField DataField="packageName" HeaderText="套餐名称" />
                                                    <asp:BoundField DataField="type" HeaderText="类型">
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="price" HeaderText="价格">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="perPrice" HeaderText="单价">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="rank" HeaderText="适用范围">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="orderDate" HeaderText="订购日期" DataFormatString="{0:d}">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                                        style="border-collapse: collapse;">
                                                        <tr>
                                                            <th scope="col">套餐名称
                                                            </th>
                                                            <th align="center" scope="col">类型
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">有效期
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">价格
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">单价
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">适用范围
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">订购日期
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="7">没有订购历史数据
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
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <script type="text/javascript">
                    document.getElementById("A4").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>
