<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Common.Master" AutoEventWireup="true" CodeBehind="CRankNew.aspx.cs" Inherits="CTCRM.CRankNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/site.css" rel="stylesheet" type="text/css" />
    <link href="CSS/validationEngine.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/scaffolding.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/jquery-ui.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/home.css" rel="stylesheet" type="text/css" />
    <link href="CSS/dialog.css" rel="Stylesheet" type="text/css" />
    <link href="CSS/css.css" rel="stylesheet" type="text/css" />


    <base target="_self" />
    <script src="Js/jquery.js" type="text/javascript"></script>
    <script src="Js/TBApply.js" type="text/javascript"></script>
    <script src="Js/DialogMsg.js" type="text/javascript"></script>

    <style type="text/css">
        /*淘宝风格*/
        .paginator {
            font: 12px Arial, Helvetica, sans-serif;
            padding: 10px 20px 10px 0;
            margin: 0px;
        }

            .paginator a {
                border: solid 1px #ccc;
                color: #0063dc;
                cursor: pointer;
                text-decoration: none;
            }

                .paginator a:visited {
                    padding: 1px 6px;
                    border: solid 1px #ddd;
                    background: #fff;
                    text-decoration: none;
                }

            .paginator .cpb {
                border: 1px solid #F50;
                font-weight: 700;
                color: #F50;
                background-color: #ffeee5;
            }

            .paginator a:hover {
                border: solid 1px #F50;
                color: #f60;
                text-decoration: none;
            }

            .paginator a, .paginator a:visited, .paginator .cpb, .paginator a:hover {
                float: left;
                height: 16px;
                line-height: 16px;
                min-width: 10px;
                _width: 10px;
                margin-right: 5px;
                text-align: center;
                white-space: nowrap;
                font-size: 12px;
                font-family: Arial,SimSun;
                padding: 0 3px;
            }
        .button
        {
            float: left;
            margin-left:20px;
            background-color:#00BFE9;
            border-color:#00BFE9;
            border-radius:5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>客户管理</h4>
                <ul class="items">
                    <li class="active"><a href="CRankNew.aspx">客户等级划分</a></li> 
                    <li class="on"><a href="allmember.aspx">客户资料</a></li>
                    <li class="on"><a href="#">分组管理</a></li>
                    <li class="on"><a href="#">标签管理</a></li>  
                    <li class="on"><a href="blacklist.aspx">黑名单管理</a></li>
                    <li class="on"><a href="SynData/downloads.aspx">客户资料补全</a></li>
                    <li class="on"><a href="SynData/buyerExport.aspx">客户资料导出</a></li>
                   
                </ul>
            </div>--%>
            </div>
            <div class="righter">
                <div class="pDiv2">
                    <div class="contt4">
                        <div class="pagemainhead">
                            <h1 class="headh">
                                客户等级设置</h1>
                            <br />
                            <div class="memopanl">
                                使用会员等级区分买家的级别，不同级别的买家可以享受不同的折扣率，注意最低折扣不能低于7折，填写折扣请注意，九八折，填写9.8而不是0.98</div>
                        </div>
                        <br />
                        <div class="tabbable" style="">
                            <br />
                            <ul id="myTab" class="adful">
                                <li class="active"><a href="CRankNew.aspx">客户等级划分</a> </li>
                                <li class=""><a href="RankProduct.aspx">会员折扣宝贝设置</a> </li>
                                <%--<li class=""><a href="/List/CustomerTemplate.aspx">会员特权展示</a> </li>--%>
                            </ul>
                            <hr style="height:0px;border:none;border-top:0 ridge #00BFE9;width:100%" />
                            <br />
                            <%--<div class="msg">
                                提示：设置会员等级条件和折扣必须为递增形式，并且普通会员条件至少有一个不为0，所设置折扣不能低于7折。请谨慎设置会员等级，一旦设置会员只升级不降级。
                            </div>--%>
                            <table>
                    <thead>
                        <tr>
                            <th width="9%" style="border-bottom: solid 1px #E2E2E2; padding-bottom: 7px; padding-top: 20px;">
                                会员等级
                            </th>
                            <th width="11%" style="border-bottom: solid 1px #E2E2E2; padding-bottom: 7px; padding-top: 20px;">
                                满足以下条件可自动升级
                            </th>
                            <th width="11%" style="border-bottom: solid 1px #E2E2E2; padding-bottom: 7px; padding-top: 20px;">
                            </th>
                            <%--<th width="11%" style="padding-bottom: 7px; border-bottom: solid 1px #ddd;">
                            </th>--%>
                        </tr>
                    </thead>
                    <tbody>
                        
                        <tr>
                            <td style="text-align: center; padding: 25px 0; border-bottom: solid 1px #ddd;">
                                普通会员(VIP1)
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                交易额<input name="txtAmount1" type="text" id="txtAmount1" onkeyup="CheckMoney(this);" value="0" onpaste="XssGuoLv('txtAmount1')" class="input-default" onblur="CheckMoney2(this);" onchange="XssGuoLv('txtAmount1')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtAmount1')"/>元&nbsp;或&nbsp;<input name="txtTime1" type="text" id="txtTime1" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" value="0" onpaste="XssGuoLv('txtTime1')" class="input-default" onblur="CheckTime(this);" onchange="XssGuoLv('txtTime1')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtTime1')" size="30"/>&nbsp;笔
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">

                            </td>
                            <%--<td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <a href="javascript:void(0)" id="member_set_1" class="bke_li_a_1 bke_li_awd" index="1" style="display: none;"/></a>
                                <input name="member_input_1" type="hidden" id="member_input_1" value="1"/>
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 25px 0; border-bottom: solid 1px #ddd;">
                                高级会员(VIP2)
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                交易额<input name="txtAmount2" type="text" id="txtAmount2" onkeyup="CheckMoney(this);" value="0" onpaste="XssGuoLv('txtAmount2')" class="input-default" onblur="CheckMoney2(this);" onchange="XssGuoLv('txtAmount2')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtAmount2')" size="30"/>元&nbsp;或&nbsp;<input name="txtTime2" type="text" id="txtTime2" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" value="0" onpaste="XssGuoLv('txtTime2')" class="input-default" onblur="CheckTime(this);" onchange="XssGuoLv('txtTime2')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtTime2')" size="30"/>&nbsp;笔
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <div >
                                    <img class="switch2" onclick="change('switch2');" src="Images/rate/closed.png" id="0" />
				                </div>
                            </td>
                            <%--<td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <a href="javascript:void(0)" class="bke_li_a_1 bke_li_awd" id="member_set_2" index="2" onmouseover="TiShi(this)"></a>
                                <input name="member_input_2" type="hidden" id="member_input_2" value="1"/>
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 25px 0; border-bottom: solid 1px #ddd;">
                                VIP会员(VIP3)
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                交易额<input name="txtAmount3" type="text" id="txtAmount3" onkeyup="CheckMoney(this);" value="0" onpaste="XssGuoLv('txtAmount3')" class="input-default" onblur="CheckMoney2(this);" onchange="XssGuoLv('txtAmount3')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtAmount3')" size="30"/>元&nbsp;或&nbsp;<input name="txtTime3" type="text" id="txtTime3" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" value="0" onpaste="XssGuoLv('txtTime3')" class="input-default" onblur="CheckTime(this);" onchange="XssGuoLv('txtTime3')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtTime3')" size="30"/>&nbsp;笔
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <div >
                                    <img class="switch3" onclick="change('switch3');" src="Images/rate/closed.png" id="0" />
				                </div>
                            </td>
                            <%--<td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <a href="javascript:void(0)" class="bke_li_a_1 bke_li_awd" id="member_set_3" index="3" onmouseover="TiShi(this)"></a>
                                <input name="member_input_3" type="hidden" id="member_input_3" value="1"/>
                            </td>--%>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding: 25px 0; border-bottom: solid 1px #ddd;">
                                至尊VIP会员(VIP4)
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                交易额<input name="txtAmount4" type="text" id="txtAmount4" onkeyup="CheckMoney(this);" value="0" onpaste="XssGuoLv('txtAmount4')" class="input-default" onblur="CheckMoney2(this);" onchange="XssGuoLv('txtAmount4')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtAmount4')" size="30"/>元&nbsp;或&nbsp;<input name="txtTime4" type="text" id="txtTime4" onkeyup="this.value=this.value.replace(/[^\d]/g,'')" value="0" onpaste="XssGuoLv('txtTime4')" class="input-default" onblur="CheckTime(this);" onchange="XssGuoLv('txtTime4')" style="width: 52px; height: 23px;" onkeydown="XssGuoLv('txtTime4')" size="30"/>&nbsp;笔
                            </td>
                            <td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <div >
                                    <img class="switch4" onclick="change('switch4');" src="Images/rate/closed.png" id="0" />
				                </div>
                            </td>
                            <%--<td style="text-align: center; border-bottom: solid 1px #ddd;">
                                <a href="javascript:void(0)" class="bke_li_a_1 bke_li_awd" id="member_set_4" index="4" onmouseover="TiShi(this)"></a>
                                <input name="member_input_4" type="hidden" id="member_input_4" value="1"/>
                            </td>--%>
                        </tr>
                    </tbody>
                </table>
                        
                            <br />
                        </div>
                        <input class="button" id="save" type="button" value="保存店铺客户折扣设置" />
                        <input class="button" id="cancle" type="button" value="取消所有客户折扣设置" />
                        <input class="button" id="classified" type="button" value="会员归类" />                    </div>
                </div>
             </div>
          </div>
         <script type="text/javascript">
             $(function () {
                 $(".adful li").click(function () {
                     $(".adful li").eq($(this).index()).addClass("cur").siblings().removeClass("cur");
                 })
             })
             function change(s) {
                 var o = "." + s;
                 var ss = $(o).attr("id");
                 if (ss == "0") {
                     $(o).attr("src", "Images/2open.png");
                     $(o).attr("id","1");
                 }
                 if (ss == "1") {
                     $(o).attr("src", "Images/rate/closed.png");
                     $(o).attr("id", "0");
                 }
             };

             document.getElementById("A9").className += ' NavSelected';
         </script> 
</asp:Content>
