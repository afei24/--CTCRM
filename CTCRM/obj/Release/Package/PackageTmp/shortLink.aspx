<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="shortLink.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.shortLink" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" />
    <link href="CSS/css.css" rel="stylesheet" />
    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员营销</h4>
                <ul class="items">
                    <li><a href="message.aspx">短信营销</a></li>
                    <li><a href="Smart/index.aspx">智能营销</a></li>
                    <li><a href="sendMsg.aspx">自有号码群发</a></li>
                    <li><a href="Smart/msgHis.aspx">发送记录</a></li>
                    <li class="on"><a href="shortLink.aspx">短链接生成</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4" style="margin-left: 10px">
                        <div class="smallTitle" style="height: 45px">
                            <table cellspacing="0" rules="all" border="1" id="Table1" style="border-collapse: collapse;">
                                <tr>
                                    <td>
                                         支持生成：店铺宝贝、店铺首页、活动链接等多种短链接，呼起手机淘宝APP,短信营销利器！
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="content">
                            <table>
                                <tbody>
                                    <tr>
                                        <td colspan="2">
                                            <font color="red">淘宝官方推出的最新接口，可以直接检测短信营销的投放效果数据（比如点击次数、引导成交等）可以在ECRM中进行查看！ </font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <div>
                                                <table cellspacing="0" rules="all" border="0" id="Table3" style="border-collapse: collapse;">
                                                    <tr>
                                                        <td style="width:150px;">
                                                            短链名称：
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtName" runat="server" CssClass="ui-widget-content ui-corner-all" Width="154px"></asp:TextBox>&nbsp;【最多只能16个中文字符】
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            短链类型:
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">-----选择类型-----</asp:ListItem>
                                                                <asp:ListItem Value="LT_ITEM">商品淘短链</asp:ListItem>
                                                                <asp:ListItem Value="LT_SHOP">店铺首页淘短链</asp:ListItem>
                                                                <asp:ListItem Value="LT_ACTIVITY">活动页淘短链</asp:ListItem>
                                                                <asp:ListItem Value="LT_TRADE">订单详情页淘短链</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" id="urlAd">
                                                        <td>
                                                            输入参加活动的地址：
                                                        </td>
                                                       <td>
                                                            <asp:TextBox ID="txtLinkURL" runat="server" Width="500px" TextMode="MultiLine" CssClass="ui-widget-content ui-corner-all" Height="35px"></asp:TextBox>
                                                       </td>           
                                                    </tr> 
                                                     <tr runat="server" id="urlAd2">
                                                         <td>

                                                         </td>                                        
                                                       <td>
                                                            【注意：URL必须是taobao.com,tmall.com,jaeapp.com这三个域名下的URL】
                                                       </td> 
                                                     </tr>
                                                      <tr runat="server" id="Trproduct">
                                                        <td>
                                                            请输入参加活动的商品ID：
                                                        </td>
                                                       <td>
                                                            <asp:TextBox ID="txtProID" runat="server" Width="200px"  CssClass="ui-widget-content ui-corner-all"></asp:TextBox>【比如：41654965978】
                                                       </td>
                                                    </tr>
                                                    <tr runat="server" id="TrTrade">
                                                        <td>
                                                            请输入参加活动的订单ID：
                                                        </td>
                                                       <td>
                                                            <asp:TextBox ID="txtTradeID" runat="server" Width="200px"  CssClass="ui-widget-content ui-corner-all"></asp:TextBox>【比如：656643332322332】
                                                       </td>
                                                    </tr>                                 
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Button ID="btnGenerate" runat="server" Text="立即生成链接" Width="118px" Height="29px" OnClick="btnGenerate_Click" 
                                                                 />&nbsp;<asp:Label ID="lbMsg" runat="server"
                                                                    Font-Bold="true" Font-Size="18px" Text="" ForeColor="Blue"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            请复制链接到短信内容框=>

                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lbLink" Font-Bold="true" Font-Size="28px" ForeColor="Blue" runat="server" Text=""></asp:Label></td>
                                                    </tr>                                                  
                                                </table>
                                            </div>
                                            <div>
                                            </div>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </div>
                        <div class="content">
                            <asp:GridView ID="grdHisMsg" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                                PageSize="5" OnPageIndexChanging="grdHisMsg_PageIndexChanging" EnableModelValidation="True">
                                                <Columns>
                                                    <asp:BoundField DataField="linkType" HeaderText="链接类型">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        <ItemStyle HorizontalAlign="Center" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="linkUrl" HeaderText="生成的短链">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px"/>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="createDate" HeaderText="创建日期">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField> 
                                                     <asp:BoundField DataField="memo" HeaderText="备注">
                                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="300px"  />
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:BoundField>                                                    
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                                        style="border-collapse: collapse;">
                                                        <tr>                            
                                                            <th align="center" scope="col">链接类型
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">生成的短链
                                                            </th>
                                                            <th align="center" valign="middle" scope="col">创建日期
                                                            </th>                    
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">当前还没有生成短链记录
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                                <PagerTemplate>
                                                    <center>
                                                        当前第:
                                                        <asp:Label ID="LabelCurrentPage" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageIndex + 1 %>"></asp:Label>
                                                        页/共:
                                                        <asp:Label ID="LabelPageCount" runat="server" Text="<%# ((GridView)Container.NamingContainer).PageCount %>"></asp:Label>
                                                        页
                                                        <asp:LinkButton ID="LinkButtonFirstPage" runat="server" CommandArgument="First" CommandName="Page"
                                                            Visible='<%#((GridView)Container.NamingContainer).PageIndex != 0 %>'>首页</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButtonPreviousPage" runat="server" CommandArgument="Prev"
                                                            CommandName="Page" Visible='<%# ((GridView)Container.NamingContainer).PageIndex != 0 %>'>上一页</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButtonNextPage" runat="server" CommandArgument="Next" CommandName="Page"
                                                            Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>下一页</asp:LinkButton>
                                                        <asp:LinkButton ID="LinkButtonLastPage" runat="server" CommandArgument="Last" CommandName="Page"
                                                            Visible='<%# ((GridView)Container.NamingContainer).PageIndex != ((GridView)Container.NamingContainer).PageCount - 1 %>'>尾页</asp:LinkButton>
                                                        转到第
                                                        <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />页
                                                        <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                                            CommandName="Page" Text="GO" />
                                                    </center>
                                                </PagerTemplate>
                                            </asp:GridView>
                        </div>
                    </div>
                </div>                
                <script type="text/javascript">
                    document.getElementById("A7").className += ' NavSelected';
                </script>
            </div>
        </div>
    </div>
</asp:Content>
