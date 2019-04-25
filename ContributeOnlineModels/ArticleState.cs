/*==========================================================
 * Class Name   :   ArticleState
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
    /// 稿件种类表
    /// </summary>
    [Serializable]
    public class ArticleState
    {
        #region 字段
        /// <summary>
        /// 稿件种类编号
        /// </summary>
        private int id;

        /// <summary>
        /// 稿件种类名称
        /// </summary>
        private string name;
        #endregion

        #region 属性
        /// <summary>
        /// 稿件种类编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 稿件种类名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
    }
}
