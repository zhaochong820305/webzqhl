<%@ Page Language="C#" AutoEventWireup="true" CodeFile="videoadd.aspx.cs" Inherits="admin_videoadd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/grid.css" rel="stylesheet" />
    <link href="css/qiyegl.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <table class="gridtable" style="margin-left:10px;width:880px;">
                   <tr> 
                        <th style="vertical-align:top" >
                             <label>&nbsp;视频标题:<b>*</b></label>
                        <td style="vertical-align:top" colspan="3" >
                             <asp:TextBox ID="id" runat="server" ReadOnly="true"  class="inputLB" value="id" Visible="false"  style="width:200px;"></asp:TextBox>
                             <asp:TextBox ID="title" runat="server"  class="inputLB" value=""  style="width:400px;"></asp:TextBox>
                   </tr>
                   <tr> 
                        <th style="vertical-align:top" >
                                <label>&nbsp;外部链接:<b>*</b></label>
                        <td style="vertical-align:top" colspan="3" >
                                <asp:TextBox ID="link" runat="server"  class="inputLB" value=""  style="width:400px;"></asp:TextBox>
                   </tr>
                   <tr> 
                        <th style="vertical-align:top" >
                                <label>&nbsp;内部上传:<b>*</b></label>
                        <td style="vertical-align:top" colspan="2" >
                                <asp:FileUpload ID="FileUpload1" Width="200px" class="buttonLB" runat="server" />
                                <asp:TextBox ID="pic1" runat="server" class="inputLB" value="专家图片" style="width:200px;"></asp:TextBox>
                        <td style="vertical-align:top" >
                                <asp:Button ID="Button2" class="buttonLB" runat="server" Text="上传" OnClick="Button2_Click" />
                   </tr>
                   <tr> 
                        <th style="vertical-align:top" >
                                <label>&nbsp;投放选择:<b>*</b></label>
                        <td style="vertical-align:top" colspan="3" >
                                <asp:CheckBoxList ID="hangyec" runat="server" RepeatColumns="5"></asp:CheckBoxList>
                   </tr>
                   <tr>
                        <th style="vertical-align:top" >    封面图片：  
                        <td style="vertical-align:top" colspan="3" ><asp:Image ID="imgh" runat="server" Height="100px" Width="374px" />
                   </tr>
                   <tr> 
                        <th style="vertical-align:top" >
                             <label>&nbsp;上传图片:<b>*</b></label>
                        <td style="vertical-align:top" colspan="2" >
                             <asp:FileUpload ID="upfile" Width="200px" class="buttonLB" runat="server" />
                             
                        <td style="vertical-align:top" >  
                             <asp:Button ID="Button1" class="buttonLB" runat="server" Text="上传" OnClick="Button1_Click" />
                   </tr>
                   <%-- 
                   <tr>
                       <th style="vertical-align:top" >
                                <label>&nbsp;网站类别:<b>*</b></label>
                       <td style="vertical-align:top" >
                                <asp:DropDownList  CssClass="inputLB" Width="200px"  ID="ddlWType" runat="server"></asp:DropDownList>
                       </td>
                       <th style="vertical-align:top" >
                       
                            <label>&nbsp;链接地址:<b>*</b></label>
                       <td style="vertical-align:top" >
                           
                   </tr>--%>
                   <tr>
                        <th style="vertical-align:top" >
                            <label>&nbsp;是否首页：<b></b></label>
                        <td style="vertical-align:top;width:300px;" >
                            <asp:CheckBox ID="indexview" runat="server" />
                            <asp:TextBox ID="pic" runat="server" class="inputLB" value="专家图片" Visible="false"  style="width:200px;"></asp:TextBox>
                        <td style="vertical-align:top;width:100px;" >
                            <label>&nbsp;重&nbsp;&nbsp;要&nbsp;&nbsp;性：</label>
                        <td style="vertical-align:top" >
                            <asp:TextBox ID="qz" runat="server"  class="inputLB" value="11"  style="width:200px;"></asp:TextBox>
                   </tr>
                   <tr>
                       <th style="vertical-align:top" >
                            <label>&nbsp;是否发布：</label>
                       <td style="vertical-align:top" >
                            <asp:CheckBox ID="en" runat="server" />
                       <td style="vertical-align:top" >     <label>&nbsp;视频分类：</label>
                       <td style="vertical-align:top" >     <asp:DropDownList ID="videotype" runat="server" Height="22px" Width="246px" AutoPostBack="True"  >
                     </asp:DropDownList> 
                            
                  
                   <tr>
                        <td style="vertical-align:top" > 
                        <td style="vertical-align:top" >  <%-- <asp:Button ID="tj" class="buttonLB"  runat="server" Text="添加视频" Visible="true" OnClick="tj_Click" /> --%>
                        <td style="vertical-align:top" >
                             <asp:Button ID="bc" class="buttonLB"  runat="server" Text="保存视频" Visible="true" OnClick="bc_Click" /> 
                        <td style="vertical-align:top" >
                           
                         
                            <asp:Label ID="msg" runat="server"  ForeColor="Red"></asp:Label> 
                        </td>
                   </tr>
               </table>
    
    </div>
    </form>
</body>
</html>
