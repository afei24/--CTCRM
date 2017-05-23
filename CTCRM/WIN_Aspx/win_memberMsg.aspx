<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="win_memberMsg.aspx.cs" Inherits="CTCRM.WIN_Aspx.win_memberMsg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../WIN_CSS/win_memberMsg.css" rel="stylesheet" type="text/css" />
    <link href="../WIN_CSS/control.css" rel="stylesheet" />
    <link href="../../WIN_CSS/msg_div.css" rel="stylesheet" />
    <link href="../WIN_CSS/SMSAlter.css" rel="stylesheet" />
    <title>会员短信群发</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_father">

            <%--<div class="tiltle">您现在所在的位置：短信管理>>会员短信群发</div>--%>
            <div class="div_zhandian" style="border-bottom: 1px solid #cec8c8; vertical-align: middle; height: 40px; line-height: 40px; font-size: 20px;">
                &nbsp;<strong>短信群发 >>会员短信群发</strong>
            </div>
            <%--<hr class="hr_01" />--%>
            <br />

           <div class="div_tishi" style="color: #00BFE9;">
                <p>温馨提示:</p>
                <p style="padding-left: 20px;">1.为避免打扰买家，短信的发送时间段为早上9点到晚上8点，如果给您带来不便，敬请谅解！</p>
                <p style="padding-left: 20px;">2.如果收不到短信请查看是否被手机软件拦截，是否停机，可以联系在线客服排查问题，谢谢您的使用！</p>
            </div>

            <div class="content">
                <p style="padding-left: 30px;">注意：请先选择群发对象再群发短信。如果会员为空，请先去<a href="../SynData/downloads.aspx" style="color: #00BFE9;">数据同步</a>，同步会员资料。</p>
                <table class="tab_01">
                    <tr>
                        <td class="td_01">群发对象：</td>

                        <td class="td_02">
                            <div class="div_bt_01" id="memberSearch">
                                已选择<strong style="color: yellow" id="strong_member">0</strong>个会员
                                <img class="arrow" src="../Win_Image/三角形下.png" />
                            </div>
                            <div class="div_allmember">
                                <table class="tab_02">
                                    <tr>

                                        <td style="text-align: right;" colspan="2">请填写好查询条件后查询
                                            <input type="button" value="开始查询" onclick="searchMember()" />
                                            <input type="button" value="查询结果(0)" id="bt_ret" onclick="showRet()" />&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">买家昵称：<input type="text" id="txt_nick" placeholder="不填写默认查询全部会员" />
                                        </td>
                                        <td class="td_02">会员级别：
                                            <select id="s_level">
                                                <option value="all">全部</option>
                                                <option value="0">潜在会员</option>
                                                <option value="1">普通会员</option>
                                                <option value="2">高级会员</option>
                                                <option value="3">Vip会员</option>
                                                <option value="4">至尊Vip会员</option>
                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">所在地区：
                                            <select id="s_area">
                                                <option value="all">全部</option>
                                                <option value="北京">北京市</option>
                                                <option value="上海">上海市</option>
                                                <option value="天津">天津市</option>
                                                <option value="重庆">重庆市</option>
                                                <option value="河北">河北省</option>
                                                <option value="山西">山西省</option>
                                                <option value="内蒙古">内蒙古自治区</option>
                                                <option value="辽宁">辽宁省</option>
                                                <option value="吉林">吉林省</option>
                                                <option value="黑龙江">黑龙江省</option>
                                                <option value="江苏">江苏省</option>
                                                <option value="浙江">浙江省</option>
                                                <option value="安徽">安徽省</option>
                                                <option value="福建">福建省</option>
                                                <option value="江西">江西省</option>
                                                <option value="山东">山东省</option>
                                                <option value="河南">河南省</option>
                                                <option value="湖北">湖北省</option>
                                                <option value="湖南">湖南省</option>
                                                <option value="广东">广东省</option>
                                                <option value="广西">广西壮族自治区</option>
                                                <option value="海南">海南省</option>
                                                <option value="贵州">贵州省</option>
                                                <option value="四川">四川省</option>
                                                <option value="西藏">西藏自治区</option>
                                                <option value="陕西">陕西省</option>
                                                <option value="甘肃">甘肃省</option>
                                                <option value="宁夏">宁夏回族自治区</option>
                                                <option value="青海">青海省</option>
                                                <option value="新疆">新疆维吾尔自治区</option>
                                                <option value="香港">香港特别行政区</option>
                                                <option value="澳门">澳门特别行政区</option>
                                                <option value="台湾">台湾省</option>
                                                <option value="其它">其它</option>
                                            </select>
                                        </td>
                                        <td class="td_02">交易频率：
                                            <select id="s_interval">
                                                <option value="all">全部</option>
                                                <option value="3">3月未成交</option>
                                                <option value="6">半年未成交</option>
                                                <option value="12">一年未成交</option>
                                            </select></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">交易时间：<input type="date" id="tbx_trade_start" />
                                            至&nbsp;<input type="date" id="tbx_trade_end" /></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">交易额度：<input type="number" id="txt_money01" />
                                            至&nbsp;<input type="number" id="txt_money02" /></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">宝贝件数：<input type="number" id="txt_good_count01" />
                                            至&nbsp;<input type="number" id="txt_good_count02" /></td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">过滤最近：
                                            <select id="s_day">
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                                <option value="4">5</option>
                                                <option value="4">6</option>
                                                <option value="4">7</option>
                                                <option value="4">10</option>
                                            </select>
                                            天内发送过短信的买家</td>
                                    </tr>
                                    <tr>
                                        <td class="td_01" colspan="2">购买次数：<input type="number" id="txt_buyCount" />
                                            次的买家</td>
                                    </tr>
                                    <tr>
                                        <td class="td_01">
                                            <input type="checkbox" id="cbx_comment" checked="checked" />过滤中差评买家 </td>
                                        <td class="td_02">
                                            <input type="checkbox" id="cbx_blacklist" checked="checked" />过滤黑名单买家</td>
                                    </tr>
                                </table>

                                <div class="div_members">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="text-align: left;"></td>
                                            <td style="text-align: right;">
                                                <input type="button" onclick="divHide()" value="收起" />
                                                <input type="button" onclick="showRet1()" value="<<返回" /></td>
                                        </tr>
                                    </table>
                                    <div class="tab_memberList"></div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_01"></td>
                        <td class="td_02"></td>
                    </tr>
                    <tr>
                        <td class="td_01" style="height: 150px; line-height: 150px">短信内容：</td>
                        <td class="td_02">
                            <textarea class="textarea_01" placeholder="短信实际长度是'标签'+'短信内容'+'退订回N'的总字数" ></textarea>
                            <div style="font-size: small;">签名：<strong class="strong_userName" style="color: blue"><%= userNick %></strong>，营销追加：<strong style="color: blue">退订回N</strong> </div>
                            &nbsp;<div style="font-size: small">总计 <strong class="textCount" style="color: red">0</strong> 个文字计费 <strong style="color: red" class="cost">0</strong> 条短信，总共扣除 <strong style="color: red" class="allCost">0</strong> 条短信</div>
                        </td>

                    </tr>
                    <tr>
                        <td class="td_01"></td>
                        <td class="td_02"></td>
                    </tr>
                    <tr>
                        <td class="td_01">辅助工具： </td>
                        <td class="td_02">
                            <table>
                                <tr>
                                    <td>
                                        <div class="msgTemp" title="1" style="color: #767676;">短信模版</div>
                                    </td>
                                    <td>
                                        <div class="shortUrl" style="color: #767676; cursor: pointer; margin-left: 10px;">缩短网址</div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_01"></td>
                        <td class="td_02">
                            <a href="../Js/jquery-1.7.1.min.js"></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="td_01"></td>
                        <td class="td_02">
                            <div class="bt_02" style="margin-left: 150px;">确认发送</div>
                        </td>

                    </tr>
                    <tr>
                        <td class="td_01">&nbsp;</td>
                        <td class="td_02">&nbsp;</td>
                    </tr>
                </table>
            </div>
            <div class="msgMoban" style="display:none;font-size:14px;">
                <div style="margin-top: 20px; margin-left: 20px; width: 624px; height: 336px;">
                    <table style="border: 0px; width: 100%;">
                        <tr>
                            <td style="width: 40px; text-align: left; border: 0px;">短信类型
                                                    <select id="msg_type" onchange="selectChange(this.value)"></select></td>
                            <td style="width: 40px; border: 0px; text-align: right">
                                <input type="button" value="×" style="margin-right: 5px; width: 25px; height: 25px;" onclick="Msgclose()" /></td>
                        </tr>
                    </table>
                    <div class="msgList"></div>
                    <div class="op"></div>
                </div>
            </div>
          </div>

    </form>
    <script src="../Js/jquery-1.7.1.min.js"></script>
    <script src="../win_js/win_membersMsg.js"></script>
    <%--<script src="../win_js/member.js"></script>--%>
</body>
</html>
