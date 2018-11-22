<%@ Control Language="C#" AutoEventWireup="true" CodeFile="header.ascx.cs" Inherits="admin_include_header" %>
	<div style="width:100%;height:80px;background: url(images/topbg.png) repeat 0 -300px ;"  >
    <div style="width:50%;height:80px;float:left;">
        <div style="float:left;cursor:pointer;">
        	<img src="images/logo.png" style="height:60px;margin-left:80px;margin-top:10px;" />
        </div>
        <div style="float:left;margin-top:25px;">
            <div style="float:left;margin-left:80px;"><a href="/"><d style="font-size:26px;color:#fff; font-weight:bold;">首页</d></a></div>
          
        </div>
    </div>
    <div style="width:50%;height:80px;float:left;">
        <div style="float:left;margin-top:25px;">
            <div style="float:left;margin-left:80px;">
                <d style="font-size:26px;color:red; font-weight:600;">
                登录用户：<%=Session["adminloginuser"] %>
                </d>
            </div>
        </div>
    </div>

</div>