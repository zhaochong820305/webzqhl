<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_defaulto" %>

<%@ Register Src="~/include/header.ascx" TagPrefix="uc1" TagName="header" %>
<%@ Register Src="~/include/footer.ascx" TagPrefix="uc1" TagName="footer" %>
<%@ Register Src="~/include/menu.ascx" TagPrefix="uc1" TagName="menu" %>




<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<uc1:header runat="server" id="header" />
    
<body>
    <uc1:menu runat="server" ID="menu" />
<!--内容-->
<div class="index_con">
    <div class="index_con_left">
    <!--轮播图-->
        <div id="lun">
            <div id="lunbotu">
                <!--/开始-->
                <div class="wrap">
                    <div id="slide-holder">
                        <div id="slide-runner">
                            <%=pic %>
                            <div id="slide-controls">
                                <!--<p id="slide-client" class="text"><strong>平台推荐: </strong><span></span></p>-->
                                <p id="slide-desc" class="text"></p>
                                <p id="slide-nav"></p>
                            </div>
                        </div>
                    </div>
                    <script type="text/javascript">
                        if(!window.slider) var slider={};slider.data=[<%=pictxt%>];
                    </script>
                </div>
                <!--/结束-->
            </div>
        </div>
    </div>
    <div class="index_con_right">
    <!--关于我们-->
        <div class="abouts">
            <div class="abouts_top">
                <div id="model_t31" class="model_ta model_active">产业动态</div>
                <div id="model_t32" class="model_ta">解读&支持</div>
                <div id="model_t33" class="model_ta">联盟动态</div>
                 
                <div id="model_con31" class="model_cona">

                    <ul>
                       <%=loadabout(51,36,9) %>
                    </ul>
                </div>
                <div id="model_con32" class="model_cona">
                    <ul>
                        <%=loadabout(52,36,9) %> 
                    </ul>
                </div>
                <div id="model_con33" class="model_cona">
                    <ul>
                        <%=loadabout(53,36,9) %> 
                    </ul>
                </div>
            </div>
           <%-- <div class="abouts_con">
                工业和信息化部电子科学技术情报研究所科技成果评价与推广转化服务中心是工业和信息化部电子科学技术情报研究所内设二级机构，从事科技成果管理、评价和推广转化的公益性、专业性支撑服务。开展的业务包括：开展科技成果评价登记、搭建技术转移服务平台、组织成果推广和技术交流活动、组织产学研合作、推动军民两用技术双向转移、技术转移中介服务、理论......(<a target="_blank" href="http://www.miit-kjcg.org/shownews.aspx?id=146">更多</a>）
            </div>--%>
        </div>
    </div>
   
</div>
 <!--banner-->
<div style="width:1200px;margin:0 auto;  ">
    <a style="width:1200px;margin:0 auto; display:block;   " href="http://finance.sina.com.cn/focus/2017_dhzgzzdll/index.shtml" target="_blank" ><img src="images/banner.png"  width="1200px"/> </a>
</div>
<div class="index_con">
    <!--左边-->
    <div class="index_con_left">
        
        <!--成果评价-->
        <div class="model clear">
        	<h4>成果评价</h4>
            <div class="img">
            	<img src="images/cgpj_03.png" width="200" height="277" />
            </div>
            <div class="right">
            <div class="model_title">
            	<div id="model_t11" class="model_t model_active">中心动态</div>
                <div id="model_t12" class="model_t">文件法规</div>
                <div  id="model_t13" class="model_t">评价介绍</div>
                <div  id="model_t14" class="model_t">评价项目</div>
                <div  id="model_t15" class="model_t">推奖项目</div>
                <a href="list.aspx?class=5&fl=1"><div class="model_t6">+ 更多</div></a>
            </div>
           
            <div id="model_con1" class="model_con">
                <ul>
                    <%=loadnr(45,1,60,6) %>
                </ul>
            </div>
          

            <div id="model_con2" class="model_con">
                <ul>
                    <%=loadnr(1,1,58,6) %>
                </ul>
            </div>
            <div id="model_con3" class="model_con">
                <ul>
                    <%=loadnr(2,1,60,6) %>
                </ul>
            </div>
            <div id="model_con4" class="model_con">
                <ul>
                    <%=loadnr(3,1,60,6) %>
                </ul>
            </div>
             <div id="model_con5" class="model_con">
                <ul>
                    <%=loadnr(4,1,60,6) %>
                </ul>
            </div>
            </div>
        </div>
        <!--政策动态-->

        <div class="model">
        	<h4>政策体系</h4>
             <div class="img">
            	<img src="images/zcdt.png" width="200" height="277" />
            </div>
            <div class="right">
            <div class="model_title model_tt">
                <div id="model_t21" class="model_t model_active">中国制造2025</div>
                <div id="model_t22" class="model_t">科技计划体系</div>
                <div id="model_t23" class="model_t">产业引导基金</div>
                <div id="model_t24" class="model_t">国家创新平台</div>
                <a href="list.aspx?class=5&fl=2"><div class="model_t6">+ 更多</div></a>
            </div>
            <div id="model_con6" class="model_con">
                <ul id="ul1">
                   <%=loadnr(6,1,60,7) %> 
                </ul>
            </div>
            <div id="model_con7" class="model_con">
                <ul>
                    <%=loadnr(5,1,60,7) %> 
                </ul>
            </div>
            <div id="model_con8" class="model_con">
                <ul>
                    <%=loadnr(7,1,60,7) %> 
                </ul>
            </div>
            <div id="model_con9" class="model_con">
                <ul>
                   <%=loadnr(8,1,60,7) %> 
                </ul>
            </div>
            </div>
        </div>
        
       
        
        <!--服务企业-->
        <div class="fwqy">
        	<h4>服务企业</h4>
        <div id="demo" style="overflow:hidden;height:180px;width:845px; margin-top:10px;">
        <table cellspacing="0" cellpadding="0" border="0">
        <tr>
        <td id="demo1">
        <table width="900px" border="0" cellspacing="0" cellpadding="0">
            <tr class="imgg">
              <%=loadfw(10) %>
            </tr>
        </table></td>
        <td id="demo2"></td>
        </tr>
        </table>
        <script language="javascript" type="text/javascript">
      
            var speed =30;
            var demo_ = document.getElementById("demo");//用getElememtById是为了兼容FF
            var demo2_ = document.getElementById("demo2");
            var demo1_ = document.getElementById("demo1");
			 var a=demo_.scrollLeft;
			 a=0;
			//var a=demo_.scrollLeft;
            demo2_.innerHTML = demo1_.innerHTML;
            var MyMar = setInterval(Marquee, speed);
			demo.onmouseover =function () { clearInterval(MyMar) }
            demo.onmouseout =function () { MyMar = setInterval(Marquee, speed) }
            function Marquee() {
                if (demo2_.offsetWidth - a <=0)
                    a -= demo1_.offsetWidth;
                else {
					a++;
					demo_.scrollLeft=a;
                }
            }
            
        </script>
    	</div>
         <div class="fwqy_con_bottom"></div>
            
            </div>
        
</div>



    <!--右边-->
    <div class="index_con_right">
        
        
         <!--在线-->
        <a href="zxsq.aspx?class=0&fl=5">
        	<div class="zxsq">
            	<div class="zxsq_con">科技评价在线申请</div>
        	</div>
        </a>
        <!--专家团队-->
        <div class="team">
            <div class="team_top">专家团队</div>
            <div class="team_icon" id="team_icon">
            	<ul>
                	<%=loadzjtd(3) %>
                </ul>
                
            </div>
            <div class="team_con">
                <ul>
                   <%=loadzjclass(4,10) %>
                </ul>
            </div>
        </div>
        
        
        <!--展示栏-->
       <!--
        <div class="show2">
            <div class="show2_con">科技成果评价服务平台</div>
        </div>
        <div class="show3">
            <div class="show3_con">军民双向转移服务平台</div>
        </div>
        <div class="show4">
            <div class="show4_con">工业强基示范应用平台</div>
        </div>
        <div class="show5">
            <div class="show5_con">健康大数据重点实验室</div>
        </div>
        -->
       
</div>   
       
</div>
    <div style="text-align:center;width:100%;height: 80px;clear: both;padding-top: 15px;">
        <div style="width:1200px;height:100%;margin:auto;">
            <div class="show2">
            <div class="show2_con">科技成果评价服务平台</div>
        </div>
        <div class="show3">
            <div class="show3_con">军民双向转移服务平台</div>
        </div>
        <div class="show4">
            <div class="show4_con">工业强基示范应用平台</div>
        </div>
        <div class="show5">
            <div class="show5_con">健康大数据重点实验室</div>
        </div>
        </div> 
        </div> 
    <uc1:footer runat="server" id="footer" />
</body>
</html>