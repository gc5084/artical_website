/*==========================================================
 * Class Name   :   AssessOpinion
 * Author       :   Sun
 * Create Time  :   2009.11.05
 * Updata Record:   Rosy
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{    
    /// <summary>
    /// 评审信息实体类
    /// </summary>
    [Serializable]
    public class AssessOpinion
    {

        #region 字段
        /// <summary>
        /// 评审意见编号
        /// </summary>
        private int id;

        /// <summary>
        /// 评审状态信息
        /// </summary>
        private AssessState assessStateInfo = new AssessState() ;

        /// <summary>
        /// 评论者编号
        /// </summary>
        private int sendID;


        /// <summary>
        /// 评审结果信息
        /// </summary>
        private AssessResult assessResultInfo = new AssessResult();

        /// <summary>
        /// 评审文章编号
        /// </summary>
        private int article;

        /// <summary>
        /// 评语
        /// </summary>
        private string message;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        /// <summary>
        /// 评审意见批次
        /// </summary>
        private int articleStateID;

        #endregion


        #region 属性

        

        /// <summary>
        /// 设置或获取评审意见编号
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }        

        /// <summary>
        /// 设置或获取评审状态信息
        /// </summary>
        public AssessState AssessStateInfo
        {
            get { return assessStateInfo; }
            set { assessStateInfo = value; }
        }

        /// <summary>
        /// 设置或获取评论者编号
        /// </summary>
        public int SendID
        {
            get { return sendID; }
            set { sendID = value; }
        }      

        /// <summary>
        /// 设置或获取评审结果信息
        /// </summary>
        public AssessResult AssessResultInfo
        {
            get { return assessResultInfo; }
            set { assessResultInfo = value; }
        }       

        /// <summary>
        /// 设置或获取评审文章编号
        /// </summary>
        public int Article
        {
            get { return article; }
            set { article = value; }
        }       

        /// <summary>
        /// 设置或获取评语
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }       

        /// <summary>
        /// 设置或获取备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// 评审意见批次
        /// </summary>
        public int ArticleStateID
        {
            get { return articleStateID; }
            set { articleStateID = value; }
        }

        #endregion
    }
}
