<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="show.aspx.cs" Inherits="Dianda.Web.Admin.newsManage.OAnews.show" %>

<%@ Register src="ucshow.ascx" tagname="ucshow" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body style="background-color:#99cccd">
    <form id="form1" runat="server">
    <div>
    
        <uc1:ucshow ID="ucshow1" runat="server" />
    
    </div>
    </form>
</body>
</html>
