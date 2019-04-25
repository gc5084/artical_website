/*==========================================================
 * Class Name   :   FieldService
 * Author       :   LiangYi
 * Create Time  :   2009.11.6
 * Updata Record:   2009.11.8
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;
using System.Data.SqlClient;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 领域信息数据访问类
    /// </summary>
    public static class FieldService
    {
        #region 查询方法

        /// <summary>
        /// 根据id返回领域对象
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns>领域对象</returns>
        public static Field GetFieldById(int id)
        {
            string sql = "select Field_ID, Field_Name from Field where [id] = @id";                 
            Field field = new Field();                                        //实例化领域对象

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@id", SqlDbType.Int).Value = id;

            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            field.Id = int.Parse(ds.Tables[0].Rows[0]["Field_ID"].ToString());
            field.FieldName = ds.Tables[0].Rows[0]["Field_Name"].ToString();

            return field;
        }

        /// <summary>
        /// 返回领域对象DataTable
        /// </summary>
        /// <returns>领域对象DataTable</returns>
        public static DataTable GetFieldAll()
        {
            string sql = "select Field_ID, Field_Name from Field";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;

            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            ds.Tables[0].TableName = "Field";
            return ds.Tables["Field"];
        }

        #endregion

        #region 非查询方法

        /// <summary>
        /// 添加新领域
        /// </summary>
        /// <param name="field">领域对象</param>
        /// <returns>SQL语句影响行数</returns>
        public static int InsertField(Field field)
        {
            string sql = "Insert into Field( [Field_Name]) values( @Field_Name)";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_Name", SqlDbType.VarChar, 50).Value = field.FieldName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// 更新领域信息
        /// </summary>
        /// <param name="field">领域对象</param>
        /// <returns>SQL语句影响行数</returns>
        public static int UpdateField(Field field)
        {
            string sql = "Update field set [Field_ID] = @Field_ID, [Field_Name] = @Field_Name where [Field_ID] = @Field_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_ID", SqlDbType.Int).Value = field.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_Name", SqlDbType.VarChar, 50).Value = field.FieldName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// 根据id删除新领域信息
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns>SQL语句影响行数</returns>
        public static int DeleteFieldById(int id)
        {
            string sql = "Delete From field where [Field_ID] = @Field_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_ID", SqlDbType.Int).Value = id;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion
    }
}
