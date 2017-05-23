<%@ Page Title="" Language="C#" MasterPageFile="~/Temp/Common.Master" AutoEventWireup="true" CodeBehind="RankProduct.aspx.cs" Inherits="CTCRM.RankProduct" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
        .qu input
        {
            float: left;
            margin-left:10px;
            border-radius:5px;
            background-color:#00BFE9;
            border-color:#00BFE9;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="homewrap">
        <div class="homediv">
            <%--<div class="hmenu">
                <h4>客户管理</h4>
                <ul class="items">
                    <li class="on"><a href="CRankNew.aspx">客户等级划分</a></li> 
                    <li class="on"><a href="allmember.aspx">客户资料</a></li>
                    <li class="on"><a href="#">分组管理</a></li>
                    <li class="on"><a href="#">标签管理</a></li>  
                    <li><a href="blacklist.aspx">黑名单管理</a></li>
                    <li class="on"><a href="SynData/downloads.aspx">客户资料补全</a></li>
                    <li><a href="SynData/buyerExport.aspx">客户资料导出</a></li>
                   
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
                                <li class=""><a href="CRankNew.aspx">客户等级划分</a> </li>
                                <li class="active"><a href="RankProduct.aspx">会员折扣宝贝设置</a> </li>
                            </ul>
                            <hr style="height:0px;border:none;border-top:0 ridge green;width:100%" />
                            <div class="querypanl" style="margin-top: 10px; padding-top: 5px;">
                                <table style="width: 100%;">
                                    <tbody>
                                                    <tr>
                                                        <td height="30" style="padding-left: 10px;">
                                                            过滤宝贝范围：<select name="selectzk" id="selectzk" class="sui-input input-query select-fat" style="width: 185px;">
	                                                        <option selected="selected" value="0">显示全部宝贝</option>
	                                                        <option value="1">只显示参加会员打折的宝贝</option>
	                                                        <option value="2">只显示不参加会员打折的宝贝</option>
                                                            </select>
                                                            &nbsp;&nbsp;宝贝分类：<select name="ddlistcate" id="ddlistcate" class="sui-input input-query select-fat">
	                                                        <option selected="selected" value="">全部分类</option>

                                                            </select>
                                                            &nbsp;&nbsp;宝贝名称：<input name="txtName" type="text" id="txtName" class="sui-input input-query input-fat" size="26"/>
                                                            &nbsp;&nbsp;<input type="submit" name="btnOK" value="查 询" id="btnOK" class="sui-btn btn-large btn-primary" style="margin-left: 50px; margin-top: 2px"/>
                                                        </td>
                                
                                                    </tr>
                                     </tbody>
                               </table>
                                <br />
                               <div class="qu">
                                       <input type="submit" name="btnCanyu" value="设置已选择宝贝参与会员打折" onclick="return ok('确定要参与会员打折吗？');" id="btnCanyu" class="okbtn"/>
                                       <input type="submit" name="btnQuXiao" value="取消已选择宝贝参与会员打折" onclick="return ok('确定要取消打折吗？');" id="btnQuXiao" class="cbtn"/>
                                       <input name="hiddenValue" type="hidden" id="hiddenValue"/>
                                       <input name="hiddenValue1" type="hidden" id="hiddenValue1"/>
                                   </div>
                              
                           </div>
                           <div>
                               <asp:GridView ID="grdBuyer" runat="server" AutoGenerateColumns="False" DataKeyNames="buyer_id"
                            OnRowDataBound="grdBuyer_RowDataBound" EnableModelValidation="True">
                            <Columns>
                                <%--<asp:BoundField DataField="buyer_nick" HeaderText="买家昵称" />--%>
                                <asp:CheckBoxField />
                                <asp:TemplateField HeaderText="宝贝名称" SortExpression="buyer_nick">
                                    <ItemTemplate>
                                        <asp:Label ID="lbBuyerNick" runat="server" Text='<%# Eval("buyer_nick").ToString() %>' />
                                        <a target="_blank" href="http://www.taobao.com/webww/ww.php?ver=3&touid=<%# Eval("buyer_nick").ToString() %>&siteid=cntaobao&status=2&charset=utf-8">
                                            <img border="0" src="http://amos.alicdn.com/realonline.aw?v=2&uid=<%# Eval("buyer_nick").ToString() %>&site=cntaobao&s=2&charset=utf-8"
                                                alt="点击这里给我发消息" />
                                        </a>
                                    </ItemTemplate>
                                    <HeaderStyle Width="80px" Wrap="false" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="buyer_reallName" HeaderText="宝贝价格" >
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:BoundField>
                                <asp:BoundField DataField="cellPhone" HeaderText="是否参加会员打折">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLinkEdit" ForeColor="#8D0D02" Text="会员详细" runat="server"></asp:HyperLink>&nbsp;
                            <asp:HyperLink ID="HyerLinkEditMember" ForeColor="#8D0D02" Text="会员修改" runat="server"></asp:HyperLink>&nbsp;
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_grdBuyer"
                                    style="border-collapse: collapse;">
                                    <tr>
                                        <th scope="col">
                                        </th>
                                        <th scope="col">宝贝名称
                                        </th>
                                        <th scope="col">宝贝价格
                                        </th>
                                        <th scope="col">是否参加会员打折
                                        </th>
                                        <th scope="col">操作
                                        </th>
                                    </tr>
                                    <tr>
                                        <td colspan="10" align="center">
                                             <div id="nodata" class="nodata" runat="server">先点击右上角的<font color="blue">搜索</font>按钮如果未找到任何符合查询条件的数据,您可以<a href="SynData/downloads.aspx" >点此</a>同步店铺客户数据！</div>
                                        </td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate>
                        </asp:GridView>
                                <table cellpadding="0" cellspacing="0" align="center" width="99%" class="border">
                                    <tr>
                                        <td align="left" colspan="2">
                                         
                                            <webdiyer:aspnetpager id="AspNetPager1" cssclass="paginator" currentpagebuttonclass="cpb"
                                                runat="server" pagesize="15" alwaysshow="True" onpagechanged="AspNetPager1_PageChanged"
                                                firstpagetext="首页" lastpagetext="尾页" nextpagetext="下一页" prevpagetext="上一页" showcustominfosection="Left"
                                                custominfosectionwidth="20%" showpageindexbox="Never" custominfotextalign="Left"
                                                layouttype="Table" custominfohtml="第<font color='red'><b>%currentPageIndex%</b></font>页，共%PageCount%页，每页显示%PageSize%条记录">
                                            </webdiyer:aspnetpager>
                                        </td>
                                    </tr>
                                </table>
                                <div class="floatLeft">
                                </div>
                                <div id="msgDiv2" style="width: 350px; height: 13px; position: absolute; left: 380px; top: 120px; display: none; z-index: 9999;">
                                    <h1>
                                        <font color="white">数据查询中,请稍等........</font></h1>
                                </div>
                                <div id="zhezhang2" style="background-image: url('../Images/msgSend.gif'); width: 280px; height: 13px; position: absolute; left: 380px; top: 150px; display: none; background-image: url(http://crm.new9channel.com/Images/msgSend.gif); z-index: 9999;">
                                </div>
                           </div>
                            <br />
                            </div>
                            </div>
                </div>
             </div>
          </div>
</asp:Content>
