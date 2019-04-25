/*==========================================================
 * Class Name   :   FieldService
 * Author       :   Blue
 * Create Time  :   2010.03.23
 * Updata Record:   none
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
    public static class ExpertArticleService
    {
        #region 查询方法
        
        /// <summary>
        /// 是否存在指定专家稿件关系
        /// </summary>
        /// <param name="expertArticle"></param>
        /// <returns></returns>
        public static bool IsExistEA(ExpertArticle expertArticle)
        {
            string sql = @"select ArticleExpert_ArticleID, ArticleExpert_ExpertID 
                            from ArticleExpert
                            where ArticleExpert_ArticleID = @ArticleExpert_ArticleID And ArticleExpert_ExpertID = @ArticleExpert_ExpertID";
            //执行
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ArticleID", SqlDbType.Int).Value = expertArticle.ArticleId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ExpertID", SqlDbType.Int).Value = expertArticle.ExpertId;
            bool result = DBVisit.ObjDBAccess.IsExist();

            return result;

        }

        #endregion

        #region 非查询方法

        /// <summary>
        /// 插入一条专家稿件关系
        /// </summary>
        /// <param name="expertArticle"></param>
        /// <returns></returns>
        public static int AddExpertArticle(ExpertArticle expertArticle)
        {
            if(IsExistEA(expertArticle))
            {
                return 2;
            }

            string sql = @"Insert into ArticleExpert(ArticleExpert_ArticleID, ArticleExpert_ExpertID)
                            Values(@ArticleExpert_ArticleID, @ArticleExpert_ExpertID)";

            //连接数据库，执行SQL语句
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ArticleID", SqlDbType.Int).Value = expertArticle.ArticleId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ExpertID", SqlDbType.Int).Value = expertArticle.ExpertId;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion
    }
}
