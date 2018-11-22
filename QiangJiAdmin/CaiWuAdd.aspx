<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CaiWuAdd.aspx.cs" Inherits="admin_CaiWuAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
       
        <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;" colspan="4"> 添加财务数据：<br />
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">年份：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbYear" runat="server" Width="708px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">资产负债率(%)：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbfuzhai" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 150px;">研发投入比(%)：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbYanFa" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">企业总资产(万元)：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbZiChan" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 120px;">收入(万元)：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbShouLu" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">利润(万元)：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbLiRun" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 120px;">纳税(万元)：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbNaShui" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" >出口创税(万美元)：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbChuKou" runat="server" Width="250px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                    <a href ="qygl.aspx" class="buttonLB1">返回企业管理</a>  <a class="buttonLB1" href ="qiyeedit.aspx?id=<%=icompanyid%>">返回编辑信息</a></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>