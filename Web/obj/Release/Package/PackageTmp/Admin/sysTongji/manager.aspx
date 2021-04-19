<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manager.aspx.cs" Inherits="Dianda.Web.Admin.sysTongji.manager" %>

<%@ Register src="ascxModel/usermember.ascx" tagname="usermember" tagprefix="uc1" %>

<%@ Register src="ascxModel/documents.ascx" tagname="documents" tagprefix="uc2" %>

<%@ Register src="ascxModel/downloads.ascx" tagname="downloads" tagprefix="uc3" %>

<%@ Register src="ascxModel/projectTask.ascx" tagname="projectTask" tagprefix="uc4" %>

<%@ Register src="ascxModel/projectApply.ascx" tagname="projectApply" tagprefix="uc5" %>

<%@ Register src="ascxModel/cashApply.ascx" tagname="cashApply" tagprefix="uc6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0"  width="100%"  runat="server" id="maincontrol">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" bgcolor="#ffffff" height="400px" cellspacing="0" width="98%">
                    <tr>
                        <td  valign="top"  width="270" bgcolor="#f0f0f0"><br />
                              <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" 
                NodeIndent="10" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" 
                ExpandImageUrl="~/Admin/images/documentFolder/folder.gif" 
                NoExpandImageUrl="~/Admin/images/documentFolder/folder.gif">
                <ParentNodeStyle Font-Bold="False" Width="250px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <LeafNodeStyle HorizontalPadding="0px" Width="195px"></LeafNodeStyle>
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                    NodeSpacing="0px" VerticalPadding="2px" BorderColor="#CFEFFF" 
                    Width="250px" ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <RootNodeStyle HorizontalPadding="0px" Width="195px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif"></RootNodeStyle>
                <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" 
                    VerticalPadding="0px" BackColor="#B5B5B5" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
            </asp:TreeView>
            
                            <asp:TreeView ID="TreeView2" runat="server">
                            </asp:TreeView>
            
                        </td>
                        <td width="5"></td>
                        <td width="720" valign="top">
                        <table width="100%">
                            <tr>
                                <td style="padding-left:500px" align="center">
                                    <asp:LinkButton ID="LinkButton1_cancel" runat="server" CssClass="button3d" onclick="LinkButton_cancel_Click">返回项目管理</asp:LinkButton></td>
                            </tr>
                            <tr>
                                <td style="width:100%;">
                                <div><uc1:usermember ID="usermember1" runat="server" Visible="false"/>
                                </div>
                                <div><uc4:projectTask ID="projectTask1" runat="server" />
                                </div>
                                <div>
                                    <uc5:projectApply ID="projectApply1" Visible="false" runat="server" />
                                </div>
                                <div><uc6:cashApply ID="cashApply1" runat="server" Visible="false"/>
                                </div>
                                </td>
                            </tr>
                        </table>
                        </td>
                         <td width="3"></td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
     <table align="center" cellpadding="0" cellspacing="0" width="100%"  height="400px" runat="server" id="docmain" visible="false">
        <tr>
            <td valign="top">
                <uc2:documents ID="documents1" runat="server" />
            </td>
        </tr>
        </table>
          <table align="center" cellpadding="0" cellspacing="0" width="100%"  height="400px" runat="server" id="downloadcmain" visible="false">
        <tr>
            <td valign="top">
                <uc3:downloads ID="downloads1" runat="server" />
               </td>
        </tr>
        </table><br />
</asp:Content>
