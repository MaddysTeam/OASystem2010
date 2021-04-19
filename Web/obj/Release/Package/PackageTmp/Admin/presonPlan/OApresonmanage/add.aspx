<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add.aspx.cs" Inherits="Dianda.Web.Admin.presonPlan.OApresonmanage.add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../../css/OACSS.css" rel="Stylesheet" type="text/css" media="all" />

    <script src="../../js/SelectDate2.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="230"  border="0" cellspacing="0" cellpadding="0" bgcolor="#125698"
            class="ziti_style">
            <tr>
                <td align="center" background="/Admin/images/OAimages/right_top.jpg" height="26">
                    <asp:Label ID="Label_addProject" runat="server" Text="新增个人计划" CssClass="ziti_style3"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center">
                    &nbsp;<%--  <input class="Wdate" type="text" id="hts" onfocus="new WdatePicker(this,'%Y年%M月%D日',false)" maxdate="#F{$('hte').value}" onPicked="$('hte').onfocus()"/>--%>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:Label ID="Label_Title" runat="server" Text="标题:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                <asp:TextBox ID="TextBox_Title" runat="server" Height="90px" TextMode="MultiLine"
                        Width="158px" MaxLength="250"></asp:TextBox>
                    <%--<asp:TextBox ID="TextBox_Title" runat="server" Width="140px" MaxLength="25" CssClass="textbox_name"></asp:TextBox>--%><font
                        color="yellow">*</font>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox_Title"
                        ErrorMessage="标题不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="30">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px" class="style1">
                    <asp:Label ID="Label_StartTime" runat="server" Text="开始日期:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px" class="style1">
                    <input class="Inputtext" id="TB_DateTime" runat="server" width="20px" type="text"
                        readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;天<font color="yellow">*</font><br>
                    <asp:DropDownList ID="ddl_Part" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_Part_change">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                    </asp:DropDownList>
                    小时<asp:DropDownList ID="ddl_second" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddl_Part_change">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <%--  <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>--%>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <%-- <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>--%>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <%--  <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>--%>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <%-- <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>--%>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <%-- <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>--%>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <%-- <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>--%>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <%-- <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>--%>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <%-- <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>--%>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <%--  <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>--%>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <%--<asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>--%>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <%-- <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>--%>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <%-- <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>--%>
                    </asp:DropDownList>
                    分钟
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TB_DateTime"
                        ErrorMessage="开始时间不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td height="30">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:Label ID="Label_EndTime" runat="server" Text="结束日期:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <input class="Inputtext" id="TB_DateTime1" runat="server" width="20px" type="text"
                        readonly="readonly" onclick="ShowCalendar(this);" />&nbsp;天<font color="yellow">*</font><br>
                    <asp:DropDownList ID="ddl_Part1" runat="server">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02" Selected="True">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="11">11</asp:ListItem>
                        <asp:ListItem Value="12">12</asp:ListItem>
                        <asp:ListItem Value="13">13</asp:ListItem>
                        <asp:ListItem Value="14">14</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="16">16</asp:ListItem>
                        <asp:ListItem Value="17">17</asp:ListItem>
                        <asp:ListItem Value="18">18</asp:ListItem>
                        <asp:ListItem Value="19">19</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="21">21</asp:ListItem>
                        <asp:ListItem Value="22">22</asp:ListItem>
                        <asp:ListItem Value="23">23</asp:ListItem>
                    </asp:DropDownList>
                    小时<asp:DropDownList ID="ddl_second1" runat="server">
                        <asp:ListItem Value="00">00</asp:ListItem>
                        <%--  <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>--%>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <%-- <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>--%>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <%--  <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>--%>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <%-- <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>--%>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <%-- <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>--%>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        <%-- <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>--%>
                        <asp:ListItem Value="30">30</asp:ListItem>
                        <%-- <asp:ListItem>31</asp:ListItem>
                        <asp:ListItem>32</asp:ListItem>
                        <asp:ListItem>33</asp:ListItem>
                        <asp:ListItem>34</asp:ListItem>--%>
                        <asp:ListItem Value="35">35</asp:ListItem>
                        <%-- <asp:ListItem>36</asp:ListItem>
                        <asp:ListItem>37</asp:ListItem>
                        <asp:ListItem>38</asp:ListItem>
                        <asp:ListItem>39</asp:ListItem>--%>
                        <asp:ListItem Value="40">40</asp:ListItem>
                        <%--  <asp:ListItem>41</asp:ListItem>
                        <asp:ListItem>42</asp:ListItem>
                        <asp:ListItem>43</asp:ListItem>
                        <asp:ListItem>44</asp:ListItem>--%>
                        <asp:ListItem Value="45">45</asp:ListItem>
                        <%--<asp:ListItem>46</asp:ListItem>
                        <asp:ListItem>47</asp:ListItem>
                        <asp:ListItem>48</asp:ListItem>
                        <asp:ListItem>49</asp:ListItem>--%>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <%-- <asp:ListItem>51</asp:ListItem>
                        <asp:ListItem>52</asp:ListItem>
                        <asp:ListItem>53</asp:ListItem>
                        <asp:ListItem>54</asp:ListItem>--%>
                        <asp:ListItem Value="55">55</asp:ListItem>
                        <%-- <asp:ListItem>56</asp:ListItem>
                        <asp:ListItem>57</asp:ListItem>
                        <asp:ListItem>58</asp:ListItem>
                        <asp:ListItem>59</asp:ListItem>--%>
                    </asp:DropDownList>
                    分钟
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TB_DateTime1"
                        ErrorMessage="结束时间不能为空" ForeColor="Yellow" Display="Dynamic"></asp:RequiredFieldValidator>
                </td>
            </tr>
<%--            <tr>
                <td height="5">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td style="padding-left: 24px">
                    <asp:Label ID="Label_Content" runat="server" Text="计划内容:"></asp:Label>
                </td>
            </tr>
            <tr>
                <td valign="top" style="padding-left: 24px" height="100px">
                    <asp:TextBox ID="TextBox_Content" runat="server" Height="90px" TextMode="MultiLine"
                        Width="158px"></asp:TextBox>
                    <br />
                    <asp:Label ID="Labeltext" Style="font-size: 12px; color: White" runat="server" Text=""></asp:Label>
                </td>
            </tr>--%>
            <tr><td> <asp:Label ID="Labeltext" Style="font-size: 12px; color: White" runat="server" Text=""></asp:Label></td></tr>
            <tr>
                <td height="30">
                    <img src="../../images/OAimages/r_s.jpg" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 20px">
                    <asp:Button ID="Button_goon" runat="server" Text="保存并新建" CssClass="button1a" OnClick="Button_goon_Click" />
                    <asp:Button ID="Button_add" runat="server" Text="保存并关闭" OnClick="Button_add_Click"
                        CssClass="button1a" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" style="height: 30px; " valign="bottom">
                    <asp:Button ID="Button_back" runat="server" Text="返 回" CssClass="button1" CausesValidation="False"
                        OnClick="Button_back_Click" />
                </td>
            </tr>
            <tr><td colspan="2" style="height: 100px">&nbsp;</td></tr>
        </table>
    </div>
    </form>
</body>
</html>
