/*==========================================================
 * Class Name   :   AssessOpinion
 * Author       :   Sun
 * Create Time  :   2009.11.05
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    [Serializable]
    /// <summary>
    /// ∆¿…Û◊¥Ã¨¿‡
    /// </summary>
    public class AssessState
    {

        #region ◊÷∂Œ
        /// <summary>
        /// ∆¿…Û◊¥Ã¨±‡∫≈
        /// </summary>
        private int  id;

        /// <summary>
        /// ∆¿…Û◊¥Ã¨√˚≥∆
        /// </summary>
        private string name;
        
        #endregion

        #region  Ù–‘
        /// <summary>
        /// ªÒ»°ªÚ…Ë÷√∆¿…Û◊¥Ã¨±‡∫≈
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// ªÒ»°ªÚ…Ë÷√∆¿…Û◊¥Ã¨√˚≥∆
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        #endregion
    }
}
