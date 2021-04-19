<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uccolumns.ascx.cs" Inherits="Dianda.Web.Admin.newsManage.OAcolumns.columns" %>
<table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
    <tr>
        <td>
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
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
                                                <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>管理
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
                                                        <td>
                                                            <table class="tab5">
                                                                <tr>
                                                                    <td>
                                                                        <table class="tab2">
                                                                            <tr>
                                                                                <td style="width: 500px;">
                                                                                    <asp:DropDownList ID="ddlNews_Columns" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlNews_Columns_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <%--  <td>
                                                                                </td>
                                                                                <td>
                                                                                    操作:
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Button_add" runat="server" Text="新建" OnClick="Button_add_onclick"
                                                                                        CssClass="button2" />
                                                                                </td>
                                                                                <td>
                                                                                    |
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                        CssClass="button2" />
                                                                                </td>
                                                                                <td>
                                                                                    |
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"
                                                                                        OnClick="Button_delete_onclick" CssClass="button2" />
                                                                                </td>--%>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                            runat="server" CellPadding="3" CssClass="GridView1">
                                                                            <Columns>
                                                                                <%--  <asp:TemplateField HeaderText="">
                                                                                    <HeaderTemplate>
                                                                                        <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                            Text="" />全选
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                            runat="server" />
                                                                                    </ItemTemplate>
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                </asp:TemplateField>--%>
                                                                                <asp:BoundField HeaderText="名称" DataField="NAME">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="栏目" DataField="PARENTID">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="栏目类型" DataField="ForItems">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="部门/项目ID" DataField="ItemsID">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="顺序" DataField="SHUNXU">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <FooterStyle CssClass="FooterStyle1" />
                                                                            <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                            <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                        </asp:GridView>
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                                                    <td>
                                                                        <div id="div2" runat="server">
                                                                            <table>
                                                                                <tr>
                                                                                    <td colspan="3" align="center">
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #A5BBF1;">
                                                                                    <td colspan="2" align="left">
                                                                                        <asp:Label ID="notice1" runat="server" Text="必填项" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        名称：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        父栏目：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPARENTID" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        栏目类型：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="ddlForItems" runat="server" RepeatColumns="2">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        顺序：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtSHUNXU" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #A5BBF1;">
                                                                                    <td colspan="2" align="left">
                                                                                        <asp:Label ID="notice2" runat="server" Text="非必填项" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        部门/项目ID：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlItemsID" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Button ID="Button_sumbit" runat="server" Text="确定" OnClick="Button_sumbit_Click"
                                                                                            CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_reset"
                                                                                                runat="server" Text="重置" OnClick="Button_reset_Click" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                    ID="Button_cancel" runat="server" Text="取消" CssClass="button1" OnClick="Button_cancel_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
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
            <table height="40px" align="center" cellpadding="1" cellspacing="1" width="98%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="notice" runat="server" Text="" CssClass="notice"></asp:Label>
                        <asp:HiddenField ID="H_NAME" runat="server" />
                        <%-- <asp:HiddenField ID="H_ModifyID" runat="server" />--%>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
