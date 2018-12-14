<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wenjuanmenu.ascx.cs" Inherits="admin_include_wenjuanmenu" %>
<%if (   Session["title"].ToString() != "6") {%>
<a <% if (stype == "2") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="diaocha.aspx?type=2">IGBT企业调研表 </a>&nbsp; 
      <a <% if (stype == "3") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="diaoyitiao.aspx?type=3">一条龙企业调研</a>&nbsp; 
      <a <% if (stype == "5") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="diaoqiye.aspx?type=5">企业需求信息 </a>&nbsp; 
 
      <a <% if (stype == "6") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="diaochaccq.aspx?type=6">存储器一条龙</a>&nbsp;
      <a <% if (stype == "7") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="diaochatuan.aspx?type=7">团体标准制修表</a>&nbsp; 
<%}%>
      <a <% if (stype == "4") Response.Write("class='buttonLB1'"); else Response.Write("class='buttonLB1 button2'"); %> href="baoming.aspx?type=4">500强企业报名</a>&nbsp;