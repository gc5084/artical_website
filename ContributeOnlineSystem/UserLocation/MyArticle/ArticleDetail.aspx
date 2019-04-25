<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleDetail.aspx.cs" Inherits="UserLocation_MyArticle_ArticleDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>稿件信息展示页面</title>
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
		    document.getElementById("hiddenIco").src="../../images/tool-02.gif";
	    }
	    else
	    {
		    this.parent.frame.cols="20%,*";
		    displayBar=true;
		    obj.title="";
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
                            <img id="hiddenIco" src="../../images/tool-01.gif" style=" vertical-align:top;cursor: pointer;" onclick="switchBar(this)" title="" />我的稿件
                        </td>
                        <td>

                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" style=" vertical-align:top;"/>我的稿件
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right; width:20%;">
                                中文标题：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChineseTitle" runat="server" Text="lblChineseTitle"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文标题：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblEnglishTitle" runat="server" Text="lblEnglishTitle"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                中文摘要：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChineseResume" runat="server" Text="lblChineseResume"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文摘要：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblEnglishResume" runat="server" Text="lblEnglishResume"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                中文关键字：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblChineseKey" runat="server" Text="lblChineseKey"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文关键字：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblEnglishKey" runat="server" Text="lblEnglishKey"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                所属栏目：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:Label ID="lblColumn" runat="server" Text="lblColumn"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                稿件种类：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:Label ID="lblType" runat="server" Text="lblType"></asp:Label>
                                </div>
                            </td>
                        </tr>
                       
                        <tr>
                            <td style="text-align: right;">
                                字数：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblCount" runat="server" Text="lblCount"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                作者简介：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblAuthorResume" runat="server" Text="lblAuthorResume"></asp:Label>                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                邮箱：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblEMail" runat="server" Text="lblEMail"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                署名作者：</td>
                            <td style="text-align: left;">
                                <asp:Label ID="lblAuthorName" runat="server" Text="lblAuthorName"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                下载附件：</td>
                            <td style="text-align: left;">
                                <a id="aUpdown" href='' runat="server">
                                    <asp:Label ID="lblLinkName" runat="server" Text="lblLinkName" style="color:Blue; padding-left:5px;"></asp:Label>
                                </a>
                                <span style="color:Red">&nbsp; &nbsp; 提示： 如不弹出下载框请用右键->目标另存为下载</span>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                </td>
                            <td style="text-align: left;">
                                <asp:Panel ID="PlSubmit" runat="server">
                                    <span class="btnStyle" style=" margin-right:10px">
                                    <asp:Button ID="btnSubmit" runat="server" Text="填写评审意见" CssClass="btn" OnClick="btnSubmit_Click"  />
                                </span>
                                </asp:Panel>
                            
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hfdArticleID" runat="server" />
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>

