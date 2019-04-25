/*==========================================================
 * Class Name   :   ArticleType
 * Author       :   and
 * Create Time  :   2009.11.5
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// ���״̬��
    /// </summary>
    [Serializable]
    public class ArticleType
    {
        #region �ֶ�

        /// <summary>
        /// ���״̬���
        /// </summary>
        private int id;

        /// <summary>
        /// ���״̬����
        /// </summary>
        private string name;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ�����ø��״̬���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ȡ�����ø��״̬����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        #endregion
    }
}
