<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="UserLocation_InformationCenter_MessageList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
		    document.getElementById("hiddenIco").src="./images/tool-02.gif";
	    }
	    else
	    {
		    this.parent.frame.cols="20%,*";
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
                            <img id="hiddenIco" src="../../images/tool-01.gif" style="vertical-align: top; cursor: pointer;"
                                onclick="switchBar(this)" title="" />我的稿件
                        </td>
                        <td>
                            <ul>
                                <li><a href="#">
                                    <img src="../../images/tb-list16.gif" /><span>未读信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/add.gif" /><span>已读信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/nav.gif" /><span>写信息</span></a></li>
                                <li><a href="#">
                                    <img src="../../images/bingtu.gif" /><span>所有信息</span></a></li>
                            </ul>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="form">
                <fieldset>
                    <legend>
                        <img src="../../images/drop-add.gif" style="vertical-align: top;" />
                        <asp:Label ID="lblTitle" runat="server" Text="所有信息"></asp:Label>
                    </legend>
                    <asp:GridView ID="gvMessageList" runat="server" AutoGenerateColumns="false" CssClass="list">
                        <HeaderStyle CssClass="listTitle" />
                        <Columns>
                            <asp:TemplateField HeaderText="消息编号">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_ID")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="消息类型">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_Type")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送者">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_SenderID")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="接收者">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_ReceiverID")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="消息内容">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_Content")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="发送时间">
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <%#Eval("Message_Time")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField>
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnCheck" runat="server" CssClass="linkBtn" OnClick="btnCheck_Click" CommandArgument='<%#Eval("Message_ID")%>'>详细信息</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemStyle Width="150px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete" runat="server" CssClass="linkBtn">删除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>
                            没有该类消息！
                        </EmptyDataTemplate>
                    </asp:GridView>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
