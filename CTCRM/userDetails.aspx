<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userDetails.aspx.cs"  MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.userDetails" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="wrapper">
        <div id="body">
            <table>
                <tr>
                    <td>
                        买家昵称:
                    </td>
                    <td>
                        <input id="buyerNick" name="buyerNick" class="ui-widget-content ui-corner-all" value="" />
                    </td>
                    <td>
                        真实姓名:
                    </td>
                    <td>
                        <input id="realName" name="realName" class="ui-widget-content ui-corner-all" value="" />
                    </td>
                    <td>
                        手机号码：
                    </td>
                    <td>
                        <input id="mobile" name="mobile" class="ui-widget-content ui-corner-all" value="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        积分余额在
                    </td>
                    <td colspan="4">
                        <input id="minPoint" name="minPoint" class="ui-widget-content ui-corner-all validate[custom[integer],min[0]]"
                            value="" />
                        至
                        <input id="maxPoint" name="maxPoint" class="ui-widget-content ui-corner-all validate[custom[integer],min[0]]"
                            value="" />
                    </td>
                    <td>
                        <button type="submit" class="ui-widget-content ui-corner-all">
                            查找</button>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <th>
                        买家昵称
                    </th>
                    <th>
                        真实姓名
                    </th>
                    <th>
                        省份
                    </th>
                    <th>
                        手机
                    </th>
                    <th>
                        积分
                    </th>
                    <th style="max-width: 200px">
                        备注
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
                <tr>
                    <td>
                        郭翠欣
                    </td>
                    <td>
                        陈颖
                    </td>
                    <td>
                        湖南省
                    </td>
                    <td>
                        15989286732
                    </td>
                    <td>
                        <a href="/pointaccount/new/%e9%83%ad%e7%bf%a0%e6%ac%a3?method=add" class="ui-icon ui-icon-circle-plus addAccountLink floatLeft"
                            title="给郭翠欣赠送积分" target="_blank"></a><a href="/pointaccount/new/%e9%83%ad%e7%bf%a0%e6%ac%a3?method=sub"
                                class="ui-icon ui-icon-circle-minus addAccountLink floatLeft" title="给郭翠欣消费积分"
                                target="_blank"></a><a href="/pointaccount/list?buyernick=%e9%83%ad%e7%bf%a0%e6%ac%a3"
                                    class="showAccountLink floatLeft" title="查看郭翠欣的积分记录" target="_blank">0</a>
                    </td>
                    <td>
                    </td>
                    <td>
                        <a href="/memberext/show/%e9%83%ad%e7%bf%a0%e6%ac%a3" class="showMemberLink" title="查看郭翠欣的详情"
                            target="_blank" buyernick="郭翠欣">查看</a> | <a href="/memberext/edit/%e9%83%ad%e7%bf%a0%e6%ac%a3"
                                class="editMemberLink" title="编辑郭翠欣的详情" target="_blank">编辑</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        tb8695824_11
                    </td>
                    <td>
                        龙明
                    </td>
                    <td>
                        北京
                    </td>
                    <td>
                        15278996321
                    </td>
                    <td>
                        <a href="/pointaccount/new/tb8695824_11?method=add" class="ui-icon ui-icon-circle-plus addAccountLink floatLeft"
                            title="给tb8695824_11赠送积分" target="_blank"></a><a href="/pointaccount/new/tb8695824_11?method=sub"
                                class="ui-icon ui-icon-circle-minus addAccountLink floatLeft" title="给tb8695824_11消费积分"
                                target="_blank"></a><a href="/pointaccount/list?buyernick=tb8695824_11" class="showAccountLink floatLeft"
                                    title="查看tb8695824_11的积分记录" target="_blank">0</a>
                    </td>
                    <td>
                    </td>
                    <td>
                        <a href="/memberext/show/tb8695824_11" class="showMemberLink" title="查看tb8695824_11的详情"
                            target="_blank" buyernick="tb8695824_11">查看</a> | <a href="/memberext/edit/tb8695824_11"
                                class="editMemberLink" title="编辑tb8695824_11的详情" target="_blank">编辑</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        bestlixuan8
                    </td>
                    <td>
                        李炫
                    </td>
                    <td>
                        四川省
                    </td>
                    <td>
                        18980517951
                    </td>
                    <td>
                        <a href="/pointaccount/new/bestlixuan8?method=add" class="ui-icon ui-icon-circle-plus addAccountLink floatLeft"
                            title="给bestlixuan8赠送积分" target="_blank"></a><a href="/pointaccount/new/bestlixuan8?method=sub"
                                class="ui-icon ui-icon-circle-minus addAccountLink floatLeft" title="给bestlixuan8消费积分"
                                target="_blank"></a><a href="/pointaccount/list?buyernick=bestlixuan8" class="showAccountLink floatLeft"
                                    title="查看bestlixuan8的积分记录" target="_blank">0</a>
                    </td>
                    <td>
                    </td>
                    <td>
                        <a href="/memberext/show/bestlixuan8" class="showMemberLink" title="查看bestlixuan8的详情"
                            target="_blank" buyernick="bestlixuan8">查看</a> | <a href="/memberext/edit/bestlixuan8"
                                class="editMemberLink" title="编辑bestlixuan8的详情" target="_blank">编辑</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        唐文玲0328
                    </td>
                    <td>
                        唐文玲
                    </td>
                    <td>
                        广西壮族自治区
                    </td>
                    <td>
                        13768966866
                    </td>
                    <td>
                        <a href="/pointaccount/new/%e5%94%90%e6%96%87%e7%8e%b20328?method=add" class="ui-icon ui-icon-circle-plus addAccountLink floatLeft"
                            title="给唐文玲0328赠送积分" target="_blank"></a><a href="/pointaccount/new/%e5%94%90%e6%96%87%e7%8e%b20328?method=sub"
                                class="ui-icon ui-icon-circle-minus addAccountLink floatLeft" title="给唐文玲0328消费积分"
                                target="_blank"></a><a href="/pointaccount/list?buyernick=%e5%94%90%e6%96%87%e7%8e%b20328"
                                    class="showAccountLink floatLeft" title="查看唐文玲0328的积分记录" target="_blank">0</a>
                    </td>
                    <td>
                    </td>
                    <td>
                        <a href="/memberext/show/%e5%94%90%e6%96%87%e7%8e%b20328" class="showMemberLink"
                            title="查看唐文玲0328的详情" target="_blank" buyernick="唐文玲0328">查看</a> | <a href="/memberext/edit/%e5%94%90%e6%96%87%e7%8e%b20328"
                                class="editMemberLink" title="编辑唐文玲0328的详情" target="_blank">编辑</a>
                    </td>
                </tr>
            </table>
            <div class="floatLeft">
            </div>
            <div style="clear: both">
            </div>
            <div class="ui-state-highlight ui-corner-all" style="margin: 5px 20px; padding: 2px">
                <span class="ui-icon ui-icon-circle-check" style="margin-right: 0.3em; float: left;">
                </span><strong>提示:</strong> 爱多淘将自动为您同步2012年04月27日开始的会员详情
            </div>
        </div>
    </div>
</asp:Content>