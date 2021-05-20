<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showParent.aspx.cs" MasterPageFile="~/Admin/OAmaster.Master" Inherits="Dianda.Web.Admin.budgetManage.department.showParent" %>

<%@ Register Src="/Admin/cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<%@ Register Src="/Admin/cashCardManage/OAleftmenu_Show.ascx" TagName="OAleftmenu_Show" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link href="/Admin/css/OACSS.css" rel="stylesheet" type="text/css" />
	<table cellpadding="0" cellspacing="0" width="100%">
		<tr>
			<td width="4"></td>
			<td valign="top" width="115" align="left" runat="server" id="td_left">
				<uc1:OAleftmenu ID="OAleftmenu1" runat="server" Visible="false" />
				<uc2:OAleftmenu_Show ID="OAleftmenu_Show1" runat="server" Visible="false" />
			</td>
			<td width="5"></td>
			<td valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%">
					<tr>
						<td height="3px"></td>
					</tr>
					<tr>
						<td>
							<table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
								<tr>
									<td>
										<table cellpadding="0" cellspacing="0" width="100%">
											<tr>
												<td>
													<table class="tab3" border="0">
														<tr>
															<td valign="top">
																<table width="100%" class="tab4" align="center" cellspacing="0" cellpadding="0">
																	<tr>
																		<td valign="top">
																			<table class="tab5">
																				<tr>
																					<td>
																						<div id="cash_jbxx" runat="server">
																							<table align="center" width="100%" border="0" cellspacing="0" cellpadding="0">
																								<tr valign="top">
																									<td align="right" height="22">
																										<asp:Button
																											ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																									</td>
																								</tr>
																								<tr valign="middle">
																									<td align="center">
																										<table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#000000">
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">部门经费名称：
																												</td>
																												<td align="left" colspan="3">&nbsp;
                                                                                                                    <asp:Label ID="LB_Name" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>

																												<td style="width: 100px; height: 25px;" align="right">部门经费编号：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_BudgetCode" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																											</tr>
																										</table>
																									</td>
																								</tr>
																								<tr>
																									<td height="5"></td>
																								</tr>
																								<%--																								<tr>
																									<td colspan="4">
																										<table width="97%" border="0" cellpadding="0" cellspacing="0">
                                                                                                                <tr>
                                                                                                                    <td style="height:30px;">
                                                                                                                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="red"></asp:Label>
                                                                                                                        <asp:GridView ID="GV_ParentDetail" AutoGenerateColumns="False" runat="server" CellPadding="3"  Width="100%"
                                                                                                                            CssClass="GridView11">
                                                                                                                            <Columns>
                                                                                                                                <asp:TemplateField HeaderText="序号">
                                                                                                                                    <ItemTemplate>
                                                                                                                                        
                                                                                                                                    </ItemTemplate>
                                                                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="30" />
                                                                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="30" />
                                                                                                                                </asp:TemplateField>
                                                                                                                            </Columns>
                                                                                                                        </asp:GridView>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
																									</td>
																								</tr>--%>
																								<tr valign="bottom">
																									<td align="center" colspan="4">
																										<div style="width: 97%; text-align: left;">
																											<table width="97%" border="0" cellpadding="0" cellspacing="0">
																												<tr>
																													<td style="height: 30px;">
																														<asp:Label ID="notice" runat="server" Text="" ForeColor="red"></asp:Label>
																														<asp:GridView ID="DList_ParentBudgetDetail" AutoGenerateColumns="False" runat="server" CellPadding="3" Width="100%"
																															CssClass="GridView11">
																															<Columns>
																																<asp:BoundField HeaderText="经费构成" DataField="DetailName">
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																																</asp:BoundField>
																																<asp:BoundField HeaderText="经费总额 (元)" DataField="Balance">
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																																</asp:BoundField>
																																<asp:BoundField HeaderText="已用经费 (元)" DataField="RealSpend">
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																																</asp:BoundField>
																																<asp:BoundField HeaderText="剩余经费 (元)" DataField="CurrentBalance">
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																																</asp:BoundField>
																															</Columns>
																														</asp:GridView>
																													</td>
																												</tr>
																											</table>
																										</div>
																									</td>
																								</tr>
																								<tr>
																									<td height="10"></td>
																								</tr>
																								<tr>
																									<td colspan="4">
																										<asp:GridView ID="DList_ChildBudgetDetail" AutoGenerateColumns="False" runat="server" CellPadding="3"
																											CssClass="GridView11" Width="100%">
																											<Columns>
																												<asp:TemplateField HeaderText="序号">
																													<ItemTemplate>
																														<asp:Label ID="labID" runat="server"> <%# Eval("ID")%></asp:Label>
																													</ItemTemplate>
																													<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																													<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																												</asp:TemplateField>
																												<asp:TemplateField HeaderText="子项目名称">
																													<ItemTemplate>
																														<%# Eval("BudgetName")%>
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

																											</Columns>
																										</asp:GridView>
																									</td>

																								</tr>
																								<%-- <tr valign="top">
                                                                                                    <td align="center" height="80">
                                                                                                        <table border="1" width="97%" height="100%" style="border-collapse: collapse; border-color: #A9BDC8;"
                                                                                                            rules="none">
                                                                                                            <tr valign="top">
                                                                                                                <td align="left">
                                                                                                                    <asp:Label ID="LB_Info" runat="server" Text=""></asp:Label>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>--%>
																							</table>
																						</div>
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
												<td height="5px"></td>
											</tr>
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
					<tr>
						<td height="10px"></td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</asp:Content>
