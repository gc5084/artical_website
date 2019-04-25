/*==========================================================
 * Class Name   :   ArticleStateService
 * Author       :   Hong
 * Create Time  :   2009.11.7
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;


namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 稿件状态操作类
    /// </summary>
    public class ArticleTypeService
    {
        

        #region  //查询方法
        /// <summary>
        /// 根据ID找稿件状态
        /// </summary>
        /// <param name="id">要查找的图书状态</param>
        /// <returns>返回找到对象</returns>
        public static ArticleType GetArticleTypesById(int id)
        {
            DBVisit.ObjDBAccess.CommandStr = "select ArticleType_ID,ArticleType_Name from ArticleType where ArticleType_ID=@id";  //SQL修改语句
            SqlParameter[] sqlPm = new SqlParameter[]
            {
                new SqlParameter ("@id",id),
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);
            DataSet ds = DBHelper.DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();

            ArticleType articleType = new ArticleType();              //创建一个对象
            articleType.Id = int.Parse(ds.Tables[0].Rows[0]["ArticleType_ID"].ToString());  //给对象的属性赋值
            articleType.Name = ds.Tables[0].Rows[0]["ArticleType_Name"].ToString();
            return articleType;

        }


        /// <summary>
        /// 查询所有的稿件种类
        /// </summary>
        /// <returns>返回DataTable</returns>
        public static DataTable GetAllArticleTypes()
        {
            DBVisit.ObjDBAccess.CommandStr = "select ArticleType_ID,ArticleType_Name from ArticleType"; //SQL查找语句
            DataSet ds = new DataSet();
            ds = DBHelper.DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();
            return ds.Tables[0];
        }

        #endregion


        #region  非查询方法

        /// <summary>
        /// 修改稿件种类方法
        /// </summary>
        /// <param name="articleState">稿件种类实体</param>
        /// <returns>受影响的行数</returns>
        public static int UpdataArticele(ArticleType articleType)
        {
            DBVisit.ObjDBAccess.CommandStr = "update ArticleType set ArticleType_Name=@name where ArticleType_ID=@id";
            SqlParameter[] sqlPm = new SqlParameter[]   //参数列表
            {
                new SqlParameter ("@name",articleType.Name ),
                new SqlParameter ("@id",articleType.Id)
            };
            DBHelper.DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);
            return DBHelper.DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //调用DBhelp执行修改
        }

        /// <summary>
        /// 根据ID删除稿件类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteArticleTypeById(int id)
        {
            DBVisit.ObjDBAccess.CommandStr = "delete from ArticleType where ArticleType_ID=@id"; //SQL删除语句
            SqlParameter sqlPm = new SqlParameter("@id", id);
            DBVisit.ObjDBAccess.CmdParas.Add(sqlPm);        //加到sqlCommand对象的参数
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();  //执行删除语句
        }

        /// <summary>
        /// 新增一个稿件种类
        /// </summary>
        /// <param name="articleType"></param>
        /// <returns></returns>
        public static int AddArticleTyjpe(ArticleType articleType)
        {
            DBVisit.ObjDBAccess.CommandStr = "insert into ArticleType value(@id,@name)";  //SQL插入语句
            SqlParameter[] sqlPm = new SqlParameter[]   //SQLCommand的插入参数
            {
                new SqlParameter ("@id",articleType.Id),
                new SqlParameter ("@name",articleType.Name )
            };
            DBVisit.ObjDBAccess.CmdParas.AddRange(sqlPm);         //加入到SqlCommand的参数列表中
            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();   //执行插入语句

        }
        #endregion

    }
}
