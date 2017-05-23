<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="blacklist.aspx.cs" Inherits="CTCRM.WIN_Aspx.rate.blacklist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/css.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .table_black, .table_black td
        {
            border:none;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <div class="righter">
               <div class="pDiv2">
                   <div class="div_zhandian">
                        <span class="zhandian">自动评价 >> 黑名单</span>
                    </div>

            <div class="contt4" style="margin-left: 10px">
                            <div class="title2">
                黑名单设置
            </div>
                <table width="100%" border="0" cellpadding="0" cellspacing="0" class="table_black">
                    <tr>
                        <td style="width: 70px">
                            &nbsp;黑名单：
                        </td>
                        <td style="text-align:left;">
                            <asp:TextBox ID="txtBlackList"  Width="320px" runat="server" style="border-radius:5px"
                                Height="21px" Text="请输入黑名单" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;多个淘宝昵称请用逗号<font
                                    color="red">","</font>隔开。<asp:ImageButton ID="btnImgAddBlakList" runat="server" ImageUrl="~/Win_Image/add.png" style="border-radius:5px"
                                        Width="80px" Height="25px" OnClick="btnImgAddBlakList_Click" />&nbsp;
                        </td>
                    </tr>
                </table>
                <asp:GridView CssClass="table2" Width="100%" ID="grdbadList" runat="server" DataKeyNames="blakListID"
                    AutoGenerateColumns="False" AllowPaging="True" PageSize="8" OnPageIndexChanging="grdbadList_PageIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="blakName" HeaderText="买家昵称">
                            <HeaderStyle HorizontalAlign="Center" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:BoundField DataField="createDate" HeaderText="添加时间">
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="200px" />
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("blakListID") %>'
                                    OnClick="Allow_click" OnClientClick="return(confirm('确定要删除该黑名单用户？'));">删除</asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle BackColor="#e79969" Width="20%" Font-Size="14px" />
                            <ItemStyle Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" Font-Size="14px" />
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table2">
                            <tr>
                                <th>
                                    买家昵称
                                </th>
                                <th>
                                    添加时间
                                </th>
                                <th>
                                    操作
                                </th>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    当前没有黑名单买家
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
        </div>
         <script type="text/javascript">
             document.getElementById("A2").className += ' NavSelected';
                 </script> 
    </div>
    </form>
</body>
</html>
