<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="members.aspx.cs" Inherits="CTCRM.WIN_Aspx.members" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../WIN_CSS/left_navigator.css" rel="stylesheet" />
      <script type="text/javascript" src="../win_js/left_nav.js"></script>
    <table class="content_father">
        <tr>
            <td class="td_01">
                <div class="leftNav_topDiv">
                    <div class="leftNav_top">
                        <div class="nav_title" >
                            <img src="../Win_Image/left_nav/members_b.png" class="nav_img" />
                            <label class="nav_text">会员管理</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="allmember.aspx">客户资料</li>
                                <li class="nav_list_li" id="blacklist.aspx">黑名单管理</li>
                                <li class="nav_list_li" id="SynData/buyerExport.aspx">客户资料导出</li>
                                <li class="nav_list_li" id="../SynData/downloads.aspx">数据同步</li>
                                <li class="nav_list_li" id="member/logisticsMembers.aspx">物流未签收</li>
                            </ul>
                        </div>
                    </div>

                </div>
            </td>
            <td class="td_02"></td>
            <td class="td_03">
                <iframe class="content_child_right" src="allmember.aspx" name="showContent" id="showContent" ></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
