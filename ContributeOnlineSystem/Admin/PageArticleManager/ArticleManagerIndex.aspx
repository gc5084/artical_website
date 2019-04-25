<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ArticleManagerIndex.aspx.cs" Inherits="Admin_PageArticleManager_ArticleManagerIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>稿件信息管理</title>
    <link href="../css/publicCss.css"rel="stylesheet" type="text/css" />
    <link href="../css/SpryTabbedPanels.css" rel="stylesheet" type="text/css" />
    
    <style type = "text/css">
        .linkBtn{
            color:BLUE;
            text-decoration:underline;
        }
    </style>
    
    <script type="text/javascript" src="../js/select.js"></script>
    <script type = "text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="";
		    document.getElementById("hiddenIco").src="../images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="15%,*";
		    displayBar=true;
		    obj.title="";
		    document.getElementById("hiddenIco").src="../images/tool-01.gif";
	    }
    }
    //-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
            <div>
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../images/tool-01.gif" style=" vertical-align:top" onclick="switchBar(this)"
                                title="稿件信息列表"alt="" />稿件信息列表</td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            
                <asp:GridView ID="GVArtlicle" runat="server" AutoGenerateColumns="false" 
                CssClass="list" Width="100%" >
                 <HeaderStyle CssClass="listTitle" />
                 <Columns> 
                    <asp:TemplateField HeaderText="稿件编号">
                    <ItemStyle Width="100px" Height="30px" HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("Article_ID")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="作者姓名">
                    <ItemStyle  HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("UserInfo_RealName")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="中文标题">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("Article_ChineseTitle")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="英文标题">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("Article_EnglishTitle")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                   
                    
                    <asp:TemplateField HeaderText="文章字数">
                    <ItemStyle  HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("Article_WordCount")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    
                    <asp:TemplateField HeaderText="文章种类">
                    <ItemStyle HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("ArticleType_Name")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="文章状态">
                    <ItemStyle Width="180px" HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("ArticleState_Name")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText=" ">
                    <ItemStyle Width="100px" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton ID="LbDelete" OnClientClick="return confirm('确认删除！')"  CommandArgument='<%#Eval("Article_ID")%>' 
                        OnClick="OnDelArticle" CssClass="linkBtn" runat="server" Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                    </asp:TemplateField>

                 </Columns>
                </asp:GridView>
                <br /><br /><br />
                <div>
                <table>
                 <tr>
                 <td style="width:45%; text-align:right;">
                    <asp:Label ID="Label1" runat="server" Text="当前页： 第 "></asp:Label>
                    <asp:Label ID="LBCurrntNum" runat="server" Text=""></asp:Label>页
                    <asp:Label ID="label3" runat="server" Text="    共"></asp:Label>
                    <asp:Label ID="LBSumNum" runat="server" Text=""></asp:Label>页
                     </td>
                    <td style="width:10%; text-align:left;">
                    <span class="btnStyle">
                    <asp:Button ID="BTPre" runat="server" Text="上一页" Width="70px" CssClass="btn" OnClick="BTPre_Click"/>
                    </span>
                    </td>
                    <td>
                    <span class="btnStyle">
                    <asp:Button ID="BTNext" runat="server" Text="下一页" Width="70px" CssClass="btn" OnClick="BTNext_Click"/>
                    </span>
                    </td>
                  </tr>
                 </table>
                </div>
            </div>
    </div>
 
    </form>
</body>
</html>
