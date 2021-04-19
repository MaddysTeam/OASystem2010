<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="fileslist.ascx.cs" Inherits="Dianda.Web.Admin.DocumentManage.fileslist" %>
  <%--  放置栏目自己和子目录的文件夹--%>
                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" 
                                                                runat="server" CellPadding="3" CssClass="GridView1">
                                                                <Columns>
                                                                       <asp:TemplateField HeaderText="标题">
                                                                        <ItemTemplate>
                                                                   <%#Eval("FolderName")%><asp:HiddenField ID="HiddenField_ID" runat="server" Value='<%#Eval("ID")%>'/>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="left" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                        <ItemTemplate>
                                                                            <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建时间">
                                                                        <ItemTemplate>
                                                                            <%#DateTime.Parse(Eval("DATETIME").ToString()).ToString("yyyy-MM-dd")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                  <asp:TemplateField HeaderText="路径">
                                                                <ItemTemplate>
                                                                    <%#Eval("PNAMES").ToString()%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="left" CssClass="HeaderStyle1" />
                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                            </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                            </asp:GridView>
                                                            <%--  放置栏目自己和子目录的文件夹--%>
                                                            <br />
                                                            <%--  放置栏目的下级子文件的列表--%>
                                                            <asp:HiddenField ID="HiddenField_FolderID" runat="server" />
                                                            <asp:GridView ID="GridView2" AutoGenerateColumns="False"  
                                                                runat="server" OnRowDataBound="GridView2_RowDataBound" CellPadding="3" CssClass="GridView1">
                                                                <Columns>
                                                                        <asp:TemplateField HeaderText="标题">
                                                                        <ItemTemplate>
                                                                            <%#Eval("FileName")%><asp:HiddenField ID="HiddenField_ID" runat="server" Value='<%#Eval("ID")%>'/>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1"   Width="200"/>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="类别">
                                                                        <ItemTemplate>
                                                                        
                                                                            <img alt="<%#Eval("FileType")%>" width="16" height="17" src=" /Admin/images/documentFolder/<%#Eval("FileType")%>.gif"/>  
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="大小">
                                                                        <ItemTemplate>
                                                                            <%#Eval("Sizeof")%>K
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="状态">
                                                                        <ItemTemplate>
                                                                            <%#Eval("IsShare").ToString() == "0" ? "正常" : "<font color='red'>共享</font>"%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建时间">
                                                                        <ItemTemplate>
                                                                            <%#Eval("DATETIME")%>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                    </asp:TemplateField>
                                                                      <asp:TemplateField HeaderText="路径">
                                                                <ItemTemplate>
                                                                    <%#Eval("PNAMES").ToString()%>
                                                                </ItemTemplate>
                                                                <HeaderStyle HorizontalAlign="left" CssClass="HeaderStyle1" />
                                                                <ItemStyle HorizontalAlign="left" CssClass="ItemStyle1"   Width="300"/>
                                                            </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                            </asp:GridView>