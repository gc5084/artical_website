/*==========================================================
 * Class Name   :   Message
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
    /// 消息实体类
    /// </summary>
    [Serializable]
    public class Message
    {
        #region 字段

        /// <summary>
        /// 消息编号
        /// </summary>
        private int id;

        /// <summary>
        /// 消息类型
        /// </summary>
        private string type;

        /// <summary>
        /// 发送者编号
        /// </summary>
        private int senderId;

        /// <summary>
        /// 接受者
        /// </summary>
        private int receiverID;

        /// <summary>
        /// 消息内容
        /// </summary>
        private string content;

        /// <summary>
        /// 发送时间
        /// </summary>
        private DateTime time;

		/// <summary>
		/// 已读标记
		/// </summary>
		private bool flag;

        /// <summary>
        /// 备注
        /// </summary>
        private string remark;


        #endregion

        #region 属性

        /// <summary>
        /// 获取或设置消息编号
        /// </summary>
        public int Id
        {
            set { id = value; }
            get { return id; }
        }

        /// <summary>
        /// 获取或设置消息类型
        /// </summary>
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        /// <summary>
        /// 获取或设置发送者编号
        /// </summary>
        public int SenderId
        {
            get { return senderId; }
            set { senderId = value; }
        }

        /// <summary>
        /// 获取或设置接受者
        /// </summary>
        public int ReceiverID
        {
            get { return receiverID; }
            set { receiverID = value; }
        }

        /// <summary>
        /// 获取或设置消息内容
        /// </summary>
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        /// <summary>
        /// 获取或设置发送时间
        /// </summary>
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

		/// <summary>
		/// 获取或设置已读标记
		/// </summary>
		public bool Flag
		{
			get { return flag; }
			set { flag = value; }
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