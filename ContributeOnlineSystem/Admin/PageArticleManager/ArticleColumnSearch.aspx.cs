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
using System.Collections.Generic;

public partial class Admin_PageArticleManager_ArticleColumnSearch : System.Web.UI.Page
{
    /// <summary>
    /// 加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataBing_();
        }
    }

    /// <summary>
    /// 数据绑定
    /// </summary>
    private void DataBing_()
    {
        RepArticlec.DataSource = ArticleColumnManager.GetArticleColumnAll();
        RepArticlec.DataBind();

        DropName.DataSource = UserManager.GetGeneralUserByRoleId(3);
        DropName.DataTextField = "RealName";
        DropName.DataValueField = "Id";
        DropName.SelectedIndex = 0;
        DropName.DataBind();
    }

    /// <summary>
    /// 添加、修改稿件栏目
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        ArticleColumn articleColumn = new ArticleColumn();

        articleColumn.Name = txtName.Text;
        articleColumn.Description = txtDepict.Text;
        articleColumn.ResponsibelUserId = int.Parse(DropName.SelectedValue);
        //添加新栏目
        if (lblColumn.Text == "添加新栏目")
        {
            ArticleColumnManager.InsertArticleColumn(articleColumn);
        }
        //修改栏目信息
        else if (lblColumn.Text == "修改栏目信息")
        {
            articleColumn.Id = int.Parse(lblId.Text);
            ArticleColumnManager.UpdateArticleColumn(articleColumn);
            lblColumn.Text = "添加新栏目";
        }
        //清空填写的信息
        txtName.Text = "";
        txtDepict.Text = "";
        DropName.SelectedIndex = 0;
        DataBing_();
    }

    /// <summary>
    /// 保存删除或修改栏目的信息
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void RepArticlec_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        //删除操作
        if (e.CommandName == "Delete")
        {
            int id = int.Parse((e.Item.FindControl("btnDel") as LinkButton).CommandArgument.ToString());
            ArticleColumnManager.DeleteArticleColumn(id);
            DataBing_();
        }
        //修改栏目信息
        else if (e.CommandName == "Update")
        {
            lblColumn.Text = "修改栏目信息";
            int id = int.Parse(((e.Item.FindControl("btnUpdate")) as LinkButton).CommandArgument.ToString());
            ArticleColumn ac = ArticleColumnManager.GetArticleColumnById(id);
            if (ac == null)
            {
                return;
            }
            txtName.Text = ac.Name;
            txtDepict.Text = ac.Description;
            DropName.Text = ac.ResponsibelUserId.ToString();
            lblId.Text = ac.Id.ToString();
        }
        //删除所选项栏目信息
        else if (e.CommandName == "DeleteAll")
        {
            for (int i = 0; i < RepArticlec.Items.Count; i++)
            {
                int id;
                if ((RepArticlec.Items[i].FindControl("chb") as CheckBox).Checked)
                {
                    id = int.Parse((RepArticlec.Items[i].FindControl("ArticleColumn_ID") as Label).Text);
                    ArticleColumnManager.DeleteArticleColumn(id);
                }
            }
            DataBing_();
        }
    }

}
