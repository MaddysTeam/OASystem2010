<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="docToIndexShow.ascx.cs" Inherits="Dianda.Web.Admin.DOC_transport.docToIndexShow" %>
                <table height="40px" align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"
                    width="658">
                    <tr>
                      <td valign="middle" align="right"  background="/Admin/images/doctofrom/header_1.gif" height="38"><a href="/Admin/DOC_transport/manageShou.aspx" target="_blank">more>></a>&nbsp;&nbsp;&nbsp;</td>
                    </tr>
                     <tr>
                    <td height="5"  background="/Admin/images/doctofrom/middle_1.gif"></td>
                    </tr>
                    <tr>
                        <td valign="top" align="center"  background="/Admin/images/doctofrom/middle_1.gif" height="160">
                            <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound"
                                AutoGenerateColumns="False" runat="server" Width="96%" ShowHeader="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None">
                                <RowStyle Height="20" BackColor="#ffffff" ForeColor="#333333" />
                                <Columns>
                                    <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                                            <img src="/Admin/images/doctofrom/image.gif" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="标题" DataField="TITLES">
                                        <ItemStyle HorizontalAlign="Left"/>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                       <asp:TemplateField HeaderText="发件人">
                                        <ItemTemplate>
                                          发件人:<%#Eval("FROMUSER")%>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="140" />
                                    </asp:TemplateField>
                                 <asp:TemplateField HeaderText="发件人">
                                        <ItemTemplate>  
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="20" />
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="发布日期" DataField="DATETIME" DataFormatString="{0:yyyy-MM-dd}">
                                        <ItemStyle HorizontalAlign="Left" Width="80" />
                                          <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                </Columns>

                                <FooterStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#ffffff" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="#000000" />
                                <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#ffffff" />
                                <AlternatingRowStyle BackColor="#ffffff" ForeColor="#000000" />

                            </asp:GridView>
                            <asp:Label ID="notice" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    <td height="5"  background="/Admin/images/doctofrom/middle_1.gif"></td>
                    </tr>
                      <tr>
                      <td valign="middle" align="right"  background="/Admin/images/doctofrom/bottom_1.gif" height="13"></td>
                    </tr>
                </table>