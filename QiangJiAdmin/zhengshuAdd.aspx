<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengshuAdd.aspx.cs" Inherits="admin_zhengshuAdd" %>

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
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=1&id=<%=icompanyid %>">编辑成果交易</a>&nbsp;&nbsp;  
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=2&id=<%=icompanyid %>">编辑成果持有人</a>&nbsp;&nbsp; 
<%--        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=3&id=<%=icompanyid %>">编辑合作方式</a>&nbsp;&nbsp; --%> 
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=4&id=<%=icompanyid %>">&nbsp;&nbsp;编辑证书&nbsp;&nbsp;</a>&nbsp;&nbsp;  
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=5&id=<%=icompanyid %>">&nbsp;&nbsp;编辑图片&nbsp;&nbsp;</a>&nbsp;&nbsp;  
        <br><br>
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=7&id=<%=icompanyid %>">&nbsp;&nbsp;编辑视频&nbsp;&nbsp;</a>&nbsp;&nbsp;
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=9&id=<%=icompanyid %>">&nbsp;编辑专家意见&nbsp;</a>&nbsp;&nbsp;  
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=8&id=<%=icompanyid %>">编辑评价结论</a>&nbsp;&nbsp;    
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=1&id=<%=icompanyid %>">返回成果交易</a>&nbsp;&nbsp;
        <a class='buttonLB1 button2'  href="Results.aspx">返回成果列表</a>&nbsp;&nbsp; 
        <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;" colspan="4"> 添加成果证书数据：<br />
            
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">证书类别：</th>
                <td class="auto-style2">
                 <%--   <asp:TextBox ID="zhengshutype" runat="server" Width="250px"></asp:TextBox>--%>
                    <asp:DropDownList ID="zhengshutype" runat="server" Height="22px" Width="262px">
                        </asp:DropDownList>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">证书名称：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="zhengshuname" runat="server" Width="260px"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">证书编号：（专利号、评价报告编号等）</th>
                <td class="auto-style2">
                    <asp:TextBox ID="zhengshuno" runat="server" Width="260px"></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">证书说明：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="text" runat="server" Width="260px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">上传证书照片：</th>
                <td class="auto-style2" colspan="3">
                     <asp:TextBox ID="pic" CssClass="inputLB" MaxLength="100" Width="600px" runat="server" Visible="false"></asp:TextBox>
                     
                     <asp:FileUpload ID="upfile" CssClass="buttonLB" runat="server" /> <asp:Button ID="scfile" CssClass="buttonLB" runat="server" Text=" 上 传 " OnClick="scfile_Click" />
                     <asp:Label ID="msg" Text="" ForeColor="Red" runat="server" ></asp:Label>
                </td>
                
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                    <%-- <a href ="Results.aspx" class="buttonLB1">返回成果交易</a> --%> <%--<a class="buttonLB1" href ="ResultEdit.aspx?id=<%=icompanyid%>">返回编辑信息</a>--%></td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">照片：</th>
                <td class="auto-style2" colspan="3">
                     <asp:Label ID="Label2" runat="server" Text=""  style="text-align: center" ForeColor="Red" Visible="false" ></asp:Label>    
                     <asp:Label ID="Label3" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                     <asp:Image ID="imgh" runat="server" Height="450px" Width="330px" /><br>
                     
                </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">缩微图：</th>
                <td class="auto-style2" colspan="3">
                     <asp:Label ID="Label4" runat="server" Text=""  style="text-align: center" ForeColor="Red" Visible="false" ></asp:Label>    
                     <asp:Label ID="Label5" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                     <asp:Image ID="Image1" runat="server"  /><br>
                     
                </td>
                
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>