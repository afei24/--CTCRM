.<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index1.aspx.cs" Inherits="CTCRM.WIN_Aspx.member.index1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <link href="../../WIN_CSS/SMSAlter.css" rel="stylesheet" />
    <link href="../../WIN_CSS/msg_div.css" rel="stylesheet" />
    <script src="../../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../../Js/DialogMsg.js" type="text/javascript"></script>
    <script src="../../Js/common.js" type="text/javascript"></script>
    <script src="../../win_js/member.js"></script>

    <style type="text/css">
        .image_button1 {
            margin-top: 5px;
        }

            .image_button1 .image_button1_1 {
                /*padding-right:5px;*/
                border: none;
            }
    </style>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="users" runat="server" />
        <div id="homewrap">
            <div class="homediv">
                <div class="righter">
                    <div class="pDiv2">
                        <div class="div_zhandian">
                            <span class="zhandian">短信提醒 >> 会员关怀</span>
                        </div>
                        <div class="contt4">
                            <div class="image_button1">
                                <asp:ImageButton ID="notpaying" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/unfahuo.jpg" OnClick="notpaying_Click" />
                                <asp:ImageButton ID="pay" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/fukuan.jpg" OnClick="pay_Click" />
                                <asp:ImageButton ID="delivery" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/fahuo.jpg" OnClick="delivery_Click" />
                                <asp:ImageButton ID="delay" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/yanchi.jpg" OnClick="delay_Click" />
                                <asp:ImageButton ID="arrived" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/daoda.jpg" OnClick="arrived_Click" />
                                <asp:ImageButton ID="Sign" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/qianshou.jpg" OnClick="Sign_Click" />
                                <asp:ImageButton ID="receivable" runat="server" CssClass="radius_btn image_button1_1" ImageUrl="../../Win_Image/huikuan.jpg" OnClick="receivable_Click" />
                            </div>

                            <div class="title2 notpaying contt4_2">
                                <asp:Label ID="Label25" runat="server" Text="未付款提醒" Font-Bold="true" Font-Size="12pt"
                                    ForeColor="#00BFE9"></asp:Label><%--【<font style="color: #00BFE9">批量提醒未付款会员尽快付款：买家拍下后2小时未付款则自动提醒</font>】 --%>
                                <%--<span class="tixing_titlemsg" style="color:#00BFE9;font-size:18px;font-weight:bold;">未付款提醒</span>--%>
                            </div>

                            <div class="contt4 notpaying contt4_2">
                                <table>
                                    <tbody>
                                        <tr>
                                            <td style="width: 70%; vertical-align: top; border: none; background-color: white">
                                                <table>
                                                    <tbody>
                                                        <tr>
                                                            <td class="td_left"><strong>基本设置&nbsp;</strong>
                                                            </td>
                                                            <td class="td_right">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;&nbsp;<asp:Label ID="Label8" runat="server" Text="是否开启："></asp:Label>
                                                            </td>
                                                            <td class="td_right">
                                                                <asp:RadioButton ID="radio_on" runat="server" Text=" 开启" GroupName="1" />
                                                                <asp:RadioButton ID="radio_off" runat="server" Text=" 关闭" GroupName="1" Checked="true" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">短信内容：</td>
                                                            <td class="td_right">
                                                                <asp:TextBox ID="txt_div_nopay_msg" runat="server" onkeydown="CheckContentCount('div_nopay_msg')" onkeyup="CheckContentCount('div_nopay_msg')" onpaste="CheckContentCount('div_nopay_msg')"
                                                                    Font-Size="12px" TextMode="MultiLine" Height="100px" Width="450px" Style="margin-top: 5px;" Font-Bold="False">亲！我们时刻关心您的购物心情：您**下单时间**拍的宝贝还有货哦,或者您还可以看看其他宝贝</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">短信模板：</td>
                                                            <td class="td_right"><a href="javascript:return false;" class="msgTemp" title="0" style="color: #767676;">短信模版</a>&nbsp;&nbsp;
                                                                <a href="../../shortLink.aspx" style="color: #767676;">缩短网址</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">发送设置：
                                                            </td>
                                                            <td class="td_right">订单金额大于&nbsp;<asp:TextBox
                                                                ID="txtAmount" Width="80px" CssClass="ui-widget-content ui-corner-all" Text="0" runat="server"></asp:TextBox>
                                                                至
                                                                <asp:TextBox
                                                                    ID="txtAmount01" Width="80px" CssClass="ui-widget-content ui-corner-all" Text="0" runat="server"></asp:TextBox>&nbsp;元之间才发送
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="td_left">&nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="条件过滤："></asp:Label>
                                                            </td>
                                                            <td class="td_right">
                                                                <asp:CheckBox ID="cbx_blackList" runat="server" Text=" 黑名单里的会员不发送(勾选生效)" />
                                                                <a href="../members.aspx?src=blacklist.aspx" target="_parent">[管理黑名单]</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">
                                                                <asp:CheckBox ID="cbx_threeDay" runat="server" Text=" 3天内发送过的会员不发送(勾选生效)" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">
                                                                <asp:CheckBox ID="cbx_area" runat="server" Text=" 地区是 " />
                                                                <asp:TextBox ID="tbx_area" Width="200px" CssClass="ui-widget-content ui-corner-all" runat="server"></asp:TextBox>
                                                                不发送(列如：北京、上海)</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">
                                                                <%--<asp:ImageButton ID="ibt_submit" ImageUrl="~/Images/save.jpg" runat="server" CssClass="radius_btn" OnClick="ibt_submit_Click" />--%>
                                                                <asp:ImageButton ID="ImageButton1" ImageUrl="~/Images/save.jpg" runat="server" CssClass="radius_btn" OnClick="btnSave_Click" />
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left"></td>
                                                            <td class="td_right">&nbsp;</td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td style="width: 30%; vertical-align: middle; border: none; background-color: white">
                                                <div style="margin-left: 100px; width: 219px; height: 280px; background-image: url('../../Win_Image/iphone.png'); background-repeat: no-repeat">
                                                    <div id="div_nopay_msg" class="div_msg" style="padding-top: 50px; margin-bottom: 200px; width: 120px; margin-left: 20px; color: #333; font-family: microsoft yahei; font-size: 14px; white-space: normal; word-break: break-all; word-wrap: break-word;">
                                                        <asp:Label ID="lb_phoneMsg" runat="server" Text=""></asp:Label>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                                <div class="msgMoban">
                                    <div style="margin-top: 20px; margin-left: 20px; width: 624px; height: 336px;">
                                        <table style="border: 0px; width: 100%;">
                                            <tr>
                                                <td style="width: 40px; text-align: left; border: 0px;">短信类型
                                                    <select id="msg_type" onchange="selectChange(this.value)"></select></td>
                                                <td style="width: 40px; border: 0px; text-align: right">
                                                    <input type="button" value="×" style="margin-right: 5px; width: 25px; height: 25px;" onclick="Msgclose()" /></td>
                                            </tr>
                                        </table>
                                        <div class="msgList"></div>
                                        <div class="op"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />

            </div>
        </div>
    </form>
</body>
</html>
