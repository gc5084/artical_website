<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="js/select.js"></script>

	<script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="展开窗口";
		    document.getElementById("hiddenIco").src="images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="20%,*";
		    displayBar=true;
		    obj.title="窗口折叠";
		    document.getElementById("hiddenIco").src="images/tool-01.gif";
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
                            <img id="hiddenIco" src="images/tool-01.gif" align="top" onclick="switchBar(this)"
                                title="鍏抽棴宸︿晶绠＄悊鑿滃崟" style="cursor: pointer;" />
                            缂洪櫡璺熻釜</td>
                        <td>
                            <ul>
                                <li><a href="#">
                                    <img src="images/tb-list16.gif" /><span>鍒楄〃</span></a></li>
                                <li><a href="#">
                                    <img src="images/add.gif" /><span>鏂板缓</span></a></li>
                                <li><a href="#">
                                    <img src="images/nav.gif" /><span>瀵艰埅</span></a></li>
                                <li><a href="#">
                                    <img src="images/bingtu.gif" /><span>楗煎浘</span></a></li>
                                <li><a href="#">
                                    <img src="images/qushi.gif" /><span>瓒嬪娍鍥?/span></a></li>
                                <li><a href="#">
                                    <img src="images/help.gif" /><span>甯姪</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search">
                <tr>
                    <td width="40" align="center">
                        <img src="images/sousuo.gif" /></td>
                    <td width="120">
                        <label>
                            <input type="text" name="textfield" id="textfield" class="textStyle" size="15" />
                        </label>
                    </td>
                    <td width="160">
                        <div id="selectStyle">
                            <select name="name01" id="name01">
                                <option>鍏ㄩ儴</option>
                                <option>涓ラ噸锛堜笉鑳藉伐浣滐級</option>
                                <option>涓瓑锛堝共鎵板伐浣滐級</option>
                                <option>杞诲井锛堝彲浠ュ伐浣滐級</option>
                            </select>
                        </div>
                    </td>
                    <td width="160">
                        <div id="Div1">
                            <select name="name02" id="name02">
                                <option>涓ラ噸锛堜笉鑳藉伐浣滐級</option>
                                <option>涓瓑锛堝共鎵板伐浣滐級</option>
                                <option>杞诲井锛堝彲浠ュ伐浣滐級</option>
                            </select>
                        </div>
                    </td>
                    <td>
                        <label>
                            <input type="text" name="textfield3" id="textfield3" class="textStyle" />
                        </label>
                    </td>
                    <td align="right" style="padding-right: 10px;">
                        <span class="btnStyle">
                            <input type="button" name="button3" id="button3" value="鎼滅储" class="btn" />
                        </span>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="list">
                <tr class="listTitle">
                    <td class="firstTd">
                        &nbsp;</td>
                    <td>
                        缂洪櫡缂栧彿</td>
                    <td>
                        缂洪櫡鏍囬</td>
                    <td>
                        缂洪櫡鎻忚堪</td>
                    <td>
                        瀵瑰簲椤圭洰闇€姹?/td>
                        <td>
                            瀵瑰簲椤圭洰鐢ㄤ緥</td>
                        <td>
                            涓ラ噸鎬?/td>
                            <td>
                                缂洪櫡绫诲瀷</td>
                            <td>
                                褰撳墠鐘舵€?</td>
                                <td>
                                    瀹℃壒淇℃伅</td>
                                <td>
                    浼樺厛绾?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
                <tr>
                    <td class="firstTd">
                        1</td>
                    <td>
                        BUG-0001</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤妯″潡鍔熻兘鍑洪敊</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯</td>
                    <td>
                        淇＄敤璇勪及鍔熻兘娴嬭瘯~~~</td>
                    <td>
                        涓ラ噸锛堜笉鑳藉伐浣滐級</td>
                    <td>
                        鎶€鏈璁＄己闄?/td>
                        <td>
                            鏂扮殑</td>
                        <td>
                            &nbsp;</td>
                        <td>
                    楂?/td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page">
                <tr>
                    <td align="right">
                        鍒嗛〉</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
