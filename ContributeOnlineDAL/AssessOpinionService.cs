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
    /// 评审信息数据访问类
    /// </summary>
    public class AssessOpinionService
    {
        #region 查询方法
        /// <summary>
        /// 根据ID查找评审意见
        /// </summary>
        /// <param name="id">要查找的评审意见ID</param>
        /// <returns>返回找到的评审意见对象</returns>
        public static AssessOpinion GetAssessOpinionById(int id)
        {
            AssessOpinion assessOption = new AssessOpinion();  //实例化一个新的查询结果
            DBVisit.ObjDBAccess.CommandStr = @"select AssessOpinion_State,AssessOpinion_SendID,
                                               AssessOpinion_Result,AssessOpinion_Article,
                                               AssessOpinion_Message,AssessOpinion_Remark,
                                               AssessOpinion_ArticleStateID
                                               from AssessOpinion where AssessOpinion_ID=@id";
            SqlParameter sqlPm = new SqlParameter("@id", id);
            DBVisit.ObjDBAccess.CmdParas.Add(sqlPm);
            DataSet ds = new DataSet();
            ds = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();  //调用DBhelp执行查询方法 返回一个DataSet对象
            assessOption.ID = id;  //跟相应的属性赋值
            assessOption.AssessStateInfo = AssessStateService.GetAssessStateById(int.Parse(ds.Tables[0].Rows[0]["AssessOpinion_State"].ToString()));
            assessOption.AssessResultInfo = AssessResultService.GetAssessResultById(int.Parse(ds.Tables[0].Rows[0]["AssessOpinion_Result"].ToString ()));
            assessOption.Article = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_Article"]);
            assessOption.Message = Convert.ToString(ds.Tables[0].Rows[0]["AssessOpinion_Message"]);
            assessOption.Remark = Convert.ToString(ds.Tables[0].Rows[0]["AssessOpinion_Remark"]);
            assessOption.SendID = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_SendID"]);
            assessOption.ArticleStateID = Convert.ToInt32(ds.Tables[0].Rows[0]["AssessOpinion_ArticleStateID"]);
            return assessOption;  //返回找到的结果
        }

        /// <summary>
        /// 查询所有的评审意见返回List
        /// </summary>
        /// <returns>返回类型List</returns>
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
        /// 获取文章信息（按照评审情况）
        /// </summary>
        /// <param name="assessStateId">稿件状态编号</param>
        /// <param name="userID">评审者编号</param>
        /// <param name="cmdStr">条件信息（SQl语句）</param>
        /// <returns>查询结果</returns>
        public static DataTable GetArticleInfoByAssessOpinionInfo(int assessStateId, int userID, string cmdStr)
        {
            //DBVisit.ObjDBAccess.CommandStr = "proc_GetArticleInfoByUserIDAndArticleTypeList";
            //设置参数
            DBVisit.ObjDBAccess.CmdParas.Clear();
            DBVisit.ObjDBAccess.CmdParas.Add("@AssessOpinion_State", SqlDbType.Int).Value = assessStateId;
            DBVisit.ObjDBAccess.CmdParas.Add("@AssessOpinion_SendID", SqlDbType.Int).Value = userID;
            DBVisit.ObjDBAccess.CmdParas.Add("@StateStr", SqlDbType.VarChar, 200).Value = cmdStr;
            DataSet ds = DBVisit.ObjDBAccess.ExecuteProc("proc_GetArticleInfoByUserIDAndArticleTypeList");
            return ds.Tables[0];
        }
        /// <summary>
        /// 获取评审信息编号
        /// </summary>
        /// <param name="articleID">稿件编号</param>
        /// <param name="senderID">发送者状态</param>
        /// <param name="assessStateID">评审状态</param>
        /// <param name="articleStID">评审批次</param>
        /// <returns>查询结果</returns>
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
        /// 根据文章编号查出关于这个文章的所有评论
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
        /// 根据文章号和评论者返回评审
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

        #region 非查询方法

        /// <summary>
        /// 修改评审意见表
        /// </summary>
        /// <param name="assessOption">要修改的新对象</param>
        /// <returns></returns>
        public static int  UpdateAssessOption(AssessOpinion assessOption)
        {
            DBVisit.ObjDBAccess.CommandStr = @"update AssessOpinion set AssessOpinion_State=@state,
                                               AssessOpinion_SendID=@sendId,AssessOpinion_Result=@result,
                                               AssessOpinion_Article=@article,AssessOpinion_Message=@message,
                                               AssessOpinion_Remark=@remark where AssessOpinion_ID=@id";  //要执行的SQL语句
            SqlParameter[] sqlPm = new SqlParameter[]    //实例化一个参数列表
            {
                new SqlParameter ("@state",assessOption.AssessStateInfo.ID),
                new SqlParameter ("@sendId",assessOption.SendID),
                new SqlParameter ("@result",assessOption.AssessResultInfo.ID),
                new SqlParameter ("@article",assessOption.Article),
                new SqlParameter ("@message",assessOption.Message),
                new SqlParameter ("@remark ",assessOption.Remark),
                new SqlParameter ("@id",assessOption.ID)
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);   //假如到SqlCommand的参数列表中去
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //执行SQL语句
        }
        /// <summary>
        /// 根据ID删除评审意见表
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
        /// 增加一条记录
        /// </summary>
        /// <param name="assessOption">要增加的对象</param>
        /// <returns></returns>
        public static int AddAssessOption(AssessOpinion assessOption)
        {
            DBVisit.ObjDBAccess.CommandStr = @"insert into AssessOpinion values
                                               (@state,@sendId,@result,@article,@message,@articleState,@remark)";  //要执行的SQL语句
            SqlParameter[] sqlPm = new SqlParameter[]  //实例化一个参数列表
            {
                new SqlParameter ("@state",assessOption.AssessStateInfo.ID),
                new SqlParameter ("@sendId",assessOption.SendID),
                new SqlParameter ("@result",assessOption.AssessResultInfo.ID),
                new SqlParameter ("@article",assessOption.Article),
                new SqlParameter ("@message",assessOption.Message),
                new SqlParameter ("@articleState",assessOption.ArticleStateID),
                new SqlParameter ("@remark",assessOption.Remark)
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);  //假如到SqlCommand的参数列表中去
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //执行SQL语句
        }
        #endregion
    }
}
