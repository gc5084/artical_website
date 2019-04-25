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

public partial class UserLocation_InformationCenter_MessageDetail : System.Web.UI.Page
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
            int messID = Convert.ToInt32(Request.QueryString["MessageID"]); //获取消息编号
            Message message = MessageManager.GetMessageById(messID);
            lblID.Text = message.Id.ToString();
            lblReceiver.Text = message.ReceiverID.ToString();
            lblSender.Text = message.SenderId.ToString();
            lblType.Text = message.Type.ToString();
            txtMessageContent.Text = message.Content;
            txtTime.Value = message.Time.ToShortDateString();
        }
    }
}
