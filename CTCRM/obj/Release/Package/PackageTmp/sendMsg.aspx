<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendMsg.aspx.cs" Inherits="CTCRM.sendMsg"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />
    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
    <script src="Js/jquery.min.js" type="text/javascript"></script>
    <script src="Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="Js/ajaxfileupload.js"></script>
    <script language="javascript" type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>
    <script src="Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        //统计字数
        function caulateSize() {
            var sig = $("#<%=HiddenField1.ClientID%>").val();
            var content = sig + $("#<%= txtmsgContent.ClientID%>").val() + " 退订回N";
            var infos = "短信字数：" + content.length + " 个" + "<br>短信预览：" + content;
            //alert(content.length);
            $.messager.alert('店铺管家', infos);
        }

        //发送测试短信
        function sendTestMsg() {
            var content = $("#<%= txtmsgContent.ClientID%>").val();
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
             "/handler/messageHandler.ashx",
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
                "/handler/messageHandler.ashx",
                "&command=getMsgCount",
                "text",
                function (result) {
                    $("#<%= lbMsgCanUseCount.ClientID%>").html(result);
                });
        }
    </script>
    <script type="text/javascript">
        function upload() {
            var msContent = $("#<%= txtmsgContent.ClientID%>").val();
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
                    url: '/handler/handlerMsg.ashx?msgContent=' + msContent,
                    type: 'post',
                    secureuri: false,
                    fileElementId: 'file1',
                    dataType: 'text',
                    success: function (data, status) {
                        if (data == "<pre>0</pre>") {
                            $.messager.alert('店铺管家', '请选择要群发的文件!', 'error');
                        }
                        if (data == "<pre>1</pre>") {
                            $.messager.alert('店铺管家', '只支持txt格式的文件!', 'error');
                        }
                        if (data == "<pre>3</pre>") {
                            $.messager.alert('店铺管家', '短信账户余额不足,请及时充值!', 'error');
                        }
                        if (data == "<pre>2</pre>") {
                            $.messager.alert('店铺管家', '短信发送成功！');
                        }
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
                "/handler/messageHandler.ashx",
                "&command=getMsgCount",
                "text",
                function (result) {
                    $("#<%= lbMsgCanUseCount.ClientID%>").html(result);
                });
            }
    </script>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="message.aspx">短信营销</a></li>
                    <li><a href="Smart/index.aspx">智能营销</a></li>
                    <li class="on"><a href="sendMsg.aspx">自有号码群发</a></li>
                    <li><a href="Smart/msgHis.aspx">发送记录</a></li>
                    <li><a href="shortLink.aspx">短链接生成</a></li>
                    <li><a href="signModify.aspx">修改签名</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4" style="margin-left: 10px">
                        <div class="smallTitle" style="height: 45px">
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
                                    <td align="center">
                                        <a href="Smart/msgHis.aspx">
                                            <img alt="" src="Images/sendHis.png" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="content">
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2">&nbsp;<asp:Label ID="Label3" runat="server" Font-Bold="true" Font-Size="15px" Text="短信内容："></asp:Label>
                                            <font color="red">【<strong>温馨提示:</strong>短信内容70个字以内算1条,超过70个字时每67个字一条】</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            选择短信内容模板： &nbsp;<a href="sms_template.aspx" target="_blank" style="color: #0000EE;">短信模版</a>&nbsp;&nbsp;<a
                                            href="shortLink.aspx" target="_blank" style="color: #0000EE;">缩短网址</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <table cellspacing="0" rules="all" border="0" id="Table3" style="border-collapse: collapse;">
                                                    <tr>
                                                        <td>
                                                            <img src="Images/sms_con.jpg" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtmsgContent" Width="406px" Font-Size="12px" runat="server" Height="82px" Text=""
                                                                TextMode="MultiLine" MaxLength="260"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">&nbsp;
                                                <input type="button" id="caculateSize" onclick="caulateSize();" value="短信预览&字数统计" />&nbsp; <font color="red">注意：发送测试短信时请输入正常的短信内容,不要随意输入比如：sfsdfsdf..等无效内容</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Label ID="Label4" runat="server" Font-Bold="true" Font-Size="15px" Text="批量导入手机号(*.txt)："></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <img src="Images/importFormart.jpg" />
                                                        </td>
                                                        <td valign="middle">
                                                            <font color="blue">导入格式如左侧所示(文件仅支持txt文本文件，多个号码请换行)</font><br />
                                                            导入已经准备好的电话号码文本文件：
                                                            <input type="file" id="file1" name="file" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnSend" runat="server" Text="立即发送" Width="118px" Height="29px" OnClientClick="upload();return false;" />&nbsp;<asp:Label ID="lbMsg" runat="server"
                                                                    Font-Bold="true" Font-Size="18px" Text="" ForeColor="Blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3" valign="middle">测试号码：<asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;
                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                    <img src="Images/sendtestmsg.jpg" /></a>
                                                            &nbsp;
                                <a href="messageSetting.aspx" id="lbOrderMsg2" style="visibility: hidden"><font font-size="18px">订购短信</font></a>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>
                </div>
                <div id="msgDiv" style="width: 380px; height: 13px; position: absolute; left: 360px; top: 170px; display: none; z-index: 9999;">
                    <h1>
                        <font color="white">短信发送中,请稍等........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 360px; top: 200px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>
