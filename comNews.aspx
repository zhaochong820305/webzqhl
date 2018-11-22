<%@ Page Language="C#" AutoEventWireup="true" CodeFile="comNews.aspx.cs" Inherits="comNews" %>

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
         当前位置：添加需求信息：
         <table class="gridtable"      id="list8">            
            <tr>
                <th class="active">标题：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="title" runat="server" BorderWidth="1"   Width="670px" ></asp:TextBox>   </td>
                
            </tr>
            <%--<tr>
                <th class="active">政策扶持：</th>
                <td colspan="3"> <asp:TextBox CssClass="inputLB"  ID="zhengce" runat="server" BorderWidth="1" Height="19px" Width="670px"></asp:TextBox>
                    &nbsp;</td>
                
            </tr>--%>
             <tr>
                <th class="active">内容：</th>
                <td>
                    <asp:TextBox CssClass="inputLB"  ID="Contents" runat="server" BorderWidth="1" TextMode="MultiLine" Height="80px" Width="670px"></asp:TextBox>   </td>
                
            </tr>
             
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="Button1" runat="server"  CssClass="buttonLB1" Text="添加企业动态信息" OnClick="Button1_Click"/>
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                   
                    <asp:Label ID="Label10" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                
                     
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
