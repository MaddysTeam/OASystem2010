<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="treelist.ascx.cs" Inherits="Dianda.Web.Admin.DocumentManage.treelist" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<br />
<table cellpadding="0" cellspacing="0" width="200px">
<tr>
<td width="5">&nbsp; </td>
    
<td valign="top">
<cc1:TabContainer ID="TabContainer_listtree" runat="server" ActiveTabIndex="0" 
        Width="210px" 
        onactivetabchanged="TabContainer_listtree_ActiveTabChanged" AutoPostBack="true">
    <cc1:TabPanel runat="server"  HeaderText="我的文档" ID="TabPanel_my">
        <ContentTemplate>
            <asp:TreeView ID="TreeView1"  runat="server" ImageSet="XPFileExplorer" 
                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" 
                ExpandImageUrl="~/Admin/images/documentFolder/folder.gif" 
                NoExpandImageUrl="~/Admin/images/documentFolder/folder.gif">
                <ParentNodeStyle Font-Bold="False" Width="195px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                <LeafNodeStyle HorizontalPadding="0px" Width="195px"></LeafNodeStyle>
                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                    NodeSpacing="0px" VerticalPadding="2px" BorderColor="#CFEFFF" 
                    Width="195px" ImageUrl="~/Admin/images/documentFolder/folder.gif" />
                <RootNodeStyle HorizontalPadding="0px" Width="195px" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif"></RootNodeStyle>
                <SelectedNodeStyle Font-Underline="False" HorizontalPadding="0px" 
                    VerticalPadding="0px" BackColor="#B5B5B5" 
                    ImageUrl="~/Admin/images/documentFolder/folder.gif" />
            </asp:TreeView>
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel_pj" runat="server" HeaderText="项目文档">
     <ContentTemplate>
            <asp:TreeView ID="TreeView2" runat="server" ImageSet="XPFileExplorer" 
                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged2" 
                ExpandImageUrl="~/Admin/images/documentFolder/folder.gif" 
                NoExpandImageUrl="~/Admin/images/documentFolder/folder.gif">
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
        </ContentTemplate>
    </cc1:TabPanel>
    <cc1:TabPanel ID="TabPanel_share" runat="server" HeaderText="共享文档">
      <ContentTemplate>
            <asp:TreeView ID="TreeView3" runat="server" ImageSet="XPFileExplorer" 
                NodeIndent="15" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged3" 
                ExpandImageUrl="~/Admin/images/documentFolder/folder.gif" 
                NoExpandImageUrl="~/Admin/images/documentFolder/folder.gif">
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
        </ContentTemplate>
    </cc1:TabPanel>
</cc1:TabContainer>
</td>
<td width="5">&nbsp; </td>
</tr>
</table>