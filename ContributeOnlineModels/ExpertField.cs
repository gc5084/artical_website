/*==========================================================
 * Class Name   :   ExpertField
 * Author       :   张小红
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
    /// 专家领域表
    /// </summary>
    [Serializable]
    public class ExpertField
    {
        #region 字段

        /// <summary>
        /// 专家领域编号
        /// </summary>
        private int id;

        /// <summary>
        /// 专家编号
        /// </summary>
        private int expertId;

        /// <summary>
        /// 领域编号
        /// </summary>
        private int fieldId;

        /// <summary>
        /// 是否自定义
        /// </summary>
        private bool isDefine;

        /// <summary>
        /// 自定义名称
        /// </summary>
        private string defineName;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置专家领域编号
        /// </summary>
        public int ID
        {
            get { return this.id; }
            set { this.id = value; }
        }

        /// <summary>
        /// 获取或设置专家编号
        /// </summary>
        public int ExpertId
        {
            get { return this.expertId; }
            set { this.expertId = value; }
        }

        /// <summary>
        /// 获取或设置领域编号
        /// </summary>
        public int FieldId
        {
            get { return this.fieldId; }
            set { this.fieldId = value; }
        }

        /// <summary>
        /// 获取或设置是否自定义
        /// </summary>
        public bool IsDefine
        {
            get { return this.isDefine; }
            set { this.isDefine = value; }
        }

        /// <summary>
        /// 获取或设置自定义名称
        /// </summary>
        public string DefineName
        {
            get { return this.defineName; }
            set { this.defineName = value; }
        }

        #endregion

    }
}
