<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="versionTip.aspx.cs" Inherits="CTCRM.version.versionTip"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 100%">
        <div class="infoArea">
            <div class="smallTitle">
                &nbsp;亲~您当前使用的是店铺管家【体验版】！
            </div>
            <div class="content">
                <table style="width: 100%">
                    <tbody>
                        <tr>
                            <td>
                                提供体验版的目的是方便您能及时了解软件所提供的功能是否满足您的需求，如果满足请及时升级到正式版本！
                            </td>
                        </tr>
                        <tr>
                            <td>
                                【体验版】包涵功能：给线下会员发送促销短信，入口地址：<a href="../sendMsg.aspx">给线下店铺会员发促销短信</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                【正式版】【特惠版】【至尊版】功能一样，但是【至尊版】可以一次性将自己店铺开店以来的所有会员信息（电话，
                                姓名，地址，地区，消费金额等等)下载保存在自己电脑上！
                            </td>
                        </tr>
                        <tr>
                            <td align="center" style="font-size: 16px; font-weight: bold">
                                <a href="http://fuwu.taobao.com/ser/detail.htm?service_code= ts-1811102" target="_blank">
                                    <font color="red">软件满足我的需求，现在就去升级?</font></a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
