<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OAleftmenu.ascx.cs"
    Inherits="Dianda.Web.Admin.cashCardManage.OAleftmenu" %>
<table cellpadding="0" cellspacing="0" border="0" width="100%">
    <tr>
        <td align="left">
            <img src="/Admin/images/OAimages/leftsideBar_top.jpg" style="vertical-align: bottom" />
        </td>
    </tr>
      <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form3_tr" onmouseover="chag_bg(3);" onmouseout="rest_bg(3);">
        <td align="left">
            <a href="/Admin/cashCardManage/Cash_Account.aspx?role=manage" target="_self" class="master_a">
                账户管理</a>
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
       <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form4_tr" onmouseover="chag_bg(4);" onmouseout="rest_bg(4);">
        <td align="left">
            <a href="/Admin/cashCardManage/Cash_SpecialFunds.aspx?role=manage" target="_self" class="master_a">
                专项资金管理</a>
        </td>
    </tr>
    
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
<%--       <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form5_tr" onmouseover="chag_bg(5);" onmouseout="rest_bg(5);">
        <td align="left">
            <a href="/Admin/cashCardManage/manageCashApply.aspx?tags=部门" target="_self" class="master_a">
                预约报告</a>
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>--%>
        <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form2_tr" onmouseover="chag_bg(2);" onmouseout="rest_bg(2);">
        <td align="left">
            <a href="/Admin/cashCardManage/manage.aspx?role=manage" target="_self" class="master_a">资金卡</a>
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
    <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
        <td align="left">
            <a href="/Admin/cashCardManage/showHistoryAll.aspx" target="_self" class="master_a">
                资金卡统计</a>
        </td>
    </tr>
	 <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
	 <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
        <td align="left">
            <a href="/Admin/budgetManage/todo/list.aspx?role=manage" target="_self" class="master_a">
                待办预算管理</a>
        </td>
    </tr>
	 <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px">
        <td align="left">
        </td>
    </tr>
	 <tr style="background: url(/Admin/images/OAimages/leftsideBar_bg.jpg); height: 20px"
        id="form1_tr" onmouseover="chag_bg(1);" onmouseout="rest_bg(1);">
        <td align="left">
            <a href="/Admin/budgetManage/department/list.aspx?role=manage" target="_self" class="master_a">
                部门预算管理</a>
        </td>
    </tr>
    <tr>
        <td align="left">
            <img src="/Admin/images/OAimages/leftsideBar_bot.jpg" />
        </td>
    </tr>
</table>
