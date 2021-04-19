<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.userManager.OAgroupmanage.manage" %>

<%@ Register Src="~/Admin/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu" runat="server" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
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
                                                                <%--<asp:Label ID="LB_name" runat="server" Text = "" CssClass="LB_name1"></asp:Label>管理>>--%><asp:Label
                                                                    ID="LB_name2" runat="server" Text="Label" CssClass="LB_name1"></asp:Label>管理
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
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
                                                                                        <table class="tab2">
                                                                                            <tr>
                                                                                                <td style="padding-left: 600px">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td style="width: 74px">
                                                                                                                <asp:Button ID="Button_add" runat="server" Text="Button" OnClick="Button_add_onclick"
                                                                                                                    CssClass="button3b" />
                                                                                                            </td>
                                                                                                            <td style="width: 50px">
                                                                                                                <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                                                    CssClass="button3a" />
                                                                                                            </td>
                                                                                                            <td style="width: 50px">
                                                                                                                <asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"
                                                                                                                    OnClick="Button_delete_onclick" CssClass="button3a" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4" align="center">
                                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <table align="center" cellpadding="1" cellspacing="1" width="100%">
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                                                runat="server" CssClass="GridView1" PageSize="10" Width="100%">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="">
                                                                                                                        <HeaderTemplate>
                                                                                                                            <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                                                                Text="" />全选
                                                                                                                        </HeaderTemplate>
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                                                runat="server" />
                                                                                                                        </ItemTemplate>
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="50" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <%-- <asp:TemplateField HeaderText="序号">
                                                                                                                         <ItemTemplate>
                                                                                                                         <%#Container.DataItemIndex+1 %>
                                                                                                                         /ItemTemplate> 
                                                                                                                         <HeaderStyle HorizontalAlign="Center"  Width="40"/>
                                                                                                                          <ItemStyle HorizontalAlign="Center" Width="40"/>
                                                                                                                          </asp:TemplateField> --%>
                                                                                                                    <asp:BoundField HeaderText="名称" DataField="NAME">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" Width="80" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="80" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:TemplateField HeaderText="人员">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%#Eval("REALNAME").ToString()%>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" Width="450" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="450" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:BoundField HeaderText="人数" DataField="ISMOREN">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" Width="50" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="50" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:TemplateField HeaderText="描述">
                                                                                                                        <ItemTemplate>
                                                                                                                            <span title="<%#Eval("CONTENTS").ToString()%>">
                                                                                                                                <%#Eval("CONTENTS").ToString().Length > 35 ? Eval("CONTENTS").ToString().Substring(0, 35) + "..." : Eval("CONTENTS").ToString()%></span>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                                            </asp:GridView>
                                                                                                            <asp:Label ID="notice" runat="server" Text="" CssClass="notice"></asp:Label>
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr height="20px">
                                                                        <td>
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
                                        <asp:HiddenField ID="H_NAME" runat="server" />
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
