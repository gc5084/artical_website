/*==========================================================
 * Class Name   :   AssessOpinion
 * Author       :   Sun
 * Create Time  :   2009.11.05
 * Updata Record:   2009.11.08
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    [Serializable]
    /// <summary>
    /// 评审结果类
    /// </summary>
    public class AssessResult
    {
        #region 字段
        /// <summary>
        /// 评审结果编号
        /// </summary>
        private int id;

        /// <summary>
        /// 评审结果名称
        /// </summary>
        private string name;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置评审结果编号
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

       /// <summary>
        /// 获取或设置评审结果名称
       /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
    }
}
