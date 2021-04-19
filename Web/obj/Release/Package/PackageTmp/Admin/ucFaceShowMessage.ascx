<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFaceShowMessage.ascx.cs"
    Inherits="Dianda.Web.Admin.ucFaceShowMessage" %>

<script src="/Admin/js/SelectDate2.js" type="text/javascript"></script>

<script language="javascript">
    //取得XMLHttp对象
    function newXMLHttp() {
        var XMLHttp = null;
        if (window.XMLHttpRequest) {
            XMLHttp = new XMLHttpRequest();
        }
        if (XMLHttp == null && window.ActiveXObject) {
            var clsids = ["MSXML2.XMLHttp.5.0", "MSXML2.XMLHttp.4.0", "MSXML2.XMLHttp.3.0", "MSXML2.XMLHttp.2.0", "MSXML2.XMLHttp.1.0", "MSXML2.XMLHttp", "Microsoft.XMLHttp"];
            for (var i = 0; i < clsids.length && XMLHttp == null; i++) {
                try {
                    XMLHttp = new ActiveXObject(clsids[i]);
                }
                catch (e)
   { }
            }
        }
        return XMLHttp;
    }

    //POST页面
    function postHTML(URL, data, func) {
        try {
            var XMLHttp = newXMLHttp();
            //同步调用
            if (typeof (func) != "function") {
                XMLHttp.open("POST", URL, false);
                XMLHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                XMLHttp.send(data);

                var result = XMLHttp.status;
                var responseText = XMLHttp.responseText;

                if (result == 200) {
                    return responseText;
                }
                else {
                    return false;
                }
            }
            //异步调用
            else {
                XMLHttp.onreadystatechange = function() {
                    if (XMLHttp.readyState == 4) {
                        if (XMLHttp.status == 200) {
                            var responseText = XMLHttp.responseText;
                            func(responseText);
                        }
                        else {
                            func(false);
                        }
                    }
                }
                XMLHttp.open("POST", URL, true);
                XMLHttp.setRequestHeader("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
                XMLHttp.send(data);
            }
        }
        catch (e) { }
    }


    var urls;
    function doTypeChange(urls) {
        //          document.getElementById("ctl00_ContentPlaceHolder1_ucFaceShowMessage1_TextBox_doIndexnum").value = indexnum;
        //          document.getElementById("ctl00_ContentPlaceHolder1_ucFaceShowMessage1_Button_doIndexnum").click();
        var data;
        postHTML(urls, data, "");
    }
</script>

<div>
    <table cellpadding="0" cellspacing="0" width="740">
        <tr>
            <td valign="top">
                <table align="center" bgcolor="#99cccd" cellpadding="0" cellspacing="0" width="98%">
                    <tr>
                        <td height="36px" valign="bottom">
                            <table width="600" height="26px" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" CommandArgument="1">全部</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton1_Click" CommandArgument="2">审批提醒</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton1_Click" CommandArgument="3">项目任务</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton1_Click" CommandArgument="4">共享文档</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton1_Click" CommandArgument="5">申请反馈</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton1_Click" CommandArgument="6">通知公告</asp:LinkButton>
                                    </td>
                                    <td valign="bottom">
                                        <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton1_Click" CommandArgument="789">我的消息</asp:LinkButton>
                                    </td>
                                    <%--<td align="center">--%>
                                    <%--  <td align="center" width="70px"><asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton1_Click"  CommandArgument="8">项目消息</asp:LinkButton></td>
                               <td align="center" width="70px"><asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton1_Click"  CommandArgument="9">部门消息</asp:LinkButton></td>--%>
                                    <%--   <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton1_Click" CommandArgument="10">历史消息</asp:LinkButton>
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="0" width="100%">
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
                                                                                <tr style="width:100%">
                                                                                    <td align="left"colspan="6" >                                                                                       
                                                                                        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
                                                                                            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
                                                                                            <asp:ListItem Selected="True" Value="time">时间排序</asp:ListItem>
                                                                                            <asp:ListItem Value="select1">范围排序</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <%--<td colspan="3" align="right"></td>--%>
                                                                                    <td colspan="4" align="right">
                                                                                    <asp:Button ID="Button2" runat="server" Text="查看回收站" CssClass="button3c" 
                                                                                            onclick="Button2_Click" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="show1" runat="server" visible="false"  style="width:100%">
                                                                                    <td colspan="6">
                                                                                        关键字：<asp:TextBox ID="Keyword" runat="server" Width="80px"></asp:TextBox>&nbsp; 开始时间：
                                                                                        <input class="Inputtext" id="txtBeginDate" runat="server" width="200" type="text"
                                                                                            readonly="readonly" onclick="ShowCalendar(this);" />&nbsp; 结束时间：
                                                                                        <input class="Inputtext" id="txtEndTime" runat="server" width="200" type="text" readonly="readonly"
                                                                                            onclick="ShowCalendar(this);" />
                                                                                    </td>
                                                                                   <%-- <td colspan="3" align="left">
                                                                                        <asp:Button ID="Button2" runat="server" Text="重置" CssClass="button3a" 
                                                                                            onclick="Button2_Click" />
                                                                                    </td>--%>
                                                                                    <td colspan="4" align="right">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                    <td align="right">  <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button_sumbit_onclick"
                                                                                            CssClass="button3a" /></td>
<%--                                                                                    <td align="right">
                                                                                      <asp:Button ID="Button_delete" ToolTip="请先搜索消息"  runat="server" Text="清除" OnClientClick="if(confirm('您确定要清除当前列表中的内容吗？')){return true;}else{return false;}"
                                                                                            OnClick="Button_delete_onclick" CssClass="button3a" Visible="false"/>
                                                                                     </td>--%>
                                                                                    </tr>
                                                                                    </table>                                                                              
                                                                              
                                                                                   </td>
                                                                                    
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="center" colspan="10">
                                                                                        <asp:Label ID="tag" runat="server" Text="" CssClass="tag1" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                            <asp:GridView ID="GridView1" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                                                GridLines="None" runat="server" CellPadding="3" CssClass="GridView1" DataKeyNames=""
                                                                                PageSize="10" ShowHeader="false" ShowFooter="false">
                                                                                <Columns>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <table width="100%" style="border-width: 1px; border-color: #808080; border-bottom-style: dashed;">
                                                                                                <tr>
                                                                                                    <td style="width: 80%">
                                                                                                        <asp:Label ID="lblURLS" runat="server" Text=""></asp:Label>
                                                                                                         <%# Eval("ISREAD").ToString() == "0" ? "<img src='../all_image/NEW.jpg' />" : ""%>
                                                                                                    </td>
                                                                                                  
                                                                                                    <td align="right">
                                                                                                        <asp:HiddenField ID="Hid_del" runat="server" />
                                                                                                        <asp:Label ID="lblDATETIME" runat="server" Text=""></asp:Label>&nbsp;&nbsp;<%--<img src='../Admin/images/del.jpg' runat="server"   onclick=""/>--%>
                                                                                                        <a href="" title="加入回收站"><asp:ImageButton ID="ImageButton_del" runat="server" ImageUrl="../Admin/images/del.jpg" OnClick="ImageButton_del_Click" /></a></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
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
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="notice" runat="server" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <asp:HiddenField ID="pageindexHidden" runat="server" />
                            <asp:HiddenField ID="H_NAME" runat="server" />
                            
                                                                        </td>
                                                                    </tr>
                                                                </table>
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
</div>
