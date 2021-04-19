<%@ Page Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="check.aspx.cs" Inherits="Dianda.Web.Admin.budgetManage.check" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellpadding="0" cellspacing="0" width="100%" class="tab_height2">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <table align="center" cellpadding="0" cellspacing="0" width="98%">
                            <tr>
                                <td>
                                    <table class="tab3">
                                        <tr>
                                            <td valign="top">
                                                <table class="tab4">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="tab5">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="7">
                                                                            <tr>
                                                                                <td colspan="3" align="center">
                                                                                    <asp:Label ID="tag" runat="server" Text="" ForeColor="Red" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="background-color: #A5BBF1;">
                                                                                <td colspan="3" align="left">
                                                                                    <asp:Label ID="notice1" runat="server" Text="基本信息" ForeColor="Red" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    项目名称：<asp:Label ID="Label_ProjectName" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    立项申请人：<asp:Label ID="Label_SendUserID" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    预算表单：<asp:Label ID="Label_budgetlist" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton
                                                                                        ID="LB_reuploadbudget" OnClientClick="javascript:window.showModalDialog('/Admin/personalProjectManage/OACashApply/uploadfilesups.aspx?role=manager','','dialogWidth=526px;dialogHeight=300px');"  runat="server" >重新上传</asp:LinkButton>
                                                                                </td>
                                                                                <td>
                                                                                    预计经费：<asp:Label ID="Label_CashTotal" runat="server" Text=""></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <%--  <tr><td colspan="2" style=" height:5px;">&nbsp;</td></tr>--%>
                                                                            <tr style="background-color: #A5BBF1;">
                                                                                <td colspan="3" align="left">
                                                                                    <asp:Label ID="notice2" runat="server" Text="审批信息" ForeColor="Red" /><asp:Label ID="LB_CheckNotice"
                                                                                        runat="server" Text="" ForeColor="red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <table border="0" width="100%">
                                                                                        <tr>
                                                                                            <td width="50%" valign="top">
                                                                                                <table border="0" width="100%">
                                                                                                    <tr>
                                                                                                        <td colspan="2">
                                                                                                            <table border="0">
                                                                                                                <tr valign="middle">
                                                                                                                    <td width="60px">
                                                                                                                        审批结果：
                                                                                                                    </td>
                                                                                                                    <td align="left" style="width: 170px;">
                                                                                                                        <asp:RadioButtonList ID="RadioButtonList_Check" runat="server" RepeatColumns="4"
                                                                                                                            AutoPostBack="true" OnSelectedIndexChanged="RadioButtonList_Check_Change">
                                                                                                                            <asp:ListItem Value="1">通过</asp:ListItem>
                                                                                                                            <asp:ListItem Value="2">不通过</asp:ListItem>
                                                                                                                        </asp:RadioButtonList>
                                                                                                                        &nbsp;&nbsp;&nbsp;
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <div runat="server" id="choose_cashcard" visible="false">
                                                                                                        <tr>
                                                                                                            <td colspan="2">
                                                                                                                资金卡选择：<asp:RadioButton ID="RB_CashCardID" runat="server" OnCheckedChanged="RB_CashCardID_CheckedChanged"
                                                                                                                    AutoPostBack="true" /><asp:DropDownList ID="DDL_CashCardID" runat="server">
                                                                                                                    </asp:DropDownList>
                                                                                                                <asp:RadioButton ID="RB_NewAddCashCard" runat="server" AutoPostBack="true" OnCheckedChanged="RB_NewAddCashCard_CheckedChanged"
                                                                                                                    Text="新建资金卡" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </div>
                                                                                                    <%--              <tr>
                  <td>
                    <table border="0" width="100%">
                    <tr>
                        <td width="60px">审批备注：</td>
                        <td align="left">
                        <asp:TextBox ID="TB_DoNote"  runat="server" Style="width: 280px;" Height="80px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                   </table>
               </td>
              </tr>--%>
                                                                                                    <tr>
                                                                                                        <td style="height: 10px;">
                                                                                                            &nbsp;
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td align="center" style="padding-top: 10px; width: 280px;" colspan="2" valign="bottom">
                                                                                                            <asp:Button ID="Button_sumbit" runat="server" Text=" 确定 " OnClientClick="if(confirm('您确定要审批吗？')){return true;}else{return false;}"
                                                                                                                OnClick="Button_sumbit_onclick" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                                    ID="Button_goback" OnClick="Button_goback_onclick" runat="server" Text=" 返回 "
                                                                                                                    CssClass="button1" />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                            <td valign="top" align="left" style="width: 50%;">
                                                                                                <div runat="server" id="div_cash" visible="false">
                                                                                                    <table>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                初始金额： &nbsp;
                                                                                                            </td>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="TB_LimitNums" Width="150px" runat="server"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top">
                                                                                                                新建备注说明： &nbsp;
                                                                                                            </td>
                                                                                                            <td style="height: 30px;">
                                                                                                                <asp:TextBox ID="TB_Notes" runat="server" TextMode="MultiLine" Height="100" Width="250"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </div>
                                                                                            </td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                </tr>
            </table>
            </td><td width="5">
            </td>
            </tr></table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
