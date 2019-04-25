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
    /// ���ʵ����
    /// </summary>
	[Serializable]
    public class Article
    {
        #region ���ʵ�����ֶ�
        /// <summary>
		/// ������
		/// </summary>
		private int id;
		/// <summary>
		/// ���ı���
		/// </summary>
		private string chineseTitle;
		/// <summary>
		/// Ӣ�ı���
		/// </summary>
		private string englishTitle;
		/// <summary>
		/// ����ժҪ
		/// </summary>
        private string chineseResume;
		/// <summary>
		/// Ӣ��ժҪ
		/// </summary>
        private string englishResume;
		/// <summary>
		/// ���Ĺؼ���
		/// </summary>
		private string chineseKey;
		/// <summary>
		/// Ӣ�Ĺؼ���
		/// </summary>
		private string englishKey;
		/// <summary>
		/// ������Ŀ���
		/// </summary>
        private int articleColumnId;
		/// <summary>
		/// �������
		/// </summary>
        private ArticleType articleTypeInfo = new ArticleType();
		/// <summary>
		/// �Ƽ�ר��
		/// </summary>
		private string expert;
		/// <summary>
		/// ����ͳ��
		/// </summary>
		private int wordCount;
		/// <summary>
		/// ���߼��
		/// </summary>
		private string authorIntro;
		/// <summary>
		/// ��������
		/// </summary>
		private string email;
		/// <summary>
		/// ��������
		/// </summary>
		private int authorName;
		/// <summary>
		/// ��������
		/// </summary>
		private string attachmentName;
		/// <summary>
		/// ������������
		/// </summary>
		private string attachmentFileName;
		/// <summary>
		/// ���״̬
		/// </summary>
        private ArticleState articleStateInfo = new ArticleState();

        private string aurthRealName;

		#endregion

		#region ���ʵ��������

		/// <summary>
        /// ��ȡ�����ø�����
		/// </summary>
		public int Id
        {
            get { return id; }
            set { id = value; }
		}
		/// <summary>
		/// ��ȡ���������ı���
		/// </summary>
		public string ChineseTitle
		{
			get { return chineseTitle; }
			set { chineseTitle = value; }
		}
		/// <summary>
		/// ��ȡ������Ӣ�ı���
		/// </summary>
		public string EnglishTitle
		{
			get { return englishTitle; }
			set { englishTitle = value; }
		}
		/// <summary>
		/// ��ȡ����������ժҪ
		/// </summary>
		public string ChineseResume
		{
            get { return chineseResume; }
            set { chineseResume = value; }
		}
		/// <summary>
		/// ��ȡ������Ӣ��ժҪ
		/// </summary>
		public string EnglishResume 
		{
			get { return englishResume; }
			set { englishResume = value; }
		}
		/// <summary>
		/// ��ȡ���������Ĺؼ���
		/// </summary>
		public string ChineseKey
		{
			get { return chineseKey; }
			set { chineseKey = value; }
		}
		/// <summary>
		/// ��ȡ������Ӣ�Ĺؼ���
		/// </summary>
		public string EnglishKey
		{ 
			get { return englishKey; }
			set { englishKey = value; }
		}
		/// <summary>
		/// ��ȡ������������Ŀ���
		/// </summary>
        public int ArticleColumnId
		{
            get { return articleColumnId; }
            set { articleColumnId = value; }
		}
		/// <summary>
		/// ��ȡ�����ø������
		/// </summary>
        public ArticleType ArticleTypeInfo
		{
            get { return articleTypeInfo; }
            set { articleTypeInfo = value; }
		}
		/// <summary>
		/// ��ȡ�������Ƽ�ר��
		/// </summary>
		public string Expert
		{ 
			get { return expert; }
			set { expert = value; }
		}
		/// <summary>
		/// ��ȡ����������ͳ��
		/// </summary>
		public int WordCount
		{
			get { return wordCount; }
			set { wordCount = value; }
		}
		/// <summary>
		/// ��ȡ���������߼��
		/// </summary>
		public string AuthorIntro
		{
			get { return authorIntro; }
			set { authorIntro = value; }
		}
		/// <summary>
		/// ��ȡ�����õ�������
		/// </summary>
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
		/// <summary>
		/// ��ȡ��������������
		/// </summary>
		public int AuthorName
		{
			get { return authorName;}
			set { authorName = value; }
		}
		/// <summary>
		/// ��ȡ�����ø�������
		/// </summary>
		public string AttachmentName
		{
			get { return attachmentName; }
			set { attachmentName = value; }
		}
		/// <summary>
		/// ��ȡ�����ø�����������
		/// </summary>
		public string AttachmentFileName
		{
			get { return attachmentFileName; }
			set { attachmentFileName = value; }
		}
		/// <summary>
		/// ��ȡ�����ø��״̬
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
