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
using System.Web.Services.Description;
using ContributeOnlineSystem.BLL;
using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.Models.ConstPara;

public partial class UserLocation_MyArticle_ArticleDetail : System.Web.UI.Page
{
    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int articleID = Convert.ToInt32(Request.QueryString["ArticleID"]); //获取消息编号
            Article article = ArticleManager.GetArticleInfoById(articleID);
            hfdArticleID.Value = articleID.ToString();
            lblChineseTitle.Text = article.ChineseTitle;
            lblEnglishTitle.Text = article.EnglishTitle; 
            lblChineseResume.Text = article.ChineseResume;
            lblEnglishResume.Text = article.EnglishResume;
            lblChineseKey.Text = article.ChineseKey;
            lblEnglishKey.Text = article.EnglishKey;
            lblColumn.Text = article.ArticleColumnId.ToString();//??
            lblType.Text = article.ArticleTypeInfo.Name;
            lblCount.Text = article.WordCount.ToString() + "字";
            lblAuthorResume.Text = article.AuthorIntro;
            lblEMail.Text = article.Email;
            lblAuthorName.Text = article.AuthorName.ToString();//??
            lblLinkName.Text = article.AttachmentName;
            aUpdown.HRef = "../../DocumentFile/" + article.AttachmentFileName;

            this.IsShowBtn(article);  //是否显示按钮
        }
    }

    /// <summary>
    /// 是否显示评审按钮
    /// </summary>
    protected void IsShowBtn(Article article)
    {
        this.PlSubmit.Visible = false;

        GeneralUser user = Session["UserInfo"] as GeneralUser;
        int UserRole = user.RoleInfo.Id; //获取用户角色

        int ArtState = article.ArticleStateInfo.Id; //获取文章状态

        switch (UserRole)
        {
            case UserRoleConst.ChiefEditor: //主编
                if (ArtState == 8) //复审通过，等待终审 时 可见
                    this.PlSubmit.Visible = true;
                break;
            case UserRoleConst.SubEditor: //副主编
                if (ArtState == 3) //二审通过，等待复审 时可见
                    this.PlSubmit.Visible = true;
                break;
            case UserRoleConst.ResponsibleEditor: //责任编辑
                if (ArtState == 1 || ArtState == 2 || ArtState == 16) //一，二审.专家已审时可见
                    this.PlSubmit.Visible = true;
                break;
            case UserRoleConst.Expert: //专家
                if (ArtState == 2) //一审通过时可见
                    this.PlSubmit.Visible = true;
                break;
            default:
                break;
        }


    }
    /// <summary>
    /// 用户点击添加评审意见
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Session["ArticleIDForAddAss"] = Request.QueryString["ArticleID"];
        Response.Redirect("~/UserLocation/MyArticle/AddAssessOpinion.aspx");

    }
}
