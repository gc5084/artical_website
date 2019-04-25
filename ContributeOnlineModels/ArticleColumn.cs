/*==========================================================
 * Class Name   :   ArticleColumn
 * Author       :   and
 * Create Time  :   2009.11.5
 * Updata Record:   liangyi 2009.11.19
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 稿件栏目实体类
    /// </summary>
    [Serializable]
    public class ArticleColumn
    {
        #region 字段

        /// <summary>
        /// 稿件栏目编号
        /// </summary>
        private int id;

        /// <summary>
        /// 杆件栏目名称
        /// </summary>
        private string name;

        /// <summary>
        /// 稿件栏目描述
        /// </summary>
        private string description;

        /// <summary>
        /// 获取或设置责任编辑
        /// </summary>
        private int responsibelUserId;

        /// <summary>
        /// 负责编辑姓名
        /// </summary>
        private string userInfo_Name;

        #endregion

        #region 属性
        /// <summary>
        /// 获取或设置稿件栏目编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 获取或设置责任编辑
        /// </summary>
        public int ResponsibelUserId
        {
            get { return responsibelUserId; }
            set { responsibelUserId = value; }
        }

        /// <summary>
        /// 获取或设置杆件栏目名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 获取或设置稿件栏目描述
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        /// <summary>
        /// 获取或设置负责编辑姓名
        /// </summary>
        public string UserInfo_Name
        {
            get { return userInfo_Name; }
            set { userInfo_Name = value; }
        }

        #endregion
    }
}
