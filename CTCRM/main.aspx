<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="CTCRM.WIN_Aspx.main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../WIN_CSS/navigator.css" rel="stylesheet" />
    <link href="../WIN_CSS/duomai_main.css" rel="stylesheet" />
    <link href="../WIN_CSS/control.css" rel="stylesheet" />

    <style>
        ul {
            margin: 0;
            padding: 0;
        }

        .tb_imgs {
            padding: 0px;
            width: 684px;
            height: 508px;
            /*border-right: 1px solid #807878;*/
            border-bottom: 1px solid #d4d0d0;
            border-collapse: collapse;
            border: 1px solid #d4d0d0;
            top: 0px;
            margin-top: 2px;
        }

        .tb_imgs_01 {
            border-bottom: 1px solid #d4d0d0;
            border-collapse: collapse;
        }

            .tb_imgs td, .tb_imgs_01 td {
                width: 225px;
                background-color: white;
                border-right: 1px solid #d4d0d0;
                border-bottom: 1px solid #d4d0d0;
            }

                .tb_imgs td:hover {
                    background-color: #00bbd7;
                }

                .tb_imgs_01 td:hover {
                    background-color: #00bbd7;
                }


        .pingjia {
            width: 100%;
        }

            .pingjia td {
                width: 50%;
                text-align: center;
            }

        #div_content div {
            float: left;
            margin-left: 10px;
        }


        .img_main {
            padding: 0px;
            margin: 0px;
        }

        .td_left {
            width: 684px;
            border-top: 0px;
            margin: 0px;
            padding: 0px;
            vertical-align: top;
        }

        .td_leftborder {
            border-left: 0px;
        }

        .space {
            width: 10px;
        }

        .space01 {
            height: 10px;
        }

        .div_text {
            padding-left: 20px;
            border-bottom: 1px solid #f2eded;
            margin-top: 0px;
            height: 35px;
            line-height: 35px;
            width: 488px;
            font-size: 14px;
            /*color: #767676;*/
        }

        .div_text1 {
            padding-left: 20px;
            border-bottom: 1px solid #f2eded;
            margin-top: 0px;
            height: 35px;
            line-height: 35px;
            font-size: 14px;
             cursor: pointer;
            /*color: #767676;*/
        }


        .ctr_div {
            padding-left: 20px;
            border-bottom: 1px solid #f2eded;
            /*color: #767676;*/
        }

        .ctr_float {
            margin-left: 60%;
            margin-top: 2px;
            background-color: #0AC2EB;
            color: white;
            width: 80px;
            height: 30px;
        }
    </style>

    <div class="index_div_max" style="margin-top: 90px;">
        <div class="index_div_level1">
            <table style="width: 1182px; margin: 0 auto;">
                <tr>
                    <td class="td_left">
                        <table class="tb_imgs">
                            <tr>
                                <td class="index_left_head" colspan="3" style="height: 40px; line-height: 40px; padding-left: 20px; border-bottom: 1px solid #d4d0d0; border-right: 0px;">便捷入口</td>
                            </tr>
                            <tr>
                                <td class="td_leftborder"><a href="WIN_Aspx/message.aspx">
                                    <img class="img_main" src="../Win_Image/home/smsSend_w.jpg" />
                                </a></td>
                                <td><a href="message.aspx?src=WIN_Aspx/Smart/index.aspx">
                                    <img class="img_main" src="../Win_Image/home/smsTrade_w.jpg" />
                                </a></td>
                                <td style="border-right: 0px;"><a href="WIN_Aspx/logistics.aspx?src=member/index1.aspx?type=pay">
                                    <img class="img_main" src="../Win_Image/home/deliverGoods_w.jpg" /></a></td>
                            </tr>
                            <tr>
                                <td class="td_leftborder"><a href="WIN_Aspx/members.aspx?src=allmember.aspx">
                                    <img class="img_main" src="../Win_Image/home/userInfo_w.jpg" /></a> </td>
                                <td><a href="WIN_Aspx/members.aspx?src=SynData/buyerExport.aspx">
                                    <img class="img_main" src="../Win_Image/home/userInfoExport_w.jpg" /></a> </td>
                                <td style="border-right: 0px;"><a href="WIN_Aspx/members.aspx?src=blacklist.aspx">
                                    <img class="img_main" src="../Win_Image/home/blackList_w.jpg" /></a> </td>
                            </tr>
                            <tr>
                                <td class="td_leftborder"><a href="WIN_Aspx/logistics.aspx?src=member/index1.aspx?type=notplay">
                                    <img class="img_main" src="../Win_Image/home/NotPalyWarn_w.jpg" /></a></td>
                                <td><a href="WIN_Aspx/logistics.aspx?src=WIN_Aspx/member/index1.aspx?type=pay">
                                    <img class="img_main" src="../Win_Image/home/palyWarn_w.jpg" /></a> </td>
                                <td style="border-right: 0px;"><a href="WIN_Aspx/automatic.aspx?src=rate/rateSetting.aspx">
                                    <img class="img_main" src="../Win_Image/home/commentWarn_w.jpg" /></a></td>
                            </tr>
                            <tr>
                                <td class="td_leftborder"><a href="message.aspx?src=signModify.aspx">
                                    <img class="img_main" src="../Win_Image/home/updateName_w.jpg" /></a></td>
                                <td><a href="SMSOrder.aspx?src=messageSetting.aspx">
                                    <img class="img_main" src="../Win_Image/home/buySms_w.jpg" /></a> </td>
                                <td style="border-right: 0px;"><a href="logistics.aspx?src=member/index1.aspx?type=delaySend">
                                    <img class="img_main" src="../Win_Image/home/delayedWarn_w.jpg" /></a> </td>
                            </tr>
                        </table>
                    </td>

                    <td class="space">&nbsp;</td>
                    <td class="td_right" style="vertical-align: top; width: 488px; margin: 0px; padding: 0px;">
                        <table style="width: 488px;">
                            <tr>
                                <td class="index_div_right_info">
                                    <div class="div_title">卖家信息</div>
                                    <div class="div_text1">
                                        <label style="color: #0AC2EB; font-weight: bold;"><%= userName %></label>
                                    </div>
                                    <div class="div_text1">
                                        当前版本：<label style="color: white; background-color: #0AC2EB; border-radius: 3px"><%=orderVersion%></label>
                                    </div>
                                    <div class="div_text1">到期时间：<label style="color: red"><%=deadline%><a style="color: #0AC2EB" href="#">续费</a></label></div>
                                    <div class="div_text1">短信数量:<%=msgCount%> <a style="color: #0AC2EB" href="WIN_Aspx/SMSOrder.aspx?src=messageSetting.aspx">充值</a></div>
                                    <div class="div_text1">联系我们：400-060-1008</div>
                                </td>
                                <td class="space"></td>
                                <td class="index_div_right_info1">
                                    <div class="div_title">系统公告</div>
                                    <%--<div id="div_content">
                                        <%=systemMsg%>
                                    </div>--%>
                                    <div class="div_text1"  id="msg1"></div>
                                    <div class="div_text1"  id="msg2"></div>
                                    <div class="div_text1"  id="msg3"></div>
                                    <div class="div_text1"  id="msg4"></div>
                                    <div class="div_text1"  id="msg5"></div>
                                </td>
                            </tr>
                            <tr>
                                <td class="space01"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" style="background-color: white; text-align: left; vertical-align: top; border: 1px solid #d4d0d0;">
                                    <table style="width: 100%; border-bottom: 1px solid #d4d0d0;">
                                        <tr class="div_title">
                                            <td style="padding-left: 10px;">自动评价</td>
                                            <td><a href="WIN_Aspx/automatic.aspx?src=rate/rateSetting.aspx" style="float: right; text-decoration: none;">
                                                <div class="bt_02">去设置</div>
                                            </a></td>
                                        </tr>
                                    </table>
                                    <div class="div_text" style="color: #0AC2EB;">自动评价设置</div>
                                    <div class="div_text">(方案一次只能开通一种)</div>
                                    <div class="div_text">
                                        评价方案一:交易完成立即【秒评】 
                                     <%--   <asp:Button ID="Button1" runat="server" Text="开通"  class="ctr_float" BorderStyle="None" />--%>
                                    </div>
                                    <div class="div_text">
                                        评价方案二：买家评论后评价
                                         <%--<asp:Button ID="Button2" runat="server" Text="开通"  class="ctr_float" BorderStyle="None"/>--%>
                                    </div>
                                    <div class="div_text">自动评价设置</div>
                                    <div class="div_text" style="color: #0AC2EB;">评价内容设置</div>
                                    <div class="div_text">亲~评价内容不能包含网址哦，否则评价会失败!</div>
                                    <div class="ctr_div" style="height: 35px; line-height: 35px;">
                                        <asp:DropDownList ID="DropDownList1" runat="server">
                                            <asp:ListItem>随机使用以下一条作为评价</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="div_text">评价模板1:</div>
                                    <div class="ctr_div" style="border-bottom: 0px;">
                                        <%--<asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="90%" Height="158"></asp:TextBox>--%>
                                        <p style="height: 128px;">
                                            1.有您的支持我们会做得更好，欢迎您的再次光临！<br />
                                            <br />

                                            2.亲们要收藏下我们店铺哟，谢谢您对我们的支持！<br />
                                            <br />

                                            3.尊敬的朋友，感谢您选购我们的商品以及长期对我们的支持！祝您购物愉快！(*^__^*) 嘻嘻！！

                                        </p>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>

        <div class="news"></div>
        <script type="text/javascript" src="../win_js/navigatort.js"></script>
    </div>
</asp:Content>
