<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserManage.ascx.cs" Inherits="Dianda.Web.Public.UserManage" %>

<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td align="left" valign="middle">
            &nbsp;
            <asp:CheckBox ID="chkAll" runat="server" Text="全选" />
            <asp:HiddenField ID="HField_ReturnVal" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="left" valign="middle">
        <asp:GridView ID="GView_UserManage" Width="100%" runat="server" AutoGenerateColumns="False"
            BackColor="White" BorderColor="White" BorderStyle="Solid" BorderWidth="0px" CellPadding="0"
            ForeColor="Black" GridLines="Vertical" OnRowDataBound="GridView_grouplist_RowDataBound">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <table cellpadding="1" cellspacing="1" width="100%" bgcolor="#99cccd">
                            <tr>
                                <td bgcolor="#99cccd" height="25">
                                    &nbsp;<asp:CheckBox ID="depid" runat="server"  
                                        TabIndex="<%# Container.DataItemIndex%>" Text='<%#Eval("DepartMentName")%>' />
                                    <asp:HiddenField ID="Hid_ID" runat="server" />
                                </td>
                            </tr>
                            <tr bgcolor="#f0f0f0" style="height:40px;">
                                <td align="left">
                                    <asp:Panel ID="Pan_UserManage" runat="server" >
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table><br />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#ffffff" />
            <PagerStyle BackColor="#ffffff" ForeColor="Black" HorizontalAlign="Center" />
            <EmptyDataTemplate>
            </EmptyDataTemplate>
            <SelectedRowStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#ffffff" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="#ffffff" />
        </asp:GridView>
        </td>
    </tr>
</table>

<script type="text/javascript">
    //全选事件
    $("input[id*=chkAll]").click(function() {
        var TnF = $(this).attr("checked");

        $("table[id*=GView_UserManage] input[type=checkbox]").each(function() {
            $(this).attr("checked", TnF);
        });
    });
    
    //部门事件
    $("input[id*=depid]").click(function() {
        var name = ($(this).attr("name"));
        var TnF = $(this).attr("checked");

        var name_arr = name.split("$");
        var depid = name_arr[name_arr.length - 1];
        var id = depid.substring(depid.indexOf("_") + 1);

        $("div[id*=" + id + "] input[type=checkbox]").each(function() {
            $(this).attr("checked", TnF);
            var nameChild = $(this).attr("name");
            var nameChild_arr = nameChild.split("$");
            var RYID = nameChild_arr[nameChild_arr.length - 1];

            $("input[id*=" + RYID + "]").each(function() {
                $(this).attr("checked", TnF);
            });
        });
    });
    
    //个人事件
    $("input[type=checkbox]").click(function() {
        var TnF = $(this).attr("checked");
        var name = $(this).attr("name");
        var name_arr = name.split("$");
        var RYID = name_arr[name_arr.length - 1];

        $("input[id*=" + RYID + "]").each(function() {
            $(this).attr("checked", TnF);
        });
        GetVal();
    });

    function GetVal() {
        var ReturnVal = "";
        $(".UserManageCss").each(function() {
            var name = $(this).attr("name");

            if ($("input[id*=" + name + "]").attr("checked")) {
                if (ReturnVal == "") {
                    ReturnVal = name;
                }
                else {
                    ReturnVal += "," + name;
                }
            }
        });

        $("input[id*=HField_ReturnVal]").val(ReturnVal);
    }
    
</script>