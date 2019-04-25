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

public partial class UserLocation_MyArticle_ArticleSearch : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string searchMode = Request.QueryString["SearchMode"].ToString();
            int userID = (Session["UserInfo"] as GeneralUser).Id;
            DataTable tempDt;
            switch (searchMode)
            {
                case "UnSend":      //草稿箱
                    tempDt = ArticleManager.GetArticleInfoByUserIDAndArticleState(userID, 15);
                    //this.lblTitle.Text = "草稿箱";
                    break;
                case "Work":        //审理中的稿件
                    tempDt = ArticleManager.GetWorkArticleInfoByUserID(userID);
                    //this.lblTitle.Text = "审理中的稿件";
                    break;
                
                case "Publish":     //发布的稿件
                    tempDt = ArticleManager.GetArticleInfoByUserIDAndArticleState(userID, 14);
                    //this.lblTitle.Text = "发布的稿件";
                    break;
                default:
                    throw new Exception("Rosy：不存在的稿件类型");
            }
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
}
