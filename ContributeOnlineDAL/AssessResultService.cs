/*==========================================================
 * Class Name   :   AssessResultService
 * Author       :   Rosy
 * Create Time  :   2009.11.8
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 评审结果数据访问类
    /// </summary>
    public class AssessResultService
    {
        #region 查询操作
        /// <summary>
        /// 获取所有评审结果信息
        /// </summary>
        /// <returns>评审结果表</returns>
        public static DataTable GetAllAssessResultInfo()
        {
            string selectStr = "Select AssessResult_ID,AssessResult_Name From AssessResult";   //定义查询语句
            DBVisit.ObjDBAccess.CommandStr = selectStr;                                     //设置查询语句
            DataSet assessStates = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();           //修改表名称
            assessStates.Tables[0].TableName = "AssessResult";                               //返回查询结果
            return assessStates.Tables["AssessResult"];
        }
        /// <summary>
        /// 按照编号查找评审结果信息
        /// </summary>
        /// <param name="assessStateId">评审结果编号</param>
        /// <returns>评审结果信息</returns>
        public static AssessResult GetAssessResultById(int assessResultId)
        {
            string selectStr = "Select AssessResult_ID,AssessResult_Name From AssessResult Where AssessResult_ID = @ID ";
            DBVisit.ObjDBAccess.CommandStr = selectStr;                                         //设置查询语句
            DBVisit.ObjDBAccess.CmdParas.Add("@ID", SqlDbType.Int).Value = assessResultId;      //设置参数
            DataSet assessResults = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();               //修改表名称

            AssessResult objResult = new AssessResult();
            objResult.ID = Convert.ToInt32(assessResults.Tables[0].Rows[0]["AssessResult_ID"]);
            objResult.Name = assessResults.Tables[0].Rows[0]["AssessResult_ID"].ToString();

            return objResult;
        }
        #endregion 查询操作
    }
}