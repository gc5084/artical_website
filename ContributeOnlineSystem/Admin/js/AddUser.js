// JScript 文件  表单验证脚本
Blue.AddEvent(window,'load',init);

function init(){
       
      Blue.$("BTNext").onclick = Check;
}

function Check(){
    
    if(checkName() && checkPSW() && checkRealName() &&checkEmail() ){
        return true;
    }
    
    return false;
        

}
//检查用户名
function checkName(){
    var name = Blue.$("TBUserName");
    if(name.value == ""){
        alert("用户名不能为空！");
        name.select();
        return false;
    }
    
    for(var i=0;i<name.value.length;i++)
	  {
	     var charTest=name.value.toLowerCase().charAt(i);
		 if( (!(charTest>='0' && charTest<='9')) &&  (!(charTest>='a' && charTest<='z'))  && (charTest!='_') )
		 {
		  alert("用户名包含非法字符，只能包括字母,数字和下划线");
		  name.select();
		  return false;
		  }
	  }
	  
	return true;

}

//检查密码
function checkPSW(){
    var pass =  Blue.$("TBUserPWD");
	var rpass = Blue.$("TBrePWD");
	
	if(pass.value == ""){
		alert("密码不能为空");
		pass.select();
		return false;
	}
	
	if(pass.value.length < 3 || pass.value.length > 16){
		alert("密码长度为3-16个字符");
		pass.select();
		return false;
	}
	
	for(var i=0;i<pass.value.length;i++)
	  {
	     var charTest=pass.value.toLowerCase().charAt(i);
		 if( (!(charTest>='0' && charTest<='9')) &&  (!(charTest>='a' && charTest<='z'))  && (charTest!='_') )
		 {
		  alert("密码包含非法字符，只能包括字母,数字和下划线");
		  pass.select();
		  return false;
		  }
	  }
	
	if(rpass.value != pass.value){
		alert("确认密码与密码输入不一致");
		rpass.select();
		return false;
	}
	
	
	
	return true;

}

//检查真实姓名
function checkRealName(){
    var name = Blue.$("TBtrueName");
    if(name.value == ""){
        alert("真实姓名不能为空！");
        name.select();
        return false;
    }
	  
	return true;

}

//检查邮箱
function checkEmail(){
    var email = Blue.$("TBEmail") 
    if(email.value == ""){ return true;}
    
　　var pattern = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+(.[a-zA-Z0-9_-])+/;  
　　var flag = pattern.test(email.value);  
　　if(flag)  
　　{  
　　　
　　　return true;  
　　}  
　　else  
　　{  
　　　　alert("邮箱格式错误！");  
　　　　return false;  
　　}
　　　　　　  
}