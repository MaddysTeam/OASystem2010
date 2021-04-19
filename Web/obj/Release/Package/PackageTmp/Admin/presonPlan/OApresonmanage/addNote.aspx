<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addNote.aspx.cs" Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.addNote" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table width="230" height="474" border="0" cellspacing="0" cellpadding="0" bgcolor="#125698" class="ziti_style">
            <tr>
                <td colspan="3" background="/Admin/images/OAimages/right_top.jpg" height="30" align="center">
                    <asp:Label ID="Label_addNote" runat="server" Text="新增便条" CssClass="ziti_style3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="bottom" height="30px" style="padding-left:24px"><asp:Label ID="Label_noteContent" runat="server" Text="便条内容:"></asp:Label>
                <font color="yellow">*</font>
                <asp:Label ID="Label_notice" ForeColor="Yellow"  runat="server" Text=""></asp:Label>
                </td>
              </tr>
            <tr>
                <td valign="top" height="120px" style="padding-left:24px"><asp:TextBox ID="TextBox_noteContent" runat="server" Height="100px" 
                        TextMode="MultiLine" Width="170px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="10">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td align="center" style="height:30px">
                    <asp:Button ID="Button_add" runat="server" Text="添  加" CssClass="button1" 
                        onclick="Button_add_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button_quxiao" runat="server" Text="返  回" CssClass="button1" 
                        onclick="Button_quxiao_Click"/>
                </td>
             </tr>
            <tr>
            <tr>
            <td align="center" height="20"></td>
            </tr>
            <td height="100%"></td></tr>
        </table>
    
    </div>
    </form>
</body>
</html>
