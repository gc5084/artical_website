/*==========================================================
 * Class Name   :   ExpertField
 * Author       :   Blue
 * Create Time  :   2010.03.23
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 专家领域表
    /// </summary>
    [Serializable]
    public class ExpertArticle
    {
        #region 字段

        /// <summary>
        /// 稿件编号
        /// </summary>
        private int articleId;

        /// <summary>
        /// 专家编号
        /// </summary>
        private int expertId;

        #endregion

        #region 属性

        /// <summary>
        /// 稿件编号
        /// </summary>
        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        /// <summary>
        /// 专家编号
        /// </summary>
        public int ExpertId
        {
            get { return expertId; }
            set { expertId = value; }
        }
        #endregion

    }
}
