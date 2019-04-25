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
using ContributeOnlineSystem.Models.ConstPara;
using System.Collections.Generic;

public partial class UserLocation_MyArticle_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            int UserID = (Session["UserInfo"] as GeneralUser).Id;
            int UserRoleID = (Session["UserInfo"] as GeneralUser).RoleInfo.Id;
            int ArticleID = Convert.ToInt32(Request.QueryString["ArticleID"]);
            DataTable result = new DataTable();
            //获取所有评审信息
            if (UserRoleID == UserRoleConst.Expert)
            {
               result = AssessOpinionManager.GetAssessByArticleIDAndSendID(ArticleID, UserID);
            }
            else
            {
               result = AssessOpinionManager.GetAssessByArticleID(ArticleID);
            }
            this.GVAssess.DataSource = result;
            this.GVAssess.DataBind();

        }
      
    }

    /// <summary>
    /// 点击返回按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/UserLocation/mainCon.aspx");
    }
}
