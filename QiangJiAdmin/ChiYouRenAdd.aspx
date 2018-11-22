<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChiYouRenAdd.aspx.cs" Inherits="admin_ChiYouRenAdd" %>

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
                <th class="active" style="width: 150px;" colspan="4"> 添加成果持有人数据：<br />
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">成果持有人：</th>
                <td colspan="3">
                    <asp:TextBox ID="CName" runat="server" Width="708px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">联系人：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="CLianXi" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 150px;">电话：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="Tel" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">职称：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="Title" runat="server" Width="250px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 120px;">邮箱：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="email" runat="server" Width="264px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">单位性质：</th>
                <td class="auto-style2">
           <%--         <asp:TextBox ID="danwenxz" runat="server" Width="250px"></asp:TextBox>--%>
                      <asp:DropDownList ID="danwenxz" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    </td>
                <th class="active" style="width: 120px;">地区：</th>
                <td class="auto-style1">
<%--                    <asp:TextBox ID="diqu" runat="server" Width="264px"></asp:TextBox>--%>
                    <asp:DropDownList ID="diqu" runat="server" Height="22px" Width="246px">
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" >通讯地址：</th>
                <td colspan="3">
                    <asp:TextBox ID="addr" runat="server" Width="700px" Height="50px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active">简介：</th>
                <td colspan="3">
                    <asp:TextBox ID="jianjie" runat="server" Width="700px" Height="50px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                   <%-- <a href ="Results.aspx" class="buttonLB1">返回成果交易</a> --%><%-- <a class="buttonLB1" href ="ResultEdit.aspx?id=<%=icompanyid%>">返回编辑信息</a>--%></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>