﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="switchView.aspx.cs" Inherits="switchView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    #switchView ul li{
	    text-align:center;
	    margin-bottom:8px;
    }
    </style>
</head>
<body bgcolor="#dfe8f6">
    <form id="form1" runat="server">
    <div id="switchView">
    <ul>
      <li><a target="project_actions_container"><img src="../images/01.gif" /></a></li>
      <li><a target="project_actions_container"><img src="../images/02.gif" /></a></li>
      <li><a target="project_actions_container"><img src="../images/03.gif" /></a></li>
      <li><a target="project_actions_container"><img src="../images/01.gif" /></a></li>
      <li><a target="project_actions_container"><img onclick="window.open('window.aspx','window','width=550,height=350');" src="../images/02.gif" /></a></li>
      <li><a  target="project_actions_container"><img src="../images/03.gif" /></a></li>
    </ul>
  </div>
    </form>
</body>
</html>
