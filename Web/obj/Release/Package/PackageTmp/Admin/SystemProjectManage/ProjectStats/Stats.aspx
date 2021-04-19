<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="Stats.aspx.cs" Inherits="Dianda.Web.Admin.SystemProjectManage.ProjectStats.Stats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table align="center" cellpadding="0" cellspacing="0" width="90%">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td>
                                                            &nbsp;&nbsp;项目切换：&nbsp;<asp:DropDownList ID="ddlProjectID" runat="server"
                                                                AutoPostBack="true" 
                                                                onselectedindexchanged="ddlProjectID_SelectedIndexChanged" >
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table cellpadding="0" cellspacing="0" width="100%" align="center">
                                                    <tr>
                                                        <td align="center">
                                                            <asp:LinkButton ID="LinkButton_task" runat="server" OnClick="LinkButton_task_Click">任务统计</asp:LinkButton>
                                                        </td>
                                                        <td align="center">
                                                            <asp:LinkButton ID="LinkButton_fee" runat="server" OnClick="LinkButton_fee_Click">经费统计</asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="tab7">
                                                    <tr>
                                                        <td>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
