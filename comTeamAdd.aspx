<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comTeamAdd.aspx.cs" Inherits="comTeamAdd" %>

<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>
<%@ Register Src="~/include/left.ascx" TagPrefix="uc1" TagName="left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>编辑企业信息</title>

<link rel="stylesheet" href="css/style.css" />
<link rel="stylesheet" href="css/company.css" />
</head>

<body>
    
    <uc1:menu runat="server" ID="menu" />

    <form  runat="server" id="form1" class="form1">
         
        <uc1:left runat="server" ID="left" />   
        <div class="rightmenu">
         当前位置：添加团队信息：
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
                    <asp:TextBox ID="tbJianLi" runat="server" Width="708px"  TextMode="MultiLine" Height="80px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" CssClass="buttonLB1" runat="server" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" CssClass="buttonLB1" runat="server" Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                    <%--<a href ="qygl.aspx" class="buttonLB1">返回企业管理</a>  
                    <a href ="qiyeedit.aspx?id=<%=icompanyid%>" class="buttonLB1">返回编辑信息</a></td>--%>
            </tr>
        </table>
       </div>
    </form>
</body>
<script src="js/angular.min.js" type="text/javascript"></script>
<script>
	var app=angular.module("lesson",[]);
	app.controller("formContr",function($scope){
		$scope.form1={};		
		});
</script>
     <uc1:footer runat="server" id="footer" />
</html>
