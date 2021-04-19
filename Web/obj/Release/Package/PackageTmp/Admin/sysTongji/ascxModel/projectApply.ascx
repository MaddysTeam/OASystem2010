<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="projectApply.ascx.cs" Inherits="Dianda.Web.Admin.sysTongji.ascxModel.projectApply" %>
  <br />
                        <table cellpadding="10" cellspacing="1" bgcolor="99cccd"  width="100%">
                        <tr>
                        <td bgcolor="#f0f0f0" height="40px" align=left>
                            <asp:Label ID="Label_tongji" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>
                        </table>
                        <br />
<table  cellpadding="0" cellspacing="0" width="100%">
                               <tr>
                                <td>&nbsp;</td>
                               </tr>
                                <tr>
                                    <td>
                               
                                    <table cellpadding="0" cellspacing="0" width="98%">
                                    <tr>
                                    <td>&nbsp;&nbsp;按类型筛选：<asp:DropDownList ID="DDL_type" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="DDL_type_Change">
                                    <asp:ListItem Value="orderSignet">用印</asp:ListItem>
                                    <asp:ListItem Value="orderCar">车辆</asp:ListItem>
                                    <asp:ListItem Value="orderFood">午餐</asp:ListItem>
                                    <asp:ListItem Value="orderRoom">会议室</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<asp:HiddenField ID="HiddenField_projectid" 
                                            runat="server" />
                                        </td>
                                    </tr>
                                   <tr><td colspan = "7" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
                    
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top" align="center">
                           <asp:GridView ID="GridView1"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1" >
                            <Columns>  
                              <asp:TemplateField HeaderText="序号">
                        <ItemTemplate>
                            <%# (Container.DataItemIndex + 1)%>
                        </ItemTemplate>
                        <HeaderStyle CssClass="HeaderStyle1" HorizontalAlign="Center" />
                        <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                    </asp:TemplateField>
                                   <asp:BoundField HeaderText="" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                               <asp:TemplateField HeaderText="备注">
                               <ItemTemplate>
                                 <span title="<%#Eval("Overviews").ToString()%>"><%#Eval("Overviews").ToString().Length >10 ? Eval("Overviews").ToString().Substring(0, 10) + "..." : Eval("Overviews").ToString()%></span>
                                <asp:HiddenField ID="Hid_ID" runat="server" /> </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1"  />
                                 <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                            </asp:TemplateField>
 
                                <asp:BoundField HeaderText="状态" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="附件" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                
                            </Columns>
                   
                </asp:GridView>
                <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td></tr></table></td>
                </tr>
                </table>
                 