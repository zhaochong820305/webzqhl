<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengshulist.aspx.cs" Inherits="admin_zhengshulist" Debug="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>证书列表</title>

    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <style>
        *{margin:0; padding:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
   <div id="tab1" class="taba" style="display:block;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div style="height:60px;width:100%">&nbsp;&nbsp;&nbsp;&nbsp;标题：<asp:TextBox ID="title" Width="200px" CssClass="inputLB" runat="server"></asp:TextBox>
            &nbsp;分类：<asp:DropDownList  CssClass="inputLB" Width="200px"  ID="fl" runat="server"></asp:DropDownList>
            <asp:Button ID="ss" CssClass="buttonLB" runat="server" Text="搜索" OnClick="ss_Click" />&nbsp;
            <asp:Button ID="Button1" CssClass="buttonLB" runat="server" Text="生成缩微图" OnClick="Button1_Click" />&nbsp;
            <asp:Button ID="Button2" CssClass="buttonLB" runat="server" Text="生成水印缩微图" OnClick="Button2_Click" />&nbsp;
        </div>
        <div style="float:left;height:500px;margin-top:0px;line-height:40px;width:90%;margin-left:19px;">
            <table border="0" style="width:100%;height:10%;padding: inherit; margin: 0 auto; border: thin solid #eac998;">
                <tr><td style="vertical-align:top;background-color:#F7F7DE; " width="100%">

                    <asp:GridView ID="myGrid" Width="880px" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound">
                        <Columns>
                             <asp:BoundField DataField="typename" HeaderText="证书类别" />
                                <asp:BoundField DataField="zhengshuname" HeaderText="证书名称"  />
                                <asp:BoundField DataField="zhengshuno" HeaderText="证书编号" />
                                <%--<asp:BoundField DataField="zhengshufile" HeaderText="证书文件"  />--%>
                                <asp:BoundField DataField="update" HeaderText="收录时间" DataFormatString="{0:yyyy-MM-dd}"  />
                                <asp:TemplateField HeaderText="操作">
                                    <ItemTemplate>
                                        <%--<asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">报表</asp:LinkButton>--%>
                                        <a href="ZhengshuAdd.aspx?id=<%# Eval("ID") %>&op=kan&cid=<%=cid%>">查看</a>
                                        <a href="ZhengshuAdd.aspx?id=<%# Eval("ID") %>&op=edit&cid=<%=cid%>">编辑</a>
                                        <asp:LinkButton ID="zs" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该证书数据么?&quot;)==false)return false;" OnCommand="ZS_Command">删除</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
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

                    </td></tr>
           </table>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </div> 
                
           </ContentTemplate></asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
