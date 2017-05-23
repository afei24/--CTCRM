<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Temp/Common.Master"
    MaintainScrollPositionOnPostback="true" CodeBehind="message.aspx.cs" Inherits="CTCRM.message" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">

    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />

    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script src="Js/DialogMsg.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>

    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />

    <script src="Js/jquery.min.js" type="text/javascript"></script>
    <script src="Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" type="text/javascript"></script>
    <script src="Js/easyui-lang-zh_CN.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(function () {
            $('#dlg').dialog({ autoOpen: false });
        });
    </script>

    <script language="javascript" type="text/javascript">
        $(document).ready(function () {
            $("#msgBar").hide();
        });

        //统计字数
        function caulateSize() {
            var sig = $("#<%=HiddenField1.ClientID%>").val(); 
            var content = sig + $("#<%= txtmsgContent.ClientID%>").val() + " 退订回N";
            var infos = "短信字数：" + content.length + " 个" + "<br>短信预览：" + content;
            //alert(content.length);
            $.messager.alert('店铺管家', infos);
        }
        //保存短信内容
        function saveMsgContent() {
            var content = $("#<%= txtmsgContent.ClientID%>").val();
            if (content == '') {
                $.messager.alert('店铺管家', '短信内容不能为空！');
                $("#<%= txtmsgContent.ClientID%>").focus();
                return;
            } else {
                //document.getElementById("imgLoader").style.display = "block";
                $PostAjax(
                   "POST",
                   "/handler/messageHandler.ashx",
                   "&command=msgConSave&msgContent=" + content,
                   "text",
                   function (result) {
                       //document.getElementById("imgLoader").style.display = "none";
                       if (result == '1') {
                           $.messager.alert('店铺管家', '短信内容保存成功！');
                       } else {
                           $.messager.alert('店铺管家', '短信内容保存失败!', 'error');
                       }
                   });
            }
        }
        //返回保存内容
        function getMsgContent() {
            $PostAjax(
                  "POST",
                  "/handler/messageHandler.ashx",
                  "&command=getConSave",
                  "text",
                  function (result) {
                      $("#<%= txtmsgContent.ClientID%>").html(result);
                      $.messager.alert('店铺管家', '短信内容提取成功，现在可以群发短信啦！');
                  });
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
                    $("#<%= lbMsgCount.ClientID%>").html(result);
                });
            }

            function sendMsg() {
                var content = $("#<%= txtmsgContent.ClientID%>").val();
                var falg = $("#<%= cbNotSendYD.ClientID%>").attr("checked"); 

            if (content == '') {
                $.messager.alert('店铺管家', '短信内容不能为空!', 'error');
                return;
            }
            if (content.indexOf("【") >= 0) {
                $.messager.alert('店铺管家', '短信内容里面不能包涵【】符号,请用()代替!', 'error');
                return;
            }
            var sig = $("#<%=HiddenField1.ClientID%>").val();
            var content2 = sig + content + " 退订回N";
            var infos = "短信字数：" + content2.length + " 个" + "<br>短信预览：" + content2;
            progress();
            $.messager.confirm("店铺管家", infos, function (data) {
                if (data) {
                $PostAjax(
               "POST",
               "/handler/messageHandler.ashx",
               "&command=sendMsg&content=" + content + "&falg=" + falg,
               "text",
               function (result) {
                   if (result == "发送成功") {
                       $.messager.alert('店铺管家', '短信发送成功！');
                   } else if (result == "余额不足") {
                       $.messager.alert('店铺管家', '短信账户余额不足!', 'error');
                       document.getElementById("lbOrderMsg").style.visibility = "visible";
                   } else if (result == "没有会员") {
                       $.messager.alert('店铺管家', '没有要发送短信的会员，请重新搜索查询！', 'error');
                   }
                   getMsgCount();
                   closeProgres();
               });
                    return;
                }
                else {
                    closeProgres();
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

    <style type="text/css">
        /*淘宝风格*/
        .paginator {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 10px 20px 10px 0;
            margin: 0px;
        }

            .paginator a {
                border: solid 1px #ccc;
                color: #0063dc;
                cursor: pointer;
                text-decoration: none;
            }

                .paginator a:visited {
                    padding: 1px 6px;
                    border: solid 1px #ddd;
                    background: #fff;
                    text-decoration: none;
                }

            .paginator .cpb {
                border: 1px solid #F50;
                font-weight: 700;
                color: #F50;
                background-color: #ffeee5;
            }

            .paginator a:hover {
                border: solid 1px #F50;
                color: #f60;
                text-decoration: none;
            }

            .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover {
                float: left;
                height: 16px;
                line-height: 16px;
                min-width: 10px;
                _width: 10px;
                margin-right: 5px;
                text-align: center;
                white-space: nowrap;
                font-size: 12px;
                font-family: Arial,SimSun;
                padding: 0 3px;
            }
        .mess_tb td
        {
            border:none;
            padding-top:10px;
            padding-left:10px;        

        }
    </style>
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="hidGetMsgContent" runat="server" />
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li class="on"><a href="message.aspx">短信营销</a></li>
                    <li><a href="Smart/index.aspx">智能营销</a></li>
                    <li><a href="sendMsg.aspx">自有号码群发</a></li>
                    <li><a href="Smart/msgHis.aspx">发送记录</a></li>
                    <li><a href="shortLink.aspx">短链接生成</a></li>
                    <li><a href="signModify.aspx">修改签名</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <div class="pDiv2">
                    <div class="div_zhandian">
                        <span class="zhandian">短信营销 >> 短信营销</span>
                    </div>
                    <div class="contt4">
                        <table class="mess_tb">
                            <%--<tr>
                                <td colspan="6">
                                    <font color="red">温馨提示：营销短信建议在9:00 -- 18:00之间群发！</font>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <label for="BuyerNick">
                                        买家昵称:
                                    </label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNickName" runat="server" CssClass="ui-widget-content ui-corner-all" Width="130px"></asp:TextBox>
                                </td>
                                <td>
                                    <label for="LastTradeTimeStart">
                                        上次交易时间：</label>
                                </td>
                                <td>
                                    <input runat="server" type="text" class="ui-widget-content ui-corner-all"  style="width:120px" onclick="WdatePicker()"
                                        id="datePicker" />
                                    至
                        <input runat="server" type="text" class="ui-widget-content ui-corner-all" style="width:120px" onclick="WdatePicker()"
                            id="datePickerEnd" />
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="CheckBox1" Enabled="false" runat="server" Checked="true" Text="过滤中差评买家" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="Grade">
                                        会员级别：</label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGrade" runat="server" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="0">潜在会员</asp:ListItem>
                                        <asp:ListItem Value="1">普通会员</asp:ListItem>
                                        <asp:ListItem Value="2">高级会员</asp:ListItem>
                                        <asp:ListItem Value="3">Vip会员</asp:ListItem>
                                        <asp:ListItem Value="4">至尊Vip会员</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="TradeCountStart">
                                        宝贝件数（件）：</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNum1" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px"></asp:TextBox>&nbsp;至
                        <asp:TextBox ID="txtNum2" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="CheckBox2" Enabled="false" runat="server" Checked="true" Text="过滤失效买家" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="Province">
                                        地区：</label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpArea" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px">
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
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <label for="TradeAmountStart">
                                        交易额（元）：</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTradAmount1" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px"></asp:TextBox>&nbsp;至
                        <asp:TextBox ID="txtTradAmount2" runat="server" CssClass="ui-widget-content ui-corner-all" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan="2">
                                    <asp:CheckBox ID="cbRemoveBlakList" Enabled="false" runat="server" Checked="true"
                                        Text="过滤黑名单买家" />&nbsp;<a href="blacklist.aspx">黑名单管理</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label for="Province">
                                        交易频率：</label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpTradePinNv" runat="server" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="3">3个月未成交</asp:ListItem>
                                        <asp:ListItem Value="6">半年未成交</asp:ListItem>
                                        <asp:ListItem Value="12">1年未成交</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:CheckBox ID="cbDays" runat="server" Text="过滤最近：" />
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpSendDays" runat="server" CssClass="ui-widget-content ui-corner-all"
                                        Width="50px">
                                        <asp:ListItem Value="2">2</asp:ListItem>
                                        <asp:ListItem Value="3">3</asp:ListItem>
                                        <asp:ListItem Value="4">4</asp:ListItem>
                                        <asp:ListItem Value="5">5</asp:ListItem>
                                        <asp:ListItem Value="6">6</asp:ListItem>
                                        <asp:ListItem Value="7">7</asp:ListItem>
                                        <asp:ListItem Value="7">10</asp:ListItem>
                                    </asp:DropDownList>
                                    天内发送过的买家&nbsp;&nbsp;<asp:CheckBox ID="cbNotSendYD" runat="server" Text="过滤移动号码" />
                                </td>
                                <td>购买次数：
                        <asp:TextBox ID="txtBuyCount" Width="100px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                </td>
                                <td align="center">
                                    <asp:ImageButton ID="btnMsgSend" runat="server" ImageUrl="../Images/search.png" OnClientClick="dialog.DOpen2(this);"
                                        OnClick="btnMsgSend_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="6">&nbsp;<asp:Label ID="lbMsgTip" Font-Bold="true" ForeColor="Red" Font-Size="15px" runat="server" Text=""></asp:Label>
                                    
                                </td>
                            </tr>
                        </table>
                        <p class="Warning">
                        </p>
                        <hr />
                        <div style="padding-bottom: 5px;">
                            <div style="clear: both">
                                <table>
                                    <tr>
                                        <td style="width: 120px;">选择短信内容模板： &nbsp;<a href="sms_template.aspx" target="_blank" style="color: #0000EE;">短信模版</a>&nbsp;&nbsp;<a
                                            href="shortLink.aspx" target="_blank" style="color: #0000EE;">缩短网址</a> &nbsp;&nbsp;<asp:Label
                                                ID="lbMsgCount" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        </td>
                                        <td>
                                            <div class="ui-state-error ui-corner-all" style="width: 380px;">
                                                <strong>温馨提示:</strong>短信内容70个字以内算1条,超过70个字时每67个字一条.
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <input type="button" id="caculateSize" onclick="caulateSize();" value="短信预览&字数统计" /></td>
                                    </tr>
                                    <%--<tr id="msgBar">
                            <td colspan="3">
                              <div id="p" class="easyui-progressbar" style="width:100%;"></div>
                               <img id="loading" src="phoneDetail/Images/msgsend.gif" alt="短信群发" />
                            </td>
                        </tr>--%>
                                    <tr>
                                        <td style="width: 150px;">
                                            <textarea cols="50" rows="10" runat="server" style="width: 430px; height: 73px; font-size: 10pt"
                                                class="ui-widget-content ui-corner-all"
                                                id="txtmsgContent" name="txtmsgContent"></textarea>
                                        </td>
                                        <td valign="bottom" colspan="2">
                                            <a href="javascript:void(0)" onclick="sendMsg();">
                                                <img src="Images/msgsend.jpg" /></a>
                                            &nbsp;&nbsp;<a
                                                href="Smart/msgHis.aspx" target="_blank"><img alt="" src="Images/sendHis.png" />
                                            </a>&nbsp;<asp:Label ID="lbError" runat="server" Font-Size="18px" ForeColor="Red"
                                                Text=""></asp:Label>&nbsp;<a href="~/messageSetting.aspx" id="lbOrderMsg" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" valign="middle">
                                            <a href="javascript:void(0)" onclick="saveMsgContent();">
                                                <img src="Images/saveMsgHisContent.jpg" /></a>
                                            &nbsp;
                                <a href="javascript:void(0)" onclick="getMsgContent();">
                                    <img src="Images/getMsgHisContent.jpg" /></a>
                                            &nbsp;<asp:Label
                                                ID="lbSaveMsgInfo" runat="server" ForeColor="Blue" Font-Size="18px" Text=""></asp:Label>
                                            <asp:ImageButton ID="btnOfflineSend" runat="server" ImageUrl="~/Images/offlineMsgSend.jpg"
                                                OnClick="btnOfflineSend_Click" Width="120px" Height="25px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" valign="middle">测试号码：<asp:TextBox ID="txtMyCellPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;
                                <a href="javascript:void(0)" onclick="sendTestMsg();">
                                    <img src="Images/sendtestmsg.jpg" /></a>
                                            &nbsp;
                                <a href="messageSetting.aspx" id="lbOrderMsg2" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="msgDiv2" style="width: 350px; height: 13px; position: absolute; left: 280px; top: 150px; display: none; z-index: 9999;">
                    <h1>
                        <font color="white">数据查询中,请稍等........</font></h1>
                </div>
                <div id="zhezhang2" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 280px; top: 180px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                </div>
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>

            </div>
        </div>
    </div>
</asp:Content>
