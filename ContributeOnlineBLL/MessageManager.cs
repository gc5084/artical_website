/*==========================================================
 * Class Name   :   MessageManager
 * Author       :   LiangYi
 * Create Time  :   2009.11.19
 * Updata Record:   none
 * Remark       :   Update Rosy
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using System.Data;
using ContributeOnlineSystem.DAL;

namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 消息信息管理
    /// </summary>
    public class MessageManager
    {
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static int SendMessage(Message msg)
        {
            return MessageService.InsertMessage(msg);
        }

        /// <summary>
        /// 根据消息Id删除消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteMessageById(int id)
        {
            return MessageService.DeleteMessage(id);
        }

        /// <summary>
        /// 根据消息接收者id查找消息列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetMessageByReceiverId(int receiverId)
        {
            return MessageService.GetFieldAllByReceiverId(receiverId);
        }

        /// <summary>
        /// 根据消息发送者id查找消息列表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetMessageBySenderId(int senderId)
        {
            return MessageService.GetFieldAllBySenderId(senderId);
        }

        #region Rosy
        /// <summary>
        /// 获取已读信息
        /// </summary>
        /// <param name="userID">用户编号</param>
        /// <param name="isRead">是否已读标志</param>
        /// <returns></returns>
        public static DataTable GetReadMessage(int userID, bool isRead)
        {
            DataTable dt = MessageService.GetFieldAllByReceiverId(userID);  //获取该用户所有的接受信息
            //过滤信息
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                bool temp = Convert.ToBoolean(dt.Rows[i]["Message_Flag"]);
                if (dt.Rows[i]["Message_Remark"].ToString().Trim() != userID.ToString() || Convert.ToBoolean(dt.Rows[i]["Message_Flag"]) != isRead)
                {
                    dt.Rows.Remove(dt.Rows[i]);     //删除该行（清除不属于该用户的消息）
                    i--;
                    continue;
                }
            }
            return dt;
        }
        /// <summary>
        /// 获取所有消息
        /// </summary>
        /// <param name="userID">消息编号</param>
        /// <returns></returns>
        public static DataTable GetAllMessageById(int userID)
        {
            DataTable dt = MessageService.GetFieldAllByUserId(userID);  //获取该用户所有的接受信息
            //过滤信息
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Message_Remark"].ToString().Trim() != userID.ToString())
                {
                    dt.Rows.Remove(dt.Rows[i]);     //删除该行（清除不属于该用户的消息）
                    i--;
                    continue;
                }
            }
            return dt;
        }
        /// <summary>
        /// 获取发送者是当前用户的信息
        /// </summary>
        /// <param name="userID">当前用户编号</param>
        /// <returns></returns>
        public static DataTable GetSenderMessage(int userID)
        {
            DataTable dt = MessageService.GetFieldAllBySenderId(userID);  //获取该用户所有的接受信息
            //过滤信息
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Message_Remark"].ToString().Trim() != userID.ToString())
                {
                    dt.Rows.Remove(dt.Rows[i]);     //删除该行（清除不属于该用户的消息）
                    i--;
                    continue;
                }
            }
            return dt;
        }
        /// <summary>
		/// 根据Id返回单个消息对像
		/// </summary>
		/// <param name="msgId">消息Id</param>
		/// <returns>消息对像</returns>
        public static Message GetMessageById(int msgId)
        {
            return MessageService.GetMessageById(msgId);
        }
        #endregion Rosy
    }
}
