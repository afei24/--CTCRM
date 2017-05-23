<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="retureGoods.aspx.cs" Inherits="CTCRM.member.retureGoods"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
               <h4>订单中心</h4>
                <ul class="items">
                    <li><a href="index.aspx">会员关怀</a></li>
                    <li class="on"><a href="retureGoods.aspx">退货处理</a></li>
                     <li><a href="reminderHis.aspx">提醒记录</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4">
                        <div class="infoArea" runat="server" id="msgAcountCheck">
                            <div class="ui-state-error ui-corner-all" style="width: 100%; text-align: center; font-size: 18px; font-weight: bold; vertical-align: middle">
                                <asp:Label ID="lbMsgTip" runat="server" Text="亲，您还未开通短信账户或者账户余额不足，现在就去？"></asp:Label><a
                                    href="../messageSetting.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buy.png" /></a>
                            </div>
                        </div>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="3" style="font-size: 13px; color: Red; font-weight: bold">提示：官方已发布售后服务综合指标,退货速度会计入服务能力,会直接影响搜索排名,如果速度快就会比同行高,对搜索有很大影响！
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                        <asp:Label ID="Label2" runat="server" Text="手动退货提醒" Font-Bold="true" Font-Size="12pt"
                            ForeColor="#E17009"></asp:Label>【<font style="color: Blue">买家申请退货,卖家同意后卖家手动发送短信提醒让买家填写退货信息</font>】
                    </div>
                    <div class="contt4">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td align="left" style="width: 90px">
                                    <asp:Label ID="Label3" runat="server" Text="买家手机号码："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCellPhone" Width="100px" CssClass="ui-widget-content ui-corner-all"
                                        runat="server"></asp:TextBox>&nbsp;<asp:Label ID="lbMsg2" ForeColor="Red" Font-Bold="true"
                                            Font-Size="18px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">设置提醒内容：
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left">
                                    <asp:TextBox ID="txtByHandContent" runat="server" CssClass="ui-widget-content ui-corner-all"
                                        TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>&nbsp;<asp:Label
                                            ID="lbMsg" ForeColor="Red" Font-Bold="true" Font-Size="18px" runat="server" Text=""></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" style="vertical-align: middle" colspan="3">
                                    <asp:ImageButton ID="btnByhand" ImageUrl="~/Images/byhand.jpg" runat="server" OnClick="btnByhand_Click" />&nbsp;<asp:Label ID="lbmsg5" runat="server"
                                        ForeColor="Blue" Font-Bold="true" Font-Size="Large" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            document.getElementById("A5").className += ' NavSelected';
        </script>
    </div>
</asp:Content>
