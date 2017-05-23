<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="CTCRM.Tuiguang.Shop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>店铺管家流量推广、精准营销提供</title>
     <link href="CSS/TBApplyTemp.css" rel="stylesheet" type="text/css" />
    <link href="CSS/PostShop.css" rel="stylesheet" type="text/css" />
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
                <div class="b_m" style="height:450px">
                    <div class="b_c" style="height:450px">
                        <ul>
                            <li id="name" class="shop">
                                <label class="lab">
                                <span class="mark">*</span> 店铺名称:</label>
                                <asp:TextBox ID="txt_nick"  CssClass="txt" runat="server"></asp:TextBox>
                            </li>
                            <li id="cats" class="shop">
                                <label class="lab">
                                 <span class="mark">*</span> 主营类目:</label>
                                <asp:DropDownList  CssClass="drp_Cats" ID="drpCatsList" runat="server"></asp:DropDownList>
                                <li id="shopType" class="shop">
                                    <label class="lab">
                                        经营类型:</label>
                                    <asp:RadioButtonList ID="rdoLst1" RepeatDirection="Horizontal"  runat="server">
                                        <asp:ListItem Selected="True">个人兼职</asp:ListItem>
                                        <asp:ListItem>个人全职</asp:ListItem>
                                        <asp:ListItem>公司开店</asp:ListItem>
                                    </asp:RadioButtonList>
                                </li>
                                <li id="Address" class="shop">
                                    <label class="lab">
                                        <span class="mark">*</span> 联系地址:</label>
                                    <asp:TextBox ID="txtAdderss" CssClass="txt_address" runat="server"></asp:TextBox>
                                </li>
                                <li id="from" class="shop">
                                    <label class="lab">
                                        <span class="mark">*</span> 主要货源:</label>

                                     <asp:RadioButtonList ID="rdoLst2" RepeatDirection="Horizontal"  runat="server">
                                        <asp:ListItem Selected="True">线下批发市场</asp:ListItem>
                                        <asp:ListItem>实体店拿货</asp:ListItem>
                                        <asp:ListItem>阿里巴巴批发</asp:ListItem>
                                          <asp:ListItem>分销/代销</asp:ListItem>
                                          <asp:ListItem>自己生产</asp:ListItem>
                                          <asp:ListItem>代工生产</asp:ListItem>
                                         <asp:ListItem>自由公司渠道</asp:ListItem>
                                         <asp:ListItem>货源还未确定</asp:ListItem>
                                    </asp:RadioButtonList>
                                </li>
                                <li id="fixed" class="shop">
                                    <label class="lab">
                                        有实体店:</label>
                                     <asp:RadioButtonList ID="rdoLst3" RepeatDirection="Horizontal"  runat="server">
                                        <asp:ListItem Selected="True">是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </li>
                                <li id="factory" class="shop">
                                    <label class="lab">
                                        有工厂:</label>
                                   <asp:RadioButtonList ID="rdoLst4" RepeatDirection="Horizontal"  runat="server">
                                        <asp:ListItem Selected="True">是</asp:ListItem>
                                        <asp:ListItem>否</asp:ListItem>
                                    </asp:RadioButtonList>
                                </li>
                                <li id="submit" class="shop">
                                    <asp:ImageButton ID="btnAdd" CssClass="btnSubmit" ImageUrl="~/Tuiguang/Images/Shop/pic_011.png" runat="server" OnClick="btnAdd_Click" />&nbsp;
                                </li>
                             <li style="margin-left:220px;margin-top:-22px">
                                 <asp:Label ID="lbMsg" ForeColor="blue" Font-Bold="true" runat="server" Font-Size="20px" Text=""></asp:Label>
                             </li>
                        </ul>

                    </div>
                </div>
                <div class="b_b">
                     <script type="text/javascript">
                         document.getElementById("Shop").className += ' NavSelected';
                </script>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
