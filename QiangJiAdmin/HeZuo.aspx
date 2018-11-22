<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HeZuo.aspx.cs" Inherits="admin_HeZuo" %>

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
                <th colspan="2" class="auto-style3">项目需求信息:</th>
                
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">合作类别：</th>
                <td>
                    <asp:DropDownList ID="ddlLeiBie" runat="server" Height="25px" Width="327px"></asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">合作方行业：</th>
                <td>
                    <asp:DropDownList ID="ddlHangYe" runat="server" Height="25px" Width="327px"></asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">合作方企业性质：</th>
                <td>
                    <asp:DropDownList ID="ddlXingZhi" runat="server" Height="25px" Width="327px"></asp:DropDownList>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">合作方企业规模：</th>
                <td>
                    <asp:TextBox ID="tbGuiMe" runat="server" Height="16px" Width="320px"></asp:TextBox>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <th class="auto-style3">内容描述：</th>
                <td>
                    <asp:TextBox ID="tbMiaoShu" runat="server" Width="421px" Height="62px"></asp:TextBox>
                </td>
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <td colspan="2" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button4" runat="server" OnClick="Button4_Click" Text=" 添 加 " Height="28px" Width="100px" />
                    <asp:Button CssClass="buttonLB1" ID="Button5" runat="server" OnClick="Button5_Click" Text=" 修 改 " Height="28px" Width="100px" />
                    <asp:Label ID="Label1" runat="server"     ForeColor="#FF3300"></asp:Label>
                    <a href="Project.aspx" class="buttonLB1">返回项目列表</a> 
                    <a href="HeZuoList.aspx?pid=<%=pid %>" class="buttonLB1">返回项目合作需求列表</a> 
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
