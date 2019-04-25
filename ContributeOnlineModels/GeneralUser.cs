/*==========================================================
 * Class Name   :   GeneralUser
 * Author       :   LiangYi
 * Create Time  :   2009.10.30
 * Updata Record:   2009.11.23
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
	/// <summary>
	/// 用户信息类
	/// </summary>
    [Serializable]
    public class GeneralUser
    {
        #region 字段

        /// <summary>
        /// 用户编号
        /// </summary>
        private int id; 

        /// <summary>
        /// 角色编号
        /// </summary>
        private Role roleInfo = new Role();

        /// <summary>
        /// 用户名称
        /// </summary>
        private string name;

        /// <summary>
        /// 用户密码
        /// </summary>
        private string pwd;

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime createTime;

        /// <summary>
        /// 真实姓名
        /// </summary>
        private string realName;

        /// <summary>
        /// 性别
        /// </summary>
        private bool sex;

        /// <summary>
        /// 生日
        /// </summary>
        private DateTime birthday;

        /// <summary>
        /// 联系电话
        /// </summary>
        private string tel;

        /// <summary>
        /// 电子邮件
        /// </summary>
        private string email;

        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置用户编号
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// 获取或设置角色编号
        /// </summary>
        public Role RoleInfo
        {
            get { return roleInfo; }
            set { roleInfo = value; }
        }

        /// <summary>
        /// 获取或设置用户名称
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 获取或设置密码
        /// </summary>
        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }

        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get { return createTime; }
            set { createTime = value; }
        }

        /// <summary>
        /// 获取或设置真实姓名
        /// </summary>
        public string RealName
        {
            get { return realName; }
            set { realName = value; }
        }

        /// <summary>
        /// 获取或设置性别
        /// </summary>
        public bool Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        /// <summary>
        /// 获取或设置生日
        /// </summary>
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        /// <summary>
        /// 获取或设置电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }

        /// <summary>
        /// 获取或设置电子邮件
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        #endregion
    }
}
