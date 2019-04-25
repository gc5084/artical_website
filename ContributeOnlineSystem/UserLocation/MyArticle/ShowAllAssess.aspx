<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ShowAllAssess.aspx.cs" Inherits="UserLocation_MyArticle_Default" %>

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
     <div>
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="../../images/tool-01.gif" style=" vertical-align:top" onclick="switchBar(this)"
                                title="评审信息列表"alt="" />评审信息列表</td>
                        <td>
                        </td>
                    </tr>
                </table>
            </div>
            
                <asp:GridView ID="GVAssess" runat="server" AutoGenerateColumns="false" 
                CssClass="list" Width="100%" >
                 <HeaderStyle CssClass="listTitle" />
                 <Columns> 
                    <asp:TemplateField HeaderText="评审批次">
                    <ItemStyle Width="130px" HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("ArticleState_Name")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="评论结果">
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("AssessResult_Name")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="评论者">
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                    <ItemTemplate>
                         <%#Eval("UserInfo_RealName")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="评语">
                    <ItemStyle Width="300px"  HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="TBMessage" Width="300px" CssClass="textStyle" Height="100px" runat="server" TextMode="MultiLine" Text='<%#Eval("AssessOpinion_Message")%>' ReadOnly="true"></asp:TextBox>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="备注">
                    <ItemStyle Width="80px"  HorizontalAlign="Center" />
                    <ItemTemplate>
                        <asp:TextBox ID="TBRemark"  Width="75px" CssClass="textStyle" Height="100px" runat="server" TextMode="MultiLine" Text='<%#Eval("AssessOpinion_Remark")%>' ReadOnly="true"></asp:TextBox>
                    </ItemTemplate>
                    </asp:TemplateField>
                 </Columns>
                 <EmptyDataTemplate>
                                还没有相应评审信息！
                            </EmptyDataTemplate>
                </asp:GridView>
                <br /><br />
                
                
                
            </div>
    </div>
        <div style="text-align:center;">
        <table style="width:100%;">
        <tr>
        <td style="width:45%"></td>
              <td><span class="btnStyle"> <asp:Button ID="BTBack" runat="server" Text="返回" CssClass="btn" OnClick="BTBack_Click" /></span></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
