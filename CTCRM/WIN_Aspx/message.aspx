<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="CTCRM.WIN_Aspx.message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../WIN_CSS/left_navigator.css" rel="stylesheet" />
    <script type="text/javascript" src="../win_js/left_nav.js"></script>
    <table class="content_father">
        <tr>
            <td class="td_01">
                <div class="leftNav_topDiv">
                    <div class="leftNav_top">
                        <div class="nav_title">
                            <img src="../Win_Image/left_nav/smsSend_b.png" class="nav_img" />
                            <label class="nav_text">短信营销</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list" >
                            <ul class="nav_list_ul">
                                <li class="nav_list_li"  id="sendMsg.aspx">自有短信群发</li>
                                <li class="nav_list_li" id="win_memberMsg.aspx">会员短信群发</li>
                                <li class="nav_list_li" id="Smart/msgHis.aspx">发送记录</li>
                                <li class="nav_list_li" id="signModify.aspx">修改签名</li>
                                <li class="nav_list_li" id="../shortLink.aspx">短链接生成</li>
                            </ul>
                        </div>
                    </div>

                    <div class="leftNav_top">
                        <div class="nav_title" >
                            <img src="../Win_Image/left_nav/smsTrade_b.png" class="nav_img" />
                            <label class="nav_text">智能营销</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="Smart/index.aspx">新会员营销</li>
                                <li class="nav_list_li" id="Smart/memberLevel.aspx">会员等级营销</li>
                                <li class="nav_list_li" id="Smart/huoyue.aspx">活跃会员营销</li>
                                <li class="nav_list_li" id="Smart/jieri.aspx">节日营销</li>
                                <li class="nav_list_li" id="../Smart/unpay.aspx">未交易营销</li>
                                <li class="nav_list_li" id="Smart/area.aspx">地区营销</li>
                            </ul>
                        </div>
                    </div>

                </div>
            </td>
            <td class="td_02"></td>
            <td class="td_03">
                <iframe class="content_child_right" src="sendMsg.aspx" style="height:1200px;" scrolling="no" frameborder="0" name="showContent" id="showContent"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
