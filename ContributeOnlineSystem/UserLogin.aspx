<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserLogin.aspx.cs" Inherits="UserLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>咸阳师范学院学报_投稿系统登录 </title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />
    <link href="css/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
a{ color:#008EE3}
a:link  { text-decoration: none;color:#008EE3}
A:visited {text-decoration: none;color:#666666}
A:active {text-decoration: underline}
A:hover {text-decoration: underline;color: #0066CC}
A.b:link {
	text-decoration: none;
	font-size:12px;
	font-family: "Helvetica,微软雅黑,宋体";
	color: #FFFFFF;
}
A.b:visited {
	text-decoration: none;
	font-size:12px;
	font-family: "Helvetica,微软雅黑,宋体";
	color: #FFFFFF;
}
A.b:active {
	text-decoration: underline;
	color: #FF0000;
}
A.b:hover {
	text-decoration: underline;
	 color: #ffffff
}

.table1 {
	border: 1px solid #CCCCCC;
}
.font {
	font-size: 12px;
	text-decoration: none;
	color: #999999;
	line-height: 20px;
}
.input {
	font-size: 12px;
	color: #999999;
	text-decoration: none;
	border: 0px none #999999;
}

td {
	font-size: 12px;
	color: #007AB5;
}
form {
	margin: 1px;
	padding: 1px;
}
input {
	border: 0px;
	height: 26px;
	color: #007AB5;
}
.unnamed1 {
	border: thin none #FFFFFF;
}
select {
	border: 1px solid #cccccc;
	height: 18px;
	color: #666666;
}
body {
	background-repeat: no-repeat;
	background-color: #9CDCF9;
	background-position: 0px 0px;
}
.tablelinenotop {
	border-top: 0px solid #CCCCCC;
	border-right: 1px solid #CCCCCC;
	border-bottom: 0px solid #CCCCCC;
	border-left: 1px solid #CCCCCC;
}
.tablelinenotopdown {
	border-top: 1px solid #eeeeee;
	border-right: 1px solid #eeeeee;
	border-bottom: 1px solid #eeeeee;
	border-left: 1px solid #eeeeee;
}
.style6 {FONT-SIZE: 9pt; color: #7b8ac3; }
</style>
</head>
<body style="background-color: #9CDCF9">
    <form id="Form1" method="post" onsubmit="return chk(this);" name="NETSJ_Login" runat="server">
        <table width="681" border="0" align="center" cellpadding="0" cellspacing="0" style="margin-top: 120px">
            <tr>
                <td width="353" height="259" align="center" valign="bottom" background="images/login_1.gif">
                    <table width="90%" border="0" cellspacing="3" cellpadding="0">
                        <tr>
                            <td align="right" valign="bottom" style="color: #05B8E4">
                                Power by <a href="http://www.mysoftfactory.com" target="_blank">Blue</a>
                                Copyright 2009</td>
                        </tr>
                    </table>
                </td>
                <td width="195" background="images/login_2.gif">
                    <table width="190" height="106" border="0" align="center" cellpadding="2" cellspacing="0">
                        <tr>
                            <td height="50" colspan="3" align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="60" height="30" align="left">
                                登陆名称</td>
                            <td colspan="2">
                                <input runat="server" name="txtName" type="TEXT" style="width:100px;background: url(images/login_6.gif) repeat-x;border: solid 1px #27B3FE; height: 20px; background-color: #FFFFFF" id="txtName" size="14" /></td>
                        </tr>
                        <tr>
                            <td height="30" align="left">
                                登陆密码</td>
                            <td colspan="2">
                                <input runat="server" name="txtPwd" type="PASSWORD" style="width:100px;background: url(images/login_6.gif) repeat-x;border: solid 1px #27B3FE; height: 20px; background-color: #FFFFFF" id="txtPwd" size="16" /></td>
                        </tr>
                        <tr>
                            <td height="30" align="left">
                                用户类型</td>
                            <td colspan="2">
                                <div id="selectDiv" class="seleStyle" style="color:Black;">
                                    <asp:DropDownList ID="ddlUserType" runat="server" Width = "100">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="40" colspan="3" align="center">
                                <img src="images/tip.gif" width="16" height="16" align="top">
                                <a href="RegisterNewUser.aspx">注册新用户</a></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnSubmit" runat="server" Text=" 登  陆 " Style="width:69px;background:url(images/login_5.gif) no-repeat;cursor: pointer;" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnCancel" runat="server" Text=" 取  消 " Style="width:69px;background:url(images/login_5.gif) no-repeat;cursor: pointer;" OnClick="btnCancel_Click" />
                            </td>
                            <td height="5" colspan="3">
                            </td>
                        </tr>
                    </table>
                </td>
                <td width="133" background="images/login_3.gif">
                    &nbsp;</td>
            </tr>
            <tr>
                <td height="161" colspan="3" background="images/login_4.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
