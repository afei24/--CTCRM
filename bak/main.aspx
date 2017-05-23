<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="main.aspx.cs" Inherits="CTCRM.main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>店铺管家_会员管理_自动评价_发货提醒_短信关怀_手机详情_会员关怀_店铺运营报告_会员关系管理二次营销</title>
    <link href="WIN_CSS/common.css" rel="stylesheet" />
    <script src="Js/jquery-1.7.1.min.js"></script>
    <script src="win_js/win_main.js" type="text/javascript"></script>

    <%--<script type="text/javascript">
        var userName = "<%=userName%>";
        $(function () {
            $(".f_user").text(userName);
        }
            )
    </script>--%>

</head>
<body>
    <form id="form1" runat="server">
    </form>

    <table class="tb_frame">
        <tr>
            <td class="tb_left">我是左边</td>
            <td class="tb_rifht">我是右边</td>
        </tr>


    </table>

    <div class="div_topside">
        <div class="div_left_navigation">
            <div class="div_logo">
                <img src="Images/logo.jpg" />
            </div>
            <div class="div_user">
                <div class="div_user_img">
                    <ul style="margin: 0; padding:0; background-color: #2F3A4C;">
                        <li class="li_user">
                            <img class="img_touxiang" src="/Images/touxiang.PNG" />&nbsp<b class="f_user"><%=userName%></b></li>
                    </ul>
                </div>
              
            </div>
            <ul class="ul_left_navigation">
                <li class="li_navigation" id="home">
                    <img class="img_main" src="Win_Image/首页-首页.png" />首页</li>
                <li class="li_navigation" id="allmember">
                    <img class="tubiao" id="Win_Image/会员" src="Win_Image/会员.png" />客户管理<img class="三角形左" src="Win_Image/三角形左.png" /></li>
                <li class="li_navigation2 allmember" id="allmember.aspx">客户管理</li>
                <li class="li_navigation2 allmember" id="CRankNew.aspx">客户等级划分</li>
                <li class="li_navigation2 allmember" id="Li5">分组管理</li>
                <li class="li_navigation2 allmember" id="Li6">标签管理</li>
                <li class="li_navigation2 allmember" id="blacklist.aspx">黑名单管理</li>
                <li class="li_navigation2 allmember" id="SynData/buyerExport.aspx">客户导出</li>
                <li class="li_navigation" id="index">
                    <img class="tubiao" id="Win_Image/物流" src="Win_Image/物流.png" />物流提醒<img class="三角形左" src="Win_Image/三角形左.png" /></li>
                <li class="li_navigation2 index" id="member/index.aspx?type=all">会员关怀</li>
                <li class="li_navigation2 index" id="member/reminderHis.aspx">提醒记录</li>
                <li class="li_navigation" id="message">
                    <img class="tubiao" id="Win_Image/营销" src="Win_Image/营销.png" />短信营销<img class="三角形左" src="Win_Image/三角形左.png" /></li>
                <li class="li_navigation2 message" id="message.aspx">短信营销</li>
                <li class="li_navigation2 message" id="Smart/index.aspx">智能营销</li>
                <li class="li_navigation2 message" id="sendMsg.aspx">短信群发</li>
                <li class="li_navigation2 message" id="Smart/msgHis.aspx">发送记录</li>
                <li class="li_navigation2 message" id="shortLink.aspx">短连接生成</li>
                <li class="li_navigation2 message" id="signModify.aspx">修改签名</li>
                <li class="li_navigation" id="messageSetting">
                    <img class="tubiao" id="Win_Image/短信" src="Win_Image/短信.png" />短信订购<img class="三角形左" src="Win_Image/三角形左.png" /></li>
                <li class="li_navigation2 messageSetting" id="messageSetting.aspx">短信订购</li>
                <li class="li_navigation" id="rateSetting">
                    <img class="tubiao" id="Win_Image/评价" src="Win_Image/评价.png" />自动评价<img class="三角形左" src="Win_Image/三角形左.png" /></li>
                <li class="li_navigation2 rateSetting" id="rate/rateSetting.aspx">自动评价</li>
                <li class="li_navigation2 rateSetting" id="rate/blacklist.aspx">黑名单</li>
                <li class="li_navigation2 rateSetting" id="rate/badList.aspx">中差评查询</li>
                <li class="li_navigation2 rateSetting" id="rate/ratingLog.aspx">评价日志</li>
                <li class="li_msg" id="li1"><div class="div_user_info"> 当前版本：<%=orderVersion%></div></li>
                <li class="li_msg" id="li2"><div class="div_user_info">短信数量:<%=msgCount%></div> </li>
                <li class="li_msg" id="li3"><div class="div_user_info">到期时间:<%=deadline%></div></li>
                <li class="li_msg" onclick="xuyue();"><div class="div_user_info"  style="color: #04ADD3;">点击续约</div> </li>
            </ul>
        </div>

        <div class="div_right_top">
            <iframe class="iframe_main" src="/WIN_Aspx/home.aspx"></iframe>
        </div>

    </div>

    <%--<div id="footer" style="text-align: center; bottom: 0; position: fixed; left: 550px;">
        地址：成都市高新区天府软件园D区DB058 邮编：610000 电话：18502840601 旺旺：<a href="http://www.taobao.com/webww/ww.php?ver=3&amp;touid=ljhkim6&amp;siteid=cntaobao&amp;status=1&amp;charset=utf-8" target="_blank"><img alt="点击这里给我发消息" border="0" src="http://amos.alicdn.com/realonline.aw?v=2&amp;uid=ljhkim6&amp;site=cntaobao&amp;s=1&amp;charset=utf-8" /></a>
        <br />
        本网站建议您使用分辨率1024*768 火狐浏览器&nbsp;[蜀ICP备12026451号]
    </div>--%>
</body>
</html>
