<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAproject.add" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="~/Admin/personalProjectManage/OAproject/Add_NewLeader.ascx" TagName="Add_NewLeader"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <%--<asp:Button ID="Button_reset" runat="server" CssClass="button1" 
                                                                            OnClick="Button_reset_Click" Text=" 重置 " />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;--%>
    <table align="center" cellpadding="0" cellspacing="0" width="90%" class="tab_height2">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="tag" runat="server" ForeColor="Red" Text="" />
            </td>
        </tr>
        <tr id="addproject" runat="server">
            <td>
                <table align="center" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            <table class="tab3">
                                <tr>
                                    <td>
                                        <table class="tab4">
                                            <tr>
                                                <td valign="top">
                                                    <table class="tab5">
                                                        <tr>
                                                            <td align="right">
                                                                <asp:Button ID="Button_DraftBox" runat="server" OnClick="Button_DraftBox_Click" Text="立项草稿箱"
                                                                    CssClass="button4" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">项目类型：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="RL_ProjectType" runat="server" RepeatColumns="2" OnSelectedIndexChanged="RL_ProjectType_Change"
                                                                                AutoPostBack="true">
                                                                                <asp:ListItem Value="1" Selected="True">正常项目</asp:ListItem>
                                                                                <asp:ListItem Value="0">个人/临时项目</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">所属项目分类/规化：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DDL_COLUMN" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_COLUMN_Changed">
                                                                            </asp:DropDownList>
                                                                            &nbsp;&nbsp;&nbsp;
                                                                            <asp:Label ID="LB_COLUMNINFO" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <div runat="server" id="div_CheckUserID">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="ffont">项目审批人：</span>
                                                                            </td>
                                                                            <td>
                                                                                <asp:DropDownList ID="DDL_CheckUserID" runat="server">
                                                                                </asp:DropDownList>
                                                                                &nbsp;&nbsp;&nbsp;<asp:Label ID="LB_CheckUserInfo" runat="server" ForeColor="red"
                                                                                    Text="没有审批人不可以进行项目申请！"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 10px;">
                                                                            </td>
                                                                        </tr>
                                                                    </div>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">项目名称：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="NAME" runat="server" Width="200"></asp:TextBox><font color="red">*</font>
                                                                            <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="NAME"
                                                                                ValidationGroup="add1" ErrorMessage="项目名称不能为空!" Display="Dynamic" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">项目负责人：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:DropDownList ID="DDL_LeaderID" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_LeaderID_Changed">
                                                                            </asp:DropDownList>
                                                                            <asp:CheckBox ID="CheckBox_Newleader" runat="server" Text="新建项目负责人" AutoPostBack="True"
                                                                                OnCheckedChanged="CheckBox_Newleader_CheckedChanged" />
                                                                            <asp:Label ID="Label_NewLeader" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <uc1:Add_NewLeader ID="Add_NewLeader1" runat="server"></uc1:Add_NewLeader>
                                                                        </td>
                                                                    </tr>
                                                                    <tr style="display: none">
                                                                        <td>
                                                                            <span class="ffont">相关部门：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBoxList ID="CB_DepartmentID" runat="server" RepeatColumns="5">
                                                                            </asp:CheckBoxList>
                                                                            <asp:Label ID="Label_dep" runat="server" Text="没有可参与的部门" Visible="false"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">预计起始时间：</span>
                                                                        </td>
                                                                        <td>
                                                                            <input id="TB_StartTime" runat="server" class="Inputtext" onclick="ShowCalendar(this);"
                                                                                readonly="readonly" type="text" style="width: 200px" /><font color="red">*</font>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="Server" ControlToValidate="TB_StartTime"
                                                                                ValidationGroup="add1" ErrorMessage="起始时间不能为空!" Display="Dynamic" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">预计结束时间：</span>
                                                                        </td>
                                                                        <td>
                                                                            <input id="TB_EndTime" runat="server" class="Inputtext" onclick="ShowCalendar(this);"
                                                                                readonly="readonly" type="text" style="width: 200px" /><font color="red">*</font>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="Server" ControlToValidate="TB_EndTime"
                                                                                ValidationGroup="add1" ErrorMessage="结束时间不能为空!" Display="Dynamic" /><asp:CompareValidator
                                                                                    ID="RequiredFieldValidator9" ControlToValidate="TB_EndTime" ValidationGroup="add1"
                                                                                    ControlToCompare="TB_StartTime" Display="Dynamic" Text="结束时间不能早于起始时间!" Operator="GreaterThan"
                                                                                    Type="Date" runat="Server" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <div runat="server" id="div_CashTotal" visible="false">
                                                                        <tr>
                                                                            <td>
                                                                                <span class="ffont">预计经费：</span>
                                                                            </td>
                                                                            <td>
                                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <asp:TextBox MaxLength="9" ID="CashTotal" runat="server" Width="200"></asp:TextBox>&nbsp;
                                                                                        </td>
                                                                                        <td valign="middle">
                                                                                            <asp:RadioButtonList ID="RB_cashtotal" runat="server" RepeatColumns="2">
                                                                                                <asp:ListItem Value="1" Selected="True">万元</asp:ListItem>
                                                                                                <asp:ListItem Value="0">元</asp:ListItem>
                                                                                            </asp:RadioButtonList>
                                                                                            &nbsp;&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="Server" ControlToValidate="CashTotal"
                                                                        ValidationGroup="add1" ErrorMessage="金额不能为空!" Display="Dynamic" /><asp:RegularExpressionValidator
                                                                            ID="RegularExpressionValidator1" runat="Server" ControlToValidate="CashTotal"
                                                                            ValidationGroup="add1" ValidationExpression="^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$"
                                                                            ErrorMessage="金额只能为数字!" Display="Dynamic" />--%>
                                                                            </td>
                                                                        </tr>
                                                                    </div>
                                                                    <tr>
                                                                        <td>
                                                                            <span class="ffont">上传附件：</span>
                                                                        </td>
                                                                        <td>
                                                                            <asp:FileUpload ID="FileUpload1" runat="server" Style="width: 270px; height: 20px;" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px;">
                                                                        </td>
                                                                    </tr>
                                                                    <%--   根据2010-09-03的需求变更要求，将此注销              <tr>
                                                                <td>
                                                                    <span class="ffont">资金卡选择：</span>
                                                                </td>
                                                                <td colspan="3">
                                                                    <asp:RadioButton ID="RB_CashCardID" runat="server" AutoPostBack="true" 
                                                                        Checked="true" oncheckedchanged="RB_CashCardID_CheckedChanged" />
                                                                    <asp:DropDownList ID="DDL_CashCardID" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:RadioButton ID="RB_NewAddCashCard" runat="server" AutoPostBack="true" 
                                                                        oncheckedchanged="RB_NewAddCashCard_CheckedChanged" Text="新建资金卡" />
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr><td colspan="2" style="height:5px;"></td></tr>
                                                            
                                                            <div ID="div_cash" runat="server" visible="false">
                                                                <tr style="background-color:#99cccd;height:30px;">
                                                                    <td><span class="ffont">初始金额：</span></td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="TB_LimitNums" runat="server"></asp:TextBox>&nbsp;&nbsp;元
                                                                    </td>
                                                                </tr>
                                                                <tr style="background-color:#99cccd;height:110px;">
                                                                    <td valign="top" style="padding-top:10px"><span class="ffont">新建备注说明：</span></td>
                                                                    <td colspan="3">
                                                                        <asp:TextBox ID="TB_Notes" runat="server" Height="100" TextMode="MultiLine" 
                                                                            Width="450"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </div>
                                                            <tr><td colspan="2" style="height:5px;"></td></tr>--%>
                                                                    <tr>
                                                                        <td valign="top" style="height: 46px;">
                                                                            <span class="ffont">项目概要：</span>
                                                                        </td>
                                                                        <td style="height: 46px">
                                                                            <FCKeditorV2:FCKeditor ID="Overviews" runat="server" Height="300" Width="580">
                                                                            </FCKeditorV2:FCKeditor>
                                                                            <%--         <asp:TextBox ID="Overviews"  runat="server" CssClass="textbox_content" 
              TextMode="MultiLine"></asp:TextBox>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <caption>
                                                                        <tr>
                                                                            <td align="center" colspan="2" style="padding-top: 10px;">
                                                                                <asp:Button ID="Button_applyfor" runat="server" CommandArgument="0" ValidationGroup="add1"
                                                                                    CssClass="button1" OnClick="Button_applyfor_Click" Text=" 申请 " />
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;<%--<asp:Button ID="Button_reset" runat="server" CssClass="button1" 
                                                                            OnClick="Button_reset_Click" Text=" 重置 " />
                                                                        &nbsp;&nbsp;&nbsp;&nbsp;--%><asp:Button ID="Button_draft" runat="server" CommandArgument="4"
                                                                            ValidationGroup="add1" CssClass="button1_1" OnClick="Button_applyfor_Click" Text="保存为草稿" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                ID="Button_goback" runat="server" CssClass="button1" OnClick="Button_goback_Click"
                                                                                Text=" 返回 " />
                                                                            </td>
                                                                        </tr>
                                                                    </caption>
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
                                        <img src="/Admin/images/OAimages/Separator_content.jpg"></img>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--
       </ContentTemplate>
    </asp:UpdatePanel>--%>
    <br />
</asp:Content>
