<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="setRight.aspx.cs" Inherits="Dianda.Web.Admin.sysRights.setRight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate> <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
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
                                    <td>部门：<asp:DropDownList ID="DDL_Depart" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDL_Depart_SelectedIndexChanged"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;状态：<asp:DropDownList ID="DDL_Status" runat="server" OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></td>
                                    <td style=" padding-left:350px" align=right>
                                    <table><tr>
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_roleM" runat="server" OnClick="LinkButton_RoleM_Click" CssClass="button3b">权限管理</asp:LinkButton></td>
                                    
                                    <td width="74px" align="center"><asp:LinkButton ID="LinkButton_groupM" runat="server" OnClick="LinkButton_groupM_Click" CssClass="button3b">组管理</asp:LinkButton></td>
                                    
                                    </tr>
                                   </table></td></tr>
                                   <tr><td colspan = "4" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
                      <%--      添加新的权限--%>
             <table cellpadding="0" cellspacing="1" width="100%" bgcolor="#000000"  runat="server" id="addrole" visible="false">
             <tr>
             <td bgcolor="#ffffff">
                    <table cellpadding="0" cellspacing="0" width="100%" height="140px">
                   <tr>
                   <td colspan="2" bgcolor="#66ccff" height="20">&nbsp;&nbsp;配置用户所在组</td>
              </tr>
                   <tr>
                   <td align="right">用户:</td><td>
                       <asp:HiddenField ID="HiddenField_userid" runat="server" />
                       <asp:Label ID="Label_userinfo" runat="server" Text=""></asp:Label></td>
                   </tr>
                  <tr>
                   <td align="right" valign="top">组列表:</td><td>
                               
                      <asp:CheckBoxList ID="CheckBoxList_grouplist"  RepeatColumns="4" runat="server">
                      </asp:CheckBoxList>
                               
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
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top">
                           <asp:GridView ID="GridView1"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1" >
                            <Columns>  
                                <asp:BoundField HeaderText="用户名" DataField="USERNAME" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="姓名">
                           <ItemTemplate>
                          <%#Eval("REALNAME").ToString()%>
                           </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                        
                        <asp:BoundField HeaderText="性别" DataField="SEX" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                       <asp:BoundField HeaderText="所属部门" DataField="DepartMentName" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="350" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="工作岗位" DataField="StationName" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="联系电话" DataField="TEL" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="邮箱" DataField="EMAIL" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="特殊权限">
                           <ItemTemplate>
                                <asp:LinkButton ID="LinkButton_edit" CommandArgument='<%#Eval("ID") %>' 
                                   runat="server" onclick="LinkButton_edit_Click">配置</asp:LinkButton>
                           </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:TemplateField>
                     
                    </Columns>
                   
                </asp:GridView>
                <%-- 记录当前是第几页--%>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <%-- 记录当前是第几页--%>
                            <%-- 记录信息集中总共有多少条记录--%>
                            <asp:HiddenField ID="dtrowsHidden" runat="server" />
                            <%-- 记录信息集中总共有多少条记录--%>
                            <%--下面是分页控件--%>
                            <table cellpadding="0" cellspacing="0" height="25" width="100%"   runat="server" id="pageControlShow">
                                <tr height=7px><td></td></tr>
                                <tr>
                                    <td align="right" bgcolor="#ffffff">
                                        <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                        &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                            ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                        </asp:DropDownList>&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <%--下面是分页控件--%>
                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                            <asp:HiddenField ID="pageindexHidden" runat="server" /><asp:HiddenField ID="H_NAME" runat="server" />
                </td></tr></table>
                
                               </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table>
                <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
                                    
                        </td>
                    </tr></table>
 
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table></ContentTemplate></asp:UpdatePanel>
</asp:Content>
