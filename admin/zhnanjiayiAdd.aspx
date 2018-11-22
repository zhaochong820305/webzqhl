<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhnanjiayiAdd.aspx.cs" Inherits="admin_zhnanjiayiAdd" %>

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
        <a class='buttonLB1 button2' href="Resultedit.aspx?type=2&id=<%=icompanyid %>">编辑成果持有人</a>&nbsp;&nbsp; 
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=3&id=<%=icompanyid %>">编辑合作方式</a>&nbsp;&nbsp;  
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=4&id=<%=icompanyid %>">编辑证书</a>&nbsp;&nbsp;  
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=5&id=<%=icompanyid %>">编辑图片</a>&nbsp;&nbsp;  
        <br><br>
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=7&id=<%=icompanyid %>">编辑视频</a>&nbsp;&nbsp;
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=9&id=<%=icompanyid %>">编辑专家意见</a>&nbsp;&nbsp;  
        <a  class='buttonLB1 button2' href="Resultedit.aspx?type=8&id=<%=icompanyid %>">编辑评价结论</a>&nbsp;&nbsp;    
        <a class='buttonLB1 button2'  href="Resultedit.aspx?type=1&id=<%=icompanyid %>">返回成果交易</a>&nbsp;&nbsp;
        <a class='buttonLB1 button2'  href="Results.aspx">返回成果列表</a>&nbsp;&nbsp; 
        <table class="gridtable">
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;" colspan="4"> 添加专家咨询意见：<br />
            
            
            
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">技术创新程序-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="jishuchuangxin" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">技术经济指标的先进程度-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="jingjizhibiao" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">技术的难度和复杂程序-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="nandu" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">技术重现性和成熟度-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="chengshudu" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">技术创新对推动科技进步和提高市场竟争能力的作用-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="shichangjingzheng" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
             <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">经济或社会效益-评分：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="shehuixiaoyi" runat="server" Width="260px"></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">评分结果：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="PingFen" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 150px;">专家意见：</th>
                <td class="auto-style1">
                    <asp:TextBox ID="YiJian" runat="server" Width="540px" Height="50px" TextMode="MultiLine"></asp:TextBox>
                    </td>
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">专家姓名：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="XingMing" runat="server" Width="260px"></asp:TextBox>
                    </td>
                
            </tr>
            <tr style="page-break-inside: avoid;">
                <th class="active" style="width: 120px;">评分时间：</th>
                <td class="auto-style2">
                    <asp:TextBox ID="Pdate" runat="server" Width="260px" ></asp:TextBox>
                    </td>
                
            </tr>
            
            <tr style="page-break-inside: avoid;">
                <td colspan="4" style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" CssClass="buttonLB1" Text="添加信息" OnClick="Button1_Click"/> 
                    <asp:Button ID="Button2" runat="server" CssClass="buttonLB1"  Text="修改信息" OnClick="Button2_Click"/>
                    <asp:Label ID="Label1" runat="server" Text=""  style="text-align: center" ForeColor="Red" ></asp:Label>                     
                   <%-- <a href ="Results.aspx" class="buttonLB1">返回成果交易</a> --%> <%--<a class="buttonLB1" href ="ResultEdit.aspx?id=<%=icompanyid%>">返回编辑信息</a>--%></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>