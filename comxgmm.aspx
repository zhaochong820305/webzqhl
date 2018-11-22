<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comxgmm.aspx.cs" Inherits="comxgmm" %>

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
         当前位置：修改密码：
        <table border="0" style="margin-left:20px;width:400px;height:250px;">
                <tr>
                    <td style="text-align:right">当前密码：</td>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="passwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right"> 新密码：</td>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="newpass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td style="text-align:right">确认密码：</td>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="confirmpass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                
                <tr>
                    <td>
                        &nbsp;</td>
                    <td> 
                        <asp:Label ID="msgb" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="Button2" runat="server" class="buttonLB" Text="   保 存   " width="100px" OnClick="Button2_Click" />
                    </td>
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
