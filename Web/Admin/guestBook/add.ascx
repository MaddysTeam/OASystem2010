<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="add.ascx.cs" Inherits="Dianda.Web.Admin.guestBook.add1" %>
<table cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="right" width="230">
            您的姓名：
        </td>
        <td align="left">
            <asp:TextBox ID="TextBox1_Writer" CssClass="Inputtext" runat="server" Width="505px"
                MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1_Writer"
                Display="Dynamic" ErrorMessage="请输入您的姓名"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
            &nbsp;&nbsp;&nbsp;EMAIL：
        </td>
      <td align="left">
            <asp:TextBox ID="TextBox_email" CssClass="Inputtext" runat="server" Width="505px"
                MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox_email"
                Display="Dynamic" ErrorMessage="请输入您的EMAIL"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
            联系电话：
        </td>
       <td align="left">
            <asp:TextBox ID="TextBox_tel" CssClass="Inputtext" runat="server" Width="505px" MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox_tel"
                Display="Dynamic" ErrorMessage="请输入您的联系电话"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right">
            工作单位：
        </td>
      <td align="left">
            <asp:TextBox ID="TextBox_compan" CssClass="Inputtext" runat="server" Width="505px"
                MaxLength="100"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox_compan"
                Display="Dynamic" ErrorMessage="请输入您的工作单位"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td valign="top" align="right">
            留言内容：
        </td>
       <td align="left">
            <asp:TextBox ID="TextBox2_content" CssClass="Inputtext" runat="server" Height="140px"
                Width="505" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBox2_content"
                Display="Dynamic" ErrorMessage="请输入您的留言内容"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:CheckBox ID="CheckBox_issend" runat="server" Text="确定提交以上内容！" />&nbsp;&nbsp;<asp:Button
                ID="Button1_commit" runat="server" OnClick="Button1_Click" class="btn1_mouseout"
                onmouseover="this.className='btn1_mouseover'" onmouseout="this.className='btn1_mouseout'"
                Text="发表留言" OnClientClick="return confirm('您确定要提交以上留言吗?')" />
            &nbsp;&nbsp;
            <asp:Label ID="Label_notice" runat="server" Text="" CssClass="clst_red"></asp:Label>
            <br />
            <br />
        </td>
    </tr>
</table>
