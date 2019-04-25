/*==========================================================
 * Class Name   :   ArticleStateService
 * Author       :   Hong
 * Create Time  :   2009.11.8
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using ContributeOnlineSystem.Models;

using System.Data.SqlClient;
using System.Data;
using ContributeOnlineSystem.DAL.DBHelper;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// ������Ϣ���ݷ�����
    /// </summary>
    public class AssessOpinionService
    {
        #region ��ѯ����
        /// <summary>
        /// ����ID�����������
        /// </summary>
        /// <param name="id">Ҫ���ҵ��������ID</param>
        /// <returns>�����ҵ��������������</returns>
        public static AssessOpinion GetAssessOpinionById(int id)
        {
            AssessOpinion assessOption = new AssessOpinion();  //ʵ����һ���µĲ�ѯ���
            DBVisit.ObjDBAccess.CommandStr = @"select AssessOpinion_State,AssessOpinion_SendID,
                                               AssessOpinion_Result,AssessOpinion_Article,
                                               AssessOpinion_Message,AssessOpinion_Remark,
                                               AssessOpinion_ArticleStateID
                                               from AssessOpinion where AssessOpinion_ID=@id";
            SqlParameter sqlPm = new SqlParameter("@id", id);
            DBVisit.ObjDBAccess.CmdParas.Add(sqlPm);
            DataSet ds = new DataSet();
            ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();  //����DBhelpִ�в�ѯ���� ����һ��DataSet����
            assessOption.ID = id;  //����Ӧ�����Ը�ֵ
            assessOption.AssessStateInfo = AssessStateService.GetAssessStateById(int.Parse(ds.Tables[0].Rows[0]["AssessOpinion_State"].ToString()));
            assessOption.AssessResultInfo = AssessResultService.GetAssessResultById(int.Parse(ds.Tables[0].Rows[0]["AssessOpinion_Result"].ToString ()));
            assessOption.Article = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_Article"]);
            assessOption.Message = Convert.ToString(ds.Tables[0].Rows[0]["AssessOpinion_Message"]);
            assessOption.Remark = Convert.ToString(ds.Tables[0].Rows[0]["AssessOpinion_Remark"]);
            assessOption.SendID = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_SendID"]);
            assessOption.ArticleStateID = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_ArticleStateID"]);
            return assessOption;  //�����ҵ��Ľ��
        }

        /// <summary>
        /// ��ѯ���е������������List
        /// </summary>
        /// <returns>��������List</returns>
        public static List<AssessOpinion> GetAllAssessOpinion()
        {
            List<AssessOpinion> list = new List<AssessOpinion>();
            DBVisit.ObjDBAccess.CommandStr = @"select AssessOpinion_ID,AssessOpinion_State,AssessOpinion_SendID,
                                                AssessOpinion_Result,AssessOpinion_Article,AssessOpinion_Message,
                                                AssessOpinion_Remark,AssessOpinion_ArticleStateID from AssessOpinion  ";
            DataTable dt = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables [0];
            foreach (DataRow dr in dt.Rows)
            {
                AssessOpinion ass = new AssessOpinion();
                ass.ID = Convert.ToInt32(dr["AssessOpinion_ID"]);
                ass.AssessStateInfo = AssessStateService.GetAssessStateById(Convert.ToInt32(dr["AssessOpinion_State"]));
                ass.AssessResultInfo = AssessResultService.GetAssessResultById(Convert.ToInt32(dr["AssessOpinion_Result"]));
                ass.SendID = Convert.ToInt32(dr["AssessOpinion_SendID"]);
                ass.Article = Convert.ToInt32(dr["AssessOpinion_Article"]);
                ass.Remark = Convert.ToString(dr["AssessOpinion_Remark"]);
                ass.Message = Convert.ToString(dr["AssessOpinion_Message"]);
                ass.ArticleStateID = Convert.ToInt32(dr["AssessOpinion_ArticleStateID"]);
                list.Add(ass);
            }
            return list;
        }

        #region Rosy
        /// <summary>
        /// ��ȡ������Ϣ���������������
        /// </summary>
        /// <param name="assessStateId">���״̬���</param>
        /// <param name="userID">�����߱��</param>
        /// <param name="cmdStr">������Ϣ��SQl��䣩</param>
        /// <returns>��ѯ���</returns>
        public static DataTable GetArticleInfoByAssessOpinionInfo(int assessStateId, int userID, string cmdStr)
        {
            //DBVisit.ObjDBAccess.CommandStr = "proc_GetArticleInfoByUserIDAndArticleTypeList";
            //���ò���
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@AssessOpinion_State", SqlDbType.Int).Value = assessStateId;
            DBVisit.ObjDBAccess.CmdParas.Add("@AssessOpinion_SendID", SqlDbType.Int).Value = userID;
            DBVisit.ObjDBAccess.CmdParas.Add("@StateStr", SqlDbType.VarChar, 200).Value = cmdStr;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteProc("proc_GetArticleInfoByUserIDAndArticleTypeList");
            return ds.Tables[0];
        }
        /// <summary>
        /// ��ȡ������Ϣ���
        /// </summary>
        /// <param name="articleID">������</param>
        /// <param name="senderID">������״̬</param>
        /// <param name="assessStateID">����״̬</param>
        /// <param name="articleStID">��������</param>
        /// <returns>��ѯ���</returns>
        public static DataTable GetAssessOpinionInfo(int articleID, int senderID, int assessStateID, int articleStID)
        {
            DBVisit.ObjDBAccess.CommandStr =
                @"Select AssessOpinion_ID,AssessOpinion_State,AssessOpinion_SendID,
                        AssessOpinion_Result,AssessOpinion_Article,AssessOpinion_Message,
                        AssessOpinion_Remark,AssessOpinion_ArticleStateID
                From AssessOpinion 
                Where AssessOpinion_Article=@ArticleID And  AssessOpinion_SendID = @SendID
                    And AssessOpinion_State = @StateID And AssessOpinion_ArticleStateID = @ArticleStID";
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleID", SqlDbType.Int).Value = articleID;
            DBVisit.ObjDBAccess.CmdParas.Add("@SendID", SqlDbType.Int).Value = senderID;
            DBVisit.ObjDBAccess.CmdParas.Add("@StateID", SqlDbType.Int).Value = assessStateID;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleStID", SqlDbType.Int).Value = articleStID;
            DataTable resule = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            return resule;
        }
        #endregion

        #region Blue
        /// <summary>
        /// �������±�Ų������������µ���������
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public static DataTable GetAssessByArticleID(int ArticleID)
        {
            string strSelect = @"select AssessOpinion_ID,AssessOpinion_State,AssessOpinion_SendID,
                                                AssessOpinion_Result,AssessOpinion_Article,AssessOpinion_Message,
                                                AssessOpinion_Remark,AssessOpinion_ArticleStateID,
                                                AssessResult_Name,ArticleState_Name,UserInfo_RealName
                                        from AssessOpinion,AssessResult,ArticleState,UserInfo
                                        where ArticleState_ID = AssessOpinion_ArticleStateID And 
                                             AssessResult_ID = AssessOpinion_Result And  
                                             UserInfo_ID = AssessOpinion_SendID And
                                            AssessOpinion_Article = @ArticleID";

            DBVisit.ObjDBAccess.CommandStr = strSelect;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;

            DataTable result =  DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            return result;

        }


        /// <summary>
        /// �������ºź������߷�������
        /// </summary>
        /// <param name="ArticleID"></param>
        /// <param name="SendID"></param>
        /// <returns></returns>
        public static DataTable GetAssessByArticleIDAndSendID(int ArticleID, int SendID)
        {
            string strSelect = @"select AssessOpinion_ID,AssessOpinion_State,AssessOpinion_SendID,
                                                AssessOpinion_Result,AssessOpinion_Article,AssessOpinion_Message,
                                                AssessOpinion_Remark,AssessOpinion_ArticleStateID,
                                                AssessResult_Name,ArticleState_Name,UserInfo_RealName
                                        from AssessOpinion,AssessResult,ArticleState,UserInfo
                                        where ArticleState_ID = AssessOpinion_ArticleStateID And 
                                             AssessResult_ID = AssessOpinion_Result And  
                                             UserInfo_ID = AssessOpinion_SendID And
                                            AssessOpinion_Article = @ArticleID And
                                            AssessOpinion_SendID = @SendID";

            DBVisit.ObjDBAccess.CommandStr = strSelect;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
            DBVisit.ObjDBAccess.CmdParas.Add("@SendID", SqlDbType.Int).Value = SendID;

            DataTable result = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand().Tables[0];
            return result;
        }



          #endregion

        #endregion

        #region �ǲ�ѯ����

        /// <summary>
        /// �޸����������
        /// </summary>
        /// <param name="assessOption">Ҫ�޸ĵ��¶���</param>
        /// <returns></returns>
        public static int  UpdateAssessOption(AssessOpinion assessOption)
        {
            DBVisit.ObjDBAccess.CommandStr = @"update AssessOpinion set AssessOpinion_State=@state,
                                               AssessOpinion_SendID=@sendId,AssessOpinion_Result=@result,
                                               AssessOpinion_Article=@article,AssessOpinion_Message=@message,
                                               AssessOpinion_Remark=@remark where AssessOpinion_ID=@id";  //Ҫִ�е�SQL���
            SqlParameter[] sqlPm = new SqlParameter[]    //ʵ����һ�������б�
            {
                new SqlParameter ("@state",assessOption.AssessStateInfo.ID),
                new SqlParameter ("@sendId",assessOption.SendID),
                new SqlParameter ("@result",assessOption.AssessResultInfo.ID),
                new SqlParameter ("@article",assessOption.Article),
                new SqlParameter ("@message",assessOption.Message),
                new SqlParameter ("@remark ",assessOption.Remark),
                new SqlParameter ("@id",assessOption.ID)
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);   //���絽SqlCommand�Ĳ����б���ȥ
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //ִ��SQL���
        }
        /// <summary>
        /// ����IDɾ�����������
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteAssessOptionById(int id)
        {
            DBVisit.ObjDBAccess.CommandStr = "delete from AssessOpinion where AssessOpinion_ID=@id";
            DBVisit.ObjDBAccess.CmdParas.AddWithValue("@id", id);
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        /// <summary>
        /// ����һ����¼
        /// </summary>
        /// <param name="assessOption">Ҫ���ӵĶ���</param>
        /// <returns></returns>
        public static int AddAssessOption(AssessOpinion assessOption)
        {
            DBVisit.ObjDBAccess.CommandStr = @"insert into AssessOpinion values
                                               (@state,@sendId,@result,@article,@message,@articleState,@remark)";  //Ҫִ�е�SQL���
            SqlParameter[] sqlPm = new SqlParameter[]  //ʵ����һ�������б�
            {
                new SqlParameter ("@state",assessOption.AssessStateInfo.ID),
                new SqlParameter ("@sendId",assessOption.SendID),
                new SqlParameter ("@result",assessOption.AssessResultInfo.ID),
                new SqlParameter ("@article",assessOption.Article),
                new SqlParameter ("@message",assessOption.Message),
                new SqlParameter ("@articleState",assessOption.ArticleStateID),
                new SqlParameter ("@remark",assessOption.Remark)
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);  //���絽SqlCommand�Ĳ����б���ȥ
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //ִ��SQL���
        }
        #endregion
    }
}
