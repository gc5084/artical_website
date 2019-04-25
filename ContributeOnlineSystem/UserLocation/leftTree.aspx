<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftTree.aspx.cs" Inherits="leftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../css/publicCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tree{
            padding:6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="trvNav" runat="server" Target = "project_actions_container">
            <DataBindings>
                <asp:TreeNodeBinding />
                <asp:TreeNodeBinding DataMember="siteMapNode" NavigateUrlField="url" TargetField="description"
                    TextField="title" />
            </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource ID="UserWorkXmlDataSource" runat="server" DataFile="~/UserLocation/xml/UserWorkNavTree.xml">
        </asp:XmlDataSource>
        <asp:XmlDataSource ID="AuthorXmlDataSource" runat="server" DataFile="~/UserLocation/xml/AuthorNavTree.xml">
        </asp:XmlDataSource>
        <asp:XmlDataSource ID="LayoutXmlDataSource" runat="server" DataFile="~/UserLocation/xml/LayoutUser.xml">
        </asp:XmlDataSource>
        <asp:XmlDataSource ID="ResponsibleXmlDataSource" runat="server" DataFile="~/UserLocation/xml/ResponsibleEditor.xml">
        </asp:XmlDataSource>
    </form>
</body>
</html>
