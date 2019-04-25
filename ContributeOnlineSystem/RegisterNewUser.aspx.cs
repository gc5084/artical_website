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
using ContributeOnlineSystem.BLL;

public partial class RegisterNewUser : System.Web.UI.Page
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
        //设置用户信息
        UserAuthor user = new UserAuthor();
        user.Id = -1;
        user.Name = txtUserName.Text;           //用户名称
        user.Pwd = txtPassword.Text;            //密码
        user.RealName = txtRealName.Text;       //真实姓名
        user.RoleInfo.Id = 6;                   //权限（作者）
        //用户性别
        if (ddlSex.SelectedValue == "1")
        {
            user.Sex = true;
        }
        else
        {
            user.Sex = false;
        }
        if (txtBirthday.Text == "")
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alert('生日必填')", true);
            return;
        }

        user.CreateTime = DateTime.Now;         //创建时间
        user.Birthday = Convert.ToDateTime(txtBirthday.Text);//生日
        user.Email = txtEMail.Text;             //邮箱
        user.Tel = txtTel.Text;                 //联系电话
        user.TypeName = "一般作者";             //作者类别

        
        if (UserManager.IsUserExist(user.Name))
        {
            ClientScript.RegisterStartupScript(GetType(), "UserIsExist", "alert('用户名已存在！')", true);
            return;
        }

        if (UserManager.AddNewAuthor(user) == 1)
        { //添加成功
            ClientScript.RegisterStartupScript(GetType(), "UserIsExist", "alert('注册成功！');location.href='UserLogin.aspx'", true);
        }
        else 
        {//添加失败
            ClientScript.RegisterStartupScript(GetType(), "UserIsExist", "alert('注册失败！')", true);
        }
    }
}
