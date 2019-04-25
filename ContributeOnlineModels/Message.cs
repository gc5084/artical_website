/*==========================================================
 * Class Name   :   Message
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
    /// ��Ϣʵ����
    /// </summary>
    [Serializable]
    public class Message
    {
        #region �ֶ�

        /// <summary>
        /// ��Ϣ���
        /// </summary>
        private int id;

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        private string type;

        /// <summary>
        /// �����߱��
        /// </summary>
        private int senderId;

        /// <summary>
        /// ������
        /// </summary>
        private int receiverID;

        /// <summary>
        /// ��Ϣ����
        /// </summary>
        private string content;

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime time;

		/// <summary>
		/// �Ѷ����
		/// </summary>
		private bool flag;

        /// <summary>
        /// ��ע
        /// </summary>
        private string remark;


        #endregion

        #region ����

        /// <summary>
        /// ��ȡ��������Ϣ���
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// ��ȡ��������Ϣ����
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// ��ȡ�����÷����߱��
        /// </summary>
        public int SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        /// <summary>
        /// ��ȡ�����ý�����
        /// </summary>
        public int ReceiverID
        {
            get { return receiverID; }
            set { receiverID = value; }
        }

        /// <summary>
        /// ��ȡ��������Ϣ����
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// ��ȡ�����÷���ʱ��
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

		/// <summary>
		/// ��ȡ�������Ѷ����
		/// </summary>
		public bool Flag
		{
			get { return flag; }
			set { flag = value; }
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