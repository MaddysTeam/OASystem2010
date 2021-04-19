<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="moban.aspx.cs" Inherits="Dianda.Web.Admin.presonPlan.moban" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td colspan="4">
                    <asp:Label ID="Label_DateProject" runat="server" Text="日程表"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Calendar ID="Calendar1" runat="server" Width="366px" ShowGridLines="True" 
                        onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 33px; height: 12px;">
                    </td>
                <td style="height: 12px">
                    <asp:Label ID="Label_AddPersonProject" runat="server" Text="新增个人计划"></asp:Label>
                </td>
                <td style="height: 12px">
                    </td>
                <td style="height: 12px">
                    </td>
            </tr>
            <tr>
               <td colspan="4" style="height: 240px" valign="top">
                 <asp:TabContainer ID="TabContainer" runat="server" ActiveTabIndex="1" 
                       Width="366px" Height="229px">
                    <asp:TabPanel ID="TabPanel_ClassProject" runat="server" HeaderText="项目任务">
                       <HeaderTemplate>项目任务</HeaderTemplate>
                       <ContentTemplate>
                           <div>
                           <asp:GridView ID="GridView_ClassProject" runat="server" AutoGenerateColumns="False">
                               <Columns>
                                   <asp:TemplateField>
                                       <ItemTemplate>
                                           <table style="width: 100%">
                                                <tr>
                                                  <td>
                                            <asp:Label ID="Label_NAMES" runat="server" Text='<%#Eval("NAMES") %>'></asp:Label>
                                                   </td>
                                                </tr>
                                             <tr>
                                                   <td>
                                           <asp:Label ID="Label_DATETIME" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label>
                                                  </td>
                                              </tr>
                                           </table>
                                       </ItemTemplate>
                                   </asp:TemplateField>
                               </Columns>
                           </asp:GridView>
                           </div>
                       </ContentTemplate>
                    </asp:TabPanel>
                     <asp:TabPanel ID="TabPanel_PersonProject" runat="server" HeaderText="个人项目">
                     <HeaderTemplate>个人项目</HeaderTemplate>
                     <ContentTemplate>
                         <asp:GridView ID="GridView_PresonProject" runat="server" 
                             AutoGenerateColumns="False" PageSize="5">
                            <Columns>
                               <asp:TemplateField>
                                    <ItemTemplate>
                                        <table style="width:100%">
                                                <tr>
                                                  <td>
                                            <asp:Label ID="Label_NAMES" runat="server" Text='<%#Eval("NAMES") %>'></asp:Label>
                                                   </td>
                                                </tr>
                                             <tr>
                                                   <td>
                                           <asp:Label ID="Label_DATETIME" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label>
                                                  </td>
                                              </tr>
                                           </table>
                                    </ItemTemplate>
                               </asp:TemplateField>
                            </Columns>
                         </asp:GridView>
                     </ContentTemplate>
                     </ccl:TabPanel>
                 </asp:TabContainer>
                 &nbsp;</td>
            </tr>
            <tr valign="top">
                <td colspan="4" valign="top">
                    <table style="width: 100%">
                        <tr>
                            <td>
                                <asp:Label ID="Label_Note" runat="server" Text="便签条"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                             <div id="NotePad">
                                <asp:GridView ID="GridVie_NoteDetial" runat="server" AutoGenerateColumns="False" 
                                    Height="75px"  ShowHeader="False"  Width="366px" PageSize="5">
                                    <Columns>
                                       <asp:TemplateField>
                                          <ItemTemplate>
                                              <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                  <tr>
                                                      <td>
                                                          <asp:Label ID="Label_NAMES" runat="server" Text='<%#Eval("NAMES") %>'></asp:Label>
                                                       </td>
                                                   </tr>
                                                   <tr>
                                                      <td>
                                                          <asp:Label ID="Label_Datetime" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label></td>
                                                      <td>
                                                          &nbsp;</td>
                                                  </tr>
                                              </table>
                                          </ItemTemplate>
                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                 <asp:HiddenField ID="HiddenField1" runat="server" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 290px">
                                <asp:Label ID="Label_AddNote" runat="server" Text=""></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label_best" runat="server" Text=""></asp:Label>
                            </td>
                            <td style="width: 274px">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
