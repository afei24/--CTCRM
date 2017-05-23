<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="systemSetting.aspx.cs"
    MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.systemSetting" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
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
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员中心</h4>
                <ul class="items">
                    <li><a href="allmember.aspx">会员管理</a></li>
                    <li><a href="systemReport.aspx">统计分析</a></li>
                    <li><a href="blacklist.aspx">黑名单管理</a></li>
                     <li><a href="SynData/buyerExport.aspx">会员导出</a></li>
                    <li class="on"><a href="systemSetting.aspx">系统设置</a></li>
                </ul>
            </div>
            <div class="righter">

                <div class="pDiv2">
                    <div class="title2">
                        系统默认等级管理
                    </div>
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 300px; font-weight: bold;">普通会员
                                    </td>
                                    <td style="width: 90px" align="right">
                                        <asp:Label ID="lbBuyerNick" runat="server" Text="消费金额(￥)："></asp:Label>
                                    </td>
                                    <td style="width: 60px">
                                        <asp:TextBox ID="txtMin1" Height="20px" runat="server" Text="1"></asp:TextBox>
                                    </td>
                                    <td style="width: 10px">到
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMax1" runat="server" Height="20px" Text="100"></asp:TextBox>
                                        <asp:Label ID="lbError1" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </tr>
                                <tr>
                                    <td style="width: 300px; font-weight: bold;">高级会员
                                    </td>
                                    <td style="width: 90px" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="消费金额(￥)："></asp:Label>
                                    </td>
                                    <td style="width: 60px">
                                        <asp:TextBox ID="txtMin2" runat="server" Height="20px" Text="100"></asp:TextBox>
                                    </td>
                                    <td style="width: 10px">到
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMax2" runat="server" Height="20px" Text="300"></asp:TextBox>
                                        <asp:Label ID="lbError2" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px; font-weight: bold;">VIP会员
                                    </td>
                                    <td style="width: 90px" align="right">
                                        <asp:Label ID="txtMissn3" runat="server" Text="消费金额(￥)："></asp:Label>
                                    </td>
                                    <td style="width: 60px">
                                        <asp:TextBox ID="txtMin3" runat="server" Height="20px" Text="300"></asp:TextBox>
                                    </td>
                                    <td style="width: 10px">到
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMax3" runat="server" Height="20px" Text="500"></asp:TextBox>
                                        <asp:Label ID="lbError3" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 300px; font-weight: bold;">至尊Vip会员
                                    </td>
                                    <td style="width: 90px" align="right">
                                        <asp:Label ID="Label2" runat="server" Text="消费金额(￥)："></asp:Label>
                                    </td>
                                    <td style="width: 60px">
                                        <asp:TextBox ID="txtMin4" runat="server" Height="20px" Text="500"></asp:TextBox>
                                    </td>
                                    <td style="width: 10px">到
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMax4" runat="server" Height="20px" Text="1000000"></asp:TextBox>
                                        <asp:Label ID="lbError4" runat="server" ForeColor="Red" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" align="center">
                                        <asp:HyperLink ID="versionControl" Font-Bold="true" Font-Size="16px" Target="_blank"
                                            ForeColor="Red" runat="server" NavigateUrl="http://to.taobao.com/28N75iy"
                                            Text="此功能仅限【付费版】用户,现在去订购？"></asp:HyperLink>&nbsp;<asp:ImageButton ID="imgModify" runat="server" ImageUrl="~/Images/modify.jpg" OnClick="imgModify_Click" />
                                        &nbsp;&nbsp;<asp:Label ID="lbMsg" runat="server" Font-Bold="true" Font-Size="18px" ForeColor="Blue" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>

               <%-- <div class="pDiv2">
                    <div class="title2">
                        系统默认分组
                    </div>
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 100px">
                                        <span style="color: #e17009">[#新客户#]</span>
                                    </td>
                                    <td>只购买过一次的会员，添加分组标签。
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #e17009">[#老客户#]</span>
                                    </td>
                                    <td>重复消费的会员，添加分组标签。
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #e17009">[#休眠3个月#]</span>
                                    </td>
                                    <td>休眠超过3个月的会员，添加分组标签。
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="color: #e17009">[#潜在客户#]</span>
                                    </td>
                                    <td>未成功购买的会员，添加分组标签。
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>--%>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
