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
public partial class Admin_PageExpertFieldManager_PageFieldSearch : System.Web.UI.Page
{
    ExpertFieldManager expertField = new ExpertFieldManager();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            DataBindMethod();
        }
    }

    /// <summary>
    /// 绑定数据到gvExpertFiled控件
    /// </summary>
    private void DataBindMethod()
    {

        gvExpertFiled.DataSource = ExpertFieldManager.GetFieldAll();
        gvExpertFiled.DataBind();
    }
    

    /// <summary>
    /// 增加到领域表
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddFiled_Click(object sender,EventArgs e)
    {
        if (txtName.Text.Length > 0)  //文本框非空
        {
            Field filed = new Field();
            filed.FieldName = txtName.Text.Trim();
            ExpertFieldManager.InsertField(filed);
            DataBindMethod();
            
        }
    }

   

    /// <summary>
    /// 删除按钮事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtnDel_Click(object sender, EventArgs e)
    {
        LinkButton lkb = sender as LinkButton;
        int id = int.Parse(lkb.CommandArgument);
        ExpertFieldManager.DeleteFieldById(id);
        
    }
    /// <summary>
    /// GV删除行处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvExpertFiled_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        DataBindMethod();//重新绑定
    }
}
