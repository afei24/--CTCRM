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
                <h4>��������</h4>
                <ul class="items">
                    <li class="on"><a href="index.aspx">��Ա�ػ�</a></li>
                    <li><a href="retureGoods.aspx">�˻�����</a></li>
                    <li><a href="reminderHis.aspx">���Ѽ�¼</a></li>
                </ul>
            </div>
            <div class="righter">
                <div class="pDiv2">                 
                    <div class="contt4">
                        <table>
                            <tbody>
                                <tr>
                                    <td style="width: 20%">1����������֧�����п�ݹ�˾��֧��EMS��˳�ᡢ��ͨ����ͨ��Բͨ���ϴլ���͡����졢��ͨ�������ܴ��������11�ҿ�ݹ�˾��
                                    </td>
                                </tr>                               
                                <tr>
                                    <td style="width: 20%">2���������ѽ������Ϸ������˵���Ч��ʹ�����·������˵�����֧���˵�״̬��ʵʱ���١�
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div class="infoArea" runat="server" id="msgReminder">
                            <div class="ui-state-error ui-corner-all" style="width: 100%;">
                                <strong>&nbsp;&nbsp;��ܰ��ʾ:</strong> �ף���ʹ������ʱ����9:00-21:00֮�䣬�����������������أ�Zz..Zz..
                            </div>
                        </div>
                        <div class="infoArea" runat="server" id="msgAcountCheck">
                            <div class="ui-state-error ui-corner-all" style="width: 100%; text-align: center; font-size: 18px; font-weight: bold; vertical-align: middle">
                                <asp:Label ID="lbMsgTip" runat="server" Text="�ף�����δ��ͨ�����˻������˻����㣬���ھ�ȥ��"></asp:Label><a
                                    href="../messageSetting.aspx"><asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buy.png" /></a>
                            </div>
                        </div>
                         <div class="ui-state-error ui-corner-all" style="width: 99%; text-align: left; font-size: 17px; font-weight: bold; vertical-align: middle">
                            <strong>&nbsp;ע�⣡��</strong>ǧ��ǵÿ�����ȡ������ȨӴ<asp:ImageButton ID="btnAuothOpen" runat="server"
                                ImageUrl="~/Images/rate/closed.png" OnClick="btnAuothOpen_Click"
                                OnClientClick="dialog.DOpen(this)" />&nbsp;<asp:HyperLink ID="versionControl" Font-Bold="true" Font-Size="16px" Target="_blank"
                                    ForeColor="Red" runat="server" NavigateUrl="http://fuwu.taobao.com/ser/detail.htm?service_code= ts-1811102"
                                    Text="������ʽ���û�,����ȥ������"></asp:HyperLink>&nbsp;<asp:Label ID="lberror" ForeColor="Blue"
                                        runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="pDiv2">
                    <div class="title2">
                       <asp:Label ID="Label6" runat="server" Text="δ��������" Font-Bold="true" Font-Size="12pt"
                         ForeColor="#E17009"></asp:Label>��<font style="color: Blue">��������δ�����Ա���츶�������º�2Сʱδ�������Զ�����</font>�� 
                    </div>
                    <div class="contt4">    
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label7" runat="server" Text="�ȴ���������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label8" runat="server" Text="����(���±�����һ��ʱ����δ����Ļ�Ա)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgAutoStart" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="�����ť,���Կ�����ر�"
                                                OnClick="btnimgAutoStart_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp1" Checked="true" GroupName="unpay" Text="�ף���**�µ�ʱ��**�ĵı���С����Ϊ�����ã��������������������лл����"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp2" GroupName="unpay" Text="�ף�����ʱ�̹������Ĺ������飺��**�µ�ʱ��**�ĵı������л�Ŷ,�����������Կ�����������"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdounpayTemp3" GroupName="unpay" Text="�ף���**�µ�ʱ��**�ĵı���С����Ϊ������,�뾡�츶.�ʱ��������Զ��رյ�Ŷ"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoUnpayCus" GroupName="unpay" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**�µ�ʱ��**|**�ջ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                          <asp:Label ID="Label10" runat="server" Text="����ػ�����" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">��Ҹ���ʱ�������Ÿ����</font>��
                     </div>
                    <div class="contt4">
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label12" runat="server" Text="��Ҹ�������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label13" runat="server" Text="�ػ�(��������±�������ʱ�������Źػ����)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgUnconfirmType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="�����ť,���Կ�����ر�"
                                                OnClick="btnimgUnconfirmType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType1" Checked="true" GroupName="pay" Text="�װ���**�ջ���**,��л�������ǵ���Ʒ��Ԥ����Ʒ����7����½������,
