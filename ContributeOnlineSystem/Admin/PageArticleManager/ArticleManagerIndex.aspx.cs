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
using System.Collections.Generic;
using ContributeOnlineSystem.Models;

public partial class Admin_PageArticleManager_ArticleManagerIndex : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.LBCurrntNum.Text = "1";
            PageDataBind();
            
        }
    }

    /// <summary>
    /// 绑定数据函数
    /// </summary>
    protected void PageDataBind()
    {
        //分页
        int CurrentPage = Convert.ToInt32(LBCurrntNum.Text) - 1;
        DataTable DTlist = ArticleManager.GetAllArticleInfo();
        PagedDataSource psData = new PagedDataSource(); //创建分页数据源
        psData.DataSource =  DTlist.DefaultView;
        psData.AllowPaging = true;
        psData.PageSize = 30;
        psData.CurrentPageIndex = CurrentPage;

        this.LBSumNum.Text = psData.PageCount.ToString();

        this.GVArtlicle.DataSource = psData;

        this.BTPre.Enabled = true;
        this.BTNext.Enabled = true;
        if (CurrentPage == 0)
            this.BTPre.Enabled = false;
        if (CurrentPage+1 == psData.PageCount)
            this.BTNext.Enabled = false;

        this.GVArtlicle.DataBind();
    }

    /// <summary>
    /// 单击上一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTPre_Click(object sender, EventArgs e)
    {
        int Page = Convert.ToInt32(this.LBCurrntNum.Text) - 1;
        this.LBCurrntNum.Text = Page.ToString();

        PageDataBind();
    }

    /// <summary>
    /// 单击下一页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BTNext_Click(object sender, EventArgs e)
    {
        int Page = Convert.ToInt32(this.LBCurrntNum.Text) + 1;
        this.LBCurrntNum.Text = Page.ToString();

        PageDataBind();
    }


    /// <summary>
    /// 删除相应函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnDelArticle(object sender, EventArgs e)
    {
        LinkButton lbBtn = sender as LinkButton;
        int ArticleID = Convert.ToInt32(lbBtn.CommandArgument);

        if (ArticleManager.DeleteArticleByID(ArticleID) == 0)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alert('删除过程出错！')", true);
        }
        PageDataBind();

    }
}
