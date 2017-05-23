<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="SMSOrder.aspx.cs" Inherits="CTCRM.WIN_Aspx.SMSOrder" %>
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
                            <img src="../Win_Image/left_nav/msgSet_b.png" class="nav_img" />
                            <label class="nav_text">短信订购</label>
                            <img src="../Win_Image/left_nav/arrows_b_left.png" class="nav_arrows" />
                        </div>
                        <div class="nav_list">
                            <ul class="nav_list_ul">
                                <li class="nav_list_li" id="messageSetting.aspx">短信订购</li>
                            </ul>

                        </div>
                    </div>
                </div>
            </td>
            <td class="td_02"></td>
            <td class="td_03">
                <iframe class="content_child_right" src="messageSetting.aspx"  name="showContent" id="showContent"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
