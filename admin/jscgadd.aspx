<%@ Page Language="C#" AutoEventWireup="true" CodeFile="jscgadd.aspx.cs" Inherits="admin_jscgadd" %>

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
                <th class="auto-style4">选择企业：</th>
                <td colspan="3">
                    <div class="input-group">
<asp:DropDownList ID="ddlCompany" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">项目名称：</th>
                <td >
                    <asp:TextBox ID="tbName" Width="246px" runat="server"></asp:TextBox>
                </td>
                 <th class="auto-style3">技术水平：</th>
                <td >
                    <asp:DropDownList ID="ddljishu" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">所属行业：</th>
                <td >
                     <asp:DropDownList ID="ddlhangye" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            
                <th class="auto-style3">成果类型：</th>
                <td >
                     <asp:DropDownList ID="ddlchengguo" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style5">所处阶段：</th>
                <td class="auto-style6" >
                    <asp:TextBox ID="tbjieduan" runat="server" Width="246px"></asp:TextBox>
                </td>
            
                <th class="auto-style3">技术成果来源：</th>
                <td class="auto-style6" >
                   
                     <asp:DropDownList ID="ddllaiyuan" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4"  >关键词：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="tbKey" runat="server" Width="246px" ></asp:TextBox>
                </td>
                <th class="auto-style3" >合作方式：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbhezuo" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">总投资（万元）：</th>
                <td >
                    <asp:TextBox ID="tbtouzi" Width="246px" runat="server"></asp:TextBox>
                </td>
            
                <th class="auto-style3">设备投资（万元）：</th>
                <td >
                    <asp:TextBox ID="tbshebei" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">新增利润（万元）：</th>
                <td >
                   <asp:TextBox ID="tblirui" Width="246px" runat="server"></asp:TextBox>
                </td>
            
                <th class="auto-style3">节省成本（万元）：</th>
                <td >
                   <asp:TextBox ID="tbjieye" Width="246px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">技术先进性说明：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbxianjin" runat="server" Width="730px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="auto-style4">主要技术参数：</th>
                <td colspan="3">
                    <asp:TextBox ID="tbcanshu" runat="server" Width="730px"></asp:TextBox>
                </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" OnClick="Button1_Click" Text="添加" />
                    <asp:Label ID="Label1" runat="server"    style="text-align: center" ForeColor="#FF3300"></asp:Label>
                    <a href="jscg.aspx" class="buttonLB1">返回技术成果</a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
