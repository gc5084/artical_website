/*==========================================================
 * Class Name   :   Role
 * Author       :   LiangYi
 * Create Time  :   2009.10.30
 * Updata Record:   2009.11.5
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 角色表
    /// </summary>
    [Serializable]
    public class Role
    {
        #region 字段

        /// <summary>
        /// 角色编号
        /// </summary>
        private int id;

        /// <summary>
        /// 角色名称
        /// </summary>
        private string name;

        /// <summary>
        /// 角色导航树节点编号
        /// </summary>
        private int navTreeNodeID;               

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置角色编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 获取或设置角色名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 获取或设置角色导航树节点编号
        /// </summary>
        public int NavTreeNodeID
        {
            get { return navTreeNodeID; }
            set { navTreeNodeID = value; }
        }

        #endregion
    }
}
