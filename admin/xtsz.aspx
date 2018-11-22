<%@ Page Language="C#" AutoEventWireup="true" CodeFile="xtsz.aspx.cs" Inherits="admin_xtsz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
    <link href="css/main.css" rel="stylesheet" />
    <link href="css/ps.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
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
   <div id="tab1" class="taba" style="display:block;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
        <div style="float:left;height:500px;margin-top:0px;line-height:40px;width:1200px;">
            <table border="0" width="100%" height="700px" style="padding: inherit; margin: 0 auto; border: thin solid #eac998;">
                <tr><td style="vertical-align:top;background-color:#F7F7DE" width="60%">

                    <asp:GridView ID="myGrid" Width="100%" Height="100%" runat="server"
                       CssClass="mGrid"
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            AutoGenerateColumns="False" PageSize="14" OnPageIndexChanging="myGrid_PageIndexChanging" 
                      ShowHeaderWhenEmpty="True">
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="编号" >
            <ControlStyle CssClass="hidden" />
            <FooterStyle CssClass="hidden" />
            <HeaderStyle CssClass="hidden" />
            <ItemStyle CssClass="hidden" />
                               </asp:BoundField>
                            <asp:BoundField HeaderText="参数名" DataField="para" />
                            <asp:BoundField DataField="value" HeaderText="参数" />
                            <asp:BoundField DataField="demo" HeaderText="说明" />
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <asp:LinkButton ID="bj" runat="server" CommandArgument='<%# Eval("ID") %>' OnCommand="bj_Command">编辑</asp:LinkButton>
                                    &nbsp;<asp:LinkButton ID="sc" runat="server" CommandArgument='<%# Eval("ID") %>' OnClientClick="if(confirm(&quot;确定要删除该用户么?&quot;)==false)return false;" OnCommand="sc_Command">删除</asp:LinkButton>
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

                    <td width="10px;"></td>
                    <td style="vertical-align:top"  width="38%">
                        <ul>
                        <li></li>
                        <li>
                            <label>编号id：</label>
                            <asp:TextBox ID="id" CssClass="inputLB" runat="server" ReadOnly  style="width:300px;">0</asp:TextBox>
                        </li>
                        <li>
                            <label>参数名：</label>
                            <asp:TextBox ID="para" runat="server"  class="inputLB" style="width:300px;" ReadOnly="True"></asp:TextBox>
                            *</li>
                         <li>
                            <label>参数值：<b></b></label>
                            <asp:TextBox ID="value" runat="server" TextMode="MultiLine" class="inputLB" style="width:300px;height:70px;"></asp:TextBox>
                        </li>
                            <li>
                            <label>说&nbsp;&nbsp;&nbsp; 明：<b></b></label>
                            <asp:TextBox ID="demo" runat="server" TextMode="Password" class="inputLB" style="width:300px;"></asp:TextBox>
                        </li>
                            
                        <li><label>&nbsp;</label></li>
                        <li><label>&nbsp;</label>
                            &nbsp;<asp:Button ID="bc" class="buttonLB"  runat="server" Text="保存参数" Visible="true" OnClick="bc_Click" /> 
                            </li>
                        </ul>
                        <div style="margin-left:15px;"><b><asp:Label ID="msg" runat="server" Width="500px" ForeColor="#CC0000"></asp:Label></b></div>
                        </td></tr>
                
            </table>


    
    

        </div> 
                
                                                              </ContentTemplate></asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
