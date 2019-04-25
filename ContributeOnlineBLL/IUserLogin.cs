/*==========================================================
 * Class Name   :   ExpertFieldManager
 * Author       :   Blue
 * Create Time  :   2009.11.20
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL;
using System.Data;

using ContributeOnlineSystem.Models.ConstPara;

namespace ContributeOnlineSystem.BLL
{
    public interface IUserLogin
    {
 
         bool IsExist();
         int GetUserType();
         bool Login();
         bool Exit();

    }
}
