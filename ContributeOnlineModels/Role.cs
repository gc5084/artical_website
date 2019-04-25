/*==========================================================
 * Class Name   :   Role
 * Author       :   LiangYi
 * Create Time  :   2009.10.30
 * Updata Record:   2009.11.5
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// ��ɫ��
    /// </summary>
    [Serializable]
    public class Role
    {
        #region �ֶ�

        /// <summary>
        /// ��ɫ���
        /// </summary>
        private int id;

        /// <summary>
        /// ��ɫ����
        /// </summary>
        private string name;

        /// <summary>
        /// ��ɫ�������ڵ���
        /// </summary>
        private int navTreeNodeID;               

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ�����ý�ɫ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ȡ�����ý�ɫ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ��ȡ�����ý�ɫ�������ڵ���
        /// </summary>
        public int NavTreeNodeID
        {
            get { return navTreeNodeID; }
            set { navTreeNodeID = value; }
        }

        #endregion
    }
}
