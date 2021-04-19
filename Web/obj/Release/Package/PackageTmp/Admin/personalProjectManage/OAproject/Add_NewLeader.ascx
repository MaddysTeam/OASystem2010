<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Add_NewLeader.ascx.cs"
    Inherits="Dianda.Web.Admin.personalProjectManage.OAproject.Add_NewLeader" %>
<div style="width: 100%; text-align: left">
    <br />
    <table width="400px" style="text-align: center; border: solid 1px #91BAB9" cellpadding="0"
        cellspacing="0">
        <tr>
            <td colspan="2" style="background-color: #99cccd; height: 25px">
                <table width="100%">
                    <tr>
                        <td>
                            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 创建新项目负责人
                        </td>
                        <td style="width: 30px">
                            <asp:LinkButton ID="LinkButton1" OnClick="Button2_Click" runat="server" Font-Size="12px"
                                ForeColor="#0066FF">收起</asp:LinkButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Label ID="tag" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 40%">
                用户名：
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox_UserName" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="TextBox_UserName"
                    ValidationGroup="new1" ErrorMessage="用户名不能为空!" Display="Dynamic" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="Server" ControlToValidate="TextBox_UserName"
                    ValidationGroup="new1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                    ErrorMessage="用户名在2~25字符且不含特殊字符!" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                密码：
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox_Pwd" runat="server" TextMode="Password"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TextBox_Pwd"
                    ValidationGroup="new1" ErrorMessage="密码不能为空!" Display="Dynamic" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="Server" ControlToValidate="TextBox_Pwd"
                    ValidationGroup="new1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                    ErrorMessage="密码在2~25字符!" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                真实姓名：
            </td>
            <td style="text-align: left">
                <asp:TextBox ID="TextBox_Rlname" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TextBox_Rlname"
                    ValidationGroup="new1" ErrorMessage="真实姓名不能为空!" Display="Dynamic" />
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TextBox_Rlname"
                    ValidationGroup="new1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                    ErrorMessage="真实姓名在2~25字符且不含特殊字符!" Display="Dynamic" />
            </td>
        </tr>
        <tr>
            <td style="text-align: right">
                性别：
            </td>
            <td style="text-align: left">
                <asp:RadioButtonList ID="RadioButtonList_Sex" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                    <asp:ListItem Value="女">女</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="Button1" runat="server" CssClass="button1" Text="确定" OnClick="Button1_Click"
                    ValidationGroup="new1" />
                <br />
                <br />
            </td>
        </tr>
    </table>
</div>
