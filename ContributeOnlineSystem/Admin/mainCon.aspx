<%@ Page Language="C#" AutoEventWireup="true" CodeFile="mainCon.aspx.cs" Inherits="mainCon" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/select.js"></script>

    <script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="？？？？？？？？？？？？？？？？";
		    document.getElementById("hiddenIco").src="images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="15%,*";
		    displayBar=true;
		    obj.title="？？？？？？？？？？？？？？？？";
		    document.getElementById("hiddenIco").src="images/tool-01.gif";
	    }
    }
    //-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style=" text-align:center;" id = "mainDiv" style="margin:auto;">
           <br/><br/>系统管理员界面！
        </div>
    </form>
</body>
</html>
