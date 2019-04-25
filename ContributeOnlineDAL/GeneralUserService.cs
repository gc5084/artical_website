/*==========================================================
 * Class Name   :   GeneralUserService
 * Author       :   LiangYi
 * Create Time  :   2009.11.8
 * Updata Record:   2009.11.25
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Data.SqlClient;
using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 用户信息表数据访问类
    /// </summary>
    public static class GeneralUserService
    {
        #region 查询方法
        /// <summary>
        /// 根据id返回用户信息对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static GeneralUser GetGeneralUserById(int id)
        {
            string sql = "Select [UserInfo_ID], [UserInfo_RoleID], [UserInfo_Name], [UserInfo_Pwd], [UserInfo_CreateTime], [UserInfo_RealName], [UserInfo_Sex], [UserInfo_Birthday], [UserInfo_Tel], [UserInfo_Email] "
            + " From UserInfo Where [UserInfo_ID] = @UserInfo_ID ";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = id;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];

            //创建用户信息对象
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            return CreateUser(dt.Rows[0]);
        }

        /// <summary>
        /// 根据用户角色查找用户信息对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<GeneralUser> GetGeneralUserByRoleId(int id)
        {
            string sql = "Select [UserInfo_ID], [UserInfo_RoleID], [UserInfo_Name], [UserInfo_Pwd], [UserInfo_CreateTime], [UserInfo_RealName], [UserInfo_Sex], [UserInfo_Birthday], [UserInfo_Tel], [UserInfo_Email] "
            + " From UserInfo Where [UserInfo_RoleID] = @Role_ID ";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Role_ID", SqlDbType.Int).Value = id;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            int rows = dt.Rows.Count;

            List<GeneralUser> generalUserList = new List<GeneralUser>(rows);
            GeneralUser generalUser = null;
            //获取全部用户信息对象
            for (int i = 0; i < rows; i++)
            {
                generalUser = CreateUser(dt.Rows[i]);                           //创建用户信息对象
                generalUserList.Add(generalUser);                               //添加用户信息对象
            }

            return generalUserList;
        }

        /// <summary>
        /// 创建用户对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static GeneralUser CreateUser(DataRow dr)
        {
            GeneralUser generalUser = new GeneralUser();
            generalUser.Id = int.Parse(dr["UserInfo_ID"].ToString());

            int roleId = int.Parse(dr["UserInfo_RoleID"].ToString());                         //角色编号
            generalUser.RoleInfo = RoleService.GetRoleById(roleId);

            generalUser.Name = dr["UserInfo_Name"].ToString();
            generalUser.Pwd = dr["UserInfo_Pwd"].ToString();
            generalUser.CreateTime = DateTime.Parse(dr["UserInfo_CreateTime"].ToString());
            generalUser.RealName = dr["UserInfo_RealName"].ToString();
            generalUser.Sex = bool.Parse(dr["UserInfo_Sex"].ToString());
            generalUser.Birthday = DateTime.Parse(dr["UserInfo_Birthday"].ToString()); ;
            generalUser.Tel = dr["UserInfo_Tel"].ToString();
            generalUser.Email = dr["UserInfo_Email"].ToString();

            return generalUser;
        }

        /// <summary>
        /// 返回全部用户信息对象
        /// </summary>
        /// <returns></returns>
        public static List<GeneralUser> GetGeneralUserAll()
        {
            string sql = "Select [UserInfo_ID], [UserInfo_RoleID], [UserInfo_Name], [UserInfo_Pwd], [UserInfo_CreateTime], [UserInfo_RealName], [UserInfo_Sex], [UserInfo_Birthday], [UserInfo_Tel], [UserInfo_Email] "
            + " From UserInfo ";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            int rows = dt.Rows.Count;

            List<GeneralUser> generalUserList = new List<GeneralUser>(rows);
            GeneralUser generalUser = null;
            //获取全部用户信息对象
            for (int i = 0; i < rows; i++)
            {
                generalUser = CreateUser(dt.Rows[i]);                           //创建用户信息对象
                generalUserList.Add(generalUser);                               //添加用户信息对象
            }

            return generalUserList;
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool IsExist(string name, string password)
        {
            bool result = false;
            //查询数据
            string selectStr = "Select Count(*) From UserInfo Where UserInfo_Name = @Name and UserInfo_Pwd = @Pwd";
            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Name", SqlDbType.VarChar, 100).Value = name;
            DBVisit.ObjDBAccess.CmdParas.Add("@Pwd", SqlDbType.VarChar, 50).Value = password;
            //判断数据是否存在
            result = DBVisit.ObjDBAccess.IsExist();
            return result;
        }
        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsExist(string name)
        {
            bool result = false;
            //查询数据
            string selectStr = "Select Count(*) From UserInfo Where UserInfo_Name = @Name";
            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Name", SqlDbType.VarChar, 100).Value = name;
            //判断数据是否存在
            result = DBVisit.ObjDBAccess.IsExist();
            return result;
        }
        #endregion

        #region 非查询方法

        /// <summary>
        /// 插入用户信息对象
        /// </summary>
        /// <param name="generalUser"></param>
        /// <returns></returns>
        public static int InsertGeneralUser(GeneralUser generalUser)
        {
            string sql = "Insert Into UserInfo(UserInfo_RoleID, UserInfo_Name, UserInfo_Pwd, UserInfo_CreateTime, UserInfo_RealName, UserInfo_Sex, UserInfo_Birthday, UserInfo_Tel, UserInfo_Email) "
            + "values(@UserInfo_RoleID, @UserInfo_Name, @UserInfo_Pwd, @UserInfo_CreateTime, @UserInfo_RealName, @UserInfo_Sex, @UserInfo_Birthday, @UserInfo_Tel, @UserInfo_Email)";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = generalUser.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = generalUser.Name;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar, 50).Value = generalUser.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = generalUser.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = generalUser.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = generalUser.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = generalUser.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = generalUser.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = generalUser.Email;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        public static int InsertGeneralUserReturnIdentity(GeneralUser generalUser)
        {
            string sql = "Insert Into UserInfo(UserInfo_RoleID, UserInfo_Name, UserInfo_Pwd, UserInfo_CreateTime, UserInfo_RealName, UserInfo_Sex, UserInfo_Birthday, UserInfo_Tel, UserInfo_Email) "
            + "values(@UserInfo_RoleID, @UserInfo_Name, @UserInfo_Pwd, @UserInfo_CreateTime, @UserInfo_RealName, @UserInfo_Sex, @UserInfo_Birthday, @UserInfo_Tel, @UserInfo_Email)";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = generalUser.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = generalUser.Name;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar, 50).Value = generalUser.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = generalUser.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = generalUser.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = generalUser.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = generalUser.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = generalUser.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = generalUser.Email;

            return DBVisit.ObjDBAccess.ExecuteInsertSqlCommandAndReturnIdentity();
        }

        /// <summary>
        /// 更新用户信息对象
        /// </summary>
        /// <param name="generalUser"></param>
        /// <returns></returns>
        public static int UpdateGeneralUser(GeneralUser generalUser)
        {
            string sql = "Update UserInfo set UserInfo_RoleID = @UserInfo_RoleID, UserInfo_Name = @UserInfo_Name, UserInfo_Pwd = @UserInfo_Pwd, "
            + "UserInfo_CreateTime = @UserInfo_CreateTime, UserInfo_RealName = @UserInfo_RealName, UserInfo_Sex = @UserInfo_Sex, "
            + "UserInfo_Birthday = @UserInfo_Birthday, UserInfo_Tel = @UserInfo_Tel, UserInfo_Email = @UserInfo_Email "
            + " Where UserInfo_ID = @UserInfo_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = generalUser.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = generalUser.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = generalUser.Name;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar, 50).Value = generalUser.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = generalUser.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = generalUser.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = generalUser.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = generalUser.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = generalUser.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = generalUser.Email;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <param name="generalUser"></param>
        /// <returns></returns>
        public static int DeleteGeneralUser(int id)
        {
            string sql = "Delete From UserInfo Where UserInfo_ID = @UserInfo_ID";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = id;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion 
    }
}
