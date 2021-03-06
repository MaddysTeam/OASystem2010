<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master"  ValidateRequest="false" AutoEventWireup="true" CodeBehind="Cash_Account_add.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.Cash_Account_add" %>
<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <table cellpadding="0" cellspacing="0" width="100%" height="397">
        <tr>
            <td width="4">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table class="tab1" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="tab1_td1">
                                                                &nbsp;
                                                            </td>
                                                            <td class="tab1_td2" id="pagenameshows" runat="server">
                                                               新建账户
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="tab4" border="0">
                                                        <tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                                            <td valign="top">
                                                                <div id="div2" runat="server" visible="true"><br /><br />
                                                                    <table width="100%">
                                                                        <tr>
                                                                            <td colspan="2" align="center">
                                                                                <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                        <tr>
                                                                            <td width="120">
                                                                                账户名称：
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtCardName" runat="server" CssClass="textbox_name" Width="180px"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="txtCardName"
                                                                                    ValidationGroup="add2" ErrorMessage="账户名称不能为空!" Display="Dynamic" /><%--<asp:RegularExpressionValidator
                                                                                        ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtCardName"
                                                                                        ValidationGroup="add2" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                        ErrorMessage="账户名称在2~25字符!" Display="Dynamic" />--%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                账户状态：
                                                                            </td>
                                                                            <td>
                                                                                <asp:RadioButtonList ID="RadioButtonList_status" RepeatDirection="Horizontal" runat="server">
                                                                                    <asp:ListItem Value="1" Selected="True">正常</asp:ListItem>
                                                                                    <asp:ListItem Value="0">冻结</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                            
                                                                            </td>
                                                                        </tr>
                                                                     
                                                                  
                                                                        <tr>
                                                                            <td>
                                                                                账户余额：
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtLimitNums" runat="server" CssClass="textbox_name" Height="16px"
                                                                                    Width="161px" Text="0" ></asp:TextBox>
                                                                                元
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtLimitNums"
                                                                                    ValidationGroup="add2" ErrorMessage="金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                        ID="RegularExpressionValidator1" runat="Server" ControlToValidate="txtLimitNums"
                                                                                        ValidationGroup="add2"  ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                        ErrorMessage="金额输入有误!" Display="Dynamic" />
                                                                            </td>
                                                                        </tr><tr>
                                                                            <td>
                                                                                每日限额：
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="txtEveryDayNum" runat="server" CssClass="textbox_name" Height="16px"
                                                                                    Width="161px" Text="0" ></asp:TextBox>
                                                                                元
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="Server" ControlToValidate="txtEveryDayNum"
                                                                                    ValidationGroup="add2" ErrorMessage="每日限额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                        ID="RegularExpressionValidator3" runat="Server" ControlToValidate="txtEveryDayNum"
                                                                                        ValidationGroup="add2"  ValidationExpression="^([0-9]\d{0,11})$|^(0|[0-9]\d{0,11})\.(\d{0,2})$"
                                                                                        ErrorMessage="每日限额输入有误!" Display="Dynamic" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="display:none;">
                                                                            <td>
                                                                                账户冻结时间：
                                                                            </td>
                                                                            <td>
                                                                                <input id="TB_DateTime" runat="server" style="width: 160px" type="text" readonly="readonly"
                                                                                    onclick="ShowCalendar(this);" />
                                                                            </td>
                                                                        </tr>
                                                                       
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr><td></td>
                                                                            <td   align="left">
                                                                                <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add2" Text="确定" OnClick="Button_sumbit_Click"
                                                                                    CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                            ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table class="tab6">
                                                        <tr>
                                                            <td align="center">
                                                                <img src="/Admin/images/OAimages/Separator_content.jpg">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="10px">
                        </td>
                    </tr>
                </table>
            </td>
            <td width="5">
            </td>
        </tr>
    </table>
</asp:Content>

