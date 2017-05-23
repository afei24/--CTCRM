<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="automatic.aspx.cs" Inherits="CTCRM.WIN_Aspx.automatic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <link href="../WIN_CSS/left_navigator.css" rel="stylesheet" />
     <script type="text/javascript" src="../win_js/left_nav.js"></script>
    <table class="content_father">
        <tr>
            <td class="td_01">
                <div class="leftNav_topDiv">
                    <div class="leftNav_top">
                        <div class="nav_title">
                            <img src="../Win_Image/left_nav/comment_b.png" class="nav_img" />
                            <label class="nav_text">评价管理</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="rate/rateSetting.aspx">自动评价</li>
                                <li class="nav_list_li" id="rate/blacklist.aspx">黑名单</li>
                                <li class="nav_list_li"  id="rate/badList.aspx">中差评查询</li>
                                <li class="nav_list_li" id="rate/ratingLog.aspx">评价日志</li>
                            </ul>
                        </div>
                    </div>
                </div>
            </td>
            <td class="td_02"></td>
            <td class="td_03">
                <iframe class="content_child_right" src="rate/rateSetting.aspx" name="showContent" id="showContent"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
