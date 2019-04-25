/*==========================================================
 * Class Name   :   FieldService
 * Author       :   Blue
 * Create Time  :   2010.03.23
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using ContributeOnlineSystem.DAL.DBHelper;
using System.Data;
using System.Data.SqlClient;

namespace ContributeOnlineSystem.DAL
{
    /// <summary>
    /// ������Ϣ���ݷ�����
    /// </summary>
    public static class ExpertArticleService
    {
        #region ��ѯ����
        
        /// <summary>
        /// �Ƿ����ָ��ר�Ҹ����ϵ
        /// </summary>
        /// <param name="expertArticle"></param>
        /// <returns></returns>
        public static bool IsExistEA(ExpertArticle expertArticle)
        {
            string sql = @"select ArticleExpert_ArticleID, ArticleExpert_ExpertID 
                            from ArticleExpert
                            where ArticleExpert_ArticleID = @ArticleExpert_ArticleID And ArticleExpert_ExpertID = @ArticleExpert_ExpertID";
            //ִ��
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ArticleID", SqlDbType.Int).Value = expertArticle.ArticleId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ExpertID", SqlDbType.Int).Value = expertArticle.ExpertId;
            bool result = DBVisit.ObjDBAccess.IsExist();

            return result;

        }

        #endregion

        #region �ǲ�ѯ����

        /// <summary>
        /// ����һ��ר�Ҹ����ϵ
        /// </summary>
        /// <param name="expertArticle"></param>
        /// <returns></returns>
        public static int AddExpertArticle(ExpertArticle expertArticle)
        {
            if(IsExistEA(expertArticle))
            {
                return 2;
            }

            string sql = @"Insert into ArticleExpert(ArticleExpert_ArticleID, ArticleExpert_ExpertID)
                            Values(@ArticleExpert_ArticleID, @ArticleExpert_ExpertID)";

            //�������ݿ⣬ִ��SQL���
            DBVisit.ObjDBAccess.CommandStr = sql;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ArticleID", SqlDbType.Int).Value = expertArticle.ArticleId;
            DBVisit.ObjDBAccess.CmdParas.Add("@ArticleExpert_ExpertID", SqlDbType.Int).Value = expertArticle.ExpertId;

            return DBVisit.ObjDBAccess.ExecuteUnSelectSqlCommand();
        }

        #endregion
    }
}
