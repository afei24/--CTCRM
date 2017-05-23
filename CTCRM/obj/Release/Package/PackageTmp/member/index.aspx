<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="CTCRM.member.index"
    MasterPageFile="~/Temp/Common.Master" MaintainScrollPositionOnPostback="true" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <link href="../CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="../CSS/home.css" rel="stylesheet" />
    <link href="../CSS/css.css" rel="stylesheet" />
    <script src="../Js/jquery-1.7.1.min.js" type="text/javascript"></script>
    <script src="../Js/DialogMsg.js" type="text/javascript"></script>
    <base target="_self" />
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="homewrap">
        <div class="homediv">
            <div class="hmenu">
                <h4>订单中心</h4>
                <ul class="items">
                    <li class="on"><a href="index.aspx">会员关怀</a></li>
                    <li><a href="retureGoods.aspx">退货处理</a></li>
                    <li><a href="reminderHis.aspx">提醒记录</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">                 
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 20%">1、发货提醒支持所有快递公司：支持EMS、顺丰、申通、中通、圆通、韵达、宅急送、天天、汇通、港中能达、优速物流11家快递公司。
                                    </td>
                                </tr>                               
                                <tr>
                                    <td style="width: 20%">2、到货提醒仅对线上发货的运单有效，使用线下发货的运单，不支持运单状态的实时跟踪。
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="infoArea" runat="server" id="msgReminder">
                            <div class="ui-state-error ui-corner-all" style="width: 100%;">
                                <strong>&nbsp;&nbsp;温馨提示:</strong> 亲，信使的送信时间是9:00-21:00之间，现在它在养精蓄锐呢，Zz..Zz..
                            </div>
                        </div>
                        <div class="infoArea" runat="server" id="msgAcountCheck">
                            <div class="ui-state-error ui-corner-all" style="width: 100%; text-align: center; font-size: 18px; font-weight: bold; vertical-align: middle">
                                <asp:Label ID="lbMsgTip" runat="server" Text="亲，您还未开通短信账户或者账户余额不足，现在就去？"></asp:Label><a
                                    href="../messageSetting.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buy.png" /></a>
                            </div>
                        </div>
                         <div class="ui-state-error ui-corner-all" style="width: 99%; text-align: left; font-size: 17px; font-weight: bold; vertical-align: middle">
                            <strong>&nbsp;注意！！</strong>千万记得开启获取数据授权哟<asp:ImageButton ID="btnAuothOpen" runat="server"
                                ImageUrl="~/Images/rate/closed.png" OnClick="btnAuothOpen_Click"
                                OnClientClick="dialog.DOpen(this)" />&nbsp;<asp:HyperLink ID="versionControl" Font-Bold="true" Font-Size="16px" Target="_blank"
                                    ForeColor="Red" runat="server" NavigateUrl="http://fuwu.taobao.com/ser/detail.htm?service_code= ts-1811102"
                                    Text="仅限正式版用户,现在去升级？"></asp:HyperLink>&nbsp;<asp:Label ID="lberror" ForeColor="Blue"
                                        runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                       <asp:Label ID="Label6" runat="server" Text="未付款提醒" Font-Bold="true" Font-Size="12pt"
                         ForeColor="#E17009"></asp:Label>【<font style="color: Blue">批量提醒未付款会员尽快付款：买家拍下后2小时未付款则自动提醒</font>】 
                    </div>
                    <div class="contt4">    
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label7" runat="server" Text="等待付款提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label8" runat="server" Text="提醒(拍下宝贝后一段时间内未付款的会员)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgAutoStart" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="点击按钮,可以开启或关闭"
                                                OnClick="btnimgAutoStart_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp1" Checked="true" GroupName="unpay" Text="亲！您**下单时间**拍的宝贝小店已为您备好，付款后我们立即发货，谢谢光临"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp2" GroupName="unpay" Text="亲！我们时刻关心您的购物心情：您**下单时间**拍的宝贝还有货哦,或者您还可以看看其他宝贝"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp3" GroupName="unpay" Text="亲！您**下单时间**拍的宝贝小店已为您备好,请尽快付.款，时间过长会自动关闭的哦"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoUnpayCus" GroupName="unpay" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**下单时间**|**收货人**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtUnpayCusContent" runat="server"
                                            Font-Size="12px" TextMode="MultiLine" Height="50px" Width="450px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                          <asp:Label ID="Label10" runat="server" Text="付款关怀提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">买家付款时，发短信给买家</font>】
                     </div>
                    <div class="contt4">
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label12" runat="server" Text="买家付款提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label13" runat="server" Text="关怀(当买家拍下宝贝付款时，发短信关怀买家)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgUnconfirmType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="点击按钮,可以开启或关闭"
                                                OnClick="btnimgUnconfirmType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType1" Checked="true" GroupName="pay" Text="亲爱的**收货人**,感谢购买我们的商品！预售商品将在7天内陆续发出,
