<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    Inherits="CTCRM.index" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link rel="shortcut icon" href="favicon.ico" />
    <link type="text/css" href="CSS/demo.css" rel="Stylesheet" media="screen" />
    <link type="text/css" href="CSS/basic.css" rel="Stylesheet" media="screen" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <%-- <div id='container'>
        <div id="basic-modal-content">
            <table>
                <tbody>
                    <tr>
                        <td align="center">
                            <div>
                                <p>
                                    <img src="http://img03.taobaocdn.com/imgextra/i3/843363746/T2xbTIXohaXXXXXXXX_!!843363746.jpg"
                                        border="0" usemap="#Map1" />
                                    <map name="Map1" id="Map1">
                                        <area shape="rect" coords="546,131,742,211" href="http://to.taobao.com/yaL75iy" target="_blank" />
                                    </map>
                                    <img src="http://img03.taobaocdn.com/imgextra/i3/843363746/T2mXfWXoJaXXXXXXXX_!!843363746.jpg"
                                        border="0" usemap="#Map3" />
                                    <map name="Map3" id="Map3">
                                        <area shape="rect" coords="316,5,592,37" target="_blank" href="http://bangpai.taobao.com/group/thread/14992769-277692074.htm?spm=0.0.0.40.c43c2b" />
                                    </map>
                                </p>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>

    <script type='text/javascript' src="js/jquery.min.js"></script>

    <script type='text/javascript' src="js/jquery.simplemodal.js"></script>

    <script language="javascript" type="text/javascript">
