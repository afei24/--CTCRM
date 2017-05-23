<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home1.aspx.cs" Inherits="CTCRM.WIN_Aspx.home1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../WIN_CSS/home1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="tb_toside">
            <tr>
                <td>
                    <img class="div_head_top_img" src="../Images/短信签名.jpg" />
                    <div class="div_head_txt">
                        <div class="txt_one">店铺短信签名</div>
                        <div class="txt_two"><%= userName %></div>
                        <div class="txt_three">修改签名</div>
                    </div>
                </td>
                <td>
                    <img class="div_head_top_img" src="../Images/软件到期.jpg" />
                    <div class="div_head_txt">
                        <div class="txt_one">店铺短信签名</div>
                        <div class="txt_two">君瑞旗舰店</div>
                        <div class="txt_three">修改签名</div>
                    </div>
                </td>
                <td>
                    <img class="div_head_top_img" src="../Images/短信条数.jpg" />
                    <div class="div_head_txt">
                        <div class="txt_one">店铺短信签名</div>
                        <div class="txt_two">君瑞旗舰店</div>
                        <div class="txt_three">修改签名</div>
                    </div>
                </td>
                <td>
                    <img class="div_head_top_img" src="../Images/短信签名.jpg" />
                    <div class="div_head_txt">
                        <div class="txt_one">店铺短信签名</div>
                        <div class="txt_two">君瑞旗舰店</div>
                        <div class="txt_three">修改签名</div>
                    </div>
                </td>
            </tr>
        </table>

        <br />
        <div class="system_msg">
            <a>
                <table>
                    <tr>
                        <td class="system_msg_title">系统公告:</td>
                        <td class="system_msg_content">【2016-7-27】订单打印功能上线</td>
                    </tr>
                </table>
            </a>
        </div>

        <table class="tb_imgs">
            <tr>
                <td>
                    <a href="../Smart/msgHis.aspx">
                        <img src="../Images/短信发送记录.jpg" /><a></td>
                <td>
                    <a href="../sendMsg.aspx">
                        <img src="../Images/短信群发.jpg" /></a></td>
                <td>
                    <a href="../message.aspx">
                        <img src="../Images/短信营销.jpg" /></a></td>
                <td><a href="../member/index.aspx?type=delivery">
                    <img src="../Images/发货提醒.jpg" /></a></td>
                <td><a href="../messageSetting.aspx">
                    <img src="../Images/短信充值.jpg" /></a></td>
            </tr>
            <tr>
                <td>
                    <a href="../allmember.aspx">
                        <img src="../Images/Customer -data.jpg" /></a></td>
                <td>
                    <a href="../SynData/buyerExport.aspx">
                        <img src="../Images/Customer -data-derived.jpg" /></a></td>
                <td>
                    <a href="../blacklist.aspx">
                        <img src="../Images/blacklist-management.jpg" /></a></td>
                <td>
                    <a href="#">
                        <img src="../Images/Label management.jpg" /></a></td>
                <td>
                    <a href="../CRankNew.aspx">
                        <img src="../Images/customer level.jpg" /></a></td>

            </tr>
            <tr>
                <td>
                    <a href="../member/index.aspx?type=notpaying">
                        <img src="../Images/Payment not remind.jpg" /></a></td>
                <td>
                    <a href="../member/index.aspx?type=pay">
                        <img src="../Images/Care of payment.jpg" /></a></td>
                <td>
                    <a href="../member/index.aspx?type=delay">
                        <img src="../Images/remind.jpg" /></a></td>
                <td>
                    <a href="../signModify.aspx">
                        <img src="../Images/Modifysignature.jpg" /></a></td>
                <td>
                    <a href="../member/index.aspx?type=delivery">
                        <img src="../Images/Send to remind.jpg" /></a></td>
            </tr>
            <tr>
                <td>
                    <a href="../member/index.aspx?type=Sign">
                        <img src="../Images/Sign for remind.jpg" /></a></td>
                <td>
                    <a href="#">
                        <img src="../Images/care.jpg" /></a></td>
                <td>
                    <a href="../member/index.aspx?type=receivable">
                        <img src="../Images/receivable-care.jpg" /></a></td>
                <td>
                    <a href="#">
                        <img src="../Images/Refund-care.jpg" /></a></td>
                <td>
                    <a href="../rate/rateSetting.aspx">
                        <img src="../Images/Evaluation-care.jpg" /></a></td>
            </tr>
        </table>

        <p>
            地址：上海市松江区佘山镇陶干路701号A栋287室 旺旺：点击这里给我发消息
            <br />
            <br />
            本网站建议您使用1920*1080分辨率 蜀【PCI备 12026451号】
        </p>

    </form>
</body>
</html>
