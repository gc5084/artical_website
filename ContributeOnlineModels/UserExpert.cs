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
    /// 专家实体类
    /// </summary>
    [Serializable]
    public class UserExpert : GeneralUser
    {
        #region 字段

        /// <summary>
        /// 工作单位
        /// </summary>
        private string workPlace;

        /// <summary>
        /// 专家简介
        /// </summary>
        private string intro;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置工作单位
        /// </summary>
        
        public string WorkPlace
        {
            get { return workPlace; }
            set { workPlace = value; }
        }

        /// <summary>
        /// 获取或设置专家简介
        /// </summary>
        
        public string Intro
        {
            get { return intro; }
            set { intro = value; }
        }

        /// <summary>
        /// 获取或设置备注
        /// </summary>
        
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        #endregion


    }
}
