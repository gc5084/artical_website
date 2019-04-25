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
    /// �����Ϣ����
    /// </summary>
    public class ArticleManager
    {
        /// <summary>
        /// �����¸��
        /// </summary>
        /// <param name="article">Ҫ�����������Ϣ</param>
        /// <returns></returns>
        public static int InsertNewArticle(Article article)
        {
            return ArticleService.InsertArticleInfo(article);
        }

        /// <summary>
        /// ��ֹ���
        /// </summary>
        /// <param name="articleId"></param>
        /// <returns></returns>
        public bool DorbidArticle(int articleId)
        {
            return false;
        }

        #region Rosy
        /// <summary>
        /// ��ȡ���и������
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleTypeList()
        {
            return ArticleTypeService.GetAllArticleTypes();
        }
        /// <summary>
        /// ��ȡ���и����Ŀ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetArticleColumnList()
        {
            return ArticleColumnService.GetArticleColumnAll();
        }
        /// <summary>
        /// ��ѯ�����еĸ��
        /// </summary>
        /// <param name="userID">���߱��</param>
        /// <returns></returns>
        public static DataTable GetWorkArticleInfoByUserID(int userID)
        {
            return ArticleService.GetWorkArticleInfoByUserID(userID);
        }
        /// <summary>
        /// �����������ߺ�״̬��ȡ������Ϣ
        /// </summary>
        /// <param name="userID">���߱��</param>
        /// <param name="articleState">Ҫ��ȡ��״̬���</param>
        /// <returns>��ѯ���</returns>
        public static DataTable GetArticleInfoByUserIDAndArticleState(int userID, int articleState)
        {
            return ArticleService.GetArticleInfoByUserIDAndArticleState(userID, articleState);
        }
        /// <summary>
        /// ���ݱ�Ż�ȡ������Ϣ
        /// </summary>
        /// <param name="ArticleId">���±��</param>
        /// <returns>Ҫ��ѯ��������Ϣ(�����ڷ���null)</returns>
        public static Article GetArticleInfoById(int articleId)
        {
            return ArticleService.GetArticleInfoById(articleId);
        }
        /// <summary>
        /// �޸ĸ����Ϣ
        /// </summary>
        /// <param name="updateArticle">Ҫ�޸ĵĸ����Ϣ</param>
        /// <returns>�������</returns>
        public static int UpdateArticleInfo(Article updateArticle)
        {
            return ArticleService.UpdateArticleInfo(updateArticle);
        }
        #endregion

        /////////////////////////////////////////////////////////////////////////////////////////////////////////

        #region Blue
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllArticleInfo()
        {
            return ArticleService.GetAllArticleInfoAsDT();
        }

      

        /// <summary>
        /// ���������߲�������
        /// </summary>
        /// <param name="SendID">�����߱��</param>
        /// <returns></returns>
        public static DataTable GetArticleByAessSendID(int SendID)
        {
            return ArticleService.GetArticleByAessSendID(SendID);
        }

        /// <summary>
        /// ����δ������
        /// </summary>
        /// <param name="strCondition">��ͬ�������ַ���</param>
        /// <returns></returns>
        public static DataTable GetArticleForUnfinsh(string strtab,string strCondition)
        {
            return ArticleService.GetArticleForUnfinsh(strtab,strCondition);
        }


        /// <summary>
        /// ���ݱ��ɾ������
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <returns></returns>
        public static int DeleteArticleByID(int ArticleID)
        {
            return ArticleService.DeleteArticleByID(ArticleID);
        }


        /// <summary>
        /// ��������״̬��������
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
