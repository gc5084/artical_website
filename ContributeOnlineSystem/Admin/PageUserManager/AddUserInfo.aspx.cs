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

using ContributeOnlineSystem.BLL;
using System.Collections.Generic;
using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.Models.ConstPara;

public partial class Admin_PageUserManager_AddUserInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            thisDataBind();
        }
    }

    private void thisDataBind()
    {
        List<GeneralUser> userList = UserManager.GetUserInfoList(); //获取用户信息
        gvUserList.DataSource = userList;

        gvUserList.DataBind();
    }
    /// <summary>
    /// 单击删除相应函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
         //int rowindex = ((GridViewRow) (((LinkButton)sender).NamingContainer) ).RowIndex; 
         //int UserID =  Convert.ToInt32(gvUserList.DataKeys[rowindex].Value);
         //this.Response.Write(UserID.ToString());
         //ClientScript.RegisterStartupScript(GetType(), "User Name or Password Error", "alert('不正确！')", true)

        LinkButton lbBtn = sender as LinkButton;
        int userID = Convert.ToInt32(lbBtn.CommandArgument);
        GeneralUser user = UserManager.GetGeneralUserInfoById(userID);

        if (user.RoleInfo.Id == UserRoleConst.Expert)
        {
            if (UserManager.DeleteUserExpert(userID) == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('删除专家出错！')", true);
            }
        }
        else
        {
            if (UserManager.DeleteUser(userID) == 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('删除用户出错！')", true);
            }
        }

        thisDataBind();
    }
}
