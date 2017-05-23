<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sysDataOpen.aspx.cs" Inherits="CTCRM.admin.memberData.sysDataOpen" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .style1
        {
            width: 192px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                同步开关管理</p>
        </div>
        <!-- title End -->
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label2" runat="server" Text="同步操作开启" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="txtTitle" Width="211px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 300px;">
                        <asp:Label ID="lbMsg" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 开 启 " OnClick="btnSearch_Click"
                            CssClass="pinpt4" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label12" runat="server" Text="删除登录账户" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TextBox5" Width="211px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 300px;">
                        <asp:Label ID="Label13" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="Button11" runat="server" Text="删 除"  CssClass="pinpt4" OnClick="Button11_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <!-- jsuo End -->
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label3" runat="server" Text="同步数据SESSION查询" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TextBox1" Width="363px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text=" 搜  索 " CssClass="pinpt4" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1" colspan="3">
                        <asp:Label ID="lbSession" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label1" runat="server" Text="同步数据" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TextBox2" Width="211px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                    <td style="width: 90px;">
                        卖家Session：
                    </td>
                    <td>
                        <asp:TextBox ID="txtSession" runat="server" Width="451px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        手工同步店铺所有客户数据<asp:Button ID="Button2" runat="server" Text="读取会员API" Height="30px"
                            Width="121px" OnClick="Button2_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        同步店铺所有订单<asp:Button ID="Button3" runat="server" Text="读取订单API" Height="30px" Width="121px"
                            OnClick="Button3_Click" /> <asp:Button ID="Button10" runat="server" Text="Old读取订单API" Height="30px" Width="121px" OnClick="Button10_Click"
                             />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Label ID="lbError" runat="server" Text="" Font-Bold="true" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label4" runat="server" Text="会员数据查询" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TextBox3" Width="211px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button4" runat="server" Text="New所有会员个数查询" Height="30px" 
                            Width="143px" onclick="Button4_Click"
                            /><asp:Label ID="Label5" Font-Bold="true" Font-Size="Large"
                                ForeColor="Blue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button5" runat="server" Text="New有效电话会员查询" Height="30px" 
                            Width="136px" onclick="Button5_Click"
                           />
                        <asp:Label ID="Label6" runat="server" Text="" Font-Bold="true" Font-Size="Large"
                            ForeColor="Blue"></asp:Label>
                    </td>
                </tr>

                 <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button8" runat="server" Text="所有会员个数查询" Height="30px" 
                            Width="146px" OnClick="Button8_Click" 
                            /><asp:Label ID="Label10" Font-Bold="true" Font-Size="Large"
                                ForeColor="Blue" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button9" runat="server" Text="有效电话会员查询" Height="30px" 
                            Width="121px" OnClick="Button9_Click" 
                           />
                        <asp:Label ID="Label11" runat="server" Text="" Font-Bold="true" Font-Size="Large"
                            ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        
        <div class="jsuo">
            <table width="100%">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="Label7" runat="server" Text="历史订单同步" Font-Bold="true" Font-Size="13px"></asp:Label>
                    </td>
                </tr>
                <tr align="left">
                    <td style="width: 65px;">
                        卖家昵称：
                    </td>
                    <td class="style1">
                        <asp:TextBox ID="TextBox4" Width="211px" CssClass="pinpt3" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                <td>
                订单报表CSV文件：
                </td>
                    <td  align="left">
                       <asp:FileUpload ID="fileOrderUpload" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Button ID="Button7" runat="server" Text="导入历史订单" Height="30px" 
                            Width="121px" onclick="Button7_Click" 
                           />
                        <asp:Label ID="Label9" runat="server" Text="" Font-Bold="true" Font-Size="Large"
                            ForeColor="Blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        强制结束同步(卖家)：<asp:TextBox ID="txtSellerName" runat="server"></asp:TextBox>
                        <asp:Button ID="Button6" runat="server" Text="一键结束" Height="38px" Width="123px" OnClick="Button6_Click" /><asp:Label ID="Label8" Font-Bold="true" ForeColor="Red" Font-Size="Large" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
    </form>
</body>
</html>
