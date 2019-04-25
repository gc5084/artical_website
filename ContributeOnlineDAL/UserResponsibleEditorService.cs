/*==========================================================
 * Class Name   :   ArticleStateService
 * Author       :   Hong ,Blue
 * Create Time  :   2009.11.7
 * Updata Record:   2009.11.9
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using System.Data;
using System.Data.SqlClient;
using ContributeOnlineSystem.DAL.DBHelper;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 责任编辑类
    /// </summary>
    public class UserResponsibleEditorService
    {
        #region  查询方法

        /// <summary>
        /// 根据ID查找责任编辑
        /// </summary>
        /// <param name="id">要查找的ID</param>
        /// <returns>返回查找的对象</returns>
        public static UserResponsibleEditor GetUserResponsibleEditorById(int id)
        {
            SqlParameter sqlPm = new SqlParameter("@id", id);  //创建一个查询参数
            DBVisit.ObjDBAccess.CmdParas.Add(sqlPm);    //将创建的参数加入到SqlCommand对象中的SqlParameter
            UserResponsibleEditor userResponsibleEditor = new UserResponsibleEditor();   //创建一个对象 用来返回Dataset
            DataTable ds = DBVisit.ObjDBAccess.ExecuteProc("pro_GetUserResponbleEditorById").Tables[0];  //执行查找操作 返回找DataSet
            userResponsibleEditor.Birthday = Convert.ToDateTime(ds.Rows[0]["UserInfo_CreateTime"]);
            userResponsibleEditor.ColumnID = Convert.ToInt32(ds.Rows[0]["ResponsibleEditor_ColumnID"]);
            userResponsibleEditor.CreateTime = Convert.ToDateTime(ds.Rows[0]["UserInfo_CreateTime"]);
            userResponsibleEditor.Email = Convert.ToString(ds.Rows[0]["UserInfo_Email"]);
            userResponsibleEditor.Id = id;
            userResponsibleEditor.Name = Convert.ToString(ds.Rows[0]["UserInfo_Name"]);
            userResponsibleEditor.Pwd = Convert.ToString(ds.Rows[0]["UserInfo_Pwd"]);
            userResponsibleEditor.RealName = Convert.ToString(ds.Rows[0]["UserInfo_RealName"]);
            userResponsibleEditor.Remark = Convert.ToString(ds.Rows[0]["ResponsibleEditor_Remark"]);
            userResponsibleEditor.RoleInfo = RoleService.GetRoleById(int.Parse(ds.Rows[0]["UserInfo_RoleID"].ToString()));
            userResponsibleEditor.Sex = Convert.ToBoolean(ds.Rows[0]["UserInfo_Sex"]);
            userResponsibleEditor.Tel = Convert.ToString(ds.Rows[0]["UserInfo_Tel"]);
            return userResponsibleEditor;           //返回找到的对象
        }

        /// <summary>
        /// 查询所有的责任编辑
        /// </summary>
        /// <returns>返回List<UserResponsibleEditor> </returns>
        public static List<UserResponsibleEditor> GetUserResponsibleAll()
        {
            List<UserResponsibleEditor> list = new List<UserResponsibleEditor>();  //创建一个UserResponsibleEditor泛型用来存储找到的全部信息
            DataTable dt = DBVisit.ObjDBAccess.ExecuteProc("pro_GetUserResponbleEditorAll").Tables[0];   //创建一个对象 用来返回Dataset
            foreach (DataRow dr in dt.Rows)   //遍历所有的行数 给每条记录创建一个对象
            {
                UserResponsibleEditor userResponsibleEditor = new UserResponsibleEditor();
                userResponsibleEditor.Birthday = Convert.ToDateTime(dr["UserInfo_CreateTime"]);
                userResponsibleEditor.ColumnID = Convert.ToInt32(dr["ResponsibleEditor_ColumnID"]);
                userResponsibleEditor.CreateTime = Convert.ToDateTime(dr["UserInfo_CreateTime"]);
                userResponsibleEditor.Email = Convert.ToString(dr["UserInfo_Email"]);
                userResponsibleEditor.Id = Convert.ToInt32(dr["ResponsibleEditor_ID"]);
                userResponsibleEditor.Name = Convert.ToString(dr["UserInfo_Name"]);
                userResponsibleEditor.Pwd = Convert.ToString(dr["UserInfo_Pwd"]);
                userResponsibleEditor.RealName = Convert.ToString(dr["UserInfo_RealName"]);
                userResponsibleEditor.Remark = Convert.ToString(dr["ResponsibleEditor_Remark"]);
                userResponsibleEditor.RoleInfo = RoleService.GetRoleById(int.Parse(dr["UserInfo_RoleID"].ToString()));
                userResponsibleEditor.Sex = Convert.ToBoolean(dr["UserInfo_Sex"]);
                userResponsibleEditor.Tel = Convert.ToString(dr["UserInfo_Tel"]);
                list.Add(userResponsibleEditor);   //加入到UserResponsibleEditor泛型中
            }
            return list;  //返回UserResponsibleEditor泛型
        }

        #endregion

        #region  非查询方法

        /// <summary>
        /// 根据ID删除责任编辑
        /// </summary>
        /// <param name="id">要删除的责任编辑ID</param>
        /// <returns>受影响的行数</returns>
        public static int DeleteUserResponsibleById(int id)
        {
            SqlParameter sql=new SqlParameter ();
            sql.ParameterName = "@IsSuccess";
            sql.Direction = ParameterDirection.Output;
            SqlParameter[] sqlPm = new SqlParameter[]
            {
                new SqlParameter ("@id",id),
                sql
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);
            DBVisit.ObjDBAccess.ExcuteProcReturnInt("por_DeleteUserResponbleEditorById");  //执行存储过程
            bool isOk = Convert.ToBoolean(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value);  //获取存储过程的输出参数
            if (isOk)  
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 增加数据到UserResponsible表中
        /// </summary>
        /// <returns></returns>
        public static int InsertUserResponsible(UserResponsibleEditor userResponsibleEditor)
        {
            SqlParameter isSuccessParam = new SqlParameter();
            isSuccessParam.ParameterName = "@IsSuccess";
            isSuccessParam.Direction = ParameterDirection.Output;
            SqlParameter[] sqlPm = new SqlParameter[]         //创建一个参数列表
            {
                 new SqlParameter ("@UserInfo_RoleID",userResponsibleEditor.RoleInfo.Id),
                 new SqlParameter ("@UserInfo_Name",userResponsibleEditor.Name),
                 new SqlParameter ("@UserInfo_Pwd",userResponsibleEditor.Pwd),
                 new SqlParameter ("@UserInfo_CreateTime",userResponsibleEditor.CreateTime),
                 new SqlParameter ("@UserInfo_RealName",userResponsibleEditor.RealName ),
                 new SqlParameter ("@UserInfo_Sex",userResponsibleEditor.Sex ),
                 new SqlParameter ("@UserInfo_Birthday",userResponsibleEditor.Birthday),
                 new SqlParameter ("@UserInfo_Tel",userResponsibleEditor.Tel),
                 new SqlParameter ("@UserInfo_Email",userResponsibleEditor.Email),
                 new SqlParameter ("@ResponsibleEditor_ColumnID",userResponsibleEditor.ColumnID),
                 new SqlParameter ("@ResponsibleEditor_Remark",userResponsibleEditor.Remark),
                 new SqlParameter ("@UserInfo_Email",userResponsibleEditor.Email),
                isSuccessParam
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);  //将参数加入到SqlCommand的SqlParameter集合中去
            DBVisit.ObjDBAccess.ExcuteProcReturnInt("por_InsertUserResponbleEditorById");  //执行存储过程
            bool isOK = Convert.ToBoolean(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value);
            if (isOK)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 更新责任编辑数据
        /// </summary>
        /// <param name="UpdateUserResponsible">更新责编</param>
        /// <returns>操作结果</returns>
        public static int UpdateUserResponsible(UserResponsibleEditor userResponsibleEditor)
        {
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_ID", SqlDbType.Int).Value = userResponsibleEditor.Id;  //主键ID
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RoleID", SqlDbType.Int).Value = userResponsibleEditor.RoleInfo.Id;  //角色编号
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Name", SqlDbType.VarChar,100).Value = userResponsibleEditor.Name;  //用户名
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Pwd", SqlDbType.VarChar,50).Value = userResponsibleEditor.Pwd;  //用户密码
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_CreateTime", SqlDbType.DateTime).Value = userResponsibleEditor.CreateTime;  //创建时间
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_RealName", SqlDbType.VarChar,50).Value = userResponsibleEditor.RealName;  //真实姓名
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Sex", SqlDbType.Bit).Value = userResponsibleEditor.Sex;  //用户性别
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Birthday", SqlDbType.DateTime).Value = userResponsibleEditor.Birthday;  //用户生日
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Tel", SqlDbType.VarChar,50).Value = userResponsibleEditor.Tel;  //联系电话
            DBVisit.ObjDBAccess.CmdParas.Add("@UserInfo_Email", SqlDbType.VarChar,50).Value = userResponsibleEditor.Email;  //Email
            DBVisit.ObjDBAccess.CmdParas.Add("@ResponsibleEditor_ColumnID", SqlDbType.Int).Value = userResponsibleEditor.ColumnID;  //负责栏目编号
            DBVisit.ObjDBAccess.CmdParas.Add("@ResponsibleEditor_Remark", SqlDbType.VarChar,100).Value = userResponsibleEditor.Remark;  //责编备注
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;  //是否执行成功 参数类型设置为output

            //执行
            DBVisit.ObjDBAccess.ExcuteProcReturnInt("porc_UpdateUserResponsibleEditorInfo");
            bool isOK = Convert.ToBoolean(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value);
            if (isOK)
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
