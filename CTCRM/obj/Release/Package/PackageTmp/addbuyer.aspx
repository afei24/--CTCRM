<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addbuyer.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.addbuyer" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="CSS/site.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>

</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div class="rightside" style="height: 100%">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
            <ContentTemplate>
                <div class="infoArea">
                    <div class="smallTitle">
                        &nbsp;新增会员【手工添加非淘宝注册用户】
                    </div>
                    <div class="content">
                        <table style="width: 100%">
                    <tbody>
                        <tr>
                            <td>
                                &nbsp;真实姓名：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtRealName" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;手机号码：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtCellphone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:Label
                                    ID="lbCellPhoneError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;固定电话：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtPhone" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:Label
                                    ID="lbPhoneError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;QQ：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtQQ" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:Label
                                    ID="lbQQError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;MSN：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtMSN" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;邮政编码：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtZIPCode" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:Label
                                    ID="lbZIPError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;邮件：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtEmail" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>&nbsp;<asp:Label
                                    ID="lbEmailError" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                            <td>
                                &nbsp;买家昵称：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtNick" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;新浪微博：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtsinaWeibo" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;腾讯微博：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtQQWeibo" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;省份：
                            </td>
                            <td>
                                &nbsp;<asp:DropDownList ID="drpArea" runat="server" Width="118px" CssClass="ui-widget-content ui-corner-all">
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
                            <td>
                                &nbsp;城市：
                            </td>
                            <td>
                                &nbsp;<asp:TextBox ID="txtCity" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;生日：
                            </td>
                            <td colspan="3">
                                &nbsp;<input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()"
                                    id="datebirthday" />
                            </td>
                        </tr>                
                        <tr>
                            <td colspan="4" align="center">
                                <asp:ImageButton ID="imgSubmit" runat="server" ImageUrl="~/Images/save.jpg"
                                    OnClick="imgSubmit_Click" />
                               <asp:Label ID="lbMsg" runat="server" Text="" Font-Bold="true" Font-Size="16px"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                    </div>
                    <div class="smallTitle">
                        &nbsp;新增会员【手工添加淘宝注册用户】
                    </div>
                    <div class="content">
                        <table style="width: 100%">
                    <tbody>
                        <tr>
                            <td colspan="4">
                                &nbsp;<asp:Label ID="Label1" runat="server" Text="请输入您要添加的淘宝会员昵称，可多个会员批量添加，多个会员昵称之间用英文逗号“,”分隔,如:ljkim,gggvke0806,表示添加这个淘宝会员。"
                                    ForeColor="#B00000"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;<asp:TextBox ID="txtTaobaoUser" TextMode="MultiLine" Height="40px" Width="500px"
                                    runat="server" CssClass="ui-widget-content ui-corner-all" Font-Size="12pt"></asp:TextBox>&nbsp;<asp:Label
                                        ID="lberror" runat="server" ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" align="center">
                                <asp:ImageButton ID="btnSave2" runat="server"  ImageUrl="~/Images/save.jpg"
                                    OnClick="btnSave2_Click" />
                               <asp:Label ID="lbResult" runat="server" Font-Bold="true" Font-Size="16px"
                                    ForeColor="Red" Text=""></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

