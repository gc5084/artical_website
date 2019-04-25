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

public partial class UserLocation_MyArticle_ArticleBack : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LbInfo.Text = "提示：请详细查看评审意见中明确表明的“退回修改”或“不予录取”,若为“退回修改”请及时进入‘修改稿件’条目。";
            int userID = (Session["UserInfo"] as GeneralUser).Id;
            DataTable tempDt;
            tempDt = ArticleManager.GetArticleInfoByUserIDAndArticleState(userID, 13);
            //绑定数据
            gvArticleList.DataSource = tempDt;
            gvArticleList.DataBind();
        }

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
    /// 修改稿件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnModify(object sender, EventArgs e)
    {
        LinkButton lbtn = (sender as LinkButton);
        string url = "~/UserLocation/MyArticle/ModifyArticle.aspx";
        Session["ArticleForModify"] = lbtn.CommandArgument;
        Response.Redirect(url);
    }


}
