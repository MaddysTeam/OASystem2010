<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
	CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.add" %>
	
<%@ Register Src="/Admin/cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="/Admin/cashCardManage/OAleftmenu_Show.ascx" TagName="OAleftmenu_Show" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<link href="/Admin/css/select2.min.css" rel="stylesheet" />
	<script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

	<table align="center" cellpadding="0" cellspacing="0" width="100%" height="397">
		<tr>

		    <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="true" />
                <uc2:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
            </td>
            <td width="5">
            </td>

			<td valign="top">
				<table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
					<tr>
						<td height="3px"></td>
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
																						<td align="right">部门预算编号：
																						</td>
																						<td>
																							<asp:TextBox ID="TB_Code" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
																								ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_Code" ValidationGroup="add1"
																								ErrorMessage="预算报告名称不能为空!" Display="Dynamic" />
																						</td>
																					</tr>
																					<tr>
																						<td align="right">部门预算名称：
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
																						<td align="right">所属部门：
																													  
																						</td>
																						<td>
																							<asp:DropDownList ID="DP_Department" runat="server" multiple="multiple" Style="width: 200px">
																							</asp:DropDownList>
																							<asp:HiddenField ID="HID_Department" runat="server" />
																							<asp:Button ID="BTN_Departmetn" runat="server" OnClick="BTN_Departmetn_Click" />
																						</td>
																					</tr>
																					<tr>
																						<td align="right">项目负责人：
																						</td>
																						<td>
																							<asp:DropDownList ID="DP_Manager" runat="server" multiple="multiple" Style="width: 200px">
																							</asp:DropDownList>
																							<asp:HiddenField ID="HID_Manager" runat="server" />
																						</td>
																					</tr>

																					<tr>
																						<td align="right">项目起止时间：
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
																						<td align="right">项目审批人：
																						</td>
																						<td>
																							<asp:DropDownList ID="DDL_AssignChecker" runat="server" Style="width: 200px">
																							</asp:DropDownList>
																						</td>
																					</tr>

																					<tr>
																						<td align="right">预算金额：
																						</td>
																						<td style="padding-top: 1px">
																							<table border="0">
																								<tr valign="middle">
																									<td align="left">
																										<asp:Label ID="LB_BudgetLimit" MaxLength="9" runat="server" ReadOnly="true"></asp:Label>
																										<%--<asp:RadioButtonList ID="RB_BudgetAmount" runat="server" RepeatColumns="2">
																											<asp:ListItem Value="1" Selected="True">万元</asp:ListItem>
																											<asp:ListItem Value="0">元</asp:ListItem>
																										</asp:RadioButtonList>--%>
																										（不用填，由子项目金额自动汇总)
																									</td>
																								</tr>
																							</table>
																							<%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_BudgetAmount"
																								ValidationGroup="add1" ErrorMessage="预算金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
																									ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TB_BudgetAmount"
																									ValidationGroup="add1" ValidationExpression="^\d+(\.[0-9]{0,2})?$"
																									ErrorMessage="预算金额必须是大于0的数字！" Display="Dynamic" />--%>
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

																					<tr>
																						<td colspan="3">
																						    <div></div>
																							<asp:GridView ID="GridView2" AutoGenerateColumns="False" runat="server" CellPadding="3"
																								CssClass="GridView11" Width="100%">
																								<Columns>
																									<asp:TemplateField HeaderText="序号">
																										<ItemTemplate>
																											<asp:Label ID="labID" runat="server"> <%# Eval("ID")%></asp:Label>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="经费名称">
																										<ItemTemplate>
																											<%# Eval("BudgetName")%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="负责人">
																										<ItemTemplate>
																											<%# Eval("Manager")%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="劳务费">
																										<ItemTemplate>
																											<%# Eval("LabourBudget")%>
																											<%--<asp:Label ID="labJKF" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="会务费">
																										<ItemTemplate>
																											<%# Eval("MeetingBudget")%>
																											<%--  <asp:Label ID="labCF" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="差旅费">
																										<ItemTemplate>
																											<%# Eval("BussinessTripBudget")%>
																											<%-- <asp:Label ID="labZLF" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="政府采购">
																										<ItemTemplate>
																											<%# Eval("GovBudget")%>
																											<%-- <asp:Label ID="labHWF" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="出版印刷费">
																										<ItemTemplate>
																											<%# Eval("PublishBudget")%>
																											<%--<asp:Label ID="labJTF" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="其他">
																										<ItemTemplate>
																											<%# Eval("OtherBudget")%>
																											<%--<asp:Label ID="labQT" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>
																									<asp:TemplateField HeaderText="操作">
																										<ItemTemplate>
																											<asp:Button OnClick="BTN_ChildBudget_Edit_Click" Text="编辑" runat="server" CssClass="button1"></asp:Button>
																											&nbsp;
																											<asp:Button OnClick="BTN_ChildBudget_Delete_Click" Text="删除"  runat="server" CssClass="button1"></asp:Button>
																											<%-- <asp:Label ID="labSYHJ" runat="server" Text="0"></asp:Label>--%>
																										</ItemTemplate>
																										<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																										<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																									</asp:TemplateField>

																								</Columns>
																							</asp:GridView>
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
															<td height="50px"></td>
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
			<td width="5"></td>
		</tr>
	</table>
	<script src="/Admin/js/select2-4.0.2/js/jquery-1.11.1.min.js" type="text/javascript"></script>
	<script src="/Admin/js/select2-4.0.2/js/select2.min.js" type="text/javascript"></script>
	<script type="text/javascript">
		setTimeout(function () {

			var departIds = '';
			var $dp_department = $('#ctl00_ContentPlaceHolder1_DP_Department');
			var $dp_manager = $('#ctl00_ContentPlaceHolder1_DP_Manager');
			var $departmentIds = $('#ctl00_ContentPlaceHolder1_HID_Department').val();
			var $managerIds = $('#ctl00_ContentPlaceHolder1_HID_Manager').val();
			//alert($managerIds);

			$dp_department.children().each(function () {
				var ids = $departmentIds.split(',')
				$this = $(this);
				for (var i = 0; i < ids.length; i++) {
					if (ids[i] == $this.attr('value')) {
						$this.attr('selected', 'selected');
					}
				}
			});
			$dp_department.select2().on('change', function (v) {
				var departIds = $(this).val();
				$('#ctl00_ContentPlaceHolder1_HID_Department').val(departIds);
				$('#ctl00_ContentPlaceHolder1_BTN_Departmetn').click();
			});

			$dp_manager.removeAttr('disabled');
			$dp_manager.children().each(function () {
				if ($managerIds == '') return false;
				var ids = $managerIds.split(',')
				$this = $(this);
				for (var i = 0; i < ids.length; i++) {
					if (ids[i] == $this.attr('value')) {
						$this.attr('selected', 'selected');
					}
				}
			});
			$dp_manager.select2().on('change', function (v) {
				var managerIds = $(this).val();
				$('#ctl00_ContentPlaceHolder1_HID_Manager').val(managerIds);
			});

		}, 10);

	</script>
</asp:Content>
