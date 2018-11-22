<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mingpianadd.aspx.cs" Inherits="admin_mingpianadd" %>

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
            <tr>
                <th class="active">企业名称：</th>
                <td colspan="3"><asp:TextBox ID="company" runat="server" Width="681px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>
            <tr>
                <th class="active">姓名：</th>
                <td>
                    <asp:TextBox ID="name" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">商务电话：</th>
                <td>
                    <asp:TextBox ID="tel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="auto-style1">详细地址：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="address" runat="server" Width="280px"></asp:TextBox></td>
                <%--<th class="auto-style1">邮政编码：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="tbzipcode" runat="server" Width="280px"></asp:TextBox></td>--%>
            </tr>
            <tr>
                <th class="active">电子邮箱：</th>
                <td>
                    <asp:TextBox ID="email" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">手机：</th>
                <td>
                    <asp:TextBox ID="modtel" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">部门：</th>
                <td>
                    <asp:TextBox ID="deptname" runat="server" Width="280px"></asp:TextBox></td>
                <th class="active">职称：</th>
                <td>
                    <asp:TextBox ID="title" runat="server" Width="280px"></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">商务传真：</th>
                <td colspan="3">
                    <asp:TextBox ID="fax" runat="server" Width="683px" ></asp:TextBox></td>
            </tr>
            <tr>
                <th class="active">商务网址：</th>
                <td colspan="3">
                    <asp:TextBox ID="url" runat="server" Width="683px" ></asp:TextBox>
                    </td>
            </tr>
            <tr>
                <th class="active">所属行业：</th>
                <td colspan="3">
                   <asp:DropDownList ID="ddlqiyexz" runat="server"></asp:DropDownList></td>
            </tr>
            <tr>
                <th class="active">所属业务员：</th>
                <td colspan="3">
                   <asp:DropDownList ID="yewu" runat="server"></asp:DropDownList></td>
            </tr>
            
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button CssClass="buttonLB1" ID="Button1" runat="server" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" CssClass="buttonLB1" runat="server" Text="修改信息" OnClick="Button2_Click"/>
                    &nbsp;<a href ="mingpian.aspx" class="buttonLB1" >返回名片管理</a>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                </td>
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
