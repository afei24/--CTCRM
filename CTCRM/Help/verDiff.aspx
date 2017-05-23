<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="verDiff.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    Inherits="CTCRM.Help.verDiff" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <base target="_self" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 100%">
        <div class="infoArea">
            <div class="smallTitle" style="cursor: pointer">
                <asp:Label ID="Label20" runat="server" Text="店铺管家软件各版本区别" Font-Bold="true" Font-Size="12pt"
                    ForeColor="#E17009"></asp:Label></div>
            <div class="content">
                <table>
                    <tbody>
                        <tr>
                            <td style="width: 20%; text-align: center">
                                <asp:Label ID="Label1" runat="server" Text="功能模块" Font-Bold="true" Font-Size="11pt"
                                    ForeColor="#E17009"></asp:Label>
                            </td>
                            <td style="width: 10%; text-align: center">
                                <asp:Label ID="Label4" runat="server" Text="高级版" Font-Bold="true" Font-Size="10pt"
                                    ForeColor="#E17009"></asp:Label>
                            </td>
                            <td style="width: 60%; text-align: center">
                                <asp:Label ID="Label2" runat="server" Text="功能说明" Font-Bold="true" Font-Size="10pt"
                                    ForeColor="#E17009"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                店铺运营情况统计
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                统计店铺总的销售额、订单数、会员数、客单价、新客户订单数、退款笔数。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员等级状况
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                统计店铺的会员等级情况【潜在会员、普通会员、高级会员、Vip会员、至尊Vip会员】。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员分组概况
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                统计店铺的买家会员进行各种分组。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员资料导出
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                将店铺中的会员信息导出到自己电脑上。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                手工添加会员
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                手工添加其它店铺或者线下店铺中的会员到系统中，方便对会员进行集中管理以及发放各种优惠促销。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                一键安装到电脑桌面
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                将软件安装到直接的电脑桌面，下次使用软件时直接从桌面和开始菜单进入(无需从淘宝后台进入)。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                导入淘宝历史订单
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                导入淘宝历史订单，找回店铺中所有会员的详细信息(方便进行短信促销)和统计报告的准确性。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员积分
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                店铺中积分最高的前10名会员，方便对这些会员打折。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员消费总金额
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                店铺中新老会员消费最高的前10名会员，方便对这些会员打折。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                热销宝贝排行
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                店铺中卖得最好的10款宝贝，方便进行爆款打造。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员管理
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                查看店铺中所有会员的基本信息和详细信息，对会员信息进行修改查询等操作。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员资料修改
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对会员信息进行修改!
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                短信营销
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对买家会员进行各种条件过滤对其进行促销活动，内置多套促销短信模板。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                智能营销
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对各种节日活动吸引来的买家进行分析然后分组过滤对其进行精准的促销活动，内置多套促销短信模板。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                统计分析
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对店铺中的买家进行分析：按地区和按月份。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员关怀
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对买家进行发货提醒、未付款提醒等操作。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员关怀(发送条件设置)
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                对买家进行发货提醒、未付款提醒等操作时进行条件过滤。
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                店铺会员等级修改
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                店铺会员等级修改
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; vertical-align: middle">
                                会员积分基数策略配置管理
                            </td>
                            <td style="width: 10%; text-align: center">
                                <img src="../Images/yes.png" />
                            </td>
                            <td align="left" style="width: 60%">
                                会员积分基数策略配置管理
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
