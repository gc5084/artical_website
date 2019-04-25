/*==========================================================
 * Class Name   :   Field
 * Author       :   Rosy
 * Create Time  :   2009.10.30
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 领域实体类
    /// </summary>
    [Serializable]
    public class Field
    {
        #region 字段

        /// <summary>
        /// 领域编号
        /// </summary>
        private int id;

        /// <summary>
        /// 领域名称
        /// </summary>
        private string fieldName;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置领域编号
        /// </summary>
        public int Id
        {
            get { return this.id; }
            set { id = value; }
        }

        /// <summary>
        /// 获取或设置领域名称
        /// </summary>
        public string FieldName
        {
            get { return this.fieldName; }
            set { fieldName = value; }
        }

        #endregion
    }
}
