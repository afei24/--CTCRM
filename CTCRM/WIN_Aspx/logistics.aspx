<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="logistics.aspx.cs" Inherits="CTCRM.WIN_Aspx.logistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="../WIN_CSS/left_navigator.css" rel="stylesheet" />
    <script type="text/javascript" src="../win_js/left_nav.js"></script>
    <%--最外层div--%>
    <table class="content_father">
        <tr>
            <td class="td_01">
                <div class="leftNav_topDiv">

                    <div class="leftNav_top">
                        <div class="nav_title">
                            <img src="../Win_Image/left_nav/lovely_b.png" class="nav_img" />
                            <label class="nav_text">会员关怀</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="member/index1.aspx?type=notplay">未付款提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=pay">付款提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=startSend">发货提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=delaySend">延迟发货提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=arivde">到达提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=sign">签收提醒</li>
                                <li class="nav_list_li" id="member/index1.aspx?type=refund">回款提醒</li>
                            </ul>
                        </div>
                    </div>
                    <div class="leftNav_top">
                        <div class="nav_title">
                            <img src="../Win_Image/left_nav/msgSet_b.png" class="nav_img" />
                            <label class="nav_text">物流提醒</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="member/reminderHis.aspx">提醒记录</li>
                            </ul>

                        </div>
                    </div>

                </div>
            </td>
            <td class="td_02"></td>
            <td class="td_03">
                <iframe class="content_child_right" src="member/index1.aspx?type=notplay" name="showContent" id="showContent"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
