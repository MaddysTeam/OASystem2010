<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="projectControl.ascx.cs" Inherits="Dianda.Web.Admin.projectControl" %>
<br />
<table cellpadding="0" cellspacing="0" width="100%">
<tr>
<td>
&nbsp;&nbsp;当前项目：&nbsp;<asp:DropDownList ID="DropDownList_myProject" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList_myProject_change">
</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label_statusname" CssClass="projectStatusBack"  runat="server" Text=""></asp:Label></td>
</tr>
<tr><td height="10"></td></tr>
</table>
<table cellpadding="0" cellspacing="0" width="100%"  align="center">
<tr>
<td align=center><asp:LinkButton ID="LinkButton_task" runat="server" 
        onclick="LinkButton_task_Click">项目任务</asp:LinkButton></td> 
        
        <td align=center>
    <asp:LinkButton ID="LinkButton_doc" runat="server" 
        onclick="LinkButton_doc_Click">项目文档</asp:LinkButton></td>
        
        <td align=center>
    <asp:LinkButton ID="LinkButton_apply" runat="server" 
        onclick="LinkButton_apply_Click">项目资源</asp:LinkButton></td>
        
        <td align=center>
    <asp:LinkButton ID="LinkButton_news" runat="server" 
        onclick="LinkButton_news_Click">项目消息</asp:LinkButton></td>
        
        <td align=center>
    <asp:LinkButton ID="LinkButton_fee" runat="server" 
        onclick="LinkButton_fee_Click">项目经费</asp:LinkButton></td>
        
        <td align=center>
    <asp:LinkButton ID="LinkButton_person" runat="server" 
        onclick="LinkButton_person_Click">项目成员</asp:LinkButton></td>
        </tr>
</table>
