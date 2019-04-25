<%@ Page Language="C#" EnableEventValidation="false" AutoEventWireup="true" CodeFile="ArticleColumnSearch.aspx.cs" Inherits="Admin_PageArticleManager_ArticleColumnSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/select.js"></script>
    
    <style type = "text/css">
        .linkBtn{
            color:BLUE;
            text-decoration:underline;
        }
    </style>

    <script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="窗口折叠";
		    document.getElementById("hiddenIco").src="../images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="15%,*";
		    displayBar=true;
		    obj.title="展开窗口";
		    document.getElementById("hiddenIco").src="../images/tool-01.gif";
	    }
    }
    
    //全选
    function CheckAll(checkType)
    {
        var checks = document.getElementsByTagName("input");

        
        for(i = 0; i < checks.length; i++)
        {
            if(checks[i].type == "checkbox")
            {
                checks[i].checked = checkType;      
            } 
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
                            <img id="hiddenIco" src="../images/tool-01.gif" alt="" align="top" onclick="switchBar(this)"
                                title="" style="cursor: pointer;" />&nbsp;&nbsp;&nbsp;栏目设置</td>
                        <td>
                           
                        </td>
                    </tr>
                </table>
            </div>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search_result">
                <tr>
                    <td style="padding-left: 10px;">
                        <img src="../images/result.gif" align="top" alt="" />
                        全部栏目列表</td>
                </tr>
            </table>     
            <asp:Repeater ID="RepArticlec" runat="server" OnItemCommand="RepArticlec_ItemCommand">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="list">
                        <tr class="listTitle">
                            <td class="firstTd" style="height: 23px; width: 29px;">
                                编号</td>
                            <td style="height: 23px; width: 48px;">
                                <asp:CheckBox ID="CheckAll" runat="server" onclick="CheckAll(this.checked)" Text="全选" Width="45px" />
                            </td>
                            <td style="height: 23px; width: 80px;"> 稿件栏目名称</td>
                            <td style="height: 23px; width: 80px;"> 负责编辑姓名</td>
                            <td style="height: 23px; width: auto;">稿件栏目描述 </td>
                            <td style="height:23px; width:50px;">&nbsp;</td>
                            <td style="height:23px; width:50px;">&nbsp;</td>
                        </tr>
                     </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td class="firstTd" style="width: 29px">
                                <asp:Label runat="server" ID="ArticleColumn_ID" Text='<%# Eval("ArticleColumn_ID") %>'></asp:Label>  </td>
                            <td style="width: 48px">
                                <asp:CheckBox ID="chb" name="chb" runat="server" />
                            </td>
                            <td style="width: 159px">
                                <%# Eval("ArticleColumn_Name")%></td>
                            <td style="width: 159px">
                                <%# Eval("UserInfo_RealName")%></td>
                            <td>
                                <%# Eval("ArticleColumn_Description") %></td>
                            <td>
                                <asp:LinkButton runat="server" CommandArgument='<%# Eval("ArticleColumn_ID") %>' ID="btnDel" OnClientClick="return confirm('确认删除吗？');"
                                  CommandName="Delete" CssClass="linkBtn"  Text="删除"></asp:LinkButton></td>
                            <td>
                                <asp:LinkButton runat="server" CommandArgument='<%# Eval("ArticleColumn_ID") %>' CommandName="Update" CssClass="linkBtn" ID="btnUpdate" Text="修改"></asp:LinkButton></td>
                        </tr>
                     </ItemTemplate>
                <FooterTemplate>
                    </table>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page">
                            <tr>
                                <td align="left" style="height: 22px">&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:LinkButton runat="server" name="button" ID="btnDeleteALL" CommandName="DeleteAll" Text="删除所选项" Width="80px" ></asp:LinkButton>
                                </td>
                            </tr>
                    </table> 
                     </FooterTemplate>
            </asp:Repeater>                     
            <div id="form">
                <form id="form2" name="form1" method="post" action="">
                    <fieldset>
                        <legend>
                            <img src="../images/sousuo.gif" align="top" alt="" />
                            <asp:Label ID="lblColumn" runat="server" Text="添加新栏目"></asp:Label></legend>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td style="width: 74px">
                                    &nbsp;</td>
                                <td>
                                    <asp:Label runat="server" ID="lblId" Text="" Visible="false" ></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 74px">
                                    稿件栏目名称</td>
                                <td>
                                    <asp:TextBox runat="server" ID="txtName" name="textfield" CssClass="textStyle" Width="209px" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>负责编辑姓名</td>
                                <td>
                                    <div class="selectStyle">
                                        <asp:DropDownList ID="DropName" runat="server" Width="127px" >
                                        </asp:DropDownList>
                                    </div>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 74px; height: auto;">
                                    稿件栏目描述</td>
                                <td style="height: auto;">
                                    <asp:TextBox runat="server" ID="txtDepict" name="textfield" CssClass="textStyle" Height="70px" TextMode="MultiLine" Width="435px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 74px; height: 27px;">
                                    &nbsp;</td>
                                <td style="height: 27px">
                                    <label>
                                        <span class="btnStyle">
                                            <asp:Button runat="server" ID="btnAdd" Text="保 存" CssClass="btn" name="button" OnClick="btnAdd_Click" />
                                        </span>
                                    </label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </form>
            </div>
        </div>
        </form>       
</body>
</html>
