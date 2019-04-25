/*==========================================================
 * Class Name   :   UserExpert
 * Author       :   Rosy
 * Create Time  :   2009.10.30
 * Update Record:   2009.11.5
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// ר��ʵ����
    /// </summary>
    [Serializable]
    public class UserExpert : GeneralUser
    {
        #region �ֶ�

        /// <summary>
        /// ������λ
        /// </summary>
        private string workPlace;

        /// <summary>
        /// ר�Ҽ��
        /// </summary>
        private string intro;

        /// <summary>
        /// ��ע
        /// </summary>
        private string remark;

        #endregion

        #region ����

        /// <summary>
        /// ��ȡ�����ù�����λ
        /// </summary>
        
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }

        /// <summary>
        /// ��ȡ������ר�Ҽ��
        /// </summary>
        
        public string Intro
        {
            get { return intro; }
            set { intro = value; }
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
