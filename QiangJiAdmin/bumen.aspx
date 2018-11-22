<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bumen.aspx.cs" Inherits="admin_bumen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <link href="css/main.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/grid.css" rel="stylesheet" />
     <style>
        *{margin:5px; padding:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left; ">      
       
        
        

        <a class="buttonLB1" href="manage.aspx">+用户管理</a>
        &nbsp;<a class="buttonLB1" href="tunjian.aspx">+推荐人列表</a>
        &nbsp;<a class="buttonLB1" href="bumen.aspx">+部门管理</a>&nbsp;
        <br />
        
        <hr  width="874px">
        <%--   <asp:GridView ID="myGrid" Width="1100px" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True" OnRowDataBound="myGrid_RowDataBound" OnRowEditing="myGrid_RowEditing"
                        OnRowUpdating="myGrid_RowUpdating">--%>
        
        &nbsp;添加: 部门名称：<asp:TextBox CssClass="inputLB" ID="TextBox1" runat="server" Width="100px" Height="30px"></asp:TextBox>
        排序： <asp:TextBox CssClass="inputLB" ID="TextBox2" runat="server" Width="100px" Height="30px"></asp:TextBox>
        部门简介： <asp:TextBox CssClass="inputLB" ID="TextBox3" runat="server" Width="100px" Height="30px"></asp:TextBox>
         &nbsp;<asp:Button CssClass="buttonLB1" ID="Button1" runat="server" Text="添加" OnClick="Button1_Click"  Height="30px" Width="80px"/>
        <br />
        <br /><hr width="874px"><asp:Label ID="Label1" runat="server" ForeColor="#FF0066"></asp:Label>
             <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="DepartmentID"
                        ForeColor="#333333" GridLines="None"   OnRowEditing="myGrid_RowEditing" OnRowDataBound="myGrid_RowDataBound"
                     PageSize="14" AllowPaging="True"  OnPageIndexChanging="myGrid_PageIndexChanging"    OnRowUpdating="myGrid_RowUpdating" OnRowCancelingEdit="myGrid_RowCancelingEdit"  Width="874px" CssClass="mGrid"
   PagerStyle-CssClass="pgr" >
                        <RowStyle Height="28px"   />
                        <Columns>                           
                          
                            <asp:BoundField DataField="DepartmentID" HeaderText="部门ID"  ItemStyle-Width="80px"  ReadOnly="True"/>
                            <asp:BoundField DataField="DepartmentName" HeaderText="部门名称"  ItemStyle-Width="100px"/>
                            <asp:BoundField DataField="Description" HeaderText="部门描述" ItemStyle-Width="500px" />
                            <asp:BoundField DataField="SequenceNo" HeaderText="排序"  ItemStyle-Width="100px"/>
                           
                            <asp:CommandField HeaderText="编辑" ShowEditButton="True" ItemStyle-Width="100px">
                            <FooterStyle ForeColor="Blue" />
                            <ItemStyle ForeColor="Blue" />
                            </asp:CommandField>
                           <%-- <asp:TemplateField HeaderText="操作"  ItemStyle-Width="50px">
                                <ItemTemplate>--%>
                                   
                                 <%--   <a href="projectedit.aspx?id=<%# Eval("ID") %>" >编辑</a>  
                                   --%>
                                    <%--<asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("DepartmentID") %>' OnClientClick="if(confirm(&quot;确定要删除该项目数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton> --%>
                                <%--</ItemTemplate>
                            </asp:TemplateField>--%>
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
