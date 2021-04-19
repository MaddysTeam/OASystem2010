﻿<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucmodify.ascx.cs" Inherits="Dianda.Web.Admin.newsManage.OAnews.ucmodify" %>

<%@ Register src="../UserManage.ascx" tagname="UserManage" tagprefix="uc1" %>
<script type="text/javascript" src="../../../ueditor/ueditor.config.js"></script>
<script type="text/javascript" src="../../../ueditor/ueditor.all.min.js"></script>
<script type="text/javascript" src="../../../ueditor/lang/zh-cn/zh-cn.js"></script>
<script>
	$(function () {

		var temp = $('.hid').val();
		var ue = new baidu.editor.ui.Editor();
		ue.render("myEditor");
		ue.ready(function () {
			if (temp != "") {
				ue.setContent(temp);
			}

		});

	});

	function isqd(btn) {
		setContentValue();
	}


	function setContentValue() {
		var temp = UE.getEditor('myEditor').getContent();
		$('.hid').val(temp);
	}
</script>
<table align="center" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td>
            <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td height="3px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <table class="tab3" width="100%">
                                        <tr>
                                            <td>
                                                <table class="tab4" width="100%">
                                                    <tr>
                                                        <td valign="top">
                                                            <table class="tab5" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <div id="div2" runat="server">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td colspan="2" align="center">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">标题：</td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="txtNAME" runat="server" CssClass="textbox_name"></asp:TextBox> <font color="red">(*必填项)</font>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="Validator1" runat="Server" ControlToValidate="txtNAME"
                                                                                            ValidationGroup="add1" ErrorMessage="标题不能为空!" Display="Dynamic" /><%--<asp:RegularExpressionValidator
                                                                                                ID="RegularExpressionValidator2" runat="Server" ControlToValidate="txtNAME" ValidationGroup="add1"
                                                                                                ValidationExpression="^([\u4e00-\u9fa5]|[0-9_a-zA-Z]){2,25}$" ErrorMessage="标题在2~25字符!"
                                                                                                Display="Dynamic" />--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <!--<tr>
                                                                                    <td>
                                                                                        栏目：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlPARENTID" runat="server">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr> -->
                                                                                <tr>
                                                                                    <td valign="top" align="right">
                                                                                        内容：
                                                                                    </td>
                                                                                    <td>
                                                                                        <%--<FCKeditorV2:FCKeditor ID="FCKeditor_neirong" runat="server" Width="580" Height="300">
                                                                                        </FCKeditorV2:FCKeditor>--%>
																						<div id="myEditor" style="height:300px; width:580px;"></div>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        浏览权限：
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RadioButtonList ID="rblLimitsChoose" runat="server" RepeatColumns="3" AutoPostBack="true"
                                                                                            OnSelectedIndexChanged="rblLimitsChoose_SelectedIndexChanged">
                                                                                        </asp:RadioButtonList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td>
                                                                                        &nbsp;
                                                                                        
                                                                                        <uc1:UserManage ID="UserManage1" runat="server" />
                                                                                        
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="2" style="padding-top: 10px;">
                                                                                        <asp:Button ID="Button_sumbit" runat="server" ValidationGroup="add1" Text="确定" OnClick="Button_sumbit_Click"
                                                                                            CssClass="button1" />&nbsp;&nbsp;&nbsp;&nbsp;<input type="button" value="返回" class="button1" onclick="funFH()" />
                                                                         <%--<asp:Button ID="Button_cancel" runat="server"
                                                                                                Text="返回" CssClass="button1" OnClick="Button_cancel_Click" />--%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr height="20px">
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
            <table height="40px" align="center" cellpadding="1" cellspacing="1" width="98%">
                <tr>
                    <td valign="top">
                        <asp:Label ID="notice" runat="server" Text="" CssClass="notice"></asp:Label>
                        <asp:HiddenField ID="H_NAME" runat="server" />
                        <%-- <asp:HiddenField ID="H_ModifyID" runat="server" />--%>
                    </td>
                </tr>
            </table>
        </td>
        <td width="5">
        </td>
    </tr>
</table>
<input type="hidden" runat="server" id="hid" class="hid" />
<script type="text/javascript">
    function funFH() {
        var pageindex = '<%=Request["pageindex"] %>';
        var status = '<%=Request["status"] %>';
        var PARENTID = '<%=Request["PARENTID"] %>';

        window.location.href = "manage.aspx?pageindex=" + pageindex + "&status=" + status + "&PARENTID=" + PARENTID;
    }
</script>