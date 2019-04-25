<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leftTree.aspx.cs" Inherits="leftTree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #tree{
            padding:6px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="trvNav" runat="server" DataSourceID="AdminXmlDataSource" Target="project_actions_container">
            <DataBindings>
                <asp:TreeNodeBinding />
                <asp:TreeNodeBinding DataMember="siteMapNode" NavigateUrlField="url" TargetField="description"
                    TextField="title" />
            </DataBindings>
        </asp:TreeView>
        <asp:XmlDataSource ID="AdminXmlDataSource" runat="server" DataFile="~/Admin/xml/AdminNavTree.xml">
        </asp:XmlDataSource>
    </form>
</body>
</html>
