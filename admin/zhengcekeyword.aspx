<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhengcekeyword.aspx.cs" Inherits="admin_zhengcekeyword" %>

<%@ Register Src="~/Admin/include/setlistlink.ascx" TagPrefix="uc1" TagName="setlistlink" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <style>
        *{margin:5px; padding:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left">      
        <%--        <uc1:setlistlink runat="server" id="setlistlink" />--%>
        <hr Width="874px">
 
        添加: 请输入类型：<asp:TextBox CssClass="inputLB" ID="TextBox1" runat="server" Height="30px"></asp:TextBox> &nbsp; &nbsp;<asp:Button ID="Button1" runat="server" Text="添加" class="buttonLB1" OnClick="Button1_Click" Height="30px" Width="80px" />
              <a <% if (stype == "41") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="HangYeZC2.aspx?type=41">+二级行业分类</a>&nbsp;
        <br />
        <br /><hr Width="874px" /><asp:Label ID="Label1" runat="server" ForeColor="#FF0066"></asp:Label>
             <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID"
                        ForeColor="#333333" GridLines="None"   OnRowEditing="myGrid_RowEditing" PageSize="14" AllowPaging="True"  OnPageIndexChanging="myGrid_PageIndexChanging" 
                        OnRowUpdating="myGrid_RowUpdating" OnRowCancelingEdit="myGrid_RowCancelingEdit" Width="874px" CssClass="mGrid"
                PagerStyle-CssClass="pgr" >
                 <RowStyle Height="28px" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="参数值" ReadOnly="true"   />
                            <asp:BoundField DataField="name" HeaderText="参数名称" />
                            <asp:CommandField HeaderText="编辑" ShowEditButton="True" >
                            <FooterStyle ForeColor="Blue" />
                            <ItemStyle ForeColor="Blue" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                   
                                 <%--   <a href="projectedit.aspx?id=<%# Eval("ID") %>" >编辑</a>  
                                   --%>
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

