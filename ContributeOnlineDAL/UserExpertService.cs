/*==========================================================
 * Class Name   :   UserExpertService
 * Author       :   LiangYi
 * Create Time  :   2009.11.8
 * Updata Record:   2009.11.24(修改InsertUserExpert，blue)
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
    /// 专家用户信息数据访问类
    /// </summary>
    public static class UserExpertService
    {
        #region 查询方法

        /// <summary>
        /// 根据id返回专家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserExpert GetUserExpertById(int id)
        {
            string sql = "proc_GetUserExpertById";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_ID", SqlDbType.Int).Value = id;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteProc(sql).Tables[0];

            return CreateUserExpert(dt.Rows[0]);

        }

        /// <summary>
        /// 创建专家信息对象
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static UserExpert CreateUserExpert(DataRow dr)
        {
            UserExpert userExpert = new UserExpert();
            userExpert.Id = int.Parse(dr["Expert_ID"].ToString());
            userExpert.WorkPlace = dr["Expert_WorkPlace"].ToString();
            userExpert.Intro = dr["Expert_Intro"].ToString();
            userExpert.Remark = dr["Expert_Remark"].ToString();
            userExpert.Name = dr["UserInfo_Name"].ToString();
            userExpert.Pwd = dr["UserInfo_Pwd"].ToString();
            userExpert.CreateTime = DateTime.Parse(dr["UserInfo_CreateTime"].ToString());
            userExpert.RealName = dr["UserInfo_RealName"].ToString();
            userExpert.Sex = bool.Parse(dr["UserInfo_Sex"].ToString());
            userExpert.Birthday = DateTime.Parse(dr["UserInfo_Birthday"].ToString());
            userExpert.Tel = dr["UserInfo_Tel"].ToString();
            userExpert.Email = dr["UserInfo_Email"].ToString();
            //角色信息
            userExpert.RoleInfo.Id = int.Parse(dr["Role_ID"].ToString());
            userExpert.RoleInfo.Name = dr["Role_Name"].ToString();
            userExpert.RoleInfo.NavTreeNodeID = int.Parse(dr["Role_NavTreeNodeID"].ToString());

            return userExpert;
        }

        /// <summary>
        /// 返回全部专家信息
        /// </summary>
        /// <returns></returns>
        public static List<UserExpert> GetUserExpertAll()
        {
            string sql = "proc_GetUserExpertAll";

            //连接数据库，执行SQL语句
            DataTable dt = DBVisit.ObjDBAccess.ExecuteProc(sql).Tables[0];
            
            //专家信息列表
            List<UserExpert> userExpertList = new List<UserExpert>(dt.Rows.Count);
            UserExpert userExpert = null;

            //创建专家信息对象并添加到专家信息列表中
            foreach (DataRow dr in dt.Rows)
            {
                userExpert = CreateUserExpert(dr);
                userExpertList.Add(userExpert);
            }

            return userExpertList;

        }

        #endregion

        #region 非查询方法

        /// <summary>
        /// 删除专家信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteUserExpert(int id)
        {
            string sql = "proc_DeleteUserExpert";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_ID", SqlDbType.Int).Value = id;
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
        /// 更新专家信息
        /// </summary>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int UpdateUserExpert(UserExpert userExpert)
        {
            string sql = "proc_UpdateUserExpertInfo";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = userExpert.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = userExpert.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = userExpert.Name;

            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar).Value = userExpert.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = userExpert.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = userExpert.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = userExpert.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = userExpert.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = userExpert.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = userExpert.Email;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_WorkPlace", SqlDbType.VarChar, 100).Value = userExpert.WorkPlace;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_Intro", SqlDbType.VarChar, 1000).Value = userExpert.Intro;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_Remark", SqlDbType.VarChar, 100).Value = userExpert.Remark;
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
        /// 插入新专家信息
        /// </summary>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int InsertUserExpert(UserExpert userExpert)
        {
            string sql = "proc_InsertUserExpert";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = userExpert.RoleInfo.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar, 100).Value = userExpert.Name;

            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar).Value = userExpert.Pwd;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = userExpert.CreateTime;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar, 100).Value = userExpert.RealName;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = userExpert.Sex;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = userExpert.Birthday;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar, 20).Value = userExpert.Tel;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar, 50).Value = userExpert.Email;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_WorkPlace", SqlDbType.VarChar, 100).Value = userExpert.WorkPlace;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_Intro", SqlDbType.VarChar, 1000).Value = userExpert.Intro;
            DBVisit.ObjDBAccess.CmdParas.Add("@Expert_Remark", SqlDbType.VarChar, 100).Value = userExpert.Remark;
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;
            DBVisit.ObjDBAccess.CmdParas.Add("@OutExpertID", SqlDbType.Int).Direction = ParameterDirection.Output; //带出自增的用户ID
            DBVisit.ObjDBAccess.ExcuteProcReturnInt(sql);

            bool result = bool.Parse(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value.ToString());
            userExpert.Id = Convert.ToInt32(DBVisit.ObjDBAccess.CmdParas["@OutExpertID"].Value);

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
