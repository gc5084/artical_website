<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserIndex.aspx.cs" Inherits="Admin_PageUserManager_UserIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户信息管理</title>
    <link href="../css/publicCss.css"rel="stylesheet" type="text/css" />
    <link href="../css/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../images/tool-01.gif" align="top" onclick="switchBar(this)"
                                title="后台管理" style="cursor: pointer;" />后台管理</td>
                        <td>
                            <ul>
                                <li><a href="AddUserInfo.aspx">
                                    <img src="../images/tb-list16.gif" /><span>添加用户信息</span></a></li>
                                <li><a href="UpdateUserInfo.aspx">
                                    <img src="../images/add.gif" /><span>修改用户信息</span></a></li>
                                <li><a href="#">
                                    <img src="../images/nav.gif" /><span>删除用户信息</span></a></li>
                                <li><a href="UserInfoList.aspx">
                                    <img src="../images/bingtu.gif" /><span>用户列表</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form" style =" text-align:center;">
                用户信息管理——说明部分！！
            </div>
    </div>
    </form>
</body>
</html>
