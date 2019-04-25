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

public partial class UserLocation_InformationCenter_MessageList : System.Web.UI.Page
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
            int userId = (Session["UserInfo"] as GeneralUser).Id;
            string modeStr = Request.QueryString["SearchMode"].ToString();
            DataTable tempDt;
            switch (modeStr)
            {
                case "UnRead":  //未读信息
                    tempDt = MessageManager.GetReadMessage(userId, false);
                    this.lblTitle.Text = "未读信息";
                    break;
                case "ReadOld": //已读信息
                    tempDt = MessageManager.GetReadMessage(userId, true);
                    this.lblTitle.Text = "已读信息";
                    break;
                case "Sender":  //已发送信息
                    tempDt = MessageManager.GetSenderMessage(userId);
                    this.lblTitle.Text = "已发送信息";
                    break;
                case "All":     //所有信息
                    tempDt = MessageManager.GetAllMessageById(userId);
                    this.lblTitle.Text = "所有信息";
                    break;
                default:
                    throw new Exception("Rosy：不存在的消息类型");
            }
            //绑定数据
            gvMessageList.DataSource = tempDt;
            gvMessageList.DataBind();
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
        string url = "~/UserLocation/InformationCenter/MessageDetail.aspx?MessageID=" + lbtn.CommandArgument;
        Response.Redirect(url);
    }
}
