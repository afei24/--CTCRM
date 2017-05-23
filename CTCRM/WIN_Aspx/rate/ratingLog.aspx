<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ratingLog.aspx.cs" Inherits="CTCRM.WIN_Aspx.rate.ratingLog" %>

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

    <script src="../../Js/jquery.js" type="text/javascript"></script>

    <script src="../../Js/TBApply.js" type="text/javascript"></script>

    <script src="../../Js/DialogMsg.js" type="text/javascript"></script>

    <script src="../../Js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
        <style type="text/css">
        table, table td
        {
            border:none;
        }
        table td
        {
            background-color:white;
            padding-bottom:5px;
            padding-top:10px;
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
                        <span class="zhandian">自动评价 >> 评价日志</span>
                    </div>
                    
                    <div class="contt4" style="margin-left: 10px">
                        <div class="title2">
                        评价日志
                    </div>
                        <table width="100%" border="0" cellpadding="0" cellspacing="0">
                            <tr valign="middle">
                                <td style="width: 30px">
                                    &nbsp;从：
                                </td>
                                <td style="width:150px;">
                                    &nbsp;<input runat="server" type="text" style="width: 110px;" class="ui-widget-content ui-corner-all"
                                        onclick="WdatePicker()" id="datePickerStart" />
                                </td>
                                <td style="width: 30px">
                                    &nbsp;至：
                                </td>
                                <td style="width:150px;">
                                    &nbsp;<input runat="server" type="text" style="width: 110px;" class="ui-widget-content ui-corner-all"
                                        onclick="WdatePicker()" id="datePickerEnd" />
                                </td>
                                <td align="left" style="width:350px;">
                                    <asp:ImageButton ID="btnimgSearch" runat="server" Width="80px" Height="25px" ImageUrl="~/Images/search.png" style="text-align:left"
                                        OnClick="btnimgSearch_Click" OnClientClick="dialog.DOpen(this);" />
                                </td>
                                <td style="width:150px;">
                                     <asp:ImageButton ID="ImageButton1" OnClientClick="return(confirm('导出日志可能比较慢，特别是订单量多的店铺，下载过程中不要离开此页面！'));" runat="server" Width="120px" Height="30px" ImageUrl="~/Win_Image/daochu.png" OnClick="ImageButton1_Click"
                                         />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="8" align="right">
                                    <ul id="text">
                                        <asp:HyperLink ID="versionControl" Font-Bold="true" Font-Size="16px" Target="_blank"
                                        ForeColor="#00BFE9" runat="server" NavigateUrl="http://fuwu.taobao.com/ser/detail.htm?spm=a1z13.1113643.1113643.61.0Jlk1A&service_code=ts-1811102&tracelog=search&scm=&ppath=&labels="
                                        Text="仅限【全功能版】用户,现在去升级？"></asp:HyperLink>
                                    </ul>
                                </td>
                            </tr>
                        </table>
                        <asp:GridView CssClass="table2" Width="100%" ID="grdRateLogList" runat="server" AutoGenerateColumns="False"
                            AllowPaging="True" PageSize="15" OnPageIndexChanging="grdRateLogList_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="created" HeaderText="评价时间">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tid" HeaderText="订单编号">
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="content" HeaderText="评价内容">
                                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                                </asp:BoundField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table width="100%" border="1" cellpadding="0" cellspacing="0" class="table2">
                                    <tr>
                                        <th>
                                            评价时间
                                        </th>
                                        <th>
                                            订单编号
                                        </th>
                                        <th>
                                            评价内容
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            当前没有评价内容
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
                <div id="msgDiv" style="width: 280px; height: 13px; position: absolute; left: 380px;
                    top: 150px; display: none; z-index: 9999;">
                    <h1>
                        <font color="#00BFE9">中差评查询中,请稍等........</font></h1>
                </div>
                <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px;
                    height: 13px; position: absolute; left: 380px; top: 180px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif);
                    z-index: 9999;">
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
