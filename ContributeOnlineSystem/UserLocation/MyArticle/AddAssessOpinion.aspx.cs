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

public partial class UserLocation_MyArticle_AddAssessOpinion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            //获取用户信息
            GeneralUser user = (Session["UserInfo"] as GeneralUser);
            lblSend.Text = user.Name;

            this.ddlResult.SelectedValue = "0"; //默认为显示
 
            this.CblExpert.DataSource = UserManager.GetGeneralUserByRoleId(UserRoleConst.Expert);
            this.CblExpert.DataTextField = "RealName";
            this.CblExpert.DataValueField = "Id";
            this.CblExpert.DataBind();
            IsShowControl();  //是否显示控件
        }
    }

    /// <summary>
    /// 是否显示控件
    /// </summary>
    protected void IsShowControl()
    {
        if (ddlResult.SelectedValue == "0")
        {
                Article article = ArticleManager.GetArticleInfoById(Convert.ToInt32(Session["ArticleIDForAddAss"])); //获取文章
                GeneralUser user = (Session["UserInfo"] as GeneralUser); //获取用户
                if (user.RoleInfo.Id == UserRoleConst.ResponsibleEditor && article.ArticleStateInfo.Id == 1)
                {
                    this.PlExpert.Visible = true;
                }
                else
                {
                    this.PlExpert.Visible = false;
                }
        }
        else
        {
            this.PlExpert.Visible = false;
        }
       

        
    }


    /// <summary>
    /// 评审结果列表的自动相应函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlResult_SelectedIndexChanged(object sender, EventArgs e)
    {
        IsShowControl();
    }



    /// <summary>
    /// 用户点击提交评审信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        GeneralUser user = (Session["UserInfo"] as GeneralUser);    //获取用户信息
        Article article = ArticleManager.GetArticleInfoById(Convert.ToInt32(Session["ArticleIDForAddAss"])); //获取文章
           

        //////////////添加评审意见//////////////

        AssessOpinion newAssOp = new AssessOpinion();
        newAssOp.AssessStateInfo.ID = 0;  //已评审
        newAssOp.SendID = user.Id;     //评论者
        newAssOp.AssessResultInfo.ID = Convert.ToInt32(this.ddlResult.SelectedValue); //评审结果
        newAssOp.Article = article.Id; //文章编号
        newAssOp.Message = this.txtMessage.Text; //评语
        newAssOp.Remark = this.txtRemark.Text;   //备注
        newAssOp.ArticleStateID = article.ArticleStateInfo.Id; //评审批次

        AssessOpinionManager.InsertAssessOpinion(newAssOp); //添加


        ///////////是责编初审 指派专家//////////////

        if (ddlResult.SelectedValue == "0")   //如果通过
        {
            if (user.RoleInfo.Id == UserRoleConst.ResponsibleEditor && article.ArticleStateInfo.Id == 1) //责编初审
            {
                for (int i = 0; i < CblExpert.Items.Count; i++)
                {
                    if (CblExpert.Items[i].Selected)
                    {
                        ExpertArticle expertArt = new ExpertArticle();
                        expertArt.ArticleId = article.Id;
                        expertArt.ExpertId = Convert.ToInt32(CblExpert.Items[i].Value);

                        if (ExpertArticleManager.AddExpertArticle(expertArt) == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "", "alert('指派专家出错！')", true);
                            return;
                        }
                    }
                }
            }
            
        }
        



        /////////修改文章状态//////////////////

        if(user.RoleInfo.Id == UserRoleConst.Expert)  //专家修改稿件状态(专家过不过稿件都成为一个状态)
        {
            article.ArticleStateInfo.Id = 16; //改状态为专家已评审
            if (ArticleManager.UpdateArticleInfo(article) != 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('写入数据出错！')", true);
            }
            ClientScript.RegisterStartupScript(GetType(), "", "alert('评审完毕！')", true);
            //跳转

            Response.Redirect("~/success.aspx"); //成功
            return;
        }


        if (ddlResult.SelectedValue == "0")      //选择通过
        {
            if (article.ArticleStateInfo.Id == 1) article.ArticleStateInfo.Id = 2; //过初审
            else if (article.ArticleStateInfo.Id == 2 || article.ArticleStateInfo.Id == 16)article.ArticleStateInfo.Id = 3; //过二审
            else if (article.ArticleStateInfo.Id == 3) article.ArticleStateInfo.Id = 8; //过复审
            else if (article.ArticleStateInfo.Id == 8) article.ArticleStateInfo.Id = 9;//过终审
            else { ClientScript.RegisterStartupScript(GetType(), "", "alert('稿件状态出错！')", true); }

            //写入数据库
            if (ArticleManager.UpdateArticleInfo(article) != 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('写入数据出错！')", true);
            }
        }
        else
        {
            article.ArticleStateInfo.Id = 13; //不通过 稿件成为退回稿件
            //写入数据库
            if (ArticleManager.UpdateArticleInfo(article) != 1)
            {
                ClientScript.RegisterStartupScript(GetType(), "", "alert('写入数据出错！')", true);
            }
        }


        ClientScript.RegisterStartupScript(GetType(), "", "alert('评审完毕！')", true);
        Response.Redirect("~/success.aspx"); //成功

    }

}
