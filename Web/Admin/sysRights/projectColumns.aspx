<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="projectColumns.aspx.cs" Inherits="Dianda.Web.Admin.sysRights.projectColumns" %>
<%@ Register src="../DocumentManage/shareForUser.ascx" tagname="shareForUser" tagprefix="uc1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
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
                                    <td></td>
                                    <td style=" padding-left:300px" align=right>
                                    <table><tr> 
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_add" runat="server" 
                                            CssClass="button3b" onclick="LinkButton_add_Click">添加</asp:LinkButton></td>
                                    <td width="114px" align="center">
                                        <asp:LinkButton ID="LinkButton1_cancel" runat="server" CssClass="button3d" 
                                            onclick="LinkButton1_cancel_Click">返回项目管理</asp:LinkButton>
                                   </td></tr>
                                   </table></td></tr>
                                   <tr><td colspan = "2" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
             <%--      添加新的权限--%>
             <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#000000"  runat="server" id="addrole" visible="false">
             <tr>
             <td bgcolor="#ffffff">
                    <table cellpadding="0" cellspacing="0" width="100%" height="140px">
                   <tr>
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;添加项目分类/规划</td>
              </tr>
                   <tr>
                   <td align="right">项目分类/规划名称:</td><td><asp:TextBox ID="TextBox_NAME" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td align="right">上级:</td><td>
                       <asp:DropDownList ID="DropDownList_roles" runat="server">
                                        </asp:DropDownList>
                   </td>
                   </tr>
                     <tr>
                   <td align="right">类型:</td><td>
                       <asp:DropDownList ID="DropDownList_TYPES" runat="server">
                                        <asp:ListItem>规划</asp:ListItem>
                                        <asp:ListItem>分类</asp:ListItem>
                                        </asp:DropDownList>
                   </td>
                   </tr>
                     <tr>
                   <td align="right" valign="top">描述内容:</td><td>
                     <FCKeditorV2:FCKeditor ID="FCKeditor_INFORS" runat="server" Width="580" Height="300">
                                                                                        </FCKeditorV2:FCKeditor>
                   </td>
                   </tr>
                   <tr>
                   <td colspan="2" align="center"><asp:Button ID="Button_sumbit" runat="server" 
                    Text=" 确定 "   CssClass="button1" onclick="Button_sumbit_Click" />　　<asp:Button ID="Button_sumbit0" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button_sumbit0_Click"/></td>
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
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;编辑项目分类/规划</td>
              </tr>
                   <tr>
                   <td align="right">项目分类/规划名称:</td><td><asp:TextBox ID="TextBox_NAME2" CssClass="textbox_name" Width="250" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                   <td align="right">上级:</td><td>
                       <asp:DropDownList ID="DropDownList_upids" runat="server">
                                        </asp:DropDownList>
                   </td>
                   </tr>
                        <tr>
                   <td align="right">类型:</td><td>
                       <asp:DropDownList ID="DropDownList_types2" runat="server">
                                        <asp:ListItem>规划</asp:ListItem>
                                        <asp:ListItem>分类</asp:ListItem>
                                        </asp:DropDownList>
                   </td>
                   </tr>
                     <tr>
                   <td align="right" valign="top">描述内容:</td><td>
                     <FCKeditorV2:FCKeditor ID="FCKeditor_infors2" runat="server" Width="580" Height="300">
                                                                                        </FCKeditorV2:FCKeditor>
                   </td>
                   </tr>
                   <tr>
                   <td colspan="2" align="center"><asp:Button ID="Button1" runat="server" 
                    Text=" 修改 "   CssClass="button1" onclick="Button1_Click"/>　　<asp:Button ID="Button2" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button2_Click"/>　　<asp:HiddenField ID="HiddenField_ID" runat="server" /></td>
                   </tr>
                    <tr>
                   <td colspan="2" height="10"></td>
                   </tr>
                   </table>
             </td>
             </tr>
             </table>
         
                 <%--    编辑权限--%>
                    <%-- 设置主持教师--%>
             <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#000000"  runat="server" id="Table_tearch" visible="false">
             <tr>
             <td bgcolor="#ffffff">
                    <table cellpadding="0" cellspacing="0" width="100%" height="140px">
                   <tr>
                   <td colspan="3" bgcolor="#66ccff" height="20">&nbsp;&nbsp;设置主持人员</td>
              </tr>
                   <tr>
                   <td align="right" height="30" width="80">名称:</td><td align="left" width="90%">
                       <asp:Label ID="Label_names" runat="server" Text=""></asp:Label></td>
                       <td></td>
                   </tr>
                   <tr>
                   <td align="right" height="30" width="80">路径:</td><td align="left" width="90%">
                       <asp:Label ID="Label_path" runat="server" Text=""></asp:Label>
                   </td>
                   <td></td>
                   </tr>
                   <tr>
                   <td colspan="3"><uc1:shareForUser ID="shareForUser1" runat="server" />
                       </td>
                   </tr>
                   <tr>
                   <td></td>
                   <td align="left"> 
                       <asp:Button ID="Button_columns" runat="server" 
                    Text=" 修改 "   CssClass="button1" onclick="Button_columns_Click"/> 
                     &nbsp; &nbsp; &nbsp; &nbsp;  
                       <asp:Button ID="Button4" runat="server" 
                    Text=" 取消 "   CssClass="button1" onclick="Button2_Click"/>
                       <asp:HiddenField ID="HiddenField1" runat="server" />
                       </td><td></td>
                   </tr>
                    <tr>
                   <td colspan="3" height="10"></td>
                   </tr>
                   </table>
             </td>
             </tr>
             </table>
         
                 <%--    设置主持教师--%>
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top">
                           <asp:GridView ID="GridView1"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" CssClass="GridView1" >
                            <Columns>  
                                <asp:BoundField HeaderText="项目分类/规划名称" DataField="NAMES" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="类型" DataField="TYPES" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  Width="40" />
                        </asp:BoundField>
                          <asp:BoundField HeaderText="主持" DataField="UserInfos" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="400"/>
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="操作">
                           <ItemTemplate>
                            <asp:LinkButton ID="LinkButton_edit" CommandArgument='<%#Eval("ID") %>' 
                                   runat="server" onclick="LinkButton_edit_Click">编辑</asp:LinkButton>
                                     <asp:LinkButton ID="LinkButton_tearch" CommandArgument='<%#Eval("ID") %>' 
                                   runat="server" onclick="LinkButton_editteach_Click">设置主持</asp:LinkButton>
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
