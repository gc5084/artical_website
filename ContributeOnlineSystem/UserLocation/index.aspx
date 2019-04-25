<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <title>咸阳师范学院学报投稿系统</title>
    <style type="text/css">
  .frameboeder{
	border:solid 1px #99bbe8;
	margin:6px;
  }
</style>
</head>
<frameset rows="35,*" border="6" style="border: solid 6px #dfe8f6;" frameborder="yes" bordercolor="#dfe8f6">
	<frame name="perspective_toolbar" title="工具栏" src="topTools.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0" noresize class="frameboeder">
	<frameset cols="30,*" border="0">
		<frame name="perspective_toolbar" title="视图切换区" src="switchView.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0" noresize>
		<frame name="perspective_content" title="" src="main.aspx" marginwidth="0" marginheight="0" scrolling="no" frameborder="0">
	</frameset>
</frameset>
</html>
