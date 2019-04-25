/*==========================================================
 * Class Name   :   ArticleManager
 * Author       :   Blue
 * Create Time  :   2010.03.23
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/

using System;
using System.Collections.Generic;
using System.Text;

using ContributeOnlineSystem.Models;
using System.Data;
using ContributeOnlineSystem.DAL;

namespace ContributeOnlineSystem.BLL
{
    /// <summary>
    /// 稿件信息管理
    /// </summary>
    public class ExpertArticleManager
    {


        /// <summary>
        /// 添加一个稿件专家关系
        /// </summary>
        /// <param name="expertArticle"></param>
        /// <returns></returns>
        public static int AddExpertArticle(ExpertArticle expertArticle)
        {
            return ExpertArticleService.AddExpertArticle(expertArticle);
        }
    }
}
