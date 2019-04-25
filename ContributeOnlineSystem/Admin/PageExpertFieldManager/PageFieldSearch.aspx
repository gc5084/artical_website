<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PageFieldSearch.aspx.cs" Inherits="Admin_PageExpertFieldManager_PageFieldSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
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
                                title="专家领域管理"alt="" />专家领域管理</td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
    <div id="GV" style="text-align:center">
        <asp:GridView ID="gvExpertFiled" runat="server" AutoGenerateColumns="False" 
        Width="100%" OnRowDeleting="gvExpertFiled_RowDeleting" CssClass="list">
        <HeaderStyle CssClass="listTitle" />
        <FooterStyle CssClass="listTitle" />
            <Columns>
            
                <asp:TemplateField HeaderText="领域编号">
                <ItemStyle Width="100px" />
                
                    <ItemTemplate>
                        <asp:Label ID="labId"  runat="server" Text='<%# (int)Eval("Field_ID")+1%>'></asp:Label>
                    </ItemTemplate>

                </asp:TemplateField>

                <asp:TemplateField HeaderText="领域名称">
                    <ItemTemplate>
                        <asp:Label ID="labName" runat="server" Text='<%# Eval("Field_Name")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="lbtnDel" runat="server" CommandName ="Delete"  CommandArgument='<%# Eval("Field_ID") %>' CssClass="linkBtn" OnClientClick="return confirm('确认删除？')" OnClick="lbtnDel_Click">删除</asp:LinkButton>
                    </ItemTemplate> 
                </asp:TemplateField>
                
            </Columns>
       
        
        </asp:GridView>
     </div>
        <br />
        <br />
        <br />
        <div id="form">
        <fieldset>
        <legend>
           <img src="../images/sousuo.gif" align="top" alt="" />
           <asp:Label ID="lblColumn" runat="server" Text="添加新领域"></asp:Label></legend>
        <br />
        <br />
        <table border="2" cellspacing="0" cellpadding="0" style="border-color:Black">
         <tr style="height:50px">
            <td  style="width:100px"><asp:Label runat ="server" ID="labName"  Text ="专家领域名称："></asp:Label></td>
            <td  style="width:150px"><asp:TextBox runat ="server" Width="130px" ID ="txtName"  CssClass="textStyle" Text =""></asp:TextBox></td>
            <td>
           <span class="btnStyle">
                <asp:Button runat ="server" Width="70px" Text ="增加" ID="btnAddFiled" OnClick ="btnAddFiled_Click" CssClass="btn"/>
            </span>
           </td>
         </tr>
         
        </table>
        </fieldset>
        </div>
        &nbsp;</div>
    </form>
</body>
</html>
