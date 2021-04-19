
<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.manage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table align="center" cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
    <tr><td height="3px"></td></tr>
        <tr >
            <td valign="top">
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table  cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                    <table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td>
                                    
                                    <table class="tab2" border="0">
                                    <tr>
                                    <td>分类筛选：</td>
                                     <td>
                                         <asp:DropDownList ID="DDL_Status" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Status_Changed">
                                            <asp:ListItem Value="0">待审核</asp:ListItem>
                                            <asp:ListItem Value="1">审核通过</asp:ListItem>
                                            <asp:ListItem Value="2">审核不通过</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                    <td style="padding-left:680px;">
                                   <table>
                                      <tr>
                                        <td><asp:Button ID="Button_check" runat="server"  Text="审核"  CssClass="button3a" OnClick="Button_check_onclick" /></td>
<%--                                        <td><asp:Button ID="Button_checkfalse" runat="server" CommandArgument="false" Text="审核不通过"  CssClass="button3b" OnClick="Button_check_onclick" /></td>--%>
                                      </tr>
                                  </table>
                                   
                                   </td>
                                   </tr>
                                   <tr><td colspan = "4" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
                    
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="top" align="center">
                          <asp:GridView ID="GridView1"  AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"  runat="server" CssClass="GridView1"  PageSize="10">
                            <Columns>  
                            
                              <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox_All" runat="server"  AutoPostBack="true" oncheckedchanged="CheckBox_choose_CheckedChanged" Text=""  />全选
                                    </HeaderTemplate>
                                        <ItemTemplate>
                                    <asp:CheckBox 
                                                ID="CheckBox_choose" runat="server" 
                                             /><asp:HiddenField ID="Hid_ID" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                    </asp:TemplateField>
                                                  
                        
                        <asp:BoundField HeaderText="项目名称" DataField="NAMES" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="项目创建人" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="项目负责人" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="预算金额" DataField="CashTotal" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle3" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="预算表单">
                             <ItemTemplate>
                                 <asp:Label ID="LB_budget" runat="server" Text=""></asp:Label>
                             </ItemTemplate>
                             <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                             <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                       </asp:TemplateField>
                        
                    </Columns>
                   
                      <FooterStyle CssClass="FooterStyle1" />
                      <PagerStyle HorizontalAlign="Left"  CssClass="PagerStyle1" />
                      <SelectedRowStyle CssClass="SelectedRowStyle1" />
                   
                </asp:GridView>
                <%-- 记录当前是第几页--%>
                            <asp:HiddenField ID="HiddenField1" runat="server" />
                            <%-- 记录当前是第几页--%>
                            <%-- 记录信息集中总共有多少条记录--%>
                            <asp:HiddenField ID="dtrowsHidden" runat="server" />
                            <%-- 记录信息集中总共有多少条记录--%>
                            <%--下面是分页控件--%>
                            <table cellpadding="0" cellspacing="5" height="25" width="100%"   runat="server" id="pageControlShow">
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
                <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                </td></tr></table>
                
                               </td></tr></table></td></tr><tr height="20px"><td></td></tr></table></td></tr></table>
                <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
                                    
                        </td>
                    </tr></table>
                        </td>
                    </tr>
                </table>
            </td><td width="5"></td>
        </tr>
    </table>
    </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
