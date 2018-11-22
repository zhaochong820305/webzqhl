window.onload=function(){
		var warp=document.getElementById("team_icon");
		var ul=warp.getElementsByTagName("ul")[0];
		var lii=warp.getElementsByTagName("li");
		var index=0;
		var left=warp.offsetWidth;
		//console.log(li.length);
		var timer=setInterval(function(){
			index++;
			if(index>lii.length-1){
				index=0;
			}
			ul.style.left=-index*left+'px';
			
		},5000);
		
	}