/*==========================================================
 * Class Name   :   AssessOpinionManager
 * Author       :   LiangYi
 * Create Time  :   2009.11.19
 * Updata Record:   Rosy
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL;
using System.Data;

namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 评审信息管理
    /// </summary>
    public class AssessOpinionManager
    {
        #region 查询操作

        /// <summary>
        /// 根据id查找评审信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static AssessOpinion GetAssessOpinionById(int id)
        {
            return AssessOpinionService.GetAssessOpinionById(id);
        }

        /// <summary>
        /// 返回评审信息列表
        /// </summary>
        /// <returns></returns>
        public static List<AssessOpinion> GetAssessOpinionAll()
        {
            return AssessOpinionService.GetAllAssessOpinion();
        }
        #region Rosy
        /// <summary>
        /// 获取文章信息（按照评审情况）
        /// </summary>
        /// <param name="assessStateId">稿件状态编号</param>
        /// <param name="userID">评审者编号</param>
        /// <param name="cmdStr">条件信息（SQl语句）</param>
        /// <returns>查询结果</returns>
        public static DataTable GetArticleInfoByAssessOpinionInfo(int assessStateId, int userID, string cmdStr)
        {
            return AssessOpinionService.GetArticleInfoByAssessOpinionInfo(assessStateId, userID, cmdStr);
        }
        /// <summary>
        /// 获取评审信息编号
        /// </summary>
        /// <param name="articleID">稿件状态</param>
        /// <param name="senderID">发送者状态</param>
        /// <param name="assessStateID">评审状态</param>
        /// <returns>查询结果</returns>
        public static DataTable GetAssessOpinionInfo(int articleID, int senderID, int assessStateID, int articleStID)
        {
            return AssessOpinionService.GetAssessOpinionInfo(articleID, senderID, assessStateID, articleStID);
        }
        #endregion
        #endregion

        #region 非查询操作

        /// <summary>
        /// 删除评审信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteAssessOpinion(int id)
        {
            return AssessOpinionService.DeleteAssessOptionById(id);
        }

        /// <summary>
        /// 插入新评审信息
        /// </summary>
        /// <param name="assessOpinion"></param>
        /// <returns></returns>
        public static int InsertAssessOpinion(AssessOpinion assessOpinion)
        {
            return AssessOpinionService.AddAssessOption(assessOpinion);
        }

        /// <summary>
        /// 更新评审信息
        /// </summary>
        /// <param name="assessOpinion"></param>
        /// <returns></returns>
        public static int UpdateAssessOpinion(AssessOpinion assessOpinion)
        {
            return AssessOpinionService.UpdateAssessOption(assessOpinion);
        }

        #endregion

        #region Blue

        /// <summary>
        /// 根据文章编号查出关于这个文章的所有评论
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static DataTable GetAssessByArticleID(int ArticleID)
        {
            return AssessOpinionService.GetAssessByArticleID(ArticleID);
        }


        /// <summary>
        /// 根据文章号和评论者返回评审
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <param name="SendID"></param>
        /// <returns></returns>
        public static DataTable GetAssessByArticleIDAndSendID(int ArticleID, int SendID)
        {
            return AssessOpinionService.GetAssessByArticleIDAndSendID(ArticleID,SendID);
        }
        #endregion 
    }
}
