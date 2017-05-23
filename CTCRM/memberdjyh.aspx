<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberdjyh.aspx.cs" MasterPageFile="~/Temp/Common.Master" Inherits="CTCRM.memberdjyh" %>

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
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>会员中心</h4>
                <ul class="items">
                    <li><a href="allmember.aspx">会员管理</a></li>
                     <li><a href="systemReport.aspx">增长分析</a></li>
                    <li><a href="areaStatic.aspx">区域分析</a></li>
                    <li class="on"><a href="blacklist.aspx">黑名单管理</a></li>
                     <li><a href="SynData/buyerExport.aspx">会员导出</a></li>
                    <li><a href="systemSetting.aspx">系统设置</a></li>
                </ul>
            </div>
            <div class="righter">

                <div class="pDiv2">
                    <div class="title2">
                        会员等级优惠
                    </div>
                    <div class="contt4">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <label for="BuyerNick">
                                        会员等级优惠<font color="red">（折扣设置不能低于最低折扣（7.0 折）;请谨慎设置会员等级，一旦设置会员只升级不降级。）</font>
                                    </label>
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
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
</asp:Content>
