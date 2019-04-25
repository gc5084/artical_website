/*==========================================================
 * Class Name   :   ArticleStateService
 * Author       :   Hong
 * Create Time  :   2009.11.7
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ContributeOnlineSystem.Models;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 稿件状态操作类
    /// </summary>
    public class ArticleStateService
    {
        #region 非查询方法

        /// <summary>
        /// 修改稿件状态方法
        /// </summary>
        /// <param name="articleState">稿件状态实体</param>
        /// <returns>受影响的行数</returns>
        public static int UpdataArticele(ArticleState articleState)
        {
            DBHelper.DBVisit.ObjDBAccess.CommandStr = "update ArticleState set ArticleState_Name=@name where ArticleState_ID=@id";
            SqlParameter[] sqlPm = new SqlParameter[]   //参数列表
            {
                new SqlParameter ("@name",articleState.Name ),
                new SqlParameter ("@id",articleState.Id)
            };
            DBHelper.DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);
            return DBHelper.DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //调用DBhelp执行修改
        }

        #endregion

        #region  //查询方法
        /// <summary>
        /// 根据ID找稿件状态
        /// </summary>
        /// <param name="id">要查找的图书状态</param>
        /// <returns>返回找到对象</returns>
        public static ArticleState GetArticleStateById(int id)
        {
            DBHelper.DBVisit.ObjDBAccess.CommandStr = "select ArticleState_Name,ArticleState_ID from ArticleState where ArticleState_ID=@id";  //SQL修改语句
            SqlParameter[] sqlPm = new SqlParameter[]
            {
                new SqlParameter ("@id",id),
            };
            DBHelper.DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);
            DataSet ds = DBHelper.DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            ArticleState articleState = new ArticleState();              //创建一个对象
            articleState.Id = int.Parse(ds.Tables[0].Rows[0]["ArticleState_ID"].ToString());  //给对象的属性赋值
            articleState.Name = ds.Tables[0].Rows[0]["ArticleState_Name"].ToString();
            return articleState;
        }

        /// <summary>
        /// 查询所有的稿件状态
        /// </summary>
        /// <returns>返回DataTable</returns>
        public static DataTable GetAllArticleStates()
        {
            DBHelper.DBVisit.ObjDBAccess.CommandStr = "select ArticleState_ID,ArticleState_Name from ArticleState"; //SQL查找语句
            DataTable dt = new DataTable();
            DataSet ds =new DataSet ();
            ds = DBHelper.DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            dt = ds.Tables[0];
            return dt;
        }

        #endregion 
    }
}
