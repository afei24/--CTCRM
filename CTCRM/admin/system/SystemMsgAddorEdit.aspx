<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMsgAddorEdit.aspx.cs" Inherits="CTCRM.admin.SystemMsgAddorEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link  media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link  media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <script src="../../Js/common.js" charset="GB2312"></script>
    <script src="../../win_js/SystemMsg.js" charset="GB2312"></script>
    <script src="../../Js/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        
        </script>
    <style type="text/css">
        .nrkuai
        {
            margin-left:30px;
        }
        .msg
        {
            width:40%;
            border:none;
        }
            .msg td
            {
                border:none;
                padding-top:10px;
                font-size:14px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="HiddenField1" Value="" runat="server" />
    <div class="right">
        <div class="title">
            <p>
                编辑系统公告管理</p>
        </div>
        <div class="nrkuai">
            <table class="msg">
                <tbody>
                    <tr>
                        <td style="border:none;">
                            <span>系统内容：</span>
                            </td>
                        <td style="border:none;width:80%">
                            <asp:TextBox ID="TextBoxMsg" runat="server" Width="414px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                        <td style="border:none;">
                            <span>标题：</span>
                            </td>
                        <td style="border:none;width:80%">
                            <asp:TextBox ID="TextBoxLink" runat="server" Width="412px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                        <td style="border:none;">
                            <span>状态：</span>
                            </td>
                        <td style="border:none;width:80%">
                            <asp:DropDownList ID="DropDownListStatus" runat="server" Width="100px">
                                <asp:ListItem Value="1">显示</asp:ListItem>
                                <asp:ListItem Value="0">隐藏</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        </tr>
                    <tr>
                        <td style="border:none;">
                            <asp:ImageButton ID="ButtonOk" runat="server" ImageUrl="../../Images/save.jpg" OnClick="ButtonOk_Click" />
                            </td>
                        <td style="border:none;">
                            <asp:ImageButton ID="ButtonCancle" runat="server" ImageUrl="../../Win_Image/cancle.png" OnClick="ButtonCancle_Click" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
    
    </div>
    </form>
</body>
</html>
