<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="UserLocation_UserSettings_ChangePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../../css/publicCss.css" rel="stylesheet" type="text/css" />
    <link href="../../css/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="展开窗口";
		    document.getElementById("hiddenIco").src="../../images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="20%,*";
		    displayBar=true;
		    obj.title="窗口折叠";
		    document.getElementById("hiddenIco").src="../../images/tool-01.gif";
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
                            <img id="hiddenIco" src="../../images/tool-01.gif" style="vertical-align: top; cursor: pointer;"
                                onclick="switchBar(this)" title="" />用户信息
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form" style =" text-align:center;">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" align="top" />修改用户密码</legend>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td style="width:200px">
                                &nbsp;</td>
                            <td colspan="3">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width:200px" align="right">请输入旧密码：</td>
                            <td colspan="3" style="text-align:left">
                                <label>
                                    <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password" Width="200px" CssClass="textStyle"></asp:TextBox>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:200px" align="right">请输入新密码：</td>
                            <td colspan="3" style="text-align:left">
                                <label>
                                    <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password" Width="200px" CssClass="textStyle"></asp:TextBox>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:200px" align="right">重复输入密码：</td>
                            <td colspan="3" style="text-align:left">
                                <label>
                                    <asp:TextBox ID="txtNewPwdAgain" runat="server" TextMode="Password" Width="200px" CssClass="textStyle"></asp:TextBox>
                                </label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="3" style="text-align:left;margin:0px; padding:0px; ">
                                    <span class="btnStyle">
                                        <asp:Button ID="btnSubmit" runat="server" Text="修 改" CssClass = "btn" Width="50" OnClick="btnSubmit_Click" />
                                    </span>
                                    <span class="btnStyle">
                                        <asp:Button ID="btnCancel" runat="server" Text="取 消" CssClass = "btn" Width="50" />
                                    </span>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
