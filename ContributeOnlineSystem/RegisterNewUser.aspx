<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegisterNewUser.aspx.cs" Inherits="RegisterNewUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>稿件信息展示页面</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="js/Blue.js"></script>
    <script type="text/javascript" src="js/select.js"></script>
    <script type="text/javascript" src="js/Regist.js"></script>
    

    

</head>
<body>
    <form id="form1" runat="server">
        <div id="main">
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="images/tool-01.gif" style="vertical-align: top; cursor: pointer;"
                                 title="" />用户注册
                        </td>
                        <td>
                           
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img src="images/drop-add.gif" style="vertical-align: top;" />用户注册</legend>
                        <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right;">
                              <span style="color:Red">*</span>  用户名称：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtUserName" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必填字段" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                              <span style="color:Red">*</span>  用户密码：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必填字段" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                              <span style="color:Red">*</span>  重复输入密码：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtPasswordAgain" TextMode="Password" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ErrorMessage="密码不一致" ControlToCompare="txtPassword" ControlToValidate="txtPasswordAgain"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                             <span style="color:Red">*</span>   真实姓名：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtRealName" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="必填字段" ControlToValidate="txtRealName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                性别：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                <asp:DropDownList ID="ddlSex" runat="server">
                                    <asp:ListItem Text="男" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="女" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                            <span style="color:Red">*</span>    生日：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtBirthday" runat="server" Width="200" CssClass="textStyle" onfocus="new WdatePicker({dateFmt:'yyyy/MM/dd',skin:'whyGreen'});"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="必填字段" ControlToValidate="txtBirthday"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                联系电话：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtTel" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                             <span style="color:Red">*</span>   电子邮件：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtEMail" runat="server" Width="200" CssClass="textStyle"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                </td>
                            <td style="text-align: left;">
                                <span class="btnStyle">
                                    <asp:Button ID="btnSubmit" runat="server" Text="注册用户" CssClass="btn" OnClick="btnSubmit_Click" />
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
