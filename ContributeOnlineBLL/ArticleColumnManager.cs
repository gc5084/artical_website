/*==========================================================
 * Class Name   :   ArticleColumnManager
 * Author       :   LiangYi
 * Create Time  :   2009.11.19
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.DAL;
using ContributeOnlineSystem.Models;
using System.Data;

namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 稿件栏目管理类
    /// </summary>
    public static class ArticleColumnManager
    {
        #region 查询

        /// <summary>
        /// 根据栏目id查询栏目对象
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public static ArticleColumn GetArticleColumnById(int columnId)
        {
            return ArticleColumnService.GetArticleColumnById(columnId);
        }

        /// <summary>
        /// 查询所有栏目对象，返回DataTable
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleColumnAll()
        {
            return ArticleColumnService.GetArticleColumnAll();
        }
        /// <summary>
        /// 按照文章栏目编号查找对应的责任编辑编号
        /// </summary>
        /// <param name="columnID">文章栏目编号</param>
        /// <returns>责任编辑编号</returns>
        public static int GetAuthorIDByArticleColumnID(int columnID)
        {
            return ArticleColumnService.GetAuthorIDByArticleColumnID(columnID);
        }
        #endregion

        #region 非查询

        /// <summary>
        /// 根据id删除稿件信息
        /// </summary>
        /// <param name="columnId"></param>
        /// <returns></returns>
        public static int DeleteArticleColumn(int columnId)
        {
            return ArticleColumnService.DeleteArticleColumn(columnId);
        }

        /// <summary>
        /// 插入新稿件栏目信息
        /// </summary>
        /// <param name="articleColumn"></param>
        /// <returns></returns>
        public static int InsertArticleColumn(ArticleColumn articleColumn)
        {
            return ArticleColumnService.InsertArticleColumn(articleColumn);
        }

        /// <summary>
        /// 更新稿件栏目信息
        /// </summary>
        /// <param name="articleColumn"></param>
        /// <returns></returns>
        public static int UpdateArticleColumn(ArticleColumn articleColumn)
        {
            return ArticleColumnService.UpdateArticleColumn(articleColumn);
        }

        #endregion

    }
}
