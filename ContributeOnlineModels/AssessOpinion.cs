/*==========================================================
 * Class Name   :   AssessOpinion
 * Author       :   Sun
 * Create Time  :   2009.11.05
 * Updata Record:   Rosy
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{    
    /// <summary>
    /// ������Ϣʵ����
    /// </summary>
    [Serializable]
    public class AssessOpinion
    {

        #region �ֶ�
        /// <summary>
        /// ����������
        /// </summary>
        private int id;

        /// <summary>
        /// ����״̬��Ϣ
        /// </summary>
        private AssessState assessStateInfo = new AssessState() ;

        /// <summary>
        /// �����߱��
        /// </summary>
        private int sendID;


        /// <summary>
        /// ��������Ϣ
        /// </summary>
        private AssessResult assessResultInfo = new AssessResult();

        /// <summary>
        /// �������±��
        /// </summary>
        private int article;

        /// <summary>
        /// ����
        /// </summary>
        private string message;

        /// <summary>
        /// ��ע
        /// </summary>
        private string remark;

        /// <summary>
        /// �����������
        /// </summary>
        private int articleStateID;

        #endregion


        #region ����

        

        /// <summary>
        /// ���û��ȡ����������
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }        

        /// <summary>
        /// ���û��ȡ����״̬��Ϣ
        /// </summary>
        public AssessState AssessStateInfo
        {
            get { return assessStateInfo; }
            set { assessStateInfo = value; }
        }

        /// <summary>
        /// ���û��ȡ�����߱��
        /// </summary>
        public int SendID
        {
            get { return sendID; }
            set { sendID = value; }
        }      

        /// <summary>
        /// ���û��ȡ��������Ϣ
        /// </summary>
        public AssessResult AssessResultInfo
        {
            get { return assessResultInfo; }
            set { assessResultInfo = value; }
        }       

        /// <summary>
        /// ���û��ȡ�������±��
        /// </summary>
        public int Article
        {
            get { return article; }
            set { article = value; }
        }       

        /// <summary>
        /// ���û��ȡ����
        /// </summary>
        public string Message
        {
            get { return message; }
            set { message = value; }
        }       

        /// <summary>
        /// ���û��ȡ��ע
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        /// <summary>
        /// �����������
        /// </summary>
        public int ArticleStateID
        {
            get { return articleStateID; }
            set { articleStateID = value; }
        }

        #endregion
    }
}
