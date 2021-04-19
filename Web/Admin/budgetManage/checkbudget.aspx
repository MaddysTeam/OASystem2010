<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/OAmaster.Master"
    CodeBehind="checkbudget.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.checkbudget" %>

<%@ Register Src="../Cash_SF_Order/SpecialFundsOrder.ascx" TagName="SpecialFundsOrder"
    TagPrefix="uc3" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab_height2">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table class="tab3">
                                <tr>
                                    <td valign="top">
                                        <table class="tab4">
                                            <tr>
                                                <td valign="top">
                                                    <table class="tab5">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="7">
                                                                    <tr>
                                                                        <td colspan="2" align="center">
                                                                            <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #A5BBF1;">
                                                                        <td colspan="2" align="left">
                                                                            <asp:Label ID="notice1" runat="server" Text="预算申报信息" ForeColor="Red" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            预算报告名称：<asp:Label ID="LB_Name" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            预算金额：<asp:Label ID="LB_BudgetAmount" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            预算申报时间：<asp:Label ID="LB_AddTime" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            所属项目：<asp:Label ID="LB_Project" runat="server" Text=""></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="background-color: #A5BBF1;">
                                                                        <td colspan="2" align="left">
                                                                            <asp:Label ID="notice2" runat="server" Text="预算审批信息" ForeColor="Red" /><asp:Label
                                                                                ID="LB_CheckNotice" runat="server" Text="" ForeColor="red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td width="45%" valign="top">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        审批权限：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="RBL_check" runat="server" RepeatColumns="2" AutoPostBack="true"
                                                                                            OnSelectedIndexChanged="RBL_check_change">
                                                                                            <asp:ListItem Value="0">分管领导审批</asp:ListItem>
                                                                                            <asp:ListItem Value="1">室主任审批</asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr runat="server" id="tr_SpecialFunds">
                                                                                    <td align="right">
                                                                                        专项资金：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_SpecialFundsID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_SpecialFundsID_Change">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr runat="server" id="tr_BudgetAmount">
                                                                                    <td align="right">
                                                                                        确认预算金额：
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:TextBox ID="TB_ActualAmount" MaxLength="9" runat="server"></asp:TextBox>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RB_AAUNIT" runat="server" RepeatColumns="2">
                                                                                                        <asp:ListItem Value="1" Selected="True">万元</asp:ListItem>
                                                                                                        <asp:ListItem Value="0">元</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_ActualAmount"
                                                                                            ValidationGroup="add1" ErrorMessage="预算金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TB_ActualAmount"
                                                                                                ValidationGroup="add1" ValidationExpression="^\d+(\.[0-9]{0,2})?$" ErrorMessage="预算金额必须是大于0的数字！"
                                                                                                Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--去除指定经费审批人 by guanzhq on 2012年3月19日 10:39:56
                                                                                说明 如要恢复功能请将 tr_AssignChecker style去除
                                                                                --%>
                                                                                <tr runat="server" id="tr_AssignChecker" style="display: none;">
                                                                                    <td align="right">
                                                                                        指定经费审批人：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_AssignChecker" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="5" colspan="2">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        审批结果：
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RBL_Checker" runat="server" RepeatColumns="4" AutoPostBack="true"
                                                                                                        OnSelectedIndexChanged="RBL_Checker_change">
                                                                                                        <asp:ListItem Value="2">不通过</asp:ListItem>
                                                                                                        <asp:ListItem Value="1" Selected="True">通过</asp:ListItem>
                                                                                                        <asp:ListItem Value="0">继续审核</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <asp:DropDownList ID="DDL_Checker" runat="server" Visible="false">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        重新上传预算报告：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:FileUpload ID="FileUpload_list" runat="server" Style="width: 270px; height: 20px;"
                                                                                            Width="271px" />
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="LB_file" runat="server" ForeColor="Red" Text="  *留空表示保留原有预算报告"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td align="left" width="55%" valign="top" runat="server" id="td_SpecialFundsOrder">
                                                                            <br />
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        所选专项资金的总金额为：<asp:Label ID="LB_total" runat="server" ForeColor="red"></asp:Label>,
                                                                                        可用金额为：<asp:Label ID="LB_KEYong" runat="server" ForeColor="red"></asp:Label>；包含的预算列表如下：
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <uc3:SpecialFundsOrder ID="SpecialFundsOrder1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="left" valign="top">
                                                                        <td colspan="2" valign="top">
                                                                            <table cellpadding="0" cellspacing="0">
                                                                                <tr>
                                                                                    <td align="right" style="width: 105px;" valign="top">
                                                                                        备注：
                                                                                    </td>
                                                                                    <td align="left" valign="top">
                                                                                        <FCKeditorV2:FCKeditor ID="Overviews" runat="server" Height="250" Width="500">
                                                                                        </FCKeditorV2:FCKeditor>
                                                                                        &nbsp;&nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height:22px;">
                                                                                    <td colspan="2"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="left" height="50">
                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                            ID="Button_sumbit" runat="server" CssClass="button1" ValidationGroup="add1" Text="确定"
                                                                                            OnClick="Button_sumbit_click" />&nbsp;&nbsp;&nbsp;
                                                                                        <asp:Button ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_click" />
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
                                        </table>
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
</asp:Content>
