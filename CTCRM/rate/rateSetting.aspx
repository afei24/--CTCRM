<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rateSetting.aspx.cs" Inherits="CTCRM.rate.rateSetting"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/css.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>
                    评价管理</h4>
                <ul class="items">
                    <li class="on"><a href="rateSetting.aspx">自动评价</a></li>
                    <li><a href="blacklist.aspx">黑名单</a></li>
                    <li><a href="badList.aspx">中差评查询</a></li>
                    <li><a href="ratingLog.aspx">评价日志</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        自动评价说明
                    </div>
                    <div class="contt4">
                        &nbsp;<img src="../images/light-bulb-on.png" width="16px" height="16px" />&nbsp;请先保存评价设置，再开启自动评价【天猫商家不支持自动评价】.<br />
                        &nbsp;<img src="../images/light-bulb-on.png" width="16px" height="16px" />&nbsp;交易完成是指买家确认收货(支付宝确认付款)，评价有效期为交易完成后15天内.<br />
                        &nbsp;<img src="../images/light-bulb-on.png" width="16px" height="16px" />&nbsp;系统如果发现买家给的是中差评，会自动加入黑名单。黑名单上限10000个，超出10000个的，最早加入的会被删除.<br />
                        &nbsp;<img src="../images/light-bulb-on.png" width="16px" height="16px" />&nbsp;黑名单指的是本系统的黑名单，与旺旺黑名单无关，因淘宝未放开接口，系统无法读取到旺旺的黑名单.
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                        自动评价开关
                    </div>
                    <div class="contt4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td valign="middle">
                                    &nbsp;<asp:ImageButton ID="imgBtnOpenRatingAtuo" runat="server" Width="95px" Height="33px"
                                        ImageUrl="~/Images/1close.png" OnClick="imgBtnOpenRatingAtuo_Click" />&nbsp;<asp:Label ID="Label2" Font-Size="16px" Font-Bold="true" runat="server" ForeColor="Red"
                                        Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                        自动评价设置（方案一次只能开通一种）
                    </div>
                    <div class="contt4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;<font color="red">评价方案一：</font><asp:RadioButton ID="rdoMiaoPing" Checked="true"
                                        CssClass="ui-widget-content ui-corner-all" Text="交易完成立即评价【秒评】" GroupName="kim"
                                        runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;<font color="red">评价方案二：</font><asp:RadioButton ID="rdoBuyerRated" Text="买家评价以后评价"
                                        CssClass="ui-widget-content ui-corner-all" runat="server" GroupName="kim" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;1：如果买家一直未评价,系统在交易完成后&nbsp;<asp:DropDownList ID="drpFangAn2Day" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn2Hour" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn2Minute" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;分钟自动评价【抢评】【<font color="red">都为 0 时不会评价</font>】
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;2：如果黑名单买家已评：<asp:RadioButton ID="rdoFangAn2NotAtuo" Text="不自动评价" Checked="true"
                                        GroupName="11" runat="server" CssClass="ui-widget-content ui-corner-all" />&nbsp;<asp:RadioButton
                                            ID="rdoFangAn2AtuoGoodRate" Text="自动好评" GroupName="11" runat="server" CssClass="ui-widget-content ui-corner-all" />&nbsp;<asp:RadioButton
                                                ID="rdoFangAn2AtuoNureRate" GroupName="11" CssClass="ui-widget-content ui-corner-all"
                                                Text="自动中评" runat="server" />&nbsp;<asp:RadioButton ID="rdoFangAn2AtuoPoolRate" GroupName="11"
                                                    CssClass="ui-widget-content ui-corner-all" Text="自动差评" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;<asp:Label ID="Label1" runat="server" Text="如果要给已评价的黑名单买家中差评,请输入中差评内容(请勿输入过激语言，淘宝有验证，否则无法评价成功）"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;<asp:TextBox ID="txtPoolRateContent" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                        TextMode="MultiLine" Width="550px" Height="30px" Text="亲不要随意给我们差评，谢谢！" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;3：如果黑名单买家一直未评价,系统在交易完成后&nbsp;<asp:DropDownList ID="drpFangAn2BacklstDay" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn2BacklstHour" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn2BacklstMinute" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;分钟自动评价【抢评】【<font color="red">都为 0 时不会评价</font>】
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">
                                    &nbsp;<font color="red">评价方案三：</font><asp:RadioButton ID="rdoAutoRate" Text="总是在交易完成后"
                                        CssClass="ui-widget-content ui-corner-all" runat="server" GroupName="kim" />&nbsp;<asp:DropDownList
                                            ID="drpFangAn3Day" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                        </asp:DropDownList>
                                    &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn3Hour" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                        <asp:ListItem>4</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>6</asp:ListItem>
                                        <asp:ListItem>7</asp:ListItem>
                                        <asp:ListItem>8</asp:ListItem>
                                        <asp:ListItem>9</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>11</asp:ListItem>
                                        <asp:ListItem>12</asp:ListItem>
                                        <asp:ListItem>13</asp:ListItem>
                                        <asp:ListItem>14</asp:ListItem>
                                        <asp:ListItem>15</asp:ListItem>
                                        <asp:ListItem>16</asp:ListItem>
                                        <asp:ListItem>17</asp:ListItem>
                                        <asp:ListItem>18</asp:ListItem>
                                        <asp:ListItem>19</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                        <asp:ListItem>21</asp:ListItem>
                                        <asp:ListItem>22</asp:ListItem>
                                        <asp:ListItem>23</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn3Minute" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>30</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;分钟自动评价【<font color="red">都为 0 时不会评价</font>】
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                        中差评设置
                    </div>
                    <div class="contt4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    &nbsp;<asp:CheckBox ID="cbBlakList" Text="自动把给我中差评的买家加入黑名单" runat="server" CssClass="ui-widget-content ui-corner-all" />
                                    &nbsp;<asp:CheckBox ID="cbAddBlacklstTuikuan" Text="把半年内有退款申请的买家加入黑名单" runat="server"
                                        CssClass="ui-widget-content ui-corner-all" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                        评价内容设置 &nbsp;<span class="span3">亲~评价内容不能包含网址哟！否则批量评价会失败！</span>
                    </div>
                    <div class="contt4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="width: 80px">
                                    &nbsp;
                                </td>
                                <td colspan="3" align="left">
                                    <asp:DropDownList ID="drpContentChoice" runat="server" Height="25px" Width="223px">
                                        <asp:ListItem Value="0">随机使用以下一条作为评价内容</asp:ListItem>
                                        <asp:ListItem Value="1">使用模板1作为评价内容</asp:ListItem>
                                        <asp:ListItem Value="2">使用模板2作为评价内容</asp:ListItem>
                                        <asp:ListItem Value="3">使用模板3作为评价内容</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;评价模板1：
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRateTemp1" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                        TextMode="MultiLine" Width="550px" Height="30px" Text="有您的支持我们会做得更好，欢迎您的再次光临！"
                                        runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;评价模板2：
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRateTemp2" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                        TextMode="MultiLine" Width="550px" Height="30px" runat="server" Text="亲们要收藏下我们店铺哟，谢谢您对我们的支持！"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;评价模板3：
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtRateTemp3" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                        TextMode="MultiLine" Width="550px" Height="30px" runat="server" Text="尊敬的朋友，感谢您选购我们的商品以及长期对我们的支持！祝您购物愉快！(*^__^*) 嘻嘻！！"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="3">
                                    <asp:ImageButton ID="btnSaveRateConfig" runat="server" ImageUrl="~/Images/save.jpg"
                                        Width="80px" Height="25px" OnClick="btnSaveRateConfig_Click" />
                                    <asp:Label ID="lberror2" Font-Size="16px" Font-Bold="true" runat="server" ForeColor="Red"
                                        Text=""></asp:Label>&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 80px">
                                </td>
                                <td colspan="3">
                                    &nbsp;说明：修改后要点【保存评价设置】。
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 490px;
                    top: 520px; display: none; z-index: 9999;">
                    <h1>
                        <font color="white">系统评价中........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../images/msgSend.gif'); width: 280px;
                    height: 13px; position: absolute; left: 490px; top: 540px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif);
                    z-index: 9999;">
                </div>
                 <script type="text/javascript">
                     document.getElementById("A2").className += ' NavSelected';
                 </script> 
            </div>
        </div>
    </div>
</asp:Content>
