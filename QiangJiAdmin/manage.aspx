<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="admin_manage" %>

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
     <a class="buttonLB1" href="manage.aspx">+用户管理</a>&nbsp;<a class="buttonLB1" href="tunjian.aspx">+推荐人列表</a>&nbsp;<a class="buttonLB1" href="bumen.aspx">+部门管理</a>&nbsp;
        <br />
        <br />
        <hr Width="874px">
         &nbsp; 登陆名：<asp:TextBox CssClass="inputLB" ID="TextBox1" runat="server" Height="30px" Width="170px"></asp:TextBox>
         &nbsp; &nbsp;姓名：<asp:TextBox  CssClass="inputLB" ID="TextBox2"  Height="30px" runat="server" Width="170px"></asp:TextBox>
         &nbsp; &nbsp;状态：<asp:DropDownList ID="tbEnabled" runat="server" Height="30px" Width="170px">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                    <asp:ListItem Value="">全部</asp:ListItem>                                 
                                </asp:DropDownList> 
         &nbsp; &nbsp;<asp:Button CssClass="buttonLB1" ID="Button1"  Height="30px"  Width="91px" runat="server" Text="查询" OnClick="Button1_Click" />
     
         &nbsp; &nbsp;<asp:Button CssClass="buttonLB1" ID="Button2" runat="server"  Height="30px"  Width="160px"  Text="添加用户" OnClick="Button2_Click" />
        <hr Width="874px" /><asp:Label ID="Label1" runat="server" ForeColor="#FF0066"></asp:Label>
        <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserID"
                        ForeColor="#333333" GridLines="None"   OnRowEditing="myGrid_RowEditing" AllowPaging="True"  PageSize="14" 
                        OnRowUpdating="myGrid_RowUpdating" OnRowCancelingEdit="myGrid_RowCancelingEdit" Width="874px" CssClass="mGrid"
   PagerStyle-CssClass="pgr" OnPageIndexChanging="myGrid_PageIndexChanging"  >
                 <RowStyle Height="28px" />
                        <Columns>                           
                          
                            <asp:BoundField DataField="UserID" HeaderText="用户ID" ReadOnly="true"   />
                            <asp:BoundField DataField="LoginName" HeaderText="登陆名" />
                            <asp:BoundField DataField="RealName" HeaderText="真实姓名" />
                            <asp:BoundField DataField="Title" HeaderText="头衔" />
                            <asp:BoundField DataField="SexName" HeaderText="性别" />
                          <%--  <asp:BoundField DataField="Email" HeaderText="电子邮件" />--%>
                            <asp:BoundField DataField="MobilePhone" HeaderText="手机号码" />
                            <asp:BoundField DataField="OfficePhone" HeaderText="办公电话" />
                            <asp:BoundField DataField="HomePhone" HeaderText="家庭电话" />
                            <asp:BoundField DataField="EnName" HeaderText="状态" />
                            <asp:BoundField DataField="IsAgentName" HeaderText="是否坐席" />
                            <asp:BoundField DataField="CreateDate" HeaderText="添加时间" />
                           <%-- <asp:CommandField HeaderText="编辑" ShowEditButton="True" >--%>
                            <%--<FooterStyle ForeColor="Blue" />
                            <ItemStyle ForeColor="Blue" />
                            </asp:CommandField>--%>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>                                   
                                    <a href="useradd.aspx?id=<%# Eval("UserID") %>&op=edit" >编辑</a>
                                    <asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("UserID") %>' OnClientClick="if(confirm(&quot;确定要删除该项目数据么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton> 
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
