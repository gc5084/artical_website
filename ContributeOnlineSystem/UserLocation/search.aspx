<%@ Page Language="C#" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

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
        <div id="main">
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="images/tool-01.gif" align="top" onclick="switchBar(this)"
                                title="鍏抽棴宸︿晶绠＄悊鑿滃崟" style="cursor: pointer;" />
                            鑷畾涔夋枃浠跺簱</td>
                        <td>
                            <ul>
                                <li><a href="#">
                                    <img src="../images/tb-list16.gif" /><span>鍒楄〃</span></a></li>
                                <li><a href="#">
                                    <img src="../images/add.gif" /><span>鏂板缓</span></a></li>
                                <li><a href="#">
                                    <img src="../images/nav.gif" /><span>瀵艰埅</span></a></li>
                                <li><a href="#">
                                    <img src="../images/bingtu.gif" /><span>楗煎浘</span></a></li>
                                <li><a href="#">
                                    <img src="../images/qushi.gif" /><span>瓒嬪娍鍥?</span></a></li>
                                <li><a href="#">
                                    <img src="../images/help.gif" /><span>甯姪</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <form id="form2" name="form1" method="post" action="">
                    <fieldset>
                        <legend>
                            <img src="../images/sousuo.gif" align="top" />
                            鏂囦欢鏌</legend>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="10%">
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    鏂囦欢搴?</td>
                                <td>
                                    <div id="selectStyle">
                                        <select name="name01" id="name01">
                                            <option>涓ラ噸锛堜笉鑳藉伐浣滐級</option>
                                            <option>涓瓑锛堝共鎵板伐浣滐級</option>
                                            <option>杞诲井锛堝彲浠ュ伐浣滐級</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    閲嶈姒傜巼</td>
                                <td>
                                    <div id="Div1">
                                        <select name="name02" id="name02">
                                            <option>蹇呯劧鍑虹幇</option>
                                            <option>鏈夎寰嬪嚭鐜?</option>
                                            <option>鏃犺寰嬪嚭鐜?</option>
                                            <option>鍙嚭鐜颁竴娆?</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    缂洪櫡绫诲瀷</td>
                                <td>
                                    <div id="Div2">
                                        <select name="name03" id="name03">
                                            <option>鐣岄潰缂洪櫡</option>
                                            <option>浠ｇ爜閿欒</option>
                                            <option>杩愯鐜缂洪櫡</option>
                                            <option>閲嶅缂洪櫡</option>
                                        </select>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    鏂囦欢缂栧彿</td>
                                <td>
                                    <input type="text" name="textfield" id="textfield" class="textStyle" style="width: 23%;" /></td>
                            </tr>
                            <tr>
                                <td align="right">
                                    鏇存柊鑰?</td>
                                <td>
                                    <input type="text" name="textfield" id="text1" class="textStyle" style="width: 23%;" /></td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <label>
                                        <span class="btnStyle">
                                            <input type="submit" name="button" id="button" value="鏌ヨ" class="btn" /></span>
                                    </label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                </form>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search_result">
                <tr>
                    <td style="padding-left: 10px;">
                        <img src="../images/result.gif" align="top" />
                        鏌ヨ缁撴灉</td>
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
                        瀵瑰簲椤圭洰闇€姹?</td>
                    <td>
                        瀵瑰簲椤圭洰鐢ㄤ緥</td>
                    <td>
                        涓ラ噸鎬?</td>
                    <td>
                        缂洪櫡绫诲瀷</td>
                    <td>
                        褰撳墠鐘舵€?</td>
                    <td>
                        瀹℃壒淇℃伅</td>
                    <td>
                        浼樺厛绾?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
                        鎶€鏈璁＄己闄?</td>
                    <td>
                        鏂扮殑</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        楂?</td>
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
