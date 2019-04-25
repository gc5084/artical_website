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
    /// 文章数据访问类
    /// </summary>
    public class ArticleService
    {
        #region 查询操作
        /// <summary>
        /// 获取所有稿件信息
        /// </summary>
        /// <returns>稿件信息列表</returns>
        public static List<Article> GetAllArticleInfo()
        {
            //查询数据信息
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

            //封装实体类
            DataTable table = resultDs.Tables["ArticleInfo"];
            int dataCount = table.Rows.Count;
            List<Article> articleList = new List<Article>(dataCount);   //创建数据列表
            //填充数据列表
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //设置数据信息
                Article item = new Article();
                item.Id = Convert.ToInt32(table.Rows[i]["Article_ID"]);                     //稿件编号
                item.ChineseTitle = table.Rows[i]["Article_ChineseTitle"].ToString();       //中文标题
                item.EnglishTitle = table.Rows[i]["Article_EnglishTitle"].ToString();       //英文标题
                item.ChineseResume = table.Rows[i]["Article_ChineseResume"].ToString();     //中文摘要
                item.EnglishResume = table.Rows[i]["Article_EnglishResume"].ToString();     //英文摘要
                item.ChineseKey = table.Rows[i]["Article_ChineseKey"].ToString();           //中文关键字
                item.EnglishKey = table.Rows[i]["Article_EnglishKey"].ToString();           //英文关键字

                item.ArticleColumnId = Convert.ToInt32(table.Rows[i]["Article_ColumnID"]);  //所属栏目编号
                item.ArticleTypeInfo.Id = Convert.ToInt32(table.Rows[i]["Article_TypeID"]); //稿件种类编号
                item.Expert = table.Rows[i]["Article_Expert"].ToString();                   //推荐专家
                item.WordCount = Convert.ToInt32(table.Rows[i]["Article_WordCount"]);       //字数统计
                item.AuthorIntro = table.Rows[i]["Article_AuthorIntro"].ToString();         //作者简介
                item.Email = table.Rows[i]["Article_EMail"].ToString();                     //电子邮箱
                item.AurthRealName = table.Rows[i]["UserInfo_RealName"].ToString();            //署名作者
                item.AttachmentName = table.Rows[i]["Article_AttachmentName"].ToString();   //附件名称
                item.AttachmentFileName = table.Rows[i]["Article_AttachmentFileName"].ToString();   //附件物理名称
                item.ArticleStateInfo.Id = Convert.ToInt32(table.Rows[i]["Article_State"]);         //稿件状态编号

                item.ArticleTypeInfo.Name = table.Rows[i]["ArticleType_Name"].ToString();           //稿件种类名称
                item.ArticleStateInfo.Name = table.Rows[i]["ArticleState_Name"].ToString();         //稿件状态名称

                //添加到实体类列表
                articleList.Add(item);
            }

            return articleList;     //返回查询结果
        }

        /// <summary>
        /// 获取所有稿件信息 已dataTabel形式
        /// </summary>
        /// <returns></returns>
        public static DataTable GetAllArticleInfoAsDT() 
        {
            //查询数据信息
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

            //封装实体类
            DataTable table = resultDs.Tables["ArticleInfo"];
            return table;     //返回查询结果
        }
        /// <summary>
        /// 根据编号获取文章信息
        /// </summary>
        /// <param name="ArticleId">文章编号</param>
        /// <returns>要查询的文章信息(不存在返回null)</returns>
        public static Article GetArticleInfoById(int articleId)
        {
            //查询数据信息
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
            { //没有符合条件的稿件
                return null;
            }
            else
            {
                Article item = new Article();
                item.Id = Convert.ToInt32(table.Rows[0]["Article_ID"]);                     //稿件编号
                item.ChineseTitle = table.Rows[0]["Article_ChineseTitle"].ToString();       //中文标题
                item.EnglishTitle = table.Rows[0]["Article_EnglishTitle"].ToString();       //英文标题
                item.ChineseResume = table.Rows[0]["Article_ChineseResume"].ToString();     //中文摘要
                item.EnglishResume = table.Rows[0]["Article_EnglishResume"].ToString();     //英文摘要
                item.ChineseKey = table.Rows[0]["Article_ChineseKey"].ToString();           //中文关键字
                item.EnglishKey = table.Rows[0]["Article_EnglishKey"].ToString();           //英文关键字

                item.ArticleColumnId = Convert.ToInt32(table.Rows[0]["Article_ColumnID"]);  //所属栏目编号
                item.ArticleTypeInfo.Id = Convert.ToInt32(table.Rows[0]["Article_TypeID"]); //稿件种类编号
                item.Expert = table.Rows[0]["Article_Expert"].ToString();                   //推荐专家
                item.WordCount = Convert.ToInt32(table.Rows[0]["Article_WordCount"]);       //字数统计
                item.AuthorIntro = table.Rows[0]["Article_AuthorIntro"].ToString();         //作者简介
                item.Email = table.Rows[0]["Article_EMail"].ToString();                     //电子邮箱
                item.AuthorName = Convert.ToInt32(table.Rows[0]["Article_AuthorName"]);     //署名作者
                item.AttachmentName = table.Rows[0]["Article_AttachmentName"].ToString();   //附件名称
                item.AttachmentFileName = table.Rows[0]["Article_AttachmentFileName"].ToString();   //附件物理名称
                item.ArticleStateInfo.Id = Convert.ToInt32(table.Rows[0]["Article_State"]);         //稿件状态编号

                item.ArticleTypeInfo.Name = table.Rows[0]["ArticleType_Name"].ToString();           //稿件种类名称
                item.ArticleStateInfo.Name = table.Rows[0]["ArticleState_Name"].ToString();         //稿件状态名称

                return item;
            }
        }

        /// <summary>
        /// 根据文章作者和状态获取文章信息
        /// </summary>
        /// <param name="userID">作者编号</param>
        /// <param name="articleState">要获取的状态编号</param>
        /// <returns>查询结果</returns>
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
        /// 根据文章状态获取文章
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
        /// 查询审理中的稿件
        /// </summary>
        /// <param name="userID">作者编号</param>
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
        #endregion 查询操作


        #region Blue

        public static int DeleteArticleByID(int ArticleID)
        {
            string sql = "proc_DeleteArticle";
            //连接数据库，执行SQL语句
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
        /// 根据评审者查找文章
        /// </summary>
        /// <param name="SendID">评审者编号</param>
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
        /// 返回未处理稿件
        /// </summary>
        /// <param name="strCondition">不同的条件字符串</param>
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

        #region 非查询操作
        /// <summary>
        /// 修改稿件信息
        /// </summary>
        /// <param name="updateArticle">要修改的稿件信息</param>
        /// <returns>操作结果</returns>
        public static int UpdateArticleInfo(Article updateArticle)
        {
            //定义修改命令
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
            //设置参数
            DBVisit.ObjDBAccess.CommandStr = updateStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseTitle", SqlDbType.VarChar, 50).Value = updateArticle.ChineseTitle;            //中文标题

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishTitle", SqlDbType.VarChar, 50).Value = updateArticle.EnglishTitle;            //英文标题
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseResume", SqlDbType.VarChar, 1000).Value = updateArticle.ChineseResume;        //中文摘要
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishResume", SqlDbType.VarChar, 1000).Value = updateArticle.EnglishResume;        //英文摘要
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseKey", SqlDbType.VarChar, 100).Value = updateArticle.ChineseKey;               //中文关键字
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishKey", SqlDbType.VarChar, 100).Value = updateArticle.EnglishKey;               //英文关键字
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ColumnID", SqlDbType.Int).Value = updateArticle.ArticleColumnId;                     //所属栏目编号
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_TypeID", SqlDbType.Int).Value = updateArticle.ArticleTypeInfo.Id;                    //稿件种类编号
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_Expert", SqlDbType.VarChar, 100).Value = updateArticle.Expert;                       //推荐专家
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_WordCount", SqlDbType.Int).Value = updateArticle.WordCount;                          //字数统计
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorIntro", SqlDbType.VarChar, 1000).Value = updateArticle.AuthorIntro;            //作者简介
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EMail", SqlDbType.VarChar, 50).Value = updateArticle.Email;                          //电子邮箱
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = updateArticle.AuthorName;                        //署名作者
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentName", SqlDbType.VarChar, 50).Value = updateArticle.AttachmentName;        //附件名称
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentFileName", SqlDbType.VarChar, 50).Value = updateArticle.AttachmentFileName;//附件物理名称
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_State", SqlDbType.Int).Value = updateArticle.ArticleStateInfo.Id;                    //稿件状态编号

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ID", SqlDbType.Int).Value = updateArticle.Id;

            int result = DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
            return result;
        }
        /// <summary>
        /// 新增稿件信息
        /// </summary>
        /// <param name="updateArticle">稿件信息</param>
        /// <returns>操作结果</returns>
        public static int InsertArticleInfo(Article insertArticle) 
        {
            //定义修改命令
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
            //设置参数
            //DBVisit.ObjDBAccess.CommandStr = insertStr;
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseTitle", SqlDbType.VarChar, 50).Value = insertArticle.ChineseTitle;            //中文标题

            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishTitle", SqlDbType.VarChar, 50).Value = insertArticle.EnglishTitle;            //英文标题
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseResume", SqlDbType.VarChar, 1000).Value = insertArticle.ChineseResume;        //中文摘要
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishResume", SqlDbType.VarChar, 1000).Value = insertArticle.EnglishResume;        //英文摘要
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ChineseKey", SqlDbType.VarChar, 100).Value = insertArticle.ChineseKey;               //中文关键字
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EnglishKey", SqlDbType.VarChar, 100).Value = insertArticle.EnglishKey;               //英文关键字
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ColumnID", SqlDbType.Int).Value = insertArticle.ArticleColumnId;                     //所属栏目编号
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_TypeID", SqlDbType.Int).Value = insertArticle.ArticleTypeInfo.Id;                    //稿件种类编号
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_Expert", SqlDbType.VarChar, 100).Value = insertArticle.Expert;                       //推荐专家
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_WordCount", SqlDbType.Int).Value = insertArticle.WordCount;                          //字数统计
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorIntro", SqlDbType.VarChar, 1000).Value = insertArticle.AuthorIntro;            //作者简介
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_EMail", SqlDbType.VarChar, 50).Value = insertArticle.Email;                          //电子邮箱
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AuthorName", SqlDbType.Int).Value = insertArticle.AuthorName;                        //署名作者
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentName", SqlDbType.VarChar, 50).Value = insertArticle.AttachmentName;        //附件名称
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_AttachmentFileName", SqlDbType.VarChar, 50).Value = insertArticle.AttachmentFileName;//附件物理名称
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_State", SqlDbType.Int).Value = insertArticle.ArticleStateInfo.Id;                    //稿件状态编号
            DBVisit.ObjDBAccess.CmdParas.Add("@Article_ID", SqlDbType.Int).Direction = ParameterDirection.Output;

            int result = DBVisit.ObjDBAccess.ExcuteProcReturnInt(insertStr);
            return Convert.ToInt32(DBVisit.ObjDBAccess.CmdParas["@Article_ID"].Value);
        }
        #endregion 非查询操作
    }
}
