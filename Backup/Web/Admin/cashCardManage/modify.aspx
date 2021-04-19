<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="modify.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.modify" %>

<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="Cash_CarDetailList.ascx" TagName="Cash_CarDetailList" TagPrefix="uc2" %>
<%@ Register src="Cash_CarDetailMX.ascx" tagname="Cash_CarDetailMX" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                                                    <td class="tab1_td2">
                                                                        <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>编辑资金卡
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <table class="tab4" border="0">
                                                                <tr>
                                                                    <td width="10">
                                                                    </td>
                                                                    <td style="width: 400px;" valign="top">
                                                                        <div id="div2" runat="server">
                                                                            <table border="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="120">
                                                                                        资金卡编号：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                    <asp:TextBox ID="TB_CardNum" runat="server" CssClass="textbox_name" Width="180px" Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        资金卡名称：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:TextBox ID="txtCardName" runat="server" CssClass="textbox_name" Width="180px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="txtCardName"
                                                                                            ValidationGroup="add2" ErrorMessage="资金卡名称不能为空!" Display="Dynamic" /><%--<asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtCardName"
                                                                                                ValidationGroup="add2" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="资金卡名称在2~25字符!" Display="Dynamic" />--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属项目：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlProjectID" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属预算报告：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_Budget" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        所属部门：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlDepartmentID" runat="server" Width="180px" AutoPostBack="true"
                                                                                            OnSelectedIndexChanged="ddlDepartmentID_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        持卡人：
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <asp:DropDownList ID="ddlCardholderID" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        到期时间：
                                                                                    </td>
                                                                                    <td>
                                                                                        <input id="TB_DateTime" runat="server" style="width: 176px" type="text" readonly="readonly"
                                                                                            onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        审批人：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlApproverIDs" runat="server" Width="180px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        资金卡细目如下：
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <uc3:Cash_CarDetailMX ID="Cash_CarDetailMX1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag2" runat="server" ForeColor="Red" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add2" Text="确定" OnClick="Button_sumbit_Click"
                                                                                            CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
