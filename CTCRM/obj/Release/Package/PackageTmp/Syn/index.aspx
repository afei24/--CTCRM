<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    Inherits="CTCRM.Syn.index" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />

    <script type="text/javascript">
	function createXMLHttpRequest() {
		var ajaxReq;
		if (window.ActiveXObject) {
			ajaxReq = new ActiveXObject("Microsoft.XMLHTTP");
		} else if (window.XMLHttpRequest) {
			ajaxReq = new XMLHttpRequest();
		} else {
			alert("浏览器不支持ajax请求");
			return null;
		}
		return ajaxReq;
	}
	function getSession() {
		var appkey = document.getElementById("appkey").value;
		if (appkey == null || appkey == "") {
			alert("请填入appkey");
			return;
		} else {
			document.getElementById("getSession").href = "http://container.api.taobao.com/container?appkey="
					+ appkey;
			//alert("value:"+document.getElementById("getSession").href);
		}
	}
	function auth() {
		var ajaxReq = createXMLHttpRequest();
		if (ajaxReq == null) {
			alert("浏览器不支持ajax请求");
			return;
		}
		var appkey = document.getElementById("appkey").value;
		if (appkey == null || appkey == "") {
			alert("请填入appkey");
			return;
		}
		var secret = document.getElementById("secret").value;
		if (secret == null || secret == "") {
			alert("请填入secret");
			return;
		}
		var session = document.getElementById("session").value;
		if (session == null || session == "") {
			alert("请填入session");
			return;
		}
		var param = "appkey=" + appkey + "&secret=" + secret + "&session="
				+ session;
		var url = "permit?" + param;
		ajaxReq.open("GET", url, true);
		ajaxReq.send(null);
		ajaxReq.onreadystatechange = function() {
			if (ajaxReq.readyState == 4) {
				if (ajaxReq.status == 200) {
					var value = ajaxReq.responseText;
					if (value == "success") {
						var getData = document.getElementById("getData");
						getData.href = "getData?" + param;
						getData.style.display = "block";
					} else {
						alert("授权错误:" + value);
					}
				}
			}
		}
	}
    </script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 570px">
        <div class="infoArea">
            <div class="smallTitle">
                主动通知
            </div>
            <div class="content">
                <center>
                    <h1>
                        第二步，主要完成授权（调用taobao.increment.customer.permit），启动comet服务接收消息</h1>
                    <table align="center">
                        <tr>
                            <td align="left">
                                第一步：请填入appkey：<input type="text" id="appkey" name="appkey" onmouseout="getSession()" /><br>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                第二步：<a href="" id="getSession" name="getSession" target="_black">获取sessionkey</a>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                第三步：使用获取到的sessionkey调用taobao.increment.customer.permit接口，使得appkey能接收这个用户的消息
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;请填入:
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;secret：<input type="text" id="secret"
                                    name="secret" />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;sessionkey：<input type="text" id="session"
                                    name="session" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <input type="button" value="授权" onclick="auth()" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <a id="getData" name="getData" href="" target="_black" style="display: none;">获取数据</a>
                            </td>
                        </tr>
                    </table>            
                </center>
            </div>
        </div>
    </div>
</asp:Content>
