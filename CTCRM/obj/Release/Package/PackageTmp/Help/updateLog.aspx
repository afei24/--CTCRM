<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="updateLog.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    Inherits="CTCRM.Help.updateLog" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
   <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/css.css" rel="stylesheet" type="text/css" />
    <base target="_self" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>软件首页</h4>
                <ul class="items">
                    <li><a href="../home.aspx">软件首页</a></li>
                    <li class="on"><a href="updateLog.aspx">软件更新日志</a></li>
                    <li><a href="http://bangpai.taobao.com/group/thread/14992769-277692074.htm?spm=0.0.0.40.c43c2b"
                        target="_blank">软件使用教程</a></li>
                    <li ><a href="../SynData/downloads.aspx">数据同步</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="title2">
                        店铺管家软件升级日志
                    </div>
                    <div class="contt4" style="margin-left: 10px">
                        <table>
                            <tbody>
                                 <tr>
                                    <td align="left" style="width: 60%">【2014-10-8】增加手机详情功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-9-29】增加差评防御功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-7-22】增加自动评价功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-7-10】增加退款提醒功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-7-3】增加回款提醒功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-7-1】增加延迟发货提醒功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-5-11】增加黑名单功能.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-4-21】到货提醒功能修复.
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2014-4-13】短信群发增加按天数过滤。
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-11-16】增加短信内容发送明细查看！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-10-21】增加给线下店铺会员群发短信功能！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-10-17】增加会员黑名单功能，群发短信自动过滤！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-07-21】短信营销增加按购买频率搜索，增加短信内容保存等！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-07-08】物流提醒增加到货提醒！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-07-03】会员资料导出增加按消费金额！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-06-29】增加短信群发给指定宝贝的买家会员！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-06-8】会员关怀升级完成！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-06-8】智能营销功能升级完成！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-06-2】软件首页升级！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-28】增加短信内容字数统计！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-25】优化短信发送进度显示
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-21】增加过滤失效买家条件，增加短信内容动态添加买家姓名和昵称！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-18】同步数据增加日期范围！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-14】会员提醒功能增加自定义提醒内容！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-13】增加短信群发时店铺签名！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-05-7】优化会员关怀模块，增加会员生日提醒！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-28】增加手动添加会员功能！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-27】会员管理列表中增加了买家会员的旺旺账号！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-25】短信营销功能增加单独过滤会员！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-25】增加一键下载到桌面功能！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-18】会员导出功能优化！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2013-04-15】短信营销功能正式上线，历史订单导入BUG修复！
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width: 60%">【2012-11-18】店铺管家正式上线！
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            document.getElementById("FirstPage").className += ' NavSelected';
        </script>
    </div>

</asp:Content>
