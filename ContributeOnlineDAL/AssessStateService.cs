/*==========================================================
 * Class Name   :   AssessStateService
 * Author       :   Rosy
 * Create Time  :   2009.11.8
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using ContributeOnlineSystem.DAL.DBHelper;
using ContributeOnlineSystem.Models;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// 评审状态数据访问类
    /// </summary>
    public class AssessStateService
    {
        #region 查询操作
        /// <summary>
        /// 获取所有评审状态信息
        /// </summary>
        /// <returns>评审状态表</returns>
        public static DataTable GetAllAssessStateInfo()
        {
            string selectStr = "Select AssessState_ID,AssessState_Name From AssessState";   //定义查询语句
            DBVisit.ObjDBAccess.CommandStr = selectStr;                                     //设置查询语句
            DataSet assessStates = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();           //修改表名称
            assessStates.Tables[0].TableName = "AssessState";                               //返回查询结果
            return assessStates.Tables["AssessState"];
        }
        /// <summary>
        /// 按照编号查找评审状态信息
        /// </summary>
        /// <param name="assessStateId">评审状态编号</param>
        /// <returns>评审状态信息</returns>
        public static AssessState GetAssessStateById(int assessStateId)
        {
            string selectStr = "Select AssessState_ID,AssessState_Name From AssessState Where AssessState_ID = @ID ";
            DBVisit.ObjDBAccess.CommandStr = selectStr;                                     //设置查询语句
            DBVisit.ObjDBAccess.CmdParas.Add("@ID", SqlDbType.Int).Value = assessStateId;   //设置参数
            DataSet assessStates = DBVisit.ObjDBAccess.ExecuteSelectSqlCommand();           //修改表名称

            AssessState objResult = new AssessState();
            objResult.ID = Convert.ToInt32(assessStates.Tables[0].Rows[0]["AssessState_ID"]);
            objResult.Name = assessStates.Tables[0].Rows[0]["AssessState_ID"].ToString();

            return objResult;
        }
        #endregion 查询操作
    }
}
