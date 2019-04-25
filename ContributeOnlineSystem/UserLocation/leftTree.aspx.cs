using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.Models.ConstPara;

public partial class leftTree : System.Web.UI.Page
{
    /// <summary>
    /// 加载导航目录树
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GeneralUser user = Session["UserInfo"] as GeneralUser;  //获取用户信息
            if (user.RoleInfo.Id == UserRoleConst.Author)
            {   //登录用户是作者
                this.trvNav.DataSource = this.AuthorXmlDataSource;
                this.DataBind();
            }
            else if (user.RoleInfo.Id == UserRoleConst.LayoutEditor) //排版编辑
            {
                this.trvNav.DataSource = this.LayoutXmlDataSource;
                this.DataBind();
            }
            else if (user.RoleInfo.Id == UserRoleConst.ResponsibleEditor) //责任编辑
            {
                this.trvNav.DataSource = this.ResponsibleXmlDataSource;
                this.DataBind();
            }
            else
            {
                this.trvNav.DataSource = this.UserWorkXmlDataSource;
                this.DataBind();
            }
        }
    }
}
