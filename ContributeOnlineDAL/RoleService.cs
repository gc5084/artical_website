/*==========================================================
 * Class Name   :   RoleService
 * Author       :   LiangYi
 * Create Time  :   2009.11.6
 * Updata Record:   2009.11.8
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;
using System.Data.SqlClient;
using ContributeOnlineSystem.Models;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 角色表数据访问类
    /// </summary>
    public static class RoleService
    {
        #region 查询方法

        public static Role GetRoleById(int id)
        {
            string sql = "Select [Role_ID], [Role_Name], [Role_NavTreeNodeID] From Role Where [Role_ID] = @Role_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Role_ID", SqlDbType.Int).Value = id;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];

            //创建角色对象
            Role role = new Role();
            role.Id = int.Parse(dt.Rows[0]["Role_ID"].ToString());
            role.Name = dt.Rows[0]["Role_Name"].ToString();
            role.NavTreeNodeID = int.Parse(dt.Rows[0]["Role_NavTreeNodeID"].ToString());

            return role;
        }

        /// <summary>
        /// 返回全部角色信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRoleAll()
        {
            string sql = "Select [Role_ID], [Role_Name], [Role_NavTreeNodeID] From Role ";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            dt.TableName = "Role";

            return dt;
        }
        /// <summary>
        /// 获取类型信息(除去管理员)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetRoleAllExceptAdmin()
        {
            DataTable userRoleList = GetRoleAll();
            for (int i = 0; i < userRoleList.Rows.Count; i++)
            {
                if ((Convert.ToInt32(userRoleList.Rows[i]["Role_ID"]) == 0))
                { //用户类型为管理员
                    userRoleList.Rows.Remove(userRoleList.Rows[i]);
                }
            }
            return userRoleList;
        }

        #endregion

        #region 非查询方法

        /// <summary>
        /// 修改角色名称
        /// </summary>
        /// <param name="role">角色对象</param>
        /// <returns>SQL语句影响行数</returns>
        public static int UpdateRoleName(Role role)
        {
            string sql = "Update Role set [Role_Name] = @Role_Name, [Role_NavTreeNodeID] = @Role_NavTreeNodeID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Role_Name", SqlDbType.VarChar,50).Value = role.Name;
            DBVisit.ObjDBAccess.CmdParas.Add("@Role_NavTreeNodeID", SqlDbType.Int).Value = role.NavTreeNodeID;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion

    }
}
