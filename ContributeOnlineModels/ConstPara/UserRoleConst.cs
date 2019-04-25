/*==========================================================
 * Class Name   :   UserRole
 * Author       :   Zhang
 * Create Time  :   2009.11.15
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models.ConstPara
{
    /// <summary>
    /// 角色类型
    /// </summary>
    public static class UserRoleConst
    {
        /// <summary>
        /// 系统管理员
        /// </summary>
        public const int Administrator = 0;
        /// <summary>
        /// 主编
        /// </summary>
        public const int ChiefEditor = 1;
        /// <summary>
        /// 副主编
        /// </summary>
        public const int SubEditor = 2;
        /// <summary>
        /// 责任编辑
        /// </summary>
        public const int ResponsibleEditor = 3;
        /// <summary>
        /// 排版编辑
        /// </summary>
        public const int LayoutEditor = 4;
        /// <summary>
        /// 专家
        /// </summary>
        public const int Expert = 5;
        /// <summary>
        /// 作者
        /// </summary>
        public const int Author = 6;
    }
}
