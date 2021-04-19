<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="roleM.aspx.cs" Inherits="Dianda.Web.Admin.sysRights.roleM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
    <tr><td height="3px"></td></tr>
        <tr >
            
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="0" width="100%">
                               
                                <tr>
                                    <td>
                                    <table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td>
                                    
                                    <table class="tab2">
                                    <tr>
                                    <td>权限类型：<asp:DropDownList ID="DDL_Depart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Depart_SelectedIndexChanged">
                                        <asp:ListItem Selected="True">页面权限</asp:ListItem>
                                        <asp:ListItem>按钮权限</asp:ListItem>
                                        <asp:ListItem>菜单权限</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style=" padding-left:300px" align=right>
                                    <table><tr> 
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_add" runat="server" 
                                            CssClass="button3b" onclick="LinkButton_add_Click">添加权限</asp:LinkButton></td>
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_roleM" runat="server" 
                                            CssClass="button3b" onclick="LinkButton_roleM_Click">配置用户</asp:LinkButton></td>
                                    
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_groupM" runat="server" OnClick="LinkButton_groupM_Click" CssClass="button3b">组管理</asp:LinkButton></td>
                                    
                                    </tr>
                                   </table></td></tr>
                                   <tr><td colspan = "2" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
             <%--      添加新的权限--%>
             <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#000000"  runat="server" id="addrole" visible="false">
             <tr>
             <td bgcolor="#ffffff">
                    <table cellpadding="0" cellspacing="0" width="100%" height="140px">
                   <tr>
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;添加权限</td>
              </tr>
                   <tr>
                   <td align="right">权限名称:</td><td><asp:TextBox ID="TextBox_NAME" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td align="right">权限类型:</td><td>
                       <asp:DropDownList ID="DropDownList_roles" runat="server" AutoPostBack="True" 
                           onselectedindexchanged="DropDownList_roles_SelectedIndexChanged">
                          <asp:ListItem Selected="True">页面权限</asp:ListItem>
                                        <asp:ListItem>按钮权限</asp:ListItem>
                                        <asp:ListItem>菜单权限</asp:ListItem>
                                        </asp:DropDownList>
                   </td>
                   </tr>
                            <tr runat="server" id="upid" visible="false">
                   <td align="right">上级权限:</td><td>
                       <asp:DropDownList ID="DropDownList_upid" runat="server">
                       </asp:DropDownList>
                   </td>
                   </tr>
                    <tr>
                   <td align="right">权限路径:</td><td><asp:TextBox ID="TextBox_roles" CssClass="textbox_name" Width="450" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td></td>
                   <td align="left"> <asp:Button ID="Button_sumbit" runat="server" 
                    Text=" 确定 "   CssClass="button1" onclick="Button_sumbit_Click" /> 
                     &nbsp; &nbsp; &nbsp; &nbsp;  
                       <asp:Button ID="Button_sumbit0" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button_sumbit0_Click"/></td>
                   </tr>
                   </table>
             </td>
             </tr>
             </table>
            
                 <%--    添加新的权限--%>
                    <%-- 编辑权限--%>
             <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#000000"  runat="server" id="Editrole" visible="false">
             <tr>
             <td bgcolor="#ffffff">
                    <table cellpadding="0" cellspacing="0" width="100%" height="140px">
                   <tr>
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;编辑权限</td>
              </tr>
                   <tr>
                   <td align="right">权限名称:</td><td><asp:TextBox ID="TextBox_NAME2" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td align="right">权限类型:</td><td>
                       <asp:DropDownList ID="DropDownList_roles2" runat="server" AutoPostBack="True" 
                           onselectedindexchanged="DropDownList_roles2_SelectedIndexChanged">
                          <asp:ListItem Selected="True">页面权限</asp:ListItem>
                                        <asp:ListItem>按钮权限</asp:ListItem>
                                        <asp:ListItem>菜单权限</asp:ListItem>
                                        </asp:DropDownList>
                   </td>
                   </tr>
                            <tr runat="server" id="Tr1" visible="false">
                   <td align="right">上级权限:</td><td>
                       <asp:DropDownList ID="DropDownList_upid2" runat="server">
                       </asp:DropDownList>
                   </td>
                   </tr>
                    <tr>
                   <td align="right">权限路径:</td><td><asp:TextBox ID="TextBox_roles2" CssClass="textbox_name" Width="450" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td></td>
                   <td align="left"> 
                       <asp:Button ID="Button1" runat="server" 
                    Text=" 修改 "   CssClass="button1" onclick="Button1_Click"/> 
                     &nbsp; &nbsp; &nbsp; &nbsp;  
                       <asp:Button ID="Button2" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button2_Click"/>
                       <asp:HiddenField ID="HiddenField_ID" runat="server" />
                       </td>
                   </tr>
                   </table>
             </td>
             </tr>
             </table>
            
                 <%--    编辑权限--%>
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top">
                           <asp:GridView ID="GridView1"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" CssClass="GridView1" >
                            <Columns>  
                                <asp:BoundField HeaderText="权限名称" DataField="NAME" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="权限类别" DataField="Types" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                       <asp:BoundField HeaderText="上级权限" DataField="upName" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="权限路径" DataField="Roles" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                       
                          <asp:TemplateField HeaderText="操作">
                           <ItemTemplate>
                            <asp:LinkButton ID="LinkButton_edit" CommandArgument='<%#Eval("ID") %>' 
                                   runat="server" onclick="LinkButton_edit_Click">编辑</asp:LinkButton>
                           </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                     
                    </Columns>
                   
                </asp:GridView>
                </td></tr></table>
                
                               </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table>
                <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
                                    
                        </td>
                    </tr></table>
                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
