/*==========================================================
 * Class Name   :   UserAuthor
 * Author       :   LiangYi
 * Create Time  :   2009.11.15
 * Updata Record:   
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 作者信息类
    /// </summary>
    public class UserAuthor : GeneralUser
    {
        #region 字段

        /// <summary>
        /// 作者类型名称
        /// </summary>
        private string typeName;

        #endregion

        #region 属性

        /// <summary>
        ///  修改或设置作者类型名称
        /// </summary>
        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        #endregion
    }
}
