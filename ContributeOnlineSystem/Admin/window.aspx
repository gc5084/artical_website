<%@ Page Language="C#" AutoEventWireup="true" CodeFile="window.aspx.cs" Inherits="window" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/select.js"></script>
</head>
<body bgcolor="#dfe8f6">
    <form id="form1" runat="server">
    <div id="main">
<table width="550" height="350" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td height="35" align="center"><table width="80%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td><img src="images/ico.gif" width="15" height="15" align="top" /> <strong>璇烽€夋嫨鐢ㄦ埛</strong></td>
        <td>鏌ヨ鏂瑰紡锛?
          <label>
            <input name="radio" type="radio" id="radio" value="radio" checked="checked" align="top" /> 鎸夐儴闂?         </label>
          <label>
            <input type="radio" name="radio" id="radio1" value="radio" /> 鎸夐儴闂?         </label>
          <label>
            <input type="radio" name="radio" id="radio2" value="radio" /> 鎸夐儴闂?         </label>          </td>
        <td><label>
          <span class="btnStyle"><input type="submit" name="button" id="button" value="鎻愪氦"  class="btn"/></span>
        </label></td>
      </tr>
    </table></td>
  </tr>
  <tr>
    <td height="300" valign="top">
     <div style=" width:400px; background:#FFFFFF; border:solid 1px #8db2e3; margin-left:auto; margin-right:auto; padding:20px;">
      <table width="98%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><div id="selectStyle">
                <select name="name01" id="name01">
                   <option>鐮斿彂閮</option>
                   <option>鍔炲叕瀹</option>
                   <option>涓氬姟閮</option>
                </select>
              </div></td>
          <td width="100" rowspan="2" align="center">
          <label>
            <span class="btnStyle">
            <input type="button" name="button3" id="button3" value="--->" class="btn" /></span>
          </label>
          <br /><br />
          <label>
            <span class="btnStyle">
            <input type="button" name="button3" id="button1" value="->>" class="btn" /></span>
          </label>
           <br /><br />
          <label>
            <span class="btnStyle">
            <input type="button" name="button3" id="button2" value="<---" class="btn" /></span>
          </label>
           <br /><br />
          <label>
            <span class="btnStyle">
            <input type="button" name="button3" id="button4" value="<<-" class="btn" /></span>
          </label>
          </td>
          <td>
            <input name="" type="text" class="textStyle" style="width:86px;" value="鏌ヨ鏉′欢" onclick="this.value='';" />
            <label>
            <span class="btnStyle"><input type="submit" name="button2" id="Submit1" value="鏌ヨ" class="btn" /></span>            </label></td>
        </tr>
        <tr>
          <td><input name="" type="text" class="textStyle" style="width:144px; height:240px" /></td>
          <td><input name="input" type="text" class="textStyle" style="width:144px; height:240px" /></td>
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
