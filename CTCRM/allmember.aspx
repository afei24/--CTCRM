<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allmember.aspx.cs" MasterPageFile="~/Temp/Common.Master"
    MaintainScrollPositionOnPostback="true" Inherits="CTCRM.allmember" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
   
    <link href="CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />


    <base target="_self" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" type="text/javascript"></script>
    <script src="Js/DialogMsg.js" type="text/javascript"></script>

    <style type="text/css">
        /*淘宝风格*/
        .paginator {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 10px 20px 10px 0;
            margin: 0px;
        }

            .paginator a {
                border: solid 1px #ccc;
                color: #0063dc;
                cursor: pointer;
                text-decoration: none;
            }

                .paginator a:visited {
                    padding: 1px 6px;
                    border: solid 1px #ddd;
                    background: #fff;
                    text-decoration: none;
                }

            .paginator .cpb {
                border: 1px solid #F50;
                font-weight: 700;
                color: #F50;
                background-color: #ffeee5;
            }

            .paginator a:hover {
                border: solid 1px #F50;
                color: #f60;
                text-decoration: none;
            }

            .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover {
                float: left;
                height: 16px;
                line-height: 16px;
                min-width: 10px;
                _width: 10px;
                margin-right: 5px;
                text-align: center;
                white-space: nowrap;
                font-size: 12px;
                font-family: Arial,SimSun;
                padding: 0 3px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4">
                        <table  border="0" cellpadding="0" cellspacing="0" frame="void">
                            <tr>
                                <td>买家昵称:
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNickName" runat="server" Width="100px" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                </td>
                                <td>会员状态:
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpStatus" runat="server" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="normal">正常</asp:ListItem>
                                        <asp:ListItem Value="delete">被买家删除</asp:ListItem>
                                        <asp:ListItem Value="blacklist">黑名单</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>所属地区：
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpArea" runat="server" Width="80px" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="北京">北京市</asp:ListItem>
                                        <asp:ListItem Value="上海">上海市</asp:ListItem>
                                        <asp:ListItem Value="天津">天津市</asp:ListItem>
                                        <asp:ListItem Value="重庆">重庆市</asp:ListItem>
                                        <asp:ListItem Value="河北">河北省</asp:ListItem>
                                        <asp:ListItem Value="山西">山西省</asp:ListItem>
                                        <asp:ListItem Value="内蒙古">内蒙古自治区</asp:ListItem>
                                        <asp:ListItem Value="辽宁">辽宁省</asp:ListItem>
                                        <asp:ListItem Value="吉林">吉林省</asp:ListItem>
                                        <asp:ListItem Value="黑龙江">黑龙江省</asp:ListItem>
                                        <asp:ListItem Value="江苏">江苏省</asp:ListItem>
                                        <asp:ListItem Value="浙江">浙江省</asp:ListItem>
                                        <asp:ListItem Value="安徽">安徽省</asp:ListItem>
                                        <asp:ListItem Value="福建">福建省</asp:ListItem>
                                        <asp:ListItem Value="江西">江西省</asp:ListItem>
                                        <asp:ListItem Value="山东">山东省</asp:ListItem>
                                        <asp:ListItem Value="河南">河南省</asp:ListItem>
                                        <asp:ListItem Value="湖北">湖北省</asp:ListItem>
                                        <asp:ListItem Value="湖南">湖南省</asp:ListItem>
                                        <asp:ListItem Value="广东">广东省</asp:ListItem>
                                        <asp:ListItem Value="广西">广西壮族自治区</asp:ListItem>
                                        <asp:ListItem Value="海南">海南省</asp:ListItem>
                                        <asp:ListItem Value="贵州">贵州省</asp:ListItem>
                                        <asp:ListItem Value="四川">四川省</asp:ListItem>
                                        <asp:ListItem Value="西藏">西藏自治区</asp:ListItem>
                                        <asp:ListItem Value="陕西">陕西省</asp:ListItem>
                                        <asp:ListItem Value="甘肃">甘肃省</asp:ListItem>
                                        <asp:ListItem Value="宁夏">宁夏回族自治区</asp:ListItem>
                                        <asp:ListItem Value="青海">青海省</asp:ListItem>
                                        <asp:ListItem Value="新疆">新疆维吾尔自治区</asp:ListItem>
                                        <asp:ListItem Value="香港">香港特别行政区</asp:ListItem>
                                        <asp:ListItem Value="澳门">澳门特别行政区</asp:ListItem>
                                        <asp:ListItem Value="台湾">台湾省</asp:ListItem>
                                        <asp:ListItem Value="其它">其它</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>分组标签：
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpGroup" runat="server" CssClass="ui-widget-content ui-corner-all">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td style="vertical-align: middle">会员级别：
                                </td>
                                <td style="vertical-align: middle">
                                    <asp:DropDownList ID="drpGrade" runat="server" Width="100px" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem Value="all">全部</asp:ListItem>
                                        <asp:ListItem Value="0">潜在会员</asp:ListItem>
                                        <asp:ListItem Value="1">普通会员</asp:ListItem>
                                        <asp:ListItem Value="2">高级会员</asp:ListItem>
                                        <asp:ListItem Value="3">Vip会员</asp:ListItem>
                                        <asp:ListItem Value="4">至尊Vip会员</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td style="vertical-align: middle">累计消费金额在
                                </td>
                                <td colspan="2" style="vertical-align: middle">
                                    <asp:TextBox ID="txtMin" runat="server" Width="100px" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                    至
                        <asp:TextBox ID="txtMax" runat="server" Width="100px" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                </td>
                                <td align="right" style="vertical-align: middle">购买次数：
                                </td>
                                <td style="vertical-align: middle; width: 100px">
                                    <asp:TextBox ID="txtBuyCount" runat="server" Width="60px" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                                </td>
                                <td align="center" style="vertical-align: middle">
                                    <asp:ImageButton ID="btnimgSearch" runat="server" ImageUrl="~/Images/serach.jpg"
                                        OnClick="btnimgSearch_Click" OnClientClick="dialog.DOpen2(this);" />
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>&nbsp;<asp:Label ID="Label8" runat="server" Font-Size="14px" ForeColor="#00BFEA"
                                    Text="提示：如果发现部分买家会员的电话号码、姓名会为空，此时可以导入订单历史找回！"></asp:Label><a href="SynData/findBuyerInfo.aspx"><font
                                        size="5px">现在就去导入？</font></a><br />
                                </td>
                            </tr>
                        </table>
                        <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" DataKeyNames="buyer_id"
                            OnRowDataBound="grdBuyer_RowDataBound" EnableModelValidation="True">
                            <Columns>
                                <%--<asp:BoundField DataField="buyer_nick" HeaderText="买家昵称" />--%>
                                <asp:TemplateField HeaderText="买家昵称" SortExpression="buyer_nick">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBuyerNick" runat="server" Text='<%# Eval("buyer_nick").ToString() %>' />
                                        <a target="_blank" href="http://www.taobao.com/webww/ww.php?ver=3&touid=<%# Eval("buyer_nick").ToString() %>&siteid=cntaobao&status=2&charset=utf-8">
                                            <img border="0" src="http://amos.alicdn.com/realonline.aw?v=2&uid=<%# Eval("buyer_nick").ToString() %>&site=cntaobao&s=2&charset=utf-8"
                                                alt="点击这里给我发消息" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="buyer_reallName" HeaderText="姓名" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="province" HeaderText="所在省份">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cellPhone" HeaderText="手机号码" />
                                <asp:TemplateField HeaderText="会员级别" SortExpression="Grade">
                                    <ItemTemplate>
                                        <asp:Label ID="Label4" runat="server" Text='<%# CheckBuyerLevel(Eval("grade").ToString() )%>' />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="trade_amount" HeaderText="消费额" DataFormatString="{0:c}" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="item_num" HeaderText="购买量">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="trade_count" HeaderText="购买次数">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="last_trade_time" HeaderText="最近交易时间">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkEdit" ForeColor="#8D0D02" Text="会员详细" runat="server"></asp:HyperLink>&nbsp;
                            <asp:HyperLink ID="HyerLinkEditMember" ForeColor="#8D0D02" Text="会员修改" runat="server"></asp:HyperLink>&nbsp;
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer"
                                    style="border-collapse: collapse;">
                                    <tr>
                                        <th scope="col">买家昵称
                                        </th>
                                        <th scope="col">买家姓名
                                        </th>
                                        <th scope="col">所在省份
                                        </th>
                                        <th scope="col">手机号码
                                        </th>
                                        <th scope="col">会员状态
                                        </th>
                                        <th scope="col">会员级别
                                        </th>
                                        <th scope="col">消费金额
                                        </th>
                                        <th scope="col">购买宝贝数
                                        </th>
                                        <th scope="col">最近交易时间
                                        </th>
                                        <th scope="col">操作
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="10" align="center">
                                             <div id="nodata" class="nodata" runat="server">先点击右上角的<font color="blue">搜索</font>按钮如果未找到任何符合查询条件的数据,您可以<a href="SynData/downloads.aspx" >点此</a>同步店铺客户数据！</div>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" align="center" width="99%" class="border">
                            <tr>
                                <td align="left" colspan="2">
                                    <webdiyer:AspNetPager ID="AspNetPager1" CssClass="paginator" CurrentPageButtonClass="cpb"
                                        runat="server" PageSize="15" AlwaysShow="True" OnPageChanged="AspNetPager1_PageChanged"
                                        FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PrevPageText="上一页" ShowCustomInfoSection="Left"
                                        CustomInfoSectionWidth="20%" ShowPageIndexBox="Never" CustomInfoTextAlign="Left"
                                        LayoutType="Table" CustomInfoHTML="第<font color='#00BFEA'><b>%currentPageIndex%</b></font>页，共%PageCount%页，每页显示%PageSize%条记录">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                        </table>
                        <div class="floatLeft">
                        </div>
                        <div id="msgDiv2" style="width: 350px; height: 13px; position: absolute; left: 380px; top: 120px; display: none; z-index: 9999;">
                            <h1>
                                <font color="white">数据查询中,请稍等........</font></h1>
                        </div>
                        <div id="zhezhang2" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 380px; top: 150px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                        </div>

                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
