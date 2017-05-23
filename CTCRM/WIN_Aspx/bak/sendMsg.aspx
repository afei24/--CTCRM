<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sendMsg.aspx.cs" Inherits="CTCRM.WIN_Aspx.sendMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <link href="../CSS/easyui.css" rel="stylesheet" />
    <link href="../CSS/icon.css" rel="stylesheet" />
    <script src="../Js/jquery.min.js" type="text/javascript"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/ajaxfileupload.js"></script>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <script src="../Js/easyui-lang-zh_CN.js"></script>
    <script src="../win_js/member.js"></script>
    <script language="javascript" type="text/javascript">
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
                        if (data == "<pre>0</pre>") {
                            $.messager.alert('店铺管家', '请选择要群发的文件!', 'error');
                        }
                        if (data == "<pre>1</pre>") {
                            $.messager.alert('店铺管家', '只支持txt格式的文件!', 'error');
                        }
                        //if (data == "<pre style=\"word-wrap: break-word; white-space: pre-wrap;\">3</pre>") {
                        if (data == "<pre>3</pre>") {
                            $.messager.alert('店铺管家', '短信账户余额不足,请及时充值!', 'error');
                        }
                        if (data == "<pre>2</pre>") {
                            $.messager.alert('店铺管家', '短信发送成功！');
                        }
                        if (data == "<pre>4</pre>") {
                            $.messager.alert('店铺管家', '写入数据库时失败！');
                        }
                        if (data == "<pre>5</pre>") {
                            $.messager.alert('店铺管家', '手机号码不正确！');
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
    <div id="homewrap">
        <div class="homediv">
            <div class="righter">
                <div class="pDiv2">
                    <div class="div_zhandian">
                        <span class="zhandian">短信营销 >>短信群发</span>
                    </div>
                    <div class="contt4" style="margin-left: 10px">
                        <div class="smallTitle" style="height: 45px;border: 1px solid #00BFE9;border-radius:5px;">
                            <ul>
                                <li><asp:Image ID="Image1" ImageUrl="~/Win_Image/111.png" runat="server" /></li><li><asp:Image ID="imgMsgISCanUse" runat="server" /></li>
                                <li><asp:Image ID="Image5" ImageUrl="~/Win_Image/021.png" runat="server" /></li><li><asp:Label ID="lbMsgCanUseCount" Font-Size="16px" runat="server" Text="" ForeColor="#767676"></asp:Label></li>
                                <li><a href="Smart/msgHis.aspx">
                                            <img alt="" src="../Win_Image/sendHis.png" /></a></li>
                                </ul>
                            <%--<table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
                                <tr>
                                    <td scope="col" style="width: 80px;">
                                        <asp:Image ID="Image3" ImageUrl="~/Win_Image/111.png" runat="server" />
                                    </td>
                                    <td style="width: 110px; vertical-align: middle">
                                        <asp:Image ID="imgMsgISCanUse" runat="server" />
                                    </td>
                                    <td scope="col" style="width: 80px;">
                                        <asp:Image ID="Image4" ImageUrl="~/Win_Image/021.png" runat="server" />
                                    </td>
                                    <td style="width: 154px; margin-top: 300px; vertical-align: middle" colspan="3">
                                        <asp:Label ID="lbMsgCanUseCount" Font-Size="16px" runat="server" Text="" ForeColor="red"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <a href="Smart/msgHis.aspx">
                                            <img alt="" src="../Win_Image/sendHis.png" />
                                    </td>
                                </tr>
                            </table>--%>
                        </div>
                        <div class="content" style="border:1px solid #00BFE9;border-radius:5px;margin-top:10px;">
                            <table style="border:none;background-color:white">
                                <tbody>
                                        <tr>
                                            <td colspan="2" style="border:none;background-color:white">&nbsp;<asp:Label ID="Label3" Style="margin-left:100px"  runat="server" Font-Bold="true" Font-Size="18px" ForeColor="#0AC2EB" Text="短信内容："></asp:Label>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="border:none;background-color:white;margin-left:100px">
                                                <div Style="margin-left:100px">
                                                    <table cellspacing="0" rules="all" border="0" id="Table3" style="border:none;background-color:white">
                                                        <tr>
                                                            <td style="width: 30%;border:none;background-color:white;vertical-align:top">
                                                                
                                                                <table>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="border:none;background-color:white;vertical-align:middle;">
                                                                                <asp:TextBox ID="txt_div_pay_msg" Width="406px" Font-Size="12px" runat="server" Height="100px" Text=""
                                                                                    onkeydown="CheckContentCount('div_pay_msg')" onkeyup="CheckContentCount('div_pay_msg')" onpaste="CheckContentCount('div_pay_msg')"
                                                                                    TextMode="MultiLine" MaxLength="260" Style="margin-left:20px;"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white;color:#0AC2EB">
                                                                                &nbsp;&nbsp;选择短信内容模板：&nbsp;&nbsp;<a href="../sms_template.aspx" target="_blank" style="color: #767676;">短信模版</a>&nbsp;&nbsp;<a
                                                                                href="../shortLink.aspx" target="_blank" style="color: #767676;">缩短网址</a>
                                                                            </td>
                                                                            </tr>
                                                                       
                                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">&nbsp;
                                                                                <input type="button" id="Button1" onclick="caulateSize();" style="border-style: none; border-color: inherit; border-width: medium; background-color:#00BFE9; color:white; width: 166px; height: 29px;" value="短信预览&字数统计" /></td>

                                                                            </tr>
                                                                         <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                                         <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                <div style="border:1px solid #00BFE9;border-radius:5px;margin-left:20px;">
                                                                                        <span style="color:#767676; font-weight:bold" >温馨提示:</span>
                                                                                        <span style="color:#767676;">短信内容70个字以内算1条,超过70个字时每67个字一条注意：发送测试短信时请输入正常的短信内容,不要随意输入比如：sfsdfsdf..等无效内容</span>
                                                                                    </div>
                                                                              </td>

                                                                          </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                            <td style="border:none;background-color:white">
                                                                    <div style="margin-left: 100px;width: 219px;height:280px; background-image:url('../../Win_Image/iphone.png');background-repeat:no-repeat">
                                                                        <div id="div_pay_msg" class="div_msg" style="padding-top:100px;margin-bottom: 200px;width: 170px;margin-left: 20px;color: #333;font-family: microsoft yahei;font-size: 14px;
                                                                            white-space: normal;word-break: break-all;word-wrap: break-word; ">
                                                                        </div>
                                                                    </div>
                                                            </td>
                                                        </tr>
<%--                                                        <tr>
                                                            <td colspan="2" style="border:none;background-color:white">
                                                                &nbsp;&nbsp;选择短信内容模板： &nbsp;<a href="../sms_template.aspx" target="_blank" style="color: #0000EE;">短信模版</a>&nbsp;&nbsp;<a
                                                                href="../shortLink.aspx" target="_blank" style="color: #0000EE;">缩短网址</a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td></td>
                                                            <td colspan="2" style="border:none;background-color:white">&nbsp;
                                                    <input type="button" id="caculateSize" onclick="caulateSize();" value="短信预览&字数统计" />&nbsp; <font color="red">注意：发送测试短信时请输入正常的短信内容,不要随意输入比如：sfsdfsdf..等无效内容</font>
                                                            </td>
                                                        </tr>--%>

                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                        <tr>
                                                            <td colspan="2" style="border-left:none;border-right:none;border-top:none;background-color:white">
                                                                <asp:Label ID="Label4" style="color:#0AC2EB;margin-left:15px;" runat="server" Font-Bold="true" Font-Size="20px" Text="批量导入手机号(*.txt或*.xlsx)："></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle" style="border:none;background-color:white">
                                                                <span  style="margin-left:15px;color:#00BFE9">上传文件：</span>
                                                                <input type="file" id="file1" name="file" style="color:#0AC2EB;"  />
                                                                
                                                                
                                                            </td>
                                                            <td style="border:none;background-color:white">
                                                                <span  style="margin-left:15px;color:#0AC2EB;">(提示：导入格式为一个号码一行)</span><br />
                                                            </td>
                                                            
                                                        </tr>
                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                        <tr>
                                                            <td colspan="2" style="border:none;background-color:white">
                                                                <asp:Button Style="margin-left:200px;" ID="btnSend" runat="server" Text="立即发送" Width="118px" Height="29px" OnClientClick="upload();return false;" BackColor="#0AC2EB" BorderColor="#0AC2EB" ForeColor="White" />&nbsp;<asp:Label ID="lbMsg" runat="server"
                                                                        Font-Bold="true" Font-Size="18px" Text="" ForeColor="#0AC2EB"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
                                                                            </tr>
                                                        <tr>
                                                            <td colspan="3" valign="middle" style="border:none;background-color:white;color:#767676;">&nbsp;测试号码：<asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;
                                                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                                                    <img src="../Win_Image/sendtestmsg.jpg" /></a>
                                                                                            &nbsp;
                                                                <a href="messageSetting.aspx" id="lbOrderMsg2" style="visibility: hidden"><font font-size="18px">订购短信</font></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                                            <td colspan="2" style="border:none;background-color:white">
                                                                                &nbsp; 
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
                        <font color="#00BFE9">短信发送中,请稍等........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 360px; top: 200px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
