<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OADepartMent.manage" %>

<%@ Register Src="~/Admin/personalProjectManage/OADepartMent/shareForUser1.ascx"
    TagName="shareForUser" TagPrefix="uc1" %>
<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="90%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <uc1:projectControl ID="projectControl1" runat="server" />
                                    </td>
                                </tr>
                                <tr id="ShowUser" runat="server">
                                    <td>
                                        <table class="tab7">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="right">
                                                                            <table>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Button ID="Button1" runat="server" CssClass="button3b" Text="编辑人员" OnClick="Button1_Click" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="Button2" runat="server" CssClass="button3b" Text="编辑部门" OnClick="Button2_Click" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="Button3" runat="server" CssClass="button3b" Text="项目负责人" OnClick="Button3_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>
                                                                            <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="GridView1"
                                                                                AutoGenerateColumns="False" Width="100%" PageSize="10">
                                                                                <Columns>
                                                                                    <asp:BoundField HeaderText="部门成员" DataField="REALNAME">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="133" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="性别" DataField="SEX">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="85" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="岗位" DataField="StationName">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="130" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="电话" DataField="TEL">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="143" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="邮箱" DataField="EMAIL">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="170" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
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
                                                                                <tr height="7px">
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <%--下面是分页控件--%>
                                                                            <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                            <asp:HiddenField ID="H_NAME" runat="server" />
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
                                <tr id="CheckboxShowUser" runat="server">
                                    <td>
                                        <table class="tab7">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5" cellpadding="0" cellspacing="0">
                                                                    <tr height="35px">
                                                                        <td style="font-weight: bold; font-size: 14px; font-family: 宋体; text-align: center;">
                                                                            编辑项目人员
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <uc1:shareForUser ID="shareForUser1" runat="server" />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="40px" align="center" bgcolor="#ffffff">
                                                                            <asp:Button ID="Button_sumbit" runat="server" Text=" 确定 " CssClass="button1" OnClick="Button_sumbit_Click" />
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                                            <asp:Button ID="Button7" CssClass="button1" runat="server" Text="返回" OnClick="Button7_Click" />
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
                                <tr id="DDL_COLUMN" runat="server">
                                    <td>
                                        <table class="tab7">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5">
                                                                    <tr>
                                                                        <td align="left">
                                                                            <br />
                                                                            <br />
                                                                            <table width="100%" style="border: solid 1px #99CCCD" cellpadding="0" cellspacing="0">
                                                                                <tr style="background-color: #99CCCD" height="35px">
                                                                                    <td colspan="2" style="font-weight: bold; font-size: 14px; font-family: 宋体; text-align: center">
                                                                                        编辑部门
                                                                                    </td>
                                                                                </tr>
                                                                                <tr align="center">
                                                                                    <td align="left">
                                                                                        <asp:CheckBoxList Width="100%" ID="CB_DepartmentID" runat="server" RepeatColumns="4"
                                                                                            RepeatDirection="Horizontal">
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br />
                                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div style="font-size: 14x; font-weight: bold">
                                                                                        <asp:CheckBox ID="CheckBox1" AutoPostBack="true" runat="server" Text="" OnCheckedChanged="CheckBox1_CheckedChanged" />刷新用户列表
                                                                                    </div>
                                                                                    <asp:Label ID="Label_Tag1" Style="color: Red" runat="server" Visible="false" Text="启用刷新用户列表后会导致发生变更部门中的用户被移除(包括项目创建人,负责人)！请谨慎操作！"></asp:Label>
                                                                                    <br />
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                            <div style="text-align: center; width:100%">
                                                                            <br />
                                                                                <asp:Button ID="Button_sumbit2" CssClass="button1" runat="server" Text="确 定" OnClick="Button_sumbit2_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Button ID="Button5" CssClass="button1" OnClick="Button7_Click" runat="server"
                                                                                    Text="返回" />
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
                                <tr id="Tr_3" runat="server">
                                    <td>
                                        <table class="tab7">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5">
                                                                    <tr>
                                                                        <td>
                                                                            <table width="100%">
                                                                                <tr align="center">
                                                                                    <td align="center">
                                                                                        <br />
                                                                                        <br />
                                                                                        <br />
                                                                                        <table width="50%" height="80px" style="border: solid 1px #99CCCD" cellpadding="0"
                                                                                            cellspacing="0">
                                                                                            <tr style="background-color: #99CCCD" height="35px">
                                                                                                <td colspan="2" style="font-weight: bold; font-size: 14px; font-family: 宋体;">
                                                                                                    设置项目负责人
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr height="35px">
                                                                                                <td align="right">
                                                                                                    当前该项目负责人：&nbsp;&nbsp;&nbsp;
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    &nbsp;&nbsp;<asp:Label ID="Label_UserAdmin" runat="server" Text="Label"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr height="35px">
                                                                                                <td align="right">
                                                                                                    请选择项目负责人：&nbsp;&nbsp;&nbsp;
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    &nbsp;&nbsp;<asp:DropDownList ID="DropDownList_UserAdmin" runat="server">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 50px;" align="center">
                                                                                        <asp:Button ID="Button4" runat="server" Text="确定" CssClass="button1" OnClick="Button4_Click" />
                                                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                        <asp:Button ID="Button6" CssClass="button1" OnClick="Button7_Click" runat="server"
                                                                                            Text="返回" />
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
            </td>
        </tr>
    </table>
    <br />
</asp:Content>
