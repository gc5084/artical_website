/*==========================================================
 * Class Name   :   ArticleService
 * Author       :   Rosy
 * Create Time  :   2009.11.8
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;


namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// �������ݷ�����
    /// </summary>
    public class ArticleService
    {
        #region ��ѯ����
        /// <summary>
        /// ��ȡ���и����Ϣ
        /// </summary>
        /// <returns>�����Ϣ�б�</returns>
        public static List<Article> GetAllArticleInfo()
        {
            //��ѯ������Ϣ
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,

	                ArticleType_Name,ArticleState_Name,UserInfo_RealName
                    
                  From Article,ArticleType,ArticleState,UserInfo
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID And Article_AuthorName=UserInfo_ID";
            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            resultDs.Tables[0].TableName = "ArticleInfo";

            //��װʵ����
            DataTable table = resultDs.Tables["ArticleInfo"];
            int dataCount = table.Rows.Count;
            List<Article> articleList = new List<Article>(dataCount);   //���������б�
            //��������б�
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //����������Ϣ
                Article item = new Article();
                item.Id = Convert.ToInt32(table.Rows[i]["Article_ID"]);                     //������
                item.ChineseTitle = table.Rows[i]["Article_ChineseTitle"].ToString();       //���ı���
                item.EnglishTitle = table.Rows[i]["Article_EnglishTitle"].ToString();       //Ӣ�ı���
                item.ChineseResume = table.Rows[i]["Article_ChineseResume"].ToString();     //����ժҪ
                item.EnglishResume = table.Rows[i]["Article_EnglishResume"].ToString();     //Ӣ��ժҪ
                item.ChineseKey = table.Rows[i]["Article_ChineseKey"].ToString();           //���Ĺؼ���
                item.EnglishKey = table.Rows[i]["Article_EnglishKey"].ToString();           //Ӣ�Ĺؼ���

                item.ArticleColumnId = Convert.ToInt32(table.Rows[i]["Article_ColumnID"]);  //������Ŀ���
                item.ArticleTypeInfo.Id = Convert.ToInt32(table.Rows[i]["Article_TypeID"]); //���������
                item.Expert = table.Rows[i]["Article_Expert"].ToString();                   //�Ƽ�ר��
                item.WordCount = Convert.ToInt32(table.Rows[i]["Article_WordCount"]);       //����ͳ��
                item.AuthorIntro = table.Rows[i]["Article_AuthorIntro"].ToString();         //���߼��
                item.Email = table.Rows[i]["Article_EMail"].ToString();                     //��������
                item.AurthRealName = table.Rows[i]["UserInfo_RealName"].ToString();            //��������
                item.AttachmentName = table.Rows[i]["Article_AttachmentName"].ToString();   //��������
                item.AttachmentFileName = table.Rows[i]["Article_AttachmentFileName"].ToString();   //������������
                item.ArticleStateInfo.Id = Convert.ToInt32(table.Rows[i]["Article_State"]);         //���״̬���

                item.ArticleTypeInfo.Name = table.Rows[i]["ArticleType_Name"].ToString();           //�����������
                item.ArticleStateInfo.Name = table.Rows[i]["ArticleState_Name"].ToString();         //���״̬����

                //��ӵ�ʵ�����б�
                articleList.Add(item);
            }

            return articleList;     //���ز�ѯ���
        }

        /// <summary>
        /// ��ȡ���и����Ϣ ��dataTabel��ʽ
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllArticleInfoAsDT() 
        {
            //��ѯ������Ϣ
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,

	                ArticleType_Name,ArticleState_Name,UserInfo_RealName
                    
                  From Article,ArticleType,ArticleState,UserInfo
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID And Article_AuthorName=UserInfo_ID";
            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            resultDs.Tables[0].TableName = "ArticleInfo";

            //��װʵ����
            DataTable table = resultDs.Tables["ArticleInfo"];
            return table;     //���ز�ѯ���
        }
        /// <summary>
        /// ���ݱ�Ż�ȡ������Ϣ
        /// </summary>
        /// <param name="ArticleId">���±��</param>
        /// <returns>Ҫ��ѯ��������Ϣ(�����ڷ���null)</returns>
        public static Article GetArticleInfoById(int articleId)
        {
            //��ѯ������Ϣ
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleType_Name,ArticleState_Name
                  From Article,ArticleType,ArticleState
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID
                        And Article_ID = @Article_ID";
            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ID", SqlDbType.Int).Value = articleId;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            
            DataTable table = resultDs.Tables[0];
            table.TableName = "ArticleInfo";
            if (table.Rows.Count == 0)
            { //û�з��������ĸ��
                return null;
            }
            else
            {
                Article item = new Article();
                item.Id = Convert.ToInt32(table.Rows[0]["Article_ID"]);                     //������
                item.ChineseTitle = table.Rows[0]["Article_ChineseTitle"].ToString();       //���ı���
                item.EnglishTitle = table.Rows[0]["Article_EnglishTitle"].ToString();       //Ӣ�ı���
                item.ChineseResume = table.Rows[0]["Article_ChineseResume"].ToString();     //����ժҪ
                item.EnglishResume = table.Rows[0]["Article_EnglishResume"].ToString();     //Ӣ��ժҪ
                item.ChineseKey = table.Rows[0]["Article_ChineseKey"].ToString();           //���Ĺؼ���
                item.EnglishKey = table.Rows[0]["Article_EnglishKey"].ToString();           //Ӣ�Ĺؼ���

                item.ArticleColumnId = Convert.ToInt32(table.Rows[0]["Article_ColumnID"]);  //������Ŀ���
                item.ArticleTypeInfo.Id = Convert.ToInt32(table.Rows[0]["Article_TypeID"]); //���������
                item.Expert = table.Rows[0]["Article_Expert"].ToString();                   //�Ƽ�ר��
                item.WordCount = Convert.ToInt32(table.Rows[0]["Article_WordCount"]);       //����ͳ��
                item.AuthorIntro = table.Rows[0]["Article_AuthorIntro"].ToString();         //���߼��
                item.Email = table.Rows[0]["Article_EMail"].ToString();                     //��������
                item.AuthorName = Convert.ToInt32(table.Rows[0]["Article_AuthorName"]);     //��������
                item.AttachmentName = table.Rows[0]["Article_AttachmentName"].ToString();   //��������
                item.AttachmentFileName = table.Rows[0]["Article_AttachmentFileName"].ToString();   //������������
                item.ArticleStateInfo.Id = Convert.ToInt32(table.Rows[0]["Article_State"]);         //���״̬���

                item.ArticleTypeInfo.Name = table.Rows[0]["ArticleType_Name"].ToString();           //�����������
                item.ArticleStateInfo.Name = table.Rows[0]["ArticleState_Name"].ToString();         //���״̬����

                return item;
            }
        }

        /// <summary>
        /// �����������ߺ�״̬��ȡ������Ϣ
        /// </summary>
        /// <param name="userID">���߱��</param>
        /// <param name="articleState">Ҫ��ȡ��״̬���</param>
        /// <returns>��ѯ���</returns>
        public static DataTable GetArticleInfoByUserIDAndArticleState(int userID, int articleState)
        {
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleType_Name,ArticleState_Name
                  From Article,ArticleType,ArticleState
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID And
                    Article_AuthorName = @Article_AuthorName And Article_State = @ArticleState_ID";

            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = userID;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleState_ID", SqlDbType.Int).Value = articleState;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            DataTable table = resultDs.Tables[0];
            return table;
        }
        /// <summary>
        /// ��������״̬��ȡ����
        /// </summary>
        /// <param name="articleState"></param>
        /// <returns></returns>
        public static DataTable GetArticleInfoByArticleState(int articleState)
        {
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleType_Name,ArticleState_Name
                  From Article,ArticleType,ArticleState
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID And
                     Article_State = @ArticleState_ID";

            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleState_ID", SqlDbType.Int).Value = articleState;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            DataTable table = resultDs.Tables[0];
            return table;
        }

        /// <summary>
        /// ��ѯ�����еĸ��
        /// </summary>
        /// <param name="userID">���߱��</param>
        /// <returns></returns>
        public static DataTable GetWorkArticleInfoByUserID(int userID)
        {
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleType_Name,ArticleState_Name
                  From Article,ArticleType,ArticleState
                  Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID And 
                    Article_AuthorName = @Article_AuthorName And Article_State <= 12 OR Article_State =16";

            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = userID;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            DataTable table = resultDs.Tables[0];
            return table;
        }
        #endregion ��ѯ����


        #region Blue

        public static int DeleteArticleByID(int ArticleID)
        {
            string sql = "proc_DeleteArticle";
            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleID", SqlDbType.Int).Value = ArticleID;
            DBVisit.ObjDBAccess.CmdParas.Add("@IsSuccess", SqlDbType.Bit).Direction = ParameterDirection.Output;

            DBVisit.ObjDBAccess.ExcuteProcReturnInt(sql);
            bool result = bool.Parse(DBVisit.ObjDBAccess.CmdParas["@IsSuccess"].Value.ToString());
            if (result)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// ���������߲�������
        /// </summary>
        /// <param name="SendID">�����߱��</param>
        /// <returns></returns>
        public static DataTable GetArticleByAessSendID(int SendID)
        {
            string selectStr =
                @"Select Distinct
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleState_Name
                  From Article,AssessOpinion,ArticleState
                  Where Article_State = ArticleState_ID And AssessOpinion_SendID = @SendID And 
                        AssessOpinion_Article = Article_ID ";

            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@SendID", SqlDbType.Int).Value = SendID;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            DataTable table = resultDs.Tables[0];
            return table;
        }

        /// <summary>
        /// ����δ������
        /// </summary>
        /// <param name="strCondition">��ͬ�������ַ���</param>
        /// <returns></returns>
        public static DataTable GetArticleForUnfinsh(string strTab,string strCondition)
        {
            string selectStr =
                @"Select	
	                Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	                Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	                Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	                Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	                Article_AttachmentName,Article_AttachmentFileName,Article_State,
	                ArticleState_Name
                  From Article,ArticleState" + strTab +
                  " Where Article_State = ArticleState_ID And " + strCondition;
                         

            DBVisit.ObjDBAccess.CommandStr = selectStr;
            DataSet resultDs = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            DataTable table = resultDs.Tables[0];
            return table;
        }
        #endregion

        #region �ǲ�ѯ����
        /// <summary>
        /// �޸ĸ����Ϣ
        /// </summary>
        /// <param name="updateArticle">Ҫ�޸ĵĸ����Ϣ</param>
        /// <returns>�������</returns>
        public static int UpdateArticleInfo(Article updateArticle)
        {
            //�����޸�����
            string updateStr =
                @"Update Article Set	
	                Article_ChineseTitle = @Article_ChineseTitle,
                    Article_EnglishTitle = @Article_EnglishTitle,
	                Article_ChineseResume = @Article_ChineseResume,
                    Article_EnglishResume = @Article_EnglishResume,
                    Article_ChineseKey = @Article_ChineseKey,
                    Article_EnglishKey = @Article_EnglishKey,
                    Article_ColumnID = @Article_ColumnID,
                    Article_TypeID = @Article_TypeID,
                    Article_Expert = @Article_Expert,
	                Article_WordCount = @Article_WordCount,
                    Article_AuthorIntro = @Article_AuthorIntro,
                    Article_EMail = @Article_EMail,
                    Article_AuthorName = @Article_AuthorName,
	                Article_AttachmentName = @Article_AttachmentName,
                    Article_AttachmentFileName = @Article_AttachmentFileName,
                    Article_State = @Article_State
                  Where Article_ID = @Article_ID";
            //���ò���
            DBVisit.ObjDBAccess.CommandStr = updateStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseTitle", SqlDbType.VarChar, 50).Value = updateArticle.ChineseTitle;            //���ı���

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishTitle", SqlDbType.VarChar, 50).Value = updateArticle.EnglishTitle;            //Ӣ�ı���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseResume", SqlDbType.VarChar, 1000).Value = updateArticle.ChineseResume;        //����ժҪ
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishResume", SqlDbType.VarChar, 1000).Value = updateArticle.EnglishResume;        //Ӣ��ժҪ
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseKey", SqlDbType.VarChar, 100).Value = updateArticle.ChineseKey;               //���Ĺؼ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishKey", SqlDbType.VarChar, 100).Value = updateArticle.EnglishKey;               //Ӣ�Ĺؼ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ColumnID", SqlDbType.Int).Value = updateArticle.ArticleColumnId;                     //������Ŀ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_TypeID", SqlDbType.Int).Value = updateArticle.ArticleTypeInfo.Id;                    //���������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_Expert", SqlDbType.VarChar, 100).Value = updateArticle.Expert;                       //�Ƽ�ר��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_WordCount", SqlDbType.Int).Value = updateArticle.WordCount;                          //����ͳ��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorIntro", SqlDbType.VarChar, 1000).Value = updateArticle.AuthorIntro;            //���߼��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EMail", SqlDbType.VarChar, 50).Value = updateArticle.Email;                          //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = updateArticle.AuthorName;                        //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentName", SqlDbType.VarChar, 50).Value = updateArticle.AttachmentName;        //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentFileName", SqlDbType.VarChar, 50).Value = updateArticle.AttachmentFileName;//������������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_State", SqlDbType.Int).Value = updateArticle.ArticleStateInfo.Id;                    //���״̬���

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ID", SqlDbType.Int).Value = updateArticle.Id;

            int result = DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
            return result;
        }
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        /// <param name="updateArticle">�����Ϣ</param>
        /// <returns>�������</returns>
        public static int InsertArticleInfo(Article insertArticle) 
        {
            //�����޸�����
            string insertStr = "proc_InsertNewArticleInfo";
//                @"Insert into 
//                  Article(
//                    Article_ChineseTitle,Article_EnglishTitle,Article_ChineseResume,
//                    Article_EnglishResume,Article_ChineseKey,Article_EnglishKey,
//                    Article_ColumnID,Article_TypeID,Article_Expert,Article_WordCount,
//                    Article_AuthorIntro,Article_EMail,Article_AuthorName,
//	                Article_AttachmentName,Article_AttachmentFileName,Article_State
//                  ) 
//                  Values(
//                    @Article_ChineseTitle,@Article_EnglishTitle,@Article_ChineseResume,
//                    @Article_EnglishResume,@Article_ChineseKey,@Article_EnglishKey,@Article_ColumnID,
//                    @Article_TypeID,@Article_Expert,@Article_WordCount,@Article_AuthorIntro,@Article_EMail,
//                    @Article_AuthorName,@Article_AttachmentName,@Article_AttachmentFileName,@Article_State
//                  )";
            //���ò���
            //DBVisit.ObjDBAccess.CommandStr = insertStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseTitle", SqlDbType.VarChar, 50).Value = insertArticle.ChineseTitle;            //���ı���

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishTitle", SqlDbType.VarChar, 50).Value = insertArticle.EnglishTitle;            //Ӣ�ı���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseResume", SqlDbType.VarChar, 1000).Value = insertArticle.ChineseResume;        //����ժҪ
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishResume", SqlDbType.VarChar, 1000).Value = insertArticle.EnglishResume;        //Ӣ��ժҪ
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseKey", SqlDbType.VarChar, 100).Value = insertArticle.ChineseKey;               //���Ĺؼ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishKey", SqlDbType.VarChar, 100).Value = insertArticle.EnglishKey;               //Ӣ�Ĺؼ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ColumnID", SqlDbType.Int).Value = insertArticle.ArticleColumnId;                     //������Ŀ���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_TypeID", SqlDbType.Int).Value = insertArticle.ArticleTypeInfo.Id;                    //���������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_Expert", SqlDbType.VarChar, 100).Value = insertArticle.Expert;                       //�Ƽ�ר��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_WordCount", SqlDbType.Int).Value = insertArticle.WordCount;                          //����ͳ��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorIntro", SqlDbType.VarChar, 1000).Value = insertArticle.AuthorIntro;            //���߼��
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EMail", SqlDbType.VarChar, 50).Value = insertArticle.Email;                          //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = insertArticle.AuthorName;                        //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentName", SqlDbType.VarChar, 50).Value = insertArticle.AttachmentName;        //��������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentFileName", SqlDbType.VarChar, 50).Value = insertArticle.AttachmentFileName;//������������
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_State", SqlDbType.Int).Value = insertArticle.ArticleStateInfo.Id;                    //���״̬���
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

            int result = DBVisit.ObjDBAccess.ExcuteProcReturnInt(insertStr);
            return Convert.ToInt32(DBVisit.ObjDBAccess.CmdParas["@Article_ID"].Value);
        }
        #endregion �ǲ�ѯ����
    }
}
