<%@ Page Language="C#" AutoEventWireup="true" CodeFile="topTools.aspx.cs" Inherits="topTools" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    #tools{
	    padding:6px;
    }
    #tools ul{
	    list-style:none;
	    height:21px;
	    float:right;
    }
    #tools ul li{
	    display:inline;
    }
    #tools ul li a{
	    display:block;
	    float:left; 
	    padding:0 0 0 10px;
	    line-height:21px;
    }
    #tools ul li a img{
	    float:left;
	    margin-right:4px;
	    margin-top:2px;
    }
    #tools ul li a:hover{
	    background:url(images/btn-bg.gif);
    }
    #tools ul li span{
	    display:block;
	    padding:0 10px 0 0 ;
    }
    #tools ul li a:hover span{
	    background:url(images/btn-bg.gif) no-repeat right top;
    }
    </style>
</head>
<body bgcolor="#dfe8f6">
    <form id="form1" runat="server">
    <div id="tools">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><span style="font-family: Verdana, Arial, Helvetica, sans-serif; font-weight:bold; color:#005d94">投稿系统</span>——后台管理</td>
          <td>
            
          </td>
        </tr>
      </table>
  </div>
    </form>
</body>
</html>
