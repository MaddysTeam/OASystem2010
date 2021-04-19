<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="modify.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAtask.modify" %>

<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" cellpadding="0" cellspacing="0" width="90%" height="397">
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
                                                        <td colspan="4" align="center">
                                                            <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            父任务：
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
                                                            子任务：
                                                        </td>
                                                        <td>
                                                            <table border="0" width="100%">
                                                            <tr>
                                                                
                                                                <td align="left"><asp:RadioButtonList ID="RadioButtonList_IsFather" runat="server" RepeatColumns="2">
                                                                          <asp:ListItem Value="1" >有</asp:ListItem>
                                                                          <asp:ListItem Value="0" >无</asp:ListItem>
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
                                                            上传文档：
                                                        </td>
                                                        <td>
                                                            <table border="0" width="100%">
                                                            <tr>
                                                                
                                                                <td align="left"><asp:RadioButtonList ID="RadioButtonList_doc" runat="server" RepeatColumns="2">
                                                                          <asp:ListItem Value="1" >是</asp:ListItem>
                                                                          <asp:ListItem Value="0" >否</asp:ListItem>
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
                                                            任务标题：
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="NAME" Width="200px" runat="server"></asp:TextBox><font color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="NAME"
                                                                ValidationGroup="add4" ErrorMessage="任务标题不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                    ID="RegularExpressionValidator2" runat="Server" ControlToValidate="NAME" ValidationGroup="add4"
                                                                    ValidationExpression=".{2,25}$" ErrorMessage="任务标题在2~25字符!"
                                                                    Display="Dynamic" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            开始时间：
                                                        </td>
                                                        <td>
                                                            <input class="Inputtext" style="width: 200px" id="TB_StartTime" runat="server" width="200"
                                                                type="text" readonly="readonly" onclick="ShowCalendar(this);" /><font color="red">*</font>&nbsp;&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            结束时间：
                                                        </td>
                                                        <td>
                                                            <input class="Inputtext" style="width: 200px" id="TB_EndTime" runat="server" width="200"
                                                                type="text" readonly="readonly" onclick="ShowCalendar(this);" /><font color="red">*</font>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                        </td>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="Server" ControlToValidate="TB_StartTime"
                                                                ValidationGroup="add4" ErrorMessage="开始时间不能为空!" Display="Dynamic" /><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_EndTime" ValidationGroup="add4"
                                                                    ErrorMessage="结束时间不能为空!" Display="Dynamic" /><asp:CompareValidator ID="RequiredFieldValidator9"
                                                                        ControlToValidate="TB_EndTime" ValidationGroup="add4" ControlToCompare="TB_StartTime"
                                                                        Display="Dynamic" Text="结束时间不能早于开始时间!" Operator="GreaterThan" Type="Date" runat="Server" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" valign="top">
                                                            参与成员：
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:CheckBox ID="CheckBox_choose" style="float:left" runat="server" Text="全部" OnCheckedChanged="CheckBox_choose_CheckedChanged"
                                                                AutoPostBack="true" />
                                                            <asp:CheckBoxList ID="CB_usersID" style="float:left" runat="server" RepeatColumns="4">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:Label ID="LB_notice" runat="server" Text="暂无可选择的参与人员" ForeColor="red" Visible="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 46px;" align="center">
                                                            任务描述：
                                                        </td>
                                                        <td style="height: 46px" colspan="3">
                                                            <asp:TextBox ID="Overviews" runat="server" CssClass="textbox_content" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            任务状态：
                                                        </td>
                                                        <td colspan="3">
                                                            <asp:RadioButtonList ID="RadioButtonList_status" runat="server" RepeatColumns="4">
                                                                <asp:ListItem Value="0">待办</asp:ListItem>
                                                                <%--<asp:ListItem Value="1">进行中</asp:ListItem>--%>
                                                                <asp:ListItem Value="2">完成</asp:ListItem>
                                                                <asp:ListItem Value="3">暂停</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <caption>
                                                        <br />
                                                        <tr>
                                                            <td align="center" colspan="4" style="padding-top: 10px;">
                                                                <asp:Button ID="Button_sumbit" runat="server" CommandArgument="0" CssClass="button1"
                                                                    OnClick="Button_sumbit_Click" Text=" 确定 " ValidationGroup="add4" />
                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_goback" runat="server"
                                                                    CssClass="button1" OnClick="Button_goback_Click" Text=" 返回 " />
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
