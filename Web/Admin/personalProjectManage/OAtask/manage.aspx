<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAtask.manage" %>

<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" cellpadding="0" cellspacing="0" width="90%">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <uc1:projectControl ID="projectControl1" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="tab7">
                                                    <tr>
                                                        <td>
                                                            <table class="tab4">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table class="tab5">
                                                                            <tr>
                                                                                <td>
                                                                                    <table class="tab2">
                                                                                        <tr>
                                                                                            <td align="left">
                                                                                                &nbsp;&nbsp;任务状态:&nbsp;<asp:DropDownList ID="DDL_Status" runat="server" AutoPostBack="True"
                                                                                                    OnSelectedIndexChanged="DDL_Status_SelectedIndexChanged">
                                                                                                    <asp:ListItem Value="">全部</asp:ListItem>
                                                                                                    <asp:ListItem Value="0">待办</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">完成</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">暂停</asp:ListItem>
                                                                                                    <%--<asp:ListItem Value="1">进行中</asp:ListItem>--%>
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                            <td align="right">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:Button ID="Button_add" runat="server" Text="新建" CssClass="button3a" OnClick="Button_add_onclick" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Button ID="Button_modify" runat="server" Text="编辑" CssClass="button3a" OnClick="Button_modify_onclick" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Button ID="Button_delete" runat="server" Text="删除" OnClientClick="if(confirm('您确定要删除吗？')){return true;}else{return false;}"
                                                                                                                CssClass="button3a" OnClick="Button_delete_onclick" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:Button ID="Button_setfinish" runat="server" Text="完成" OnClientClick="if(confirm('您确定要设为完成吗？')){return true;}else{return false;}"
                                                                                                                CommandArgument="2" CssClass="button3a" OnClick="Button_setfinish_onclick" />
                                                                                                        </td>
                                                                                                        <%--<td><asp:Button ID="Button_setunderway" runat="server" Text="设为进行中"  OnClientClick="if(confirm('您确定要设为进行中吗？')){return true;}else{return false;}"  CommandArgument="1"  CssClass="button3c" OnClick="Button_setfinish_onclick"  /></td>--%>
                                                                                                        <td>
                                                                                                            <asp:Button ID="Button_setpostpone" runat="server" Text="暂停" OnClientClick="if(confirm('您确定要设为暂停吗？')){return true;}else{return false;}"
                                                                                                                CommandArgument="3" CssClass="button3a" OnClick="Button_setfinish_onclick" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" align="center">
                                                                                                <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                                <asp:HiddenField ID="HiddenField_userid" runat="server" /> <asp:HiddenField ID="HiddenField_userinfo" runat="server" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <table align="center" cellpadding="1" cellspacing="1" width="100%">
                                                                                        <tr>
                                                                                            <td valign="top">
                                                                                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" runat="server" Width="100%"
                                                                                                    OnRowDataBound="GridView1_RowDataBound" CssClass="GridView1">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="">
                                                                                                            <HeaderTemplate>
                                                                                                                <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                                                    Text="" />全选
                                                                                                            </HeaderTemplate>
                                                                                                            <ItemTemplate>
                                                                                                                <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                                    runat="server" />
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="50px" />
                                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" Width="50px" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="序号">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Label2" runat="server" Text='<%# (Container.DataItemIndex + 1) + (GridView1.PageSize)* (int.Parse(pageindexHidden.Value.ToString())-1)%>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle CssClass="HeaderStyle3" HorizontalAlign="Center" />
                                                                                                            <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="任务标题">
                                                                                                            <ItemTemplate>
                                                                                                                <span title="<%#Eval("Overviews").ToString()%>">
                                                                                                                    <%#Eval("NAMES").ToString()%></span>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:BoundField HeaderText="开始日期" DataField="StartTime" DataFormatString="{0:yyyy-MM-dd}">
                                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:BoundField HeaderText="结束日期" DataField="EndTime" DataFormatString="{0:yyyy-MM-dd}">
                                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:BoundField HeaderText="任务状态" DataField="Status">
                                                                                                            <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                                            <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                                        </asp:BoundField>
                                                                                                        <asp:TemplateField HeaderText="参与人员">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Label1" Style="cursor: hand" runat="server" ToolTip='<%# Bind("UserInfo") %>'
                                                                                                                    Text='<%# substing( Eval("UserInfo")) %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle CssClass="HeaderStyle3" HorizontalAlign="Center" />
                                                                                                            <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="相关操作">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:LinkButton ID="LinkButton_doc" runat="server" OnClick="LinkButton_doc_onclick"></asp:LinkButton>
                                                                                                            </ItemTemplate>
                                                                                                            <HeaderStyle CssClass="HeaderStyle3" HorizontalAlign="Center" />
                                                                                                            <ItemStyle CssClass="ItemStyle1" HorizontalAlign="Center" />
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
                                    <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                        <tr>
                                            <td align="right" bgcolor="#ffffff">
                                                <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                    ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr height="7px">
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    <%--下面是分页控件--%>
                                    <asp:HiddenField ID="pageindexHidden" runat="server" />
                                    <asp:HiddenField ID="H_NAME" runat="server" />
                                    
                                    
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20px">
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table class="tab6">
                                                    <tr>
                                                        <td align="center">
                                                            <img src="/Admin/images/OAimages/Separator_content.jpg">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>



                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="5">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
