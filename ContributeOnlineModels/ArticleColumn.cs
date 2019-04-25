/*==========================================================
 * Class Name   :   ArticleColumn
 * Author       :   and
 * Create Time  :   2009.11.5
 * Updata Record:   liangyi 2009.11.19
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// �����Ŀʵ����
    /// </summary>
    [Serializable]
    public class ArticleColumn
    {
        #region �ֶ�

        /// <summary>
        /// �����Ŀ���
        /// </summary>
        private int id;

        /// <summary>
        /// �˼���Ŀ����
        /// </summary>
        private string name;

        /// <summary>
        /// �����Ŀ����
        /// </summary>
        private string description;

        /// <summary>
        /// ��ȡ���������α༭
        /// </summary>
        private int responsibelUserId;

        /// <summary>
        /// ����༭����
        /// </summary>
        private string userInfo_Name;

        #endregion

        #region ����
        /// <summary>
        /// ��ȡ�����ø����Ŀ���
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ȡ���������α༭
        /// </summary>
        public int ResponsibelUserId
        {
            get { return responsibelUserId; }
            set { responsibelUserId = value; }
        }

        /// <summary>
        /// ��ȡ�����ø˼���Ŀ����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ��ȡ�����ø����Ŀ����
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// ��ȡ�����ø���༭����
        /// </summary>
        public string UserInfo_Name
        {
            get { return userInfo_Name; }
            set { userInfo_Name = value; }
        }

        #endregion
    }
}
