<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="rolemodel.ascx.cs" Inherits="Dianda.Web.Admin.sysRights.rolemodel" %>
<asp:GridView ID="GridView_grouplist" Width="100%" runat="server" 
    AutoGenerateColumns="False" BackColor="White" BorderColor="#ffffff" 
    BorderStyle="Solid" BorderWidth="0px" CellPadding="0" ForeColor="Black" 
    GridLines="Vertical" 
    onrowdatabound="GridView_grouplist_RowDataBound" ShowHeader="False">
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
            <table cellpadding="0" cellspacing="0" width="100%">
            <tr><td bgcolor="#f0f0f0" height="25" colspan="3">
               &nbsp;<asp:CheckBox ID="depid"  runat="server" 
                    oncheckedchanged="depid_CheckedChanged" AutoPostBack="true" TabIndex="<%# Container.DataItemIndex%>"/><%#Eval("NAME")%><asp:HiddenField ID="Hid_ID"
                    runat="server" />
            </td></tr>
            <tr>  <td width="20"></td>
            <td><asp:CheckBoxList ID="CheckBoxList_userlist" runat="server" RepeatColumns="4">
                </asp:CheckBoxList>
            </td>  <td width="20"></td>
            </tr>
            </table>
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