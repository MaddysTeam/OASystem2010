<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="personPlanCalendar.ascx.cs" Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.personPlanCalendar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ccl" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <table style="width: 100%">
            <tr>
                <td colspan="5">
                    <asp:Label ID="Label_DateProject" runat="server" Text="日程表"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Calendar ID="Calendar1" runat="server" Width="366px"></asp:Calendar>
                </td>
            </tr>
            <tr>
                <td style="width: 40px">
                    </td>
                <td>
                    <asp:Label ID="Label_AddPersonProject" runat="server" Text="新增个人计划"></asp:Label>
                </td>
                <td>
                    </td>
                <td colspan="2">
                    </td>
            </tr>
            <tr>
               <td colspan="5">
                  <div id="TabContainer">
                   <ccl:TabContainer runat="server" ctiveTabIndex="0" Width="220px" ID="TabContainer_Tab" ActiveTabIndex="1">
                       <ccl:TabPanel ID="TabPanel_ClassProject" HeaderText="部门任务" runat="server">
                       <HeaderTemplate>
                         部门任务
                       </HeaderTemplate>
                           <ContentTemplate>
                               <asp:GridView ID="GridView_ClassProject" runat="server" AutoGenerateColumns="false">
                                  <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="width: 111px">
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("NAMES") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                               </asp:GridView>
                           </ContentTemplate>
                       </ccl:TabPanel>
                       
                       
                        <ccl:TabPanel ID="TabPanel_PersonProject" runat="server" HeaderText="个人计划">
                            <HeaderTemplate>
                                个人计划
                            </HeaderTemplate>
                            <ContentTemplate>
                                <asp:GridView ID="GridView_PersonProject" runat="server" AutoGenerateColumns="False">
                                      <Columns>
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                <table style="width:100%">
                                                   <tr>
                                                     <td style="widows:111px">
                                                          <asp:Label ID="Label1" runat="server" Text='<%#Eval("NAMES") %>'></asp:Label>
                                                     </td>
                                                     <td>
                                                         <asp:Label ID="Label2" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label>
                                                     </td>
                                                   </tr>
                                                </table>
                                             </ItemTemplate>
                                         </asp:TemplateField>
                                      </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </ccl:TabPanel>
                    
                    </ccl:TabContainer>
                    </div>
                    </td>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="5">
                    <table style="width: 100%">
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="Label_Note" runat="server" Text="便签条"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                             <div id="NotePad">
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    Height="75px"  ShowHeader="False" 
                                    Width="307px">
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
                                                          <asp:Label ID="Label_Datetime" runat="server" Text='<%#Eval("DATETIME") %>'></asp:Label></td>
                                                      <td>
                                                          <asp:LinkButton ID="LinkButton_Del" runat="server">删除</asp:LinkButton>
                                                       </td>
                                                  </tr>
                                              </table>
                                          </ItemTemplate>
                                       </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 304px">
                                <asp:Label ID="Label_AddNote" runat="server" Text=""></asp:Label>
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