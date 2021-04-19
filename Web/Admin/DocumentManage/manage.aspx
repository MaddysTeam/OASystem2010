<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manage.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.manage" %>

<%@ Register Src="treelist.ascx" TagName="treelist" TagPrefix="uc1" %>
<%@ Register Src="../projectControl.ascx" TagName="projectControl" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table cellpadding="0" cellspacing="0" width="90%" align="center" class="tab_height2">
        <tr>
            <td height="30px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc2:projectControl ID="projectControl1" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
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
                                                                        <td valign="top" width="210px">
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        
                                                                        <div id="id1" runat="server">
                                                                        项目文档状态：
                                                                           <asp:DropDownList ID="DropDownList_keys" OnSelectedIndexChanged="DropDownList_keys_SelectedIndexChanged" runat="server" AutoPostBack="True">
                                                                                                            <asp:ListItem Value="-1">-请选择状态-</asp:ListItem>
                                                                                                            <asp:ListItem Value="0">待审核</asp:ListItem>
                                                                                                            <asp:ListItem Value="1">正常运行中</asp:ListItem>
                                                                                                            <asp:ListItem Value="2">审核不通过</asp:ListItem>
                                                                                                            <asp:ListItem Value="3">暂停</asp:ListItem>
                                                                                                            <asp:ListItem Value="4">草稿箱中</asp:ListItem>
                                                                                                            <asp:ListItem Value="5">完成 </asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                            </div>
                                                                        
                                                                        
                                                                        
                                                                        
                                                                            <uc1:treelist ID="treelist1" runat="server" />
                                                                        </td>
                                                                        <td valign="top" align="center" width="700">
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <ContentTemplate>
                                                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                                                        <tr>
                                                                                            <td height="21px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right">
                                                                                                <asp:HiddenField ID="HiddenField_tp" runat="server" />
                                                                                                <asp:HiddenField ID="HiddenField_upid" runat="server" />
                                                                                                <asp:HiddenField ID="HiddenField_foldID" runat="server" />
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_addcolumns" runat="server" OnClick="LinkButton_addcolumns_Click"
                                                                                                                CssClass="button3b">新建目录</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_add" runat="server" OnClick="LinkButton_add_Click"
                                                                                                                CssClass="button3b">上传文件</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_download" runat="server" OnClick="LinkButton_downs_Click"
                                                                                                                CssClass="button3b">批量下载</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_modify" runat="server" OnClick="LinkButton_modify_Click"
                                                                                                                CssClass="button3a">编辑</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_DEL" runat="server" OnClientClick="if(confirm('您确定要删除所选项吗？删除目录时，会同时删除其子目录!(确定后，我们将列出本次操作所要删除的内容列表！)')){return true;}else{return false;}"
                                                                                                                OnClick="LinkButton_share_del_Click" CssClass="button3b">删除所选</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_transfer" runat="server" OnClick="LinkButton_transfer_Click"
                                                                                                                CssClass="button3a">收藏</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_share" runat="server" OnClick="LinkButton_share_Click"
                                                                                                                CssClass="button3a">共享</asp:LinkButton>
                                                                                                        </td>
                                                                                                        <td align="center">
                                                                                                            <asp:LinkButton ID="LinkButton_cancelshare" runat="server" OnClientClick="if(confirm('您确定要取消所选项的共享吗？')){return true;}else{return false;}"
                                                                                                                OnClick="LinkButton_share_cancel_Click" CssClass="button3b">取消共享</asp:LinkButton>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                    <%--  放置栏目自己和子目录的文件夹--%>
                                                                                    <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                        runat="server" CellPadding="3" CssClass="GridView1" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                                        Text="" />
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                        runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="20" />
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="标题">
                                                                                                <ItemTemplate>
                                                                                                    <a href="manage.aspx?CID=<%#Eval("COLUMNSPATH")%>&tp=<%=HiddenField_tp.Value.ToString() %>"
                                                                                                        target="_self">
                                                                                                        <%#Eval("FolderName")%></a>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="类别">
                                                                                                <ItemTemplate>
                                                                                                    <img alt="<%#Eval("Types").ToString()=="public" ? "项目文档目录":"个人文档目录"%>" width="16"
                                                                                                        height="17" src=" /Admin/images/documentFolder/<%#Eval("Types")%>.gif" />
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="25" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建用户">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("REALNAME")%>(<%#Eval("USERNAME")%>)
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="80" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="所属项目">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("ProjectName")%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="大小">
                                                                                                <ItemTemplate>
                                                                                                    &nbsp;
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="60" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="状态">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="30" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建时间">
                                                                                                <ItemTemplate>
                                                                                                    <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="70" />
                                                                                            </asp:TemplateField>
                                                                                            <%--    <asp:TemplateField HeaderText="路径">
                                                                <ItemTemplate>
                                                                    <%#Eval("PNAMES").ToString()%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                            </asp:TemplateField>--%>
                                                                                        </Columns>
                                                                                        <FooterStyle CssClass="FooterStyle1" />
                                                                                        <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                        <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                    </asp:GridView>
                                                                                    <%--  放置栏目自己和子目录的文件夹--%>
                                                                                    <%--  放置栏目的下级子文件的列表--%>
                                                                                    <asp:HiddenField ID="HiddenField_showhead" runat="server" />
                                                                                    <asp:HiddenField ID="HiddenField_FolderID" runat="server" />
                                                                                    <%--  <table cellpadding="0" cellspacing="0" width="100%"  runat="server" id="showlistname" visible="false">
                                                            <tr><td align="left" bgcolor="#99cccd" height="25px">&nbsp;&nbsp;<asp:Label ID="Label_columnsname" runat="server" Text="" Font-Bold="true"></asp:Label></td></tr>
                                                            </table>--%>
                                                                                    <asp:GridView ID="GridView2" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
                                                                                        runat="server" CellPadding="3" CssClass="GridView1" Width="100%" ShowHeader="False">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged2"
                                                                                                        Text="" />
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                        runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="20" />
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="标题">
                                                                                                <ItemTemplate>
                                                                                                    <a href="<%#Eval("FilePath")%>" title="点击下载" target="_blank">
                                                                                                        <%#Eval("FileName")%></a>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="类别">
                                                                                                <ItemTemplate>
                                                                                                    <img alt="<%#Eval("FileType")%>" width="16" height="17" src=" /Admin/images/documentFolder/<%#Eval("FileType")%>.gif" />
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="25" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建用户">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("REALNAME")%>(<%#Eval("USERNAME")%>)
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="80" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="大小">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("Sizeof")%>K
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="60" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="状态">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="30" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建时间">
                                                                                                <ItemTemplate>
                                                                                                    <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="70" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle CssClass="FooterStyle1" />
                                                                                        <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                        <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                    </asp:GridView>
                                                                                    <asp:GridView ID="GridView3" AutoGenerateColumns="False" OnRowDataBound="GridView3_RowDataBound"
                                                                                        runat="server" CellPadding="3" CssClass="GridView1" Width="100%">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="">
                                                                                                <HeaderTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true" OnCheckedChanged="CheckBox_choose_CheckedChanged3"
                                                                                                        Text="" />
                                                                                                </HeaderTemplate>
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                                        runat="server" />
                                                                                                </ItemTemplate>
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="20" />
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="标题">
                                                                                                <ItemTemplate>
                                                                                                    <a href="<%#Eval("FilePath")%>" title="点击下载" target="_blank">
                                                                                                        <%#Eval("FileName")%></a>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="类别">
                                                                                                <ItemTemplate>
                                                                                                    <img alt="<%#Eval("FileType")%>" width="16" height="17" src=" /Admin/images/documentFolder/<%#Eval("FileType")%>.gif" />
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="25" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建用户">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("REALNAME")%>(<%#Eval("USERNAME")%>)
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="80" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="大小">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("Sizeof")%>K
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" Width="60" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="上级目录">
                                                                                                <ItemTemplate>
                                                                                                    <%#Eval("PNAMES").ToString()%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="创建时间">
                                                                                                <ItemTemplate>
                                                                                                    <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                                <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" Width="70" />
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <FooterStyle CssClass="FooterStyle1" />
                                                                                        <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                        <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                                    </asp:GridView>
                                                                                    <%-- 记录当前是第几页--%>
                                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                                    <%-- 记录当前是第几页--%>
                                                                                    <%-- 记录信息集中总共有多少条记录--%>
                                                                                    <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                                    <%-- 记录信息集中总共有多少条记录--%>
                                                                                    <%--下面是分页控件--%>
                                                                                    <%--   <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                <tr>
                                                                    <td align="right" bgcolor="#99cccd">
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
                                                            </table>--%>
                                                                                    <%--下面是分页控件--%>
                                                                                    <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                                    <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                                    <asp:HiddenField ID="H_NAME" runat="server" />
                                                                                    <%--  放置栏目的下级子文件的列表--%>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
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
        <tr height="50px">
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
