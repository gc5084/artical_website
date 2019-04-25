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

public partial class UserLocation_UserSettings_UserExit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["UserInfo"] = null;
            FormsAuthentication.SignOut();
            ClientScript.RegisterStartupScript(GetType(), "URL", "window.open('../../UserLogin.aspx','_top')", true);
            
        }
    }
}
