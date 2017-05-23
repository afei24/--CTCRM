<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="area.aspx.cs" Inherits="CTCRM.WIN_Aspx.Smart.area" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" />
    <link href="../../CSS/css.css" rel="stylesheet" />
    <script src="../../Js/jquery.js" type="text/javascript"></script>
    <script src="../../Js/TBApply.js" type="text/javascript"></script>
    <script src="../../Js/DialogMsg.js" type="text/javascript"></script>
    <base target="_self" />
    <link href="../../CSS/easyui.css" rel="stylesheet" />
    <script src="../../Js/jquery.min.js"></script>
    <script src="../../Js/jquery.easyui.min.js"></script>
    <script src="../../Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        $(function () {
            $('#dlg').dialog({ autoOpen: false });
            $('#ButtonAll').click(function () {
                $("[type = checkbox]:input").attr("Checked", true);
                return false;
            });
            $('#ButtonNull').click(function () {
                $("[type = checkbox]:input").attr("Checked", false);
                return false;
            }); 
            $('#ButtonCancle').click(function () {
                $('#choseProvince').dialog('close');
                //$('#choseProvince').hide();
                //return false;
            });
            
            $('#ImageButtonChonse').click(function () {
                $('#choseProvince').show();
            });
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
                   "../../handler/messageHandler.ashx",
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
                "../../handler/messageHandler.ashx",
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
                var pro = "<%=provinces%>";
                $.messager.confirm("店铺管家", infos, function (data) {
                    if (data) {
                        progress();
                        $PostAjax(
                         "POST",
                         "../../handler/messageHandler.ashx",
                         "&command=sendSmartMsg&content=" + content + "&sendType=" + sendType+"&provinces="+ pro,
                         "text",
                         function (result) {
                             if (result == "发送成功") {
                                 $.messager.alert('店铺管家', '短信发送成功！');
                             } else if (result == "余额不足") {
                                 $.messager.alert('店铺管家', '余额不足!', 'error');
                             } else if (result == "没有会员") {
                                 $.messager.alert('店铺管家', '该分类下没有要发送短信的会员！', 'error');
                             }
                             getMsgCount();
                         });
                        closeProgres();
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
</head>
<body>
    <form id="form1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="index.aspx">新会员营销</a></li>
                    <li><a href="memberLevel.aspx">会员等级营销</a></li>
                    <li><a href="huoyue.aspx">活跃会员营销</a></li>
                    <li><a href="jieri.aspx">节日营销</a></li>
                    <li><a href="unpay.aspx">未交易营销</a></li>
                    <li class="on"><a href="area.aspx">地区营销</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hidLabId" runat="server" />

             <div class="pDiv2 yingxiao_pDiv2">
                 <div class="div_yingxiao">
                        <span class="yingxiao">
                            地区营销</span>
                    </div>
                    <div class="contt4 yingxiao_contt4">
                        <table class="ind_tb">
                            <tbody>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label53" runat="server" Text="北方地区" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label54" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">根据不同地域会员的不同消费习惯开展针对性的营销活动，以提升不同地域会员的黏粘性和忠诚度，从而提高销售收入。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/四星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="btnimgBaiFang" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="btnimgBaiFang_Click" /><asp:Label ID="lbBaiFang" Font-Bold="true" Font-Size="16px"
                                                runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('baifang')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label55" runat="server" Text="南方地区" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label56" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">根据不同地域会员的不同消费习惯开展针对性的营销活动，以提升不同地域会员的黏粘性和忠诚度，从而提高销售收入。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/三星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="imgbtnNanfang" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgbtnNanfang_Click" /><asp:Label ID="lbNanfang" Font-Bold="true" Font-Size="16px"
                                                runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('nanfang')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label2" runat="server" Text="选择省份" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label3" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">根据具体省份的不同消费习惯开展针对性的营销活动，以提升不同地域会员的黏粘性和忠诚度，从而提高销售收入。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/四星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <a id="ImageButtonChonse"  
                                             ><img src="../../Win_Image/选择省份.jpg" /></a><asp:Label ID="lbShengfen" Font-Bold="true" Font-Size="16px"
                                                runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('province')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                 <div id="choseProvince"  closed="true" title="智能营销 -> 选择省份" style="display:none; width: 900px; height: 300px; padding: 10px" data-options=" iconCls: 'icon-save',toolbar: '#dlg-toolbar',buttons: '#dlg-buttons'" >
                    <table class="tb_chose">
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxBeijing" name="chkItem"  runat="server" Text="北京" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxtTianjin" name="chkItem" runat="server" Text="天津" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxHebei" name="chkItem" runat="server" Text="河北" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxShanxi" name="chkItem" runat="server" Text="山西" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxNei" name="chkItem" runat="server" Text="内蒙古" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxLiao" name="chkItem" runat="server" Text="辽宁" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxJi" name="chkItem" runat="server" Text="吉林" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxHei" name="chkItem" runat="server" Text="黑龙江" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxShanghai" name="chkItem" runat="server" Text="上海" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxJiangsu" name="chkItem" runat="server" Text="江苏" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxZhejiang" name="chkItem" runat="server" Text="浙江" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxAnhui" name="chkItem" runat="server" Text="安徽" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxFujian" name="chkItem" runat="server" Text="福建" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxJiangxi" name="chkItem" runat="server" Text="江西" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxShandong" name="chkItem" runat="server" Text="山东" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxHenan" name="chkItem" runat="server" Text="河南" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxHubei" name="chkItem" runat="server" Text="湖北" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxHunan" name="chkItem" runat="server" Text="湖南" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxGuangdong" name="chkItem" runat="server" Text="广东" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxGuangxi" name="chkItem" runat="server" Text="广西" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxHainan" name="chkItem" runat="server" Text="海南" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxChongqing" name="chkItem" runat="server" Text="重庆" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxSichuang" name="chkItem" runat="server" Text="四川" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxGuizhou" name="chkItem" runat="server" Text="贵州" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxYunnan" name="chkItem" runat="server" Text="云南" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxXizang" name="chkItem" runat="server" Text="西藏" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxXi" name="chkItem" runat="server" Text="陕西" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxGansu" name="chkItem" runat="server" Text="甘肃" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxQinghai" name="chkItem" runat="server" Text="青海" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxNingxia" name="chkItem" runat="server" Text="宁夏" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxXinjiang" name="chkItem" runat="server" Text="新疆" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxTaiwan" name="chkItem" runat ="server" Text="台湾" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CheckBoxXianggang" name="chkItem" runat="server" Text="香港" />
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxAomen" name="chkItem" runat="server" Text="澳门" />
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                            </td>
                            <td>
                                
                                
                            </td>
                            </tr>
                    </table> 
                     <div style="border-style: none; border-color: inherit; border-width: medium; text-align:right; width: 864px;">
                         <asp:Button ID="ButtonAll" runat="server" Text="全选" /> &nbsp;&nbsp;<asp:Button ID="ButtonNull" runat="server" Text="全清" /> &nbsp;&nbsp;
                     <asp:Button ID="ButtonOk" runat="server" Text="确定" OnClick="ButtonOk_Click" /> &nbsp;&nbsp;<asp:Button ID="ButtonCancle" runat="server" Text="关闭" OnClick="ButtonCancle_Click" />   
                         </div>
                 </div>
                 <div id="dlg" class="easyui-dialog" closed="true" title="智能营销 -> 地区营销" style="width: 600px; height: 300px; padding: 10px" data-options=" iconCls: 'icon-save',toolbar: '#dlg-toolbar',buttons: '#dlg-buttons'">
		                <div style="clear: both">
                            <table>
                                <tr>
                                    <td style="width: 100px;" colspan="3">
                                        <asp:Label ID="lbMsgCount" runat="server" ForeColor="#00BFE9" Text=""></asp:Label>
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
                                            <img src="../../Win_Image/msgsend.jpg" /></a>&nbsp;<asp:Label ID="Label1" runat="server" Font-Size="18px" ForeColor="#00BFE9"
                                    Text=""></asp:Label>&nbsp;<a href="../messageSetting.aspx" id="A1" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" valign="middle">测试号码：<asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;
                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                    <img src="../../Win_Image/sendtestmsg.jpg" /></a>
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

                <div id="zhedang" style="background-image: url('../../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 250px; top: 150px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;"></div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
