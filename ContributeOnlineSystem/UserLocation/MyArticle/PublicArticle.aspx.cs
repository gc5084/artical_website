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

public partial class UserLocation_MyArticle_PublicArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userRoleID = (Session["UserInfo"] as GeneralUser).RoleInfo.Id;
            if (userRoleID != UserRoleConst.ResponsibleEditor)
            {
                ClientScript.RegisterStartupScript(GetType(), "URL", "window.open('../../ReLogin.aspx','_top')", true);
            }
            localDataBind();
        }

    }


    protected void localDataBind()
    {
        DataTable tempDt;
        tempDt = ArticleManager.GetArticleInfoByArticleState(10);
        //绑定数据
        gvArticleList.DataSource = tempDt;
        gvArticleList.DataBind();
    }


    /// <summary>
    /// 用户点击详细信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCheck_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (sender as LinkButton);
        string url = "~/UserLocation/MyArticle/ArticleDetail.aspx?ArticleID=" + lbtn.CommandArgument;
        Response.Redirect(url);
    }


    /// <summary>
    /// 查看评审
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnShowAssess(object sender, EventArgs e)
    {
        LinkButton lbtn = (sender as LinkButton);
        string url = "~/UserLocation/MyArticle/ShowAllAssess.aspx?ArticleID=" + lbtn.CommandArgument;
        Response.Redirect(url);
    }

    /// <summary>
    /// 改状态为出版
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPublic(object sender, EventArgs e)
    {
        LinkButton lbtn = (sender as LinkButton);
        int articleID = Convert.ToInt32(lbtn.CommandArgument);
        Article Marticle = ArticleManager.GetArticleInfoById(articleID);
        Marticle.ArticleStateInfo.Id = 14;
        if (ArticleManager.UpdateArticleInfo(Marticle) == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alter('更新出错')", true);
        }
        localDataBind();

    }
}