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
    /// ������Ϣ���ݷ�����
    /// </summary>
    public static class FieldService
    {
        #region ��ѯ����

        /// <summary>
        /// ����id�����������
        /// </summary>
        /// <param name="id">����id</param>
        /// <returns>�������</returns>
        public static Field GetFieldById(int id)
        {
            string sql = "select Field_ID, Field_Name from Field where [id] = @id";                 
            Field field = new Field();                                        //ʵ�����������

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@id", SqlDbType.Int).Value = id;

            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            field.Id = int.Parse(ds.Tables[0].Rows[0]["Field_ID"].ToString());
            field.FieldName = ds.Tables[0].Rows[0]["Field_Name"].ToString();

            return field;
        }

        /// <summary>
        /// �����������DataTable
        /// </summary>
        /// <returns>�������DataTable</returns>
        public static DataTable GetFieldAll()
        {
            string sql = "select Field_ID, Field_Name from Field";

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;

            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            ds.Tables[0].TableName = "Field";
            return ds.Tables["Field"];
        }

        #endregion

        #region �ǲ�ѯ����

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="field">�������</param>
        /// <returns>SQL���Ӱ������</returns>
        public static int InsertField(Field field)
        {
            string sql = "Insert into Field( [Field_Name]) values( @Field_Name)";

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_Name", SqlDbType.VarChar, 50).Value = field.FieldName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// ����������Ϣ
        /// </summary>
        /// <param name="field">�������</param>
        /// <returns>SQL���Ӱ������</returns>
        public static int UpdateField(Field field)
        {
            string sql = "Update field set [Field_ID] = @Field_ID, [Field_Name] = @Field_Name where [Field_ID] = @Field_ID";

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_ID", SqlDbType.Int).Value = field.Id;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_Name", SqlDbType.VarChar, 50).Value = field.FieldName;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// ����idɾ����������Ϣ
        /// </summary>
        /// <param name="id">����id</param>
        /// <returns>SQL���Ӱ������</returns>
        public static int DeleteFieldById(int id)
        {
            string sql = "Delete From field where [Field_ID] = @Field_ID";

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@Field_ID", SqlDbType.Int).Value = id;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion
    }
}
