/*==========================================================
 * Class Name   :   ExpertFieldManager
 * Author       :   Blue
 * Create Time  :   2009.11.20
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL;
using System.Data;

namespace ContributeOnlineSystem.BLL
{
    
    /// <summary>
    /// 专家领域管理类
    /// </summary>
    public class ExpertFieldManager
    {
        #region 函数操作
        /// <summary>
        /// 添加指定领域到指定专家
        /// </summary>
        /// <returns></returns>
        public static int AddFieldExpert(Field field,UserExpert userExpert)
        {
            ExpertField ThisExpertField = new ExpertField();

            //封装一个专家和领域实体
            ThisExpertField.ExpertId = userExpert.Id;
            ThisExpertField.FieldId = field.Id;
            ThisExpertField.IsDefine = false;
            ThisExpertField.DefineName = "";

            //调用添加函数
            return ExpertFieldService.InsertExpertField(ThisExpertField);

        }


        /// <summary>
        /// 删除一个专家和领域的关系
        /// </summary>
        /// <param name="field"></param>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int DelFieldExpert(Field field, UserExpert userExpert)
        {
            int IsSuccess = 1; 
            //是否全部删除成功

            DataTable dataTable = ExpertFieldService.GetExpertIDByED(field, userExpert);
            //获取专家和领域ID的datatable


            for (int i = 0; i < dataTable.Rows.Count; i++) //删除所有对应的专家和领域实体
            {
                int Index = (int)dataTable.Rows[i][1];
                if(ExpertFieldService.DeleteExpertField(Index) == 0) //是否成功
                {
                    IsSuccess = 0;
                }
            }

            return IsSuccess;
        }
        /// <summary>
        /// 插入一个专家
        /// </summary>
        /// <param name="userExpert"></param>
        /// <returns></returns>
        public static int InsertUserExpert(UserExpert userExpert)
        {
            return UserExpertService.InsertUserExpert(userExpert);
        }

        /// <summary>
        /// 获取全部领域信息
        /// </summary>
        /// <returns></returns>
        public static DataTable GetFieldAll()
        {
            return FieldService.GetFieldAll();
        }


        /// <summary>
        /// 添加新领域
        /// </summary>
        /// <param name="field">领域对象</param>
        /// <returns>SQL语句影响行数</returns>
        public static int InsertField(Field field)
        {
            return FieldService.InsertField(field);
        }

        /// <summary>
        /// 根据id删除新领域信息
        /// </summary>
        /// <param name="id">对象id</param>
        /// <returns>SQL语句影响行数</returns>
        public static int DeleteFieldById(int id)
        {
            return FieldService.DeleteFieldById(id);
        }
    #endregion

    }
}
