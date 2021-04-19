<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin/ajaxAdmin_noSession.Master"  CodeBehind="manageShou.aspx.cs" Inherits="Dianda.Web.Admin.DOC_transport.manageShou" %>
<%@ Register src="docToModel.ascx" tagname="docToModel" tagprefix="uc1" %>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server" ID="ContentPlaceHolder2">
   <table height="40px" align="center" bgcolor="#A8A6A7" cellpadding="0" cellspacing="0"
        width="100%">
        <tr bgcolor="#ffffff">
            <td>
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
                                        &nbsp;&nbsp;<img alt="" src="../images/2009-3-23/gif_46_067.gif" /> &nbsp;&nbsp; <span class="titlePosition">以下是公文流转收件箱文件列表</span>&nbsp;&nbsp; <input id="Button1" onclick="window.open('add.aspx','_self')" type="button"
                                            value="-发布新公文-" class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'"
                                            onmouseout="this.className='btn1_mouseout'" />
                                      <input id="Button_addNeworgan" onclick="window.open('http://totalonline.shtvsss.com/Default.aspx?user=<%=Session["USERID_SYSUSER"].ToString()%>','_blank')" type="button"
                                            value="-进入聊天室-" class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'"
                                            onmouseout="this.className='btn1_mouseout'" />
                                              <input id="Button2" onclick="window.open('manage.aspx','_self')" type="button"
                                            value="-进入发件箱-" class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'"
                                            onmouseout="this.className='btn1_mouseout'" />
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

                <table height="40px" align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"
                    width="100%">
                    <tr bgcolor="#ffffff">
                        <td valign="top">
                            <uc1:docToModel ID="docToModel1" runat="server" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