jQuery(function ($) {
	// Load dialog on page load
	$('#basic-modal-content').modal({onOpen: function (dialog) {
			dialog.overlay.fadeIn('slow');
			dialog.data.show();
			dialog.container.fadeIn('slow');
		},onClose: function (dialog) {
			dialog.container.fadeOut('slow');
			dialog.overlay.fadeOut('slow',function(){
				$.modal.close();
			});
		},
		opacity:45
	});
});
    </script>--%>

    <div id="wrapper">
        <div id="body">
            <div class="leftside">
                <div class="infoArea">
                    <div class="content">
                        <table>
                            <tbody>
                                <tr>
                                    <td rowspan="5" align="center" style="width: 80px">
                                        <asp:Image ID="shopImg" Style="width: 80px; height: 80px; float: left;" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        当前昵称：
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lbNickName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        店铺名称：
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lbShopName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        剩余短信：
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lbUnUseMsgCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="left">
                                        到期时间：
                                    </td>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lbUptoDate" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <%--<div class="smallTitle">
                        &nbsp;同步店铺数据到系统
                    </div>
                    <div class="content">
                        <table>
                            <tbody>
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="tnUpdateDate" runat="server" ImageUrl="~/Images/downloadOrder.jpg"
                                            OnClick="tnUpdateDate_Click" CssClass="BtnStyle" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>--%>
                    <div class="smallTitle">
                        会员等级状况
                    </div>
                    <div class="content">
                        <table>
                            <tbody>
                                <tr style="font-weight: bold;">
                                    <td>
                                        级别
                                    </td>
                                    <td>
                                        标识
                                    </td>
                                    <td colspan="2" style="width: 20%">
                                        数量
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        潜在会员
                                    </td>
                                    <td>
                                        <img alt="潜在会员" src="Images/qianzai.png" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbQianZai" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        普通会员
                                    </td>
                                    <td>
                                        <img alt="普通会员" src="Images/putong.png" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbCommonBuyer" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        高级会员
                                    </td>
                                    <td>
                                        <img alt="高级会员" src="Images/gaoji.png" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbAdvanceBuyer" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Vip会员
                                    </td>
                                    <td>
                                        <img alt="Vip会员" src="Images/vip.png" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbVIP" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        至尊Vip会员
                                    </td>
                                    <td>
                                        <img alt="至尊Vip会员" src="Images/topvip.png" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lbTopVIP" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="infoArea">
                    <div class="smallTitle">
                        会员分组概况
                    </div>
                    <div class="content">
                        <table>
                            <tbody>
                                <tr style="font-weight: bold;">
                                    <td>
                                        标签名称
                                    </td>
                                    <td colspan="2" style="width: 20%">
                                        数量
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        第一次购买的会员【新客户】
                                    </td>
                                    <td>
                                        <asp:Label ID="lbNewBuyerCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        重复购买的会员【老客户】
                                    </td>
                                    <td>
                                        <asp:Label ID="lbOldBuyerCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        最后1次交易距今超过3个月【休眠3个月】
                                    </td>
                                    <td>
                                        <asp:Label ID="lb3MonthsNoLoginCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        下单未付款的会员【潜在客户】
                                    </td>
                                    <td>
                                        <asp:Label ID="QianZaiBuyerCount" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <%--  <tr>
                                    <td colspan="2" align="center">
                                        <asp:ImageButton ID="btnDownLoadDesk" runat="server" ImageUrl="~/Images/downloaddeskTop.jpg"
                                            CssClass="BtnStyle" onclick="btnDownLoadDesk_Click" />
                                    </td>
                                </tr>--%>
                            </tbody>
                        </table>
                    </div>
                </div>
               
            </div>
            <div class="rightside">
                <div class="infoArea">
                    <div class="smallTitle">
                        &nbsp;店铺运营情况统计
                    </div>
                    <div class="content">
                        <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                            style="border-collapse: collapse;">
                            <tbody>
                                <tr>
                                    <th scope="col">
                                        销售额
                                    </th>
                                    <th align="center" scope="col">
                                        订单数
                                    </th>
                                    <th align="center" valign="middle" scope="col">
                                        会员数
                                    </th>
                                    <th align="center" valign="middle" scope="col">
                                        客单价
                                    </th>
                                    <th align="center" valign="middle" scope="col">
                                        新客户订单数
                                    </th>
                                    <th align="center" valign="middle" scope="col">
                                        退款笔数
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lbTotalSales" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbOrderCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbUserCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbPerOrderPirce" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbNewUserOrderCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbRefundOrderCount" runat="server" Text="0"></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="infoArea">
                    <div class="smallTitle">
                        会员消费总金额排行榜
                    </div>
                    <div class="content">
                        <asp:GridView ID="grdTopBuyerTradeAmount" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="buyer_nick" HeaderText="买家昵称" />
                                <asp:BoundField DataField="trade_amount" HeaderText="总金额" DataFormatString="{0:c}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trade_count" HeaderText="总笔数">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_num" HeaderText="总数量">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="avg_price" HeaderText="平均客单价" DataFormatString="{0:c}">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                    style="border-collapse: collapse;">
                                    <tr>
                                        <th scope="col">
                                            买家昵称
                                        </th>
                                        <th align="center" scope="col">
                                            总金额
                                        </th>
                                        <th align="center" valign="middle" scope="col">
                                            总笔数
                                        </th>
                                        <th align="center" valign="middle" scope="col">
                                            总数量
                                        </th>
                                        <th align="center" valign="middle" scope="col">
                                            平均客单价
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
                <div class="infoArea">
                    <div class="smallTitle">
                        热销宝贝排行榜
                    </div>
                    <div class="content">
                        <asp:GridView ID="grdTopSales" PageSize="10" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="title" HeaderText="宝贝名称" HeaderStyle-Width="60%" />
                                <asp:BoundField DataField="price" HeaderText="宝贝单价" HeaderStyle-Width="12%" DataFormatString="{0:c}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="num" HeaderText="销售量" HeaderStyle-Width="10%">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="totalTrade" HeaderText="总金额" DataFormatString="{0:c}"
                                    HeaderStyle-Width="10%">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                    style="border-collapse: collapse;">
                                    <tr>
                                        <th scope="col">
                                            宝贝名称
                                        </th>
                                        <th scope="col">
                                            宝贝单价
                                        </th>
                                        <th align="center" scope="col">
                                            销售量
                                        </th>
                                        <th align="center" valign="middle" scope="col">
                                            总金额
                                        </th>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div style="clear: both;">
            </div>
        </div>
    </div>
</asp:Content>
