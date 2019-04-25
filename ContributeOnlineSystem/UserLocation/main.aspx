<%@ Page Language="C#" AutoEventWireup="true" CodeFile="main.aspx.cs" Inherits="main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Future页面内容</title>
    <style type="text/css">
      .frameboeder{
	    border:solid 1px #99bbe8;
	    margin:6px;
      }
    </style>
</head>
<frameset name="d" cols="20%,*" border="6" frameborder="yes" bordercolor="#dfe8f6" id="frame">
  <frame id="a" name="project_navigator_container" src="leftTree.aspx" marginwidth=0 marginheight=0 scrolling="no" frameborder="0" class="frameboeder">
  <frame name="project_actions_container" src="mainCon.aspx"  marginwidth="0" marginheight="0" scrolling="auto" frameborder="0" class="frameboeder">
</frameset>
</html>
