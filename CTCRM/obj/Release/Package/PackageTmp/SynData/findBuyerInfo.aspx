<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="findBuyerInfo.aspx.cs" Inherits="CTCRM.SynData.findBuyerInfo" MasterPageFile="~/Temp/Common.Master" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <script src="../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <script src="../Js/common.js" type="text/javascript"></script>   
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="samain">
        <div class="rightside" style="height: 100%"> 
            <div class="infoArea">
                <div class="smallTitle">
                    &nbsp;<img src="../Images/2fenliu.png" />导入淘宝历史订单,找回买家电话号码等信息
                </div>
                <div class="content">
                    <table>
                        <tbody>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label5" runat="server" ForeColor="Red" Text="注意：导入历史订单信息需要两步操作，这两步操作必须连续顺序完成，否则可能出现数据不完整！"></asp:Label><br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" Font-Bold="true" runat="server" Text="第一步：从淘宝下载历史订单"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;1、<a target="_blank" href="http://tradearchive.taobao.com/trade/itemlist/list_export_order.htm">点击此处直接进入淘宝下载历史订单</a>（这个链接等同于如下操作：进入淘宝卖家的”已卖出宝贝“页面，点击最后一栏的”三个月前订单“，点击上面的”导出/下载历史订单“按钮）。<br />
                                    &nbsp;&nbsp;&nbsp;2、输入需要导出的成交时间，就能导出订单了（开始时间选择标准以会员管理菜单中会员列表最后一页最后一个会员的日期为准）。<br />
                                    &nbsp;&nbsp;&nbsp;3、在淘宝处理完成后，一定要点击后面的“下载订单报表”，这个才是我们需要的。<br />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="Label7" Font-Bold="true" runat="server" Text="第二步：上传历史订单到店铺管家"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="2">
                                    &nbsp;&nbsp;&nbsp;选择第一步保存的订单信息文件，点击上传按钮(不要做任何更改，店铺管家只识别从淘宝直接导出的数据格式)(也不要做打开保存动作，打开后即使不做任何修改，文件格式也变了)，店铺管家将自动提取客户电子邮件、手机、交易等信息。<br />
                                    &nbsp;&nbsp;&nbsp;<font color="red">(最大可上传文件大小为20M，超过20M请在淘宝导出的时候分时间段导出！)</font>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    订单报表CSV文件：
                                </td>
                                <td>
                                    <asp:FileUpload ID="fileOrderUpload" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:ImageButton
                                            ID="imgImportData" runat="server" ImageUrl="~/Images/import.jpg" OnClick="imgImportData_Click"
                                            OnClientClick="dialog.DOpen(this)" />
                                    &nbsp;<asp:Label ID="lbError" Font-Size="14pt" runat="server" ForeColor="Red" Text=""></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <div id="msgDiv" style="width: 380px; height: 13px; position: absolute; left: 580px;
        top: 320px; display: none; z-index: 9999;">
        <h1>
            <font color="white">正在处理,请稍等........</font></h1>
    </div>
    <div id="zhedang" style="background-image: url('../Images/msgSend.gif'); width: 280px;
        height: 13px; position: absolute; left: 580px; top: 350px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif);
        z-index: 9999;">
    </div>
    </div>
</asp:Content>
