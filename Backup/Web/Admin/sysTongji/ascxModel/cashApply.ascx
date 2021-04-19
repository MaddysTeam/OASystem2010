<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="cashApply.ascx.cs" Inherits="Dianda.Web.Admin.sysTongji.ascxModel.cashApply" %>
<br />
<table cellpadding="10" cellspacing="1" bgcolor="99cccd" width="100%">
    <tr>
        <td bgcolor="#f0f0f0" height="40px" align="left">
            <asp:Label ID="Label_tongji" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
<br />
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <table cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td>
                        &nbsp;&nbsp;按状态筛选：<asp:DropDownList ID="ddlStatas" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlStatas_SelectedIndexChanged">
                            <asp:ListItem Value="0">待审核</asp:ListItem>
                            <asp:ListItem Value="1">审核通过</asp:ListItem>
                            <asp:ListItem Value="2">审核不通过</asp:ListItem>
                        </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField ID="HiddenField_projectid" runat="server" /><asp:HiddenField ID="HiddenField_totals"  Value="0" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        
                    </td>
                </tr>
            </table>
            <table align="center" cellpadding="1" cellspacing="1" width="100%">
                <tr>
                    <td valign="top" align="center">
                        <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                            runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames="ID,ApplierRealName,GetDateTime,ApplyCount"
                            Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <ItemTemplate>
                                        <%# (Container.DataItemIndex + 1)%>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                                    <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="金额" DataField="ApplyCount">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="项目" DataField="ProjectName">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="领取预约时间" DataField="GetDateTime">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="状态" DataField="Statas">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                            </Columns>
                            <FooterStyle CssClass="FooterStyle1" />
                            <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                            <SelectedRowStyle CssClass="SelectedRowStyle1" />
                        </asp:GridView>
                        <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
