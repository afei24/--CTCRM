<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="signModify.aspx.cs" Inherits="CTCRM.WIN_Aspx.signModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
        .mod_tb td {
            border: none;
        }

        table td{
            background-color: white;
           border:0px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="homewrap">
            <div class="homediv">
                <div class="righter">
                    <div class="pDiv2">
                        <%--<div style="width:100%;border-bottom:1px solid #cec8c8;height:40px;line-height:40px;font-size :20px;">
                           &nbsp; <strong class="">短信营销 >>修改签名</strong>
                        </div>
                        
                          <hr />--%>
                       <div class="div_zhandian" style="border-bottom:1px solid #cec8c8;vertical-align:middle;height:30px;">
                            <span class="zhandian">短信营销 >>修改签名</span>
                        </div>
                        <div class="contt4" style="border:none;">
                            <div class="div_tishi">
                            <p>温馨提示:该签名用于短信营销和群发，不用于物流提醒！</p>
                        </div> 
                        <table style="width: 95%; margin: auto; margin-top: 10px; border:0px;" >
                            <tr>
                                <td style="width: 20%; text-align: center; height: 40px;">店铺签名：</td>
                                <td style="width: 80%; text-align: left; height: 40px;">
                                    <asp:Label ID="lbSignPrv" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; text-align: center; height: 40px;">新签名：</td>
                                <td style="width: 80%; text-align: left; height: 40px;">
                                    <asp:TextBox ID="txtSign" runat="server" CssClass="ui-widget-content ui-corner-all" Width="168px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 20%; text-align: right; height: 40px;"></td>
                                <td style="width: 80%; text-align: left; height: 40px;">
                                    <asp:Button ID="btnGenerate" runat="server" Text="修改保存" Width="118px" Height="29px" OnClick="btnGenerate_Click" BackColor="#0AC2EB" BorderColor="#0AC2EB" ForeColor="White" /><asp:Label ID="lbMsg" runat="server"
                                        Font-Bold="true" Font-Size="18px" Text="" ForeColor="#0AC2EB"></asp:Label>
                                </td>
                            </tr>
                        </table>

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
