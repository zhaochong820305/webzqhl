<%@ Page Language="C#" AutoEventWireup="true" CodeFile="qiyeonline.aspx.cs" Inherits="admin_qiyeonline" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>企业在线提交</title>

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
         &nbsp;<a href ="qygl.aspx">返回企业管理</a>
   <div id="tab1" class="taba" style="display:block;width:100%;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div style="height:60px;width:100%">
        </div>
        <div style="float:left;height:500px;margin-top:0px;line-height:40px;width:90%;">
            <table border="0" style="width:100%;height:10%;padding: inherit; margin: 0 auto; border: thin solid #eac998;">
                <tr><td style="vertical-align:top;background-color:#F7F7DE" width="100%">

                    <asp:GridView ID="myGrid" Width="100%" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="企业序号" />
                            <asp:BoundField HeaderText="企业号称" DataField="Name" />
                            <asp:BoundField DataField="Contact" HeaderText="联系人" />
                            <asp:BoundField DataField="Tel" HeaderText="电话" />
                            <asp:BoundField DataField="CreateDate" HeaderText="提交时间" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                  <%--  <asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">编辑</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该用户么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>--%>
                                    <a href='online.aspx?id=<%# Eval("ID") %>' >查看</a> 
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


    
    

        </div> 
                
                                                              </ContentTemplate></asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
