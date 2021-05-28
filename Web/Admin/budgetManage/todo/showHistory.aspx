<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showHistory.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.todo.showHistory" %>

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
																										<asp:Label ID="LB_MSG" runat="server" ForeColor="Red" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
																											ID="Button_jz" runat="server" Text="记帐" CssClass="button1" OnClick="Button_jz_Click" />&nbsp;&nbsp;<asp:Button
																												ID="Button_cancel" runat="server" Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																									</td>
																								</tr>
																								<tr valign="middle">
																									<td align="center">
																										<table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#000000">
																											<%--<tr style="background-color: #99cccd" height="25px">
                                                                                                                <td align="center" colspan="2" style="height: 30px;">
                                                                                                                    &nbsp;&nbsp;&nbsp;<asp:Label ID="lblCardName" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>--%>
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">经费名称：
																												</td>
																												<td align="left" colspan="3">&nbsp;
                                                                                                                    <asp:Label ID="LB_Name" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>

																												<%--  <td align="left" colspan="2">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Label ID="LB_Project" runat="server" Text=""></asp:Label>
                                                                                                                    &nbsp;
                                                                                                                </td>--%>
																											</tr>
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">经费编号：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_BudgetCode" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																												<td style="width: 100px; height: 25px;" align="right">所属项目：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_ParentBudget" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																											</tr>
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">经费预算：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_LimitNumbers" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																												<td style="width: 100px; height: 25px;" align="right">当请总余额：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_YEBalance" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																											</tr>
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">项目负责人：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_Managers" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																												<td style="width: 100px; height: 25px;" align="right">项目审批人：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_Approver" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																											</tr>
																											<tr style="background-color: #ffffff">
																												<td style="width: 100px; height: 25px;" align="right">开始时间：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_StartTime" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																												<td style="width: 100px; height: 25px;" align="right">结束时间：
																												</td>
																												<td align="left">&nbsp;
                                                                                                                    <asp:Label ID="LB_EndTime" runat="server" Text=""></asp:Label>
																													&nbsp;
																												</td>
																											</tr>
																										</table>
																									</td>
																								</tr>
																								<tr>
																								<td height="15"></td>
																								</tr>
																								<tr>
																								<td>
																								<b style="font-weight:bold">经费使用情况总览（元）：</b>
																								</td>
																								</tr>
																								<tr>
																								<td height="15"></td>
																								</tr>
																								<tr valign="bottom">
																									<td align="center">
																										<div style="width: 97%; text-align: left;">
																											<table width="97%" border="0" cellpadding="0" cellspacing="0">
																												<tr>
																													<td style="height: 30px;">
																														<asp:Label ID="notice" runat="server" Text="" ForeColor="red"></asp:Label>
																														<asp:GridView ID="GV_Summary" AutoGenerateColumns="False" runat="server" CellPadding="3" Width="100%"
																															CssClass="GridView11">
																															<Columns>
																																<asp:TemplateField HeaderText="经费">
																																	<ItemTemplate>
																																		<%# Eval("Title")%>
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
																																<asp:TemplateField HeaderText="业务委托费">
																																	<ItemTemplate>
																																		<%# Eval("BussinessBudget")%>
																																		<%-- <asp:Label ID="labHWF" runat="server" Text="0"></asp:Label>--%>
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
																											</table>
																										</div>
																									</td>
																								</tr>
																								<tr>
																								<td height="15"></td>
																								</tr>
																								<tr>
																								<td>
																								<b style="font-weight:bold">可用金额调整情况：#(记录预算变更的情况)</b>
																								</td>
																								</tr>
																								<tr>
																								<td height="15"></td>
																								</tr>
																								<tr valign="bottom">
																									<td align="center">
																										<div style="width: 97%; text-align: left;">
																											<table width="97%" border="0" cellpadding="0" cellspacing="0">
																												<tr>
																													<td style="height: 30px;">
																														<asp:Label ID="Label1" runat="server" Text="" ForeColor="red"></asp:Label>
																														<asp:GridView ID="GV_Details" AutoGenerateColumns="False" runat="server" CellPadding="3" Width="100%"
																															CssClass="GridView11">
																															<Columns>
																																<asp:TemplateField HeaderText="序号">
																																	<ItemTemplate>
																																		<%# Eval("PX") %>
																																	</ItemTemplate>
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="30" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="30" />
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
																																<asp:TemplateField HeaderText="业务委托费">
																																	<ItemTemplate>
																																		<%# Eval("BussinessBudget")%>
																																		<%-- <asp:Label ID="labHWF" runat="server" Text="0"></asp:Label>--%>
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
																																<asp:TemplateField HeaderText="记账时间">
																																	<ItemTemplate>
																																		<%# Eval("AddTime")%>
																																		<%--<asp:Label ID="labQT" runat="server" Text="0"></asp:Label>--%>
																																	</ItemTemplate>
																																	<HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
																																	<ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
																																</asp:TemplateField>
																															</Columns>
																														</asp:GridView>
																														 <%-- 记录当前是第几页--%>
                                                                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                        <%-- 记录当前是第几页--%>
                                                                                        <%-- 记录信息集中总共有多少条记录--%>
                                                                                        <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                                        <%-- 记录信息集中总共有多少条记录--%>
                                                                                        <%--下面是分页控件--%>
                                                                                        <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                                            <tr height="7px">
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right" bgcolor="#ffffff">
                                                                                                    <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                                                                    &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                                        ID="DDL_ToPage" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_ToPage_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                    &nbsp;
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <%--下面是分页控件--%>
                                                                                        <asp:Label ID="Label2" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                        <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                                        <asp:HiddenField ID="H_NAME" runat="server" />
																													</td>
																												</tr>
																											</table>
																										</div>
																									</td>
																								</tr>


																								<tr>
																									<td height="10"></td>
																								</tr>
																								<tr valign="top">
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
																								</tr>
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