<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="addChild.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.addChild" %>

<%@ Register Src="../Budget_DetailMX.ascx" TagName="Budget_DetailMX" TagPrefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

	<link href="/Admin/css/select2.min.css" rel="stylesheet" />
	<script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

<table align="center" cellpadding="0" cellspacing="0" width="100%" height="397">
		<tr>
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
																						<td align="right">子项目编号：
																						</td>
																						<td>
																							<asp:TextBox ID="TB_Code" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
																								ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_Code" ValidationGroup="add1"
																								ErrorMessage="预算报告名称不能为空!" Display="Dynamic" />
																						</td>
																					</tr>
																					<tr>
																						<td align="right">子项目名称：
																						</td>
																						<td>
																							<asp:TextBox ID="TB_BudgetName" runat="server" Width="200"></asp:TextBox>&nbsp;&nbsp;<asp:RequiredFieldValidator
																								ID="RequiredFieldValidator3" runat="Server" ControlToValidate="TB_BudgetName" ValidationGroup="add1"
																								ErrorMessage="部门预算名称不能为空!" Display="Dynamic" />
																						</td>
																					</tr>
																					<tr>
																						<td align="right">所属项目：
																						</td>
																						<td>
																							<asp:DropDownList ID="DDL_Budget" runat="server" Style="width: 200px">
																							</asp:DropDownList>
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
																						<td align="right">子项目负责人：
																						</td>
																						<td>
																							<asp:DropDownList ID="DP_Manager" runat="server" multiple="multiple" Style="width: 200px">
																							</asp:DropDownList>
																							<asp:HiddenField ID="HID_Manager" runat="server" />
																						</td>
																					</tr>

																					<tr>
																						<td align="right">子项目起止时间：
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
																							<asp:DropDownList ID="DDL_AssignChecker" runat="server"	 Style="width: 200px">
																							</asp:DropDownList>	
																						</td>
																					</tr>

																					<tr>
																						<td>
																					
																						</td>
																						<td style="padding-top: 1px">
																							<uc3:Budget_DetailMX ID="budgetDetails" runat="server" />
																						</td>
																					</tr>

																					<br />
																					<tr>
																						<td colspan="2" align="center" height="50">
																							<asp:Button ID="Button_sumbit" runat="server" CssClass="button1" ValidationGroup="add1" Width="120"
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

			//if ($managerIds != '' && $dp_manager.children().size() <= 0) {
			//	$('#ctl00_ContentPlaceHolder1_BTN_Departmetn').click();
			//}


		},0);
	</script>
</asp:Content>
