<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tongji.aspx.cs" Inherits="CTCRM.WebForm1" %>

<script language="javascript" type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   

</head>
<body>
    <form runat="server">
    <asp:TextBox ID="TextBox1" runat="server" Height="116px" Width="686px" 
        TextMode="MultiLine"></asp:TextBox><br />
    输入文本内容字数：<asp:Label ID="Label1" runat="server" Text=""></asp:Label>个
     
    <p>
        <asp:Button ID="Button1" runat="server" Text="计算" onclick="Button1_Click" />
    </p>
    </form>
</body>
</html>
