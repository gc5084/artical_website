<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LayoutedArticle.aspx.cs" Inherits="UserLocation_MyArticle_LayoutedArticle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../css/publicCss.css" rel="stylesheet" type="text/css" />
    <style type = "text/css">
        .linkBtn{
            color:BLUE;
            text-decoration:underline;
        }
    </style>

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
    <div>
     <div id="main">
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../../images/tool-01.gif" style="vertical-align: top; cursor: pointer;"
                                onclick="switchBar(this)" title="" />切换视图
                        </td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" style="vertical-align: top;" />已出版稿件 </legend>
                    <div id="UserListDiv">
                        <asp:GridView ID="gvArticleList" runat="server" AutoGenerateColumns="false" CssClass="list">
                            <HeaderStyle CssClass="listTitle" />
                            <Columns>
                                <asp:TemplateField HeaderText="稿件编号">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("Article_ID")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="中文标题">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("Article_ChineseTitle")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="字数">
                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("Article_WordCount")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="稿件状态">
                                    <ItemStyle Width="160px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <%#Eval("ArticleState_Name")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnCheck" runat="server" CssClass="linkBtn" CommandArgument='<%#Eval("Article_ID")%>' OnClick="btnCheck_Click">详细信息</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                
                            
                                
                            </Columns>
                            <EmptyDataTemplate>
                                没有这类稿件信息！
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    </form>
</body>
</html>