<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showHistoryAll.aspx.cs" MasterPageFile="~/Admin/OAmaster.Master" Inherits="Dianda.Web.Admin.budgetManage.department.showHistoryAll" %>


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
                                                                                                                    学科：
                                                                                                                </td>
                                                                                                                <td style="width: 200px; height: 25px;" align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:TextBox ID="txtXK" runat="server"></asp:TextBox>
                                                                                                                    &nbsp;
                                                                                                                </td>
                                                                                                                <td style="width: 100px; height: 25px;" align="center">
                                                                                                                    <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="button1"  />
                                                                                                                </td>
                                                                                                                <td align="left">
                                                                                                                    &nbsp;
                                                                                                                    <asp:Button ID="btnReport" runat="server" Text="导 出" CssClass="button1"  />
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
                                                                                                                            <asp:Label ID="labID" runat="server" Text="Label"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="学科">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("CardName")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="使用人">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("HolderRealName")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="劳务费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labJKF" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="餐费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labCF" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="资料费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labZLF" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="会务费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labHWF" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="交通费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labJTF" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="其他">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labQT" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="使用合计">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="labSYHJ" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="结余">
                                                                                                                        <ItemTemplate>
																															   <asp:Label ID="BalanceAll" runat="server" ></asp:Label>
                                                                                                                            <%--<%# Eval("BalanceAll")%>--%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="额度">
                                                                                                                        <ItemTemplate>
																															 <asp:Label ID="OldbalanceAll" runat="server"><%# Eval("OldbalanceAll")%></asp:Label>
                                                                                                                          <%--  <%# Eval("OldbalanceAll")%>--%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                        
                                                                                                        <div id="tabUsGridPaging" runat="server" style="width: 97%;text-align: left;">
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
                                                                                                        </div>
                                                                                                        
                                                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" CellPadding="3"
                                                                                                                CssClass="GridView11" Width="100%" Visible="false">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="序号">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="学科">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("CardName")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="使用人">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("HolderRealName")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="讲课费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="餐费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label3" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="资料费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label4" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="会务费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label5" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="交通费">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label6" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="其他">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="使用合计">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="结余">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("BalanceAll")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="额度">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%# Eval("OldbalanceAll")%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                            </asp:GridView>
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