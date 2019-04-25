<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddAssessOpinion.aspx.cs" Inherits="UserLocation_MyArticle_AddAssessOpinion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加评审意见</title>
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
                <table width="100%" border="2" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img  alt="" id="hiddenIco" src="../../images/tool-01.gif" style=" vertical-align:top;cursor: pointer;" onclick="switchBar(this)" title="" />评审稿件意见
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img  alt="" src="../../images/drop-add.gif" style=" vertical-align:top;"/>评审意见
                    </legend>
                    <table style="width: 100%;">
                        <tr>
                            <td style="text-align: right; height: 21px;">
                                评论者：</td>
                            <td style="text-align: left; height: 21px;">
                                <asp:Label ID="lblSend" runat="server" Text="lblSend"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                评审结果：</td>
                            <td style="text-align: left;">
                                <div class="selectStyle">
                                    <asp:DropDownList ID="ddlResult" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlResult_SelectedIndexChanged">
                                        <asp:ListItem Text="通过" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="未通过" Value="1"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        
                        <asp:Panel ID="PlExpert" runat="server">
                        <tr>
                            <td style="text-align: right;">
                                推荐专家：</td>
                            <td style="text-align: left;">
                                <asp:CheckBoxList ID="CblExpert" runat="server" RepeatColumns="5">
                                </asp:CheckBoxList>
                            </td>
                        </tr>
                        </asp:Panel>
                                               
                        <tr>
                            <td style="text-align: right;">
                                评语：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtMessage" CssClass="textStyle" Width="547px" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                备注：</td>
                            <td style="text-align: left;">
                                <asp:TextBox ID="txtRemark" CssClass="textStyle" Width="200" Rows="5" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right;">
                                </td>
                            <td style="text-align: left;">
                            <span class="btnStyle" style=" margin-right:10px">
                                <asp:Button ID="btnSubmit" runat="server" Text="提交评审结果" CssClass="btn" OnClick="btnSubmit_Click"  />
                            </span>
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
