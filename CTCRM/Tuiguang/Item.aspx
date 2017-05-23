<%@ Page Language="C#" AutoEventWireup="true"  EnableEventValidation="false" CodeBehind="Item.aspx.cs" Inherits="CTCRM.Tuiguang.Item" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>店铺管家流量推广、精准营销提供</title>
    <link href="CSS/TBApplyTemp.css" rel="stylesheet" type="text/css" />
    <link href="CSS/Items.css" rel="stylesheet" type="text/css" />
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
                            <li class="n_l"><a class="n_a" id="A10" href="Item.aspx">宝贝推广</a></li>
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
                            <ul id="items">
                                <li class="title"><span class="l_t">特别提示</span><span class="l_r">|</span><span class="l_m">目前每个商家只开放6个广告位,服务周期内可以循环使用,每次创建都会扣除一个广告位！</span></li>
                                <li class="serach">
                                    <div class="s_s">
                                        &nbsp;<input class="span8" style="width: 730px; margin-top: 30px; height: 26px" type="text" title="你要推广的宝贝地址,例如：https://item.taobao.com/item.htm?id=529108600343"
                                            onfocus='if(this.value == "你要推广的宝贝地址,例如：https://item.taobao.com/item.htm?id=529108600343"){this.value = ""}'
                                            onblur='if(this.value == ""){this.value = "你要推广的宝贝地址,例如：https://item.taobao.com/item.htm?id=529108600343"}'
                                            value="你要推广的宝贝地址,例如：https://item.taobao.com/item.htm?id=529108600343" runat="server" id="s_key">
                                        <asp:ImageButton ID="btnCreateTask" CssClass="BtnStyle" style="height:33px;width:108px"  ImageUrl="~/Tuiguang/Images/createTask.png" runat="server" OnClick="btnCreateTask_Click" />
                                    </div>
                                </li>
                                <li class="show" style="text-align:right;">
                                    <asp:Label ID="lbMsg" ForeColor="blue" Font-Bold="true" Font-Size="20px" runat="server" Text=""></asp:Label>
                                </li>
                                <li class="data">
                                    <ul>
                                        <asp:Repeater ID="rptProducts" runat="server"   OnItemDataBound="rptProducts_ItemDataBound">
                                            <HeaderTemplate>
                                                 <li id="d_t" class="da">
                                                    <span class="i_i">宝贝图片</span>
                                                    <span class="i_name">宝贝名称</span>
                                                    <span class="i_p">价格</span>
                                                    <span class="i_n">商品销量</span>
                                                    <span class="i_o">操作</span>
                                                    <span class="i_o">查看广告位</span>
                                                 </li>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                     <li id="d_c" class="da">
                                                        <ul>
                                                            <li> 
                                                                <span class="i_i"><asp:HiddenField ID="hfId" Value='<%#Eval("itemNo")%>' runat="server"/>
        <img src="<%#Eval("itemPicUrl")%>" alt='' /></span>
                                                                <span class="i_name"><a href="<%#Eval("itemUrl")%>" target="_blank"><%#Eval("itemTitle")%></a> </span>
                                                                <span class="i_p"><%#Eval("price")%></span>
                                                                <span class="i_n"><%#Eval("inventory")%></span>
                                                                <span class="i_o" id="AlteredOpera">
                                                                <asp:Image ID="btnTuiing" ImageUrl="~/Tuiguang/Images/tuiing2.gif" runat="server" Width="90px" Height="28px"/>
                                                                <asp:ImageButton ID="btnDown" CommandArgument='<%# Eval("itemNo") %>' OnClientClick="return(confirm('确定要下架该宝贝吗？'));" runat="server" ImageUrl="~/Tuiguang/Images/downTask.png" Width="90px" Height="28px" OnClick="btnDown_click" />
                                                                     <asp:ImageButton ID="btnAddTask" CommandArgument='<%# Eval("itemNo") %>' OnClientClick="return(confirm('确定要重新上架该宝贝吗？'));" ImageUrl="~/Tuiguang/Images/addTask.png" Width="90px" Height="28px" runat="server" OnClick="btnAddTask_click"/>
                                                                <asp:ImageButton ID="btnDeleteTask" ImageUrl="~/Tuiguang/Images/deleteTask.png" CommandArgument='<%# Eval("itemNo") %>' OnClientClick="return(confirm('确定要删除该宝贝？'));" Width="90px" Height="28px" runat="server" OnClick="btnDeleteTask_click" />
                                                                </span>
                                                                <span class="i_o" id="Span3">
                                                                     <a href="<%#Eval("tuiAddress")%>" target="_blank">
                                                                       <img src="Images/chekTask.png" style="width:90px;height:28px;" runat="server" id="imgShowTask"/>
                                                                   </a>
                                                                    <%--<img src="/Images/erweima.png" style="width:100px;height:100px" />--%>
                                                                </span>
                                                            </li>
                                                        </ul>
                                                    </li>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </ul>
                                </li>
                                <li>
                                    <div class="page">
                                        <div style="text-align: center">
                                        </div>
                                    </div>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <div class="b_b">
                        <script type="text/javascript">
                            document.getElementById("A10").className += ' NavSelected';
                        </script>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>
</html>
