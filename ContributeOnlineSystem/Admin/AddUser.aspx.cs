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

public partial class AddUser : System.Web.UI.Page
{
    public const int ExpertID = 5;
    public const int Responsible = 3;
    public const int Chife = 1;
    public const int SubChife = 2;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (this.IsPostBack == false)
        {
            this.HideAllPanel();
            this.PanelGeneral.Visible = true;
            this.BindDataCBLfield();
            this.BindDataCBLal();

        }

    }

    #region 功能函数


    /// <summary>
    /// 获取基本用户信息
    /// </summary>
    /// <param name="user"></param>
    protected void GetGeneralInfo(GeneralUser user)
    {
        user.Name = this.TBUserName.Text;
        user.Pwd = Session["PassWord"].ToString();
        user.RealName = this.TBtrueName.Text;

        if (this.RBsex.SelectedValue == "0")
            user.Sex = false;
        else
            user.Sex = true;

        user.Birthday = Convert.ToDateTime(this.TBBirthday.Text);
        user.Tel = this.TBTel.Text;
        user.Email = this.TBEmail.Text;
        user.RoleInfo.Id = int.Parse(this.DDLrole.SelectedValue);

        user.CreateTime = DateTime.Now;
    }

    /// <summary>
    /// 隐藏所有panel
    /// </summary>
    protected void HideAllPanel()
    {
        this.PanelGeneral.Visible = false;
        this.PanelExpert.Visible = false;
        this.PanelResponsible.Visible = false;
        this.Panelchief.Visible = false;
        this.PanelSuccess.Visible = false;
    }

    /// <summary>
    /// 绑定领域字段
    /// </summary>
    protected void BindDataCBLfield()
    {
        DataTable DTfield = ExpertFieldManager.GetFieldAll();
        if (DTfield.Rows.Count == 0)
        {
            this.LBfield.Text = "没有可显示的领域信息";
        }

        this.CBLfield.DataSource = DTfield;
        this.CBLfield.DataTextField = "Field_Name";
        this.CBLfield.DataValueField = "Field_ID";
        this.CBLfield.DataBind();
    }

    /// <summary>
    /// 绑定栏目字段
    /// </summary>
    protected void BindDataCBLal()
    {
        DataTable DTArtCol = ArticleColumnManager.GetArticleColumnAll();
      
        if (DTArtCol.Rows.Count == 0)
        {
            this.LBartCol.Text = "没有可显示的栏目信息";
        }
        this.CBLArticleColumn.DataSource = DTArtCol;
        this.CBLArticleColumn.DataTextField = "ArticleColumn_Name";
        this.CBLArticleColumn.DataValueField = "ArticleColumn_ID";
        this.CBLArticleColumn.DataBind();
    }

    #endregion 


    #region 相应按钮函数

    /// <summary>
    /// 下一步按钮相应函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnBTNextClick(object sender, EventArgs e)
    {
        if (!Page.IsValid) return; //如果验证有误就不显示下一页
        this.HideAllPanel();
        if (this.DDLrole.SelectedValue == ExpertID.ToString())  //显示专家页面
        {
            this.PanelExpert.Visible = true;
        }
        else if (this.DDLrole.SelectedValue == Responsible.ToString())  //显示责编页面
        {
            this.PanelResponsible.Visible = true;
        }
        else //显示主副编页面
        {
            this.Panelchief.Visible = true;
        }
        Session["PassWord"] = this.TBUserPWD.Text; 
    }

    /// <summary>
    /// 点击上一步按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnForword(object sender, EventArgs e)
    {
        this.HideAllPanel();

        this.PanelGeneral.Visible = true;
    }



    /// <summary>
    /// 专家完成按钮响应
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnFinishExpert(object sender, EventArgs e)
    {
        //获取基础信息
        UserExpert userExpert = new UserExpert();
        this.GetGeneralInfo(userExpert);

        //获取专家特殊信息
        userExpert.WorkPlace = this.TBWorkSpace.Text;
        userExpert.Intro = this.TBintro.Text;
        userExpert.Remark = "";
        //添加专家
        if (ExpertFieldManager.InsertUserExpert(userExpert) != 1)
        {
            ClientScript.RegisterStartupScript(GetType(), "", "alert('添加专家失败！')", true);
            return;
        }


        //添加专家领域
        for (int i = 0; i < this.CBLfield.Items.Count; i++)
        {
            if (this.CBLfield.Items[i].Selected)
            {
                Field field = new Field();
                field.Id = Convert.ToInt32(this.CBLfield.Items[i].Value);

                ExpertFieldManager.AddFieldExpert(field, userExpert);
               
            }
        }

        //显示成功页面
        this.HideAllPanel();
        this.PanelSuccess.Visible = true;

    }

    /// <summary>
    /// 响应责编完成按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnFinishResponsible(object sender, EventArgs e)
    {
        //获取基础信息
        GeneralUser userResponsible = new GeneralUser();
        this.GetGeneralInfo(userResponsible);

        //添加责编到库
        if ((userResponsible.Id = UserManager.InsertGeneralUserReturnIndentity(userResponsible)) != 0)
        {
            //更新栏目
            for (int i = 0; i < this.CBLArticleColumn.Items.Count; i++)
            {
                if (this.CBLArticleColumn.Items[i].Selected)
                {
                    //搜出栏目 对象
                    int columnId = Convert.ToInt32(this.CBLArticleColumn.Items[i].Value);
                    ArticleColumn articleColumn = ArticleColumnManager.GetArticleColumnById(columnId);

                    //更新栏目对应责编
                    articleColumn.ResponsibelUserId = userResponsible.Id;
                    articleColumn.UserInfo_Name = userResponsible.Name;
                    ArticleColumnManager.UpdateArticleColumn(articleColumn);

                }
                
            }
        }
        else
        {
            return;
        }

        //显示成功页面
        this.HideAllPanel();
        this.PanelSuccess.Visible = true;
    }

    /// <summary>
    /// 主副编完成按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnFinishChife(object sender, EventArgs e)
    {
        //获取基础信息
        GeneralUser userChife = new GeneralUser();
        this.GetGeneralInfo(userChife);

        //添加入库
        if (UserManager.InsertGeneralUserReturnIndentity(userChife) == 0)
        {
            return;
        }

        //显示成功页面
        this.HideAllPanel();
        this.PanelSuccess.Visible = true;

    }

    /// <summary>
    /// 响应继续添加按钮
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void OnContinue(object sender, EventArgs e)
    {
        Response.Redirect("AddUser.aspx");
    }

    #endregion

    #region 验证控件函数
    /// <summary>
    /// 用户名验证函数
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void OnCheckName(object source, ServerValidateEventArgs args)
    {

        string strName = args.Value;
        if (strName == "")
        {
            
            args.IsValid = false;
            this.CustomV_Name.Text = "不允许为空！";
            return;
 
        }

        else if (UserManager.IsUserExist(strName) == true)
        {
            args.IsValid = false;
            this.CustomV_Name.Text = "用户名已存在！";
            return;
   
        }

        else { args.IsValid = true; }

    }

    /// <summary>
    /// 密码验证
    /// </summary>
    /// <param name="source"></param>
    /// <param name="args"></param>
    protected void OnCheckPWD(object source, ServerValidateEventArgs args)
    {
        string strPws = this.TBUserPWD.Text;
        string strRepws = this.TBrePWD.Text;

        if (strPws == "")
        {
            args.IsValid = false;
            this.LBPWD.Text = "密码不允许为空！";
            return;
        }
        else if (String.Compare(strPws, strRepws) != 0)
        {
            args.IsValid = false;
            this.CustomV_PWD.Text = "密码不一致";
            return;

        }
        else { args.IsValid = true;}
    }




      
    #endregion

    
}
