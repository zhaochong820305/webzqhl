<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reg.aspx.cs" Inherits="reg" %>
 
<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>
 

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>注册页面</title>
<link rel="stylesheet" href="css/base.css" />
<link rel="stylesheet" href="css/style.css" />
 
</head>

<body>
    <uc1:menu runat="server" ID="menu" />
<div class="bottom"></div>
    <form  runat="server" id="form1" class="form1">
            <div class="warp" style="margin-left:300px;" >
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server"><ContentTemplate>
                    <center>
                    <table border="0" style="width:600px;height:350px;">
                        <tr><td style="height:50px;"></td><td></td></tr>
                        <tr>
                            <td style="width:100px; color:#333; font-weight:600;">用户名：</td>
                            <td align="left">
                                <asp:TextBox name="user" type="text" CssClass="butt" id="user"  style="width:205px;" ng-model="user"  runat="server"></asp:TextBox>
                                
                                <span style="color:#F00" ng-show="form1.user.$dirty && form1.user.$invalid">
                    				<span ng-show="form1.user.$error.required"></span>
                    			</span>
                            </td>
                        </tr>
                        <tr>
                            <td style=" color:#333; font-weight:600;"> 密&nbsp;&nbsp;&nbsp;码：</td>
                            <td  align="left">
                                <asp:TextBox ID="pass" name="pass" type="password" TextMode="Password" style="width:205px;" ng-model="pass"   runat="server"></asp:TextBox>
                                
                                <span style="color:#F00" ng-show="form1.pass.$dirty && form1.pass.$invalid">
                    				<span ng-show="form1.pass.$error.required"></span>
                    			</span>
                            </td>								
                        </tr>
                        <tr>
                            <td style=" color:#333; font-weight:600;"> 密码确认：</td>
                            <td  align="left">
                                <asp:TextBox ID="pass2" name="pass" type="password" TextMode="Password" style="width:205px;" ng-model="pass"   runat="server"></asp:TextBox>
                                
                                <span style="color:#F00" ng-show="form1.pass.$dirty && form1.pass.$invalid">
                    				<span ng-show="form1.pass.$error.required"></span>
                    			</span>
                            </td>								
                        </tr>
                        <tr>
                            <td style=" color:#333; font-weight:600;"> 用户分类：</td>
                            <td>
                                
                                <asp:DropDownList id="usertypes" runat="server" width="205px">     
                                   
                                </asp:DropDownList><font color="red"> 用户分类一经选择不能修改</font>
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
                                <asp:Button name="Button1" value="  注 册  " id="Button1" style=" color:#fff; background-color:#69C; font-weight:600;"  runat="server" Text=" 注 册 " OnClick="Button1_Click" />
                                <asp:Label ID="msg" runat="server" ForeColor="#CC0000"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a href="login.aspx">已经注册用户登陆 </a>
                                </td>
                        </tr>
                        <tr>
                            <td ></td>
                            <td style="text-align:left; color:#333;" ></td>
                        </tr>
                    </table></center>
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
     <uc1:footer runat="server" id="footer" />
</html>

