<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="addCashApply.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.addCashApply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" cellpadding="0" cellspacing="0" width="100%" height="397">
                <tr>
                    <td valign="top">
                        <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td height="3px">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <table class="tab3">
                                                    <tr>
                                                        <td>
                                                            <table class="tab4">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table class="tab5">
                                                                            <tr>
                                                                                <td>
                                                                                    <div id="div2" runat="server">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td colspan="2" align="center">
                                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    所属项目：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlProjectID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProjectID_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    资金卡：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlCardName" runat="server">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    申请数额：
                                                                                                </td>
                                                                                                <td style="padding-top: 1px">
                                                                                                    ￥<asp:TextBox ID="txtApplyCount" runat="server" CssClass="textbox_name">0</asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                                <td style="padding-top: 1px">
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="txtApplyCount"
                                                                                                        ValidationGroup="add1" ErrorMessage="金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                            ID="RegularExpressionValidator1" runat="Server" ControlToValidate="txtApplyCount"
                                                                                                            ValidationGroup="add1" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"
                                                                                                            ErrorMessage="金额只能为数字!" Display="Dynamic" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    领取预约日期：
                                                                                                </td>
                                                                                                <td style="padding-top: 1px">
                                                                                             <table border="0" >
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <input class="Inputtext" id="txtGetDateTime" runat="server" width="200" type="text"
                                                                                                        readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;<asp:DropDownList ID="ddlHour"
                                                                                                            runat="server" Visible="false">
                                                                                                        </asp:DropDownList>
                                                                                                    <asp:DropDownList ID="ddlMin" runat="server" Visible="false">
                                                                                                    </asp:DropDownList>

                                                                                                </td>
                                                                                                <td align="left">                                                                                                    <asp:RadioButtonList ID="RadioButtonList_shijian" runat="server" RepeatColumns="2">
                                                                                                    <asp:ListItem Value=" 10:00:00" Selected="True">上午</asp:ListItem>
                                                                                                    <asp:ListItem Value=" 12:00:00">下午</asp:ListItem>
                                                                                                    </asp:RadioButtonList></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                                    
                                                                                                    
                                                                                                    
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="middle">预约类型：
                                                                                                </td>
                                                                                                <td valign="top">
                                                                                                    <asp:RadioButtonList ID="RBlist_YYLX" runat="server" RepeatColumns="2">
                                                                                                <asp:ListItem Value="1" Selected="True">报销</asp:ListItem>
                                                                                                <asp:ListItem Value="2">借贷</asp:ListItem>
                                                                                                </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    用途：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtUseFor" runat="server" TextMode="MultiLine" Height="100px" Width="456px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    联系方式：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtApplierTel" runat="server" CssClass="textbox_name"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" align="center"><asp:Button ID="Button_sumbit" runat="server" CssClass="button1" OnClick="Button_sumbit_Click"
                                                                                                        Text="确定" />　　<asp:Button ID="Button_cancel" runat="server" Text="返回" CssClass="button1"
                                                                                                        OnClick="Button_cancel_Click" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="50px">
                                                                    </td>
                                                                </tr>
                                                            </table>
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
                        <table height="40px" align="center" cellpadding="1" cellspacing="1" width="98%">
                            <tr>
                                <td valign="top">
                                    <asp:Label ID="notice" runat="server" Text="" CssClass="notice"></asp:Label>
                                    <asp:HiddenField ID="H_NAME" runat="server" />
                                    <%-- <asp:HiddenField ID="H_ModifyID" runat="server" />--%>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="5">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
