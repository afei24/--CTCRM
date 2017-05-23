<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rateSetting.aspx.cs" Inherits="CTCRM.WIN_Aspx.rate.rateSetting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <script src="../../Js/jquery-1.7.1.min.js"></script>
    <link href="../../CSS/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".title_li").bind("click", function () {
                var id = $(this).attr("id");
                $(".title_li").removeClass("title_click");
                $(this).addClass("title_click");
                $(".contect").hide();
                $("." + id).show();
            });
        })
    </script>
    <style type="text/css">
        .contt4
        {
            padding-top:0;
            border:1px solid #00BFE9;border-radius: 5px;
            margin-top:0;
            margin-left:10px;
            margin-right:20px;
            padding-top:10px;
            float:left;
        }
        td,tr,table,tbody
        {
            border:none;
            
        }
        .contect td
        {
            text-align:left;
        }
        .title2
        {
            background-color:white;
            padding-top:10px;
        }
        .title_li
        {
            float:left;
            color:#505050;
            font-size:25px;margin-top:10px;
            margin-bottom:5px;
            background-color: #F0F0F0;
            font-weight:700;
            width:32%;
            border:none;
            text-align:center;
            height:50px;
            vertical-align:middle;
        }
            .title_li p
            {
                padding-top:8px;
            }
        .title_li:hover
        {
            float:left;
            color:#00BFE9;
            background-color:white;
            font-size:25px;
            margin-top:10px;
            margin-bottom:5px;
            cursor:pointer;
            border:none;
            border-top:solid 3px #00BFE9;
        }

        .title_click
        {
            float:left;
            color:#00BFE9;
            background-color:white;
            font-size:25px;
            margin-top:10px;
            margin-bottom:5px;
            cursor:pointer;
            border:none;
            border-top:solid 3px #00BFE9;
        }

        .title_div
        {
            float:left;
            padding-top:15px;
            width:100%;
        }
        .shuoming
        {
            width:100%;border:none;

        }
            .shuoming td
            {
                border:none;
                border-bottom:1px solid #DEDFDE;
            }
            .shuoming p
            {
                padding-left:10px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="homewrap">
        <div class="homediv" style="height:520px;">
            <div class="righter">
                <div>
                    <div class="pDiv2" style="height:550px;"> 
                        <%--<div class="div_zhandian">
                            <span class="zhandian">自动评价 >> 自动评价</span>
                        </div>
                        <hr style="color:#1EC4EB" />--%>
                        <table class="shuoming">
                            <tbody>
                                <tr>
                                    <td style="width:20%;font-size:25px;font-weight:bold;color:#505050;">
                                        自动评价说明
                                        </td>
                                    <td style="width:80%;border-left:1px solid #DEDFDE;">
                                        <div  style="width:100%;text-align:left;margin-bottom:10px;margin-top:10px;border:none;">
                                            <p style="color:#00BFE9">请先保存评价设置，再开启自动评价【天猫商家不支持自动评价】.</p>
                                            &nbsp;<p>交易完成是指买家确认收货(支付宝确认付款)，评价有效期为交易完成后15天内.</p>
                                            &nbsp;<p>系统如果发现买家给的是中差评，会自动加入黑名单。黑名单上限10000个，超出10000个的，最早加入的会被删除.</p>
                                            &nbsp;<p>黑名单指的是本系统的黑名单，与旺旺黑名单无关，因淘宝未放开接口，系统无法读取到旺旺的黑名单.</p>
                                        </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        <div class="title_div">
                            <ul class="title_ul">
                                <li class="title_li" id="auto"><p>自动评价设置</p></li>
                                <li class="title_li" id="badp"><p>中差评设置</p></li>
                                <li class="title_li" id="neirong"><p>评价内容设置</p></li>

                            </ul>    
                        </div>
                        <div class="contt4" style="border:none;">
                            <table border="0" cellpadding="0" cellspacing="0" class="auto contect">
                                <tr>
                                    <td style="border:none;">
                                        <font color="#00BFE9">评价方案一：</font><asp:RadioButton ID="rdoMiaoPing" Checked="true" style="border:none;"
                                            CssClass="ui-widget-content ui-corner-all" Text="交易完成立即评价【秒评】" GroupName="kim"
                                            runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" style="border:none;">
                                        <font color="#00BFE9">评价方案二：</font><asp:RadioButton ID="rdoBuyerRated" Text="买家评价以后评价" style="border:none;"
                                            CssClass="ui-widget-content ui-corner-all" runat="server" GroupName="kim" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" style="border:none;">
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;1：如果买家一直未评价,系统在交易完成后<asp:DropDownList ID="drpFangAn2Day" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn2Hour" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn2Minute" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                        </asp:DropDownList>
                                       分钟自动评价【抢评】【<font color="#00BFE9">都为 0 时不会评价</font>】
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;2：如果黑名单买家已评：<asp:RadioButton ID="rdoFangAn2NotAtuo" Text="不自动评价" Checked="true" style="border:none;"
                                            GroupName="11" runat="server" CssClass="ui-widget-content ui-corner-all" />&nbsp;<asp:RadioButton
                                                ID="rdoFangAn2AtuoGoodRate" Text="自动好评" GroupName="11" runat="server" CssClass="ui-widget-content ui-corner-all" style="border:none;" />&nbsp;<asp:RadioButton
                                                    ID="rdoFangAn2AtuoNureRate" GroupName="11" CssClass="ui-widget-content ui-corner-all" style="border:none;"
                                                    Text="自动中评" runat="server" />&nbsp;<asp:RadioButton ID="rdoFangAn2AtuoPoolRate" GroupName="11" style="border:none;"
                                                        CssClass="ui-widget-content ui-corner-all" Text="自动差评" runat="server" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="如果要给已评价的黑名单买家中差评,请输入中差评内容(请勿输入过激语言，淘宝有验证，否则无法评价成功）"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPoolRateContent" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                            TextMode="MultiLine" Width="550px" Height="30px" Text="亲不要随意给我们差评，谢谢！" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" style="border:none;">
                                       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;3：如果黑名单买家一直未评价,系统在交易完成后<asp:DropDownList ID="drpFangAn2BacklstDay" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn2BacklstHour" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn2BacklstMinute" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                        </asp:DropDownList>
                                        分钟自动评价【抢评】
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;【<font color="#00BFE9">都为 0 时不会评价</font>】</td>
                                    </tr>
                                <tr>
                                    <td style="border:none;">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="middle" style="border:none;">
                                        <font color="#00BFE9">评价方案三：</font><asp:RadioButton ID="rdoAutoRate" Text="总是在交易完成后" style="border:none;"
                                            CssClass="ui-widget-content ui-corner-all" runat="server" GroupName="kim" />&nbsp;<asp:DropDownList
                                                ID="drpFangAn3Day" runat="server">
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>11</asp:ListItem>
                                                <asp:ListItem>12</asp:ListItem>
                                                <asp:ListItem>13</asp:ListItem>
                                                <asp:ListItem>14</asp:ListItem>
                                            </asp:DropDownList>
                                        &nbsp;天&nbsp;<asp:DropDownList ID="drpFangAn3Hour" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>1</asp:ListItem>
                                            <asp:ListItem>2</asp:ListItem>
                                            <asp:ListItem>3</asp:ListItem>
                                            <asp:ListItem>4</asp:ListItem>
                                            <asp:ListItem>5</asp:ListItem>
                                            <asp:ListItem>6</asp:ListItem>
                                            <asp:ListItem>7</asp:ListItem>
                                            <asp:ListItem>8</asp:ListItem>
                                            <asp:ListItem>9</asp:ListItem>
                                            <asp:ListItem>10</asp:ListItem>
                                            <asp:ListItem>11</asp:ListItem>
                                            <asp:ListItem>12</asp:ListItem>
                                            <asp:ListItem>13</asp:ListItem>
                                            <asp:ListItem>14</asp:ListItem>
                                            <asp:ListItem>15</asp:ListItem>
                                            <asp:ListItem>16</asp:ListItem>
                                            <asp:ListItem>17</asp:ListItem>
                                            <asp:ListItem>18</asp:ListItem>
                                            <asp:ListItem>19</asp:ListItem>
                                            <asp:ListItem>20</asp:ListItem>
                                            <asp:ListItem>21</asp:ListItem>
                                            <asp:ListItem>22</asp:ListItem>
                                            <asp:ListItem>23</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;小时&nbsp;<asp:DropDownList ID="drpFangAn3Minute" runat="server">
                                            <asp:ListItem>0</asp:ListItem>
                                            <asp:ListItem>30</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;分钟自动评价【<font color="#00BFE9">都为 0 时不会评价</font>】
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="badp contect" style="display:none;float:left;margin-left:20px; width:940px;">
                                <tr>
                                    <td style="border:none;">
                                        <asp:CheckBox ID="cbBlakList" Text="自动把给我中差评的买家加入黑名单" runat="server" CssClass="ui-widget-content ui-corner-all" style="border:none;" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:CheckBox ID="cbAddBlacklstTuikuan" Text="把半年内有退款申请的买家加入黑名单" runat="server" style="border:none;"
                                            CssClass="ui-widget-content ui-corner-all" />
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="neirong contect" style="display:none;width:940px;">
                                <tr>
                                    <td style="width: 80px;border:none;">
                                        &nbsp;
                                    </td>
                                    <td colspan="3" align="left" style="border:none;">
                                        <asp:DropDownList ID="drpContentChoice" runat="server" Height="25px" Width="223px">
                                            <asp:ListItem Value="0">随机使用以下一条作为评价内容</asp:ListItem>
                                            <asp:ListItem Value="1">使用模板1作为评价内容</asp:ListItem>
                                            <asp:ListItem Value="2">使用模板2作为评价内容</asp:ListItem>
                                            <asp:ListItem Value="3">使用模板3作为评价内容</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        &nbsp;
                                    </td>
                                    <td style="border:none;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        评价模板1：
                                    </td>
                                    <td colspan="3" style="border:none;">
                                        <asp:TextBox ID="txtRateTemp1" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                            TextMode="MultiLine" Width="550px" Height="30px" Text="有您的支持我们会做得更好，欢迎您的再次光临！"
                                            runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        &nbsp;
                                    </td>
                                    <td style="border:none;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        评价模板2：
                                    </td>
                                    <td colspan="3" style="border:none;">
                                        <asp:TextBox ID="txtRateTemp2" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                            TextMode="MultiLine" Width="550px" Height="30px" runat="server" Text="亲们要收藏下我们店铺哟，谢谢您对我们的支持！"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        &nbsp;
                                    </td>
                                    <td style="border:none;">
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td style="border:none;">
                                        评价模板3：
                                    </td>
                                    <td colspan="3" style="border:none;">
                                        <asp:TextBox ID="txtRateTemp3" MaxLength="500" CssClass="ui-widget-content ui-corner-all"
                                            TextMode="MultiLine" Width="550px" Height="30px" runat="server" Text="尊敬的朋友，感谢您选购我们的商品以及长期对我们的支持！祝您购物愉快！(*^__^*) 嘻嘻！！"></asp:TextBox>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td style="border:none;">
                                    </td>
                                    <td colspan="3" style="border:none;">
                                        <asp:ImageButton ID="btnSaveRateConfig" runat="server" ImageUrl="~/Images/save.jpg"
                                            Width="80px" Height="25px" OnClick="btnSaveRateConfig_Click" />
                                        <asp:Label ID="lberror2" Font-Size="16px" Font-Bold="true" runat="server" ForeColor="#00BFE9"
                                            Text=""></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 80px;border:none;">
                                    </td>
                                    <td colspan="3" style="border:none;">
                                        说明：修改后要点【保存评价设置】。
                                    </td>
                                </tr>--%>
                            </table>
                        </div>
                         <table border="0" >
                                <tr>
                                    <td style="border:none;">
                                        <div style="padding-left:20px;margin-top:10px;float:left;margin-bottom:10px;color:#1EC4EB;">
                                                <span><asp:ImageButton ID="btnSaveRateConfig" runat="server" ImageUrl="~/Images/save.jpg"
                                                            Width="80px" Height="25px" OnClick="btnSaveRateConfig_Click" /><asp:Label ID="lberror2" Font-Size="14px"  runat="server" ForeColor="#00BFE9"
                                                                Text=""></asp:Label>&nbsp;</span>
                                    
                                            </div>
                                        </td>
                                    <td style="border:none;">
                                        <div style="padding-left:20px;margin-top:10px;float:left;margin-bottom:10px;color:#1EC4EB;">
                                                <span><span style="float:left;margin-top:8px; font-size:14px;">自动评价开关:</span><asp:ImageButton ID="imgBtnOpenRatingAtuo" runat="server" Width="95px" Height="31px"
                                                                ImageUrl="~/Win_Image/1close.png" OnClick="imgBtnOpenRatingAtuo_Click" />&nbsp;<asp:Label ID="Label2" Font-Size="14px"  runat="server" ForeColor="#00BFE9"
                                                                Text=""></asp:Label></span>
                                            </div>   
                                        </td>
                                    </tr>
                            </table>
                                            <%--<div style="padding-left:20px;margin-top:10px;float:left;margin-bottom:10px;color:#1EC4EB;">
                                                <span><asp:ImageButton ID="btnSaveRateConfig" runat="server" ImageUrl="~/Images/save.jpg"
                                                            Width="80px" Height="25px" OnClick="btnSaveRateConfig_Click" /><asp:Label ID="lberror2" Font-Size="14px"  runat="server" ForeColor="#00BFE9"
                                                                Text=""></asp:Label>&nbsp;</span>
                                    
                                            </div>
                                            <div style="padding-left:20px;margin-top:10px;float:left;margin-bottom:10px;color:#1EC4EB;">
                                                <span><span style="float:left;margin-top:8px; font-size:14px;">自动评价开关:</span><asp:ImageButton ID="imgBtnOpenRatingAtuo" runat="server" Width="95px" Height="31px"
                                                                ImageUrl="~/Win_Image/1close.png" OnClick="imgBtnOpenRatingAtuo_Click" />&nbsp;<asp:Label ID="Label2" Font-Size="14px"  runat="server" ForeColor="#00BFE9"
                                                                Text=""></asp:Label></span>
                                            </div>--%>
                         
                        
                    </div>
                    
                    <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 490px;
                        top: 520px; display: none; z-index: 9999;">
                        <h1>
                            <font color="white">系统评价中........</font></h1>
                    </div>
                    <div id="zhedang" style="background-image: url('../images/msgSend.gif'); width: 280px;
                        height: 13px; position: absolute; left: 490px; top: 540px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif);
                        z-index: 9999;">
                    </div>
                </div>
                 <script type="text/javascript">
                     document.getElementById("A2").className += ' NavSelected';
                 </script> 
            </div>
        </div>
    </div>
    </form>
</body>
</html>
