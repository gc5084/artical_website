<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="css/publicCss.css" rel="stylesheet" type="text/css" />

    <script language="javascript" type="text/javascript" src="js/select.js"></script>
    <script language="javascript" type="text/javascript" src="../js/My97DatePicker/WdatePicker.js"></script>
    <script language="javascript" type="text/javascript" src="../js/Blue.js"></script>
    <script language="javascript" type="text/javascript" src="js/AddUser.js"></script>
    
    <script type="text/javascript">
    <!--
    var displayBar=true;
    function switchBar(obj){
	    if (displayBar)
	    {
		    this.parent.frame.cols="0,*";
		    displayBar=false;
		    obj.title="窗口折叠";
		    document.getElementById("hiddenIco").src="images/tool-02.gif";
	    }
	    else{
		    this.parent.frame.cols="15%,*";
		    displayBar=true;
		    obj.title="展开窗口";
		    document.getElementById("hiddenIco").src="images/tool-01.gif";
	    }
    }
    //-->
    </script>

</head>
<body>
       <form method="post" action="" runat="server">
        <div id="main">
            <div id="topMenu">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <img id="hiddenIco" src="images/tool-01.gif" align="top" onclick="switchBar(this)"
                                title="展开当前页面" style="cursor: pointer;" />
                            展开当前页面</td>
                        <td>
                            
                        </td>
                    </tr>
                </table>
            </div>
           
                
                
         <div id="form">      
                    <fieldset>
                        <legend>
                            <img src="images/sousuo.gif" align="top" />
                            添加新用户</legend>
                            
                        
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        
                        <!--基础信息Panel-->
                        <asp:Panel ID="PanelGeneral"  runat="server" >
                            <tr >
                                <td >
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                    
                                <span style="color:Red">*</span>  用户名称：</td>
                                <td>
                                <asp:TextBox ID="TBUserName" class="textStyle" style="width: 23%;" runat="server"></asp:TextBox>
                                &nbsp;&nbsp;
                                <asp:CustomValidator ID="CustomV_Name" runat="server"  OnServerValidate="OnCheckName" ControlToValidate="TBUserName" ValidateEmptyText="true"></asp:CustomValidator>
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="right">
                                 <span style="color:Red">*</span>    用户密码：</td>
                                <td>
                                <asp:TextBox ID="TBUserPWD" class="textStyle" style="width: 23%;" TextMode="Password" runat="server"></asp:TextBox>
                                <asp:Label ID="LBPWD" style="color:Red"  runat="server" Text=""></asp:Label>
                                
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                 <span style="color:Red">*</span>    密码确认：</td>
                                <td>
                                <asp:TextBox ID="TBrePWD" class="textStyle" style="width: 23%;" TextMode="Password" runat="server"></asp:TextBox>
                                    <asp:CustomValidator ID="CustomV_PWD" runat="server"  OnServerValidate="OnCheckPWD" ControlToValidate="TBrePWD" ValidateEmptyText="true"></asp:CustomValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                <span style="color:Red">*</span>     真实姓名：</td>
                                <td>
                                <asp:TextBox ID="TBtrueName" class="textStyle" style="width: 23%;"  runat="server"></asp:TextBox>
                                </td>
                            </tr>
                                         
                            <tr>
                                <td align="right">
                                    性别：</td>
                                <td>
                                    
                                    <asp:RadioButtonList ID="RBsex"  RepeatColumns= "2" runat="server">
                                    <asp:ListItem Value="0" Text="男" Selected="True"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="女"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                 <span style="color:Red">*</span>   生日：</td>
                                <td>
                                
                                <asp:TextBox ID="TBBirthday" class="textStyle" style="width: 23%;"  runat="server" onfocus="new WdatePicker({dateFmt:'yyyy/MM/dd',skin:'whyGreen'});"></asp:TextBox>&nbsp;
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必填字段" ControlToValidate="TBBirthday"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                   联系电话：</td>
                                <td>
                                <asp:TextBox ID="TBTel" class="textStyle" style="width: 23%;"  runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right">
                                   电子邮件：</td>
                                <td>
                                <asp:TextBox ID="TBEmail" class="textStyle" style="width: 23%;"  runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            
                            <tr>
                                <td align="right">
                                 <span style="color:Red">*</span>    用户类型：</td>
                                <td>
                                <div class = "selectStyle">
                                    <asp:DropDownList ID="DDLrole"   runat="server">
                                    <asp:ListItem Value="5">专家</asp:ListItem>
                                    <asp:ListItem Value="3">责任编辑</asp:ListItem>
                                    <asp:ListItem Value="4">排版编辑</asp:ListItem>
                                    <asp:ListItem Value="1">主编</asp:ListItem>
                                    <asp:ListItem Value="2">副主编</asp:ListItem>
                                    
                                    </asp:DropDownList>
                                 </div>
                                    
                                </td>
                                
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <label>
                                    <span style=" width:100px;">
                                        <span  class="btnStyle">
                                            <asp:Button ID="BTNext" runat="server"  Text="下一步" class="btn" Width="70px"  OnClick="OnBTNextClick"/>
                                            </span></span>
                                    </label>
                                    
                                    <label>
                                        <span class="btnStyle">
                                            
                                            <input type="reset" name="button" id="reset1" value="重  置"  class="btn" style="width:70px" /></span>
                                    </label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
   
                    </asp:Panel>
                    
                    
                    <!--专家Panel-->
                     <asp:Panel ID="PanelExpert"   runat="server">
                        
                      
                            
                               <tr>
                                    <td align="right">
                                        工作单位：</td>
                                    <td>
                                    <asp:TextBox ID="TBWorkSpace" class="textStyle" style="width: 23%;"  runat="server"></asp:TextBox>
                                    </td> 
                                </tr>
                                
                                <tr>
                                    <td align="right">
                                        专家简介：</td>
                                    <td>
                                    <asp:TextBox ID="TBintro" class="textStyle"  TextMode="MultiLine" style="width: 23%; height:150px;"  runat="server"></asp:TextBox>
                                    </td> 
                                </tr>

                                
                                <tr>
                                    <td align="right">专家所属领域：</td>
                                    <td>
                                        <asp:Label ID="LBfield" runat="server" Text=""></asp:Label>
                                        <asp:CheckBoxList ID="CBLfield" RepeatColumns="3" runat="server">
                                        
                                        
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                                
                                 <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    <label>
                                        <span class="btnStyle">
                                            <asp:Button ID="BTfinish1" runat="server"  Text="完成" class="btn" Width="70px" OnClick="OnFinishExpert"/>
                                            </span>
                                    </label>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <label>
                                        <span class="btnStyle">
                                            
                                            <asp:Button ID="BTback" runat="server"  Text="上一步" class="btn" Width="70px" OnClick="OnForword"/></span>
                                    </label>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                                
                               
                            
                         </asp:Panel>
                         
                         
                         
                         <!--责任编辑Panel-->
                         <asp:Panel ID="PanelResponsible" runat="server"  >
                            
                                <tr>
                                    <td align="right">责任编辑负责栏目：</td>
                                    
                                    <td>
                                        <asp:Label ID="LBartCol" runat="server" Text=""></asp:Label>
                                    <asp:CheckBoxList ID="CBLArticleColumn"  RepeatColumns="3" runat="server">
                                    
                                    </asp:CheckBoxList>
                                    </td>
                                </tr>
                                
                                
                                <tr>
                                    <td>
                                       请确认完成;</td>
                                    <td>
                                        <label>
                                            <span class="btnStyle">
                                                <asp:Button ID="BTfinish2" runat="server"  Text="完成" class="btn" Width="70px" OnClick="OnFinishResponsible"/>
                                                </span>
                                        </label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label>
                                            <span class="btnStyle">
                                                
                                                <asp:Button ID="BTback2" runat="server"  Text="上一步" class="btn" Width="70px" OnClick="OnForword"/></span>
                                        </label>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </asp:Panel>
                    
                           <!--主/副编Panel-->
                            <asp:Panel ID="Panelchief" runat="server" >
                                <tr>
                                    <td align="right">
                                        请确认完成:&nbsp;</td>
                                    <td>
                                        <label>
                                            <span class="btnStyle">
                                                <asp:Button ID="BTfinish3" runat="server"  Text="完成" class="btn" Width="70px" OnClick="OnFinishChife"/>
                                                </span>
                                        </label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <label>
                                            <span class="btnStyle">
                                                
                                                <asp:Button ID="BTback3" runat="server"  Text="上一步" class="btn" Width="70px" OnClick="OnForword"/></span>
                                        </label>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                             
                            </asp:Panel>
                            
                            <asp:Panel ID="PanelSuccess" runat="server" >
                                    <tr>
                                        <td align="left">
                                            点击继续按钮添加下一个用户：
                                         </td>
                                         <td>
                                             <span class="btnStyle"><asp:Button ID="BTcontinue" runat="server" Text="继续" class="btn" OnClick="OnContinue" /></span>
                                         </td>
                                    </tr>
                            </asp:Panel>
                            
                           
                        </table>
                  

            
                       
                    </fieldset>
                    </div>
                    </div>
 
                </form>
               
                <!--表单结束--> 
             <div>    

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="search_result">
                <tr>
                    <td style="padding-left: 10px;">
                        <img src="images/result.gif" align="top" />
                        下栏1</td>
                </tr>
            </table>

            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="page">
                <tr>
                    <td align="right">
                        下栏2</td>
                </tr>
            </table>
        </div>
    
    
   
</body>
</html>
