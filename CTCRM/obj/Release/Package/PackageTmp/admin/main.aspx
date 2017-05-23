<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="CTCRM.admin.main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>后台管理系统</title>
     <link rev="stylesheet" media="all" href="style/admin.css" type="text/css" rel="stylesheet" />
</head>
<frameset id="setMain" cols="210,*" frameborder="NO" border="0" framespacing="0" >
  <frame src="Menu.aspx" name="leftFrame" scrolling="no">
  <frame src="message/sendHis.aspx" name="rightFrame" scrolling="yes" noresize>
</frameset>
<body class="bodyBj1">
</body>
</html>
