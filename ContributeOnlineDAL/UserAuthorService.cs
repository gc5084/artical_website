/*==========================================================
 * Class Name   :   UserAuthorService
 * Author       :   LiangYi
 * Create Time  :   2009.11.8
 * Updata Record:   none
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
    /// 作者数据访问类
    /// </summary>
    public static class UserAuthorService
    {
        #region 查询操作

        /// <summary>
        /// 根据id返回作者信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserAuthor GetUserAuthorById(int id)
        {
            string sql = "proc_GetUserAuthorById";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Add("@Author_ID", SqlDbType.Int).Value = id;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteProc(sql).Tables[0];

            return CreateUserAuthor(dt.Rows[0]);

        }

        /// <summary>
        /// 查询所有作者id
        /// </summary>
        /// <returns></returns>
        public static List<UserAuthor> GetUserAuthorAll()
        {
            string sql = "proc_GetUserAuthorAll";

            //连接数据库，执行SQL语句
            DataTable dt = DBVisit.ObjDBAccess.ExecuteProc(sql).Tables[0];
            
            //作者信息列表
            List<UserAuthor> userAuthorList = new List<UserAuthor>(dt.Rows.Count);
            UserAuthor userAuthor = null;

            //创建作者信息对象并添加到作者信息列表中
            foreach(DataRow dr in dt.Rows)
            {
                userAuthor = CreateUserAuthor(dr);
                userAuthorList.Add(userAuthor);
            }

            return userAuthorList;

        }

        /// <summary>
        /// 创建作者信息对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static UserAuthor CreateUserAuthor(DataRow dr)
        {
            UserAuthor userAuthor = new UserAuthor();
            userAuthor.Id = int.Parse(dr["Author_ID"].ToString());
            userAuthor.TypeName = dr["Author_TypeName"].ToString();

            userAuthor.Name = dr["UserInfo_Name"].ToString();
            userAuthor.Pwd = dr["UserInfo_Pwd"].ToString();
            userAuthor.CreateTime = DateTime.Parse(dr["UserInfo_CreateTime"].ToString());
            userAuthor.RealName = dr["UserInfo_RealName"].ToString();
            userAuthor.Sex = bool.Parse(dr["UserInfo_Sex"].ToString());
            userAuthor.Birthday = DateTime.Parse(dr["UserInfo_Birthday"].ToString());
            userAuthor.Tel = dr["UserInfo_Tel"].ToString();
            userAuthor.Email = dr["UserInfo_Email"].ToString();
            //角色信息
            userAuthor.RoleInfo.Id = int.Parse(dr["Role_ID"].ToString());
            userAuthor.RoleInfo.Name = dr["Role_Name"].ToString();
            userAuthor.RoleInfo.NavTreeNodeID = int.Parse(dr["Role_NavTreeNodeID"].ToString());

            return userAuthor;
        }

        #endregion

        #region 非查询操作

        /// <summary>
        /// 删除作者信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteUserAuthor(int id)
        {
            string sql = "proc_DeleteUserAuthor";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@authorId", SqlDbType.Int).Value = id;
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;

            DBVisit.ObjDBAccess.ExcuteProcReturnInt(sql);
            bool result = bool.Parse(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value.ToString());
            if (result)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新作者信息
        /// </summary>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int UpdateUserAuthor(UserAuthor userAuthor)
        {
            string sql = "proc_UpdateUserAuthorInfo";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = userAuthor.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = userAuthor.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = userAuthor.Name;

            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar).Value = userAuthor.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = userAuthor.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = userAuthor.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = userAuthor.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = userAuthor.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = userAuthor.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = userAuthor.Email;

            DBVisit.ObjDBAccess.CmdParas.Add("@Author_TypeName", SqlDbType.VarChar, 50).Value = userAuthor.TypeName;
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;
            DBVisit.ObjDBAccess.ExcuteProcReturnInt(sql);

            bool result = bool.Parse(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value.ToString());
            if (result)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 插入作者信息
        /// </summary>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int InsertUserExpert(UserAuthor userAuthor)
        {
            string sql = "proc_InserIntoAuthor";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = userAuthor.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = userAuthor.Name;

            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar).Value = userAuthor.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = userAuthor.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = userAuthor.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = userAuthor.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = userAuthor.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = userAuthor.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = userAuthor.Email;

            DBVisit.ObjDBAccess.CmdParas.Add("@Author_TypeName", SqlDbType.VarChar, 50).Value = userAuthor.TypeName;
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;
            DBVisit.ObjDBAccess.ExcuteProcReturnInt(sql);

            bool result = bool.Parse(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value.ToString());
            if (result)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        #endregion
    }
}
