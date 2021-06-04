<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showHistoryAll.aspx.cs" MasterPageFile="~/Admin/OAmaster.Master" Inherits="Dianda.Web.Admin.budgetManage.todo.showHistoryAll" %>


<%@ Register Src="../../cashCardManage/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />
    <table cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td width="4">
            </td>
            <td valign="top" width="115" align="left" runat="server" id="td_left">
                
                <uc1:OAleftmenu ID="OAleftmenu_Show1" runat="server" Visible="true" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="3px">
                        </td>
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
                                                                                                        <asp:Label ID="LB_MSG" runat="server" ForeColor="Red" Text=""></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="middle">
                                                                                                    <td align="center">
                                                                                                        <table width="97%" border="0" cellpadding="0" cellspacing="1" bgcolor="#000000">
                                                                                                            <tr style="background-color: #ffffff">
                                                                                                                <td style="width: 80px; height: 25px;" align="center">
                                                                                                                    经费名称：
                                                                                                                </td>
                                                                                                                <td style="width: 200px; height: 25px;" align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:TextBox ID="txtJF" runat="server"></asp:TextBox>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="center">
                                                                                                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="button1"   OnClick="btnSearch_Click"/>
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Button ID="btnReport" runat="server" Text="导 出" CssClass="button1" OnClick="btnReport_Click"  />
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr valign="bottom">
                                                                                                    <td align="center">
                                                                                                        <div style="width: 97%;text-align: left;">
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
                                                                                                                  <%--  <asp:TemplateField HeaderText="负责人">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("Manager")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>--%>
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
                                                                                                                    <asp:TemplateField HeaderText="项目经费总额">
                                                                                                                        <ItemTemplate>
																															 <asp:Label ID="TotalBudget" runat="server"><%# Eval("TotalBalance")%></asp:Label>
                                                                                                                          <%--  <%# Eval("OldbalanceAll")%>--%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
																													<asp:TemplateField HeaderText="经费总余额">
                                                                                                                        <ItemTemplate>
																															 <asp:Label ID="TotalBalance" runat="server"><%# Eval("KYBalance")%></asp:Label>
                                                                                                                          <%--  <%# Eval("OldbalanceAll")%>--%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
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
                                                                                                        </div>
                                                                                                        
                  <%--                                                                                      <div id="tabUsGridPaging" runat="server" style="width: 97%;text-align: left;">
                                                                                                            <table style="width: 100%;">
                                                                                                                <tr>
                                                                                                                    <td valign="baseline" align="right">
                                                                                                                        <asp:LinkButton ID="homePage" runat="server" >首页</asp:LinkButton>
                                                                                                                        <asp:LinkButton ID="firstPage" runat="server" >上一页</asp:LinkButton>
                                                                                                                        <asp:LinkButton ID="nextPage" runat="server" >下一页</asp:LinkButton>
                                                                                                                        <asp:LinkButton ID="lastPage" runat="server" >最后页</asp:LinkButton>
                                                                                                                        <asp:Label ID="totalRecord" runat="server" Text="共条"></asp:Label>
                                                                                                                        <asp:Label ID="totalPage" runat="server" Text="共页"></asp:Label>
                                                                                                                        <asp:Label ID="nowPage" runat="server" Text="当前第页"></asp:Label>
                                                                                                                        <asp:DropDownList ID="targetPage" runat="server" AutoPostBack="True" 
                                                                                                                            >
                                                                                                                        </asp:DropDownList>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </div>--%>
                                                                                                        
                                                                                                       
                                                                                                        </div>
                                                                                                        
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="10">
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
                                                <td height="5px">
                                                </td>
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
                        <td height="10px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>