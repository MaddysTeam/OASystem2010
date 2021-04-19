<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="groupM.aspx.cs" Inherits="Dianda.Web.Admin.sysRights.groupM" %>
<%@ Register src="rolemodel.ascx" tagname="rolemodel" tagprefix="uc1" %>
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
                                    <td>组类型：<asp:DropDownList ID="DDL_Depart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Depart_SelectedIndexChanged">
                                        <asp:ListItem Selected="True">岗位</asp:ListItem>
                                        <asp:ListItem>部门</asp:ListItem>
                                        <asp:ListItem>普通组</asp:ListItem>
                                        </asp:DropDownList></td>
                                    <td style=" padding-left:300px" align=right>
                                    <table><tr> 
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_add" runat="server" 
                                            CssClass="button3b" onclick="LinkButton_add_Click">添加组</asp:LinkButton></td>
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_roleM" runat="server" 
                                            CssClass="button3b" onclick="LinkButton_roleM_Click">配置用户</asp:LinkButton></td>
                                    
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_groupM" runat="server" OnClick="LinkButton_groupM_Click" CssClass="button3b">权限管理</asp:LinkButton></td>
                                    
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
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;添加组</td>
              </tr>
                   <tr>
                   <td align="right">组名称:</td><td><asp:TextBox ID="TextBox_NAME" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr><td colspan="2" height="2"></td></tr>
                  <%-- <tr>
                   <td align="right">组顺序:</td><td><asp:TextBox ID="TextBox_ISMOREN" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>--%>
                   <tr>
                   <td align="right">组类型:</td><td>
                       <asp:DropDownList ID="DropDownList_roles" runat="server">
                            <asp:ListItem Selected="True">普通组</asp:ListItem>
                                        </asp:DropDownList>
                   </td>
                   </tr>
                            <tr>
                   <td align="right" valign="top">权限列表:</td><td>
                                <uc1:rolemodel ID="rolemodel1" runat="server" />
                   </td>
                   </tr>
                   
                   <tr>
                   <td></td>
                   <td align="left"> <asp:Button ID="Button_sumbit" runat="server" 
                    Text=" 确定 "   CssClass="button1" onclick="Button_sumbit_Click" /> 
                     &nbsp; &nbsp; &nbsp; &nbsp;  
                       <asp:Button ID="Button_sumbit0" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button_sumbit0_Click"/>
                       </td>
                   </tr>
                   <tr>
                   <td colspan="2" height="10"></td>
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
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;编辑组</td>
              </tr>
                   <tr>
                   <td align="right">组名称:</td><td><asp:TextBox ID="TextBox_NAME2" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr><td colspan="2" height="2"></td></tr>
                   <tr  runat="server" id="shunxuhao">
                   <td align="right">组顺序:</td><td><asp:TextBox ID="TextBox_ISMOREN2" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox>
                     </td>
                   </tr> 
                    <tr>
                   <td align="right">删除</td>
                   <td align="left">   <asp:CheckBox
                           ID="CheckBox_del" runat="server" Text="删除该组" />
                   </td>
                   </tr>
                    <tr>
                   <td align="right"  valign="top">权限列表:</td><td>
                                <uc1:rolemodel ID="rolemodel2" runat="server" />
                   </td>
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
                    <tr>
                   <td colspan="2" height="10"></td>
                   </tr>
                   </table>
             </td>
             </tr>
             </table>
             <table cellpadding="0" cellspacing="0" width="100%" bgcolor="#66ccff" height="30"  align="center">
             <tr><td>
             &nbsp; &nbsp;岗位和部门的新建工作由人事统一操作，此处仅对普通组进行添加工作；同时岗位和部门的编辑工作也仅仅是对其权限进行操作！
             </td></tr>
             </table>
            
                 <%--    编辑权限--%>
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top">
                           <asp:GridView ID="GridView1"  OnRowDataBound="GridView1_RowDataBound"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" CssClass="GridView1" >
                            <Columns>  
                                <asp:BoundField HeaderText="组名" DataField="NAME" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="组类型" DataField="TAGS" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="组顺序/默认组" DataField="ISMOREN" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                     <%--  <asp:BoundField HeaderText="是否默认组" DataField="ISMOREN" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>--%>
                          <asp:TemplateField HeaderText="操作">
                           <ItemTemplate>
                            <asp:LinkButton ID="LinkButton_edit" CommandArgument='<%#Eval("ID") %>' 
                                   runat="server" onclick="LinkButton_edit_Click">编辑</asp:LinkButton>&nbsp;       
  <asp:LinkButton ID="LinkButton_ismoren" CommandArgument='<%#Eval("ID") %>'  runat="server" onclick="LinkButton_ismoren_Click">默认组</asp:LinkButton>
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
