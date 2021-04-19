<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="documents.ascx.cs" Inherits="Dianda.Web.Admin.sysTongji.ascxModel.documents" %>
 
  <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" height="400px" bgcolor="#ffffff" cellspacing="0" width="98%">
                    <tr>
                        <td  valign="top"  width="250" bgcolor="#f0f0f0"><br />
                             <asp:TreeView ID="TreeView2" runat="server" ImageSet="XPFileExplorer" 
                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged2" 
                ExpandImageUrl="~/Admin/images/documentFolder/folder.gif" 
                NoExpandImageUrl="~/Admin/images/documentFolder/folder.gif" ExpandDepth="2">
                <ParentNodeStyle Font-Bold="False" Width="220px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <LeafNodeStyle HorizontalPadding="0px" Width="220px"></LeafNodeStyle>
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                    NodeSpacing="0px" VerticalPadding="2px" BorderColor="#CFEFFF" 
                    Width="220px" ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <RootNodeStyle HorizontalPadding="0px" Width="220px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif"></RootNodeStyle>
                <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" 
                    VerticalPadding="0px" BackColor="#B5B5B5" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
            </asp:TreeView>
                            <asp:HiddenField ID="HiddenField_projectid" runat="server" />
                        </td>
                        <td width="5"></td>
                        <td width="750" valign="top" align=center>
                        <%--文档汇总信息--%> <br />
                       <table cellpadding="0" cellspacing="0" width="100%">
                       <tr>
                       <td width="600">&nbsp;</td>
                       <td align="center"><asp:LinkButton 
              ID="LinkButton1" runat="server" CssClass="button3c" onclick="LinkButton1_Click">返回主窗口</asp:LinkButton></td></tr>
                       </table><br />
                        <table cellpadding="10" cellspacing="1" bgcolor="99cccd"  width="100%">
                        <tr>
                        <td bgcolor="#f0f0f0" height="40px" align=left>
                            <asp:Label ID="Label_tongji" runat="server" Text=""></asp:Label>
                        </td>
                        </tr>
                        </table>
                        <br />
                         <%--文档汇总信息--%>
      <div><table cellpadding="0" cellspacing="0" width="100%">
      <tr> 
      <td width="600">&nbsp;</td>
      <td align="center"><asp:LinkButton ID="LinkButton_download" runat="server" OnClick="LinkButton_downs_Click" CssClass="button3c">归档所选</asp:LinkButton></td></tr>
      <tr>
        <td width="600" height="10">&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      </table></div>
                        <div>   <%--  放置栏目自己和子目录的文件夹--%>
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
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="20" />
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="标题">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="LinkButton_FOLDER" CommandArgument='<%#Eval("ID") %>' 
                                                                                runat="server" onclick="LinkButton_FOLDER_Click"></asp:LinkButton>  
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="类别">
                                                                        <ItemTemplate>
                                                                             <img alt="<%#Eval("Types").ToString()=="public" ? "项目文档目录":"个人文档目录"%>" width="16" height="17" src=" /Admin/images/documentFolder/<%#Eval("Types")%>.gif" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   Width="25"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建用户">
                                                                        <ItemTemplate>
                                                                            <%#Eval("REALNAME")%>(<%#Eval("USERNAME")%>)
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  Width="120"/>
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
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   Width="60"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                        <ItemTemplate>
                                                                            <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   Width="30"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建时间">
                                                                        <ItemTemplate>
                                                                            <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="70"/>
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
                                                            <asp:HiddenField ID="HiddenField_FolderID" runat="server" />
                                                          <%--  <table cellpadding="0" cellspacing="0" width="100%"  runat="server" id="showlistname" visible="false">
                                                            <tr><td align="left" bgcolor="#99cccd" height="25px">&nbsp;&nbsp;<asp:Label ID="Label_columnsname" runat="server" Text="" Font-Bold="true"></asp:Label></td></tr>
                                                            </table>--%>
                                                            <asp:GridView ID="GridView2" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound"
                                                                runat="server" CellPadding="3" CssClass="GridView1" Width="100%" 
                                                                ShowHeader="False">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="">
                                                                        <HeaderTemplate>
                                                                            <asp:CheckBox ID="CheckBox_All" runat="server" AutoPostBack="true"  OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                                Text="" />
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckBox_choose" runat="server" /><asp:HiddenField ID="Hid_ID"
                                                                                runat="server" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="20" />
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="标题">
                                                                        <ItemTemplate>
                                                                            <a href="<%#Eval("FilePath")%>" title="点击下载" target="_blank">
                                                                                <%#Eval("FileName")%></a>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                   
                                                                    <asp:TemplateField HeaderText="类别">
                                                                        <ItemTemplate>
                                                                            <img alt="<%#Eval("FileType")%>" width="16" height="17" src=" /Admin/images/documentFolder/<%#Eval("FileType")%>.gif" />
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="25"/>
                                                                    </asp:TemplateField>
                                                                       <asp:TemplateField HeaderText="创建用户">
                                                                        <ItemTemplate>
                                                                            <%#Eval("REALNAME")%>(<%#Eval("USERNAME")%>)
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  Width="120"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="大小">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Sizeof")%>K
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"  Width="60"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                        <ItemTemplate>
                                                                            <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   Width="30"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建时间">
                                                                        <ItemTemplate>
                                                                            <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"  Width="70"/>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                            </asp:GridView>
                            </div>
                      
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
      