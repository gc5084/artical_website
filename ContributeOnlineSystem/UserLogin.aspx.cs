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

public partial class UserLogin : System.Web.UI.Page
{
    /// <summary>
    /// 加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlUserType.DataSource = UserManager.GetRoleAllExceptAdmin();   //设置数据源
            ddlUserType.DataTextField = "Role_Name";
            ddlUserType.DataValueField = "Role_ID";
            ddlUserType.DataBind();
            ddlUserType.SelectedValue = "6";
        }
    }
    /// <summary>
    /// 点击登录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //获取用户信息
        string name = txtName.Value;
        string pwd = txtPwd.Value;
        int type = Convert.ToInt32(ddlUserType.SelectedItem.Value);
        //校验用户信息
        GeneralUser user = UserManager.UserLogin(name, pwd, type);
        //保存用户信息到Session
        if (user != null)
        {   //用户登录成功
            Session["UserInfo"] = user;
            //建立票据
            FormsAuthentication.SetAuthCookie("user", false);
            //跳转页面
            //Response.Redirect("~/UserLocation/index.aspx");
            ClientScript.RegisterStartupScript(GetType(), "URL", "window.open('UserLocation/index.aspx','_top')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "UserLogionError", "alert('登录信息错误！')", true);
        }
    }
    /// <summary>
    /// 点击取消
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}
