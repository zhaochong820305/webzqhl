<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamAdd.aspx.cs" Inherits="admin_TeamAdd" %>

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
                <th class="active" style="width: 150px;" colspan="4">添加团队数据：<br />
             <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">姓名：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbName" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 150px;">学历：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbXueLi" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">专业：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbZhanYe" runat="server" Width="708px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">职位：</th>
                <td colspan="3">
                    <asp:DropDownList ID="ZhiWei" runat="server"></asp:DropDownList>
                    
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">上市公司任职情况：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbRenZhi" runat="server" Width="708px" TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">简历：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbJianLi" runat="server" Width="708px" TextMode="MultiLine" Height="80px"> </asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" CssClass="buttonLB1" runat="server" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" CssClass="buttonLB1" runat="server" Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                    <a href ="qygl.aspx" class="buttonLB1">返回企业管理</a>  
                    <a href ="qiyeedit.aspx?id=<%=icompanyid%>" class="buttonLB1">返回编辑信息</a></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
