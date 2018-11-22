<%@ Page Language="C#" AutoEventWireup="true" CodeFile="useradd.aspx.cs" Inherits="admin_useradd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <div   style="box-sizing : border-box; height:35px; width:800px;zoom: 1; border: 1px solid rgb(231, 143, 8); color: rgb(255, 255, 255); font-weight: bold; border-radius: 4px; padding: 0.4em 1em; position: relative; cursor: move; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 14.3px; font-style: normal; font-variant: normal; letter-spacing: normal; line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; background: url(http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-bg_gloss-wave_35_f6a828_500x100.png) 50% 50% repeat-x rgb(246, 168, 40);">
            <span id="ui-dialog-title-adminPopUp" class="ui-dialog-title" style="box-sizing: border-box; float: left; margin: 0.1em 16px 0.1em 0px;">添加运营管理平台用户</span><a class="ui-dialog-titlebar-close ui-corner-all" href="manage.aspx" role="button" style="box-sizing: border-box; color: rgb(255, 255, 255); text-decoration: none; border-radius: 4px; position: absolute; right: 0.3em; top: 16.1406px; width: 19px; margin: -10px 0px 0px; padding: 1px; height: 18px;"><span class="ui-icon ui-icon-closethick" style="box-sizing: border-box; display: block; text-indent: -99999px; overflow: hidden; width: 16px; height: 16px; margin: 1px; background-image: url(http://admin.miit-kjcg.org/Scripts/jqueryui/css/images/ui-icons_ffffff_256x240.png); background-position: -96px -128px; background-repeat: no-repeat;">close</span></a></div>
        <div id="adminPopUp" class="auto-style1" scrollleft="0" scrolltop="0" style="border-style: none; border-color: inherit; border-width: 0px; box-sizing: border-box; color: rgb(51, 51, 51); padding: 0.5em 1em; zoom: 1; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 14.3px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: 18px; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; min-height: 0px; background: none rgb(255, 255, 255);">
            <div style="box-sizing: border-box; background-color: rgb(255, 255, 255);">
                <table class="table table-bordered" style="box-sizing: border-box; border-collapse: collapse; border-spacing: 0px; max-width: 100%; width: 763px; margin-bottom: 0px; border: 1px solid rgb(221, 221, 221); background-color: transparent;">
                    <tbody style="box-sizing: border-box;">
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">登 录 名：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbUser" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">真实姓名：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbName" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">所在部门：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:DropDownList ID="ddlDept" runat="server" Height="30px" Width="245px">
                                </asp:DropDownList>
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">权限：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                
                                <asp:DropDownList ID="tbTitles" runat="server" Height="30px" Width="245px">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                    <asp:ListItem Value="1">新闻录入员</asp:ListItem>
                                    <asp:ListItem Value="2">业务员</asp:ListItem>
                                    <asp:ListItem Value="3">系统管理员</asp:ListItem>
                                    <asp:ListItem Value="4">名片管理员</asp:ListItem>
                                    <asp:ListItem Value="5">成果交易管理员</asp:ListItem>
                                    <asp:ListItem Value="6">企业报名查询</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">密 码：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbPass" runat="server" Height="30px" Width="245px" TextMode="Password"></asp:TextBox>
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">性别：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:DropDownList ID="ddlSex" runat="server" Height="30px" Width="245px">
                                    <asp:ListItem>女</asp:ListItem>
                                    <asp:ListItem>男</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">手机号码：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbTel" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">办公电话：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbOfficTel" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">家庭电话：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbHomeTel" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">电子邮件：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:TextBox ID="tbEmail" runat="server" Height="30px" Width="245px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">是否座席：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:CheckBox ID="cbZuoXi" runat="server" />
                            </td>
                            <th class="active" style="box-sizing: border-box; text-align: center; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); background-color: rgb(245, 245, 245);">是否启用：</th>
                            <td style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221);">
                                <asp:CheckBox ID="cbQiYong" runat="server" Checked="True" />
                            </td>
                        </tr>
                        <tr style="box-sizing: border-box;">
                            <td colspan="4" style="box-sizing: border-box; padding: 4px; line-height: 1.42857; border: 1px solid rgb(221, 221, 221); text-align: center;">
                                <asp:Button   ID="Button2" runat="server" Text="关闭" style="box-sizing: border-box; margin: 0px 20px 0px 0px; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 1em; line-height: 1.5; text-transform: none; cursor: pointer; -webkit-appearance: button; display: inline-block; padding: 5px 10px; font-weight: normal; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid rgb(212, 63, 58); border-radius: 3px; -webkit-user-select: none; color: rgb(255, 255, 255); background-image: none; background-color: rgb(217, 83, 79);" OnClick="Button2_Click" />
                                <span class="Apple-converted-space">&nbsp;&nbsp;</span>
                                
                                <asp:Button   ID="Button1" runat="server" Text="添加" style="box-sizing: border-box; margin: 0px; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 1em; line-height: 1.5; text-transform: none; cursor: pointer; -webkit-appearance: button; display: inline-block; padding: 5px 10px; font-weight: normal; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid rgb(76, 174, 76); border-radius: 3px; -webkit-user-select: none; color: rgb(255, 255, 255); background-image: none; background-color: rgb(92, 184, 92);" OnClick="Button1_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button   ID="Button3" runat="server" Text="修改" style="box-sizing: border-box; margin: 0px; font-family: 'Trebuchet MS', Tahoma, Verdana, Arial, sans-serif; font-size: 1em; line-height: 1.5; text-transform: none; cursor: pointer; -webkit-appearance: button; display: inline-block; padding: 5px 10px; font-weight: normal; text-align: center; white-space: nowrap; vertical-align: middle; border: 1px solid rgb(76, 174, 76); border-radius: 3px; -webkit-user-select: none; color: rgb(255, 255, 255); background-image: none; background-color: rgb(92, 184, 92);" OnClick="Button3_Click" />
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
