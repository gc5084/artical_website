/*==========================================================
 * Class Name   :   UserResponsibleEditor
 * Author       :   and
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
    /// 主编实体类
    /// </summary>
    [Serializable]
    public class UserResponsibleEditor : GeneralUser
    {
        #region 字段

        /// <summary>
        /// 负责栏目编号
        /// </summary>
        private int columnID;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;

        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置负责栏目
        /// </summary>
        public int ColumnID
        {
            get { return columnID; }
            set { columnID = value; }
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
