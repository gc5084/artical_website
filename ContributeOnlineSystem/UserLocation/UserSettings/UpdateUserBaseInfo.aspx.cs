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

public partial class UserLocation_UserSettings_UpdateUserBaseInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //填充用户信息
            GeneralUser user = Session["UserInfo"] as GeneralUser;  //获取用户信息
            this.lblID.Text = user.Id.ToString();
            this.lblLoginName.Text = user.Name;
            this.lblRole.Text = user.RoleInfo.Name;
            this.txtTel.Value = user.Tel;
            this.txtRealName.Value = user.RealName;
            this.lblCreateTime.Text = user.CreateTime.Year.ToString() + '/' + user.CreateTime.Month.ToString() + '/' + user.CreateTime.Day.ToString();
            this.txtBirthday.Value = user.Birthday.Year.ToString() + '/' + user.Birthday.Month.ToString() + '/' + user.Birthday.Day.ToString();
            this.txtEMail.Value = user.Email;

            if (user.Sex)
            {
                ddlSex.SelectedValue = "1";
            }
            else
            {
                ddlSex.SelectedValue = "0";
            }
        }
    }
    /// <summary>
    /// 提交修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        GeneralUser user = Session["UserInfo"] as GeneralUser;  //获取用户基本信息

        user.Tel = this.txtTel.Value;
        user.RealName = this.txtRealName.Value;
        user.Birthday = Convert.ToDateTime(this.txtBirthday.Value);
        user.Email = this.txtEMail.Value;
        if (ddlSex.SelectedValue == "1")
        {
            user.Sex = true;
        }
        else
        {
            user.Sex = false;
        }

        if (UserManager.UpdateGeneralUserInfo(user) > 0)
        { //更新成功
            ClientScript.RegisterStartupScript(GetType(), "Update Success", "alert('更新成功！')", true);
        }
        else
        {
            ClientScript.RegisterStartupScript(GetType(), "Update Success", "alert('更新失败！')", true);
        }
    }
}
