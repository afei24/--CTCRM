<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="messageSetting.aspx.cs" Inherits="CTCRM.WIN_Aspx.messageSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" type="text/javascript"></script>

    <link href="../CSS/easyui.css" rel="stylesheet" />
    <link href="../CSS/icon.css" rel="stylesheet" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        function orderMsg() {
            $.messager.alert('店铺管家', '短信在线充值支付接口出现问题，会尽快修复开通，订购短信请直接联系客服开通即可！', 'info');
            return;
        }
        function BuyMsg() {
            $("#ldg_lockmask").show();
            $(".orderTishi").show();
            return;
        }
    </script>
    <style>
        .ui_border ui_state_focus ui_state_lock> *
        {
            border:none;
           
        }
        .ui_border ui_state_focus ui_state_lock {
             margin-left: 0;
            margin-right: 0;
        }
        .mesOrd td 
        {
            border:none;
            padding-bottom:10px;
            padding-top:10px;
            text-align:left;
        }
        .mesOrd
        {
            border:none;
            border-top: 1px solid #d4d4d4;
            margin-left:20px;
            padding-bottom:10px;
            padding-top:10px;
        }
        .taocan
        {
            border-collapse: collapse;
            border:none;width:100%;
            height:30px;
        }
            .taocan td
            {
                height:30px;
            }
        .waitaocan,.waitaocan > *
        {
            border:solid 1px #F0F0F0;
        }
        .taocan img
        {
            border-radius:5px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>短信账户</h4>
                <ul class="items">
                    <li class="on"><a href="messageSetting.aspx">短信订购</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <div class="pDiv2">
                    <div class="div_zhandian">
                        <span class="zhandian">短信订购 >> 短信订购</span>
                    </div>
                    <div class="contt4">
                        <div class="div_tishi">
                            <p style="padding-left:20px;"><span style="color:#00BFE9">提示：</span>各位亲~订购短信过程中如果遇到问题，请<a target="_blank"
                                                href="http://www.taobao.com/webww/ww.php?ver=3&touid=ljhkim6&siteid=cntaobao&status=1&charset=utf-8"><img
                                                    border="0" src="http://amos.alicdn.com/realonline.aw?v=2&uid=ljhkim6&site=cntaobao&s=1&charset=utf-8"
                                                    alt="点击这里给我发消息" /></a> <span style="color: #00BFE9;">BTW：付款完成后不要直接关闭支付宝页面，否则会出现短信不到账的问题！</span></p><br />

                            <table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;" class="mesOrd">
                            <tr>
                                <td scope="col" style="width: 80px;">
                                    服务状态：
                                </td>
                                <td style="width: 110px; vertical-align: middle">
                                    <asp:Label ID="MsgISCanUse" runat="server"  Text="" ForeColor="#00BFE9" style="font-weight:bold;"></asp:Label>
                                </td>
                                <td scope="col" style="width: 80px;">
                                    剩余短信：
                                </td>
                                <td style="width: 154px; margin-top: 300px; vertical-align: middle" colspan="3">
                                    <asp:Label ID="lbMsgCanUseCount" Font-Size="16px" runat="server" Text="" ForeColor="#00BFE9" style="font-weight:bold;"></asp:Label>
                                </td>
                                <td>
                                    <a href="message.aspx?src=Smart/msgHis.aspx" target="_blank" style="color:#00BFE9;font-weight:bold;">
                                        查看发送记录</a>
                                </td>
                            </tr>
                        </table>
                        </div>
                        
                    </div>
                    <div class="contt4" style="border:none;">
                        <table class="waitaocan" style="border:none">
                            <tbody style="border:none">
                                <tr>
                                    <td valign="middle">
                                        <div class="title2" style="background-color:white;color:black;border-bottom:none;height:50px;font-size:30px;vertical-align:middle;text-align:left;">
                                            <p style="padding-top:5px;">短信套餐包</p>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none">
                                        <div style="border:none;">
                                            <table class="taocan" cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                                >
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
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">45.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >5分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000305107" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)2000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">90.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >4.8分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000305512" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)5000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">225.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >4.7分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306533" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)10000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">450.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >4.6分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306628" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)20000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">900.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >4.6分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306704" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center">店铺管家CRM(淘宝)50000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle">2250.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle"><span style="text-decoration:line-through;"><font >4.6分/条</font></span>&nbsp;4.5分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306705" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center" class="datagrid-header-row">店铺管家CRM(淘宝)100000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">4300.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row"><span style="text-decoration:line-through;"><font >4.6分/条</font></span>&nbsp;4.3分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" class="datagrid-header-row">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306433" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="vertical-align: middle" align="center" class="datagrid-header-row">店铺管家CRM(淘宝)200000条
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">永久有效
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row">8600.00元
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" style="vertical-align: middle" class="datagrid-header-row"><span style="text-decoration:line-through;"><font >4.5分/条</font></span>&nbsp;4.3分/条(活动价)
                                                    </td>
                                                    <td align="center" valign="middle" scope="col" class="datagrid-header-row">店铺管家CRM(淘宝)&nbsp;&nbsp;&nbsp; <a class="buy" onclick="BuyMsg();" href="../meesageAcount/nav.aspx?type=FW_GOODS-1000306706" target="_blank">
                                                        <img src="../../Win_Image/buy1.png" width="80px" height="20px" /></a>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <div>
                                        </div>
                                        <div class="smallTitle" style="background-color:white;color:black;">
                                            订购历史
                                        </div>
                                        <div style="border:none">
                                            <asp:GridView ID="grdHisMsg" runat="server" AutoGenerateColumns="False" AllowPaging="True" style="border:none"
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
                                                        style="border-collapse: collapse;border:none">
                                                        <tr style="border:none">
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
                    <div id="ldg_lockmask" style="display:none; position: fixed; left: 0px; top: 0px; width: 100%; height: 100%; overflow: hidden; opacity: 0.6; z-index: 10; background: rgb(220, 226, 241);"></div>
                    
                    <div class="contt4 orderTishi" style="position: fixed; visibility: visible; display: none; width: auto; left: 304px; top: 173px; z-index: 1978;border: 1px solid #d4d4d4;">
                        <table class="ui_border ui_state_focus ui_state_lock" >
                            <tbody style="border:none">
                                <tr style="border:none">
                                    <td class="ui_lt" style="border:none"></td>
                                    <td class="ui_t" style="border:none">提示</td>
                                    <td class="ui_rt" style="border:none"></td>

                                </tr>
                                <tr style="border:none">
                                    <td class="ui_l"></td>
                                    <td class="ui_main" style="width: auto; height: auto;">
                                        <div class="ui_content" style="padding: 10px;">亲，如果充值成功，请点击确定按钮，软件会自动刷新充值后的短信余额；<br/>如果充值失败，请点击取消按钮</div>

                                    </td>

                                </tr>
                                <tr style="border:none">
                                    <td colspan="2">
                                        <div class="ui_buttons">
                                            <asp:ImageButton ID="ImageButton_Ok" runat="server" ImageUrl="../Win_Image/OK.png" OnClick="ImageButton_Ok_Click" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:ImageButton ID="ImageButton_Cancle" runat="server" ImageUrl="../Win_Image/cancle.png" OnClick="ImageButton_Cancle_Click" />
                                            

                                        </div>

                                    </td>

                                </tr>
                                </tbody>
                            </table>
                        </div>
                    
                <script type="text/javascript">
                    document.getElementById("A4").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
