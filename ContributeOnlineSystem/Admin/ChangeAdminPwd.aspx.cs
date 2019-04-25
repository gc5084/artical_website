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

public partial class Admin_ChangeAdminPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 用户点击提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (UserManager.UpdateAdminPassword(txtOldPwd.Text, txtNewPwd.Text))
        {//修改密码成功
            ClientScript.RegisterStartupScript(GetType(), "key", "alert('修改密码成功！')", true);
        }
        else 
        {
            ClientScript.RegisterStartupScript(GetType(), "key", "alert('修改密码失败！')", true);
        }
    }
}
