<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAproject.manage" %>
<%@ Register src="~/Admin/personalProjectManage/OAproject/myproleftmenu.ascx" tagname="myproleftmenu" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
         <table cellpadding="0" cellspacing="0" width="100%" class="tab_height1">
            <tr>
            <td width="10"></td>
                <td valign="top" width="115" align="left">
                     <uc1:myproleftmenu ID="myproleftmenu" runat="server" />
                </td>
                <td width="5"></td>
                <td valign="top">
<table align="center" width="100%" class="tab_height1" cellpadding="0" cellspacing="0">
<tr>
<td valign="top">
<table align="center" cellpadding="0" cellspacing="0" width="98%">
<tr><td height="3px"></td></tr><tr>
    <%--<td>项目类型：<asp:DropDownList ID="DDL_ProjectType" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_ProjectType_Changed">
        <asp:ListItem Value="0">我负责的项目</asp:ListItem>
        <asp:ListItem Value="1">我参与的项目</asp:ListItem>
        <asp:ListItem Value="2">我创建的项目</asp:ListItem>
    </asp:DropDownList></td>
    <td width="560px"></td>--%>
<%--    <td>项目状态：<asp:DropDownList ID="DDL_ProjectStatus" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_ProjectStatus_Changed">
        <asp:ListItem Value="0">待审项目</asp:ListItem>
        <asp:ListItem Value="1">当前项目</asp:ListItem>
        <asp:ListItem Value="3">暂停项目</asp:ListItem>
        <asp:ListItem Value="5">完成项目</asp:ListItem>
        <asp:ListItem Value="2">不通过项目</asp:ListItem>
        <asp:ListItem Value="4">立项草稿箱</asp:ListItem>
    </asp:DropDownList></td>--%>
    <td>
      <table class="tab1" cellpadding="0" cellspacing="0"><tr><td class="tab1_td1">&nbsp;</td><td class="tab1_td2">
          <asp:Label ID="LB_title" runat="server" ></asp:Label></td></tr></table>
   </td>
    </tr></table>
</td></tr>
<tr>
    <td valign="top" align="center">
    <table cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
     <table class="tab3"><tr><td><table class="tab4"><tr><td valign="top">
                                    <table class="tab5">
                                    <tr><td align="right"><asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"  CssClass="button3a" OnClick="Button_delete_onclick" /></td></tr>
                                                                      <tr><td colspan = "2" align="center" valign="top"><asp:Label ID="tag" runat="server" Text="" CssClass="tag1" /></td></tr>
                                    <tr><td valign="top">
    <asp:GridView ID="GridView1"  AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"  runat="server" CellPadding="3" CssClass="GridView1">
                            <Columns>                   
<%--                                    <asp:TemplateField HeaderText="序号">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                         <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                        <ItemStyle HorizontalAlign="Center" Width="30"  CssClass="ItemStyle1"  />
                                    </asp:TemplateField>--%>
                                  <asp:TemplateField HeaderText="">
                                    <HeaderTemplate>
                                    <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" oncheckedchanged="CheckBox_choose_CheckedChanged" Text=""  /><asp:Label
                                        ID="LB_Choose" runat="server" Text="全选" Font-Bold="true"></asp:Label>
                                    </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="LB_index" runat="server" Text="<%# Container.DataItemIndex+1 %>" Visible="false"></asp:Label>
                                    <asp:CheckBox  ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" Width="50" />
                                    </asp:TemplateField>
                                    
<%--                        <asp:TemplateField HeaderText="项目名称">
                           <ItemTemplate>
                             <%#Eval("NAMES").ToString()%>
                             <asp:HiddenField ID="Hid_ID" runat="server" />
                           </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                            <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  />
                        </asp:TemplateField>--%>
                        <asp:BoundField HeaderText="项目名称" DataField="" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
                        <asp:BoundField HeaderText="负责人" DataField="LeaderRealName" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="状态" DataField="" >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        
<%--                       <asp:BoundField HeaderText="开始日期" DataField="StartTime" DataFormatString="{0:yyyy-MM-dd}">
                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                        </asp:BoundField>--%>
                        
                        <asp:TemplateField HeaderText="开始日期">
                               <ItemTemplate>
                                <%#Convert.ToDateTime(Eval("StartTime").ToString()).ToString("yyyy-MM-dd")%>
                               </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                       </asp:TemplateField>
                       <asp:TemplateField HeaderText="结束日期">
                               <ItemTemplate>
                                <%#Convert.ToDateTime(Eval("EndTime").ToString()).ToString("yyyy-MM-dd")%>
                               </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                       </asp:TemplateField>   
<%--                        <asp:BoundField HeaderText="结束日期" DataField="EndTime"  DataFormatString="{0:yyyy-MM-dd}">
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   />
                        </asp:BoundField>--%>
                        <asp:BoundField HeaderText="创建者" DataField="SendUserRealName"  >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="创建日期">
                               <ItemTemplate>
                                <%#Convert.ToDateTime(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                               </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                       </asp:TemplateField> 
                       <asp:BoundField HeaderText="项目详细" DataField=""  >
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>
<%--                        <asp:BoundField HeaderText="创建日期" DataField="DATETIME"  DataFormatString="{0:yyyy-MM-dd}">
                              <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle2" />
                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  />
                        </asp:BoundField>--%>
                       
                    </Columns>
                   
                               <FooterStyle CssClass="FooterStyle1" />
                               <PagerStyle HorizontalAlign="Left"  CssClass="PagerStyle1" />
                               <SelectedRowStyle CssClass="SelectedRowStyle1" />
                   
                </asp:GridView>
                <asp:Label ID="notice" runat="server" Text="" ForeColor="red"></asp:Label>
                </td></tr>
                </table></td></tr></table></td></tr></table>
                <table class="tab6"><tr><td align="center"><img src="/Admin/images/OAimages/Separator_content.jpg"></td></tr></table>
                </td></tr></table>
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
