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
using ContributeOnlineSystem.Models;

public partial class UserLocation_UserSettings_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 点击修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtNewPwd.Text != txtNewPwdAgain.Text)
        { //密码不一致
            ClientScript.RegisterStartupScript(GetType(), "Password is different!", "alert('密码不一致！')", true); 
            return;
        }
        GeneralUser user = Session["UserInfo"] as GeneralUser;  //获取用户信息
        if (user.Pwd != txtOldPwd.Text)
        {//校验用户旧密码是否正确
            ClientScript.RegisterStartupScript(GetType(), "Password is different!", "alert('旧密码不正确！')", true);
            return;
        }
        user.Pwd = txtNewPwd.Text;
        if (UserManager.UpdateUserPassword(user) != -1)
        {
            ClientScript.RegisterStartupScript(GetType(), "Password is different!", "alert('密码修改成功！')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Password is different!", "alert('密码修改失败！')", true);
        }
    }
}
