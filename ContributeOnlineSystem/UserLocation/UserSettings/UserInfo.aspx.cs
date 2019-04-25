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

public partial class UserLocation_UserSettings_UserInfo : System.Web.UI.Page
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
            GeneralUser user = Session["UserInfo"] as GeneralUser;  //获取用户信息
            this.txtID.Value = user.Id.ToString();
            this.txtLoginName.Value = user.Name;
            this.txtRole.Value = user.RoleInfo.Name;
            this.txtSex.Value = user.Sex ? "男" : "女";
            this.txtTel.Value = user.Tel;
            this.txtRealName.Value = user.RealName;
            this.txtCreateTime.Value = user.CreateTime.Year.ToString() + '/' + user.CreateTime.Month.ToString() + '/' + user.CreateTime.Day.ToString();
            this.txtBirthday.Value = user.Birthday.Year.ToString() + '/' + user.Birthday.Month.ToString() + '/' + user.Birthday.Day.ToString();
            this.txtEMail.Value = user.Email;
        }
    }
}
