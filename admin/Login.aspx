<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html>
<html ng-app="lesson" ng-controller="formContr">
<head><meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>管理中心</title>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div class="top">
	<div class="logo"><img src="images/logo.png" /></div>
</div>
<div class="bottom"></div>
    <form  runat="server" id="form1" class="form1">
            <div id="UpdatePanel1">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <table border="0" style="width:100%;height:350px;">
                        <tr><td style="height:50px;"></td><td></td></tr>
                        <tr>
                            <td style="width:100px; color:#333; font-weight:600;">用户名：</td>
                            <td>
                                <asp:TextBox name="user" type="text" id="user"  style="width:300px;" ng-model="user" required runat="server"></asp:TextBox>
                                
                                <span style="color:#F00" ng-show="form1.user.$dirty && form1.user.$invalid">
                    				<span ng-show="form1.user.$error.required"></span>
                    			</span>
                            </td>
                        </tr>
                        <tr>
                            <td style=" color:#333; font-weight:600;"> 密&nbsp;&nbsp;码：</td>
                            <td>
                                <asp:TextBox ID="pass" name="pass" type="password" TextMode="Password" style="width:300px;" ng-model="pass" required  runat="server"></asp:TextBox>
                                
                                <span style="color:#F00" ng-show="form1.pass.$dirty && form1.pass.$invalid">
                    				<span ng-show="form1.pass.$error.required"></span>
                    			</span>
                            </td>								
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align:left;">
                                <span id="msg" style="color:Red;"></span></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="text-align:left;">
                                <asp:Button name="Button1" value="  登  录  " id="Button1" style=" color:#fff; background-color:#69C; font-weight:600;"  runat="server" Text=" 登 录 " OnClick="Button1_Click" />
                                <asp:Label ID="msg" runat="server" ForeColor="#CC0000"></asp:Label>
                                </td>
                        </tr>
                        <tr>
                            <td ></td>
                            <td style="text-align:left; color:#333;">注：请输入用户名密码登录，如果你非管理员，<a href="~/">请访问首页</a>，谢谢。</td>
                        </tr>
                    </table>
                  </ContentTemplate></asp:UpdatePanel>      
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
</html>

