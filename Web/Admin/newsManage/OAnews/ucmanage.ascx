<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucmanage.ascx.cs" Inherits="Dianda.Web.Admin.newsManage.OAnews.ucmanage" %>
<table cellpadding="0" cellspacing="0" width="100%" height="100%">
    <tr>
        <td valign="top">
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td height="3px">
                    </td>
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
                                                                        <table class="tab2">
                                                                            <tr>
                                                                               
                                                                                <td align="right">
                                                                                    <table>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:Button ID="Button_add" runat="server" Text="新建" OnClick="Button_add_onclick"
                                                                                                    CssClass="button3a" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="Button_modify" runat="server" Text="编辑" OnClick="Button_modify_onclick"
                                                                                                    CssClass="button3a" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"
                                                                                                    OnClick="Button_delete_onclick" CssClass="button3a" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="7" align="center">
                                                                                    <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                            runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="ID,ForItems,PARENTID,LimitsChoose"
                                                                            PageSize="10">
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
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="名称" DataField="NAME">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="栏目" DataField="PARENTNAME">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="浏览权限" DataField="LimitsChoose">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                            </Columns>
                                                                            <FooterStyle CssClass="FooterStyle1" />
                                                                            <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                            <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                        </asp:GridView>
                                                                        <asp:GridView ID="GridView2" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
                                                                            runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="ID,ForItems,PARENTID,LimitsChoose"
                                                                            PageSize="10">
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
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField HeaderText="名称" DataField="NAME">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="栏目" DataField="PARENTNAME">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="已读" DataField="IsRead">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField HeaderText="阅读时间" DataField="ReadTime" DataFormatString="{0:yyyy-MM-dd}">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>
                                                                                <%-- 20100812 tcl说不显示内容  <asp:BoundField HeaderText="内容" DataField="CONTENTS">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                </asp:BoundField>--%>
                                                                                <asp:BoundField HeaderText="浏览权限" DataField="LimitsChoose">
                                                                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
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
                            <tr height="7px">
                                <td></td>
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
        <td width="5">
        </td>
    </tr>
</table>
