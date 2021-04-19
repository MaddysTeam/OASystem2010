<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/OAmaster.Master" AutoEventWireup="true"
    CodeBehind="manageCashApply.aspx.cs" Inherits="Dianda.Web.Admin.cashCardManage.manageCashApply" %>

<%@ Register Src="OAleftmenu.ascx" TagName="OAleftmenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table align="center" cellpadding="0" cellspacing="0" width="100%" bgcolor="#99cccd">
        <tr>
            <td width="10">
            </td>
            <td valign="top" width="115" align="left">
                <uc1:OAleftmenu ID="OAleftmenu1" runat="server" />
            </td>
            <td width="5">
            </td>
            <td>
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="98%" align="center">
                                <tr>
                                    <td height="5px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="tab1" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td class="tab1_td1">
                                                    &nbsp;
                                                </td>
                                                <td class="tab1_td2">
                                                    <asp:Label ID="LB_name" runat="server" Text="" CssClass="LB_name1"></asp:Label>经费预约
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="tab3">
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
                                                                                    <td>
                                                                                        <table>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    状态：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="ddlStatas" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStatas_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                                <td>
                                                                                                    日期：
                                                                                                </td>
                                                                                                <td>
                                                                                                    <asp:DropDownList ID="DDList_RQ" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDList_RQ_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <%--<td align="center">
                                                                                        <a id="show_manage" runat="server" href="YYJEHZ.aspx" target="_self" rel="gb_page_center[726,400]"
                                                                                                        class="button3d" style="text-decoration: none" title="">预约金额汇总</a>
                                                                                    </td>--%>
                                                                                    <td align="center">
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" CssClass="button3d" Text="预约审核" 
                                                                                            onclick="Button_sumbit_Click"  />
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        <asp:Button ID="Button_Complete" runat="server" Text="直接记账" CssClass="button3d" 
                                                                                            OnClick="Button_Complete_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="5">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                runat="server" CssClass="GridView1" DataKeyNames="ID,ApplierRealName,GetDateTime,ApplyCount,Statas">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="">
                                                                                        <HeaderTemplate>
                                                                                            选择
                                                                                        </HeaderTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:RadioButton ID="RBtn_choose" runat="server" onclick="setRadio(this)"  />
                                                                                            <asp:HiddenField ID="Hid_ID"
                                                                                                runat="server" />
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:BoundField HeaderText="申请人" DataField="ApplierRealName">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="金额" DataField="ApplyCount">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="类型" DataField="Attribute">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="领取预约时间" DataField="GetDateTime">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="卡名称" DataField="TEMP2">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:TemplateField HeaderText="详情">
                                                                                        <ItemTemplate>
                                                                                            <a href="#" title="<%#Eval("UseFor") %>" onclick='ShowDialog(<%#Eval("ID") %>);'>详情</a>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle1" />
                                                                                    </asp:TemplateField>
                                                                                    <%--<asp:BoundField HeaderText="联系方式" DataField="ApplierTel">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>--%>
                                                                                    <asp:BoundField HeaderText="申请时间" DataField="DATETIME" DataFormatString="{0:yyyy-MM-dd}">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField HeaderText="状态" DataField="Statas">
                                                                                        <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle3" />
                                                                                        <ItemStyle HorizontalAlign="Center" CssClass="ItemStyle1" />
                                                                                    </asp:BoundField>
                                                                                </Columns>
                                                                                <FooterStyle CssClass="FooterStyle1" />
                                                                                <PagerStyle HorizontalAlign="Left" CssClass="PagerStyle1" />
                                                                                <SelectedRowStyle CssClass="SelectedRowStyle1" />
                                                                            </asp:GridView>
                                                                            <%-- 记录当前是第几页--%>
                                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                            <%-- 记录当前是第几页--%>
                                                                            <%-- 记录信息集中总共有多少条记录--%>
                                                                            <asp:HiddenField ID="dtrowsHidden" runat="server" />
                                                                            <%-- 记录信息集中总共有多少条记录--%>
                                                                            <%--下面是分页控件--%>
                                                                            <table cellpadding="0" cellspacing="0" height="25" width="100%" runat="server" id="pageControlShow">
                                                                                <tr height="7px">
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" bgcolor="#ffffff">
                                                                                        <asp:LinkButton ID="FirstPage" OnClick="PageChange_Click" runat="server">第一页</asp:LinkButton>
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="PreviousPage" OnClick="PageChange_Click" runat="server">上一页</asp:LinkButton>
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="NextPage" OnClick="PageChange_Click" runat="server">下一页</asp:LinkButton>
                                                                                        &nbsp;&nbsp;<asp:LinkButton ID="LastPage" OnClick="PageChange_Click" runat="server">最后页</asp:LinkButton>
                                                                                        &nbsp;&nbsp;<asp:Label ID="Label_showInfo" runat="server" Text=""></asp:Label>&nbsp;&nbsp;跳转到：<asp:DropDownList
                                                                                            ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <%--下面是分页控件--%>
                                                                            <asp:HiddenField ID="pageindexHidden" runat="server" />
                                                                            <asp:HiddenField ID="H_NAME" runat="server" />
                                                                            <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <br />
                                                                <div style="width: 100%; text-align: center">
                                                                    <table width="98%" height="50px" style="border: solid 1px #99cccd; text-align: center"
                                                                        cellpadding="0" cellspacing="0">
                                                                        <tr style="background-color: #99cccd;">
                                                                            <td>
                                                                                日期：<asp:Label ID="Label_Time" runat="server" Text="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                待审核
                                                                            </td>
                                                                            <td>
                                                                                审核通过
                                                                            </td>
                                                                            <td>
                                                                                审核未通过
                                                                            </td>
                                                                            <td>
                                                                                完成
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="border-right: solid 1px #99cccd; width: 120px">
                                                                                合计：金额
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money1" runat="server" Text="Label"></asp:Label>元
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money2" runat="server" Text="Label"></asp:Label>元
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money3" runat="server" Text="Label"></asp:Label>元
                                                                            </td>
                                                                            <td style="border-right: solid 1px #99cccd">
                                                                                <asp:Label ID="Label_money4" runat="server" Text="Label"></asp:Label>元
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
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
        </tr>
    </table>        
    <script type="text/javascript">
        function setRadio(nowRadio)
        {
            var choose = $("input[type=radio]")
            choose.each(function(i){
                $(this).attr("checked",false);
            });
            $("input[id="+nowRadio.id+"]").attr("checked",true);
        }
        function ShowDialog(ID)
        {
            window.showModalDialog('/Admin/cashCardManage/ShowDetail.aspx?ID='+ ID,'','dialogWidth=650px;dialogHeight=350px');
        }
    </script>
</asp:Content>
