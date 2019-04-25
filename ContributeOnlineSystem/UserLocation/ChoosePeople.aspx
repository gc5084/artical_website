<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChoosePeople.aspx.cs" Inherits="UserLocation_ChoosePeople" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>选择人员</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/select.js"></script>
</head>
<body style="background-color: #dfe8f6">
    <form id="form1" runat="server">
        <div id="main">
            <table style="width: 550px; height: 350px;" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td style="height: 35px;" align="center">
                        <table width="80%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <img src="../images/ico.gif" width="15" height="15" align="top" />
                                    <strong>选择人员</strong></td>
                                <td>
                                    <label>
                                        <input name="radio" type="radio" id="radio" value="radio" checked="checked" align="top" />类型1</label>
                                    <label>
                                        <input type="radio" name="radio" id="radio1" value="radio" />类型2</label>
                                    <label>
                                        <input type="radio" name="radio" id="radio2" value="radio" />类型3</label>
                                </td>
                                <td>
                                    <label>
                                        <span class="btnStyle">
                                            <input type="submit" name="button" id="button" value="提交" class="btn" /></span>
                                    </label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="300" valign="top">
                        <div style="width: 400px; background: #FFFFFF; border: solid 1px #8db2e3; margin-left: auto;
                            margin-right: auto; padding: 20px;">
                            <table width="98%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td>
                                        <div class="selectStyle">
                                            <asp:DropDownList ID="ddlPeople" runat="server">
                                                <asp:ListItem Text="人员一" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="人员二" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td width="60px" rowspan="2" align="center">
                                        <label style=" margin-left:20px;">
                                            <span class="btnStyle">
                                                <input type="button" name="button3" id="button1" value="--->" class="btn" /></span>
                                        </label>
                                        <br />
                                        <br />
                                        <label>
                                            <span class="btnStyle">
                                                <input type="button" name="button3" id="button2" value="->>" class="btn" /></span>
                                        </label>
                                        <br />
                                        <br />
                                        <label>
                                            <span class="btnStyle">
                                                <input type="button" name="button3" id="button3" value="<---" class="btn" /></span>
                                        </label>
                                        <br />
                                        <br />
                                        <label>
                                            <span class="btnStyle">
                                                <input type="button" name="button3" id="button4" value="<<-" class="btn" /></span>
                                        </label>
                                    </td>
                                    <td>
                                        <input name="" type="text" class="textStyle" style="width: 86px;" value=""
                                            onclick="this.value='';" />
                                        <label>
                                            <span class="btnStyle">
                                                <input type="submit" name="button2" id="Submit1" value="查找" class="btn" /></span>
                                        </label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input name="" type="text" class="textStyle" style="width: 144px; height: 240px" /></td>
                                    <td>
                                        <input name="input" type="text" class="textStyle" style="width: 144px; height: 240px" /></td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
