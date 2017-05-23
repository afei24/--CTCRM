<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Pagination.ascx.cs" Inherits="CTCRM.admin.CommonContr.Pagination" %>
<style type="text/css">

    .PaginationControl
    {
	    font-size: 9pt;
        background-color: #C0FFC0;
        width: 955px;
        margin-left:15px;
        margin-top:-15px;
        border-top: #B0B0B0 1px solid;
        border-bottom: #B0B0B0 1px solid;
    }
    
    .NavigationText
    {
	    height: 16px;
	    text-align: center;
    }
</style>

<script type="text/javascript">
        function onKeyDownEvent(evt)
        {
            evt=evt?evt:window.event;
            if(evt.keyCode==13)
            {
                var btnRefresh=document.getElementById("pgnController_btnRefresh");
                if(!btnRefresh)
                {
                    btnRefresh=document.getElementsByName("pgnController$btnRefresh");
                }
                if(btnRefresh)
                {
                   btnRefresh.click();
                }
                return false;
            }
            return true;
        }
</script>

<div class="PaginationControl">
    <table border="0px" cellpadding="0px" cellspacing="0px" style="background-color: #C0FFC0;">
        <tr>

            <td>
                <asp:Label ID="lblRowInformation" runat="server" Text="每页记录数"></asp:Label>
                <asp:Label ID="txtRowsPerPage" CssClass="NavigationText" runat="server" Width="20px" ReadOnly="true"
                     Wrap="False" ToolTip=""
                    ></asp:Label>
                <asp:Label ID="lblPageInformation1" runat="server" Text="总记录数"></asp:Label>
                <asp:Label ID="lblRowCount" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:ImageButton ID="btnFirst" CssClass="NavigationButton" ImageUrl="~/admin/images/Button/pgnFirst.GIF" 
                    runat="server" ToolTip="首页" OnClick="btnFirst_Click" />&nbsp;<asp:ImageButton ID="btnPrevious"
                        CssClass="NavigationButton" ImageUrl="~/admin/images/Button/pgnPrevious.gif"
                        runat="server" ToolTip="前一页" OnClick="btnPrevious_Click" />&nbsp;</td>
            <td>
                <asp:Label ID="lblPageInformation2" runat="server" Text="当前第"></asp:Label>
                <asp:Label ID="lblCurrentPage"  CssClass="NavigationText" runat="server" Width="20px" 
                    Wrap="False" ToolTip=""
                    ></asp:Label>
                    <asp:Label ID="Label1" runat="server" Text="页"></asp:Label>
                <asp:Label ID="lblPageInformation3" runat="server" Text="  共 "></asp:Label>
                <asp:Label ID="lblPageCount" runat="server"></asp:Label>
                <asp:Label ID="lblPageInformation4" runat="server" Text="页"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:ImageButton ID="btnNext" ImageUrl="~/admin/images/Button/pgnNext.gif" runat="server"
                    ToolTip="后一页" OnClick="btnNext_Click" />&nbsp;<asp:ImageButton ID="btnLast" ImageUrl="~/admin/images/Button/pgnLast.gif"
                        runat="server" ToolTip="尾页" OnClick="btnLast_Click" /></td>
                        <td>&nbsp;
                        <asp:Label ID="Label2" runat="server" Text="转到"></asp:Label>
                        </td><td>&nbsp;
                        <asp:TextBox ID="txtCurrentPage" Style="text-align: center" runat="server" Font-Size="9pt" Width="20px" Height="20px"
                    Wrap="False" ToolTip=""
                    ></asp:TextBox>&nbsp;</td><td>
                        <asp:Label ID="Label3" runat="server" Text="页"></asp:Label>
                        </td>
                                    <td valign="middle">&nbsp;
                <asp:ImageButton ID="btnRefresh" CssClass="NavigationButton" ImageUrl="~/admin/images/Button/go.gif"
                    runat="server" ToolTip="刷新数据" OnClick="btnRefresh_Click" />&nbsp;</td>
           
        </tr>
    </table>
</div>

