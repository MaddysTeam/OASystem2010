<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FaceShowMessage.aspx.cs"
    Inherits="Dianda.Web.Admin.FaceShowMessage" %>

<%@ Register Src="ucFaceShowMessage.ascx" TagName="ucFaceShowMessage" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/OACSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ucFaceShowMessage id="ucFaceShowMessage1" runat="server" />
    </div>
    </form>
</body>
</html>
