/*==========================================================
 * Class Name   :   Field
 * Author       :   Rosy
 * Create Time  :   2009.10.30
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
    public class Field
    {
        #region �ֶ�

        /// <summary>
        /// ������
        /// </summary>
        private int id;

        /// <summary>
        /// ��������
        /// </summary>
        private string fieldName;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ������������
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ȡ��������������
        /// </summary>
        public string FieldName
        {
            get { return this.fieldName; }
            set { fieldName = value; }
        }

        #endregion
    }
}
