<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageDetail.aspx.cs" Inherits="UserLocation_InformationCenter_MessageDetail" %>

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
                        <img src="../../images/drop-add.gif" style=" vertical-align:top;"/>消息明细
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right;">
                                消息编号：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblID" runat="server" Text="lblID"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                消息类型：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblType" runat="server" Text="lblType"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                发送者：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblSender" runat="server" Text="lblSender"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                接受者：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblReceiver" runat="server" Text="lblReceiver"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                消息内容：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtMessageContent" ReadOnly="true" TextMode="MultiLine" CssClass="textStyle" Width="200" Rows="4" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                发送时间：</td>
                            <td style="text-align: left;">
                                <input id="txtTime" type="text" readonly="readonly" class="textStyle" style="width: 200px;" runat="server" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
