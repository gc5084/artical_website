if EXISTS
(
   select * 
   from master.dbo.sysdatabases 
   where name = 'ContributeOnlineSystemDB'
)
begin
      use master; /*防止正在使用无法删除*/
     
      drop database ContributeOnlineSystemDB;
end
GO


/*创建数据库*/
Create Database ContributeOnlineSystemDB
ON (
  NAME = 'ContributeOnlineSystemDB_data',   --主数据文件的逻辑名
  FILENAME = 'E:\ContributeOnlineSystemDB_data.mdf' ,  --主数据文件的物理名
  SIZE = 10 MB,  --主数据文件初始大小
  FILEGROWTH = 20%    --主数据文件的增长率
) 
LOG ON 
 (NAME = 'ContributeOnlineSystemDB_log', 
  FILENAME = 'E:\ContributeOnlineSystemDB_log.ldf' ,
  SIZE = 3MB, 
  MAXSIZE = 20MB,
  FILEGROWTH = 10%
)

Go
USE [ContributeOnlineSystemDB]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ArticleType]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ArticleType](
	[ArticleType_ID] [int] NOT NULL,
	[ArticleType_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ARTICLETYPE] PRIMARY KEY CLUSTERED 
(
	[ArticleType_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[AssessResult]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[AssessResult](
	[AssessResult_ID] [int] NOT NULL,
	[AssessResult_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ASSESSRESULT] PRIMARY KEY CLUSTERED 
(
	[AssessResult_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[AssessState]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[AssessState](
	[AssessState_ID] [int] NOT NULL,
	[AssessState_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ASSESSSTATE] PRIMARY KEY CLUSTERED 
(
	[AssessState_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Message]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Message](
	[Message_ID] [int] IDENTITY(1,1) NOT NULL,
	[Message_Type] [varchar](20) NOT NULL,
	[Message_SenderID] [int] NOT NULL,
	[Message_ReceiverID] [int] NOT NULL,
	[Message_Content] [varchar](1000) NOT NULL,
	[Message_Time] [datetime] NOT NULL,
	[Message_Flag] [bit] NOT NULL,
	[Message_Remark] [varchar](200) NULL,
 CONSTRAINT [PK_MESSAGE] PRIMARY KEY CLUSTERED 
(
	[Message_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Role]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Role](
	[Role_ID] [int] NOT NULL,
	[Role_Name] [varchar](50) NOT NULL,
	[Role_NavTreeNodeID] [int] NOT NULL,
 CONSTRAINT [PK_ROLE] PRIMARY KEY CLUSTERED 
(
	[Role_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ArticleColumn]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ArticleColumn](
	[ArticleColumn_ID] [int] IDENTITY(1,1) NOT NULL,
	[ArticleColumn_ResponsibleEditorID] [int] NULL,
	[ArticleColumn_Name] [varchar](100) NOT NULL,
	[ArticleColumn_Description] [varchar](1000) NULL,
 CONSTRAINT [PK_ARTICLECOLUMN] PRIMARY KEY CLUSTERED 
(
	[ArticleColumn_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Field]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Field](
	[Field_ID] [int] IDENTITY(1,1) NOT NULL,
	[Field_Name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FIELD] PRIMARY KEY CLUSTERED 
(
	[Field_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_GetArticleInfoByUserIDAndArticleTypeList]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Proc [dbo].[proc_GetArticleInfoByUserIDAndArticleTypeList]
@AssessOpinion_State int,	--评审状态
@AssessOpinion_SendID int,	--评论者编号
@StateStr varChar(200)		--Article_State
AS
Exec(
''Select	
	Article_ID,Article_ChineseTitle,Article_EnglishTitle,
	Article_ChineseResume,Article_EnglishResume,Article_ChineseKey,
	Article_EnglishKey,Article_ColumnID,Article_TypeID,Article_Expert,
	Article_WordCount,Article_AuthorIntro,Article_EMail,Article_AuthorName,
	Article_AttachmentName,Article_AttachmentFileName,Article_State,
	ArticleType_Name,ArticleState_Name
From Article,ArticleType,ArticleState
Where Article_TypeID = ArticleType_ID And Article_State = ArticleState_ID
      And Article_ID in
(
	Select AssessOpinion_Article From AssessOpinion
	Where AssessOpinion_State = ''+@AssessOpinion_State+'' 
		  And AssessOpinion_SendID = ''+@AssessOpinion_SendID+''
) And (''+@StateStr+'')'' )' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ArticleState]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ArticleState](
	[ArticleState_ID] [int] NOT NULL,
	[ArticleState_Name] [varchar](20) NOT NULL,
 CONSTRAINT [PK_ARTICLESTATE] PRIMARY KEY CLUSTERED 
(
	[ArticleState_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Article]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Article](
	[Article_ID] [int] IDENTITY(1,1) NOT NULL,
	[Article_ChineseTitle] [varchar](50) NOT NULL,
	[Article_EnglishTitle] [varchar](50) NOT NULL,
	[Article_ChineseResume] [varchar](1000) NOT NULL,
	[Article_EnglishResume] [varchar](1000) NOT NULL,
	[Article_ChineseKey] [varchar](100) NOT NULL,
	[Article_EnglishKey] [varchar](100) NOT NULL,
	[Article_ColumnID] [int] NOT NULL,
	[Article_TypeID] [int] NOT NULL,
	[Article_Expert] [varchar](100) NOT NULL,
	[Article_WordCount] [int] NOT NULL,
	[Article_AuthorIntro] [varchar](1000) NOT NULL,
	[Article_EMail] [varchar](50) NOT NULL,
	[Article_AuthorName] [int] NOT NULL,
	[Article_AttachmentName] [varchar](50) NOT NULL,
	[Article_AttachmentFileName] [varchar](50) NOT NULL,
	[Article_State] [int] NOT NULL,
 CONSTRAINT [PK_ARTICLE] PRIMARY KEY CLUSTERED 
(
	[Article_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[AssessOpinion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[AssessOpinion](
	[AssessOpinion_ID] [int] IDENTITY(1,1) NOT NULL,
	[AssessOpinion_State] [int] NOT NULL,
	[AssessOpinion_SendID] [int] NOT NULL,
	[AssessOpinion_Result] [int] NOT NULL,
	[AssessOpinion_Article] [int] NOT NULL,
	[AssessOpinion_Message] [varchar](1000) NOT NULL,
	[AssessOpinion_ArticleStateID] [int] NOT NULL,
	[AssessOpinion_Remark] [varchar](500) NULL,
 CONSTRAINT [PK_ASSESSOPINION] PRIMARY KEY CLUSTERED 
(
	[AssessOpinion_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ArticleExpert]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ArticleExpert](
	[ArticleExpert_ArticleID] [int] NOT NULL,
	[ArticleExpert_ExpertID] [int] NOT NULL,
 CONSTRAINT [PK_ARTICLEEXPERT] PRIMARY KEY CLUSTERED 
(
	[ArticleExpert_ArticleID] ASC,
	[ArticleExpert_ExpertID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[ExpertField]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[ExpertField](
	[ExpertField_ID] [int] IDENTITY(1,1) NOT NULL,
	[ExpertField_ExpertID] [int] NOT NULL,
	[ExpertField_FieldID] [int] NOT NULL,
	[ExpertField_IsUserDefine] [bit] NOT NULL,
	[ExpertField_UserDefineName] [varchar](50) NULL,
 CONSTRAINT [PK_EXPERTFIELD] PRIMARY KEY CLUSTERED 
(
	[ExpertField_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[UserInfo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[UserInfo](
	[UserInfo_ID] [int] IDENTITY(1,1) NOT NULL,
	[UserInfo_RoleID] [int] NOT NULL,
	[UserInfo_Name] [varchar](100) NOT NULL,
	[UserInfo_Pwd] [varchar](50) NOT NULL,
	[UserInfo_CreateTime] [datetime] NOT NULL,
	[UserInfo_RealName] [varchar](100) NOT NULL,
	[UserInfo_Sex] [bit] NOT NULL,
	[UserInfo_Birthday] [datetime] NOT NULL,
	[UserInfo_Tel] [varchar](20) NOT NULL,
	[UserInfo_Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_USERINFO] PRIMARY KEY CLUSTERED 
(
	[UserInfo_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Expert]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Expert](
	[Expert_ID] [int] NOT NULL,
	[Expert_WorkPlace] [varchar](100) NOT NULL,
	[Expert_Intro] [varchar](1000) NOT NULL,
	[Expert_Remark] [varchar](100) NULL,
 CONSTRAINT [PK_EXPERT] PRIMARY KEY CLUSTERED 
(
	[Expert_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Author]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
BEGIN
CREATE TABLE [dbo].[Author](
	[Author_ID] [int] NOT NULL,
	[Author_TypeName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_AUTHOR] PRIMARY KEY CLUSTERED 
(
	[Author_ID] ASC
) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_GetUserExpertById]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [dbo].[proc_GetUserExpertById]
	@Expert_ID int
as	
	Select Expert_ID, Expert_WorkPlace, Expert_Intro, Expert_Remark, 
           UserInfo_RoleID, UserInfo_Name, UserInfo_Pwd, UserInfo_CreateTime,
		   UserInfo_RealName, UserInfo_Sex, UserInfo_Birthday, UserInfo_Tel, UserInfo_Email
		   Role_ID, Role_Name, Role_NavTreeNodeID
	From Expert, UserInfo, [Role]
	where Expert_ID = @Expert_ID and UserInfo_ID = Expert_ID and Role_ID = UserInfo_RoleID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_DeleteUserExpert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE PROCEDURE [dbo].[proc_DeleteUserExpert]
	@Expert_ID int,
    @IsSuccess bit Output
As
	--检查在专家——领域关系表中是否引用当前专家
	Declare @isExists int 
	Set @isExists = (Select count(*) From ExpertField 
					Where ExpertField_ExpertID = @Expert_ID)
	Begin Transaction
	If @isExists > 0 --如果存在关系 删除关系
		Begin
		    Delete From ExpertField Where ExpertField_ExpertID = @Expert_ID
		End
	--删除专家稿件关系
	delete from ArticleExpert where ArticleExpert_ExpertID = @Expert_ID

	Begin
		--删除专家信息

		Delete From Expert Where Expert_ID = @Expert_ID
		Delete From UserInfo Where UserInfo_ID = @Expert_ID
		Declare @Error int
		Set @Error = @@Error
		If @Error > 0
			Begin
				set	@IsSuccess = 0
				RollBack Transaction
				Return
			End
		Else	
			Begin
				Set @IsSuccess = 1
				Commit Transaction
			End
	End



' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_InsertUserExpert]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Procedure [dbo].[proc_InsertUserExpert]
	--用户信息表变量
	@UserInfo_RoleID Int,
	@UserInfo_Name Varchar(100),
	@UserInfo_Pwd Varchar(50),
	@UserInfo_CreateTime DateTime,
	@UserInfo_RealName Varchar(100),
	@UserInfo_Sex Bit,
	@UserInfo_Birthday DateTime,
	@UserInfo_Tel Varchar(20),
	@UserInfo_Email Varchar(50),
	--专家信息表变量
	@Expert_WorkPlace Varchar(100),
	@Expert_Intro Varchar(1000),
	@Expert_Remark Varchar(100),
	--输出参数
	@IsSuccess Int Output,
	@OutExpertID int Output
	
As
	Begin Transaction
	Insert Into UserInfo(UserInfo_RoleID, UserInfo_Name, UserInfo_Pwd, UserInfo_CreateTime,
				UserInfo_RealName, UserInfo_Sex, UserInfo_Birthday, UserInfo_Tel, UserInfo_Email)
				Values(@UserInfo_RoleID, @UserInfo_Name, @UserInfo_Pwd, @UserInfo_CreateTime,
				@UserInfo_RealName, @UserInfo_Sex, @UserInfo_Birthday, @UserInfo_Tel, @UserInfo_Email)
	Declare @Error int
	Declare @Index int
	Set @Error = @@Error
	Set @Index = @@Identity
	Set @OutExpertID = @@Identity
	If @Error > 0
		Begin
			Set @IsSuccess = 0
			RollBack Transaction
			Return
		End
	Insert Into Expert(Expert_ID, Expert_WorkPlace, Expert_Intro, Expert_Remark)
				Values(@Index, @Expert_WorkPlace, @Expert_Intro, @Expert_Remark)
	Set @Error = @@Error
	If @Error > 0
		Begin
			Set @IsSuccess = 0
			RollBack Transaction
			Return
		End
	Else
		Begin
			Set @IsSuccess = 1
			Commit Transaction
			Return
		End

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_GetUserExpertAll]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [dbo].[proc_GetUserExpertAll]
as	
	Select Expert_ID, Expert_WorkPlace, Expert_Intro, Expert_Remark, 
           UserInfo_RoleID, UserInfo_Name, UserInfo_Pwd, UserInfo_CreateTime,
		   UserInfo_RealName, UserInfo_Sex, UserInfo_Birthday, UserInfo_Tel, UserInfo_Email
		   Role_ID, Role_Name, Role_NavTreeNodeID
	From Expert, UserInfo, [Role]
	where UserInfo_ID = Expert_ID and Role_ID = UserInfo_RoleID
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_UpdateUserExpertInfo]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Proc [dbo].[proc_UpdateUserExpertInfo]
--用户信息表变量
@UserInfo_ID Int,
@UserInfo_RoleID Int,
@UserInfo_Name Varchar(100),
@UserInfo_Pwd Varchar(50),
@UserInfo_CreateTime DateTime,
@UserInfo_RealName Varchar(100),
@UserInfo_Sex Bit,
@UserInfo_Birthday DateTime,
@UserInfo_Tel Varchar(20),
@UserInfo_Email Varchar(50),
--专家信息表变量
@Expert_WorkPlace Varchar(100),
@Expert_Intro Varchar(1000),
@Expert_Remark Varchar(100),
--操作列类型
@IsSuccess Bit output
AS
Set @IsSuccess = 1
Begin Transaction 
--修改用户表中的信息

Update UserInfo 
Set 
	UserInfo_RoleID = @UserInfo_RoleID,
	UserInfo_Name = @UserInfo_Name,
	UserInfo_Pwd = @UserInfo_Pwd,
	UserInfo_CreateTime = @UserInfo_CreateTime,
	UserInfo_RealName = @UserInfo_RealName,
	UserInfo_Sex = @UserInfo_Sex,
	UserInfo_Birthday = @UserInfo_Birthday,
	UserInfo_Tel = @UserInfo_Tel,
	UserInfo_Email = @UserInfo_Email
Where UserInfo_ID = @UserInfo_ID
--检查操作是否成功
IF @@ERROR <> 0
Begin
	Set @IsSuccess = 0
	Rollback Transaction
	Return 1
End
--修改专家表中的信息
Update Expert
Set
	Expert_WorkPlace = @Expert_WorkPlace,
	Expert_Intro = @Expert_Intro,
	Expert_Remark = @Expert_Remark
Where Expert_ID = @UserInfo_ID
--检查操作是否成功
IF @@ERROR <> 0
Begin
	Set @IsSuccess = 0
	Rollback Transaction
	Return 1
End
Commit Transaction
Return 0
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_InserIntoAuthor]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'
--创建一个ResponsibleEditor的插入的存储过程
create procedure [dbo].[proc_InserIntoAuthor]
@UserInfo_RoleID int,
@UserInfo_Name varchar(50),
@UserInfo_Pwd varchar(50),
@UserInfo_CreateTime datetime,
@UserInfo_RealName varchar(50),
@UserInfo_Sex int,
@UserInfo_Birthday datetime,
@UserInfo_Tel varchar(50),
@UserInfo_Email varchar(50),


@Author_TypeName varchar(100),

@IsSuccess bit Output
as
 begin transaction
   insert into UserInfo(UserInfo_RoleID,UserInfo_Name,UserInfo_Pwd,UserInfo_CreateTime,
         UserInfo_RealName,UserInfo_Sex,UserInfo_Birthday,UserInfo_Tel,UserInfo_Email )
   values (@UserInfo_RoleID,@UserInfo_Name,@UserInfo_Pwd,@UserInfo_CreateTime,
           @UserInfo_RealName,@UserInfo_Sex,@UserInfo_Birthday,@UserInfo_Tel,@UserInfo_Email)
   Declare @Index int
   Declare @Error int
   set @Error=@@Error
   set @index=@@identity
   if @Error>0
       Begin
            Set @IsSuccess = 0
			RollBack Transaction
            return
		End
   insert into Author(Author_ID,Author_TypeName)
   values (@index,@Author_TypeName)
   set @Error=@@Error
   if @Error >0
       begin
            Set @IsSuccess = 0
			RollBack Transaction
            return
       end
   else
      begin
            Set @IsSuccess = 1
			commit Transaction
            return
       end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_UpdateUserAuthorInfo]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'

create Procedure [dbo].[proc_UpdateUserAuthorInfo]
(
--基本用户信息参数
 @UserInfo_ID int,
 @UserInfo_RoleID int,
 @UserInfo_Name varchar(100),
 @UserInfo_Pwd varchar(50),
 @UserInfo_CreateTime datetime,
 @UserInfo_RealName varchar(100),
 @UserInfo_Sex bit,
 @UserInfo_Birthday datetime,
 @UserInfo_Tel varchar(20),
 @UserInfo_Email varchar(50),
--责任编辑信息参数
 @Author_TypeName varchar(20),
--存储过程执行结果参数
 @IsSuccess bit OUTPUT
)
AS
Begin
		--检查是否在责任编辑表中存在相应数据行
		if not exists(select * from Author where Author_ID = @UserInfo_ID)
			Begin 
				set @IsSuccess = 0;
				return
			End

		
		Begin Transaction   --事务起点
			--修改责编表中信息
			Update Author
			Set 
				Author_TypeName = @Author_TypeName
			where 
				Author_ID = @UserInfo_ID
			--是否有错误
			If @@Error <> 0 
				Begin
					RollBack Transaction; --回滚事务
					set @IsSuccess = 0;
					return
				End

			--修改相应基本用户表中信息
			Update UserInfo
			set
				UserInfo_RoleID = @UserInfo_RoleID,
				UserInfo_Name	= @UserInfo_Name,
				UserInfo_Pwd	= @UserInfo_Pwd,
				UserInfo_CreateTime =@UserInfo_CreateTime,
				UserInfo_RealName	=@UserInfo_RealName,
				UserInfo_Sex	=@UserInfo_Sex,
				UserInfo_Birthday	= @UserInfo_Birthday,
				UserInfo_Tel	= @UserInfo_Tel,
				UserInfo_Email	= @UserInfo_Email
			where
				UserInfo_ID = @UserInfo_ID
			--是否有错误
			If @@Error <> 0 
				Begin
					RollBack Transaction; --回滚事务
					set @IsSuccess = 0;
					return
				End
			--事务完成
			Commit Transaction
			set @IsSuccess = 1;
			return
end' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_GetUserAuthorById]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Proc [dbo].[proc_GetUserAuthorById]
@ID int
AS
Begin
	Select  UserInfo_ID,UserInfo_RoleID,
			UserInfo_Name,UserInfo_Pwd,
			UserInfo_CreateTime,UserInfo_RealName,
			UserInfo_Sex,UserInfo_Birthday,
			UserInfo_Tel,UserInfo_Email,
			Author_ID,
			Author_TypeName
	From Author,UserInfo
	Where UserInfo_ID = Author_ID And UserInfo_ID = @ID
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_GetAllUserAuthor]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Proc [dbo].[proc_GetAllUserAuthor]
AS
Begin
	Select  UserInfo_ID,UserInfo_RoleID,
			UserInfo_Name,UserInfo_Pwd,
			UserInfo_CreateTime,UserInfo_RealName,
			UserInfo_Sex,UserInfo_Birthday,
			UserInfo_Tel,UserInfo_Email,
			Author_ID,
			Author_TypeName
	From Author,UserInfo
	Where UserInfo_ID = Author_ID
End' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_DeleteArticle]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE Procedure [dbo].[proc_DeleteArticle] 
@ArticleID int,
@IsSuccess bit Output
As
	Begin Transaction
	--删除评审
	delete from AssessOpinion where AssessOpinion_Article=@ArticleID
	--删除专家稿件关系
    delete from ArticleExpert where ArticleExpert_ArticleID = @ArticleID
	--删除稿件
	delete from Article where Article_ID=@ArticleID
	Declare @error int
	set @error=@@Error
	if @error>0
	  begin
		set @IsSuccess=0
		rollback Transaction
		return
	  end
	else
	  begin
		set @IsSuccess=1
		commit Transaction
	  end
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_InsertNewArticleInfo]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'Create Proc [dbo].[proc_InsertNewArticleInfo]
@Article_ChineseTitle varchar(50),		--中文标题
@Article_EnglishTitle varchar(50),		--英文标题
@Article_ChineseResume  varchar(1000),		--中文摘要
@Article_EnglishResume varchar(1000),		--英文摘要
@Article_ChineseKey varchar(100),			--中文关键字
@Article_EnglishKey varchar(100),			--英文关键字
@Article_ColumnID int,			--所属栏目编号
@Article_TypeID int,				--稿件种类编号
@Article_Expert varchar(100),				--推荐专家
@Article_WordCount int,			--字数统计
@Article_AuthorIntro varchar(1000),			--作者简介
@Article_EMail varchar(50),				--电子邮箱
@Article_AuthorName int,			--署名作者
@Article_AttachmentName varchar(50),		--附件名称
@Article_AttachmentFileName varchar(50),	--附件物理名称
@Article_State int,				--稿件状态编号
@Article_ID int output
AS
Insert into 
Article(
	Article_ChineseTitle,Article_EnglishTitle,Article_ChineseResume,
	Article_EnglishResume,Article_ChineseKey,Article_EnglishKey,
	Article_ColumnID,Article_TypeID,Article_Expert,Article_WordCount,
	Article_AuthorIntro,Article_EMail,Article_AuthorName,
	Article_AttachmentName,Article_AttachmentFileName,Article_State
) 
Values(
	@Article_ChineseTitle,@Article_EnglishTitle,@Article_ChineseResume,
	@Article_EnglishResume,@Article_ChineseKey,@Article_EnglishKey,@Article_ColumnID,
	@Article_TypeID,@Article_Expert,@Article_WordCount,@Article_AuthorIntro,@Article_EMail,
	@Article_AuthorName,@Article_AttachmentName,@Article_AttachmentFileName,@Article_State
)
Set @Article_ID = @@identity' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[proc_DeleteUserAuthor]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
BEGIN
EXEC dbo.sp_executesql @statement = N'


--删除作者或用户信息的存储过程 （如没删除附表记录 不需回滚继续删除主表内容）
CREATE proc [dbo].[proc_DeleteUserAuthor]
@authorId int,
@IsSuccess bit Output
as

Begin Transaction
	--删除作者用户的相应文章
	Declare @isExists int 
	Set @isExists = (Select count(*) From Article 
					Where Article_AuthorName = @authorId)
	if @isExists > 0 --若该用户有写过文章
	Begin
		Declare @Insuccess int
		Declare @articleID int   --定义储存变量
		Declare arID_cursor Cursor for select Article_ID  --定义游标
										from Article  
										where Article_AuthorName = @authorId
		Open arID_cursor
		Fetch Next from arID_cursor into @articleID			--提前第一行
			exec proc_DeleteArticle @articleID,@Insuccess output --执行存储过程
		While @@Fetch_status = 0
			Begin
				exec proc_DeleteArticle @articleID,@Insuccess output --执行存储过程
			End
		Close arID_cursor  --关闭游标
		Deallocate arID_cursor --释放游标
	End
	--删除用户信息
	delete from Author where Author_ID=@authorId
	delete from UserInfo where UserInfo_ID=@authorId
   
	Declare @error int
	set @error=@@Error
	if @error>0
	  begin
		set @IsSuccess=0
		rollback Transaction
		return
	  end
	else
	  begin
		set @IsSuccess=1
		commit Transaction
	  end

' 
END
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ARTICLE_REFERENCE_ARTICLEC]') AND type = 'F')
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_ARTICLE_REFERENCE_ARTICLEC] FOREIGN KEY([Article_ColumnID])
REFERENCES [dbo].[ArticleColumn] ([ArticleColumn_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ARTICLE_REFERENCE_ARTICLES]') AND type = 'F')
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_ARTICLE_REFERENCE_ARTICLES] FOREIGN KEY([Article_State])
REFERENCES [dbo].[ArticleState] ([ArticleState_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ARTICLE_REFERENCE_ARTICLET]') AND type = 'F')
ALTER TABLE [dbo].[Article]  WITH CHECK ADD  CONSTRAINT [FK_ARTICLE_REFERENCE_ARTICLET] FOREIGN KEY([Article_TypeID])
REFERENCES [dbo].[ArticleType] ([ArticleType_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ASSESSOP_REFERENCE_ARTICLE]') AND type = 'F')
ALTER TABLE [dbo].[AssessOpinion]  WITH CHECK ADD  CONSTRAINT [FK_ASSESSOP_REFERENCE_ARTICLE] FOREIGN KEY([AssessOpinion_Article])
REFERENCES [dbo].[Article] ([Article_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ASSESSOP_REFERENCE_ARTSTATE]') AND type = 'F')
ALTER TABLE [dbo].[AssessOpinion]  WITH CHECK ADD  CONSTRAINT [FK_ASSESSOP_REFERENCE_ARTSTATE] FOREIGN KEY([AssessOpinion_ArticleStateID])
REFERENCES [dbo].[ArticleState] ([ArticleState_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ASSESSOP_REFERENCE_ASSESSRE]') AND type = 'F')
ALTER TABLE [dbo].[AssessOpinion]  WITH CHECK ADD  CONSTRAINT [FK_ASSESSOP_REFERENCE_ASSESSRE] FOREIGN KEY([AssessOpinion_Result])
REFERENCES [dbo].[AssessResult] ([AssessResult_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ASSESSOP_REFERENCE_ASSESSST]') AND type = 'F')
ALTER TABLE [dbo].[AssessOpinion]  WITH CHECK ADD  CONSTRAINT [FK_ASSESSOP_REFERENCE_ASSESSST] FOREIGN KEY([AssessOpinion_State])
REFERENCES [dbo].[AssessState] ([AssessState_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ASSESSOP_REFERENCE_USERINFO]') AND type = 'F')
ALTER TABLE [dbo].[AssessOpinion]  WITH CHECK ADD  CONSTRAINT [FK_ASSESSOP_REFERENCE_USERINFO] FOREIGN KEY([AssessOpinion_SendID])
REFERENCES [dbo].[UserInfo] ([UserInfo_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ARTICLEE_REFERENCE_ARTICLE]') AND type = 'F')
ALTER TABLE [dbo].[ArticleExpert]  WITH CHECK ADD  CONSTRAINT [FK_ARTICLEE_REFERENCE_ARTICLE] FOREIGN KEY([ArticleExpert_ArticleID])
REFERENCES [dbo].[Article] ([Article_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_ARTICLEE_REFERENCE_EXPERT]') AND type = 'F')
ALTER TABLE [dbo].[ArticleExpert]  WITH CHECK ADD  CONSTRAINT [FK_ARTICLEE_REFERENCE_EXPERT] FOREIGN KEY([ArticleExpert_ExpertID])
REFERENCES [dbo].[Expert] ([Expert_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_EXPERTFI_REFERENCE_EXPERT]') AND type = 'F')
ALTER TABLE [dbo].[ExpertField]  WITH CHECK ADD  CONSTRAINT [FK_EXPERTFI_REFERENCE_EXPERT] FOREIGN KEY([ExpertField_ExpertID])
REFERENCES [dbo].[Expert] ([Expert_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_EXPERTFI_REFERENCE_FIELD]') AND type = 'F')
ALTER TABLE [dbo].[ExpertField]  WITH CHECK ADD  CONSTRAINT [FK_EXPERTFI_REFERENCE_FIELD] FOREIGN KEY([ExpertField_FieldID])
REFERENCES [dbo].[Field] ([Field_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_USERINFO_REFERENCE_ROLE]') AND type = 'F')
ALTER TABLE [dbo].[UserInfo]  WITH CHECK ADD  CONSTRAINT [FK_USERINFO_REFERENCE_ROLE] FOREIGN KEY([UserInfo_RoleID])
REFERENCES [dbo].[Role] ([Role_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_EXPERT_REFERENCE_USERINFO]') AND type = 'F')
ALTER TABLE [dbo].[Expert]  WITH CHECK ADD  CONSTRAINT [FK_EXPERT_REFERENCE_USERINFO] FOREIGN KEY([Expert_ID])
REFERENCES [dbo].[UserInfo] ([UserInfo_ID])
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[FK_AUTHOR_REFERENCE_USERINFO]') AND type = 'F')
ALTER TABLE [dbo].[Author]  WITH CHECK ADD  CONSTRAINT [FK_AUTHOR_REFERENCE_USERINFO] FOREIGN KEY([Author_ID])
REFERENCES [dbo].[UserInfo] ([UserInfo_ID])
