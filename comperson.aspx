<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comperson.aspx.cs" Inherits="comperson" %>

<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/include/left.ascx" TagPrefix="uc1" TagName="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>编辑企业信息</title>
<link rel="stylesheet" href="css/base.css" />
<link rel="stylesheet" href="css/style.css" />
<link rel="stylesheet" href="css/company.css" />
</head>

<body>
    <uc1:menu runat="server" ID="menu" />

    <form  runat="server" id="form1" class="form1">
         
         <uc1:left runat="server" ID="left" />   
         <div class="rightmenu">
         
         当前位置：编辑个人信息 
         <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;" colspan="4"> 编辑个人信息：<br />
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">姓名：</th>
                <td colspan="3">
                    <asp:TextBox ID="CName" runat="server" Width="665px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
               
                <th class="active" style="width: 150px;">电话：</th>
                <td class="auto-style1" colspan="3">
                    <asp:TextBox ID="Tel" runat="server" Width="246px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">职称：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="Title" runat="server" Width="246px"></asp:TextBox>
                    </td>
                <th class="active" style="width: 120px;">邮箱：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="email" runat="server" Width="246px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">单位性质：</th>
                <td class="auto-style2">
           <%--         <asp:TextBox ID="danwenxz" runat="server" Width="250px"></asp:TextBox>--%>
                      <%--<asp:DropDownList ID="danwenxz" runat="server" Height="22px" Width="250px">
                        </asp:DropDownList>--%>
                    <asp:Label ID="danwenxz1" runat="server" Text="个人"></asp:Label>
                    </td>
                <th class="active" style="width: 120px;">地区：</th>
                <td class="auto-style1">
<%--                    <asp:TextBox ID="diqu" runat="server" Width="264px"></asp:TextBox>--%>
                    <asp:DropDownList ID="diqu" runat="server" Height="22px" Width="250px">
                        </asp:DropDownList>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" >通讯地址：</th>
                <td colspan="3">
                    <asp:TextBox ID="addr" runat="server" Width="665px" Height="22px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active">简介：</th>
                <td colspan="3">
                    <asp:TextBox ID="jianjie" runat="server" Width="665px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="添加信息" OnClick="Button1_Click"/> 
                     
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                   <%-- <a href ="Results.aspx" class="buttonLB1">返回成果交易</a> --%><%-- <a class="buttonLB1" href ="ResultEdit.aspx?id=<%=icompanyid%>">返回编辑信息</a>--%></td>
            </tr>
        </table>
    </div>

   
    </form>
</body>
<script src="js/angular.min.js" type="text/javascript"></script>

     <uc1:footer runat="server" id="footer" />
</html>