<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zhanjiatype.aspx.cs" Inherits="admin_zhanjiatype" %>

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
    <div style="float:left; ">      
      <a <% if (stype == "2") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=2">+&nbsp;所在地区</a>&nbsp; 
      <a <% if (stype == "3") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=3">+&nbsp;所有行业</a>&nbsp; 
      <a <% if (stype == "5") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=5">+&nbsp;重点方向</a>&nbsp; 
      <a <% if (stype == "4") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=4">+&nbsp;企业性质&nbsp;</a>&nbsp; 
      <a <% if (stype == "6") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=6">+&nbsp;行业领域&nbsp;&nbsp;</a>&nbsp;
      <a <% if (stype == "7") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=7">+&nbsp;项目性质</a>&nbsp; 
      <br/><br/> 
      <a <% if (stype == "8") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=8">+&nbsp;军工情况</a>&nbsp; 
      <a <% if (stype == "9") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=9">+&nbsp;配套企业</a>&nbsp; 
      <a <% if (stype == "10") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=10">+&nbsp;技术来源</a>&nbsp;
      <a <% if (stype == "11") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=11">+&nbsp;技术地位&nbsp;</a>&nbsp;
      <a <% if (stype == "12") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=12">+&nbsp;技术壁垒&nbsp;&nbsp;</a>&nbsp; 
      <a <% if (stype == "13") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=13">+&nbsp;行业优势</a>&nbsp;
      <br/><br/> 
      <a <% if (stype == "14") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=14">+&nbsp;退出机制</a>&nbsp; 
      <a <% if (stype == "15") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=15">+&nbsp;所在职位</a>&nbsp; 
      <a <% if (stype == "16") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=16">+&nbsp;产业政策</a>&nbsp;
      <a <% if (stype == "17") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=17">+&nbsp;合作需求&nbsp;</a>&nbsp; 
      <a <% if (stype == "41") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="HangYe2.aspx?type=41">+子行业参数</a>&nbsp; 
      <a <% if (stype == "19") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=19">+&nbsp;合作状态</a>&nbsp;
         <br/><br/> 
      <a <% if (stype == "21") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=21">强基项目类</a>&nbsp; 
      <a <% if (stype == "22") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=22">+&nbsp;成果阶段</a>&nbsp; 
      <a <% if (stype == "23") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=23">+&nbsp;成果密级</a>&nbsp; 
      <a <% if (stype == "24") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=24">+&nbsp;成果属性&nbsp;</a>&nbsp; 
      <a <% if (stype == "25") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=25">成果创新形式</a>&nbsp; 
      <a <% if (stype == "42") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=42">+&nbsp;成果位置</a>&nbsp;
        <br />
        <br />
      <a <% if (stype == "26") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=26">未应用原因</a>&nbsp; 

      <a <% if (stype == "28") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=28">+&nbsp;证书类型</a>&nbsp; 
      <a <% if (stype == "29") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=29">+&nbsp;应用情况</a>&nbsp; 
      <a <% if (stype == "30") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=30">+&nbsp;交易状态&nbsp;</a>&nbsp; 
      <a <% if (stype == "27") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=27">成果合作方式</a>&nbsp; 
      <a <% if (stype == "43") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="zhanjiatype.aspx?type=43">+&nbsp;专家领域</a>&nbsp;
        <br />
        <br />

      <a <% if (stype == "32") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=32">+&nbsp;任务来源</a>&nbsp; 
      <a <% if (stype == "33") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=33">+&nbsp;性能类型</a>&nbsp; 
      <a <% if (stype == "34") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=34">+&nbsp;专家类别</a>&nbsp; 
      <a <% if (stype == "35") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=35">+&nbsp;企业类别&nbsp;</a>&nbsp; 
      <a <% if (stype == "31") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=31">成果会员属性</a>&nbsp; 
        <br />
        <br />

        <a <% if (stype == "37") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=37">+&nbsp;所属行业</a>&nbsp; 
        <a <% if (stype == "38") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=38">+&nbsp;应用计划</a>&nbsp; 
        <a <% if (stype == "40") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=40">+&nbsp;成果标签</a>&nbsp;  
        <a <% if (stype == "39") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=39">IGBT产业链</a>&nbsp;  
        <a <% if (stype == "36") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="setlist.aspx?type=36">上市企业参数</a>&nbsp; 
        <br />
        <br />

        <br />
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
        &nbsp;专家领域：
        <br><br>&nbsp;添加: 专家领域名称：<asp:TextBox  CssClass="inputLB" ID="TextBox1" runat="server" Width="200px" Height="30px"></asp:TextBox>
        <%--子行业描述： <asp:TextBox  CssClass="inputLB" ID="TextBox2" runat="server" Width="405px" Height="30px"></asp:TextBox>--%>
         &nbsp;<asp:Button ID="Button1"  CssClass="buttonLB1"  runat="server" Text="添加" OnClick="Button1_Click"  Height="30px" Width="80px"/>
        <br />
        <br /><hr width="874px"><asp:Label ID="Label1" runat="server" ForeColor="#FF0066"></asp:Label>
             <asp:GridView ID="myGrid" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="ID"
                        ForeColor="#333333" GridLines="None"   OnRowEditing="myGrid_RowEditing" OnRowDataBound="myGrid_RowDataBound"
                     PageSize="14" AllowPaging="True"  OnPageIndexChanging="myGrid_PageIndexChanging"    OnRowUpdating="myGrid_RowUpdating" OnRowCancelingEdit="myGrid_RowCancelingEdit"  Width="874px" CssClass="mGrid"
   PagerStyle-CssClass="pgr" >
                        <RowStyle Height="28px"   />
                        <Columns>                           
                          
                            <asp:BoundField DataField="id" HeaderText="参数值"  ItemStyle-Width="50px"  ReadOnly="True"/>
                            <asp:BoundField DataField="class" HeaderText="参数名称"  ItemStyle-Width="500px"/>
                            <%--<asp:BoundField DataField="Description" HeaderText="描述" ItemStyle-Width="560px" />--%>
                         
                           
                            <asp:CommandField HeaderText="编辑" ShowEditButton="True" >
                            <FooterStyle ForeColor="Blue" />
                            <ItemStyle ForeColor="Blue" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="操作"  ItemStyle-Width="50px">
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
