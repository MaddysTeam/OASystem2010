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
                                                    ��Ա��Ϣ���� >>�½���Ա
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
                                                                                        <asp:Label ID="notice1" runat="server" Text="������" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        �û�����
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_USERNAME" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        ���룺
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_PASSWORD" runat="server" Text=""></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        ��ʵ������
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
                                                                                            ValidationGroup="add1" ErrorMessage="�û�������Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator2" runat="Server" ControlToValidate="TB_USERNAME"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="�û�����2~25�ַ��Ҳ��������ַ�!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_PASSWORD"
                                                                                            ValidationGroup="add1" ErrorMessage="���벻��Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator3" runat="Server" ControlToValidate="TB_PASSWORD"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="������2~25�ַ�!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_REALNAME"
                                                                                            ValidationGroup="add1" ErrorMessage="��ʵ��������Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator4" runat="Server" ControlToValidate="TB_REALNAME"
                                                                                                ValidationGroup="add1" ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$"
                                                                                                ErrorMessage="��ʵ������2~25�ַ��Ҳ��������ַ�!" Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        �Ա�
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RadioButtonList_SEX" runat="server" RepeatColumns="2">
                                                                                                        <asp:ListItem Value="��" Selected="true">��</asp:ListItem>
                                                                                                        <asp:ListItem Value="Ů">Ů</asp:ListItem>
                                                                                                    </asp:RadioButtonList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td>
                                                                                        ���᣺
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_NativePlace" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        ���䣺
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
                                                                                            ValidationGroup="add1" ErrorMessage="���᲻��Ϊ��!" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="Server" ControlToValidate="TB_EMAIL"
                                                                                            ValidationGroup="add1" ErrorMessage="���䲻��Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator10" runat="Server" ControlToValidate="TB_EMAIL"
                                                                                                ValidationGroup="add1" ValidationExpression="^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                                                                                ErrorMessage="�����ʽ����ȷ!" Display="Dynamic" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        ѧ����
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_EducationLevel" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        ����״̬��
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="DDL_WorkStats" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        ������λ��
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
                                                                                        ��ϵ�绰��
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_TEL" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                   
                                                                                    <td>
                                                                                        ��Ŀ����
                                                                                    </td>
                                                                                    <td>
                                                                                        <table border="0" width="100%">
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <asp:RadioButtonList ID="RadioButtonList_IsManager" runat="server" RepeatColumns="2">
                                                                                                        <asp:ListItem Value="1">��</asp:ListItem>
                                                                                                        <asp:ListItem Value="0" Selected="true">��</asp:ListItem>
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
                                                                                            ValidationGroup="add1" ErrorMessage="�绰����Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                                ID="Validator_ID" runat="Server" ControlToValidate="TB_TEL" ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)"
                                                                                                ValidationGroup="add1" ErrorMessage="��ʽ����!(11λ�ֻ��Ż�XX-XX)" Display="Dynamic" />
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <%--<ASP:RequiredFieldValidator id="RequiredFieldValidator8" Runat="Server"
������ControlToValidate="TB_BIRTHDAY" ValidationGroup="add1"
������ErrorMessage="���ղ���Ϊ��!"
������Display="Dynamic"/>--%>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td  style="vertical-align:top;">
                                                                                        ���ţ�
                                                                                    </td>
                                                                                    <td colspan="5">                                                                                      
                                                                                        <asp:CheckBoxList ID="CheckBox_DEPARTMENT" Width="98%" runat="server" RepeatColumns="4" 
                                                                                            RepeatDirection="Horizontal">
                                                                                        </asp:CheckBoxList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #A5BBF1;">
                                                                                    <td colspan="6" align="left">
                                                                                        <asp:Label ID="notice2" runat="server" Text="�Ǳ�����" ForeColor="Red" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        סַ��
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_ADDRESS" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        ��ҵѧУ��
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_GraduateSchool" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        רҵ��
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="TB_Major" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        ���գ�
                                                                                    </td>
                                                                                    <td>
                                                                                        <input class="Inputtext" id="TB_BIRTHDAY" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                    <td>
                                                                                        ��ְʱ�䣺
                                                                                    </td>
                                                                                    <td>
                                                                                        <input class="Inputtext" id="TB_DatesEmployed" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                    <td>
                                                                                        ��ְʱ�䣺
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
                                                                                            ValidationGroup="add1" ControlToCompare="TB_BIRTHDAY" Display="Dynamic" Text="��ְʱ�䲻��С�ڳ�������!"
                                                                                            Operator="GreaterThan" Type="Date" runat="Server" />
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="TB_LeaveDates" ValidationGroup="add1"
                                                                                            ControlToCompare="TB_DatesEmployed" Display="Dynamic" Text="��ְʱ�䲻��С����ְʱ��!" Operator="GreaterThan"
                                                                                            Type="Date" runat="Server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                 <td>
                                                                                        �ƶ��绰��
                                                                                    </td>
                                                                                    <td>
                                                                                      <asp:TextBox ID="TextBox_TEMP1" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                    <td colspan="4"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        ����������
                                                                                    </td>
                                                                                    <td colspan="5">
                                                                                        <asp:TextBox ID="TB_TrackRecord" runat="server" Style="width: 635px;" Height="80px"
                                                                                            TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="6" align="center" style="padding-top: 10px">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add1" Text=" ȷ�� "
                                                                                            OnClick="Button_queding_Click" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                ID="Button_reset" runat="server" Text=" ���� " OnClick="Button_chongzhi_Click"
                                                                                                CssClass="button1" />
                                                                                        <input type="button" onclick="window.open('manage.aspx','_self');" value="����" name="����"
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
