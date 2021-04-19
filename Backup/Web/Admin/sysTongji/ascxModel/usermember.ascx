<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usermember.ascx.cs" Inherits="Dianda.Web.Admin.sysTongji.ascxModel.usermember" %>
  <%--文档汇总信息--%> <br />
                        <table cellpadding="10"  align="center"  cellspacing="1" bgcolor="99cccd"  width="98%">
                        <tr>
                        <td bgcolor="#f0f0f0" height="40px" align=left>
                            <asp:Label ID="Label_tongji" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>
                        </table>
                         <%--文档汇总信息--%>
   <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                             
                                <tr>
                                    <td>
                                     <asp:GridView ID="GridView_grouplist" Width="100%" runat="server" AutoGenerateColumns="False"
                                                    BackColor="White" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" CellPadding="0"
                                                    ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView_grouplist_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <table cellpadding="1" cellspacing="1" width="100%" bgcolor="#99cccd">
                                                                    <tr>
                                                                        <td bgcolor="#99cccd" height="25">
                                                                            &nbsp;<asp:CheckBox ID="depid" runat="server"  
                                                                        Enabled="false"          TabIndex="<%# Container.DataItemIndex%>" /><%#Eval("NAME")%><asp:HiddenField
                                                                                    ID="Hid_ID" runat="server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr  bgcolor="#f0f0f0" height="40px">
                                                                        <td  align="center"><table cellpadding="0" cellspacing="0" width="90%"><tr><td align="left"> <asp:CheckBoxList   ID="CheckBoxList_userlist" runat="server" RepeatColumns="4">
                                                                            </asp:CheckBoxList></td></tr></table>
                                                                           
                                                                        </td>
                                                                    </tr>
                                                                </table><br />
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
                                          
                                        </td></tr>
                                        <tr>
                        <td height="40px" align="center" bgcolor="#ffffff">
                        
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