���ǽ���ʱ���ٲ���״̬���������Ҫ���ͺſ�����ϵ�ͷ�Ӵ"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType2" GroupName="pay" Text="�װ���**�ջ���**,��л�������ǵ���Ʒ�����ǽ���ʱ���ٲ���״̬��
��������ʱ�˽�.����������������ϵ�ͷ�Ӵ"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayType3" GroupName="pay" Text="�װ�������,��л�����±���������һ���3���������ڽ����ͳ�Ӵ��żһ��
��̰�棬һ��2��5��ͻ�ɱ������������Ŷ"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoPayTypeCus" GroupName="pay" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**�ջ���**|**�µ�ʱ��**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                      <asp:Label ID="Label15" runat="server" Text="��������" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">�㷢�����Զ������Ÿ����</font>��
                     </div>
                    <div class="contt4">                    
                      <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label1" runat="server" Text="��������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label3" runat="server" Text="����(��Ա����������Ѿ�����)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnimgshippingType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="�����ť,���Կ�����ر�"
                                                OnClick="btnimgshippingType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont1" Checked="true" GroupName="1" Text="�ף����ı�����**����ʱ��**����**��ݹ�˾**��**��ݵ���**��л�ݹ�"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont2" GroupName="1" Text="�ף�ʱ�̹������Ĺ������飬�����ҵ깺��ı�������**����ʱ��**��**��ݹ�˾**��**��ݵ���**��������ӭ�´ι���"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShippingCont3" GroupName="1" Text="�ף����İ���**��ݹ�˾**��**��ݵ���**����**����ʱ��**������Ը���Ի������ٶȷɵ������У��ڴ������ȫ���"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoShiping" GroupName="1" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**����ʱ��**|**��ݹ�˾**|**��ݵ���**|**�ջ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                      <asp:Label ID="Label19" runat="server" Text="�ӳٷ�������" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">����ʱ���������,�Զ����Ͷ��Ž��а�����Ĭ�϶�1��ǰ����Ѹ���δ�����Ķ�����������</font>��
                     </div>
                    <div class="contt4">
                        <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label20" runat="server" Text="�ӳٷ�������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label21" runat="server" Text="����(����ʱ��������ң��Զ����Ͷ��Ž��а���)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnDelayShipping" ImageUrl="~/Images/work_off.gif"
                                                runat="server" ToolTip="�����ť,���Կ�����ر�" OnClick="btnDelayShipping_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoDelayShipping" Checked="true" GroupName="rdodelay" Text="���ˣ�ż����ı���������һ���3���������ڽ��ҷ�����,żһ����̰��,һ��3��5�����Ҿͷɱ�����������Ŷ~"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoDelayShipCus" GroupName="rdodelay" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**�ջ���**|**��ݵ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                     <asp:Label ID="Label14" runat="server" Text="��������" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">��ݴﵽ������ڳ��У��Զ����Ͷ��Ÿ����</font>��
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label2" runat="server" Text="��������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label4" runat="server" Text="����(��ݵ����ջ�����ʱ���Զ�����ҷ��Ͷ���)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnArrivedType" ImageUrl="~/Images/work_off.gif" runat="server" ToolTip="�����ť,���Կ�����ر�"
                                                OnClick="btnArrivedType_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton4" Checked="true" GroupName="111" Text="�ף����ı����ѵ�**��ǰλ��**����ע����ա�"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton5" GroupName="111" Text="���ڱ��깺��ı����ѵ�**��ǰλ��**�����������ǩ�ա�"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton6" GroupName="111" Text="�ף����İ�������**��ݹ�˾**�˵�**��ǰλ��**�����պ�����������ϵ��"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="RadioButton7" GroupName="111" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**��ǰλ��**|**��ݹ�˾**|**�ջ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                       <asp:Label ID="Label16" runat="server" Text="ǩ������" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">���ǩ�պ��Զ����Ͷ��Ÿ����</font>��
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label17" runat="server" Text="ǩ������"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label18" runat="server" Text="����(�Ա�����״̬��Ϊ�����ǩ��ʱ�������Ÿ����)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="imgbtnSign" ImageUrl="~/Images/work_off.gif" ToolTip="�����ť,���Կ�����ر�"
                                                runat="server" OnClick="imgbtnSign_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign1" Checked="true" GroupName="21" Text="�װ���**�ջ���**,������ʾ���Ķ�����ǩ�գ���Բ�Ʒ��������,��ȫ��5�ֺ�����������;��������⣬����ϵ���ǡ�ף���������"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign2" GroupName="21" Text="�װ���**�ջ���**���⺢���Ժ���������չ�,������ò���,�ø��߼ҳ��������û����ԵĻ�,�붯����꣬����5�ֺ���������"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSign3" GroupName="21" Text="�ף���ʾ���Ķ�����ǩ�գ���Բ�Ʒ��������,���ȫ5�ֺ�����������;�粻���⣬����ϵ���ǣ����ǻ���������⣡"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoSignCus" GroupName="21" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**�ջ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                    <asp:Label ID="Label22" runat="server" Text="�ؿ�����" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>��<font style="color: Blue">�������ǩ�ջ�δȷ���ջ��Ķ���,ϵͳ���Զ��������������ȷ���ջ�.Ĭ�϶�ǩ��5Сʱδȷ�ϵ���ҷ�������</font>��
                     </div>
                    <div class="contt4">
                    <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 20%; vertical-align: middle">
                                            <asp:Label ID="Label23" runat="server" Text="�ؿ�����"></asp:Label>
                                        </td>
                                        <td style="width: 50%; vertical-align: middle">
                                            <asp:Label ID="Label24" runat="server" Text="����(�������ǩ�պ󾡿�ȷ���ջ����Կ��ٻ����ʽ�)"></asp:Label>
                                        </td>
                                        <td style="width: 15%">
                                            <asp:ImageButton ID="btnHuiZJ" ImageUrl="~/Images/work_off.gif" ToolTip="�����ť,���Կ�����ر�"
                                                runat="server" OnClick="btnHuiZJ_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoHuiZJCont" Checked="true" GroupName="huizj" Text="�װ���**�ջ���**�����ǵĽ����Ѿ��ɹ���ϣ������ȷ��+���������ǲ��г�ԣ���ʽ���ת,����ߵ��������ͷ���ף��������죡"
                                                runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RadioButton ID="rdoHuiZJCus" GroupName="huizj" Text="��Ҫ�Լ������������ݡ�<font color=red>�������ݿ�ѡ������**�ջ���**</font>��<font color=blue>�Զ��������������ú�����ϵ�ͷ����������򲻳ɹ���<font color=red>" runat="server" />
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
                      <asp:Label ID="Label47" runat="server" Text="�߼�����" Font-Bold="true" Font-Size="12pt"
                                ForeColor="#E17009"></asp:Label>
                     </div>
                    <div class="contt4">
                       
                        <div class="content" id="ContentDiv5">
                            <table>
                                <tbody>
                                    <tr>
                                        <td style="width: 10%; vertical-align: middle">
                                            <asp:Label ID="Label5" runat="server" Text="�������ã�"></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 90%; vertical-align: middle">
                                            <asp:Label ID="Label11" runat="server" Text="����������"></asp:Label>&nbsp;<asp:TextBox
                                                ID="txtAmount" Width="80px" CssClass="ui-widget-content ui-corner-all" Text="0" runat="server"></asp:TextBox>&nbsp;Ԫ�ŷ���
                                <asp:Label ID="lberror2" Font-Size="16px" Font-Bold="true" ForeColor="Red" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 10%; vertical-align: middle">
                                            <asp:Label ID="Label9" runat="server" Text="��Ա���ˣ�"></asp:Label>
                                        </td>
                                        <td colspan="3" style="width: 90%; vertical-align: middle">ʹ�ú�����<a href="../blacklist.aspx" target="_blank">[����]</a>
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
                                    <td>ǩ��Ԥ����
                                    </td>
                                    <td>
                                        <asp:Label ID="lbShopSignPre" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>�Զ���ǩ��(��������&�������ž���ʹ��)��
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
