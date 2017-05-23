<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signModify.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.signModify" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />
    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="message.aspx">短信营销</a></li>
                    <li><a href="Smart/index.aspx">智能营销</a></li>
                    <li><a href="sendMsg.aspx">自有号码群发</a></li>
                    <li><a href="Smart/msgHis.aspx">发送记录</a></li>
                    <li><a href="shortLink.aspx">短链接生成</a></li>
                    <li class="on"><a href="signModify.aspx">修改签名</a></li>
                </ul>
            </div>--%>
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4" style="margin-left: 10px">
                        <div class="smallTitle" style="height: 45px">
                            <table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                         自定义短信签名,支持物流提醒和短信促销活动！
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="content">
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <table  border="0" id="Table3" style="border-collapse: collapse;">
                                                    
                                                    <tr>
                                                        <td>
                                                            店铺签名:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbSignPrv" Font-Bold="true" runat="server" Text="" Font-Size="18px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width:150px;">
                                                            店铺签名：
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSign" runat="server" CssClass="ui-widget-content ui-corner-all" Width="168px"></asp:TextBox>
                                                        </td>
                                                    </tr>                      
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnGenerate" runat="server" Text="修改保存" Width="118px" Height="29px" OnClick="btnGenerate_Click" 
                                                                 />&nbsp;<asp:Label ID="lbMsg" runat="server"
                                                                    Font-Bold="true" Font-Size="18px" Text="" ForeColor="Blue"></asp:Label>
                                                        </td>
                                                    </tr>                                                                                      
                                                </table>
                                            </div>
                                            <div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                    </div>
                </div>                
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>

