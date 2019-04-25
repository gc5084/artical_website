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
    /// 稿件栏目数据访问类
    /// </summary>
    public class ArticleColumnService
	{
		#region 非查询操作
		/// <summary>
		/// 插入新的稿件栏目
		/// </summary>
		/// <param name="artClm">稿件栏目对像</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int InsertArticleColumn(ArticleColumn articleColumn)
		{
			//构造查询字符串
            string sql = @"Insert Into ArticleColumn(ArticleColumn_Name ,ArticleColumn_Description,ArticleColumn_ResponsibleEditorID)
					Values(@artClmName , @artClmDesc,@artRespInt)";
			DBVisit.ObjDBAccess.CommandStr = sql;			//将查询字符串赋给命令字符串

			//参数化传递所有查询参数
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmName", SqlDbType.VarChar, 100).Value = articleColumn.Name;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmDesc", SqlDbType.VarChar, 1000).Value = articleColumn.Description;

            DBVisit.ObjDBAccess.CmdParas.Add("@artRespInt", SqlDbType.Int, 100).Value = articleColumn.ResponsibelUserId;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行并返回响应行数
		}

		/// <summary>
		/// 更新稿件栏目
		/// </summary>
		/// <param name="artClm">稿件栏目对像</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int UpdateArticleColumn(ArticleColumn articleColumn)
		{
			//构造查询字符串
            string sql = @"Update ArticleColumn Set ArticleColumn_Name=@artClmName ,ArticleColumn_Description=@artClmDesc,ArticleColumn_ResponsibleEditorID=@artResInt where ArticleColumn_ID=@artClmId ";
			DBVisit.ObjDBAccess.CommandStr = sql;			//将查询字符串赋给命令字符串

			//参数化传递所有查询参数
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = articleColumn.Id;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmName", SqlDbType.VarChar, 100).Value = articleColumn.Name;
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmDesc", SqlDbType.VarChar, 1000).Value = articleColumn.Description;
            DBVisit.ObjDBAccess.CmdParas.Add("@artResInt", SqlDbType.Int, 10).Value = articleColumn.ResponsibelUserId;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行并返回响应行数
		}

		/// <summary>
		/// 删除一个稿件栏目
		/// 若责任编辑表或稿件表中有对这个栏目的引用，则该栏目不允许删除
		/// </summary>
		/// <param name="artClmId">要删除的稿件栏目编号</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int DeleteArticleColumn(int artClmId)
		{
            ////构造查询字符串
            //string sql1 = @"Select * From ResponsibleEditor Where ResponsibleEditor_ColumnID = @artClmId";
            //DBVisit.ObjDBAccess.CommandStr = sql1;			//将查询字符串赋给命令字符串
            ////参数化传递所有查询参数
            //DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;
            //bool resEditorExist = DBVisit.ObjDBAccess.IsExist();		//查询责编表中是否有要删除的稿件栏目的引用

			//构造查询字符串
			string sql2 = @"Select * From Article Where Article_ColumnID = @artClmId";
			DBVisit.ObjDBAccess.CommandStr = sql2;			//将查询字符串赋给命令字符串
			//参数化传递所有查询参数
			DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;
			bool articleExist = DBVisit.ObjDBAccess.IsExist();		//查询稿件表中是否有要删除的稿件栏目的引用

			if (articleExist)	//若责任编辑表或稿件表中存在对这个栏目的引用，则该栏目不允许删除
			{
				return 0;
			}
			else
			{
				//构造查询字符串
				string sql = @"Delete from ArticleColumn Where ArticleColumn_ID = @artClmId";
				DBVisit.ObjDBAccess.CommandStr = sql;			//将查询字符串赋给命令字符串
				//参数化传递所有查询参数
				DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;

				return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行并返回响应行数
			}
		}
		#endregion

		#region 查询操作
		/// <summary>
		/// 根据稿件栏目Id查询稿件栏目信息
		/// </summary>
		/// <param name="artClmId">稿件栏目Id</param>
		/// <returns>稿件栏目对像</returns>
		public static ArticleColumn GetArticleColumnById(int artClmId)
		{
			//构造查询字符串
            string sql = @"Select ArticleColumn_ID , ArticleColumn_Name , ArticleColumn_Description ,ArticleColumn_ResponsibleEditorID, UserInfo_RealName
					From ArticleColumn,UserInfo Where ArticleColumn_ID = @artClmId and UserInfo_ID = ArticleColumn_ResponsibleEditorID";
			ArticleColumn artClm = new ArticleColumn();		//实例化稿件栏目对像

			DBVisit.ObjDBAccess.CommandStr = sql;			//将查询字符串赋给命令字符串
			//参数化传递所有查询参数
            DBVisit.ObjDBAccess.CmdParas.Add("@artClmId", SqlDbType.Int).Value = artClmId;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集

            if (ds.Tables.Count == 1 && ds.Tables[0].Rows.Count == 1)
            {
                artClm.Id = int.Parse(ds.Tables[0].Rows[0]["ArticleColumn_ID"].ToString());
                artClm.Name = ds.Tables[0].Rows[0]["ArticleColumn_Name"].ToString();
                artClm.Description = ds.Tables[0].Rows[0]["ArticleColumn_Description"].ToString();
                artClm.ResponsibelUserId = Convert.ToInt32(ds.Tables[0].Rows[0]["ArticleColumn_ResponsibleEditorID"]);
                artClm.UserInfo_Name = ds.Tables[0].Rows[0]["UserInfo_RealName"].ToString();

                return artClm;				//返回稿件栏目类对像
            }
            else
                return null;
		}

		/// <summary>
		/// 返回所有的稿件栏目
		/// </summary>
		/// <returns>稿件栏目对象DataTable</returns>
		public static DataTable GetArticleColumnAll()
		{
			//构造查询字符串
            string sql = @"Select ArticleColumn_ID ,ArticleColumn_Name , ArticleColumn_Description ,ArticleColumn_ResponsibleEditorID, UserInfo_RealName From ArticleColumn, UserInfo Where UserInfo_ID = ArticleColumn_ResponsibleEditorID";
			//连接数据库
			DBVisit.ObjDBAccess.CommandStr = sql;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集
			ds.Tables[0].TableName = "Message";

			return ds.Tables[0];		//返回稿件栏目结果集
        }
        #region Rosy
        /// <summary>
        /// 按照文章栏目编号查找对应的责任编辑编号
        /// </summary>
        /// <param name="columnID">文章栏目编号</param>
        /// <returns>责任编辑编号</returns>
        public static int GetAuthorIDByArticleColumnID(int columnID)
        {
            string sql = @"Select ArticleColumn_ResponsibleEditorID From ArticleColumn Where ArticleColumn_ID = @ArticleColumn_ID";
			//连接数据库
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
