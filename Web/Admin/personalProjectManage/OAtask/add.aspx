<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAtask.add" %>

<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" cellpadding="0" cellspacing="0" width="90%" bgcolor="#99cccd">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <uc1:projectControl ID="projectControl1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table class="tab7">
                            <tr>
                                <td>
                                    <table class="tab4">
                                        <tr>
                                            <td valign="top">
                                                <table class="tab5">
                                                    <tr>
                                                        <td colspan="2" align="center">
                                                            <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ������
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="DDL_UpID" runat="server" AutoPostBack = "true" OnSelectedIndexChanged="DDL_UpID_Change">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ������
                                                        </td>
                                                        <td>
                                                            <table border="0" width="100%">
                                                            <tr>
                                                                
                                                                <td align="left"><asp:RadioButtonList ID="RadioButtonList_IsFather" runat="server" RepeatColumns="2">
                                                                          <asp:ListItem Value="1" >��</asp:ListItem>
                                                                          <asp:ListItem Value="0" >��</asp:ListItem>
                                                                          </asp:RadioButtonList>
                                                                </td></tr>
                                                           </table>
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            �ϴ��ĵ���
                                                        </td>
                                                        <td>
                                                            <table border="0" width="100%">
                                                            <tr>
                                                                
                                                                <td align="left"><asp:RadioButtonList ID="RadioButtonList_doc" runat="server" RepeatColumns="2">
                                                                          <asp:ListItem Value="1" >��</asp:ListItem>
                                                                          <asp:ListItem Value="0" >��</asp:ListItem>
                                                                          </asp:RadioButtonList>
                                                                </td></tr>
                                                           </table>
                                                           </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ������⣺
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="NAME" Width="200px" runat="server"></asp:TextBox><font color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="NAME"
                                                                ValidationGroup="add4" ErrorMessage="������ⲻ��Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator2" runat="Server" ControlToValidate="NAME" ValidationGroup="add4"
                                                                    ValidationExpression=".{2,25}$" ErrorMessage="���������2~25�ַ�!"
                                                                    Display="Dynamic" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ��ʼʱ�䣺
                                                        </td>
                                                        <td style="width: 717px">
                                                            <input class="Inputtext" style="width: 200px" id="TB_StartTime" runat="server" width="200"
                                                                type="text" readonly="readonly" onclick="ShowCalendar(this);" /><font color="red">*</font>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="Server" ControlToValidate="TB_StartTime"
                                                                ValidationGroup="add4" ErrorMessage="��ʼʱ�䲻��Ϊ��!" Display="Dynamic" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ����ʱ�䣺
                                                        </td>
                                                        <td style="width: 717px">
                                                            <input class="Inputtext" style="width: 200px" id="TB_EndTime" runat="server" width="200"
                                                                type="text" readonly="readonly" onclick="ShowCalendar(this);" /><font color="red">*</font>
                                                                <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_EndTime" ValidationGroup="add4"
                                                                    ErrorMessage="����ʱ�䲻��Ϊ��!" Display="Dynamic" /><asp:CompareValidator ID="RequiredFieldValidator9"
                                                                        ControlToValidate="TB_EndTime" ValidationGroup="add4" ControlToCompare="TB_StartTime"
                                                                        Display="Dynamic" Text="����ʱ�䲻�����ڿ�ʼʱ��!" Operator="GreaterThan" Type="Date" runat="Server" />
                                                                
                                                        </td>
                                                    </tr>
                                                  <tr>
                                                    <td colspan="2" style="height:10px;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center"  valign="top">
                                                            �����Ա��
                                                        </td>
                                                        <td >
                                                            <asp:CheckBox ID="CheckBox_choose" style="float:left; line-height:20px;vertical-align:middle" Height="26px" runat="server" Text="ȫ��" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                AutoPostBack="true" />
                                                            <asp:CheckBoxList ID="CB_usersID" style="float:left"  runat="server" RepeatColumns="4">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LB_notice" runat="server" Text="���޿�ѡ��Ĳ�����Ա" ForeColor="red" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px;" align="center" valign="top">
                                                            ����������
                                                        </td>
                                                        <td style="height: 46px">
                                                            <asp:TextBox ID="Overviews" runat="server" CssClass="textbox_content" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            ����״̬��
                                                        </td>
                                                        <td>
                                                            <asp:RadioButtonList ID="RadioButtonList_status" runat="server" RepeatColumns="4">
                                                                <asp:ListItem Value="0">����</asp:ListItem>
                                                                <%--<asp:ListItem Value="1">������</asp:ListItem>--%>
                                                                <asp:ListItem Value="2">���</asp:ListItem>
                                                                <asp:ListItem Value="3">��ͣ</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        <br />
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <asp:Button ID="Button_sumbit" runat="server" CommandArgument="0" CssClass="button1"
                                                                    OnClick="Button_sumbit_Click" Text=" ȷ�� " ValidationGroup="add4" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_goback" runat="server"
                                                                    CssClass="button1" OnClick="Button_goback_Click" Text=" ���� " />
                                                            </td>
                                                        </tr>
                                                    </caption>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr height="50px">
                                            <td>
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
                    <td width="5">
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
