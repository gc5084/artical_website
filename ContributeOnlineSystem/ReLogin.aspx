<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReLogin.aspx.cs" Inherits="ReLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>集成化研发管理平台 MainSoft</title>
    <style type="text/css">
  .frameboeder{
	border:solid 1px #99bbe8;
	margin:6px;
  }
</style>
</head>
<frameset rows="30%,*" border="6" style="border: solid 6px #dfe8f6;" frameborder="yes" bordercolor="#dfe8f6">
	<frame name="perspective_toolbar" title="工具栏" src="logo.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0" noresize class="frameboeder">
	<frameset cols="20%,*" border="0">
		<frame name="perspective_toolbar" title="图片" src="pic.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0" noresize>
		<frame name="perspective_content" title="登录" src="UserLogin.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0">
	</frameset>
</frameset>
</html>
