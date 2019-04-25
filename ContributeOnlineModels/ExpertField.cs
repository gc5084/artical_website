/*==========================================================
 * Class Name   :   ExpertField
 * Author       :   ��С��
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
    /// ר�������
    /// </summary>
    [Serializable]
    public class ExpertField
    {
        #region �ֶ�

        /// <summary>
        /// ר��������
        /// </summary>
        private int id;

        /// <summary>
        /// ר�ұ��
        /// </summary>
        private int expertId;

        /// <summary>
        /// ������
        /// </summary>
        private int fieldId;

        /// <summary>
        /// �Ƿ��Զ���
        /// </summary>
        private bool isDefine;

        /// <summary>
        /// �Զ�������
        /// </summary>
        private string defineName;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ������ר��������
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// ��ȡ������ר�ұ��
        /// </summary>
        public int ExpertId
        {
            get { return this.expertId; }
            set { this.expertId = value; }
        }

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        public int FieldId
        {
            get { return this.fieldId; }
            set { this.fieldId = value; }
        }

        /// <summary>
        /// ��ȡ�������Ƿ��Զ���
        /// </summary>
        public bool IsDefine
        {
            get { return this.isDefine; }
            set { this.isDefine = value; }
        }

        /// <summary>
        /// ��ȡ�������Զ�������
        /// </summary>
        public string DefineName
        {
            get { return this.defineName; }
            set { this.defineName = value; }
        }

        #endregion

    }
}
