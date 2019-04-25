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
    /// ר�������
    /// </summary>
    [Serializable]
    public class ExpertArticle
    {
        #region �ֶ�

        /// <summary>
        /// ������
        /// </summary>
        private int articleId;

        /// <summary>
        /// ר�ұ��
        /// </summary>
        private int expertId;

        #endregion

        #region ����

        /// <summary>
        /// ������
        /// </summary>
        public int ArticleId
        {
            get { return articleId; }
            set { articleId = value; }
        }

        /// <summary>
        /// ר�ұ��
        /// </summary>
        public int ExpertId
        {
            get { return expertId; }
            set { expertId = value; }
        }
        #endregion

    }
}
