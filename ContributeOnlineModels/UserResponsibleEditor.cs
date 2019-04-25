/*==========================================================
 * Class Name   :   UserResponsibleEditor
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
    /// ����ʵ����
    /// </summary>
    [Serializable]
    public class UserResponsibleEditor : GeneralUser
    {
        #region �ֶ�

        /// <summary>
        /// ������Ŀ���
        /// </summary>
        private int columnID;

        /// <summary>
        /// ��ע
        /// </summary>
        private string remark;

        #endregion

        #region ����
        /// <summary>
        /// ��ȡ�����ø�����Ŀ
        /// </summary>
        public int ColumnID
        {
            get { return columnID; }
            set { columnID = value; }
        }

        /// <summary>
        /// ��ȡ�����ñ�ע
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        #endregion
    }
}
