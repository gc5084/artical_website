/*==========================================================
 * Class Name   :   ArticleColumn
 * Author       :   ZhangQi
 * Create Time  :   2009.11.7
 * Updata Record:   LiangYi 2009.11.22
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// �����Ŀ���ݷ�����
    /// </summary>
    public class ArticleColumnService
	{
		#region �ǲ�ѯ����
		/// <summary>
		/// �����µĸ����Ŀ
		/// </summary>
		/// <param name="artClm">�����Ŀ����</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int InsertArticleColumn(ArticleColumn articleColumn)
		{
			//�����ѯ�ַ���
            string sql = @"Insert Into ArticleColumn(ArticleColumn_Name ,ArticleColumn_Description,ArticleColumn_ResponsibleEditorID)
					Values(@artClmName , @artClmDesc,@artRespInt)";
			DBVisit.ObjDBAccess.CommandStr = sql;			//����ѯ�ַ������������ַ���

			//�������������в�ѯ����
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmName", SqlDbType.VarChar, 100).Value = articleColumn.Name;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmDesc", SqlDbType.VarChar, 1000).Value = articleColumn.Description;

            DBVisit.ObjDBAccess.CmdParas.Add("@artRespInt", SqlDbType.Int, 100).Value = articleColumn.ResponsibelUserId;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�������Ӧ����
		}

		/// <summary>
		/// ���¸����Ŀ
		/// </summary>
		/// <param name="artClm">�����Ŀ����</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int UpdateArticleColumn(ArticleColumn articleColumn)
		{
			//�����ѯ�ַ���
            string sql = @"Update ArticleColumn Set ArticleColumn_Name=@artClmName ,ArticleColumn_Description=@artClmDesc,ArticleColumn_ResponsibleEditorID=@artResInt where ArticleColumn_ID=@artClmId ";
			DBVisit.ObjDBAccess.CommandStr = sql;			//����ѯ�ַ������������ַ���

			//�������������в�ѯ����
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = articleColumn.Id;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmName", SqlDbType.VarChar, 100).Value = articleColumn.Name;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmDesc", SqlDbType.VarChar, 1000).Value = articleColumn.Description;
            DBVisit.ObjDBAccess.CmdParas.Add("@artResInt", SqlDbType.Int, 10).Value = articleColumn.ResponsibelUserId;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�������Ӧ����
		}

		/// <summary>
		/// ɾ��һ�������Ŀ
		/// �����α༭����������ж������Ŀ�����ã������Ŀ������ɾ��
		/// </summary>
		/// <param name="artClmId">Ҫɾ���ĸ����Ŀ���</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int DeleteArticleColumn(int artClmId)
		{
            ////�����ѯ�ַ���
            //string sql1 = @"Select * From ResponsibleEditor Where ResponsibleEditor_ColumnID = @artClmId";
            //DBVisit.ObjDBAccess.CommandStr = sql1;			//����ѯ�ַ������������ַ���
            ////�������������в�ѯ����
            //DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;
            //bool resEditorExist = DBVisit.ObjDBAccess.IsExist();		//��ѯ�������Ƿ���Ҫɾ���ĸ����Ŀ������

			//�����ѯ�ַ���
			string sql2 = @"Select * From Article Where Article_ColumnID = @artClmId";
			DBVisit.ObjDBAccess.CommandStr = sql2;			//����ѯ�ַ������������ַ���
			//�������������в�ѯ����
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;
			bool articleExist = DBVisit.ObjDBAccess.IsExist();		//��ѯ��������Ƿ���Ҫɾ���ĸ����Ŀ������

			if (articleExist)	//�����α༭��������д��ڶ������Ŀ�����ã������Ŀ������ɾ��
			{
				return 0;
			}
			else
			{
				//�����ѯ�ַ���
				string sql = @"Delete from ArticleColumn Where ArticleColumn_ID = @artClmId";
				DBVisit.ObjDBAccess.CommandStr = sql;			//����ѯ�ַ������������ַ���
				//�������������в�ѯ����
				DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;

				return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�������Ӧ����
			}
		}
		#endregion

		#region ��ѯ����
		/// <summary>
		/// ���ݸ����ĿId��ѯ�����Ŀ��Ϣ
		/// </summary>
		/// <param name="artClmId">�����ĿId</param>
		/// <returns>�����Ŀ����</returns>
		public static ArticleColumn GetArticleColumnById(int artClmId)
		{
			//�����ѯ�ַ���
            string sql = @"Select ArticleColumn_ID , ArticleColumn_Name , ArticleColumn_Description ,ArticleColumn_ResponsibleEditorID, UserInfo_RealName
					From ArticleColumn,UserInfo Where ArticleColumn_ID = @artClmId and UserInfo_ID = ArticleColumn_ResponsibleEditorID";
			ArticleColumn artClm = new ArticleColumn();		//ʵ���������Ŀ����

			DBVisit.ObjDBAccess.CommandStr = sql;			//����ѯ�ַ������������ַ���
			//�������������в�ѯ����
            DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����

            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
            {
                artClm.Id = int.Parse(ds.Tables[0].Rows[0]["ArticleColumn_ID"].ToString());
                artClm.Name = ds.Tables[0].Rows[0]["ArticleColumn_Name"].ToString();
                artClm.Description = ds.Tables[0].Rows[0]["ArticleColumn_Description"].ToString();
                artClm.ResponsibelUserId = Convert.ToInt32(ds.Tables[0].Rows[0]["ArticleColumn_ResponsibleEditorID"]);
                artClm.UserInfo_Name = ds.Tables[0].Rows[0]["UserInfo_RealName"].ToString();

                return artClm;				//���ظ����Ŀ�����
            }
            else
                return null;
		}

		/// <summary>
		/// �������еĸ����Ŀ
		/// </summary>
		/// <returns>�����Ŀ����DataTable</returns>
		public static DataTable GetArticleColumnAll()
		{
			//�����ѯ�ַ���
            string sql = @"Select ArticleColumn_ID ,ArticleColumn_Name , ArticleColumn_Description ,ArticleColumn_ResponsibleEditorID, UserInfo_RealName From ArticleColumn, UserInfo Where UserInfo_ID = ArticleColumn_ResponsibleEditorID";
			//�������ݿ�
			DBVisit.ObjDBAccess.CommandStr = sql;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����
			ds.Tables[0].TableName = "Message";

			return ds.Tables[0];		//���ظ����Ŀ�����
        }
        #region Rosy
        /// <summary>
        /// ����������Ŀ��Ų��Ҷ�Ӧ�����α༭���
        /// </summary>
        /// <param name="columnID">������Ŀ���</param>
        /// <returns>���α༭���</returns>
        public static int GetAuthorIDByArticleColumnID(int columnID)
        {
            string sql = @"Select ArticleColumn_ResponsibleEditorID From ArticleColumn Where ArticleColumn_ID = @ArticleColumn_ID";
			//�������ݿ�
			DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleColumn_ID", SqlDbType.Int).Value = columnID;
			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            if (ds.Tables[0].Rows.Count != 1)
            {
                return -1;
            }
            return Convert.ToInt32(ds.Tables[0].Rows[0]["ArticleColumn_ResponsibleEditorID"]);
        }
		
        #endregion Rosy
        #endregion
    }
}
