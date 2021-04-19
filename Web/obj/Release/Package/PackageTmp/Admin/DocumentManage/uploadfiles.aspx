<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="uploadfiles.aspx.cs" Inherits="Dianda.Web.Admin.DocumentManage.uploadfiles" %>

<%@ Register Src="../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<%--<%@ Register assembly="FlashUpload" namespace="FlashUpload" tagprefix="cc1" %>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" width="90%" align="center">
        <tr>
            <td height="40px">
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
                                                <td colspan="2" height="90">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <table cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td width="150px">
                                                            </td>
                                                            <td align="center">
                                                                上级目录:<asp:DropDownList ID="DropDownList_upid" runat="server" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="DropDownList_upid_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="Label_notice2" runat="server" Text="请选择您所参与的项目"></asp:Label><span
                                                                    runat="server" id="uploada"> <%--<a href="javascript:window.showModalDialog('uploadfilesups.aspx?ID=<%=DropDownList_upid.SelectedItem.Value.ToString()%>','','dialogWidth=900px;dialogHeight=500px');"
                                                                        target="_self" class="button1_links" title="给<%=DropDownList_upid.SelectedItem.Text.ToString()%>上传文件">
                                                                        上传文件</a>--%><a onclick="javascript:window.open('uploadfilesups.aspx?ID=<%=DropDownList_upid.SelectedItem.Value.ToString()%>','','Width=700px;Height=400px');" href="#"
                                                                        target="_self" class="button1_links" title="给<%=DropDownList_upid.SelectedItem.Text.ToString()%>上传文件">
                                                                        上传文件</a></span>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Button ID="Button_reset" runat="server" CausesValidation="false" Text=" 返回 "
                                                                    CssClass="button1" OnClick="Button_reset_Click" />
                                                            </td>
                                                            <td width="150px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:HiddenField ID="HiddenField_uid" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="40">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2">
                                                    <%--   <cc1:FlashUpLoad ID="FlashUpLoad1" runat="server" OnUploadComplete="UploadComplete()"
        UploadPage="Upload.axd" FileTypeDescription="" FileTypes=""
        TotalUploadSizeLimit="25000000000" UploadFileSizeLimit="10000000000">
    </cc1:FlashUpLoad>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="30">
                                                    [*支持的文件类型：<asp:Label ID="Label_type" runat="server" Text=""></asp:Label>]
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="2" height="30">
                                                    上传文件是支持多文件同时上传的。请先选择你要上传到的目录！
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
        </tr>
    </table>
    <table class="tab6">
        <tr>
            <td align="center">
                <img src="/Admin/images/OAimages/Separator_content.jpg">
            </td>
        </tr>
    </table>
</asp:Content>
