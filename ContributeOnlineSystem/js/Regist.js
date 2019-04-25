// JScript 文件
Blue.AddEvent(window,'load',init);

 function init(){
           
          Blue.$("btnSubmit").onclick = checkEmail;
}
    
    
function checkEmail(){
var email = getElementById("txtEMail") 
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

