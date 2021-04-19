<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowPlanUser.ascx.cs" Inherits="Dianda.Web.Admin.ShowPlanUser" %>
<asp:GridView ID="GridView_grouplist" Width="100%" runat="server" AutoGenerateColumns="False"
    BackColor="White" BorderColor="#ffffff" BorderStyle="Solid" BorderWidth="0px"
    CellPadding="0" ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView_grouplist_RowDataBound"
    ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#99cccd">
                    <tr>
                        <td bgcolor="#99cccd" height="25">
                            &nbsp;<asp:CheckBox ID="depid" runat="server" OnCheckedChanged="depid_CheckedChanged"
                                AutoPostBack="true" TabIndex="<%# Container.DataItemIndex%>" /><%#Eval("NAME")%><asp:HiddenField
                                    ID="Hid_ID" runat="server" />
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#f0f0f0" height="40px">
                        <td align="center">
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left">
                                        <asp:CheckBoxList ID="CheckBoxList_userlist" Width="100%" TabIndex="<%# Container.DataItemIndex%>" OnSelectedIndexChanged="user_CheckedChanged"  runat="server" RepeatColumns="4" AutoPostBack="true">
                                        </asp:CheckBoxList>
                                        <asp:HiddenField ID="HiddenField_old" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
    <FooterStyle BackColor="#ffffff" />
    <PagerStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Center" />
    <EmptyDataTemplate>
    </EmptyDataTemplate>
    <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
    <AlternatingRowStyle BackColor="#ffffff" />
</asp:GridView>
