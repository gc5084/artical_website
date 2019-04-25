<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyArticle.aspx.cs" Inherits="UserLocation_MyArticle_ModifyArticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
                            <img alt="" id="hiddenIco" src="../../images/tool-01.gif" style=" vertical-align:top;cursor: pointer;" onclick="switchBar(this)" title="" />我要投稿
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img alt=""  src="../../images/drop-add.gif" style=" vertical-align:top;"/>修改稿件
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right;">
                             <span style="color:Red">*</span>    中文标题：</td>
                            <td style="text-align: left;">
                                <input id="txtChineseTitle" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                        ErrorMessage="必填字段" ControlToValidate="txtChineseTitle"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文标题：</td>
                            <td style="text-align: left;">
                                <input id="txtEnglishTitle" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                中文摘要：</td>
                            <td style="text-align: left;">
                                <input id="txtChineseResume" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文摘要：</td>
                            <td style="text-align: left;">
                                <input id="txtEnglishResume" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                中文关键字：</td>
                            <td style="text-align: left;">
                                <input id="txtChineseKey" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                英文关键字：</td>
                            <td style="text-align: left;">
                                <input id="txtEnglishKey" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                所属栏目：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:DropDownList ID="ddlColumn" runat="server" Width="300">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                稿件种类：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:DropDownList ID="ddlType" runat="server" Width="300">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td style="text-align: right;">
                             <span style="color:Red">*</span>    字数：</td>
                            <td style="text-align: left;">
                                <input id="txtCount" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                        ErrorMessage="必填字段" ControlToValidate="txtCount"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                作者简介：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtAuthorResume" runat="server" CssClass="textStyle" Width="200" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                邮箱：</td>
                            <td style="text-align: left;">
                                <input id="txtEMail" type="text" class="textStyle" style="width: 200px;" 
                                    runat="server" />
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="text-align: right;">
                                署名作者：</td>
                            <td style="text-align: left;">
                                <input id="txtAuthorName" type="text" class="textStyle" style="width: 200px;" 
                                    readonly="readonly" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                             <span style="color:Red">*</span>    附件：</td>
                            <td style="text-align: left;">
                                <asp:FileUpload ID="fulAccessories" runat="server" CssClass="textStyle" Width="272" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                </td>
                            <td style="text-align: left;">
                            <span class="btnStyle" style=" margin-right:10px">
                                <asp:Button ID="btnSubmit" runat="server" Text="修改完成" CssClass="btn" OnClick="btnSubmit_Click" />
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