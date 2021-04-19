﻿<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="addDepartmentBudget.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.addDepartmentbudget" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<link href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.2/css/select2.min.css" rel="stylesheet" />
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
                                                                                            部门预算编号：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="TB_Code" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_Code" ValidationGroup="add1"
                                                                                                ErrorMessage="预算报告名称不能为空!" Display="Dynamic" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align="right">
                                                                                           部门预算名称：
                                                                                        </td>
                                                                                        <td>
                                                                                           <%-- <asp:DropDownList ID="DDL_AssignChecker" runat="server">
                                                                                            </asp:DropDownList>--%>

																														 <asp:TextBox ID="TB_BudgetName" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator3" runat="Server" ControlToValidate="TB_BudgetName" ValidationGroup="add1"
                                                                                                ErrorMessage="部门预算名称不能为空!" Display="Dynamic" />
                                                                                        </td>
                                                                                    </tr>
																											  <tr>
																												 <td align="right">
                                                                                           所属部门：
																													  
                                                                                     </td>
																												  <td>
																													   <select id="DP_Department"  multiple="multiple" style="width:200px">
																															<option value="1" selected="selected">复选</option>
																															<option value="1">test2</option>
																													   </select>
																												  </td>
																											  </tr>
																											  <tr>
                                                                                        <td align="right">
                                                                                            项目负责人：
                                                                                        </td>
                                                                                        <td>
                                                                                             <select id="DP_Manager" multiple="multiple" style="width:200px">
																															<option value="1">test1</option>
																															<option value="1">test2</option>
																													   </select>
                                                                                        </td>
                                                                                    </tr>

																											   <tr>
                                                                                        <td align="right">
                                                                                            项目起止时间：
                                                                                        </td>
                                                                                        <td>
                                                                                            <input id="TB_StartDateTime" runat="server" style="width: 176px" type="text" readonly="readonly"
                                                                                            onclick="ShowCalendar(this);" />
																														   -
																														  <input id="TB_EndDateTime" runat="server" style="width: 176px" type="text" readonly="readonly"
                                                                                            onclick="ShowCalendar(this);" />
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
                                                                                    
                                                                                    <br />
                                                                                    <tr>
                                                                                        <td colspan="2" align="center" height="50">
                                                                                            <asp:Button ID="Button_sumbit" runat="server" CssClass="button1" ValidationGroup="add1" Width="120"
                                                                                                Text="下一步：新建子项目" OnClick="Button_sumbit_click" />&nbsp;&nbsp;&nbsp;
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
	<script src="../js/select2-4.0.2/js/jquery-1.11.1.min.js" type="text/javascript"></script>
	<script src="../js/select2-4.0.2/js/select2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		$('#DP_Department,#DP_Manager').select2();
	</script>
</asp:Content>