我们将随时跟踪播报状态。亲如果需要换型号可以联系客服哟"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType2" GroupName="pay" Text="亲爱的**收货人**,感谢购买我们的商品！我们将随时跟踪播报状态，
方便您及时了解.亲如果有问题可以联系客服哟"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType3" GroupName="pay" Text="亲爱的主人,感谢您拍下宝贝啦，店家会在3个工作日内将我送出哟，偶一定
不贪玩，一般2到5天就会飞奔到你了身边了哦"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayTypeCus" GroupName="pay" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**收货人**|**下单时间**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtPayCus" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                      <asp:Label ID="Label15" runat="server" Text="发货提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">点发货后，自动发短信给买家</font>】
                     </div>
                    <div class="contt4">                    
                      <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label1" runat="server" Text="发货提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label3" runat="server" Text="提醒(会员付款后卖家已经发货)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgshippingType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="点击按钮,可以开启或关闭"
                                                OnClick="btnimgshippingType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont1" Checked="true" GroupName="1" Text="亲！您的宝贝于**发货时间**发货**快递公司**：**快递单号**多谢惠顾"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont2" GroupName="1" Text="亲，时刻关心您的购物心情，您在我店购买的宝贝已于**发货时间**由**快递公司**：**快递单号**发货，欢迎下次光临"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont3" GroupName="1" Text="亲！您的包裹**快递公司**：**快递单号**已于**发货时间**发货，愿她以火箭般的速度飞到您手中！期待您打个全五分"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShiping" GroupName="1" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**发货时间**|**快递公司**|**快递单号**|**收货人**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtShippingContent" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>   
                    </div>

                    <div class="title2">
                      <asp:Label ID="Label19" runat="server" Text="延迟发货提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">对延时发货的买家,自动发送短信进行安抚：默认对1天前买家已付款未发货的订单进行提醒</font>】
                     </div>
                    <div class="contt4">
                        <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label20" runat="server" Text="延迟发货提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label21" runat="server" Text="提醒(对延时发货的买家，自动发送短信进行安抚)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnDelayShipping" ImageUrl="~/Images/work_off.gif"
                                                runat="server" ToolTip="点击按钮,可以开启或关闭" OnClick="btnDelayShipping_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoDelayShipping" Checked="true" GroupName="rdodelay" Text="主人，偶是你的宝贝啦，店家会在3个工作日内将我发出噢,偶一定不贪玩,一般3到5天左右就飞奔到你的身边了哦~"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoDelayShipCus" GroupName="rdodelay" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**收货人**|**快递单号**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtDelayShippingCus" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                     <asp:Label ID="Label14" runat="server" Text="到达提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">快递达到买家所在城市，自动发送短信给买家</font>】
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label2" runat="server" Text="到达提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label4" runat="server" Text="提醒(快递到达收货城市时，自动给买家发送短信)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnArrivedType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="点击按钮,可以开启或关闭"
                                                OnClick="btnArrivedType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton4" Checked="true" GroupName="111" Text="亲，您的宝贝已到**当前位置**，请注意查收。"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton5" GroupName="111" Text="您在本店购买的宝贝已到**当前位置**，请验货后再签收。"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton6" GroupName="111" Text="亲，您的包裹已由**快递公司**运抵**当前位置**，查收后有问题请联系。"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton7" GroupName="111" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**当前位置**|**快递公司**|**收货人**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtArrivedContent" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                       <asp:Label ID="Label16" runat="server" Text="签收提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">买家签收后，自动发送短信给买家</font>】
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label17" runat="server" Text="签收提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label18" runat="server" Text="提醒(淘宝物流状态变为买家已签收时，发短信给买家)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="imgbtnSign" ImageUrl="~/Images/work_off.gif" ToolTip="点击按钮,可以开启或关闭"
                                                runat="server" OnClick="imgbtnSign_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign1" Checked="true" GroupName="21" Text="亲爱的**收货人**,物流显示您的订单已签收，如对产品服务满意,请全打5分好评鼓励我们;如果不满意，请联系我们。祝您生活愉快"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign2" GroupName="21" Text="亲爱滴**收货人**：这孩子以后请您多多照顾,如果觉得不乖,得告诉家长，您觉得还可以的话,请动动鼠标，给个5分好评鼓励下"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign3" GroupName="21" Text="亲，显示您的订单已签收，如对产品服务满意,请打全5分好评鼓励我们;如不满意，请联系我们，我们会服务到您满意！"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSignCus" GroupName="21" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**收货人**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtSignCus" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                    <asp:Label ID="Label22" runat="server" Text="回款提醒" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>【<font style="color: Blue">对买家已签收还未确认收货的订单,系统会自动发短信提醒买家确认收货.默认对签收5小时未确认的买家发送提醒</font>】
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label23" runat="server" Text="回款提醒"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label24" runat="server" Text="提醒(提醒买家签收后尽快确认收货，以快速回笼资金)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnHuiZJ" ImageUrl="~/Images/work_off.gif" ToolTip="点击按钮,可以开启或关闭"
                                                runat="server" OnClick="btnHuiZJ_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoHuiZJCont" Checked="true" GroupName="huizj" Text="亲爱的**收货人**，我们的交易已经成功，希望您能确认+好评，我们才有充裕的资金流转,来提高店铺质量和服务，祝您生活愉快！"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoHuiZJCus" GroupName="huizj" Text="我要自己设置提醒内容【<font color=red>提醒内容可选参数：**收货人**</font>】<font color=blue>自定义提醒内容设置后请联系客服备案，否则不成功！<font color=red>" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtHuiZJContent" runat="server"
                                            TextMode="MultiLine" Width="450px" Font-Size="12px" Height="50px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3"></td>
                                    </tr>
                                </tbody>
                            </table>
                    </div>

                    <div class="title2">
                      <asp:Label ID="Label47" runat="server" Text="高级设置" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>
                     </div>
                    <div class="contt4">
                       
                        <div class="content" id="ContentDiv5">
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 10%; vertical-align: middle">
                                            <asp:Label ID="Label5" runat="server" Text="发送设置："></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 90%; vertical-align: middle">
                                            <asp:Label ID="Label11" runat="server" Text="订单金额大于"></asp:Label>&nbsp;<asp:TextBox
                                                ID="txtAmount" Width="80px" CssClass="ui-widget-content ui-corner-all" Text="0" runat="server"></asp:TextBox>&nbsp;元才发送
                                <asp:Label ID="lberror2" Font-Size="16px" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; vertical-align: middle">
                                            <asp:Label ID="Label9" runat="server" Text="会员过滤："></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 90%; vertical-align: middle">使用黑名单<a href="../blacklist.aspx" target="_blank">[管理]</a>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 20%"></td>
                                        <td colspan="3" style="width: 80%;">
                                            &nbsp;&nbsp;<asp:ImageButton ID="btnSave" ImageUrl="~/Images/save.jpg" runat="server" OnClick="btnSave_Click" />&nbsp;<asp:Label
                                                ID="lbMsg" ForeColor="Red" runat="server" Font-Size="18px" Font-Bold="true" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                             <table>
                                <tr>
                                    <td>签名预览：
                                    </td>
                                    <td>
                                        <asp:Label ID="lbShopSignPre" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>自定义签名(物流提醒&促销短信均可使用)：
                                    </td>
                                    <td>
                                        <asp:TextBox
                                            ID="txtShopSign" Width="200px" CssClass="ui-widget-content ui-corner-all" Text="" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 20%"></td>
                                    <td colspan="3" style="width: 80%; text-align: left">&nbsp;&nbsp;<asp:ImageButton ID="imgBtnSetSign" ImageUrl="~/Images/save.jpg" runat="server" OnClick="imgBtnSetSign_Click" />&nbsp;<asp:Label
                                        ID="lbSignMsg" ForeColor="Red" runat="server" Font-Size="18px" Font-Bold="true" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
        </div>
        <script type="text/javascript">
            document.getElementById("A5").className += ' NavSelected';
        </script>
    </div>
    </div>
</asp:Content>
