<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blacklist.aspx.cs" Inherits="CTCRM.blacklist"
    MasterPageFile="~/Temp/Common.Master" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
   <link href="CSS/site.css" rel="stylesheet" />
    <link href="CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />

    <link href="CSS/easyui.css" rel="stylesheet" />
    <link href="CSS/icon.css" rel="stylesheet" />
    <link href="CSS/color.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>会员中心</h4>
                <ul class="items">
                    <li class="on"><a href="CRankNew.aspx">客户等级划分</a></li> 
                    <li class="on"><a href="allmember.aspx">客户资料</a></li>
                    <li class="on"><a href="#">分组管理</a></li>
                    <li class="on"><a href="#">标签管理</a></li>  
                    <li class="active"><a href="blacklist.aspx">黑名单管理</a></li>
                    <li class="on"><a href="SynData/downloads.aspx">客户资料补全</a></li>
                    <li class="on"><a href="SynData/buyerExport.aspx">客户资料导出</a></li>
                   
                </ul>
            </div>--%>
            <div class="righter">

                <div class="pDiv2">
                    <div class="title2">
                        黑名单管理
                    </div>
                    <div class="contt4">
                        <table>
                            <tr>
                                <td>
                                    <label for="BuyerNick">
                                        黑名单管理:
                                    </label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="drpOperType" runat="server" CssClass="ui-widget-content ui-corner-all">
                                        <asp:ListItem>全局</asp:ListItem>
                                        <asp:ListItem>会员营销</asp:ListItem>
                                        <asp:ListItem>催付提醒</asp:ListItem>
                                        <asp:ListItem>发货提醒</asp:ListItem>
                                        <asp:ListItem>达到提醒</asp:ListItem>
                                        <asp:ListItem>付款提醒</asp:ListItem>
                                        <asp:ListItem>延迟发货提醒</asp:ListItem>
                                        <asp:ListItem>签收提醒</asp:ListItem>
                                        <asp:ListItem>回款提醒</asp:ListItem>
                                        <asp:ListItem>退货提醒</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;全局黑名单仅可以同时过滤所有的关怀、营销短信，评价和差评防御需单独设置。
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <label for="Grade">
                                        旺旺昵称(已保存 
                                    <asp:Label ID="lbCount" runat="server" ForeColor="Red" Text=""></asp:Label>
                                        个，已自动剔除重复旺旺,多个旺旺昵称请用逗号隔开)</label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox ID="txtBlackList" runat="server" Width="300px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                                    &nbsp;<asp:ImageButton ID="imgbtnSave" runat="server" ImageUrl="~/Images/save.jpg"
                                        OnClick="imgbtnSave_Click" />&nbsp;<asp:Label ID="lbMsg" runat="server" ForeColor="Blue"
                                            Font-Bold="true" Font-Size="Large" Text=""></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView CssClass="table2" Width="100%" ID="grdbadList" runat="server" DataKeyNames="blakListID"
                            AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="grdbadList_PageIndexChanging" EnableModelValidation="True">
                            <Columns>
                                <asp:BoundField DataField="blakName" HeaderText="旺旺昵称">
                                    <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="operType" HeaderText="使用范围">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="createDate" HeaderText="添加时间">
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("blakListID") %>' OnClientClick="return(confirm('确认要删除该黑名单用户？'));"
                                            OnClick="Allow_click">删除</asp:LinkButton>
                                    </ItemTemplate>
                                    <HeaderStyle BackColor="#e79969" Width="20%" Font-Size="14px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table2">
                                    <tr>
                                        <th>旺旺昵称
                                        </th>
                                        <th>使用范围
                                        </th>
                                        <th>添加时间
                                        </th>
                                        <th>操作
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">当前没有黑名单买家
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
                            <asp:TextBox ID="txtNewPageIndex" runat="server" Width="20px" Text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1 %>' />
                                    页
                            <asp:LinkButton ID="btnGo" runat="server" CausesValidation="False" CommandArgument="-2"
                                CommandName="Page" Text="GO" />
                                </center>
                            </PagerTemplate>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
