<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/ajaxAdmin_noSession.Master"
    CodeBehind="check.aspx.cs" Inherits="Dianda.Web.Admin.DOC_transport.check" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server" ID="Content1">
    <table height="30px" align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"
        width="98%">
        <tr>
            <td colspan="4" height="10" bgcolor="#ffffff">
            </td>
        </tr>
        <tr bgcolor="#d4f6d9">
            <td>
                <table height="30px" bgcolor="#ffffff" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            &nbsp;&nbsp;<img alt="" src="../images/2009-3-23/gif_46_067.gif" />
                            &nbsp;&nbsp; <span class="titlePosition">公文流转收件箱文件>>公文查看</span>&nbsp;&nbsp;
                            <asp:Button ID="Button_fanhui" runat="server" Text="-返回-" OnClick="Button_fanhui_Click"
                                class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'" onmouseout="this.className='btn1_mouseout'" />
                        </td>
                    </tr>
                    <tr>
                        <td height="1" bgcolor="#e0e0e0">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <br />
    <table height="40px" align="center" bgcolor="#e0e0e0" cellpadding="1" cellspacing="1"
        width="98%">
        <tr bgcolor="#ffffff">
            <td>
                <table align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0" width="98%"
                    style="height: 100px">
                    <tr>
                        <td style="height: 100px; width: 100%;">
                            <table height="40px" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center" style="height: 25px;" width="100" valign="middle">
                                    公文标题：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label_title" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="height: 25px;" width="100"  valign="middle">
                                    附件下载：
                                    </td>
                                    <td>
                                        <asp:Label ID="Label_fileup" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                      
                            </table>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
