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
using ContributeOnlineSystem.Models.ConstPara;
using System.Collections.Generic;

public partial class AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 用户点击登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string name = txtName.Value.ToString().Trim();  //获取用户名称

        string pwd = txtPwd.Value.ToString().Trim();    //获取用户密码
        //验证用户身份
        if (UserManager.AdminLogin(name, pwd))
        {
            //用户合法
            FormsAuthentication.SetAuthCookie("Admin", false);     //为用户建立票据
            Response.Redirect("~/Admin/index.aspx");
        }
        else 
        {
            ClientScript.RegisterStartupScript(GetType(), "User Name or Password Error", "alert('用户名或密码不正确！')", true);
        }
    }
    /// <summary>
    /// 用户点击取消0
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
