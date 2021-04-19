<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="addbudget.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.addbudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

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
                                                                                        <td align="right">
                                                                                            预算报告名称：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TB_Name" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_Name" ValidationGroup="add1"
                                                                                                ErrorMessage="预算报告名称不能为空!" Display="Dynamic" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                           报告审批人：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="DDL_AssignChecker" runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            所属项目：
                                                                                        </td>
                                                                                        <td>
                                                                                            <table border="0">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="RBL_project" runat="server" RepeatColumns="2" AutoPostBack="true"
                                                                                                            OnSelectedIndexChanged="RBL_project_change">
                                                                                                            <asp:ListItem Value="0" Selected="True">无</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">有</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:DropDownList ID="DDL_Project" runat="server" Visible="false">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            预算金额：
                                                                                        </td>
                                                                                        <td style="padding-top: 1px">
                                                                                            <table border="0">
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <asp:TextBox ID="TB_BudgetAmount" MaxLength="9" runat="server"></asp:TextBox>
                                                                                                    </td>
                                                                                                    <td align="left">
                                                                                                        <asp:RadioButtonList ID="RB_BudgetAmount" runat="server" RepeatColumns="2">
                                                                                                            <asp:ListItem Value="1" Selected="True">万元</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">元</asp:ListItem>
                                                                                                        </asp:RadioButtonList>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_BudgetAmount"
                                                                                                ValidationGroup="add1" ErrorMessage="预算金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TB_BudgetAmount"
                                                                                                ValidationGroup="add1" ValidationExpression="^\d+(\.[0-9]{0,2})?$"
                                                                                                ErrorMessage="预算金额必须是大于0的数字！" Display="Dynamic" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                            上传预算报告：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:FileUpload ID="FileUpload_list" runat="server" Style="width: 270px; height: 20px;" />&nbsp;&nbsp;<asp:Label
                                                                                                ID="LB_file" runat="server" ForeColor="Red" Text="  *留空表示保留原有预算报告" Visible="false"></asp:Label><%--<asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator3" runat="Server" ControlToValidate="FileUpload_list"
                                                                                                ValidationGroup="add1" ErrorMessage="预算报告不能为空!" Display="Dynamic" />--%>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <br />
                                                                                    <tr>
                                                                                        <td colspan="2" align="center" height="50">
                                                                                            <asp:Button ID="Button_sumbit" runat="server" CssClass="button1" ValidationGroup="add1"
                                                                                                Text="确定" OnClick="Button_sumbit_click" />&nbsp;&nbsp;&nbsp;
                                                                                            <asp:Button ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_click" />
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
            </td>
            <td width="5">
            </td>
        </tr>
    </table>
</asp:Content>
