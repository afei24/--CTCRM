<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CTCRM.WIN_Aspx.home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link type="text/css" href="../CSS/demo.css" rel="Stylesheet" media="screen" />
    <link type="text/css" href="../CSS/basic.css" rel="Stylesheet" media="screen" />
    <link href="../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/easyui.css" rel="stylesheet" />
    <link href="../CSS/icon.css" rel="stylesheet" />
    <script src="../Js/jquery.min.js"></script>
    <script src="../Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../Js/easyui-lang-zh_CN.js"></script>
    <script language="javascript" type="text/javascript">
        function doSave() {
            var valNick = $('#sellerSigName').val();
            var valPhone = $('#sellerCellphone').val();
            if (valNick == '') {
                alert('店铺签名不能为空!');
                $('#sellerSigName').focus();
                return;
            }
            if (valNick.length > 10) {
                alert('店铺签名不能超过10个字!');
                $('#sellerSigName').focus();
                return;
            }
            $PostAjax(
                   "POST",
                   "~/handler/common.ashx",
                   "&nick=" + valNick + "&phone=" + valPhone,
                   "text",
                   function (jsonString) {
                       if (jsonString == '0') {
                           $.messager.alert('店铺管家', '手机号码格式不正确！', 'error');
                           return;
                       } if (jsonString == '1') {
                           $.messager.alert('店铺管家', '保存成功！');
                           return;
                       }
                   });
        }

        function SigNamePre() {
            var valNick = $('#sellerSigName').val();
            $('#lbPrveNick').html('【' + valNick + '】');

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="homewrap">
        <div class="prompt">
            <ul style="padding:0">
                <table style="width: 100%;" class="thead">
                    <tr>
                        <td>
                            <div class="pic">
                            <img src="../Images/短信签名.jpg" />
                                </div>
                            <div class="msg">
                                <font color="#FF8762">店铺短信签名</font>
                                <br />
                                <font color="black" id="userName"><%=userName%></font>
                                <br />
                                <font color="black"><a href="signModify.aspx">修改签名</a></font>
                                </div>
                        </td>
                        <td> <div class="pic">
                            <img src="../Images/软件到期.jpg" />
                                </div>
                            <div class="msg">
                                <font color="#56BDDE">软件到期时间</font>
                                <br />
                                <font color="black" id="Font1"><%=deadline%></font>
                                <br />
                                <font color="black"><a href="#">续订软件</a></font>
                                </div></td>
                        <td> <div class="pic">
                            <img src="../Images/短信条数.jpg" />
                                </div>
                            <div class="msg">
                                <font color="#B198DC">剩余短信条数</font>
                                <br />
                                <font color="black" id="Font2">你还有<%=msgCount%>短信</font>
                                <br />
                                <font color="black"><a href="messageSetting.aspx">短信充值</a></font>
                                </div></td>
                        <td> <div class="pic">
                            <a href="../SynData/downloads.aspx"><img src="../Images/数据同步.PNG" /></a>
                                </div>
                            </td>
                    </tr>
                </table>

            </ul>
            <p></p> 
            <div style=" border-color:black;">
            <p><a href="#"><font  style="font-weight:bold;" color="#56BDDE">★系统公告：</font><font style="font-weight:bold;" color="#91949D" id="systemMsg">【2016-7-27】订单打印功能上线</font></a></p> 
                </div>
            <div class="gongneng">
                <table style="width: 100%;background-color:black;height:100%">
                    <tr>
                        <td style="border-color:black">
                            <a href="Smart/msgHis.aspx"><img src="../Images/短信发送记录.jpg" /></a></td>
                        <td>
                            <a href="sendMsg.aspx"><img src="../Images/短信群发.jpg" /></a></td>
                        <td>
                            <a href="../message.aspx"><img src="../Images/短信营销.jpg" /></a></td>
                        <td><a href="member/index1.aspx?type=delivery"><img src="../Images/发货提醒.jpg" /></a></td>
                        <td><a href="messageSetting.aspx"><img src="../Images/短信充值.jpg" /></a></td>
                    </tr>
                    <tr>
                        <td>
                            <a href="allmember.aspx"><img src="../Images/Customer -data.jpg" /></a></td>
                        <td>
                            <a href="SynData/buyerExport.aspx"><img src="../Images/Customer -data-derived.jpg" /></a></td>
                        <td>
                            <a href="blacklist.aspx"><img src="../Images/blacklist-management.jpg" /></a></td>
                        <td>
                            <a href="#"><img src="../Images/Label management.jpg" /></a></td>
                        <td>
                            <a href="../CRankNew.aspx"><img src="../Images/customer level.jpg" /></a></td>

                    </tr>
                    <tr>
                        <td>
                            <a href="member/index1.aspx?type=notpaying"><img src="../Images/Payment not remind.jpg" /></a></td>
                        <td>
                            <a href="member/index1.aspx?type=pay"><img src="../Images/Care of payment.jpg" /></a></td>
                        <td>
                            <a href="member/index1.aspx?type=delay"><img src="../Images/remind.jpg" /></a></td>
                        <td>
                            <a href="signModify.aspx"><img src="../Images/Modifysignature.jpg" /></a></td>
                        <td>
                            <a href="member/index1.aspx?type=delivery"><img src="../Images/Send to remind.jpg" /></a></td>
                    </tr>
                    <tr>
                        <td>
                            <a href="member/index1.aspx?type=Sign"><img src="../Images/Sign for remind.jpg" /></a></td>
                        <td>
                            <a href="#"><img src="../Images/care.jpg" /></a></td>
                        <td>
                            <a href="member/index1.aspx?type=receivable"><img src="../Images/receivable-care.jpg" /></a></td>
                        <td>
                            <a href="#"><img src="../Images/Refund-care.jpg" /></a></td>
                        <td>
                            <a href="rate/rateSetting.aspx"><img src="../Images/Evaluation-care.jpg" /></a></td>
                    </tr>
                </table>
                </div>
        </div>
         <script type="text/javascript">
             document.getElementById("FirstPage").className += ' NavSelected';
                 </script> 
    </div>
    </div>
    </form>
</body>
</html>
