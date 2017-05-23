<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buyerExport.aspx.cs" Inherits="CTCRM.WIN_Aspx.SynData.buyerExport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="../../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../../CSS/css.css" rel="stylesheet" type="text/css" />
    <script src="../../Js/jquery.js" type="text/javascript"></script>
    <script src="../../win_js/buyerExport.js"></script>
    <script src="../../Js/jquery-1.7.1.min.js"></script>
    <script src="../../Js/TBApply.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script src="../../Js/Dialog.js" language="javascript" charset="utf-8" type="text/javascript"></script>
    <script language="javascript" type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <style type="text/css">
        .ta_ta,.ta_ta td,.ta_ta_bufen td
        {
            border:none;
        }
        table span
        {
            padding-left:100px;
        }
        #GridView_Jilv td,#GridView_Jilv th
        {
            width:20%;
            text-align:center;
        }
        #GridView_Jilv
        {
            margin-left:20px;
            width:70%;
            display:none;
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
                        <span class="zhandian">客户管理 >> 客户导出</span>
                    </div>
                    <div class="contt4">
                        <div class="div_tishi">
                            <p>温馨提示：</p><p style="padding-left:20px;">导出数据过程中不要关闭页面，如果您店铺的会员比较多，那么请耐心等待，下载完成后系统将提示已经完成。</p>
                            <p style="padding-left:20px;">担心店铺会员资料丢失？别急，您可以在这里导出并保存到自己的电脑硬盘上哟！</p><br />
                        </div>
                        <table border="0" cellpadding="0" cellspacing="0" class="ta_ta" style="background: #FAFAFA;border:solid 1px #F0F0F0;margin-bottom:10px;">
                            <tr>
                                <td>
                                <table class="ta_ta_bufen">
                                    <tr>
                                        <td style="text-align:left;"><span>客户来源：&nbsp;&nbsp;<asp:DropDownList ID="sources" runat="server" Width="145px" CssClass="ui-widget-content ui-corner-all">
                                                <asp:ListItem Value="全部">全部</asp:ListItem>
                                                <asp:ListItem Value="部分会员">部分会员</asp:ListItem>
                                            </asp:DropDownList></span>

                                            <span style="margin-left:45px;">会员等级：&nbsp;&nbsp;<asp:DropDownList ID="drpMember" runat="server" Width="145px" CssClass="ui-widget-content ui-corner-all">
                                            <asp:ListItem Value="all">全部</asp:ListItem>
                                            <asp:ListItem Value="0">潜在会员</asp:ListItem>
                                            <asp:ListItem Value="1">普通会员</asp:ListItem>
                                            <asp:ListItem Value="2">高级会员</asp:ListItem>
                                            <asp:ListItem Value="3">VIP会员</asp:ListItem>
                                            <asp:ListItem Value="4">至尊VIP会员</asp:ListItem>
                                        </asp:DropDownList></span>
                                        </td>                                          
                                    </tr>
                                    <tr>
                                        <td style="text-align:left;"><span>所属地区：&nbsp;&nbsp;<asp:DropDownList ID="drpArea" runat="server" Width="145px" CssClass="ui-widget-content ui-corner-all">
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
                                            <asp:ListItem Value="云南">云南省</asp:ListItem>
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
                                        </asp:DropDownList></span>

                                            <span style="margin-left:59px;">交易量：
                                                    <asp:TextBox ID="jiaoyiStart" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all" style="margin-left:5px;"></asp:TextBox>至
                                         <asp:TextBox ID="jiaoyiEnd" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox></span>
                                        </td>
                                        
                                    
                                    </tr>
                                    <tr>
                                        <td style="text-align:left"><span>交易金额：
                                                    <asp:TextBox ID="txtTradeAmountFrom" Width="60px" runat="server" style="margin-left:5px;" CssClass="ui-widget-content ui-corner-all"></asp:TextBox>至
                                         <asp:TextBox ID="txtTradeAmountTo" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox></span>

                                            <span style="margin-left:19px;">交易宝贝件数：
                                                    <asp:TextBox ID="countStart" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all" style="margin-left:5px;"></asp:TextBox>至
                                         <asp:TextBox ID="countEnd" Width="60px" runat="server" CssClass="ui-widget-content ui-corner-all"></asp:TextBox></span>
                                                </td>
                                    </tr>
                                    <tr>
                                        <td style="text-align:left">
                                            <span>时间范围：<input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()" style="margin-left:10px; width: 61px;"
                                    id="datePicker" /></span>
                                            <span style="margin-left:-107px;">至 <input runat="server" type="text" class="ui-widget-content ui-corner-all" onclick="WdatePicker()" style=" width: 61px;"
                                        id="datePickerEnd" /></span>
                                            </td>
                                        </tr>                                 
                                    
                                    </table>
                                </td>
                            </tr>
                            </table>
                        <asp:ImageButton ID="imgbtnshowJilu" ImageUrl="~/Win_Image/showExport.png" CssClass="radius_btn" style="margin-left:70px;"  runat="server" />
                        <asp:ImageButton ID="imgbtnExport" ImageUrl="~/Win_Image/export.png" CssClass="radius_btn" 
                                            runat="server" OnClick="imgbtnExport_Click" style="margin-left:100px;"
                                             />
                                    <asp:ImageButton ID="ImageButtonCancle" ImageUrl="~/Win_Image/cancleExport.png" CssClass="radius_btn" 
                                            runat="server"  style="margin-left:100px;"
                                            OnClick="ImageButtonCancle_Click" />
                        <div class="jilv">
                            <asp:GridView ID="GridView_Jilv" runat="server" EnableModelValidation="True">
                            </asp:GridView>
                            
                            </div>
                    </div>
                </div>
            </div>
        </div>
         <script type="text/javascript">
             document.getElementById("A9").className += ' NavSelected';
                 </script> 
    </div>
    </form>
</body>
</html>
