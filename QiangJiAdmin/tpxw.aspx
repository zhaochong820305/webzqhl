<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tpxw.aspx.cs" Inherits="admin_tpxw" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>管理中心</title>
   <%-- <link href="css/main.css" rel="stylesheet" />
    <link href="css/ps.css" rel="stylesheet" />
    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />--%>
    <link href="css/grid.css" rel="stylesheet" />
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-2.1.1.min.js" type="text/javascript"></script>
    <style>
        *{margin:0; padding:0;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server"></asp:ScriptManagerProxy>
  
               <table class="gridtable" style="margin-left:10px;width:880px;">
                   <tr>
                        <th style="vertical-align:top" >
                                <label>&nbsp;新&nbsp;闻&nbsp;&nbsp;id:<b>*</b></label>
                        <td style="vertical-align:top" >
                                <asp:TextBox ID="id" runat="server" ReadOnly="true"  class="inputLB" value="id"  style="width:200px;"></asp:TextBox>
                        <th style="vertical-align:top" >
                                <label>&nbsp;新闻标题:<b>*</b></label>
                        <td style="vertical-align:top" >
                                <asp:TextBox ID="title" runat="server"  class="inputLB" value=""  style="width:200px;"></asp:TextBox>
                   </tr>
                   <tr>
                       <th style="vertical-align:top" >
                                <label>&nbsp;网站类别:<b>*</b></label>
                       <td style="vertical-align:top" >
                                <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="ddlWType" runat="server"></asp:DropDownList>
                       </td>
                       <th style="vertical-align:top" >
                       
                            <label>&nbsp;链接地址:<b>*</b></label>
                       <td style="vertical-align:top" >
                            <asp:TextBox ID="link" runat="server"  class="inputLB" value=""  style="width:200px;"></asp:TextBox>
                   </tr>
                   <tr>
                        <th style="vertical-align:top" >
                            <label>&nbsp;图&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;片：<b></b></label>
                        <td style="vertical-align:top" >
                            <asp:TextBox ID="pic" runat="server" class="inputLB" value="专家图片"  style="width:200px;"></asp:TextBox>
                        <th style="vertical-align:top" >
                            <label>&nbsp;权&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;值：</label>
                        <td style="vertical-align:top" >
                            <asp:TextBox ID="qz" runat="server"  class="inputLB" value="权值为数字"  style="width:200px;"></asp:TextBox>
                   </tr>
                   <tr>
                       <th style="vertical-align:top" >
                            <label>&nbsp;是否发布：</label>
                       <td style="vertical-align:top" >
                            <asp:CheckBox ID="en" runat="server" />
                       <th style="vertical-align:top" >    选择图片：  
                       <td style="vertical-align:top" >      
                            <asp:FileUpload ID="upfile" Width="200px" class="buttonLB" runat="server" />
                   <tr>
                        <th style="vertical-align:top" >    图片显示：  
                        <td style="vertical-align:top" colspan="3" ><asp:Image ID="imgh" runat="server" Height="100px" Width="374px" />
                   
                   <tr>
                        <td style="vertical-align:top" > 
                        <td style="vertical-align:top" >   <asp:Button ID="Button1" class="buttonLB" runat="server" Text="上传" OnClick="Button1_Click" />
                        <td style="vertical-align:top" >
                            <asp:Button ID="tj" class="buttonLB"  runat="server" Text="添加图片" Visible="true" OnClick="tj_Click" /> 
                        <td style="vertical-align:top" >
                            &nbsp;<asp:Button ID="bc" class="buttonLB"  runat="server" Text="保存图片" Visible="true" OnClick="bc_Click" /> 
                         
                            <asp:Label ID="msg" runat="server"  ForeColor="Red"></asp:Label> 
                        </td>
                   </tr>
               </table>
            <table border="0" style="width:880px;height:100%;padding: inherit; margin-left:10px;margin-top:20px;  border: thin solid #eac998;">
                <tr><td style="vertical-align:top;background-color:#F7F7DE">

                    <asp:GridView ID="myGrid" Width="880px" Height="100%" runat="server"
             ShowHeaderWhenEmpty="True"
                                   CssClass="mGrid"  
   PagerStyle-CssClass="pgr"   BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" AllowPaging="True" 
            
            AutoGenerateColumns="False" OnRowDataBound="myGrid_RowDataBound" OnPageIndexChanging="myGrid_PageIndexChanging" 
                        >
                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="编号" >
            <ControlStyle CssClass="hidden" />
            <FooterStyle CssClass="hidden" />
            <HeaderStyle CssClass="hidden" />
            <ItemStyle CssClass="hidden" Width="20px"  Height="30px"/>
                               </asp:BoundField>
                            <asp:BoundField DataField="title" HeaderText="标题" >
                            <ItemStyle Width="150px" />
                            </asp:BoundField>
                            <%--<asp:BoundField DataField="pic" HeaderText="图片" >
                            <ItemStyle Width="150px" />
                            </asp:BoundField>--%>
                             <asp:BoundField DataField="name" HeaderText="分类" >
                            <ItemStyle Width="92px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="cdate" HeaderText="上传时间" DataFormatString="{0:yyyy-MM-dd}" >
                            <ItemStyle Width="92px" />
                            </asp:BoundField>
                            <%--<asp:BoundField HeaderText="权值" DataField="qz" >
                            <ItemStyle Width="20px" />
                            </asp:BoundField>--%>
                            <%--<asp:BoundField DataField="en" HeaderText="1为发布" >
                            <ItemStyle Width="20px" />
                            </asp:BoundField>--%>
                            <asp:BoundField HeaderText="操作" >
                            <ItemStyle Width="30px" />
                            </asp:BoundField>
                        </Columns>
                        <FooterStyle BackColor="#CCCC99" />
          <PagerSettings FirstPageText="&lt;&lt;" LastPageText="&gt;&gt;" 
              Mode="NumericFirstLast" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="center" />
        <PagerTemplate>  
        <table width="100%">  
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

                    
                   
                
            </table>
             
    </form>
</body>
</html>
