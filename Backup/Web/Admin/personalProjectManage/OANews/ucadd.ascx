<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucadd.ascx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OANews.ucadd" %>
<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>

<%@ Register src="../../newsManage/UserManage.ascx" tagname="UserManage" tagprefix="uc2" %>
<table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td valign="top">
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <uc1:projectControl ID="projectControl1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table class="tab7" width="100%">
                                        <tr>
                                            <td>
                                                <table class="tab4" width="100%">
                                                    <tr>
                                                        <td>
                                                            <table class="tab5" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <div id="div2" runat="server">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        标题：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNAME" runat="server" CssClass="textbox_name"></asp:TextBox><font
                                                                                            color="red">*</font>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <div id="Div1" runat="server" visible="false">
                                                                                        <td>
                                                                                            栏目：
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:DropDownList ID="ddlPARENTID" runat="server">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </div>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td  valign="top">
                                                                                        内容：
                                                                                    </td>
                                                                                    <td>
                                                                                        <FCKeditorV2:FCKeditor ID="FCKeditor_neirong" runat="server" Width="580" Height="300">
                                                                                        </FCKeditorV2:FCKeditor>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        浏览权限：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="rblLimitsChoose" runat="server" RepeatColumns="3" AutoPostBack="true"
                                                                                            OnSelectedIndexChanged="rblLimitsChoose_SelectedIndexChanged">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                        <uc2:UserManage ID="UserManage1" runat="server" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" Text="  发布  " OnClick="Button_sumbit_Click"
                                                                                            CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button_reset"
                                                                                                runat="server" Text=" 重置 " OnClick="Button_reset_Click" CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                                    ID="Button_cancel" runat="server" Text=" 取消 " CssClass="button1" OnClick="Button_cancel_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
            <table height="40px" align="center" cellpadding="1" cellspacing="1" width="98%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="notice" runat="server" Text="" CssClass="notice"></asp:Label>
                        <asp:HiddenField ID="H_NAME" runat="server" />
                        <%-- <asp:HiddenField ID="H_ModifyID" runat="server" />--%>
                    </td>
                </tr>
            </table>
        </td>
        <td width="5">
        </td>
    </tr>
</table>
