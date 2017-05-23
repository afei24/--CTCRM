<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendMsg.aspx.cs" Inherits="CTCRM.WIN_Aspx.sendMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <link href="../WIN_CSS/msg_div.css" rel="stylesheet" />
    <link href="../../WIN_CSS/msg_div.css" rel="stylesheet" />
    <script src="../Js/TBApply.js" charset="utf-8" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" charset="utf-8" type="text/javascript"></script>
    <script type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../Js/ajaxfileupload.js"></script>
    <link href="../CSS/easyui.css" rel="stylesheet" />
    <link href="../CSS/icon.css" rel="stylesheet" />
    <script src="../Js/common.js"></script>
    <script src="../win_js/member.js"></script>

    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" type="text/javascript"></script>
    <script src="../Js/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <style type="text/css">
        .msg_tb, .msg_tb td {
            border: none;
            background-color: white;
        }

            .msg_tb td {
                padding-left: 10px;
            }

        .td_right {
            text-align: left;
        }

        .auto-style1 {
            text-align: left;
            height: 22px;
        }
    </style>
    <script type="text/javascript">

        //统计字数
        function caulateSize() {
            var sig = $("#<%=HiddenField1.ClientID%>").val();
            var content = sig + $("#<%= txt_div_pay_msg.ClientID%>").val() + " 退订回N";
            var infos = "短信字数：" + content.length + " 个" + "<br>短信预览：" + content;
            //alert(content.length);
            $.messager.alert('店铺管家', infos);
        }

        //发送测试短信
        function sendTestMsg() {
            var content = $("#<%= txt_div_pay_msg.ClientID%>").val();
            var phoneNo = $("#<%= txtMyCellPhone.ClientID%>").val();
            if (phoneNo == '') {
                $.messager.alert('店铺管家', '测试手机号码不能为空!', 'error');
                return;
            }
            if (content == '') {
                $.messager.alert('店铺管家', '短信内容不能为空!', 'error');
                return;
            }
            if (content.indexOf("【") >= 0) {
                $.messager.alert('店铺管家', '短信内容里面不能包涵【】符号,请用()代替!', 'error');
                return;
            }
            $.messager.confirm("店铺管家", "温馨提示：为防止钓鱼,测试内容请输入亲正式要群发的内容，否则可能会被拦截哟", function (data) {
                if (data) {
                    $PostAjax(
                     "POST",
                     "../handler/messageHandler.ashx",
                     "&command=sendTestMsg&phone=" + phoneNo + "&content=" + content,
                     "text",
                     function (result) {
                         if (result == "发送成功") {
                             $.messager.alert('店铺管家', '短信发送成功！');
                         } else if (result == "余额不足") {
                             $.messager.alert('店铺管家', '短信账户余额不足!', 'error');
                             document.getElementById("lbOrderMsg2").style.visibility = "visible";
                         } else if (result == "手机号码格式不正确") {
                             $.messager.alert('店铺管家', '手机号码格式不正确！', 'error');
                         } else if (result == "发送阻塞") {
                             $.messager.alert('店铺管家', '亲~稍等，1分钟再来自测吧！', 'error');
                         }
                         else if (result == "6") {
                             $.messager.alert('店铺管家', '存在不文明词汇！');
                         }
                         getMsgCount();
                     });
                    return;
                }
                else {
                    return;
                }
            });
        }

        function getMsgCount() {
            $PostAjax(
                "POST",
                "../handler/messageHandler.ashx",
                "&command=getMsgCount",
                "text",
                function (result) {
                    $("#<%= lbMsgCanUseCount.ClientID%>").html(result);
                });
            }
    </script>
    <script type="text/javascript">
        function upload() {
            var msContent = $("#<%= txt_div_pay_msg.ClientID%>").val();
            if (msContent == '') {
                $.messager.alert('店铺管家', '短信内容不能为空!', 'error');
                return;
            }
            if (msContent.indexOf("【") >= 0) {
                $.messager.alert('店铺管家', '短信内容里面不能包涵【】符号,请用()代替!', 'error');
                return;
            }
            progress();
            $.ajaxFileUpload
            (
                {
                    url: '../handler/handlerMsg.ashx?msgContent=' + msContent,
                    type: 'post',
                    secureuri: false,
                    fileElementId: 'file1',
                    dataType: 'text',
                    success: function (data, status) {

                        if (data.indexOf('0') >= 0) {
                            $.messager.alert('店铺管家', '请选择要群发的文件!', 'error');
                        }
                        if (data.indexOf('1') >= 0) {
                            $.messager.alert('店铺管家', '只支持txt格式的文件!', 'error');
                        }
                        //if (data == "<pre style=\"word-wrap: break-word; white-space: pre-wrap;\">3</pre>") {
                        if (data.indexOf('3') >= 0) {
                            $.messager.alert('店铺管家', '短信账户余额不足,请及时充值!', 'error');
                        }
                        if (data.indexOf('2') >= 0) {
                            $.messager.alert('店铺管家', '短信发送成功！');
                        }
                        if (data.indexOf('4') >= 0) {
                            $.messager.alert('店铺管家', '写入数据库时失败！');
                        }
                        if (data.indexOf('5') >= 0) {
                            $.messager.alert('店铺管家', '手机号码不正确！');
                        }
                        if (data.indexOf('6') >= 0) {
                            $.messager.alert('店铺管家', '存在不文明词汇！');
                        }
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>0</pre>") {
                        //    $.messager.alert('店铺管家', '请选择要群发的文件!', 'error');
                        //}
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>1</pre>") {
                        //    $.messager.alert('店铺管家', '只支持txt格式的文件!', 'error');
                        //}
                        ////if (data == "<pre style=\"word-wrap: break-word; white-space: pre-wrap;\">3</pre>") {
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>3</pre>") {
                        //    $.messager.alert('店铺管家', '短信账户余额不足,请及时充值!', 'error');
                        //}
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>2</pre>") {
                        //    $.messager.alert('店铺管家', '短信发送成功！');
                        //}
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>4</pre>") {
                        //    $.messager.alert('店铺管家', '写入数据库时失败！');
                        //}
                        //if (data == "<pre style='word-wrap: break-word; white-space: pre-wrap;'>5</pre>") {
                        //    $.messager.alert('店铺管家', '手机号码不正确！');
                        //}
                        getMsgCount();
                        closeProgres();
                    },
                    error: function (data, status, e) {
                        alert(e);
                    }
                }
            );
        }

        function progress() {
            var win = $.messager.progress({
                title: '店铺管家',
                msg: '短信发送中......'
            });
        }

        function closeProgres() {
            setTimeout(function () {
                $.messager.progress('close');
            }, 1)
        }

        function getMsgCount() {
            $PostAjax(
                "POST",
                "../handler/messageHandler.ashx",
                "&command=getMsgCount",
                "text",
                function (result) {
                    $("#<%= lbMsgCanUseCount.ClientID%>").html(result);
                });
            }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="users" runat="server" />
        <div id="homewrap">
            <div class="homediv">
                <div class="righter">
                    <div class="pDiv2">
                        <div class="div_zhandian">
                            <span class="zhandian">短信营销 >>短信群发</span>
                        </div>
                        <div class="contt4" style="margin-left: 10px">
                            <div class="smallTitle" style="height: 30px;    padding-top: 10px; border: 1px solid #d4d4d4; border-radius: 5px; vertical-align:middle; background-color: white;">
                                <%--<asp:Image ID="Image1" ImageUrl="~/Win_Image/111.png" runat="server" /><asp:Image ID="imgMsgISCanUse" runat="server" />--%>
                                &nbsp;<asp:Label ID="Label1" Font-Size="16px" runat="server" Text="剩余短信：" ForeColor="#767676" Style="padding-top : 3px;"></asp:Label>&nbsp;<asp:Label ID="lbMsgCanUseCount" Font-Size="16px" runat="server" Text="" ForeColor="white" Style="padding-top: 3px; background-color: #00BFE9; border-radius: 5px;"></asp:Label>
                                &nbsp;<span style="padding-top: 3px;" > <a href="message.aspx?src=Smart/msgHis.aspx" target="_blank" style="color:#00BFE9;font-weight:bold;">
                                        查看发送记录</a></span>
                            </div>
                            <div class="content" style="border: 1px solid #d4d4d4; border-radius: 5px; margin-top: 10px;">
                                <table class="msg_tb">
                                    <tbody>
                                        <tr>
                                            <td style="width: 80%; vertical-align: top; border: none; background-color: white">

                                                <table style="margin-top: 10px; margin-bottom: 10px;">
                                                    <tbody>
                                                        <tr>
                                                            <td class="td_left"><strong>短信群发&nbsp;</strong>
                                                            </td>
                                                            <td class="td_right">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left" style="color: #00BFE9; text-align: right;">一条短信70个字符，最多可发260个字符将扣除4条短信！</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">短信内容：</td>
                                                            <td class="td_right">

                                                                <asp:TextBox ID="txt_div_pay_msg" Width="406px" Font-Size="12px" runat="server" Height="100px" Text=""
                                                                    onkeyup="CheckContentCount('div_pay_msg')" onpaste="CheckContentCount('div_pay_msg')"
                                                                    TextMode="MultiLine" MaxLength="260" Style=""></asp:TextBox>
                                                                <%-- <div style="font-size: small; height:20px; line-height:20px;">签名：<strong class="strong_userName" style="color: blue">【<%= userNick %>】</strong>，营销追加：<strong style="color: blue">退订回N</strong></div>
                                                                <div style="font-size: small; margin-top: 0px;height:20px; line-height:20px;">总计 <strong class="textCount" style="color: red">0</strong> 个文字计费 <strong style="color: red" class="cost">0</strong> 条短信，总共扣除 <strong style="color: red" class="allCost">0</strong> 条短信</div>--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left" style="color: #767676; text-align: right;">
                                                                <asp:Label ID="msgTip" runat="server" Style="color: #767676; text-align: right;" Text=""></asp:Label></td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td class="td_left" style="width: 110px;">短信统计：</td>
                                                            <td class="td_right" style="text-align:left;">
                                                                <input type="button" id="Button1" onclick="caulateSize();" style="border-style: none; border-color: inherit; border-width: medium; background-color: #00BFE9; color: white; width: 166px; height: 29px;" value="短信预览&字数统计" />
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">短信模板：</td>
                                                            <td class="td_right"><a href="javascript:return false;" class="msgTemp" title="1" style="color: #767676;">短信模版</a>&nbsp;&nbsp;
                                                                <a href="../shortLink.aspx" style="color: #767676;">缩短网址</a>

                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">导入手机号码：</td>
                                                            <td class="td_right">
                                                                <input type="file" id="file1" name="file" style="color: #0AC2EB;" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_right" style="color: #767676;">文件格式为.txt或淘宝导出文件.csv</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">
                                                                <asp:ImageButton ID="ImageButton1" ImageUrl="../Win_Image/立即发送.jpg" runat="server" OnClientClick="upload();return false;" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left"><strong>短信测试&nbsp;</strong></td>
                                                            <td class="td_right">
                                                                <asp:Label ID="lbMsg" runat="server"
                                                                    Font-Bold="true" Font-Size="18px" Text="" ForeColor="#0AC2EB"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left" style="width: 110px;">&nbsp</td>
                                                            <td class="td_left">&nbsp</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="slider-h">测试号码：</td>
                                                            <td class="auto-style1">
                                                                <asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                                                <a href="javascript:void(0)" onclick="sendTestMsg();">&nbsp;</a></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="td_left">&nbsp;</td>
                                                            <td class="td_right">
                                                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                                                    <img src="../Win_Image/sendtestmsg.jpg" /></a></td>
                                                        </tr>
                                                    </tbody>
                                                </table>

                                            </td>
                                            <td style="width: 30%; vertical-align: middle; border: none; background-color: white">
                                                <div style="margin-left: 100px; width: 219px; height: 280px; background-image: url('../../Win_Image/iphone.png'); background-repeat: no-repeat">
                                                    <div id="div_pay_msg" class="div_msg" style="padding-top: 50px; margin-bottom: 200px; width: 120px; margin-left: 18px; color: #333; font-family: microsoft yahei; font-size: 14px; white-space: normal; word-break: break-all; word-wrap: break-word;">
                                                    </div>

                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: left; width: 80%">
                                                <div class="" style="padding-left: 20px; height: 100px;">
                                                    <p style="color: #00BFE9; font-size: 12px; height: 100px;">
                                                        <font style="color: #00BFE9; font-size: 18px;">发送须知：</font>
                                                        <br />
                                                        <br />
                                                        <span>1.为避免打扰买家，短信的发送时间段为早上9点到晚上8点，如果给您带来不便，敬请谅解！</span>
                                                        <br />
                                                        <span>&nbsp;</span><br />
                                                        <span style="margin-top: 5px;">2.如果收不到短信请查看是否被手机软件拦截，是否停机，可以联系在线客服排查问题，谢谢您的使用！</span>
                                                    </p>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>


                            </div>
                        </div>
                    </div>

                    <div id="msgDiv" style="width: 380px; height: 13px; position: absolute; left: 360px; top: 170px; display: none; z-index: 9998;">
                        <h1>
                            <font color="#00BFE9">短信发送中,请稍等........</font></h1>
                    </div>
                    <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 360px; top: 200px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                    </div>
                    <script type="text/javascript">
                        document.getElementById("A7").className += ' NavSelected';
                    </script>
                </div>

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


    </form>
</body>
</html>
