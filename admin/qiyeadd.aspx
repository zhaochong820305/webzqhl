<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qiyeadd.aspx.cs" Inherits="admin_qiyeadd" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
    
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
	<script charset="utf-8" src="js/kindeditor-all.js"></script>
	<script charset="utf-8" src="js/lang/zh-CN.js"></script>
	<script charset="utf-8" src="js/plugins/code/prettify.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin-left:40px;margin-top:10px;">当前位置：添加企业</div>
    <div style="margin-left:40px;margin-top:0px;">
    
        <table class="gridtable">
            <tr>
                <th class="active">企业名称：</th>
                <td colspan="3"><asp:TextBox ID="tbname" runat="server" Width="681px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>
            <tr>
                <th class="active">登录名：</th>
                <td>
                    <asp:TextBox ID="tblogin" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">密码：</th>
                <td>
                    <asp:TextBox ID="tbpass" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="auto-style1">详细地址：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbadd" runat="server" Width="280px"></asp:TextBox></td>
                <th class="auto-style1">邮政编码：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbzipcode" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">法人姓名：</th>
                <td>
                    <asp:TextBox ID="tbfaren" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">法人电话：</th>
                <td>
                    <asp:TextBox ID="tbfarentel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">联系人：</th>
                <td>
                    <asp:TextBox ID="tblianxi" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">联系电话：</th>
                <td>
                    <asp:TextBox ID="tblianxitel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">经营范围：</th>
                <td colspan="3">
                    <asp:TextBox ID="jingyingfw" runat="server" Width="683px" Height="55px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">地区：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ddldiqu" runat="server"></asp:DropDownList>
                    </td>
            </tr>
            <tr>
                <th class="active">企业性质：</th>
                <td colspan="3">
                   <asp:DropDownList ID="ddlqiyexz" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th class="active">行业领域：</th>
                <td>
                    <asp:DropDownList ID="hangye" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="tdHangYe2ID">
                     <asp:DropDownList ID="hangye2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="hangye2_SelectedIndexChanged"></asp:DropDownList></td>
                <td id="desc">
                    <asp:Label ID="Label2" runat="server" Width="330px"></asp:Label>
                </td>
            </tr>
            <tr>
                <th class="active">是否上市公司：</th>
                <td colspan="3">
                     <asp:CheckBox ID="ishangshi" runat="server" />     </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" Text="添加信息" OnClick="Button1_Click"/> 
                    &nbsp;<a href ="qygl.aspx" class="buttonLB1" >返回企业管理</a>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                </td>
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
