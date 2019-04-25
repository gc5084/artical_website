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
    /// ϵͳ��Ϣ���ݷ�����
    /// </summary>
    public class MessageService
	{
		#region �ǲ�ѯ����
		/// <summary>
		/// ����ϵͳ��Ϣ
		/// </summary>
		/// <param name="msg">��Ϣʵ�������</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int UpdateMessage(Message message)
		{
			//�����ѯ�ַ���
			string sql=@"Update Message	Set 
					[Message_Type]=@MsgType , [Message_SenderID]=@MsgSenderID , [Message_ReceiverID]=@MsgReceiverID ,
					[Message_Content]=@MsgContent , [Message_Time]=@MsgTime , [Message_Flag]=@MsgFlag , 
					[Message_Remark]=@MsgRemark Where [Message_ID]=@MsgID";
			DBVisit.ObjDBAccess.CommandStr = sql;	//����ѯ�ַ������������ַ���

			//�������������в�ѯ����
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgID", SqlDbType.Int).Value = message.Id;

			DBVisit.ObjDBAccess.CmdParas.Add("@MsgType", SqlDbType.VarChar, 20).Value = message.Type;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgSenderID", SqlDbType.Int).Value = message.SenderId;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgReceiverID", SqlDbType.Int).Value = message.ReceiverID;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgContent", SqlDbType.VarChar, 1000).Value = message.Content;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgTime", SqlDbType.DateTime).Value = message.Time;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgFlag", SqlDbType.Bit).Value = message.Flag;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgRemark", SqlDbType.VarChar, 200).Value = message.Remark;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�ѯ�ַ�������������Ӧ����
		}

		/// <summary>
		/// ����Ϣ���в���һ���µ���Ϣ
		/// </summary>
		/// <param name="msg">��Ϣʵ�������</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int InsertMessage(Message message)
		{
			//�����ѯ�ַ���
			string sql = @"Insert Into Message
					([Message_Type] , [Message_SenderID] , [Message_ReceiverID] , [Message_Content] ,
					[Message_Time] , [Message_Flag] , [Message_Remark]) 
					Values(@MsgType , @MsgSenderID , @MsgReceiverID ,
					@MsgContent , @MsgTime , @MsgFlag , @MsgRemark)";
			DBVisit.ObjDBAccess.CommandStr = sql;	//����ѯ�ַ������������ַ���

			//�������������в�ѯ����
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgType", SqlDbType.VarChar, 20).Value = message.Type;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgSenderID", SqlDbType.Int).Value = message.SenderId;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgReceiverID", SqlDbType.Int).Value = message.ReceiverID;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgContent", SqlDbType.VarChar, 1000).Value = message.Content;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgTime", SqlDbType.DateTime).Value = message.Time;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgFlag", SqlDbType.Bit).Value = message.Flag;
			DBVisit.ObjDBAccess.CmdParas.Add("@MsgRemark", SqlDbType.VarChar, 200).Value = message.Remark;

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�ѯ�ַ�������������Ӧ����
		}

		/// <summary>
		/// ɾ��һ����Ϣ
		/// </summary>
		/// <param name="msgId">��Ϣ��ID��</param>
		/// <returns>��Ӧ��������ȷִ�з���1�����򷵻�0��</returns>
		public static int DeleteMessage(int msgId) 
		{
			string sql = "Delete Message Where [Message_ID]=@MsgID";	//�����ѯ�ַ���
			DBVisit.ObjDBAccess.CommandStr = sql;				//����ѯ�ַ������������ַ���

			DBVisit.ObjDBAccess.CmdParas.Add("@MsgID", SqlDbType.Int).Value = msgId;//�������������в�ѯ����

			return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();	//ִ�в�ѯ�ַ�������������Ӧ����
		}
		#endregion

		#region ��ѯ����
		/// <summary>
		/// ����Id���ص�����Ϣ����
		/// </summary>
		/// <param name="msgId">��ϢId</param>
		/// <returns>��Ϣ����</returns>
		public static Message GetMessageById(int msgId)
		{
			string sql = @"Select [Message_ID] , [Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] 
					From Message where [Message_ID] = @id";								//�����ѯ�ַ���
			Message msg = new Message();                                        //ʵ������Ϣ����

			//�������ݿ�
			DBVisit.ObjDBAccess.CommandStr = sql;
			DBVisit.ObjDBAccess.CmdParas.Add("@id", SqlDbType.Int).Value = msgId;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����

			msg.Id = int.Parse(ds.Tables[0].Rows[0]["Message_ID"].ToString());
			msg.Type = ds.Tables[0].Rows[0]["Message_Type"].ToString();
			msg.SenderId = int.Parse(ds.Tables[0].Rows[0]["Message_SenderID"].ToString());
			msg.ReceiverID = int.Parse(ds.Tables[0].Rows[0]["Message_ReceiverID"].ToString());
			msg.Content = ds.Tables[0].Rows[0]["Message_Content"].ToString();
			msg.Time = DateTime.Parse(ds.Tables[0].Rows[0]["Message_Time"].ToString());
			msg.Flag = bool.Parse(ds.Tables[0].Rows[0]["Message_Flag"].ToString());
			msg.Remark = ds.Tables[0].Rows[0]["Message_Remark"].ToString();

			return msg;				//������Ϣ�����
		}

		/// <summary>
		/// �������е���Ϣ����
		/// </summary>
		/// <returns>��Ϣ����DataTable</returns>
		public static DataTable GetFieldAll()
		{
			//�����ѯ�ַ���
			string sql = @"Select [Message_ID] , [Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message";
			//�������ݿ�
			DBVisit.ObjDBAccess.CommandStr = sql;

			DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����
			ds.Tables[0].TableName = "Message";

			return ds.Tables[0];		//������Ϣ�����
        }

        /// <summary>
        /// �������е���Ϣ����
        /// </summary>
        /// <returns>��Ϣ����DataTable</returns>
        public static DataTable GetFieldAllBySenderId(int id)
        {
            //�����ѯ�ַ���
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_SenderID]=@SenderID";
            //�������ݿ�
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add(new SqlParameter("SenderID", id));
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//������Ϣ�����
        }

        /// <summary>
        /// �������е���Ϣ����
        /// </summary>
        /// <returns>��Ϣ����DataTable</returns>
        public static DataTable GetFieldAllByReceiverId(int id)
        {
            //�����ѯ�ַ���
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_ReceiverID]=@ReceiverID";
            //�������ݿ�
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add(new SqlParameter("ReceiverID", id));
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//������Ϣ�����
        }
        public static DataTable GetFieldAllByUserId(int id)
        {
            //�����ѯ�ַ���
            string sql = @"Select  [Message_ID] ,[Message_Type] , [Message_SenderID] , [Message_ReceiverID] , 
					[Message_Content] , [Message_Time] , [Message_Flag] , [Message_Remark] From Message Where [Message_ReceiverID]=@UserID or [Message_SenderID]=@UserID";
            //�������ݿ�
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@UserID", SqlDbType.Int).Value = id;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();			//�õ���ѯ�Ľ����
            ds.Tables[0].TableName = "Message";

            return ds.Tables[0];		//������Ϣ�����
        }
		#endregion
	}
}
