<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.manage" %>
<%@ Register src="../../projectControl.ascx" tagname="projectControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
    <tr><td height="3px"></td></tr>
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="90%" >
                    <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="0" width="100%">
                               <tr>
                                <td><uc1:projectControl ID="projectControl1" runat="server" /></td>
                               </tr>
                                <tr>
                                    <td>
                                    <table class="tab7"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td>
                                    
                                    <table class="tab2">
                                    <tr>
                                    <td>按类型筛选：<asp:DropDownList ID="DDL_type" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="DDL_type_Change">
                                    <asp:ListItem Value="orderSignet">用印</asp:ListItem>
                                    <asp:ListItem Value="orderCar">车辆</asp:ListItem>
                                    <asp:ListItem Value="orderFood">午餐</asp:ListItem>
                                    <asp:ListItem Value="orderRoom">会议室</asp:ListItem>
                                    </asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
                                        按状态筛选：<asp:DropDownList ID="DDL_status" runat="server" OnSelectedIndexChanged="DDL_status_Change" AutoPostBack = "true">
                                    <asp:ListItem Value="">全部</asp:ListItem>
                                    <asp:ListItem Value="0">待审批</asp:ListItem>
                                    <asp:ListItem Value="1">已审批</asp:ListItem>
                                    <asp:ListItem Value="2">已撤销</asp:ListItem>
                                    <asp:ListItem Value="3">已挂起</asp:ListItem>
                                    <asp:ListItem Value="4">已完成</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:HiddenField ID="HiddenField_senderid" runat="server" />
                                    </td>
                                    <td align="right">
                                    <table><tr>
                                    <td><asp:Button ID="Button_add" runat="server" Text="新建"  CssClass="button3a"  OnClick="Button_add_onclick"  /></td>
                                    <td><asp:Button ID="Button_revoke" runat="server" Text="撤销"  OnClientClick="if(confirm('您确定要撤销吗？')){return true;}else{return false;}" CssClass="button3a" OnClick="Button_revoke_onclick"/></td>
                                    
                                    </tr>
                                   </table></td></tr>
                                   <tr><td colspan = "7" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
                    
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top" align="center">
                           <asp:GridView ID="GridView1"  AutoGenerateColumns="false"  runat="server" Width="100%"  PageSize="10" OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1" >
                            <Columns>  
                              <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox_All" runat="server"  AutoPostBack="true" oncheckedchanged="CheckBox_choose_CheckedChanged"   Text=""  />全选
                                    </HeaderTemplate>
                                        <ItemTemplate>
                                    <asp:CheckBox 
                                                ID="CheckBox_choose" runat="server" 
                                             /><asp:HiddenField ID="Hid_ID" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    </asp:TemplateField>
                        
<%--                             <asp:BoundField HeaderText="申请类型" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>--%>
                             
<%--                                <asp:BoundField HeaderText="用途" DataField="Overviews" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>--%>
                                <asp:BoundField HeaderText="" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                
                               <asp:TemplateField HeaderText="备注">
                               <ItemTemplate>
                                 &nbsp;&nbsp;&nbsp;<span title="<%#Eval("Overviews").ToString()%>"><%#Eval("Overviews").ToString().Length > 30 ? Eval("Overviews").ToString().Substring(0, 30) + "..." : Eval("Overviews").ToString()%></span>
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1"  />
                                 <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  />
                            </asp:TemplateField>
<%--                            
                                <asp:BoundField HeaderText="申请时间" DataField="DATETIME" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="审批时间" DataField="ReadTime" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>--%>
                                <asp:BoundField HeaderText="状态" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                
                                <asp:BoundField HeaderText="附件" DataField="" >
                                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                </asp:BoundField>
                                     <asp:TemplateField HeaderText="申请人">
                               <ItemTemplate>
                                <%#Eval("REALNAME") %>(<%#Eval("USERNAME")%>)
                                 </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1"  />
                                 <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                            </asp:TemplateField>
                                
                            </Columns>
                   
                </asp:GridView>
                <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                
                             
 <%-- 记录当前是第几页--%>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <%-- 记录当前是第几页--%>
                            <%-- 记录信息集中总共有多少条记录--%>
                            <asp:HiddenField ID="dtrowsHidden" runat="server" />
                            <%-- 记录信息集中总共有多少条记录--%>
                            <%--下面是分页控件--%>
                            <table cellpadding="0" cellspacing="0" height="25" width="100%"   runat="server" id="pageControlShow">
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
                                <tr height=7px><td></td></tr>
                            </table>
                            <%--下面是分页控件--%>
                            
                            <asp:HiddenField ID="pageindexHidden" runat="server" /><asp:HiddenField ID="H_NAME" runat="server" />
                
                
                
                
                </td></tr></table>
                
                               </td></tr></table></td></tr><tr height="200px"><td></td></tr></table></td></tr></table>
                <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
                                    
                        </td>
                    </tr></table>
                     
                        </td>
                    </tr>
                </table>
            </td><td width="5"></td>
        </tr>
    </table>
<%--    </ContentTemplate>
    </asp:UpdatePanel>--%>
    
</asp:Content>
