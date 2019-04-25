/*==========================================================
 * Class Name   :   ArticleManager
 * Author       :   Rosy
 * Create Time  :   2009.11.19
 * Updata Record:   Rosy
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using System.Data;
using ContributeOnlineSystem.DAL;

namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 稿件信息管理
    /// </summary>
    public class ArticleManager
    {
        /// <summary>
        /// 插入新稿件
        /// </summary>
        /// <param name="article">要插入的文章信息</param>
        /// <returns></returns>
        public static int InsertNewArticle(Article article)
        {
            return ArticleService.InsertArticleInfo(article);
        }

        /// <summary>
        /// 禁止稿件
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool DorbidArticle(int articleId)
        {
            return false;
        }

        #region Rosy
        /// <summary>
        /// 获取所有稿件类型
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleTypeList()
        {
            return ArticleTypeService.GetAllArticleTypes();
        }
        /// <summary>
        /// 获取所有稿件栏目
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleColumnList()
        {
            return ArticleColumnService.GetArticleColumnAll();
        }
        /// <summary>
        /// 查询审理中的稿件
        /// </summary>
        /// <param name="userID">作者编号</param>
        /// <returns></returns>
        public static DataTable GetWorkArticleInfoByUserID(int userID)
        {
            return ArticleService.GetWorkArticleInfoByUserID(userID);
        }
        /// <summary>
        /// 根据文章作者和状态获取文章信息
        /// </summary>
        /// <param name="userID">作者编号</param>
        /// <param name="articleState">要获取的状态编号</param>
        /// <returns>查询结果</returns>
        public static DataTable GetArticleInfoByUserIDAndArticleState(int userID, int articleState)
        {
            return ArticleService.GetArticleInfoByUserIDAndArticleState(userID, articleState);
        }
        /// <summary>
        /// 根据编号获取文章信息
        /// </summary>
        /// <param name="ArticleId">文章编号</param>
        /// <returns>要查询的文章信息(不存在返回null)</returns>
        public static Article GetArticleInfoById(int articleId)
        {
            return ArticleService.GetArticleInfoById(articleId);
        }
        /// <summary>
        /// 修改稿件信息
        /// </summary>
        /// <param name="updateArticle">要修改的稿件信息</param>
        /// <returns>操作结果</returns>
        public static int UpdateArticleInfo(Article updateArticle)
        {
            return ArticleService.UpdateArticleInfo(updateArticle);
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Blue
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllArticleInfo()
        {
            return ArticleService.GetAllArticleInfoAsDT();
        }

      

        /// <summary>
        /// 根据评审者查找文章
        /// </summary>
        /// <param name="SendID">评审者编号</param>
        /// <returns></returns>
        public static DataTable GetArticleByAessSendID(int SendID)
        {
            return ArticleService.GetArticleByAessSendID(SendID);
        }

        /// <summary>
        /// 返回未处理稿件
        /// </summary>
        /// <param name="strCondition">不同的条件字符串</param>
        /// <returns></returns>
        public static DataTable GetArticleForUnfinsh(string strtab,string strCondition)
        {
            return ArticleService.GetArticleForUnfinsh(strtab,strCondition);
        }


        /// <summary>
        /// 根据编号删除文章
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <returns></returns>
        public static int DeleteArticleByID(int ArticleID)
        {
            return ArticleService.DeleteArticleByID(ArticleID);
        }


        /// <summary>
        /// 根据文章状态返回文章
        /// </summary>
        /// <param name="ArticleSate"></param>
        /// <returns></returns>
        public static DataTable GetArticleInfoByArticleState(int ArticleSate)
        {
            return ArticleService.GetArticleInfoByArticleState(ArticleSate);
        }

        #endregion 
    }
}
