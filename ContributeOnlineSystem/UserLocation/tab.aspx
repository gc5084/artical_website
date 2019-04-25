<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tab.aspx.cs" Inherits="tab" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <script src="../js/SpryTabbedPanels.js" type="text/javascript"></script>
    <link href="../css/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="鎵撳紑宸﹁竟绠＄悊鑿滃崟";
		    document.getElementById("hiddenIco").src="../images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="15%,*";
		    displayBar=true;
		    obj.title="鍏抽棴宸﹁竟绠＄悊鑿滃崟";
		    document.getElementById("hiddenIco").src="../images/tool-01.gif";
	    }
    }
    //-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="topMenu">
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img id="hiddenIco" src="../images/tool-01.gif" align="top" title="鍏抽棴宸﹁竟绠＄悊鑿滃崟" onclick="switchBar(this)" style="cursor:pointer;" /> 閫夐」鍗￠〉闈?</td>
          <td>
            <ul>
              <li><a href="#"><img src="../images/tb-list16.gif" /><span>鍒楄〃</span></a></li>
              <li><a href="#"><img src="../images/add.gif" /><span>鏂板缓</span></a></li>
              <li><a href="#"><img src="../images/nav.gif" /><span>瀵艰埅</span></a></li>
              <li><a href="#"><img src="../images/bingtu.gif" /><span>楗煎浘</span></a></li>
              <li><a href="#"><img src="../images/qushi.gif" /><span>瓒嬪娍鍥?</span></a></li>
              <li><a href="#"><img src="../images/help.gif" /><span>甯姪</span></a></li>
            </ul>
          </td>
        </tr>
      </table>
</div>
<div style="padding:10px;">
<div id="TabbedPanels1" class="TabbedPanels">
  <ul class="TabbedPanelsTabGroup">
    <li class="TabbedPanelsTab" tabindex="0"><span>鍩烘湰淇℃伅</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>椤圭洰鎴愬憳</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 3</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 4</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 5</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 6</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 7</span></li>
    <li class="TabbedPanelsTab" tabindex="0"><span>Tab 8</span></li>
  </ul>
  <div class="TabbedPanelsContentGroup">
    <div class="TabbedPanelsContent">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
        <tr>
          <td class="name">椤圭洰绠€绉?</td>
          <td>000000</td>
          <td class="name">椤圭洰鍚嶇О</td>
          <td>000000</td>
        </tr>
      </table>
      
      <div style="padding-top:20px;">
        <p style="padding-bottom:6px;"><input name="name" type="radio" value="" />鏄剧ず浜ゆ祦璁板綍<input name="name" type="radio" value="" checked="checked" />
        鏂板缓浜ゆ祦璁板綍</p>
        <p style="padding-bottom:6px;"><textarea name="textarea" id="textarea" cols="95" rows="5" class="textStyle"></textarea></p>
        <p><span class="btnStyle"><input type="submit" name="button" id="button" value="鎻愪氦"  class="btn"/></span></p>
      </div>
    </div>
    <div class="TabbedPanelsContent">鍐呭 2</div>
    <div class="TabbedPanelsContent">鍐呭 3</div>
    <div class="TabbedPanelsContent">鍐呭 4</div>
    <div class="TabbedPanelsContent">鍐呭 5</div>
    <div class="TabbedPanelsContent">鍐呭 6</div>
    <div class="TabbedPanelsContent">鍐呭 7</div>
    <div class="TabbedPanelsContent">鍐呭 8</div>
  </div>
</div>
<script type="text/javascript">
<!--
var TabbedPanels1 = new Spry.Widget.TabbedPanels("TabbedPanels1");
//-->
</script>
</div>
    </form>
</body>
</html>
