<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectInfo.manage" %>
<%@ Register src="~/Admin/SystemProjectManage/ProjectInfo/proleftmenu.ascx" tagname="proleftmenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="../../js/showTexts.js" type="text/javascript"></script>
<script type="text/javascript">
    window.onload = function() { enableTooltips(); }; 
</script> 
 <link href="../../css/textShow.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>
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
     <table cellpadding="0" cellspacing="0" width="100%" bgcolor="#ffffff" height="350" runat="server" id="noProject" visible="true">
    <tr>
    <td align=center>
    请从左边菜单选择您要管理的模块
    </td>
    </tr>
    </table>
    <div runat="server" id="showProject"  visible="false">
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
                                    <table class="tab1" cellpadding="0" cellspacing="0"><tr><td class="tab1_td1">&nbsp;</td><td class="tab1_td2">项目信息
                                    </td></tr></table>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td valign="top">
                                    <table class="tab3"><tr><td valign="top"><table class="tab4"><tr><td valign="top">
                                    <table class="tab5"><tr><td valign="top">
                                    
                                    <table class="tab2">
                                    <tr>
                                    <td></td>
                                    <td style=" padding-left:600px" valign="top" align="right">
                                    <table><tr>
                                    <td><asp:Button ID="Button_modify" runat="server" Text="编辑"  CssClass="button3a"  OnClick="Button_modify_onclick" /></td>
                                    
                                    <td><asp:Button ID="Button_delete" Visible="false" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"  CssClass="button3a" OnClick="Button_delete_onclick" /></td>
                                    <td><asp:Button ID="Button_projectsearch" runat="server" Text="项目搜索"  CssClass="button3b" OnClick="Button_projectsearch_onclick" /></td>
                                    </tr>
                                    
                                   </table></td></tr>
                                   <tr><td colspan = "2" align="center" valign="top"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                   <div id="search" runat="server" visible="false">
                            <tr><td colspan = "2" align="left" >
                                <table border="0" cellpadding="0" cellspacing="1" width="100%" bgcolor="#999999"><tr><td >
                                    <table border="0" cellpadding="0" cellspacing="1" width="100%" bgcolor="#ffffff" >
                                        <tr><td align="center">项目名称：</td>
                                            <td><asp:TextBox ID="TB_name" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;负责人：&nbsp;<asp:TextBox ID="TB_leader" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;参与部门：&nbsp;<asp:TextBox ID="TB_depart" runat="server"></asp:TextBox></td>
                                        </tr>
                                       <%-- <tr><td align="center"></td>
                                            <td colspan="5">
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                            <td width="125"><ASP:RequiredFieldValidator id="Validator1" Runat="Server"
                                                                ControlToValidate="TB_name" ValidationGroup="reach1"
                                                                ErrorMessage="项目名称不能为空!"
                                                                Display="Dynamic"/><ASP:RegularExpressionValidator id="RegularExpressionValidator2" RunAt="Server"
                                                                ControlToValidate="TB_name" ValidationGroup="reach1"
                                                                ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                errorMessage="项目名称在2~25字符且不含特殊字符!"
                                                                display="Dynamic" /></td>
                                            <td></td> 
                                            </tr>
                                            </table>
                                            </td>
                                        </tr>--%>
                                        <tr><td colspan="2" height="1px"></td></tr>
                                        <tr><td align="center">时间范围：</td>
                                            <td><input  class="Inputtext"  id="TB_starttime" runat="server" Width="200" type="text" readonly="readonly" onClick="ShowCalendar(this);" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input  class="Inputtext"  id="TB_endtime" runat="server" Width="200" type="text" readonly="readonly" onClick="ShowCalendar(this);" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_search" runat="server" Text=" 搜索 " ValidationGroup="reach1" CssClass="button1"  OnClick="Button_search_onclick"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_close" runat="server" Text=" 关闭 "  CssClass="button1" OnClick="Button_close_onclick" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_viewall" runat="server" Text="返回全部"  CssClass="button1_1" OnClick="Button_viewall_onclick" /><asp:HiddenField ID="HF_search" runat="server"/>
                                            </td>
                                        </tr>
                                        <tr><td align="center"></td>
                                            <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                            <td width="125"><ASP:CompareValidator ID="RequiredFieldValidator9"
                                                                ControlToValidate="TB_EndTime" ValidationGroup="reach1"
                                                                ControlToCompare="TB_StartTime"
                                                                Display="Dynamic"
                                                                Text="结束时间不能早于起始时间!"
                                                                Operator="GreaterThan"
                                                                Type="Date"
                                                                Runat="Server" /></td>
                                            <td></td> 
                                            </tr>
                                            </table>
                                            </td>
                                        </tr>

                                 <tr><td colspan="2" height="1px"></td></tr>
                                    </table>
                                    
                                
                                </td></tr></table>
                            </td></tr>
</div>
                                   </table>
                    
                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">

                    <tr >
                        <td valign="middle" align="center">
                          <asp:GridView ID="GridView1"  AutoGenerateColumns="False"     
OnRowDataBound="GridView1_RowDataBound"  runat="server" CellPadding="0" CssClass="GridView1" Width="100%" >
                            <Columns>
                            
                              <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox_choose_CheckedChanged" Text=""  />全选
                                    </HeaderTemplate>
                                        <ItemTemplate>
                                    <asp:CheckBox 
                                                ID="CheckBox_choose" runat="server" 
                                             /><asp:HiddenField ID="Hid_ID" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="50" />
                                    </asp:TemplateField>
                                                  
                        <asp:BoundField HeaderText="项目名称" DataField="NAMES" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"    Width="120"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="项目创建人" DataField="" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
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
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                                <asp:TemplateField HeaderText="参与部门">
                                    <ItemTemplate>
                                   <a href="#" title="任务描述：<%#Eval("DepartmentNames").ToString()%>">参与详情</a>
                                    </ItemTemplate>
                                       <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="center" CssClass="ItemStyle1"  />
                                </asp:TemplateField>
                        
                    <%--    <asp:BoundField HeaderText="参与部门" DataField="DepartmentNames" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        --%>
                        
                        <asp:BoundField HeaderText="项目资金卡" >
                            <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                            <ItemStyle HorizontalAlign="center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="起/始日期" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="80" />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="创建日期" DataField="DATETIME" DataFormatString="{0:yyyy-MM-dd}" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="80" />
                        </asp:BoundField>
                        
                        <%--<asp:BoundField HeaderText="项目资金卡" DataField="CardName" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="80" />
                        </asp:BoundField>--%>
                        
                        <asp:BoundField HeaderText="项目状态" DataField="" >
                              <HeaderStyle HorizontalAlign="Center"  CssClass="HeaderStyle1" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="80"  />
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
    </table></div>
                       </td>
                       <td width="5"></td>
            </tr>
        </table>
        </ContentTemplate>
         </asp:UpdatePanel>
         <script type="text/javascript">
 function funOpen(s)
{
    var Url = s.Url;
    window.showModalDialog(Url,"","dialogHeight=350px;dialogWidth=750px;location:no;menubar:no;toolbar:no;status:no;scroll:yes;")
             }
</script>
</asp:Content>
