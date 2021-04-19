<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoteDetail.aspx.cs" Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.NoteDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all" />

    <script src="../../js/SelectDate.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="230" height="478" border="0" cellspacing="0" cellpadding="0" bgcolor="#125698"
            class="ziti_style">
            <tr>
               <%-- <td >background="/Admin/images/OAimages/rbg_2.jpg" height="30"  style="background-repeat:no-repeat;"
                 <asp:Label ID="Label1" runat="server" Font-Bold="true" Text="便签条" CssClass="ziti_style3"></asp:Label>
                </td>--%>                
               <td background="/Admin/images/OAimages/right_top.jpg" style="height:30px" align="center">
               <asp:Label ID="Label_Note" runat="server" Text="便签条" CssClass="ziti_style3"></asp:Label></td>                     
            </tr>
            <tr>
            <td align="right" style="padding-top:2px;">
            <asp:DropDownList
                                    ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                </asp:DropDownList>
             </td></tr>
            <tr>
                <td valign="top" style="padding-left:10px;" height="350"> <div class="div_scroll_notepad"><asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" PageSize="6"
                        Width="200" BorderColor="#125698" GridLines="None">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table width="100%"cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                               <%#Eval("NAMES")%>
                                            </td>
                                        </tr>
                                        </table>
                                      <table width="100%" cellpadding="0" cellspacing="0" style=" border:1px; border-bottom-style:dashed;">  
                                        <tr>
                                            <td>
                                            <%#Eval("DATETIME")%>
                                            </td>
                                            <td >
                                                <asp:ImageButton ID="ImageButton1"  OnClientClick='return confirm("您确定要如此操作吗？")' runat="server"  OnClick="LinkButton_Del_Click1" CommandArgument='<%#Eval("ID") %>'  ImageUrl="/admin/images/OAimages/ico_close.jpg"/>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>  </div>                
                    <%-- 记录当前是第几页--%>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <%-- 记录当前是第几页--%>
                    <%-- 记录信息集中总共有多少条记录--%>
                    <asp:HiddenField ID="dtrowsHidden" runat="server" />
                    <%-- 记录信息集中总共有多少条记录--%>
                    <%--下面是分页控件--%>
                    </td>
                 </tr>
                 <tr style="display:none">
                    <td>
                    <table cellpadding="0" cellspacing="0" height="28" width="100%" runat="server" id="pageControlShow">
                        <tr>
                            <td align="center">
                                <asp:Label ID="Label_notice" runat="server" Text=""></asp:Label>
                                
                                <asp:Panel ID="Panel1" runat="server" Visible="False">
                                
                                <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server" 
                                    CssClass="linkb_style" Visible="False">第一页</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server"
                                    CssClass="linkb_style" Visible="False">上一页</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server"
                                    CssClass="linkb_style" Visible="False">下一页</asp:LinkButton>
                                &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server"
                                    CssClass="linkb_style" Visible="False">最后页</asp:LinkButton>
                                &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Visible="False"></asp:Label>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <%--下面是分页控件--%>
                    <asp:Label ID="notice" runat="server" Text=""></asp:Label><asp:HiddenField ID="pageindexHidden"
                        runat="server" />
                </td>
            </tr>
            <tr>
                <td height="10">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td align="center" height="30">
                    <asp:Button ID="Get_Back" runat="server" CssClass="button1" Text=" 返 回 " 
                        CausesValidation="False" onclick="Get_Back_Click" />
                </td>
            </tr>
            <tr>
                <td height="5" >
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
