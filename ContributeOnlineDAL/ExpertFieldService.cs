/*==========================================================
 * Class Name   :   ExpertFieldService
 * Author       :   LiangYi
 * Create Time  :   2009.11.8
 * Updata Record:   none,
 *                  2009.11.20 (Blue)  添加函数GetExpertIDByED
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
    /// 专家--领域关系表数据访问类
    /// </summary>
    public static class ExpertFieldService
    {
        #region 查询方法

        /// <summary>
        /// 根据id返回专家--领域关系对象
        /// </summary>
        /// <returns></returns>
        public static ExpertField GetExpertFieldById(int id)
        {
            //SQL语句
            string sql = "select [ExpertField_ID], [ExpertField_ExpertID], [ExpertField_FieldID], [ExpertField_IsUserDefine], [ExpertField_UserDefineName] "
                + " from ExpertField where [ExpertField_ID] = @ExpertField_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_ID", SqlDbType.Int).Value = id;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            //实例化专家--领域关系对象
            ExpertField expertField = new ExpertField();                               
            expertField.ID = int.Parse(ds.Tables[0].Rows[0]["ExpertField_ID"].ToString());
            expertField.ExpertId = int.Parse(ds.Tables[0].Rows[0]["ExpertField_ExpertID"].ToString());
            expertField.FieldId = int.Parse(ds.Tables[0].Rows[0]["ExpertField_FieldID"].ToString());
            expertField.IsDefine = bool.Parse(ds.Tables[0].Rows[0]["ExpertField_IsUserDefine"].ToString());
            expertField.DefineName = ds.Tables[0].Rows[0]["ExpertField_UserDefineName"].ToString();

            return expertField;
        }

        /// <summary>
        /// 返回全部专家--领域关系对象
        /// </summary>
        /// <returns></returns>
        public static DataTable GetExpertFieldAll()
        {
            //SQL语句
            string sql = "select [ExpertField_ID], [ExpertField_ExpertID], [ExpertField_FieldID], [ExpertField_IsUserDefine], [ExpertField_UserDefineName] "
                + " from ExpertField ";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            ds.Tables[0].TableName = "ExpertField";

            return ds.Tables["ExpertField"];
        }

        /// <summary>
        /// 根据具体的领域和专家查找 专家--领域的ID
        /// </summary>
        /// <param name="field"></param>
        /// <param name="userExpert"></param>
        /// <returns> 返回包含所有满足条件专家--领域的ID的DataTable</returns>
        public static DataTable GetExpertIDByED(Field field, UserExpert userExpert)
        {
            //sql语句
            string sql = " select ExpertField_ID from ExpertField " +
                "where ExpertField_ExpertID = @ExpertField_ExpertID and ExpertField_FieldID = @ExpertField_FieldID";
            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            ds.Tables[0].TableName = "ExpertID";

            return ds.Tables["ExpertID"];

        }

        #endregion

        #region 非查询方法

        /// <summary>
        /// 更新专家--领域关系对象
        /// </summary>
        /// <param name="expertField"></param>
        /// <returns></returns>
        public static int UpdateExpertField(ExpertField expertField)
        {
            //SQL语句
            string sql = "Update expertField set [ExpertField_ExpertID] = @ExpertField_ExpertID, [ExpertField_FieldID] = @ExpertField_FieldID, [ExpertField_IsUserDefine] = @ExpertField_IsUserDefine,"
                + " [ExpertField_UserDefineName] = @ExpertField_UserDefineName where [ExpertField_ID] = @ExpertField_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_ID", SqlDbType.Int).Value = expertField.ID;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_ExpertID", SqlDbType.Int).Value = expertField.ExpertId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_FieldID", SqlDbType.Int).Value = expertField.FieldId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_IsUserDefine", SqlDbType.Bit).Value = expertField.IsDefine;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_UserDefineName", SqlDbType.VarChar, 50).Value = expertField.DefineName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// 新建专家--领域关系对象
        /// </summary>
        /// <param name="expertField"></param>
        /// <returns></returns>
        public static int InsertExpertField(ExpertField expertField)
        {
            string sql = "Insert into expertField(ExpertField_ExpertID, ExpertField_FieldID, ExpertField_IsUserDefine, ExpertField_UserDefineName) "
                + " Values(@ExpertField_ExpertID, @ExpertField_FieldID, @ExpertField_IsUserDefine, @ExpertField_UserDefineName)";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_ExpertID", SqlDbType.Int).Value = expertField.ExpertId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_FieldID", SqlDbType.Int).Value = expertField.FieldId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_IsUserDefine", SqlDbType.Bit).Value = expertField.IsDefine;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_UserDefineName", SqlDbType.VarChar, 50).Value = expertField.DefineName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// 删除专家--领域关系对象
        /// </summary>
        /// <param name="expertField"></param>
        /// <returns></returns>
        public static int DeleteExpertField(int expertField_ID)
        {
            //SQL语句
            string sql = "Delete From expertField Where [ExpertField_ID] = @ExpertField_ID";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ExpertField_ID", SqlDbType.Int).Value = expertField_ID;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion
    }
}
