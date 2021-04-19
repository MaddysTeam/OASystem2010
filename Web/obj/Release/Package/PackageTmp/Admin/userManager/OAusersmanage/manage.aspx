<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.userManager.OAusersmanage.manage" %>

<%@ Register Src="~/Admin/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                                                        人员管理
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
                                                                                                        <td>
                                                                                                            部门：<asp:DropDownList ID="DDL_Depart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Depart_SelectedIndexChanged">
                                                                                                            </asp:DropDownList>
                                                                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;状态：<asp:DropDownList ID="DDL_Status" runat="server"
                                                                                                                OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged" AutoPostBack="True">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td style="padding-left: 300px" align="right">
                                                                                                            <table>
                                                                                                                <tr>
                                                                                                                    <td width="74px">
                                                                                                                        <asp:LinkButton ID="LinkButton1" Visible="false" runat="server" OnClick="LinkButton1_Click">创建用户的文件夹</asp:LinkButton><asp:Button
                                                                                                                            ID="Button_add" runat="server" Text="新建人员" OnClick="Button_add_onclick" CssClass="button3b" />
                                                                                                                    </td>
                                                                                                                    <td width="50px">
                                                                                                                        <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                                                            CssClass="button3a" />
                                                                                                                    </td>
                                                                                                                    <td width="50px">
                                                                                                                        <asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"
                                                                                                                            OnClick="Button_delete_onclick" CssClass="button3a" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan="2" align="center">
                                                                                                            <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table align="center" cellpadding="1" cellspacing="1" width="100%">
                                                                                                    <tr>
                                                                                                        <td valign="top">
                                                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                                                                                                                PageSize="10" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1">
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
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="姓名">
                                                                                                                        <ItemTemplate>
                                                                                                                            <a href="javascript:window.showModalDialog('../OAgroupmanage/show.aspx?userid=<%#Eval("ID").ToString()%>','','dialogWidth=715px;dialogHeight=250px');"
                                                                                                                                title="人员详细信息">
                                                                                                                                <%#Eval("REALNAME").ToString()%></a>
                                                                                                                        </ItemTemplate>
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:BoundField HeaderText="性别" DataField="SEX">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="所属部门" DataField="DepartMentName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Left" Width="150px" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="工作岗位" DataField="StationName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="联系电话" DataField="TEL">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="邮箱" DataField="EMAIL">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="状态" DataField="WorkStataName">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
                                                                                                                    <asp:BoundField HeaderText="项目经理" DataField="">
                                                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                                    </asp:BoundField>
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
                                                                                                                <tr>
                                                                                                                    <td height="7px">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="right" bgcolor="#ffffff">
                                                                                                                        <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                                                                                        &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                                                            ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                                                                        </asp:DropDownList>
                                                                                                                        &nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <%--下面是分页控件--%>
                                                                                                            <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                                                            <asp:HiddenField ID="H_NAME" runat="server" />
                                                                                                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
