<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.personalProjectManage.OAapply.add" %>

<%@ Register Src="~/Admin/personalProjectManage/OAapply/orderFood.ascx" TagName="orderFood"
    TagPrefix="uc1" %>
<%@ Register Src="~/Admin/personalProjectManage/OAapply/orderCar.ascx" TagName="orderCar"
    TagPrefix="uc2" %>
<%@ Register Src="~/Admin/personalProjectManage/OAapply/orderRoom.ascx" TagName="orderRoom"
    TagPrefix="uc3" %>
<%@ Register Src="~/Admin/personalProjectManage/OAapply/orderSignet.ascx" TagName="orderSignet"
    TagPrefix="uc4" %>
<%@ Register Src="../../projectControl.ascx" TagName="projectControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="/Admin/js/SelectDate.js" type="text/javascript"></script>

    <script language="javascript" type="text/javascript">
        function checksignetnums(signetnums) {
            //       function checksignetnums(signetid, signetnums) {
            //         if (signetid.length == 0) 
            //         {
            //             alert('����ѡ����Ҫ�����ӡ�£�');
            //            return false;
            //         }
            //         if (signetnums.length == 0) 
            //         {
            //             alert('���·�������Ϊ�գ�');
            //            return false;
            //         }
            var str = "1234567890";
            var k = signetnums.length;
            var i;
            for (i = 0; i < k; i++) {
                var num = signetnums.charAt(i);
                if (str.indexOf(num) == -1) {
                    //alert('���·���ֻ���������֣�');
                    return false;
                }
            }

        }
    </script>

    <table align="center" cellpadding="0" cellspacing="0" width="90%" height="397">
        <tr>
            <td height="3px">
            </td>
        </tr>
        <div id="Control" runat="server">
            <tr>
                <td>
                    <uc1:projectControl ID="projectControl1" runat="server" />
                </td>
            </tr>
        </div>
        <tr>
            <td valign="top">
                <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table class="tab7">
                                            <tr>
                                                <td>
                                                    <table class="tab4">
                                                        <tr>
                                                            <td valign="top">
                                                                <table class="tab5">
                                                                    <tr>
                                                                        <td>
                                                                            <table class="tab2">
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lab_CLTS" runat="server" Text="����ʾ�������ʡ�ó����뼰ʱ����������д<a style='color:Red;' target='_blank' href=''>����ȷ�ϵ�</a>������ԤԼ���޷�ȷ�ϣ�лл������ϡ�" ForeColor="Red" Visible="false"></asp:Label></td>
                                                                                                <td align="center">
                                                                                                    <a id="show_manage" runat="server" href="" target="_self" class="button3d" style="text-decoration: none"
                                                                                                        title="">�鿴��������Ϣ</a>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <%--<asp:Button ID="Button_viewhistroy" runat="server" Text="�鿴��ʷ����" CssClass="button3d"
                                                                                                        OnClick="Button_viewhistroy_onclick" />--%>
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
                                                        <tr height="200px">
                                                            <td valign="top">
                                                                <%--�������½�ҵ��ľ�����--%>
                                                                <table border="0" cellpadding="0" cellspacing="0" style="margin-left: 20px;">
                                                                    <tr>
                                                                        <td>
                                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                                        </asp:ScriptManager>
                                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                <Triggers>  
                                                                                    <asp:PostBackTrigger ControlID="DDL_AppType" /> 
                                                                                </Triggers>
                                                                                <ContentTemplate>
                                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td colspan="2" align="center">
                                                                                                <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                �������ͣ�
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="DDL_AppType" runat="server" OnSelectedIndexChanged="DDL_AppType_Changed"
                                                                                                    AutoPostBack="true">
                                                                                                    <asp:ListItem Value=""> --��ѡ��-- </asp:ListItem>
                                                                                                    <asp:ListItem Value="orderFood">�ͷ�ԤԼ</asp:ListItem>
                                                                                                    <asp:ListItem Value="orderCar">����ԤԼ</asp:ListItem>
                                                                                                    <asp:ListItem Value="orderRoom">������ԤԼ</asp:ListItem>
                                                                                                    <asp:ListItem Value="orderSignet">��ӡ����</asp:ListItem>
                                                                                                </asp:DropDownList>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                <asp:Label ID="Lab_SHR" runat="server" Text="�����:" Visible="false"></asp:Label>
                                                                                                <asp:DropDownList ID="DDList_SHR" runat="server" Visible="false">
                                                                                                </asp:DropDownList>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                ������Ŀ��
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:DropDownList ID="DDL_Project" runat="server" OnSelectedIndexChanged="DDL_Project_SelectedIndexChanged"
                                                                                                    AutoPostBack="true">
                                                                                                </asp:DropDownList>
                                                                                                <asp:Label ID="LB_Project" runat="server" Text=""></asp:Label>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ���벿�ţ�<asp:DropDownList ID="DDL_Department" runat="server"
                                                                                                    AutoPostBack="True" OnSelectedIndexChanged="DDL_Department_SelectedIndexChanged">
                                                                                                </asp:DropDownList>
                                                                                                &nbsp;&nbsp; �����ˣ�<asp:DropDownList ID="User_DPList" runat="server">
                                                                                                </asp:DropDownList>
                                                                                                &nbsp;&nbsp;&nbsp;��ϵ�绰��<asp:TextBox ID="TB_TelNum" runat="server"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <%--                                    <tr><td colspan="2" height="2"></td></tr>
                                    <tr>
                                        <td>��ϵ�绰��</td>
                                        <td > 
                                            <asp:TextBox ID="TB_TelNum" runat="server" ></asp:TextBox>
                                        </td>
                                    </tr>--%>
                                                                                        <div id="ordertype" runat="server" visible="false">
                                                                                            <tr>
                                                                                                <td colspan="2" height="2">
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    ��ϸ�����
                                                                                                </td>
                                                                                                <td>
                                                                                                    <uc1:orderFood ID="orderFood" runat="server" Visible="false" />
                                                                                                    <uc2:orderCar ID="orderCar" runat="server" Visible="false" />
                                                                                                    <uc3:orderRoom ID="orderRoom" runat="server" Visible="false" />
                                                                                                    <uc4:orderSignet ID="orderSignet" runat="server" Visible="false" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </div>
                                                                                        <tr>
                                                                                            <td colspan="2" height="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 40px;" align="left" valign="top">
                                                                                                ��;��
                                                                                            </td>
                                                                                            <td style="height: 40px">
                                                                                                <asp:TextBox ID="Overviews" runat="server" CssClass="textbox_content" TextMode="MultiLine"></asp:TextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="2">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr align="center">
                                                                        <td>
                                                                            <asp:Button ID="Button_sumbit" runat="server" Text=" ȷ�� " CssClass="button1" OnClick="Button_sumbit_onclick" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button
                                                                                ID="Button_reback" runat="server" Text=" ���� " CssClass="button1" OnClick="Button_reback_onclick" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="2">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <%--�������½�ҵ��ľ�����--%>
                                                            </td>
                                                        </tr>
                                                        <tr height="50px">
                                                            <td>
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
</asp:Content>
