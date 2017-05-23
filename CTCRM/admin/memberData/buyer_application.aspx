<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyer_application.aspx.cs" Inherits="CTCRM.admin.memberData.buyer_application" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rev="stylesheet" media="all" href="../style/admin.css" type="text/css" rel="stylesheet" />
    <link rev="stylesheet" media="all" href="../style/calendar.css" type="text/css" rel="stylesheet" />
    <style type="text/css">
        th
        {
            width:300px;
            font-size:16px;
        }
        td
        {
            font-size:16px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="right">
        <div class="title">
            <p class="title_p">
                会员资料导出申请</p>
        </div>
        <asp:GridView ID="gv_buyer" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            CssClass="gv_sellser" EnableModelValidation="True"  OnRowDataBound="gv_buyer_RowDataBound" PageSize="100" OnSelectedIndexChanged="gv_buyer_SelectedIndexChanged"
             OnRowCommand="gv_buyer_RowCommand" style="margin-left:20px;">
                            <Columns>
                                <asp:BoundField DataField="buyer_nick" HeaderText="卖家昵称">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="export_time" HeaderText="申请日期">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                
                                <asp:ButtonField CommandName="buttonOk" Text="同意" ><ItemStyle HorizontalAlign="Center" /></asp:ButtonField>
                                <asp:ButtonField CommandName="buttonCancle" Text="驳回" ><ItemStyle HorizontalAlign="Center" /></asp:ButtonField>
                                
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdTopBuyerTradeAmount"
                                    style="border-collapse: collapse; width:900px">
                                    <tr>
                                        <th scope="col">
                                            卖家昵称
                                        </th>
                                        <th scope="col">
                                            申请日期
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="7">
                                            没有数据！
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
    </div>
    </form>
</body>
</html>
