<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xgmm.aspx.cs" Inherits="admin_xgmm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
  
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <style>
        *{margin:0; padding:0;}
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <div id="tab2" class="taba" style="display:block;">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
          
        <div style="float:left;height:80px;margin-top:30px;line-height:40px;width:400px;margin-left:20px">
            <table class="gridtable" >
                
                <tr>
                    <th class="active" >当前密码：</th>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="passwd" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="active" > 新密码：</th>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="newpass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <th class="active" >确认密码：</th>
                    <td>
                        <asp:TextBox CssClass="inputLB" ID="confirmpass" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                
              
                <tr>
                    <td></td>
                    <td> <asp:Label ID="msgb" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Button ID="Button2" runat="server" class="buttonLB" Text="   保 存   " width="100px" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
            <table  class="gridtable" width="800px" >
                    <tbody style="box-sizing: border-box;">
                        <tr style="box-sizing: border-box;">
                            <th class="active" >登 录 名：</th>
                            <td >
                                <asp:Label ID="tbUser" runat="server" Height="30px" Width="245px"></asp:Label>
                            </td>
                            <th class="active" >真实姓名：</th>
                            <td >
                                
                                <asp:TextBox ID="RealName" CssClass="inputLB"  runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        
                        
                        <tr style="box-sizing: border-box;">
                            <th class="active" >手机号码：</th>
                            <td >
                                <asp:TextBox ID="tbTel" CssClass="inputLB"  runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                            <th class="active" >办公电话：</th>
                            <td >
                                <asp:TextBox ID="tbOfficTel" CssClass="inputLB"  runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" >家庭电话：</th>
                            <td >
                                <asp:TextBox ID="tbHomeTel" CssClass="inputLB"  runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                            <th class="active" >电子邮件：</th>
                            <td >
                                <asp:TextBox ID="tbEmail" CssClass="inputLB"  runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" >微信二维码上传：</th>
                            <td colspan="3">
                                 <asp:FileUpload ID="upfile1" class="buttonLB" runat="server" /> 扫描二维码添加好友
                                 <%--<asp:Button ID="Button1" class="buttonLB" runat="server" Text="上传" OnClick="Button1_Click" />--%>
                            </td>
                            
                        </tr>
                         <tr style="box-sizing: border-box;">
                            <th class="active" >微信二维码显示：</th>
                            <td colspan="3">
                                <asp:Image ID="imgh" runat="server" Height="200px" Width="200px" /> 
                            </td>
                            
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" >个人头像上传：</th>
                            <td colspan="3">
                                 <asp:FileUpload ID="FileUpload1" class="buttonLB" runat="server" />  （长：118*高130）
                                 <%--<asp:Button ID="Button1" class="buttonLB" runat="server" Text="上传" OnClick="Button1_Click" />--%>
                            </td>
                            
                        </tr>
                         <tr style="box-sizing: border-box;">
                            <th class="active" >个人头像显示：</th>
                            <td colspan="3">
                                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
                            </td>
                            
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <td colspan="4" style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); text-align: center;">
       
                                <span class="Apple-converted-space">&nbsp;&nbsp;</span>
                                
                                
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button   ID="Button4" runat="server" Text="修改" style="box-sizing: border-box; margin: 0px; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 1em; line-height: 1.5; text-transform: none; cursor: pointer; -webkit-appearance: button; display: inline-block; padding: 5px 10px; font-weight: normal; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid rgb(76, 174, 76); border-radius: 3px; -webkit-user-select: none; color: rgb(255, 255, 255); background-image: none; background-color: rgb(92, 184, 92);" OnClick="Button3_Click" />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
        </div>
    </div>
    </form>
</body>
</html>