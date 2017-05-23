<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="huoyue.aspx.cs" Inherits="CTCRM.WIN_Aspx.Smart.huoyue" %>

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
                      $.messager.confirm("店铺管家", infos, function (data) {
                          if (data) {
                              progress();
                              $PostAjax(
                               "POST",
                               "../../handler/messageHandler.ashx",
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
                    <li class="on"><a href="huoyue.aspx">活跃会员营销</a></li>
                    <li><a href="jieri.aspx">节日营销</a></li>
                    <li><a href="unpay.aspx">未交易营销</a></li>
                    <li><a href="area.aspx">地区营销</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <asp:HiddenField ID="HiddenField1" runat="server" />
                <asp:HiddenField ID="hidLabId" runat="server" />
                <%--<div class="infoArea" runat="server" id="msgAcountCheck">
                    <div class="ui-state-error ui-corner-all" style="width: 100%; text-align: center; font-size: 18px; font-weight: bold; vertical-align: middle">
                        <asp:Label ID="lbMsgTip" runat="server" Text="亲，您还未开通短信账户或者账户余额不足，现在就去？"></asp:Label><a
                            href="../messageSetting.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buy.png" /></a>
                    </div>
                </div>--%>

                <div class="pDiv2 yingxiao_pDiv2">
                    <div class="div_yingxiao">
                        <span class="yingxiao">活跃会员营销</span>
                    </div>
                     <%--<div class="title2">
                        活跃会员营销
                    </div>--%>
                    <div class="contt4 yingxiao_contt4">
                        <table class="ind_tb">
                            <tbody>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label16" runat="server" Text="活跃度较低但购买力较强的会员" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label17" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">此类会员购买力较强，活跃度较低，建议对其加大促销力度，挑选单价比较高的产品进行随送。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/四星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="imgbtnHuoYueDiGouMaiDi" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgbtnHuoYueDiGouMaiDi_Click" /><asp:Label ID="lbHuoYueDiGouMaiQiang" Font-Bold="true"
                                                Font-Size="16px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">  
                                         <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('HuoYueDiGouMaiQiang')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label18" runat="server" Text="活跃度一般购物能力也一般的会员" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label19" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">这些会员购物能力和活跃度都一般，建议对其提升活动促销力度，挑选性价比高的商品进行推送。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/三星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="imgbtnHuoYueYiBan" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgbtnHuoYueYiBan_Click" /><asp:Label ID="lbHuoYueYiBan" Font-Bold="true"
                                                Font-Size="16px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('HuoYueBanGouMaiBan')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label2" runat="server" Text="活跃度高购物能力一般的会员" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label21" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">这些会员的购物能力一般，但是活跃度很高，建议活动重点放在挑选性价比高或者价格有吸引力的商品进行推送。
                                    </td>
                                    <td style="width: 10%"> 
                                        <img alt="" src="../../Win_Image/五星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="benimgHuoYueGaoGouBan" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="benimgHuoYueGaoGouBan_Click" /><asp:Label ID="lbHuoYueGaoGouMaiBan" Font-Bold="true"
                                                Font-Size="16px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">
                                         <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('HuoYueGaoGouMaiBan')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%" class="head">
                                        <asp:Label ID="Label22" runat="server" Text="活跃度高且购物能力强的会员" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                    <td colspan="3" style="width: 30%" class="head">
                                        <asp:Label ID="Label23" runat="server" Text="推荐指数" Font-Bold="true" Font-Size="11pt"
                                            ></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 70%">这些会员是高质量的，建议为其精准推送高价值商品或者组合商品。
                                    </td>
                                    <td style="width: 10%">
                                        <img alt="" src="../../Win_Image/五星.jpg" />
                                    </td>
                                    <td style="width: 10%" align="center">
                                        <asp:ImageButton ID="imgbtnHuoYueGaoGouGao" runat="server" ImageUrl="../../Win_Image/会员营销的赛选会员.jpg" OnClientClick="dialog.DOpen(this);"
                                            OnClick="imgbtnHuoYueGaoGouGao_Click" /><asp:Label ID="lbGaoGao" Font-Bold="true"
                                                Font-Size="16px" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="width: 10%">                   
                                        <a href="javascript:void(0)" style="text-decoration: none" onclick="$('#dlg').dialog('open');setType('HuoYueGaoGouMaiGao')"><img src="../../Win_Image/会员营销的短信营销.jpg" /></a>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                    <div id="dlg" class="easyui-dialog" closed="true" title="智能营销 -> 活跃会员营销(最近3个月)" style="width: 600px; height: 300px; padding: 10px" data-options=" iconCls: 'icon-save',toolbar: '#dlg-toolbar',buttons: '#dlg-buttons'">
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
                                    Text=""></asp:Label>&nbsp;<a href="~/messageSetting.aspx" id="A1" style="visibility: hidden; font-size: large; font-weight: bold; color: blue;">订购短信</a>
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
