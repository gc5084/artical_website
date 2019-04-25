/*==========================================================
 * Class Name   :   AssessOpinion
 * Author       :   Sun
 * Create Time  :   2009.11.05
 * Updata Record:   2009.11.08
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    [Serializable]
    /// <summary>
    /// ��������
    /// </summary>
    public class AssessResult
    {
        #region �ֶ�
        /// <summary>
        /// ���������
        /// </summary>
        private int id;

        /// <summary>
        /// ����������
        /// </summary>
        private string name;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ���������������
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

       /// <summary>
        /// ��ȡ����������������
       /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
    }
}
