<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="CTCRM.home"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link type="text/css" href="CSS/demo.css" rel="Stylesheet" media="screen" />
    <link type="text/css" href="CSS/basic.css" rel="Stylesheet" media="screen" />
    <link href="CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
    <script src="Js/jquery.min.js"></script>
    <script src="Js/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="Js/easyui-lang-zh_CN.js"></script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <script language="javascript" type="text/javascript">    
        function doSave() {
            var valNick = $('#sellerSigName').val();
            var valPhone = $('#sellerCellphone').val();
            if (valNick == '') {
                alert('店铺签名不能为空!');
                $('#sellerSigName').focus();
                return;
            }
            if (valNick.length > 10) {
                alert('店铺签名不能超过10个字!');
                $('#sellerSigName').focus();
                return;
            }
            $PostAjax(
                   "POST",
                   "/handler/common.ashx",
                   "&nick=" + valNick + "&phone=" + valPhone,
                   "text",
                   function (jsonString) {
                       if (jsonString == '0') {
                           $.messager.alert('店铺管家', '手机号码格式不正确！','error');
                           return;
                       } if (jsonString == '1') {
                           $.messager.alert('店铺管家', '保存成功！');
                           return;
                       }
                   });
        }

        function SigNamePre()
        {
            var valNick = $('#sellerSigName').val();
            $('#lbPrveNick').html('【' + valNick + '】');
            
        }
    </script>
 <%--   <div id="dlg" class="easyui-dialog" title="店铺签名设置" style="width:545px;height:280px;padding:10px" data-options=" iconCls: 'icon-save',toolbar: '#dlg-toolbar',buttons: '#dlg-buttons'">
            <div class="ui-state-error ui-corner-all" style="width: 480px; margin-top: 2px;">
                <strong>注意:</strong> 店铺签名将作为短信签名,在短信内容前显示。请设置简短的店铺签名，能代表自己店铺名称及品牌形象.如<font color="red">XXX旗舰店、XXX专营店等</font>。
            </div>
            <div class="content">
                <div>
                     店铺昵称：
                </div>
                <div id="shopeName" class="shopeName" style="margin-left:85px;margin-top:-23px;">
                    <asp:Label ID="lbNick" runat="server" Font-Bold="true" Text=""></asp:Label>
                </div>
                <table>
                    <tbody>
                       
                        <tr>
                            <td>
                                签名设置：
                            </td>
                            <td>
                                <input type="text" style="width: 120px;" value='<%= sigName %>' name="sellerSigName" onkeyup="SigNamePre();" id="sellerSigName" class="ui-widget-content ui-corner-all" />
                                &nbsp;<font color="blue">店铺签名禁止夹带网址或者促销等词汇</font>&nbsp;<asp:Label
                                    ID="lbMsg" ForeColor="Red" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                签名预览：
                            </td>
                            <td>
                                <span id="lbPrveNick"><%= sigPrveName %></span>&nbsp;<%--<font color="blue">暂时采用固定签名的方式，自定义签名开通时间另行通知</font>--%>
                          <%--  </td>
                        </tr>
                        <tr>
                            <td>
                                手机号码：
                            </td>
                            <td>
                                <input type="text" style="width: 100px;" value='<%= cellPhone %>' name="sellerCellphone"  id="sellerCellphone" class="ui-widget-content ui-corner-all" />&nbsp;<font color="blue">便于及时监控短信账户余额</font>
                            </td>
                        </tr>        
                    </tbody>
                </table>
            </div>
	</div>
	<div id="dlg-buttons" style="text-align:center">
		<a href="javascript:void(0)" class="easyui-linkbutton" onClick="javascript:doSave()">保存</a>
		<a href="javascript:void(0)" class="easyui-linkbutton" onClick="javascript:$('#dlg').dialog('close')">关闭</a>
	</div>--%>--%>


    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>
                    软件首页</h4>
                <ul class="items">
                    <li class="on"><a href="#">软件首页</a></li>
                    <%--<li><a href="Help/updateLog.aspx">软件更新日志</a></li>   --%>        
                    <li><a href="SynData/downloads.aspx">数据同步</a></li>
                </ul>
            </div>
            <div class="hspot" style="margin-left:37px;">
                <div class="spot">
                    <h3>
                    </h3>
                    <ul class="spotc">
                        <li class="c1"><strong>客户数据全、准、细</strong><br />
                            09年开店以来所有客户数据，购买情况全记录，多维度划分客户。</li>
                        <li class="c2"><strong>会员等级，折扣分明</strong><br />
                            客户等级划分，老客户忠实客户享受低折扣，用优惠留住老客户。</li>
                        <li class="c3"><strong>智能营销，让客户轻松回头</strong><br />
                            智能营销，基于事件驱动机制的营销策略，真正做到活动精准推送。</li>
                        <li class="c4"><strong>店铺运营报表，会员统计分析</strong><br />
                            实时掌握店铺运营动态，会员地区、新老客户成交分析。</li>
                        <li class="c5"><strong>短信营销，效果显著</strong><br />
                            节日营销、周年庆营销、新品营销、聚划算营销。</li>
                        <li class="c6"><strong>会员关怀、订单自动催付</strong><br />
                            自动短信催付，会员生日提醒，发货提醒，提醒内容自由控制，效果显著。</li>
                         <li class="c7"><strong>订单批量打印，批量发货</strong><br />
                            电子面单打印、供销平台打印、合并订单、促销活动发货单打印。</li>
                        <li class="c8"><strong>自动评价、秒评、抢评</strong><br />
                            自动评价，最后一分钟抢评，秒评，差评拦截，效果显著。</li>
                    </ul>
                </div>
                <div class="changelog" style="height:435px">
                    <h3>
                        系统公告</h3>
                    <ul>
                        <li><em>[2016-03-25]</em>订单打印上线.</li>
                        <li><em>[2015-12-29]</em>短信营销恢复自定义签名.</li>
                        <li><em>[2015-11-16]</em>物流提醒签名修改.</li>
                        <li><em>[2015-06-4]</em>短信营销效果追踪.</li>
                        <li><em>[2015-03-18]</em>优化数据同步.</li>
                        <li><em>[2014-9-29]</em>增加差评防御管理.</li>
                        <li><em>[2014-7-22]</em>增加自动评价管理.</li>             
                    </ul>
                </div>
               <%-- <div class="changelog">
                    <h3>
                        使用教程</h3>
                    <ul>
                        <li><a href="http://bangpai.taobao.com/group/thread/14992769-277692074.htm?spm=0.0.0.40.c43c2b"
                            target="_blank">
                            <img src="Images/jiaocheng.jpg" /></a></li>
                    </ul>
                </div>--%>
            </div>
           <%-- <div class="hshare">
                <h3>
                    客户案例分析</h3> 
                <div class="c">
                    <img src="images/h_share.jpg" width="970" height="308" /></div>
            </div>--%>
        </div>
         <script type="text/javascript">
             document.getElementById("FirstPage").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
