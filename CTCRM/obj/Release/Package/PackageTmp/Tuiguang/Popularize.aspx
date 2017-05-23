<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Popularize.aspx.cs" Inherits="CTCRM.Tuiguang.Popularize" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>店铺管家流量推广、精准营销提供</title>
     <link href="CSS/TBApplyTemp.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Popularize.css" rel="stylesheet" type="text/css" />
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
                        <ul class="content">
                            <li class="title">您的宝贝会出现在这里(APP里面单品详情页或者攻略里面商品详情页底部)：</li>
                            <li class="con" style="margin-left:100px;margin-top:15px;">
                                <img class="img" src="Images/guangaowei.png" style="width:375px; height:650px" /></li>
                        </ul>
                    </div>
                <div class="b_b">
                    <script type="text/javascript">
                        document.getElementById("introduce").className += ' NavSelected';
                </script>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
