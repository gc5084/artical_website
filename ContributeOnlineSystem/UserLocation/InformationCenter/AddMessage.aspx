<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddMessage.aspx.cs" Inherits="UserLocation_InformationCenter_AddMessage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../css/publicCss.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/select.js"></script>

    <script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="";
		    document.getElementById("hiddenIco").src="./images/tool-02.gif";
	    }
	    else
	    {
		    this.parent.frame.cols="20%,*";
		    displayBar=true;
		    obj.title="";
		    document.getElementById("hiddenIco").src="../images/tool-01.gif";
	    }
    }
    //-->
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../../images/tool-01.gif" style=" vertical-align:top;cursor: pointer;" onclick="switchBar(this)" title="" />信息中心
                        </td>
                        <td>
                            <ul>
                                <li><a href="#">
                                    <img src="../../images/tb-list16.gif" /><span>未读信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/add.gif" /><span>已读信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/nav.gif" /><span>写信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/bingtu.gif" /><span>所有信息</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" style=" vertical-align:top;"/>写信息
                    </legend>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>

