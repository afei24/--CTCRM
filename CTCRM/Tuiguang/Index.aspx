<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CTCRM.Tuiguang.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>店铺管家流量推广、精准营销提供</title>
    <link href="CSS/TBApplyTemp.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Index_V1.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
     <div id="main">
        <div id="top">
            <div class="t_c t_c_m">
                <div class="t_c_t">
                     <ul class="t_c_t_u">
                            <li class="t_c_t_l t_c_t_l_l" style="margin-left:17px"><a href="javascript:void(0)">
                                <asp:Label runat="server" Text="fan" ID="lab_Nick"></asp:Label>|</a></li>
                            <li class="t_c_t_l t_c_t_l_m" style="margin-left:-1px;width:79px;"><a href="javascript:void(0)">
                                <asp:Label ID="lbVersion" runat="server" Text=""></asp:Label>
                                |</a></li>
                            <li class="t_c_t_l">
                               
                            </li>
                        </ul>
                </div>
                <div class="t_c_b">
                    <ul class="nav">
                        <li class="n_l n_l_f "><a class="n_a" id="FirstPage" href="Index.aspx">首页</a></li>
                        <li class="n_l"><a class="n_a" id="Items" href="Item.aspx">宝贝推广</a></li>
                        <li class="n_l"><a class="n_a" id="Shop" href="Shop.aspx">提交店铺</a></li>
                         <li class="n_l"><a class="n_a" id="A11" href="Statistic.aspx">推广效果</a></li>
                        <li class="n_l"><a class="n_a" id="introduce" href="Popularize.aspx">推广位介绍</a></li>
                    </ul>
                </div>
            </div>
        </div>
        <div id="bottom">
            <div class="t_c">
                <div class="b_t">
                </div>
                <div class="b_m">
                    <div class="b_c">
                        <ul id="show">
                            <li class="describe">
                                <div class="tle FontSize15">
                                    想要您的宝贝出现在<span class="FontColor"><a href="http://url.cn/a7y9lg" target="_blank" class="FontSize15 FontColor"> 有木丫 </a></span>百万级流量的位置么？
                                </div>
                                <div class="tle  FontSize15 ">
                                    您只需要:
                                </div>
                                <div class="r1">
                                    <div id="Itme" class="steup">
                                    </div>
                                    <div class="remark  backMiddle">
                                       一键推广宝贝，系统自动将宝贝分配到【有木丫】APP宝贝详情页下，达到精准推广的效果。
                                    </div>
                                    <div class="status backMiddle">
                                        <p>
                                            您有<span class="shopNameColor"><asp:Label ID="totalOnsalCount" CssClass="FontColor" runat="server" Font-Bold="true" Font-Size="16px" Text=""></asp:Label></span>件宝贝正在出售</p>
                                        <p>
                                            已发布宝贝<span class="Bold"><asp:Label ID="Label2"  CssClass="FontColor" runat="server" Font-Bold="true" Font-Size="16px" Text=""></asp:Label></span>个</p>
                                        
                                    </div>
                                    <div class="btn backMiddle">
                                        <div class="subBtn">
                                            <a href="Item.aspx?" class="go">马上去发布</a>
                                        </div>
                                    </div>
                                    <div class="backBottom">
                                    </div>
                                </div>
                                <div class="r2">
                                </div>
                                <div class="r1">
                                    <div id="pShop" class="steup">
                                    </div>
                                    <div class="remark backMiddle">
                                        确认你的店铺基本信息是否正确并提交。
                                    </div>
                                    <div class="status backMiddle">
                                        <p>
                                            您的店铺:<span class="shopNameColor"><asp:Label ID="Label1" Font-Bold="true" Font-Size="16px" runat="server" Text=""></asp:Label></span>
                                        </p>
                                    </div>
                                    <div class="btn backMiddle">
                                        <div class="subBtn">
                                            <a href="Shop.aspx?" class="go">马上去提交</a>
                                        </div>
                                    </div>
                                    <div class="backBottom">
                                    </div>
                                </div>
                                <div class="r2">
                                </div>
                                <div class="r1">
                                    <div id="popularize" class="steup">
                                    </div>
                                    <div class="remark backMiddle marginLeft">
                                    </div>
                                    <div class="status backMiddle marginLeft">
                                    </div>
                                    <div class="btn backMiddle marginLeft">
                                        <div class="subBtn ">
                                            <a href="Popularize.aspx" class="go">查看广告位</a>
                                        </div>
                                    </div>
                                    <div class="backBottom marginLeft">
                                    </div>
                                </div>
                            </li>
                            <li id="about" class="clear">
                                <ul class="about">
                                    <li class="row">
                                        <div class="title">
                                            关于有木丫
                                        </div>
                                        <div class="content">
                                            有木丫(www.new9channel.com),有木丫，新一代移动电商，主打礼物和全球好货指南，涵盖礼物、家居、服装、饰品、零食、鞋帽、母婴等类目，目前采用导购的商业模式。创办于2015年7月,目前拥有淘宝买家用户数百万。针对送礼物和挑选生活好物的痛点，用户既可以查看每日精选推荐，从送礼物、挑选家居用品和服装零食等多场景获取热门的导购指南；也可以在自营模块挑选国内、国外的精品好物。有木丫采用“社交+媒体+电商”的运营模式，提前为用户构建使用场景.<a href="http://www.new9channel.com/"
                                                target="_blank" class="shopNameColor">点击了解更多信息>></a>
                                        </div>
                                    </li>
                                </ul>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="b_b">
                     <script type="text/javascript">
                         document.getElementById("FirstPage").className += ' NavSelected';
                </script>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
