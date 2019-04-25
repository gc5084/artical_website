/*==========================================================
 * Class Name   :   MessageManager
 * Author       :   Rosy
 * Create Time  :   2009.11.19
 * Updata Record:   2009.11.25
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.Models.ConstPara;
using ContributeOnlineSystem.DAL;
using System.Data;
namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 用户管理类
    /// </summary>
    public class UserManager
    {
        #region 查询信息
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <param name="userType">用户类型</param>
        /// <returns>用户是否存在</returns>
        public static bool IsUserExist(string name, string password)
        {
            bool result = GeneralUserService.IsExist(name, password);
            return result;
        }
        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="password">用户密码</param>
        /// <returns>用户是否存在</returns>
        public static bool IsUserExist(string name)
        {
            bool result = GeneralUserService.IsExist(name);
            return result;
        }
        /// <summary>
        ///  根据用户类型返回用户
        /// </summary>
        /// <param name="RoleId"></param>
        /// <returns></returns>
        public static List<GeneralUser> GetGeneralUserByRoleId(int RoleId)
        {
            return GeneralUserService.GetGeneralUserByRoleId(RoleId);
        }
        /// <summary>
        /// 获取所有用户信息列表
        /// </summary>
        /// <returns></returns>
        public static List<GeneralUser> GetUserInfoList()
        {
            return GeneralUserService.GetGeneralUserAll();
        }
        /// <summary>
        /// 按用户ID获取用户信息
        /// </summary>
        /// <param name="id">用户编号</param>
        /// <returns></returns>
        public static GeneralUser GetGeneralUserInfoById(int id)
        {
            return GeneralUserService.GetGeneralUserById(id);
        }
        #endregion

        #region 操作
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user">要修改的用户信息</param>
        /// <returns>操作结果</returns>
        public static int UpdateUserPassword(GeneralUser user)
        {
            int result = -1;
            //修改用户编号
            switch (user.RoleInfo.Id)
            {
                case UserRoleConst.Administrator:    //系统管理员
                    result = GeneralUserService.UpdateGeneralUser(user);
                    break;
                //更新一般用户信息
                case UserRoleConst.ChiefEditor:      //主编
                    result = GeneralUserService.UpdateGeneralUser(user);
                    break;
                case UserRoleConst.LayoutEditor:     //排版编辑
                    result = GeneralUserService.UpdateGeneralUser(user);
                    break;
                case UserRoleConst.ResponsibleEditor://责任编辑
                    result = GeneralUserService.UpdateGeneralUser(user);
                    break;
                case UserRoleConst.SubEditor:        //副主编
                    result = GeneralUserService.UpdateGeneralUser(user);
                    break;
                //更新特殊用户信息
                case UserRoleConst.Author:           //作者
                    UserAuthor auther = user as UserAuthor;
                    result = UserAuthorService.UpdateUserAuthor(auther);
                    break;
                case UserRoleConst.Expert:           //专家
                    UserExpert expert = user as UserExpert;
                    result = UserExpertService.UpdateUserExpert(expert);
                    break;
            }
            return result;
        }

        
        /// <summary>
        /// 修改管理员密码
        /// </summary>
        /// <param name="oldPwd">旧密码</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>操作结果</returns>
        public static bool UpdateAdminPassword(string oldPwd, string newPwd)
        {
            int result = 0;
            GeneralUser admin = GetGeneralUserInfoById(1);  //获取管理员信息
            if (admin != null && admin.Pwd == oldPwd)
            { //旧密码正确
                admin.Pwd = newPwd;                                         //设置用户密码
                result = GeneralUserService.UpdateGeneralUser(admin);      //修改管理员密码
            }
            if (result > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="generalUser"></param>
        /// <returns></returns>
        public static int InsertGeneralUserReturnIndentity(GeneralUser generalUser)
        {
            return GeneralUserService.InsertGeneralUserReturnIdentity(generalUser);
        }

  
        /// <summary>
        /// 获取用户类型信息列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRoleAllExceptAdmin()
        {
            return RoleService.GetRoleAllExceptAdmin();
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        public static int UpdateGeneralUserInfo(GeneralUser userInfo)
        {
            return GeneralUserService.UpdateGeneralUser(userInfo);
        }

        /// <summary>
        /// 创建作者信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static int AddNewAuthor(UserAuthor user)
        {
            return UserAuthorService.InsertUserExpert(user);
        }
        #endregion 操作
        /////////////////////////////////////////////////////////////
        #region Blue
        /// <summary>
        /// 删除专家信息
        /// </summary>
        /// <param name="UserID"></param>
        /// <returns></returns>
        public static int DeleteUserExpert(int UserID)
        {
            return UserExpertService.DeleteUserExpert(UserID);
        }

        public static int DeleteUser(int UserID)
        {
            return UserAuthorService.DeleteUserAuthor(UserID);
        }



        #endregion
        /////////////////////////////////////////////////////////////
        #region 用户登陆部分
        /// <summary>
        /// 管理员登陆
        /// </summary>
        /// <param name="adminName">管理员名称</param>
        /// <param name="adminPwd">管理员密码</param>
        /// <returns>是否登录成功</returns>
        public static bool AdminLogin(string adminName, string adminPwd)
        {
            bool pass = true;
            GeneralUser adminInfo = GeneralUserService.GetGeneralUserById(1);       //获取管理员信息

            if (adminInfo == null)
            {   //管理员信息不存在
                return false;
            }
            if (adminInfo.Name != adminName || adminInfo.Pwd != adminPwd)
            {   //身份验证
                pass = false;
            }
            return pass;
        }
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="name">用户名称</param>
        /// <param name="pwd">密码</param>
        /// <param name="userType">用户类型</param>
        /// <returns>成功登陆返回用户信息，否则为null</returns>
        public static GeneralUser UserLogin(string name, string pwd, int userType)
        {
            GeneralUser user = null;
            List<GeneralUser> userList = GeneralUserService.GetGeneralUserByRoleId(userType);
            //查找用户信息
            for (int i = 0; i < userList.Count; i++)
            {
                if (userList[i].Name == name && userList[i].Pwd == pwd)
                {//用户存在
                    user = userList[i];
                }
            }
            return user;
        }
        #endregion
    }
}
