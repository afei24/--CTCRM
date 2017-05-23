<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="CTCRM.admin.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>后台管理系统</title>

    <script type="text/javascript">
        function CloseExtend(obj) {
            obj = (obj == "string" ? document.getElementById("obj") : obj);
            var prt = obj.parentNode.parentNode;
            for (var i = prt.childNodes.length-1; i >= 0; i--) {
                var ele = prt.childNodes[i];
                if (ele.tagName == "DD") {
                    if (ele.tagName == "DD" && ele.style.display == "none") {
                        ele.style.display = 'block';
                        var chid = obj.childNodes;
                        for (var j = 0; j < chid.length; j++) {
                            if (chid[j].tagName == "S" && chid[j].className == 'ps1') {
                                chid[j].style.backgroundPosition = '-142px  -129px ';
                                break;
                            }
                        }

                        continue;
                    }
                    if (ele.tagName == "DD" && ele.style.display == 'block') {
                        ele.style.display = 'none';
                        var chid = obj.childNodes;
                        for (var j = 0; j < chid.length; j++) {
                            if (chid[j].tagName == "S" && chid[j].className == 'ps1') {
                                chid[j].style.backgroundPosition = '-142px -96px ';
                                break;
                            }
                        }
                        continue;
                    }
                }
            }

        }
        function ChangeDisplay(obj, value) {
            obj.style.display = 'value'
        }
    </script>

    <link rev="stylesheet" media="all" href="style/admin.css" type="text/css" rel="stylesheet" />
</head>
<body class="bodyBj1" style="margin: 0px">
    <form id="Form1" action="menu.aspx" method="post" runat="server">
    <div class="main">
        <div class="pmain">
            <div class="left">
                <div class="leftMain">
                    <div class="logo">
                    </div>
                    <!-- logo End -->
                    <div class="lbj1 ts1">
                        当前用户：<asp:Label ID="lbAdminUserName" runat="server" Text=""></asp:Label></div>
                    <!-- lbj1 End -->
                    <div class="lbts">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" class="pinpt1" onclick="JAVASCRIPT:window.parent.location.href='/index.aspx?'">&nbsp;&nbsp;&nbsp;
                        <input type="button" class="pinpt1 pinpt2" onclick="javascript:window.parent.location.href='/admin/login.aspx'">&nbsp;&nbsp;
                    </div>
                    <!-- lbts End -->
                    <div class="cdan">
                        <dl>
                            <dt class="lbj1"><a class="nav" href="javascript:void(0)" onclick="CloseExtend(this)">
                                &nbsp;&nbsp;<span style="cursor: pointer;"> 短信管理 </span><s class="ps1" style="background-position:-142px -129px;"></s></a>
                            </dt>
                             <dd style="display: block">
                                <s></s><a onfocus="this.blur();" href="message/sendHis.aspx"target="rightFrame">营销记录</a></dd>
                            <dd style="display: block">
                                <s></s><a onfocus="this.blur();" href="message/sendHisReminder.aspx"target="rightFrame">物流记录</a></dd>
                        </dl>
                        <dl>
                            <dt class="lbj1"><a class="nav" href="javascript:void(0)" onclick="CloseExtend(this)">
                                &nbsp;&nbsp;<span style="cursor: pointer;"> 卖家管理 </span><s class="ps1"></s></a>
                            </dt>
                            <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="memberData/index.aspx" target="rightFrame">会员导出权限</a></dd>
                            <dd style="display: none">
                                <s></s><a onfocus="this.blur();" href="message/sellerMsgAcount.aspx" target="rightFrame">短信账户</a></dd>
                            <dd style="display: none">
                                <s></s><a onfocus="this.blur();" href="memberData/sysDataOpen.aspx" target="rightFrame">会员查询</a></dd> 
                           
                                                     
                        </dl>
                        <dl>
                            <dt class="lbj1"><a class="nav" href="javascript:void(0)" onclick="CloseExtend(this)">
                                &nbsp;&nbsp;<span style="cursor: pointer;"> 主动通知 </span><s class="ps1"></s></a>
                            </dt>
                            <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="notify/index.aspx" target="rightFrame">通知管理</a></dd>
                             <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="notify/allCus.aspx" target="rightFrame">API通知管理</a></dd>
                               <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="notify/deleteData.aspx" target="rightFrame">卖家消息管理</a></dd>
                        </dl>
                         <dl>
                            <dt class="lbj1"><a class="nav" href="javascript:void(0)" onclick="CloseExtend(this)">
                                &nbsp;&nbsp;<span style="cursor: pointer;"> 物流管理 </span><s class="ps1"></s></a>
                            </dt>
                             <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="notify/nomsg.aspx" target="rightFrame">过期卖家</a></dd> 
                            <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="logtics/index.aspx" target="rightFrame">手工开通</a></dd> 
                             <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="logtics/bklst.aspx" target="rightFrame">白名单</a></dd> 
                              <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="logtics/auditMsg.aspx" target="rightFrame">提醒审核</a></dd> 
                        </dl>
                        
                        <dl>
                            <dt class="lbj1"><a class="nav" href="javascript:void(0)" onclick="CloseExtend(this)">
                                &nbsp;&nbsp;<span style="cursor: pointer;"> 评价管理 </span><s class="ps1"></s></a>
                            </dt>
                             <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="rate/index.aspx" target="rightFrame">评价日志</a></dd> 
                             <dd class="fgx" style="display: none">
                                <s></s><a onfocus="this.blur();" href="rate/rateQuery.aspx" target="rightFrame">评价客户查询</a></dd> 
                           
                             
                        </dl>
                         
                    </div>
                    <!-- cdan End -->
                </div>
            </div>
            <!-- left End -->
        </div>
        <!-- main End -->
    </form>
</body>
</html>
