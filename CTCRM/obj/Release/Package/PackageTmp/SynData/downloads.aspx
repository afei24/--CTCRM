<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Temp/Common.Master"
    CodeBehind="downloads.aspx.cs" Inherits="CTCRM.Download.download" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <script src="../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../wBox/wbox.css" rel="stylesheet" type="text/css" />
    <script src="../wBox/wbox.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../CSS/progress.css" rel="stylesheet" type="text/css" />
    <script src="../Js/progressbar.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <script type="text/javascript">
        var wpro = null;
        var ProFun = null;

        function closeProgress() {
            if (wpro != undefined) {
                clearInterval(ProFun);
                $("#spaceused1").progressBar(100);
                wpro.close();
            }
        }

        function showProgress(msg)                    //根据屏幕的大小显示两个层 
        {
            
            var content = "<div class=\"l_content\">" + msg + "<br /><span class='progressBar' id='spaceused1'>0%</span></div>";
            wpro = $(this).wBox({ opacity: 0.3, title: "系统消息", show: true, noTitle: true, parent: "#samain", html: content });
            $("#spaceused1").progressBar(0, { increment: 120 });
            ProFun = setInterval(progressbar, 1000);
        }

        function setProgress(per) {
            $("#spaceused1").progressBar(per);
        }

        $(document).ready(function () {
            CallServer("progress", "");
        });

        function sync_click() {
            CallServer("syncmember", "");
        }

        function progressbar() {
            CallServer("progress", "");
        }

        function ReceiveData(rValue) {
            if (rValue == undefined || rValue == null || rValue == "") return;
            var sarg = rValue.split(',');

            if (sarg[0] == "progress") {
                if (sarg[1] == "0") {
                    if (wpro != null) {
                        closeProgress();
                        __doPostBack("", "updatetime");
                    }
                }
                else {
                    if (wpro == null)
                        showProgress("正在同步会员资料，请耐心等待...");
                    else
                        setProgress(sarg[1]);
                }
            }
            else if (sarg[0] == "syncmember") {
                if (sarg[1] == "success")
                    showProgress("正在同步会员资料，请耐心等待...");
                else
                    msgbox("同步会员列表失败！");
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="samain">
        <div class="rightside" style="height: 100%">
            <div class="infoArea" style="height: 200px;" runat="server">
                <div class="smallTitle">
                    &nbsp;<img src="../Images/1fenliu.png" />默认获取最近3个月的客户数据
                </div>
                <div class="content">
                    <table>
                        <tbody>
                            <tr>
                                <td align="center">
                                    <a href="javascript:;" onclick="sync_click();">
                                        <img src="../Images/member.png" alt="" width="120px" height="30px" /></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                <%--<div class="smallTitle">
                    &nbsp;<img src="../Images/2fenliu.png" />同步店铺所有订单【<font color="red">淘宝官方API调用按读取次数收费，为了降低商家使用软件的成本，系统针对每个用户仅限同步一次！</font>】
                </div>
                <div class="smallTitle" style="vertical-align: middle; text-align: center">
                    <table>
                        <tbody>
                            <tr>
                                <td align="center">
                                    <asp:ImageButton ID="btnSynTrade" ImageUrl="~/Images/trade.png" runat="server" OnClientClick="dialog.DOpen(this)"
                                        OnClick="btnSynTrade_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>--%>
                <div class="smallTitle">
                    &nbsp;<img src="../Images/2fenliu.png" />导入历史订单
                </div>
                <div class="smallTitle" style="vertical-align: middle; text-align: center">
                    <table>
                        <tbody>
                            <tr>
                                <td align="center">
                                    <a href="findBuyerInfo.aspx">
                                        <img src="../Images/goto.png" /></a>
                                    <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />--%>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <table border="0" cellpadding="0" cellspacing="0" style="height: 60px;">
                <tr>
                    <td align="center">
                        <ul id="text">
                            <font color="blue" size="5px">&nbsp;同步信息：</font>&nbsp;<asp:Label Font-Size="20px"
                                ID="lbsynDate" ForeColor="Blue" runat="server" Text=""></asp:Label>
                        </ul>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
