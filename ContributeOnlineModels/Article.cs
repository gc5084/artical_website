/*==========================================================
 * Class Name   :   Article
 * Author       :   Zhang
 * Create Time  :   2009.10.30
 * Updata Record:   none
 * Remark       :   none
 *=========================================================*/
using System;
using System.Collections.Generic;
using System.Text;

namespace ContributeOnlineSystem.Models
{
    /// <summary>
    /// 稿件实体类
    /// </summary>
	[Serializable]
    public class Article
    {
        #region 稿件实体类字段
        /// <summary>
		/// 稿件编号
		/// </summary>
		private int id;
		/// <summary>
		/// 中文标题
		/// </summary>
		private string chineseTitle;
		/// <summary>
		/// 英文标题
		/// </summary>
		private string englishTitle;
		/// <summary>
		/// 中文摘要
		/// </summary>
        private string chineseResume;
		/// <summary>
		/// 英文摘要
		/// </summary>
        private string englishResume;
		/// <summary>
		/// 中文关键字
		/// </summary>
		private string chineseKey;
		/// <summary>
		/// 英文关键字
		/// </summary>
		private string englishKey;
		/// <summary>
		/// 所属栏目编号
		/// </summary>
        private int articleColumnId;
		/// <summary>
		/// 稿件种类
		/// </summary>
        private ArticleType articleTypeInfo = new ArticleType();
		/// <summary>
		/// 推荐专家
		/// </summary>
		private string expert;
		/// <summary>
		/// 字数统计
		/// </summary>
		private int wordCount;
		/// <summary>
		/// 作者简介
		/// </summary>
		private string authorIntro;
		/// <summary>
		/// 电子邮箱
		/// </summary>
		private string email;
		/// <summary>
		/// 署名作者
		/// </summary>
		private int authorName;
		/// <summary>
		/// 附件名称
		/// </summary>
		private string attachmentName;
		/// <summary>
		/// 附件物理名称
		/// </summary>
		private string attachmentFileName;
		/// <summary>
		/// 稿件状态
		/// </summary>
        private ArticleState articleStateInfo = new ArticleState();

        private string aurthRealName;

		#endregion

		#region 稿件实体类属性

		/// <summary>
        /// 获取或设置稿件编号
		/// </summary>
		public int Id
        {
            get { return id; }
            set { id = value; }
		}
		/// <summary>
		/// 获取或设置中文标题
		/// </summary>
		public string ChineseTitle
		{
			get { return chineseTitle; }
			set { chineseTitle = value; }
		}
		/// <summary>
		/// 获取或设置英文标题
		/// </summary>
		public string EnglishTitle
		{
			get { return englishTitle; }
			set { englishTitle = value; }
		}
		/// <summary>
		/// 获取或设置中文摘要
		/// </summary>
		public string ChineseResume
		{
            get { return chineseResume; }
            set { chineseResume = value; }
		}
		/// <summary>
		/// 获取或设置英文摘要
		/// </summary>
		public string EnglishResume 
		{
			get { return englishResume; }
			set { englishResume = value; }
		}
		/// <summary>
		/// 获取或设置中文关键字
		/// </summary>
		public string ChineseKey
		{
			get { return chineseKey; }
			set { chineseKey = value; }
		}
		/// <summary>
		/// 获取或设置英文关键字
		/// </summary>
		public string EnglishKey
		{ 
			get { return englishKey; }
			set { englishKey = value; }
		}
		/// <summary>
		/// 获取或设置所属栏目编号
		/// </summary>
        public int ArticleColumnId
		{
            get { return articleColumnId; }
            set { articleColumnId = value; }
		}
		/// <summary>
		/// 获取或设置稿件种类
		/// </summary>
        public ArticleType ArticleTypeInfo
		{
            get { return articleTypeInfo; }
            set { articleTypeInfo = value; }
		}
		/// <summary>
		/// 获取或设置推荐专家
		/// </summary>
		public string Expert
		{ 
			get { return expert; }
			set { expert = value; }
		}
		/// <summary>
		/// 获取或设置字数统计
		/// </summary>
		public int WordCount
		{
			get { return wordCount; }
			set { wordCount = value; }
		}
		/// <summary>
		/// 获取或设置作者简介
		/// </summary>
		public string AuthorIntro
		{
			get { return authorIntro; }
			set { authorIntro = value; }
		}
		/// <summary>
		/// 获取或设置电子邮箱
		/// </summary>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		/// <summary>
		/// 获取或设置署名作者
		/// </summary>
		public int AuthorName
		{
			get { return authorName;}
			set { authorName = value; }
		}
		/// <summary>
		/// 获取或设置附件名称
		/// </summary>
		public string AttachmentName
		{
			get { return attachmentName; }
			set { attachmentName = value; }
		}
		/// <summary>
		/// 获取或设置附件物理名称
		/// </summary>
		public string AttachmentFileName
		{
			get { return attachmentFileName; }
			set { attachmentFileName = value; }
		}
		/// <summary>
		/// 获取或设置稿件状态
		/// </summary>
        public ArticleState ArticleStateInfo
		{
            get { return articleStateInfo; }
            set { articleStateInfo = value; }
		}

        public string AurthRealName
        {
            get { return aurthRealName; }
            set { aurthRealName = value; }
        }
		#endregion
	}
}
