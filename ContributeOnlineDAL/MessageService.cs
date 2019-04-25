/*==========================================================
 * Class Name   :   MessageService
 * Author       :   ZhangQi
 * Create Time  :   2009.11.7
 * Updata Record:   2009.11.7
 * Remark       :   Update Rosy
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;
using System.Data.SqlClient;
using ContributeOnlineSystem.Models;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 系统消息数据访问类
    /// </summary>
    public class MessageService
	{
		#region 非查询操作
		/// <summary>
		/// 更新系统消息
		/// </summary>
		/// <param name="msg">消息实体类对像</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int UpdateMessage(Message message)
		{
			//构造查询字符串
			string sql=@"Update Message	Set 
					[Message_Type]=@MsgType , [Message_SenderID]=@MsgSenderID , [Message_ReceiverID]=@MsgReceiverID ,
					[Message_Content]=@MsgContent , [Message_Time]=@MsgTime , [Message_Flag]=@MsgFlag , 
					[Message_Remark]=@MsgRemark Where [Message_ID]=@MsgID";
			DBVisit.ObjDBAccess.CommandStr = sql;	//将查询字符串赋给命令字符串

			//参数化传递所有查询参数
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgID", SqlDbType.Int).Value = message.Id;

			DBVisit.ObjDBAccess.CmdParas.Add("@MsgType", SqlDbType.VarChar, 20).Value = message.Type;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgSenderID", SqlDbType.Int).Value = message.SenderId;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgReceiverID", SqlDbType.Int).Value = message.ReceiverID;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgContent", SqlDbType.VarChar, 1000).Value = message.Content;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgTime", SqlDbType.DateTime).Value = message.Time;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgFlag", SqlDbType.Bit).Value = message.Flag;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgRemark", SqlDbType.VarChar, 200).Value = message.Remark;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行查询字符串，并返回响应行数
		}

		/// <summary>
		/// 往消息表中插入一条新的消息
		/// </summary>
		/// <param name="msg">消息实体类对像</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int InsertMessage(Message message)
		{
			//构造查询字符串
			string sql = @"Insert Into Message
					([Message_Type] , [Message_SenderID] , [Message_ReceiverID] , [Message_Content] ,
					[Message_Time] , [Message_Flag] , [Message_Remark]) 
					Values(@MsgType , @MsgSenderID , @MsgReceiverID ,
					@MsgContent , @MsgTime , @MsgFlag , @MsgRemark)";
			DBVisit.ObjDBAccess.CommandStr = sql;	//将查询字符串赋给命令字符串

			//参数化传递所有查询参数
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgType", SqlDbType.VarChar, 20).Value = message.Type;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgSenderID", SqlDbType.Int).Value = message.SenderId;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgReceiverID", SqlDbType.Int).Value = message.ReceiverID;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgContent", SqlDbType.VarChar, 1000).Value = message.Content;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgTime", SqlDbType.DateTime).Value = message.Time;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgFlag", SqlDbType.Bit).Value = message.Flag;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgRemark", SqlDbType.VarChar, 200).Value = message.Remark;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行查询字符串，并返回响应行数
		}

		/// <summary>
		/// 删除一条消息
		/// </summary>
		/// <param name="msgId">消息的ID号</param>
		/// <returns>响应行数（正确执行返回1，否则返回0）</returns>
		public static int DeleteMessage(int msgId) 
		{
			string sql = "Delete Message Where [Message_ID]=@MsgID";	//构造查询字符串
			DBVisit.ObjDBAccess.CommandStr = sql;				//将查询字符串赋给命令字符串

			DBVisit.ObjDBAccess.CmdParas.Add("@MsgID", SqlDbType.Int).Value = msgId;//参数化传递所有查询参数

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//执行查询字符串，并返回响应行数
		}
		#endregion

		#region 查询操作
		/// <summary>
		/// 根据Id返回单个消息对像
		/// </summary>
		/// <param name="msgId">消息Id</param>
		/// <returns>消息对像</returns>
		public static Message GetMessageById(int msgId)
		{
			string sql = @"Select [Message_ID] , [Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] 
					From Message where [Message_ID] = @id";								//构造查询字符串
			Message msg = new Message();                                        //实例化消息对象

			//连接数据库
			DBVisit.ObjDBAccess.CommandStr = sql;
			DBVisit.ObjDBAccess.CmdParas.Add("@id", SqlDbType.Int).Value = msgId;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集

			msg.Id = int.Parse(ds.Tables[0].Rows[0]["Message_ID"].ToString());
			msg.Type = ds.Tables[0].Rows[0]["Message_Type"].ToString();
			msg.SenderId = int.Parse(ds.Tables[0].Rows[0]["Message_SenderID"].ToString());
			msg.ReceiverID = int.Parse(ds.Tables[0].Rows[0]["Message_ReceiverID"].ToString());
			msg.Content = ds.Tables[0].Rows[0]["Message_Content"].ToString();
			msg.Time = DateTime.Parse(ds.Tables[0].Rows[0]["Message_Time"].ToString());
			msg.Flag = bool.Parse(ds.Tables[0].Rows[0]["Message_Flag"].ToString());
			msg.Remark = ds.Tables[0].Rows[0]["Message_Remark"].ToString();

			return msg;				//返回消息类对像
		}

		/// <summary>
		/// 返回所有的消息对象
		/// </summary>
		/// <returns>消息对象DataTable</returns>
		public static DataTable GetFieldAll()
		{
			//构造查询字符串
			string sql = @"Select [Message_ID] , [Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message";
			//连接数据库
			DBVisit.ObjDBAccess.CommandStr = sql;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集
			ds.Tables[0].TableName = "Message";

			return ds.Tables[0];		//返回消息结果集
        }

        /// <summary>
        /// 返回所有的消息对象
        /// </summary>
        /// <returns>消息对象DataTable</returns>
        public static DataTable GetFieldAllBySenderId(int id)
        {
            //构造查询字符串
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_SenderID]=@SenderID";
            //连接数据库
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add(new SqlParameter("SenderID", id));
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//返回消息结果集
        }

        /// <summary>
        /// 返回所有的消息对象
        /// </summary>
        /// <returns>消息对象DataTable</returns>
        public static DataTable GetFieldAllByReceiverId(int id)
        {
            //构造查询字符串
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_ReceiverID]=@ReceiverID";
            //连接数据库
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add(new SqlParameter("ReceiverID", id));
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//返回消息结果集
        }
        public static DataTable GetFieldAllByUserId(int id)
        {
            //构造查询字符串
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_ReceiverID]=@UserID or [Message_SenderID]=@UserID";
            //连接数据库
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserID", SqlDbType.Int).Value = id;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//得到查询的结果集
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//返回消息结果集
        }
		#endregion
	}
}
