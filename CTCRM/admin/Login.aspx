<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CTCRM.admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <title>管理员控制台登录</title>
    <link rev="stylesheet" media="all" href="style/admin.css" type="text/css" rel="stylesheet">
      <script type="text/javascript">
        function VerifyCodeChange(obj) {
            (typeof obj == "string" ? document.getElementById(obj) : obj).src = "../VerifyCode.aspx?Date=" + new Date().getSeconds();
        }
    </script>
</head>
<body class="bodyBj">
    <form id="form1" runat="server" method="post">
    <div class="login">
        <div class="bjt">
            <table>
                <tr>
                    <th>
                        账号：
                    </th>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server" CssClass="inpt1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                        密码：
                    </th>
                    <td>
                        <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" CssClass="inpt1"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th>
                    </th>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="" CssClass="inpt2" OnClick="btnLogin_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
