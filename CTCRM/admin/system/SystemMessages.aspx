<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemMessages.aspx.cs" Inherits="CTCRM.admin.system.SystemMessages" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link  media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link href="../../CSS/Page.css" rel="stylesheet" type="text/css" />
    <link  media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        .nrkuai_1
        {
            margin-left:70px;
        }
        .nrkuai_1 td
        {
            text-align:center;
        }
         .nrkuai_1 th
        {
            background-color:#4195cc;
            background:none;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p>
                系统公告管理</p>
        </div>
        <div class="jsuo" style="    border-bottom: 2px solid #7faee6;">
            <table width="100%">
                <tr align="left">    
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Text=" 添 加 " 
                            CssClass="pinpt4" Width="78px" OnClick="btnSearch_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" Text=" 批量删除 "
                            CssClass="pinpt4" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div class="nrkuai_1">
            <asp:GridView ID="GridViewSystem" runat="server" EnableModelValidation="True" OnRowCommand="GridViewSystem_RowCommand" Width="718px" AutoGenerateColumns="False" Height="175px">
                <Columns>
                     
                    <asp:TemplateField HeaderText="选中">
                        <ItemTemplate>
                           <asp:CheckBox ID="ChkItem" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="SystemMsg" HeaderText="公告内容" >
                    <ControlStyle Height="30px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SystemLink" HeaderText="公告标题" />
                    <asp:BoundField DataField="SystemDate" HeaderText="公告时间" />
                                        <asp:BoundField DataField="Status" HeaderText="状态" />
                    <asp:ButtonField CommandName="buttonEdit" Text="编辑" />
                    <asp:ButtonField CommandName="buttonDel" Text="删除" />

                    
                </Columns>
                    <EmptyDataTemplate>
                        <table  border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                            style="border-collapse: collapse; width:900px">
                         <tr>
                            <th scope="col">
                                公告内容
                            </th>
                            <th scope="col">
                                公告链接
                            </th>
                        </tr>
                        <tr>
                            <td >
                                没有数据！
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
            </asp:GridView>
            </div>
    </div>
    </form>
</body>
</html>
