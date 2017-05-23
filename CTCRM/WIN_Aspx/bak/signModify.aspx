<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signModify.aspx.cs" Inherits="CTCRM.WIN_Aspx.signModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <link href="../CSS/easyui.css" rel="stylesheet" />
    <link href="../CSS/icon.css" rel="stylesheet" />
    <style type="text/css">
         .mod_tb td
        {
            border:none;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
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
                    <div class="div_zhandian">
                        <span class="zhandian">短信营销 >> 修改签名</span>
                    </div>
                    <div class="contt4" style="margin-left: 10px">
                        <div class="div_tishi">
                                         <p>温馨提示:</p><br /><p style="padding-left:20px;">自定义短信签名,支持物流提醒和短信促销活动！</p>
                        </div>
                        <div class="content">
                            <table class="mod_tb" style="border:none">
                                <tbody style="border:none">
                                    <tr>
                                        <td colspan="2" style="border:none;background-color:white">
                                            <div style="border:none">
                                                <table  border="0" id="Table3" style="border:none">
                                                    
                                                    <tr style="border:none">
                                                        <td style="padding-left:40px;">
                                                            店铺签名:
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbSignPrv" Font-Bold="true" runat="server" Text="" Font-Size="18px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="border:none">
                                                        <td style="width:150px;padding-left:40px;">
                                                            店铺签名：
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtSign" runat="server" CssClass="ui-widget-content ui-corner-all" Width="168px"></asp:TextBox>
                                                        </td>
                                                    </tr>                      
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnGenerate" runat="server" Text="修改保存" Width="118px" Height="29px" OnClick="btnGenerate_Click"  BackColor="#0AC2EB" BorderColor="#0AC2EB" ForeColor="White"
                                                                 />&nbsp;<asp:Label ID="lbMsg" runat="server"
                                                                    Font-Bold="true" Font-Size="18px" Text="" ForeColor="#0AC2EB"></asp:Label>
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
    </form>
</body>
</html>
