<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="modify.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectInfo.modify" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <br />
            <table align="center" cellpadding="0" cellspacing="0" width="90%" class="tab_height2">
                <tr>
                    <td valign="top">
                        <table class="tab3">
                            <tr>
                                <td>
                                    <table class="tab4">
                                        <tr>
                                            <td>
                                                <table class="tab5">
                                                    <tr>
                                                        <td>
                                                            <table align="center" cellpadding="0" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td align="center">
                                                                        <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                                    </td>
                                                                </tr>
                                                                <tr id="addproject" runat="server">
                                                                    <td>
                                                                        <table align="center" cellpadding="0" cellspacing="0" width="90%">
<tr>
                                                                        <td>
                                                                            <span class="ffont">��Ŀ���ͣ�</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="RL_ProjectType" runat="server" RepeatColumns="2"  AutoPostBack="true">
                                                                                <asp:ListItem Value="1" Selected="True">������Ŀ</asp:ListItem>
                                                                                <asp:ListItem Value="0">����/��ʱ��Ŀ</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                                                                                                                                                            <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">�����滯/����Ŀ��</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DDL_COLUMN" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_COLUMN_Changed">
                                                                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                                                                            <asp:Label ID="LB_COLUMNINFO" runat="server" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                                                                                        <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <div runat="server" id="div_CheckUserID">
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">��Ŀ�����ˣ�</span>
                                                                        </td>
                                                                        <td>
                                                                           <asp:DropDownList ID="DDL_CheckUserID" runat="server" >
                                                                            </asp:DropDownList>&nbsp;&nbsp;&nbsp;<asp:Label ID="LB_CheckUserInfo" runat="server" ForeColor="red"  Text="û�������˲����Խ�����Ŀ���룡"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    </div>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; ��Ŀ���ƣ�
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:TextBox ID="NAME" runat="server" Width="200"></asp:TextBox>
                                                                                    <font color="red">*</font></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="NAME"
                                                                                        ValidationGroup="add1" ErrorMessage="��Ŀ���Ʋ���Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                            ID="RegularExpressionValidator2" runat="Server" ControlToValidate="NAME" ValidationGroup="add1"
                                                                                            ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){1,25}$" ErrorMessage="��Ŀ������1~25�ַ��Ҳ��������ַ�!"
                                                                                            Display="Dynamic" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; ��Ŀ�����ˣ�
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:DropDownList ID="DDL_LeaderID" runat="server" OnSelectedIndexChanged="DDL_LeaderID_Changed"
                                                                                        AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                            
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; ��Ŀ״̬��
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:RadioButtonList ID="RadioButtonList_projectstatu" runat="server" RepeatColumns="5">
                                                                                    <asp:ListItem Value="1">����������</asp:ListItem>
                                                                                    <asp:ListItem Value="3">��ͣ</asp:ListItem>
                                                                                    <asp:ListItem Value="5">�����</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                            
                                                                            <tr style="display:none">
                                                                                <td>
                                                                                    &nbsp; ���벿�ţ�
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:CheckBoxList ID="CB_DepartmentID" runat="server" RepeatColumns="5">
                                                                                    </asp:CheckBoxList>
                                                                                    <asp:Label ID="Label_dep" runat="server" Text="û�пɲ���Ĳ���" Visible="false"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; Ԥ����ʼʱ�䣺
                                                                                </td>
                                                                                <td>
                                                                                    <input class="Inputtext" id="TB_StartTime" runat="server"  style="width:200px" type="text"
                                                                                        readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                <font color="red">*</font></td>
                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                            <td colspan="2" style="height: 10px;">&nbsp;&nbsp;</td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; Ԥ�ƽ���ʱ�䣺
                                                                                </td>
                                                                                <td>
                                                                                    <input class="Inputtext" id="TB_EndTime" runat="server" style="width:200px" type="text"
                                                                                        readonly="readonly" onclick="ShowCalendar(this);" />
                                                                                <font color="red">*</font></td>
                                                                                
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_StartTime"
                                                                                        ValidationGroup="add1" ErrorMessage="��ʼʱ�䲻��Ϊ��!" Display="Dynamic" /><asp:RequiredFieldValidator
                                                                                            ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_EndTime" ValidationGroup="add1"
                                                                                            ErrorMessage="����ʱ�䲻��Ϊ��!" Display="Dynamic" /><asp:CompareValidator ID="RequiredFieldValidator9"
                                                                                                ControlToValidate="TB_EndTime" ValidationGroup="add1" ControlToCompare="TB_StartTime"
                                                                                                Display="Dynamic" Text="����ʱ�䲻��������ʼʱ��!" Operator="GreaterThan" Type="Date" runat="Server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                             <div runat="server" id="div_CashTotal"  visible="false">
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; Ԥ�ƾ��ѣ�
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <%--<asp:TextBox ID="CashTotal" Width="200px" runat="server"></asp:TextBox>&nbsp;Ԫ--%>
                                                                                  <table border="0" cellpadding="0" cellspacing="0"><tr>
                                                                                    <td valign="top">
                                                                                       <asp:TextBox  MaxLength="9" ID="CashTotal" runat="server" Width="200"></asp:TextBox>&nbsp;
                                                                                    </td>
                                                                                    <td valign="middle">
                                                                                       <asp:RadioButtonList ID="RB_cashtotal" runat="server" RepeatColumns="2">
                                                                                         <asp:ListItem Value="1"  Selected="true">��Ԫ</asp:ListItem>
                                                                                         <asp:ListItem Value="0">Ԫ</asp:ListItem>
                                                                                        </asp:RadioButtonList>&nbsp;&nbsp;
                                                                                    </td>
                                                                                    </tr></table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="Server" ControlToValidate="CashTotal"
                                                                                        ValidationGroup="add1" ErrorMessage="����Ϊ��!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                                            ID="RegularExpressionValidator1" runat="Server" ControlToValidate="CashTotal"
                                                                                            ValidationGroup="add1" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"
                                                                                            ErrorMessage="���ֻ��Ϊ����!" Display="Dynamic" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 10px;">
                                                                                </td>
                                                                            </tr>
                                                                            </div>
                                                                            <tr>
                                                                                <td>
                                                                                    <span class="ffont">�ϴ�������</span>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 200px; height: 20px;" /><font
                                                                                        color="red">&nbsp;(*���ձ�ʾ���޸�ԭ�ļ���)</font><asp:HiddenField ID="HiddenField_oldpath" runat="server" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 8px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="LB_view" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                             <div runat="server" id="div_cash" visible="false">
                                                                            <tr>
                                                                                <td colspan="2" style="height: 8px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    &nbsp; �ʽ�ѡ��
                                                                                </td>
                                                                                <td colspan="3">
                                                                                    <asp:RadioButton ID="RB_CashCardID" runat="server" OnCheckedChanged="RB_CashCardID_CheckedChanged"
                                                                                        AutoPostBack="true" /><asp:DropDownList ID="DDL_CashCardID" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    <asp:RadioButton ID="RB_NewAddCashCard" runat="server" AutoPostBack="true" OnCheckedChanged="RB_NewAddCashCard_CheckedChanged"
                                                                                        Text="�½��ʽ�" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 5px;">
                                                                                </td>
                                                                            </tr>
                                                                            
                                                                                <tr style="background-color: #99cccd">
                                                                                    <td>
                                                                                        &nbsp; ��ʼ��
                                                                                    </td>
                                                                                    <td colspan="3">
                                                                                        <asp:TextBox ID="TB_LimitNums" Width="200px" runat="server"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="background-color: #99cccd">
                                                                                    <td style="height: 40px;">
                                                                                        &nbsp; �½���ע˵����
                                                                                    </td>
                                                                                    <td style="height: 40px;" colspan="3">
                                                                                        <asp:TextBox ID="TB_Notes" runat="server" TextMode="MultiLine" Height="100" Width="450"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </div>
                                                                            <tr>
                                                                                <td colspan="2" style="height: 5px;">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" style="height: 46px;">
                                                                                    &nbsp; ��Ŀ��Ҫ��
                                                                                </td>
                                                                                <td style="height: 46px" colspan="3">
                                                                                    <FCKeditorV2:FCKeditor ID="Overviews" runat="server" Width="580" Height="300">
                                                                                    </FCKeditorV2:FCKeditor>
                                                                                    <%--         <asp:TextBox ID="Overviews"  runat="server" CssClass="textbox_content" 
              TextMode="MultiLine"></asp:TextBox>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <caption>
                                                                                <br />
                                                                                <tr>
                                                                                    <td colspan="4" height="5">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="4">
                                                                                        <asp:Button ID="Button_applyfor" runat="server" CommandArgument="0" ValidationGroup="add1"
                                                                                            CssClass="button1" OnClick="Button_applyfor_Click" Text=" �޸� " />&nbsp;&nbsp;<asp:Button ID="Button_reset" runat="server" Text="����" CssClass="button1" OnClick="Button_reset_onclick" />
                                                                                    </td>
                                                                                </tr>
                                                                            </caption>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr height="20px">
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
<%--        </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
