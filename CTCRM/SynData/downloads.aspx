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
    <%--<script src="../wBox/wbox.js" type="text/javascript"></script>--%>
    <script src="../win_js/downloads.js" type="text/javascript"></script>
    <script src="../Js/common.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <link href="../CSS/progress.css" rel="stylesheet" type="text/css" />
    <script src="../Js/progressbar.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <%--<script type="text/javascript">
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
    </script>--%>
    <style type="text/css">
        table,table td
        {
            border:none;
            width:100%;
        }
        td
        {
            background-color: white;
        }
        </style>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<div id="homewrap">
        <div class="homediv">
            <div class="righter">
                <div class="pDiv2">
                    <div class="div_zhandian">
                        <span class="zhandian">客户管理 >> 数据同步</span>
                    </div>
                    <div class="contt4">
                        <div class="div_tishi" style="border:solid 1px #00BFE9">
                            <p >温馨提示：</p><p style="font-weight:bold;color:#00BFE9">1.您还有<asp:Label ID="LabelNoNum" runat="server" Text="0"></asp:Label>位客户没有手机号，请按以下步骤导入。</p>
                            <p style="font-weight:bold;color:#00BFE9">2.导入时请耐心等待，不要跳转到别的页面。</p>
                            <p >3.因为淘宝接口只支持获取近三个月订单，如果要向更多的客户发送短信，需要手动导入当前店铺三个月前的订单数据。</p>
                            <p ">4.导入时系统会自动过滤 重复客户，故不会产生客户重复的现象。</p>
                            <p >5.在淘宝处理完成后，一定要点击后面的“下载订单报表”。</p>
                            <p >6.最大可上传文件大小为20M，超过20M请在淘宝导出的时候分时间段导出！</p><br />
                        </div>
                    <div id="Div1">
                             <div class="rightside" style="height: 100%">
                                <div id="Div2" class="infoArea" style="height: 200px;" runat="server">
                        
                <div class="content">
                    <table class="down_table">
                        <tbody class="syn">
                            <tr>
                                <td align="center" style="width:50%;padding-right:20px;background-color: white;" valign="top">
                                    <div class="smallTitle">
                                        第一步：从淘宝下载历史订单
                                    </div>
                                    <div style="border:1px solid #F5F5F5;border-bottom:none;padding-top:10px;">
                                        <a style="color:#00BFE9" target="_blank"  href="http://tradearchive.taobao.com/trade/itemlist/list_export_order.htm"><img src="../Win_Image/下载.png" /></a>
                                        </div>
                                    <div style="height: 44px; padding-top:10px;background-color:white;border:1px solid #F5F5F5;border-top:none;">
                                         <span>点击此处直接进入淘宝下载历史订单</span>
                                        </div>
                                </td>
                                <td align="center" valign="top" style="padding-right:0;background-color:white;">
                                    <div class="smallTitle">
                                    第二步：将导出的订单上传到软件里
                                </div>
                                    <div style="height: 114px; padding-top:20px;background-color:white;border:1px solid #F5F5F5;">
                                        <p style="font-weight:bold;color:#00BFE9">导入时请耐心等待，不要跳转到别的页面。</p>
                                        <p style="padding-left:20px;">订单报表CSV文件：
                                    <asp:FileUpload ID="fileOrderUpload" runat="server" /></p>
                                    <%--<a href="findBuyerInfo.aspx">
                                        <img src="../Win_Image/goto.png" /></a>--%>
                                    <br />
                                    <p><asp:ImageButton
                                            ID="ImageButton1" runat="server" ImageUrl="~/Images/import.png" OnClick="imgImportData_Click" 
                                            />&nbsp;<asp:Label ID="lbError" Font-Size="14pt" runat="server" ForeColor="#00BFE9" Text=""></asp:Label></p>
                                        </div>
                                </td>
                            </tr>
                            <%--<tr>
                                <td align="center" style="background-color:white;height:200px;width:40%;">
                                    <span><a style="color:#00BFE9" target="_blank"  href="http://tradearchive.taobao.com/trade/itemlist/list_export_order.htm">点击此处直接进入淘宝下载历史订单</a></span><br />
                                    <br />
                                </td>
                                <td align="center" style="background-color:white;height:200px;width:40%;">
                                    <p style="padding-left:20px;">订单报表CSV文件：
                                    <asp:FileUpload ID="fileOrderUpload" runat="server" /></p>
                                    <br />
                                    <p><asp:ImageButton
                                            ID="imgImportData" runat="server" ImageUrl="~/Images/import.jpg" OnClick="imgImportData_Click" 
                                            />&nbsp;<asp:Label ID="lbError" Font-Size="14pt" runat="server" ForeColor="#00BFE9" Text=""></asp:Label></p>
                                </td>
                            </tr>--%>
                        </tbody>
                    </table>
                </div>
            </div>
                                <table border="0" cellpadding="0" cellspacing="0" style="height: 60px;">
                                    <tr>
                                        <td align="center">
                                            <ul id="Ul1">
                                                <font color="#C6C6C6" size="5px">&nbsp;同步信息：</font>&nbsp;<asp:Label Font-Size="20px"
                                                    ID="lbsynDate" ForeColor="#C6C6C6" runat="server" Text=""></asp:Label>
                                            </ul>
                                        </td>
                                    </tr>
                                </table>
                        </div>
                    </div>  
                        </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
