<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Navigation.Master" AutoEventWireup="true" CodeBehind="system.aspx.cs" Inherits="CTCRM.WIN_Aspx.system" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../WIN_CSS/left_navigator.css" rel="stylesheet" />
    <style type="text/css">
        ul
        {
            margin:0;padding:0
        }
        </style>
    <%--最外层div--%>
    <div class="content_father">
        <%--左边最外层div--%>
        <div class="content_child_left">
            <%-- 导航最外层div窗口--%>
            <div class="navigation_div_father">
                <%-- 第一个导航div--%>
                <div class="navigation_div_child">
                    <div class="navigation_div_titile" id="members" style="background-image: url('../Win_Image/members.png');color:white">
                        <ul>
                            <li class="navigation_li_txt">系统设置</li>
                        </ul>
                    </div>

                    <div class="navigation_div_a members">
                        <ul class="navigation_div_ul">
                            <li><a class="navigation2" id="allmember.aspx">客户资料</a> </li>
                            <li><a class="navigation2" id="blacklist.aspx">黑名单管理</a></li>
                            <li><a class="navigation2" id="SynData/buyerExport.aspx">客户资料导出</a></li>
                        </ul>
                    </div>

                </div>
            </div>
        </div>

        <%--右边最外层div--%>
        <iframe class="content_child_right" src="allmember.aspx">
        </iframe>

    </div>
</asp:Content>
