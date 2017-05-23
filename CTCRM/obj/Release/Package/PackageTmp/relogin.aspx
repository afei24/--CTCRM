<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="relogin.aspx.cs" Inherits="CTCRM.relogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>店铺管家CRM</title>
    <link href="CSS/common.css" rel="stylesheet" type="text/css" />
      <style type="text/css">
          <!--
          .memu_box {height:29px; margin-bottom:20px;}
          -->
      </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="soft_body" width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr class="soft_body_td">
              <td class="soft_body_right">
                  <div class="soft_workspace_title soft_workspace_title_index">
                      <h3><span class="index"></span>系统登陆</h3>
                  </div>
                  <div class="soft_workspace"> 
                      <div class="memu_box"><a class="onlymenu" href="https://oauth.taobao.com/authorize?response_type=code&client_id=21088197&redirect_uri=http://crm.new9channel.com/home.aspx">点击此处进入店铺管家CRM</a></div>
                      <div class="percentage_box">
                          <div class="percentage_text">
                              <strong class="fontsize14">登陆提示：</strong>
                              <p style="padding-top:5px;">您将跳转至淘宝网站登录后，通过授权使用该软件</p>
                              <!--<ul class="pl12" style="padding-top:5px;">
                                <li>1,&nbsp;尝试刷新本页面。</li>
                                <li>2,&nbsp;点击屏幕右上角的“联系我们”，我们的客服人员将会给你专业的咨询与帮助。</li>
                              </ul>-->
                          </div>
                      </div>

                  </div>
              </td>
          </tr>
      </table>
    </div>
        <script type="text/javascript">
            if (top != self) {
                if (top.location != self.location)
                    top.location = self.location;
            }
  </script>
    </form>
</body>
</html>
