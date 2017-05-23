<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unpay.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.Smart.unpay" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <script src="../Js/jquery.js" type="text/javascript"></script>
    <script src="../Js/TBApply.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <base target="_self" />
    <link href="../CSS/easyui.css" rel="stylesheet" />
    <script src="../Js/jquery.min.js"></script>
    <script src="../Js/jquery.easyui.min.js"></script>
    <script src="../Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('#dlg').dialog({ autoOpen: false });
        });

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
            if (content.length >= 260) {
                $.messager.alert('店铺管家', '短信内容字数不能超过260个字!', 'error');
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
                    $("#<%= lbMsgCount.ClientID%>").html(result);
                });
            }

            function setType(e) {
                $("#<%= hidLabId.ClientID%>").val(e);
            }

            function sendMsg() {
                var content = $("#<%= txtmsgContent.ClientID%>").val();
                if (content == '') {
                    $.messager.alert('店铺管家', '短信内容不能为空!', 'error');
                    return;
                }
                if (content.length >= 260) {
                    $.messager.alert('店铺管家', '短信内容字数不能超过260个字!', 'error');
                    return;
                }
                if (content.indexOf("【") >= 0) {
                    $.messager.alert('店铺管家', '短信内容里面不能包涵【】符号,请用()代替!', 'error');
                    return;
                }
                //获取发送类型
                var sendType = $("#<%= hidLabId.ClientID%>").val();
                      var sig = $("#<%=HiddenField1.ClientID%>").val();
                var content2 = sig + content + " 退订N";
                var infos = "短信字数：" + content2.length + " 个" + "<br>短信预览：" + content2;
                $.messager.confirm("店铺管家", infos, function (data) {
                    if (data) {
                        progress();
                        $PostAjax(
                         "POST",
                         "/handler/messageHandler.ashx",
                         "&command=sendSmartMsg&content=" + content + "&sendType=" + sendType,
                         "text",
                         function (result) {
                             if (result == "发送成功") {
                                 $.messager.alert('店铺管家', '短信发送成功！');
                             } else if (result == "余额不足") {
                                 $.messager.alert('店铺管家', '余额不足!', 'error');
                             } else if (result == "没有会员") {
                                 $.messager.alert('店铺管家', '该分类下没有要发送短信的会员！', 'error');
                             }
                             closeProgres();
                             getMsgCount();
                         });
                        return;
                    }
                    else {
                        return;
                    }
                });
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
    </script> 
    
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="index.aspx">新会员营销</a></li>
                    <li ><a href="memberLevel.aspx">会员等级营销</a></li>
                    <li><a href="huoyue.aspx">活跃会员营销</a></li>
                    <li><a href="jieri.aspx">节日营销</a></li>
                    <li class="on"><a href="unpay.aspx">未交易营销</a></li>
                    <li><a href="area.aspx">地区营销</a></li>
                </ul>
            </div>
            <div class="righter">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hidLabId" runat="server" />
                <div class="infoArea" runat="server" id="msgAcountCheck">
                    <div class="ui-state-error ui-corner-all" style="width: 100%; text-align: center; font-size: 18px; font-weight: bold; vertical-align: middle">
                        <asp:Label ID="lbMsgTip" runat="server" Text="亲，您还未开通短信账户或者账户余额不足，现在就去？"></asp:Label><a
                            href="../messageSetting.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buy.png" /></a>
                    </div>
                </div>

                <div class="pDiv2">
                     <div class="title2">
                        未交易客户营销
                    </div>
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 70%">
                                        <asp:Label ID="Label48" runat="server" Text="下单未交易成功的会员" Font-Bold="true" Font-Size="11pt"
                                            ForeColor="#E17009"></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%">
                                        <asp:Label ID="Label49" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="10pt"
                                            ForeColor="#E17009"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">这类会员有购买需求，但因为种种原因没有成功完成交易时非常值得挽回的。建议对此类会员进行适度刺激和关怀，以促使达成交易。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../Images/xingxiang2.png" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="btnimgunpay" runat="server" ImageUrl="~/Images/getUser.png" OnClientClick="dialog.DOpen(this);"
                                            OnClick="btnimgunpay_Click" /><asp:Label ID="lbunpay" Font-Bold="true" Font-Size="16px"
                                                runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('unpay')"><img src="../Images/msgSend1.png" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">
                                        <asp:Label ID="Label50" runat="server" Text="下单7天内还未付款的会员" Font-Bold="true" Font-Size="11pt"
                                            ForeColor="#E17009"></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%">
                                        <asp:Label ID="Label51" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="10pt"
                                            ForeColor="#E17009"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">下单未付款，此时需要及时提醒会员买家完成付款操作以避免因为遗忘而导致交易失败。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../Images/xingxiang2.png" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="imgbtnunpay7days" runat="server" ImageUrl="~/Images/getUser.png" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgbtnunpay7days_Click" /><asp:Label ID="lbunpay7days" Font-Bold="true"
                                                Font-Size="16px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                         <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('unpay7days')"><img src="../Images/msgSend1.png" /></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                     <div id="dlg" class="easyui-dialog" closed="true" title="智能营销 -> 未交易客户营销" style="width: 600px; height: 300px; padding: 10px" data-options=" iconCls: 'icon-save',toolbar: '#dlg-toolbar',buttons: '#dlg-buttons'">
		                <div style="clear: both">
                            <table>
                                <tr>
                                    <td style="width: 100px;" colspan="3">
                                        <asp:Label ID="lbMsgCount" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div class="ui-state-error ui-corner-all" style="width: 390px;">
                                            <strong>&nbsp;&nbsp;温馨提示:</strong> 短信内容70个字以内算1条,超过70个字时每67个字一条.
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 150px;">
                                        <textarea cols="50" rows="10" runat="server" style="width: 420px; height:60px; font-size: 10pt"
                                            class="ui-widget-content ui-corner-all"
                                            id="txtmsgContent" name="txtmsgContent"></textarea>
                                    </td>  
                                    <td style="width: 130px;text-align:center;">
                                        <input type="button" id="caculateSize" style="height:50px" onclick="caulateSize();" value="短信预览&字数统计" />
                                    </td>                                 
                                </tr>
                                <tr>
                                    <td colspan="2">
                                         <a href="javascript:void(0)" onclick="sendMsg();">
                                            <img src="../Images/msgsend.jpg" /></a>&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="18px" ForeColor="Red"
                                    Text=""></asp:Label>&nbsp;<a href="~/messageSetting.aspx" id="A1" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="middle">测试号码：<asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;
                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                    <img src="../Images/sendtestmsg.jpg" /></a>
                                        &nbsp;
                                <a href="../messageSetting.aspx" id="lbOrderMsg2" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>
                                    </td>
                                </tr>
                            </table>
                        </div>
	                </div>
                    <div id="dlg-buttons" style="text-align: center">
		                <a href="javascript:void(0)" class="easyui-linkbutton" onclick="javascript:$('#dlg').dialog('close')">关闭</a>
                    </div>
                </div>

                <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 250px; top: 120px; display: none; z-index: 9999;">
                        <h1><font color="white">会员数据筛选中........</font></h1>
                </div>

                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 250px; top: 150px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;"></div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>