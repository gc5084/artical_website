/*==========================================================
 * Class Name   :   GeneralUser
 * Author       :   LiangYi
 * Create Time  :   2009.10.30
 * Updata Record:   2009.11.23
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
	/// <summary>
	/// �û���Ϣ��
	/// </summary>
    [Serializable]
    public class GeneralUser
    {
        #region �ֶ�

        /// <summary>
        /// �û����
        /// </summary>
        private int id; 

        /// <summary>
        /// ��ɫ���
        /// </summary>
        private Role roleInfo = new Role();

        /// <summary>
        /// �û�����
        /// </summary>
        private string name;

        /// <summary>
        /// �û�����
        /// </summary>
        private string pwd;

        /// <summary>
        /// ����ʱ��
        /// </summary>
        private DateTime createTime;

        /// <summary>
        /// ��ʵ����
        /// </summary>
        private string realName;

        /// <summary>
        /// �Ա�
        /// </summary>
        private bool sex;

        /// <summary>
        /// ����
        /// </summary>
        private DateTime birthday;

        /// <summary>
        /// ��ϵ�绰
        /// </summary>
        private string tel;

        /// <summary>
        /// �����ʼ�
        /// </summary>
        private string email;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ�������û����
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ��ȡ�����ý�ɫ���
        /// </summary>
        public Role RoleInfo
        {
            get { return roleInfo; }
            set { roleInfo = value; }
        }

        /// <summary>
        /// ��ȡ�������û�����
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        /// <summary>
        /// ��ȡ�����ô���ʱ��
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        /// <summary>
        /// ��ȡ��������ʵ����
        /// </summary>
        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        /// <summary>
        /// ��ȡ�������Ա�
        /// </summary>
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// ��ȡ����������
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        /// <summary>
        /// ��ȡ�����õ绰
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// ��ȡ�����õ����ʼ�
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion
    }
}
