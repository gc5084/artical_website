<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUserBaseInfo.aspx.cs" Inherits="UserLocation_UserSettings_UpdateUserBaseInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户信息列表</title>
    <link href="../../css/publicCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/select.js"></script>
    <script type="text/javascript" src="../../js/My97DatePicker/WdatePicker.js"></script>
    <script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="现实导航栏";
		    document.getElementById("hiddenIco").src="./images/tool-02.gif";
	    }
	    else
	    {
		    this.parent.frame.cols="20%,*";
		    displayBar=true;
		    obj.title="隐藏导航栏";
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
                            <img id="hiddenIco" src="../../images/tool-01.gif" style="vertical-align: top; cursor: pointer;"
                                onclick="switchBar(this)" title="" />用户信息
                        </td>
                        <td>
                            <ul>
                                <li><a href="../../UserLocation/UserSettings/UserInfo.aspx">
                                    <img src="../../images/tb-list16.gif" /><span>基本信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/add.gif" /><span>附加信息</span></a></li>
                                <li><a href="../../UserLocation/UserSettings/UpdateUserBaseInfo.aspx">
                                    <img src="../../images/add.gif" /><span>修改基本信息</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form" style="text-align: center;">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" style="vertical-align: top;" />
                        <asp:Label ID="lblTitle" runat="server" Text="基本信息"></asp:Label>
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right;">
                                用户编号：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblID" runat="server" Text="lblID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                用户角色：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblRole" runat="server" Text="lblRole"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                登录名称：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblLoginName" runat="server" Text="lblLoginName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                创建时间：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblCreateTime" runat="server" Text="lblCreateTime"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                真实姓名：</td>
                            <td style="text-align: left;">
                                <input id="txtRealName" type="text" class="textStyle" style="width: 200px;" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:DropDownList ID="ddlSex" runat="server">
                                        <asp:ListItem Value="1" Text="男"></asp:ListItem>
                                        <asp:ListItem Value="0" Text="女"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                出生日期：</td>
                            <td style="text-align: left;">
                                <input id="txtBirthday" type="text" class="textStyle" style="width: 200px;" runat="server" readonly="readonly" onfocus="new WdatePicker({dateFmt:'yyyy/MM/dd',skin:'whyGreen'});"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                联系电话：</td>
                            <td style="text-align: left;">
                                <input id="txtTel" type="text" class="textStyle" style="width: 200px;" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                电子邮件：</td>
                            <td style="text-align: left;">
                                <input id="txtEMail" type="text" class="textStyle" style="width: 200px;" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;"></td>
                            <td style="text-align: left;">
                                <span class="btnStyle">
                                    <asp:Button ID="btnUpdate" runat="server" Text="修改" CssClass="btn" OnClick="btnUpdate_Click" />
                                </span>
                                <span class="btnStyle">
                                    <asp:Button ID="btnCancel" runat="server" Text="取消" CssClass="btn" />
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
