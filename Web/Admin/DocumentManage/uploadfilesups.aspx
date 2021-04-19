<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadfilesups.aspx.cs"
    Inherits="Dianda.Web.Admin.DocumentManage.uploadfilesups" %>

<%@ Register Assembly="FlashUpload" Namespace="FlashUpload" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传文件</title>
    <link href="../css/OACSS.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript">
    function onloads() {

        // var hid = request("hid");
        var urls = self.location.href;
        //alert(self.location.href);
        if (urls.indexOf("hid=0") > 0) {
          //  alert("ok");
        }
        else {
            urls = urls + "&hid=0";
            window.open(urls, "_self");
        }
       
    }
    
    </script>
<meta http-equiv="Pragma" content="no-cache"/>
    <base target="_self" />
</head>
<body bgcolor="#eeeeee">
    <form id="form1" runat="server">
    <input id="Hidden1" value="0" type="hidden" />
    <div>
        <table cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td align="center" colspan="2" height="50">
                    <br />
                    <table width="95%" border="0" height="70" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="left" style="font-size: 12px; color: Black; font-weight: bolder;">
                                文件类型：<asp:Label Font-Bold="true" ForeColor="red" ID="Label_type" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px; color: Black; font-weight: bolder;">
                                友情提示：<span style="color: red; font-weight: bolder;">当上传的进度条显示“已上传100%”后，并且“添加文件”按钮再次单独出现，才可以关闭当前页面，</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="font-size: 12px; color: Black; font-weight: bolder;">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span
                                    style="color: red; font-weight: bolder;">否则上传工作无法完成！</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <table border="0" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
                        <tr>
                            <td>
                                <cc1:FlashUpLoad ID="FlashUpLoad1" runat="server" OnUploadComplete="UploadComplete()"
                                    UploadPage="Upload.axd" FileTypeDescription="" FileTypes="" TotalUploadSizeLimit="25000000000"
                                    UploadFileSizeLimit="10000000000">
                                </cc1:FlashUpLoad>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="HiddenField_uid" runat="server" />
    </div>
    </form>
</body>
</html>
