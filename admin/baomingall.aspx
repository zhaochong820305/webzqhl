﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baomingall.aspx.cs" Inherits="admin_baomingall" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <div  style="float:left;height:500px;margin-top:30px;line-height:40px;width:100%;margin-left:20px;">
        <div  style="float:left;height:100px;margin-top:30px;line-height:40px;width:880px;">
       
            企业名称：  <asp:TextBox ID="company" runat="server" Width="100px" CssClass="inputLB"></asp:TextBox>
            姓名：      <asp:TextBox ID="name" runat="server" Width="100px" CssClass="inputLB"></asp:TextBox>
            
            <asp:Button ID="ss" CssClass="buttonLB" runat="server" Text="搜索" OnClick="ss_Click" />   
           <%-- <%if (Session["title"].ToString() != "6")
                { %>
            <a href="diaocha.aspx" target="_blank">"IGBT" 企业调研表</a> &nbsp;&nbsp;&nbsp;&nbsp;
            <a href="diaoyitiao.aspx" >"一条龙" 企业调研表</a>
            <%} %>--%>

           
            <%--&nbsp;&nbsp;<a href="diaoqiye.aspx" >优秀企业需求信息</a>--%>
            <asp:Button ID="Button1" CssClass="buttonLB" runat="server" Text="导出excel" OnClick="btnExcel_Click" />   
         </div>   
         
         <%-- <div class="con-ns"><img src="http://www.liantu.com/api.php?bg=ffffff&fg=000000&gc=000000&el=L&text=http://m.miit-kjcg.org/mingpian.aspx?uid=<%=Session["userid"] %>&loginname=<%=Session["adminloginuser"] %>&title=<%=Session["title"] %>" style="width: 100px; height: 100px;"></div>--%>
    <asp:GridView ID="myGrid" Width="880px" Height="100%" runat="server"
                       CssClass="mGrid"
    PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound">
                        <Columns>
                            <%-- <asp:BoundField DataField="ID" HeaderText="ID" >
                            <HeaderStyle Width="30px" />                           
                            </asp:BoundField>--%>
                           <%-- <asp:BoundField HeaderText="联系人" DataField="Contact" />--%>
                           
                            <%--<asp:BoundField DataField="CName" HeaderText="企业名称"  />--%>
                            <%-- <asp:TemplateField HeaderText="企业名称" DataField="company" >
                           
                                <ItemTemplate>                                 
                                    <a href="qiyelist.aspx?id=<%# Eval("company") %>" ><%# Eval("company") %></a>   
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:BoundField DataField="cname" HeaderText="企业名称" />
                            <asp:BoundField DataField="name" HeaderText="参会人姓名" />
                            <asp:BoundField DataField="sex" HeaderText="参会人性别" />
                            <asp:BoundField DataField="title" HeaderText="参会人职务" />
                            <asp:BoundField DataField="tel" HeaderText="参会人电话" />
                            <asp:BoundField DataField="ContactTel" HeaderText="联系人电话" />
                            <asp:BoundField DataField="Contact" HeaderText="联系人" />
                            <asp:BoundField DataField="email" HeaderText="电子邮箱" />
                            <asp:BoundField DataField="address" HeaderText="地址" />
                            <asp:BoundField DataField="zipcode" HeaderText="邮编" />
                            <asp:BoundField DataField="chuxi" HeaderText="联系人是否出席" />
                            <asp:BoundField DataField="update" HeaderText="报名时间" />
                           
                            
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
          <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" 
              Mode="NumericFirstLast" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="center" />
        <PagerTemplate>  
        <table border="0" style="width:100%;">  
            <tr>  
                <td style="text-align: center;color: Black;font-size: 10pt;font-family: 宋体;text-decoration: none;">  
   
                    第<font style="font-family: Tahoma;color: Red"><%=PgIndex+ 1 %></font>页  
                    共<font style="font-family: Tahoma;color: Red"><%=PgCount %></font>页                   共<font style="font-family: Tahoma;color: Red"><%=RCount %></font>条                   
                    <asp:LinkButton ID="btnFirst" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="first" CommandName="Page" OnClick="btnGridView_Click" Text="首页" />  
                    <asp:LinkButton ID="btnPrev" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="prev" CommandName="Page" OnClick="btnGridView_Click" Text="上一页" />  
                    <asp:LinkButton ID="btnNext" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="next" CommandName="Page" OnClick="btnGridView_Click" Text="下一页" />  
                    <asp:LinkButton ID="btnLast" runat="server" CssClass="font_color" CausesValidation="False" CommandArgument="last" CommandName="Page" OnClick="btnGridView_Click" Text="尾页" />  
                </td>  
            </tr>  
        </table>  
    </PagerTemplate>  
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
                    </asp:GridView>
    </div>
    </form>
</body>
</html>
