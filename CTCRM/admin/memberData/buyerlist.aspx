<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyerlist.aspx.cs" Inherits="CTCRM.admin.buyerlist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script language="javascript" type="text/javascript" src="../../Js/My97DatePicker/WdatePicker.js"></script>
    <title></title>
    <style type="text/css">
        .gv_sellser {
            width: 100%;
        }

        .table {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    买家数据<asp:Label ID="lb_buyerCount" runat="server"></asp:Label>
                    <hr />
                    <div>
                        <div>
                            用户昵称<asp:TextBox ID="tb_nick" runat="server"></asp:TextBox>
                            开始时间：<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_StartTime" />
                            结束时间：<input runat="server" type="text" class="pinpt3" onclick="WdatePicker()" id="txt_EndTime" />
                            <asp:Button ID="bt_sosuo" runat="server" Text="搜索" OnClick="bt_sosuo_Click" />&nbsp;
                            <asp:Button ID="bt_Export" runat="server" Text="生成下载链接" OnClick="bt_Export_Click" />&nbsp;
                            <asp:HyperLink ID="HyperLink1" runat="server">下载</asp:HyperLink>
                        </div>
                        <asp:GridView ID="gv_buyer" runat="server" AllowPaging="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" CssClass="gv_sellser" EnableModelValidation="True" OnPageIndexChanging="gv_buyer_PageIndexChanging" OnRowDataBound="gv_buyer_RowDataBound" PageSize="100">
                            <Columns>
                                <asp:BoundField DataField="buyer_nick" HeaderText="昵称">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="last_trade_time" HeaderText="日期">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CellPhone" HeaderText="电话号码">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerTemplate>
                                <table width="100%">
                          <tr>
                            <td style="text-align:right">
                            第<asp:Label id="lblPageIndex" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />页
                              共/<asp:Label id="lblPageCount" runat="server" text='<%# ((GridView)Container.Parent.Parent).PageCount  %>' />页 
                               <asp:linkbutton id="btnFirst" runat="server" causesvalidation="False" commandargument="First" commandname="Page" text="首页" />
                              <asp:linkbutton id="btnPrev" runat="server" causesvalidation="False" commandargument="Prev" commandname="Page" text="上一页" />
                             <asp:linkbutton id="btnNext" runat="server" causesvalidation="False" commandargument="Next" commandname="Page" text="下一页" />                          
                             <asp:linkbutton id="btnLast" runat="server" causesvalidation="False" commandargument="Last" commandname="Page" text="尾页" />                                            
                             <asp:textbox id="txtNewPageIndex" runat="server" width="20px" text='<%# ((GridView)Container.Parent.Parent).PageIndex + 1  %>' />
                             <asp:linkbutton id="btnGo" runat="server" causesvalidation="False" commandargument="-1" commandname="Page" text="GO" /><!-- here set the CommandArgument of the Go Button to '-1' as the flag -->
                             </td>
                          </tr>
                        </table>

                            </PagerTemplate>
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
        <script type="text/javascript">
            function setValue(hid_id, value) {
                document.getElementById(hid_id).innerText = value;
            }
        </script>
    </form>
</body>
</html>
