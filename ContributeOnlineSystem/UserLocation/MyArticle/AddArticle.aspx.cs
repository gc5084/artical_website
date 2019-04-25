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

public partial class UserLocation_MyArticle_AddArticle : System.Web.UI.Page
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
            //绑定稿件栏目
            ddlColumn.DataSource = ArticleManager.GetArticleColumnList();
            ddlColumn.DataTextField = "ArticleColumn_Name";
            ddlColumn.DataValueField = "ArticleColumn_ID";
            ddlColumn.DataBind();
            //绑定稿件类型
            ddlType.DataSource = ArticleManager.GetArticleTypeList();
            ddlType.DataTextField = "ArticleType_Name";
            ddlType.DataValueField = "ArticleType_ID";
            ddlType.DataBind();
            //设置署名作者
            this.txtAuthorName.Value = (Session["UserInfo"] as GeneralUser).RealName;
        }
    }
    /// <summary>
    /// 点击投稿
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            //获取稿件信息
            string chineseTitle = txtChineseTitle.Value;    //标题信息
            string englishTitle = txtEnglishTitle.Value;
            string chineseResume = txtChineseResume.Value;  //摘要信息
            string englishResume = txtEnglishResume.Value;
            string chineseKey = txtChineseKey.Value;        //关键字信息
            string englishKey = txtEnglishKey.Value;
            int columnID = Convert.ToInt32(ddlColumn.SelectedValue);         //栏目编号
            int typeID = Convert.ToInt32(ddlType.SelectedValue);             //类型编号


            int count = Convert.ToInt32(txtCount.Value);        //字数
            string authorResume = txtAuthorResume.Text;         //作者简介
            string eMail = txtEMail.Value;                      //邮箱
            string authorName = txtAuthorName.Value;            //署名作者


            //检查附件，并保存
            if (fulAccessories.HasFile == false)
            {
                ClientScript.RegisterStartupScript(GetType(), "DocumentError", "alert('需上传附件！')", true);
                return;
            }
            if (fulAccessories.PostedFile.ContentLength > 10 * 1024 * 1024)
            {
                ClientScript.RegisterStartupScript(GetType(), "DocumentConutError", "alert('上传文件类型大小不能超过10MB！')", true);
                return;
            }

            long tick = DateTime.Now.Ticks;
            string file = fulAccessories.FileName;
            string subfilename = file.Substring(file.LastIndexOf('.'));

            //保存稿件信息（向数据库中添加信息）
            Article newArticle = new Article();
            newArticle.ChineseTitle = chineseTitle;
            newArticle.EnglishTitle = englishTitle;
            newArticle.ChineseResume = chineseResume;
            newArticle.EnglishResume = englishResume;
            newArticle.ChineseKey = chineseKey;                 //关键字信息
            newArticle.EnglishKey = englishKey;
            newArticle.ArticleColumnId = columnID;              //栏目编号
            newArticle.ArticleTypeInfo.Id = typeID;             //类型编号
            newArticle.ArticleTypeInfo.Name = ddlType.SelectedItem.Text;

            newArticle.Expert = "";                         //推荐专家
            newArticle.WordCount = count;                       //字数
            newArticle.AuthorIntro = authorResume;              //作者简介
            newArticle.Email = eMail;                          //邮箱
            newArticle.AuthorName = (Session["UserInfo"] as GeneralUser).Id;  //署名作者

            newArticle.AttachmentName = file;                           //附件名称
            newArticle.AttachmentFileName = tick.ToString() + subfilename;   //附件物理名称
            newArticle.ArticleStateInfo.Id = 1;

            //数据库操作
            int artID = ArticleManager.InsertNewArticle(newArticle);
            if (artID > 0)
            {
                fulAccessories.SaveAs(Server.MapPath("~/DocumentFile/" + tick.ToString() + subfilename));//保存文件
                Response.Redirect("~/success.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(GetType(), "AddError", "alert('投稿失败！')", true);
            }

        }
        catch (Exception error)
        {
            string strReason =  error.Message;
            ClientScript.RegisterStartupScript(GetType(), "", "alert('" + strReason + "')", true);
        }
       

    }

}
