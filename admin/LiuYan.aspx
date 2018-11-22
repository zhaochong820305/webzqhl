<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LiuYan.aspx.cs" Inherits="admin_LiuYan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left;height:500px;margin-top:70px;line-height:40px;width:90%;margin-left:19px;">
    <%--成果留言--%>
        <asp:GridView ID="myGrid" Width="860px" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="编号" >
                            <HeaderStyle Width="30px" />                           
                            </asp:BoundField>
                            <asp:BoundField HeaderText="成果名称" DataField="RName" />
                            <asp:BoundField HeaderText="留言内容" DataField="Contact" />
                            <%--<asp:BoundField DataField="CName" HeaderText="企业名称"  />--%>
                            <asp:TemplateField HeaderText="会员详细">
                           
                                <ItemTemplate>                                 
                                    <a href="qiyelist.aspx?id=<%# Eval("CompanyID") %>" ><%# Eval("CName") %></a>   
                                </ItemTemplate>
                            </asp:TemplateField>
                          <%--  <asp:BoundField DataField="naturename" HeaderText="项目性质" />--%>
                           
                        <%--    <asp:BoundField DataField="MilitaryName" HeaderText="军工情况" />--%>
                           
                        <%--    <asp:BoundField DataField="Scale" HeaderText="建设规模" />--%>
                          
                            <asp:BoundField DataField="updates" HeaderText="收录时间"  DataFormatString="{0:yyyy-MM-dd}"  />
                           
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <%--<a href="LiuYanlist.aspx?id=<%# Eval("ID") %>" >查看</a> --%>  
                                    <%--<a href="projectedit.aspx?id=<%# Eval("ID") %>" >编辑</a>  
                                    <a href="HeZuolist.aspx?pid=<%# Eval("ID") %>" >合作</a>    --%>
                                    <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该项目数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>
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
    </div>
    </form>
</body>
</html>
