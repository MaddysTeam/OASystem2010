<%@ Page Language="C#" AutoEventWireup="true"  ValidateRequest="false" MasterPageFile="~/Admin/ajaxAdmin_noSession.Master" CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.DOC_transport.add" %>
 <asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server" ID="ContentPlaceHolder2">
  <script type="text/javascript">
      var GB_ROOT_DIR = "/Admin/js/greybox/";
    </script>
 
    <script type="text/javascript" src="/Admin/js/greybox/AJS.js"></script>

    <script type="text/javascript" src="/Admin/js/greybox/AJS_fx.js"></script>

    <script type="text/javascript" src="/Admin/js/greybox/gb_scripts.js"></script>

    <link href="/Admin/js/greybox/gb_styles.css" rel="stylesheet" type="text/css" media="all" />

    <script type="text/javascript" src="/Admin/js/static_files/help.js"></script>
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
                            &nbsp;&nbsp;<img alt="" src="../images/2009-3-23/gif_46_067.gif" />&nbsp;&nbsp; <span class="titlePosition">添加公文</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            
                            <input type="button" onclick="window.open('manage.aspx','_self');" value="-返回-" name="-返回-"
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
    <table height="40px" align="center" bgcolor="#ffffff" cellpadding="1" cellspacing="1"
        width="98%">
        <tr bgcolor="#ffffff">
            <td>
                <table height="40px" align="center" bgcolor="#ffffff" cellpadding="0" cellspacing="0"
                    width="98%">
                    <tr>
                        <td style="width: 100%;" valign="top">
                            <table height="20px" cellpadding="1" bgcolor="#f0f0f0" cellspacing="1" width="100%">
                                <tr >
                                    <td colspan="2" align="right" style="height: 25px" valign="top">
                                        ○&nbsp; 公文基本信息：
                                    </td>
                                    <td style="height: 25px">
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td style="width: 12px; height: 28px;">
                                        &nbsp;&nbsp;&nbsp;
                                    </td>
                                    <td style="width: 98px; height: 28px;" align="right" valign="top">
                                        公文标题：
                                    </td>
                                    <td style="height: 39px; color: #ff0000;">
                                        <asp:TextBox ID="TextBox_NAME" CssClass="Inputtext" runat="server"  
                                            Width="434px" TextMode="MultiLine" Height="60">400个字符</asp:TextBox>
                                        (*必填项)
                                    </td>
                                </tr>
                           
                                <tr>
                                    <td style="width: 12px; height: 27px">
                                    </td>
                                    <td align="right" style="width: 98px; height: 27px">
                                        公文附件：
                                    </td>
                                    <td style="height: 27px">
                                        <asp:FileUpload ID="FileUpload_sl" runat="server" Width="488px" /><br />
                                         只允许上传ppt、rar、zip、doc、xls、pdf、txt、jpg、jpeg、png、bmp、docx、xlsx格式的文件
                                    </td>
                                </tr>
                                   <tr>
                                    <td>
                                    </td>
                                    <td align="right">
                                        请选择人员：
                                    </td>
                                    <td height="40">
                                     &nbsp; &nbsp;  &nbsp;  &nbsp;  <a href="javascript:window.showModalDialog('chooseUser.aspx','','dialogWidth=726px;dialogHeight=400px');" target="_self"   style="color:Red; font-size:14px; font-weight:bolder">点击选择接收公文的人员列表</a> (*只显示老师用户)
                                    </td>
                                </tr> 
                                <tr>
                        <td align="center" colspan="3">
                           
                            <asp:Button ID="Button_queding" runat="server" Text="-确定-" 
                                class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'" 
                                onmouseout="this.className='btn1_mouseout'" onclick="Button_queding_Click" />
                            <input type="button" onclick="window.open('manage.aspx','_self');" value="-返回-" name="-返回-"
                                class="btn1_mouseout" onmouseover="this.className='btn1_mouseover'" onmouseout="this.className='btn1_mouseout'" />
                            <asp:Image ID="tagImage" Visible="false" runat="server" />
                            <asp:Label ID="tag" runat="server" Text="" /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /><br />
                        </td>
                    </tr>
                            </table>
              
                        </td>
                    </tr>
                   
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
 


