<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectCheck.manage" %>
<%@ Register src="~/Admin/SystemProjectManage/ProjectInfo/proleftmenu.ascx" tagname="proleftmenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script src="../../js/showTexts.js" type="text/javascript"></script>
<script type="text/javascript">
    window.onload = function() { enableTooltips() }; 
</script> 
 <link href="../../css/textShow.css" rel="stylesheet" type="text/css" />
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<table cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
            <tr>
            <td width="10"></td>
                <td valign="top" width="115" align="left">
                     <uc1:proleftmenu ID="proleftmenu" runat="server" />
                </td>
                <td width="5"></td>
                <td valign="top">
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
                                    <table class="tab1" cellpadding="0" cellspacing="0"><tr><td class="tab1_td1">&nbsp;</td><td class="tab1_td2">立项审核</td></tr></table>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                    <table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td valign="top">
                                    
                                    <table class="tab2">
                                    <tr>
                                    <td align="right">分类筛选：</td>
                                     <td>
                                         <asp:DropDownList ID="DDL_Status" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_Status_Changed">
                                            <%--<asp:ListItem Value="">全部</asp:ListItem>--%>
                                            <asp:ListItem Value="0" Selected="True">待审核</asp:ListItem>
                                            <asp:ListItem Value="2">审核不通过</asp:ListItem>
                                            <asp:ListItem Value="9">移交审核</asp:ListItem>
                                         </asp:DropDownList>
                                     </td>
                                    <td style=" padding-left:560px">
                                    <table><tr>
                                    <td><asp:Button ID="Button_check" runat="server" Text="审批"  CssClass="button3a" OnClick="Button_check_onclick" /></td>
                                    </tr>
                                    
                                   </table></td></tr>
                                   <tr><td colspan = "4" align="center"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                   </table>
                    
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="middle" align="center">
                          <asp:GridView ID="GridView1"  AutoGenerateColumns="False"   
OnRowDataBound="GridView1_RowDataBound"  runat="server" CssClass="GridView1"  PageSize="10" Width="100%" >
                            <Columns>  
                            
                              <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                    <%--<asp:CheckBox ID="CheckBox_All" runat="server"  AutoPostBack="true" oncheckedchanged="CheckBox_choose_CheckedChanged" Text=""  />全选--%>
                                    选择
                                    </HeaderTemplate>
                                        <ItemTemplate>
                                    <asp:CheckBox 
                                                ID="CheckBox_choose" runat="server" 
                                             /><asp:HiddenField ID="Hid_ID" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="50" />
                                    </asp:TemplateField>
                                                  
                        <asp:BoundField HeaderText="项目名称" DataField="" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="120" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="项目创建人" DataField="" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="90" />
                        </asp:BoundField>
<%--                        <asp:TemplateField HeaderText="立项申请人">
                           <ItemTemplate>
                             <%#Eval("REALNAME").ToString()%>
                           </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:TemplateField>--%>
                        
                        <asp:BoundField HeaderText="项目负责人" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="90" />
                        </asp:BoundField>
                        
                        <asp:TemplateField HeaderText="参与部门">
                            <ItemTemplate>
                                <a href="#" title="任务描述：<%#Eval("DepartmentNames").ToString()%>">参与详情</a>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="center" CssClass="ItemStyle1"  />
                        </asp:TemplateField>
                        
                        <asp:BoundField HeaderText="项目资金卡" DataField="CardName" >
                            <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="80" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="起/始日期" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="80" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="立项时间" DataField="DATETIME" DataFormatString="{0:yyyy-MM-dd}" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="80"  />
                        </asp:BoundField>
                        
                        
                        <asp:BoundField HeaderText="项目状态" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="80"  />
                        </asp:BoundField>
                        
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
                                <tr height="7px"><td></td></tr>
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
            </td>
        </tr>
    </table>
                       </td>
                       <td width="5"></td>
            </tr>
        </table>
        </ContentTemplate>
         </asp:UpdatePanel>
</asp:Content>
