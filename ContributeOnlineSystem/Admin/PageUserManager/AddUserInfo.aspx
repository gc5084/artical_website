<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUserInfo.aspx.cs" Inherits="Admin_PageUserManager_AddUserInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户列表</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
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
    <div id="main">
        <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../images/tool-01.gif" style=" vertical-align:top" onclick="switchBar(this)"
                                title="用户信息列表"alt="" />用户信息列表</td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
        <div id="UserListDiv">
        <asp:GridView ID="gvUserList" runat="server" AutoGenerateColumns="false" DataKeyNames ="Id" CssClass="list">
            <HeaderStyle CssClass="listTitle" />
            <Columns>
            
                <asp:TemplateField HeaderText="用户编号">
              
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("Id")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户角色">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("RoleInfo.Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="用户名称">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("Name")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="密码">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("Pwd")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="真实姓名">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("RealName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="联系电话">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("Tel")%>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="邮箱">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <%#Eval("Email")%>
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:TemplateField HeaderText=" ">
                    <ItemStyle Width="150" HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%#Eval("Id")%>' OnClientClick="return confirm('确认删除！')"  OnClick ="btnDelete_Click"  CssClass="linkBtn"  Text="删除"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                
            </Columns>
        </asp:GridView>
            &nbsp;
    </div>
    </div>
    </form>
</body>
</html>
