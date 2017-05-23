<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="win_memberMsg_old.aspx.cs" Inherits="CTCRM.WIN_Aspx.win_memberMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../WIN_CSS/win_memberMsg.css" rel="stylesheet" type="text/css" />
    <link href="../WIN_CSS/control.css" rel="stylesheet" />
    <script src="../Js/jquery-1.7.1.min.js"></script>
    <script src="../win_js/win_memberMsg.js"></script>
    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <title>会员短信群发</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_father">

            <div class="tiltle">短信管理>>会员短信群发</div>

            <hr class="hr_01" />

            <div class="note">
                温馨提醒：<br />
                <br />
                短信的发送时间段为早上9点到晚上8点，如果给您带来不便，敬请谅解！
            </div>

            <div class="bt_01">
                <input type="radio" id="rdo_msg" />
                短信群发
                <input type="radio" value="rdo_his" />
                发送记录
            </div>

            <div class="content">

                <table class="tab_01">
                    <tr>
                        <td class="td_01">群发对象：</td>

                        <td class="td_02">
                            <div class="div_bt_01" id="memberSearch">筛选会员</div>
                            <div class="div_allmember">
                                <ul class="ul_tab">
                                    <li class="li_01">筛选会员</li>
                                    <li class="li_02">结果显示</li>
                                    <li class="li_03"></li>
                                </ul>

                                <table class="tab_02">
                                    <tr>
                                        <td class="td_01">买家昵称：<asp:TextBox ID="tbx_nick" runat="server"></asp:TextBox>
                                        </td>
                                        <td class="td_02">会员级别：<asp:DropDownList ID="ddl_level" runat="server" Height="16px">
                                            <asp:ListItem Value="all">全部</asp:ListItem>
                                            <asp:ListItem Value="0">潜在会员</asp:ListItem>
                                            <asp:ListItem Value="1">普通会员</asp:ListItem>
                                            <asp:ListItem Value="2">高级会员</asp:ListItem>
                                            <asp:ListItem Value="3">Vip会员</asp:ListItem>
                                            <asp:ListItem Value="4">至尊Vip会员</asp:ListItem>
                                        </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">所在地区：<asp:DropDownList ID="ddl_province" runat="server">
                                            <asp:ListItem Value="all">全部</asp:ListItem>
                                            <asp:ListItem Value="北京">北京市</asp:ListItem>
                                            <asp:ListItem Value="上海">上海市</asp:ListItem>
                                            <asp:ListItem Value="天津">天津市</asp:ListItem>
                                            <asp:ListItem Value="重庆">重庆市</asp:ListItem>
                                            <asp:ListItem Value="河北">河北省</asp:ListItem>
                                            <asp:ListItem Value="山西">山西省</asp:ListItem>
                                            <asp:ListItem Value="内蒙古">内蒙古自治区</asp:ListItem>
                                            <asp:ListItem Value="辽宁">辽宁省</asp:ListItem>
                                            <asp:ListItem Value="吉林">吉林省</asp:ListItem>
                                            <asp:ListItem Value="黑龙江">黑龙江省</asp:ListItem>
                                            <asp:ListItem Value="江苏">江苏省</asp:ListItem>
                                            <asp:ListItem Value="浙江">浙江省</asp:ListItem>
                                            <asp:ListItem Value="安徽">安徽省</asp:ListItem>
                                            <asp:ListItem Value="福建">福建省</asp:ListItem>
                                            <asp:ListItem Value="江西">江西省</asp:ListItem>
                                            <asp:ListItem Value="山东">山东省</asp:ListItem>
                                            <asp:ListItem Value="河南">河南省</asp:ListItem>
                                            <asp:ListItem Value="湖北">湖北省</asp:ListItem>
                                            <asp:ListItem Value="湖南">湖南省</asp:ListItem>
                                            <asp:ListItem Value="广东">广东省</asp:ListItem>
                                            <asp:ListItem Value="广西">广西壮族自治区</asp:ListItem>
                                            <asp:ListItem Value="海南">海南省</asp:ListItem>
                                            <asp:ListItem Value="贵州">贵州省</asp:ListItem>
                                            <asp:ListItem Value="四川">四川省</asp:ListItem>
                                            <asp:ListItem Value="西藏">西藏自治区</asp:ListItem>
                                            <asp:ListItem Value="陕西">陕西省</asp:ListItem>
                                            <asp:ListItem Value="甘肃">甘肃省</asp:ListItem>
                                            <asp:ListItem Value="宁夏">宁夏回族自治区</asp:ListItem>
                                            <asp:ListItem Value="青海">青海省</asp:ListItem>
                                            <asp:ListItem Value="新疆">新疆维吾尔自治区</asp:ListItem>
                                            <asp:ListItem Value="香港">香港特别行政区</asp:ListItem>
                                            <asp:ListItem Value="澳门">澳门特别行政区</asp:ListItem>
                                            <asp:ListItem Value="台湾">台湾省</asp:ListItem>
                                            <asp:ListItem Value="其它">其它</asp:ListItem>
                                        </asp:DropDownList></td>
                                        <td class="td_02">交易频率：<asp:DropDownList ID="ddl_pinlv" runat="server">
                                            <asp:ListItem Value="all">全部</asp:ListItem>
                                            <asp:ListItem Value="3">3个月未成交</asp:ListItem>
                                            <asp:ListItem Value="6">半年未成交</asp:ListItem>
                                            <asp:ListItem Value="12">1年未成交</asp:ListItem>
                                        </asp:DropDownList></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">交易时间：<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="tbx_trade_start" /></td>
                                        <td class="td_02">至&nbsp;<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="tbx_trade_end" /></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">交易额度：<asp:TextBox ID="tbx_money01" runat="server"></asp:TextBox></td>
                                        <td class="td_02">至&nbsp;<asp:TextBox ID="tbx_money02" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">宝宝件数：<asp:TextBox ID="tbx_buy_count01" runat="server"></asp:TextBox></td>
                                        <td class="td_02">至&nbsp;<asp:TextBox ID="tbx_buy_count02" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">过滤最近：<asp:DropDownList ID="ddl_day" runat="server">
                                            <asp:ListItem>1</asp:ListItem>
                                        </asp:DropDownList>天内发送过短信的买家</td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">购买次数：<asp:TextBox ID="tbx_buy_count" runat="server"></asp:TextBox>次的买家</td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">
                                            <asp:CheckBox ID="cbx_comment" runat="server" Text="过滤中差评买家" /></td>
                                        <td class="td_02">
                                            <asp:CheckBox ID="cbx_blacklist" runat="server" Text="过滤黑名单买家" /></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">
                                            <asp:Button ID="bt_seach" runat="server" Text="搜索" OnClick="bt_seach_Click" />
                                        </td>
                                    </tr>
                                </table>

                                <table class="tab_03">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_member" runat="server"></asp:GridView>

                                        </td>
                                    </tr>
                                </table>
                            </div>

                        </td>
                    </tr>
                </table>
            </div>
        </div>

    </form>
</body>
</html>
