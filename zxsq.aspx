<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zxsq.aspx.cs" Inherits="zxsq" %>
<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<uc1:header runat="server" id="header" />
    <link href="css/cgpj.css" rel="stylesheet" >
<body>
    <uc1:menu runat="server" ID="menu" />
<!--内容-->
<!--con-->
<div class="cgpj-con">
    <div class="con-left">
       <%=leftmenu %>
        <div class="con-nav-img">
        	<a href="zxsq.aspx?class=0&fl=5">
            	<img src="images/shenqing.png" width="280">
            	<div class="con-nav-img-c">科技评价在线申请</div>
            </a>
        </div>
    </div>

    <div class="conn">
        <div class="conn-top">
            <div class="conn-top-title1">联系我们</div>
            <div class="conn-top-title2">&nbsp;联系我们</div>
            <div class="conn-top-title3">您当前的位置：&nbsp;></div>
        </div>
        <div class="conn-con">
            <div class="conn-con-c">
 <form runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
     <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            	<table border="1" style="border-collapse:collapse; border:1px solid #eddfdf">
                <caption>企业在线信息提交</caption>
                <colgroup span="1" style="background-color:#eeeded"></colgroup>
                	<tr class="tr">
                    	<td>企业名称</td>
                        <td colspan="3">
                            
                            <asp:TextBox ID="qymc" runat="server" MaxLength="100" placeholder="请输入企业名称"></asp:TextBox>
                        </td>
                    </tr>
                   <tr class="tr1">
                    	<td>联系人</td>
                        <td>
                            <asp:TextBox ID="lxr" runat="server" MaxLength="25" placeholder="请输入联系人"></asp:TextBox></td>
                        <td>联系电话</td>
                        <td>
                            <asp:TextBox ID="lxdh" runat="server" MaxLength="25" placeholder="请输入联系电话"></asp:TextBox></td>
                    </tr>
                    <tr class="tr">
                    	<td>项目名称</td>
                        <td colspan="3">
                            <asp:TextBox ID="xmmc" runat="server" MaxLength="100" placeholder="请输入项目名称"></asp:TextBox></td>
                    </tr>
                    <tr class="tr tr2">
                    	<td>项目介绍</td>
                        <td colspan="3">
                            <asp:TextBox ID="xmjs" runat="server" MaxLength="1000" placeholder="请输入项目介绍"></asp:TextBox></td>
                    </tr>
                    <tr class="tr tr2">
                    	<td>技术优势</td>
                        <td colspan="3">
                            <asp:TextBox ID="jsys" MaxLength="1000" placeholder="请输入技术优势"  runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="tr tr2">
                    	<td>知识产权情况</td>
                        <td colspan="3">
                            <asp:TextBox ID="cqqk" runat="server" MaxLength="1000"  placeholder="请输入知识产权情况"></asp:TextBox></td>
                    </tr>
                    <tr class="tr tr2">
                    	<td>投资进度</td>
                        <td colspan="3">
                            <asp:TextBox ID="tzjd" runat="server" MaxLength="1000" placeholder="请输入投资进度"></asp:TextBox></td>
                    </tr>
                    <tr class="tr tr2">
                    	<td>销售额及利润</td>
                        <td colspan="3">
                            <asp:TextBox ID="xslr" placeholder="请输入销售额及利润" MaxLength="1000"  runat="server"></asp:TextBox></td>
                    </tr>
                    <tr class="tr3">
                        <td colspan="4">
                            <asp:Button ID="bc" runat="server" Text=" 提 交 " OnClick="bc_Click" />
                            
                            <asp:Label ID="msg" runat="server" ForeColor="#CC0000"></asp:Label>
                        </td>
                    </tr>
                </table>
         </ContentTemplate></asp:UpdatePanel>
                </form>
            </div>

        </div>
    </div>
</div>
    <uc1:footer runat="server" id="footer" />
</body>
    
</html>