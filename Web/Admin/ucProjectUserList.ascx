<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProjectUserList.ascx.cs" Inherits="Dianda.Web.Admin.ucProjectUserList" %>

<table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd" style=" margin-top:3px;">
    <tr>
        <td>
            <table align="center" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="tab8" align="center">
                                        <tr>
                                            <td><asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label></td>
                                            <td class="LB_name1">　　　 部门成员　　　　　性别　　　　　　　岗位　　　　　　　　　电话　　　　　　　　　　　邮箱</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr><td style="height:5px"></td></tr>
                            <tr>
                                <td align="center">
                                <div style="OVERFLOW-y:scroll;OVERFLOW-x:none; width:715px; height:108px;">
                                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" ShowHeader="false" OnRowDataBound="GridView1_RowDataBound"
                                                                            runat="server" CellPadding="3" CssClass="GridView2">
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
                                </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table height="10px" align="center" cellpadding="1" cellspacing="1" width="98%">
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

