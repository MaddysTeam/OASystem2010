<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.userManager.OAusersmanage.add" %>

<%@ Register Src="~/Admin/OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <table cellpadding="0" cellspacing="0" width="100%" class="tab_height2">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu" runat="server" />
            </td>
            <td width="5">
            </td>
            <td valign="top">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td height="3px">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table align="center" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
                                        <table class="tab1" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tab1_td1">
                                                    &nbsp;
                                                </td>
                                                <td class="tab1_td2">
                                                    人员信息管理 >>新建人员
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="tab3">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table width="780" border="0" cellspacing="0" cellpadding="5">
                                                                                <tr>
                                                                                    <td colspan="6" align="center">
                                                                                        <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #A5BBF1;">
                                                                                    <td colspan="6" align="left">
                                                                                        <asp:Label ID="notice1" runat="server" Text="必填项" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        用户名：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_USERNAME" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        密码：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_PASSWORD" runat="server" Text=""></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        真实姓名：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_REALNAME" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="TB_USERNAME"
                                                                                            ValidationGroup="add1" ErrorMessage="用户名不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator2" runat="Server" ControlToValidate="TB_USERNAME"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="用户名在2~25字符且不含特殊字符!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_PASSWORD"
                                                                                            ValidationGroup="add1" ErrorMessage="密码不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator3" runat="Server" ControlToValidate="TB_PASSWORD"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="密码在2~25字符!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_REALNAME"
                                                                                            ValidationGroup="add1" ErrorMessage="真实姓名不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TB_REALNAME"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="真实姓名在2~25字符且不含特殊字符!" Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        性别：
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RadioButtonList_SEX" runat="server" RepeatColumns="2">
                                                                                                        <asp:ListItem Value="男" Selected="true">男</asp:ListItem>
                                                                                                        <asp:ListItem Value="女">女</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        籍贯：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_NativePlace" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        邮箱：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_EMAIL" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="Server" ControlToValidate="TB_NativePlace"
                                                                                            ValidationGroup="add1" ErrorMessage="籍贯不能为空!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="Server" ControlToValidate="TB_EMAIL"
                                                                                            ValidationGroup="add1" ErrorMessage="邮箱不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator10" runat="Server" ControlToValidate="TB_EMAIL"
                                                                                                ValidationGroup="add1" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                                                                                ErrorMessage="邮箱格式不正确!" Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        学历：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_EducationLevel" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        工作状态：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_WorkStats" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        工作岗位：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_Station" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        联系电话：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_TEL" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                   
                                                                                    <td>
                                                                                        项目经理：
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RadioButtonList_IsManager" runat="server" RepeatColumns="2">
                                                                                                        <asp:ListItem Value="1">是</asp:ListItem>
                                                                                                        <asp:ListItem Value="0" Selected="true">否</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="Server" ControlToValidate="TB_TEL"
                                                                                            ValidationGroup="add1" ErrorMessage="电话不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="Validator_ID" runat="Server" ControlToValidate="TB_TEL" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"
                                                                                                ValidationGroup="add1" ErrorMessage="格式错误!(11位手机号或XX-XX)" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <%--<ASP:RequiredFieldValidator id="RequiredFieldValidator8" Runat="Server"
　　　ControlToValidate="TB_BIRTHDAY" ValidationGroup="add1"
　　　ErrorMessage="生日不能为空!"
　　　Display="Dynamic"/>--%>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td  style="vertical-align:top;">
                                                                                        部门：
                                                                                    </td>
                                                                                    <td colspan="5">                                                                                      
                                                                                        <asp:CheckBoxList ID="CheckBox_DEPARTMENT" Width="98%" runat="server" RepeatColumns="4" 
                                                                                            RepeatDirection="Horizontal">
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #A5BBF1;">
                                                                                    <td colspan="6" align="left">
                                                                                        <asp:Label ID="notice2" runat="server" Text="非必填项" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        住址：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_ADDRESS" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        毕业学校：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_GraduateSchool" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        专业：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_Major" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        生日：
                                                                                    </td>
                                                                                    <td>
                                                                                        <input class="Inputtext" id="TB_BIRTHDAY" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                    <td>
                                                                                        入职时间：
                                                                                    </td>
                                                                                    <td>
                                                                                        <input class="Inputtext" id="TB_DatesEmployed" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                    <td>
                                                                                        离职时间：
                                                                                    </td>
                                                                                    <td>
                                                                                        <input class="Inputtext" id="TB_LeaveDates" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="TB_DatesEmployed"
                                                                                            ValidationGroup="add1" ControlToCompare="TB_BIRTHDAY" Display="Dynamic" Text="入职时间不能小于出生日期!"
                                                                                            Operator="GreaterThan" Type="Date" runat="Server" />
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="TB_LeaveDates" ValidationGroup="add1"
                                                                                            ControlToCompare="TB_DatesEmployed" Display="Dynamic" Text="离职时间不能小于入职时间!" Operator="GreaterThan"
                                                                                            Type="Date" runat="Server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                 <td>
                                                                                        移动电话：
                                                                                    </td>
                                                                                    <td>
                                                                                      <asp:TextBox ID="TextBox_TEMP1" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="4"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        工作履历：
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="TB_TrackRecord" runat="server" Style="width: 635px;" Height="80px"
                                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="6" align="center" style="padding-top: 10px">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add1" Text=" 确定 "
                                                                                            OnClick="Button_queding_Click" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                ID="Button_reset" runat="server" Text=" 重置 " OnClick="Button_chongzhi_Click"
                                                                                                CssClass="button1" />
                                                                                        <input type="button" onclick="window.open('manage.aspx','_self');" value="返回" name="返回"
                                                                                            class="button1" />
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
</asp:Content>
