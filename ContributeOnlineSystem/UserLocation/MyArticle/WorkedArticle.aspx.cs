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

public partial class UserLocation_MyArticle_WorkedArticle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string searchMode = Request.QueryString["SearchMode"].ToString();
            GeneralUser user = (Session["UserInfo"] as GeneralUser);
            int userID = user.Id;

            string strCon = "";
            string strTab = "";

            DataTable tempDt;

            switch (searchMode)
            {
                case "Finish":   //已处理稿件

                    tempDt = ArticleManager.GetArticleByAessSendID(userID);  //显示本人评论过稿件
                    break;
                case "UnFinish":  //未处理稿件 
                    strTab = CreateTableCon(user.RoleInfo, userID);
                    strCon = CreateConditionStr(user.RoleInfo, userID);
                    tempDt = ArticleManager.GetArticleForUnfinsh(strTab, strCon);
                    break;
                default:
                    throw new Exception("不存在的稿件类型");
            }
            //绑定数据
            gvArticleList.DataSource = tempDt;
            gvArticleList.DataBind();
        }
    }

    /// <summary>
    /// 创建表条件
    /// </summary>
    /// <param name="role"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    private string CreateTableCon(Role role, int userId)
    {
        string result = "";
        switch (role.Id)
        {
            case 0://系统管理员
                result = "Error";
                break;
            case UserRoleConst.ChiefEditor: //主编
                result = "";
                break;
            case 2://副主编
                result = "";
                break;
            case 3://责任编辑
                result = ",ArticleColumn";
                break;
            case 4://排版编辑
                result = "";
                break;
            case 5://专家
                result = ",ArticleExpert";
                break;
            case 6://作者
                result = "Error";
                break;
            default:
                result = "Error";
                break;
        }
        if (result == "Error")
        {
            throw new Exception("用户信息不正确！（该用户不能使用本功能）");
        }

        return result;
    }

    /// <summary>
    /// 用户编号
    /// </summary>
    /// <param name="role">用户权限</param>
    /// <returns>条件字符串</returns>
    private string CreateConditionStr(Role role, int userId)
    {

        string result = "";
        switch (role.Id)
        {
            case 0://系统管理员
                result = "Error";
                break;
            case UserRoleConst.ChiefEditor: //主编
                result = "Article_State = 8";
                break;
            case 2://副主编
                result = "Article_State = 3";
                break;
            case 3://责任编辑
                result = @"(Article_State = 1 OR Article_State = 2 OR Article_State = 16) And 
                            ArticleColumn_ID = Article_ColumnID And ArticleColumn_ResponsibleEditorID =" + userId.ToString();
                break;
            case 4://排版编辑
                result = @"(Article_State = 9 OR Article_State = 11)";
                break;
            case 5://专家
                result = @"ArticleExpert_ArticleID = Article_ID And Article_State = 2 And  ArticleExpert_ExpertID = " + userId.ToString();
                break;
            case 6://作者
                result = "Error";
                break;
            default:
                result = "Error";
                break;
        }
        if (result == "Error")
        {
            throw new Exception("用户信息不正确！（该用户不能使用本功能）");
        }

        return result;
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

    protected void btnShowAssess(object sender, EventArgs e)
    {
        LinkButton lbtn = (sender as LinkButton);
        string url = "~/UserLocation/MyArticle/ShowAllAssess.aspx?ArticleID=" + lbtn.CommandArgument;
        Response.Redirect(url);

    }
}
