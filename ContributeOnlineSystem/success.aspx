<%@ Page Language="C#" AutoEventWireup="true" CodeFile="success.aspx.cs" Inherits="success" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form style="height:100%;" id="form1" runat="server">
    <div style="height:100%;" >
      <table style="height:100%; width:100%;">
      <tr><td><br/><br/><br/><br/><br/><br/></td></tr>
      <tr><td style="text-align:right; font-size:x-large;">操作成功! &nbsp; &nbsp; &nbsp;</td>
         <td><span class="btnStyle"> <asp:Button ID="Button1" CssClass="btn" runat="server" Text="返回" onclick="Button1_Click" /></span></td>
      </tr>
      </table>
    </div>
    </form>
</body>
</html>
