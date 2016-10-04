USE [master]
GO
/****** Object:  Database [Playground]    Script Date: 10/31/2010 21:46:23 ******/
CREATE DATABASE [Playground] ON  PRIMARY 
( NAME = N'Playground', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Playground.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Playground_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\Playground_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Playground] SET COMPATIBILITY_LEVEL = 90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Playground].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Playground] SET ANSI_NULL_DEFAULT ON
GO
ALTER DATABASE [Playground] SET ANSI_NULLS ON
GO
ALTER DATABASE [Playground] SET ANSI_PADDING ON
GO
ALTER DATABASE [Playground] SET ANSI_WARNINGS ON
GO
ALTER DATABASE [Playground] SET ARITHABORT ON
GO
ALTER DATABASE [Playground] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Playground] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Playground] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Playground] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Playground] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Playground] SET CURSOR_DEFAULT  LOCAL
GO
ALTER DATABASE [Playground] SET CONCAT_NULL_YIELDS_NULL ON
GO
ALTER DATABASE [Playground] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Playground] SET QUOTED_IDENTIFIER ON
GO
ALTER DATABASE [Playground] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Playground] SET  DISABLE_BROKER
GO
ALTER DATABASE [Playground] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Playground] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Playground] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Playground] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Playground] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Playground] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Playground] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Playground] SET  READ_WRITE
GO
ALTER DATABASE [Playground] SET RECOVERY FULL
GO
ALTER DATABASE [Playground] SET  MULTI_USER
GO
ALTER DATABASE [Playground] SET PAGE_VERIFY NONE
GO
ALTER DATABASE [Playground] SET DB_CHAINING OFF
GO
USE [Playground]
GO
/****** Object:  Table [dbo].[Sites]    Script Date: 10/31/2010 21:46:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sites](
	[SiteID] [int] IDENTITY(1,1) NOT NULL,
	[SiteName] [varchar](255) NULL,
	[SiteURL] [varchar](500) NULL,
	[SiteDescription] [varchar](max) NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetBySiteId]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Sites table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_GetBySiteId]
(

	@SiteId int   
)
AS


				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Sites]
				WHERE
					[SiteID] = @SiteId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Sites table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Sites]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Sites_Get_List]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Sites table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_Get_List]

AS


				
				SELECT
					[SiteID],
					[SiteName],
					[SiteURL],
					[SiteDescription],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Sites]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Sites_Find]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Sites table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_Find]
(

	@SearchUsingOR bit   = null ,

	@SiteId int   = null ,

	@SiteName varchar (255)  = null ,

	@SiteUrl varchar (500)  = null ,

	@SiteDescription varchar (MAX)  = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteURL]
	, [SiteDescription]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([SiteName] = @SiteName OR @SiteName IS NULL)
	AND ([SiteURL] = @SiteUrl OR @SiteUrl IS NULL)
	AND ([SiteDescription] = @SiteDescription OR @SiteDescription IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiteID]
	, [SiteName]
	, [SiteURL]
	, [SiteDescription]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[Sites]
    WHERE 
	 ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([SiteName] = @SiteName AND @SiteName is not null)
	OR ([SiteURL] = @SiteUrl AND @SiteUrl is not null)
	OR ([SiteDescription] = @SiteDescription AND @SiteDescription is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Sites_Delete]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Sites table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_Delete]
(

	@SiteId int   
)
AS


				DELETE FROM [dbo].[Sites] WITH (ROWLOCK) 
				WHERE
					[SiteID] = @SiteId
GO
/****** Object:  Table [dbo].[SiteWebParts]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteWebParts](
	[SiteWebPartID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[SiteWebPartTypeID] [int] NOT NULL,
	[SiteWebPartHTML] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteWebPartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_Update]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the SiteWebParts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_Update]
(

	@SiteWebPartId int   ,

	@SiteId int   ,

	@SiteWebPartTypeId int   ,

	@SiteWebPartHtml ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SiteWebParts]
				SET
					[SiteID] = @SiteId
					,[SiteWebPartTypeID] = @SiteWebPartTypeId
					,[SiteWebPartHTML] = @SiteWebPartHtml
				WHERE
[SiteWebPartID] = @SiteWebPartId
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_Insert]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the SiteWebParts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_Insert]
(

	@SiteWebPartId int    OUTPUT,

	@SiteId int   ,

	@SiteWebPartTypeId int   ,

	@SiteWebPartHtml ntext   
)
AS


				
				INSERT INTO [dbo].[SiteWebParts]
					(
					[SiteID]
					,[SiteWebPartTypeID]
					,[SiteWebPartHTML]
					)
				VALUES
					(
					@SiteId
					,@SiteWebPartTypeId
					,@SiteWebPartHtml
					)
				
				-- Get the identity value
				SET @SiteWebPartId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_GetBySiteWebPartTypeId]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the SiteWebParts table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_GetBySiteWebPartTypeId]
(

	@SiteWebPartTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteWebPartID],
					[SiteID],
					[SiteWebPartTypeID],
					[SiteWebPartHTML]
				FROM
					[dbo].[SiteWebParts]
				WHERE
					[SiteWebPartTypeID] = @SiteWebPartTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_GetBySiteWebPartId]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the SiteWebParts table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_GetBySiteWebPartId]
(

	@SiteWebPartId int   
)
AS


				SELECT
					[SiteWebPartID],
					[SiteID],
					[SiteWebPartTypeID],
					[SiteWebPartHTML]
				FROM
					[dbo].[SiteWebParts]
				WHERE
					[SiteWebPartID] = @SiteWebPartId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_GetBySiteId]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the SiteWebParts table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[SiteWebPartID],
					[SiteID],
					[SiteWebPartTypeID],
					[SiteWebPartHTML]
				FROM
					[dbo].[SiteWebParts]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_Get_List]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the SiteWebParts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_Get_List]

AS


				
				SELECT
					[SiteWebPartID],
					[SiteID],
					[SiteWebPartTypeID],
					[SiteWebPartHTML]
				FROM
					[dbo].[SiteWebParts]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_Find]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the SiteWebParts table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_Find]
(

	@SearchUsingOR bit   = null ,

	@SiteWebPartId int   = null ,

	@SiteId int   = null ,

	@SiteWebPartTypeId int   = null ,

	@SiteWebPartHtml ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiteWebPartID]
	, [SiteID]
	, [SiteWebPartTypeID]
	, [SiteWebPartHTML]
    FROM
	[dbo].[SiteWebParts]
    WHERE 
	 ([SiteWebPartID] = @SiteWebPartId OR @SiteWebPartId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([SiteWebPartTypeID] = @SiteWebPartTypeId OR @SiteWebPartTypeId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiteWebPartID]
	, [SiteID]
	, [SiteWebPartTypeID]
	, [SiteWebPartHTML]
    FROM
	[dbo].[SiteWebParts]
    WHERE 
	 ([SiteWebPartID] = @SiteWebPartId AND @SiteWebPartId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([SiteWebPartTypeID] = @SiteWebPartTypeId AND @SiteWebPartTypeId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_Delete]    Script Date: 10/31/2010 21:46:48 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the SiteWebParts table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_Delete]
(

	@SiteWebPartId int   
)
AS


				DELETE FROM [dbo].[SiteWebParts] WITH (ROWLOCK) 
				WHERE
					[SiteWebPartID] = @SiteWebPartId
GO
/****** Object:  StoredProcedure [dbo].[Sites_Update]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Sites table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_Update]
(

	@SiteId int   ,

	@SiteName varchar (255)  ,

	@SiteUrl varchar (500)  ,

	@SiteDescription varchar (MAX)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Sites]
				SET
					[SiteName] = @SiteName
					,[SiteURL] = @SiteUrl
					,[SiteDescription] = @SiteDescription
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
				WHERE
[SiteID] = @SiteId
GO
/****** Object:  StoredProcedure [dbo].[Sites_Insert]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Sites table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_Insert]
(

	@SiteId int    OUTPUT,

	@SiteName varchar (255)  ,

	@SiteUrl varchar (500)  ,

	@SiteDescription varchar (MAX)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				INSERT INTO [dbo].[Sites]
					(
					[SiteName]
					,[SiteURL]
					,[SiteDescription]
					,[LastModified]
					,[LastModifiedBy]
					)
				VALUES
					(
					@SiteName
					,@SiteUrl
					,@SiteDescription
					,@LastModified
					,@LastModifiedBy
					)
				
				-- Get the identity value
				SET @SiteId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[Members]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Members](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[Username] [nvarchar](255) NOT NULL,
	[Password] [nvarchar](255) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[EmailAddress] [varchar](255) NOT NULL,
	[Company] [varchar](255) NULL,
	[Position] [varchar](255) NULL,
	[HomePhone] [char](40) NULL,
	[WorkPhone] [char](40) NULL,
	[MobilePhone] [char](40) NULL,
	[Fax] [char](40) NULL,
	[Address1] [nvarchar](500) NULL,
	[Address2] [nvarchar](500) NULL,
	[LocationID] [int] NOT NULL,
	[AreaID] [int] NOT NULL,
	[PreferredCategoryID] [int] NULL,
	[PreferredSubCategoryID] [int] NULL,
	[PreferredSalaryID] [int] NULL,
	[Subscribed] [bit] NOT NULL,
	[MonthlyUpdate] [bit] NOT NULL,
	[ReferringMemberID] [int] NULL,
	[LastModifiedDate] [datetime] NULL,
	[Valid] [bit] NOT NULL,
	[EmailFormat] [int] NOT NULL,
	[LastLogon] [datetime] NULL,
	[DateOfBirth] [smalldatetime] NULL,
	[Gender] [char](1) NULL,
	[Tags] [nvarchar](1000) NULL,
	[Validated] [bit] NOT NULL,
	[MemberURLExtension] [varchar](255) NULL,
	[WebsiteURL] [varchar](500) NULL,
	[AvailabilityID] [int] NULL,
	[AvailabilityFromDate] [smalldatetime] NULL,
	[MySpaceHeading] [ntext] NULL,
	[MySpaceContent] [ntext] NULL,
	[URLReferrer] [varchar](500) NULL,
	[RequiredPasswordChange] [bit] NULL,
	[PreferredJobTitle] [nvarchar](500) NULL,
	[PreferredAvailability] [varchar](500) NULL,
	[PreferredAvailabilityType] [int] NULL,
	[PreferredSalaryFrom] [varchar](100) NULL,
	[PreferredSalaryTo] [varchar](100) NULL,
	[CurrentSalaryFrom] [varchar](100) NULL,
	[CurrentSalaryTo] [varchar](100) NULL,
	[LookingFor] [nvarchar](500) NULL,
	[Experience] [nvarchar](max) NULL,
	[Skills] [nvarchar](max) NULL,
	[Reasons] [nvarchar](max) NULL,
	[Comments] [nvarchar](max) NULL,
	[ProfileType] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Members_GetBySiteId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Members table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberID],
					[SiteID],
					[Username],
					[Password],
					[Title],
					[EmailAddress],
					[Company],
					[Position],
					[HomePhone],
					[WorkPhone],
					[MobilePhone],
					[Fax],
					[Address1],
					[Address2],
					[LocationID],
					[AreaID],
					[PreferredCategoryID],
					[PreferredSubCategoryID],
					[PreferredSalaryID],
					[Subscribed],
					[MonthlyUpdate],
					[ReferringMemberID],
					[LastModifiedDate],
					[Valid],
					[EmailFormat],
					[LastLogon],
					[DateOfBirth],
					[Gender],
					[Tags],
					[Validated],
					[MemberURLExtension],
					[WebsiteURL],
					[AvailabilityID],
					[AvailabilityFromDate],
					[MySpaceHeading],
					[MySpaceContent],
					[URLReferrer],
					[RequiredPasswordChange],
					[PreferredJobTitle],
					[PreferredAvailability],
					[PreferredAvailabilityType],
					[PreferredSalaryFrom],
					[PreferredSalaryTo],
					[CurrentSalaryFrom],
					[CurrentSalaryTo],
					[LookingFor],
					[Experience],
					[Skills],
					[Reasons],
					[Comments],
					[ProfileType]
				FROM
					[dbo].[Members]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Members_GetByMemberId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Members table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_GetByMemberId]
(

	@MemberId int   
)
AS


				SELECT
					[MemberID],
					[SiteID],
					[Username],
					[Password],
					[Title],
					[EmailAddress],
					[Company],
					[Position],
					[HomePhone],
					[WorkPhone],
					[MobilePhone],
					[Fax],
					[Address1],
					[Address2],
					[LocationID],
					[AreaID],
					[PreferredCategoryID],
					[PreferredSubCategoryID],
					[PreferredSalaryID],
					[Subscribed],
					[MonthlyUpdate],
					[ReferringMemberID],
					[LastModifiedDate],
					[Valid],
					[EmailFormat],
					[LastLogon],
					[DateOfBirth],
					[Gender],
					[Tags],
					[Validated],
					[MemberURLExtension],
					[WebsiteURL],
					[AvailabilityID],
					[AvailabilityFromDate],
					[MySpaceHeading],
					[MySpaceContent],
					[URLReferrer],
					[RequiredPasswordChange],
					[PreferredJobTitle],
					[PreferredAvailability],
					[PreferredAvailabilityType],
					[PreferredSalaryFrom],
					[PreferredSalaryTo],
					[CurrentSalaryFrom],
					[CurrentSalaryTo],
					[LookingFor],
					[Experience],
					[Skills],
					[Reasons],
					[Comments],
					[ProfileType]
				FROM
					[dbo].[Members]
				WHERE
					[MemberID] = @MemberId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Members_GetByEmailFormat]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Members table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_GetByEmailFormat]
(

	@EmailFormat int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberID],
					[SiteID],
					[Username],
					[Password],
					[Title],
					[EmailAddress],
					[Company],
					[Position],
					[HomePhone],
					[WorkPhone],
					[MobilePhone],
					[Fax],
					[Address1],
					[Address2],
					[LocationID],
					[AreaID],
					[PreferredCategoryID],
					[PreferredSubCategoryID],
					[PreferredSalaryID],
					[Subscribed],
					[MonthlyUpdate],
					[ReferringMemberID],
					[LastModifiedDate],
					[Valid],
					[EmailFormat],
					[LastLogon],
					[DateOfBirth],
					[Gender],
					[Tags],
					[Validated],
					[MemberURLExtension],
					[WebsiteURL],
					[AvailabilityID],
					[AvailabilityFromDate],
					[MySpaceHeading],
					[MySpaceContent],
					[URLReferrer],
					[RequiredPasswordChange],
					[PreferredJobTitle],
					[PreferredAvailability],
					[PreferredAvailabilityType],
					[PreferredSalaryFrom],
					[PreferredSalaryTo],
					[CurrentSalaryFrom],
					[CurrentSalaryTo],
					[LookingFor],
					[Experience],
					[Skills],
					[Reasons],
					[Comments],
					[ProfileType]
				FROM
					[dbo].[Members]
				WHERE
					[EmailFormat] = @EmailFormat
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Members_Get_List]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Members table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_Get_List]

AS


				
				SELECT
					[MemberID],
					[SiteID],
					[Username],
					[Password],
					[Title],
					[EmailAddress],
					[Company],
					[Position],
					[HomePhone],
					[WorkPhone],
					[MobilePhone],
					[Fax],
					[Address1],
					[Address2],
					[LocationID],
					[AreaID],
					[PreferredCategoryID],
					[PreferredSubCategoryID],
					[PreferredSalaryID],
					[Subscribed],
					[MonthlyUpdate],
					[ReferringMemberID],
					[LastModifiedDate],
					[Valid],
					[EmailFormat],
					[LastLogon],
					[DateOfBirth],
					[Gender],
					[Tags],
					[Validated],
					[MemberURLExtension],
					[WebsiteURL],
					[AvailabilityID],
					[AvailabilityFromDate],
					[MySpaceHeading],
					[MySpaceContent],
					[URLReferrer],
					[RequiredPasswordChange],
					[PreferredJobTitle],
					[PreferredAvailability],
					[PreferredAvailabilityType],
					[PreferredSalaryFrom],
					[PreferredSalaryTo],
					[CurrentSalaryFrom],
					[CurrentSalaryTo],
					[LookingFor],
					[Experience],
					[Skills],
					[Reasons],
					[Comments],
					[ProfileType]
				FROM
					[dbo].[Members]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Members_Find]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Members table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_Find]
(

	@SearchUsingOR bit   = null ,

	@MemberId int   = null ,

	@SiteId int   = null ,

	@Username nvarchar (255)  = null ,

	@Password nvarchar (255)  = null ,

	@Title nvarchar (100)  = null ,

	@EmailAddress varchar (255)  = null ,

	@Company varchar (255)  = null ,

	@Position varchar (255)  = null ,

	@HomePhone char (40)  = null ,

	@WorkPhone char (40)  = null ,

	@MobilePhone char (40)  = null ,

	@Fax char (40)  = null ,

	@Address1 nvarchar (500)  = null ,

	@Address2 nvarchar (500)  = null ,

	@LocationId int   = null ,

	@AreaId int   = null ,

	@PreferredCategoryId int   = null ,

	@PreferredSubCategoryId int   = null ,

	@PreferredSalaryId int   = null ,

	@Subscribed bit   = null ,

	@MonthlyUpdate bit   = null ,

	@ReferringMemberId int   = null ,

	@LastModifiedDate datetime   = null ,

	@Valid bit   = null ,

	@EmailFormat int   = null ,

	@LastLogon datetime   = null ,

	@DateOfBirth smalldatetime   = null ,

	@Gender char (1)  = null ,

	@Tags nvarchar (1000)  = null ,

	@Validated bit   = null ,

	@MemberUrlExtension varchar (255)  = null ,

	@WebsiteUrl varchar (500)  = null ,

	@AvailabilityId int   = null ,

	@AvailabilityFromDate smalldatetime   = null ,

	@MySpaceHeading ntext   = null ,

	@MySpaceContent ntext   = null ,

	@UrlReferrer varchar (500)  = null ,

	@RequiredPasswordChange bit   = null ,

	@PreferredJobTitle nvarchar (500)  = null ,

	@PreferredAvailability varchar (500)  = null ,

	@PreferredAvailabilityType int   = null ,

	@PreferredSalaryFrom varchar (100)  = null ,

	@PreferredSalaryTo varchar (100)  = null ,

	@CurrentSalaryFrom varchar (100)  = null ,

	@CurrentSalaryTo varchar (100)  = null ,

	@LookingFor nvarchar (500)  = null ,

	@Experience nvarchar (MAX)  = null ,

	@Skills nvarchar (MAX)  = null ,

	@Reasons nvarchar (MAX)  = null ,

	@Comments nvarchar (MAX)  = null ,

	@ProfileType varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MemberID]
	, [SiteID]
	, [Username]
	, [Password]
	, [Title]
	, [EmailAddress]
	, [Company]
	, [Position]
	, [HomePhone]
	, [WorkPhone]
	, [MobilePhone]
	, [Fax]
	, [Address1]
	, [Address2]
	, [LocationID]
	, [AreaID]
	, [PreferredCategoryID]
	, [PreferredSubCategoryID]
	, [PreferredSalaryID]
	, [Subscribed]
	, [MonthlyUpdate]
	, [ReferringMemberID]
	, [LastModifiedDate]
	, [Valid]
	, [EmailFormat]
	, [LastLogon]
	, [DateOfBirth]
	, [Gender]
	, [Tags]
	, [Validated]
	, [MemberURLExtension]
	, [WebsiteURL]
	, [AvailabilityID]
	, [AvailabilityFromDate]
	, [MySpaceHeading]
	, [MySpaceContent]
	, [URLReferrer]
	, [RequiredPasswordChange]
	, [PreferredJobTitle]
	, [PreferredAvailability]
	, [PreferredAvailabilityType]
	, [PreferredSalaryFrom]
	, [PreferredSalaryTo]
	, [CurrentSalaryFrom]
	, [CurrentSalaryTo]
	, [LookingFor]
	, [Experience]
	, [Skills]
	, [Reasons]
	, [Comments]
	, [ProfileType]
    FROM
	[dbo].[Members]
    WHERE 
	 ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([Username] = @Username OR @Username IS NULL)
	AND ([Password] = @Password OR @Password IS NULL)
	AND ([Title] = @Title OR @Title IS NULL)
	AND ([EmailAddress] = @EmailAddress OR @EmailAddress IS NULL)
	AND ([Company] = @Company OR @Company IS NULL)
	AND ([Position] = @Position OR @Position IS NULL)
	AND ([HomePhone] = @HomePhone OR @HomePhone IS NULL)
	AND ([WorkPhone] = @WorkPhone OR @WorkPhone IS NULL)
	AND ([MobilePhone] = @MobilePhone OR @MobilePhone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([Address1] = @Address1 OR @Address1 IS NULL)
	AND ([Address2] = @Address2 OR @Address2 IS NULL)
	AND ([LocationID] = @LocationId OR @LocationId IS NULL)
	AND ([AreaID] = @AreaId OR @AreaId IS NULL)
	AND ([PreferredCategoryID] = @PreferredCategoryId OR @PreferredCategoryId IS NULL)
	AND ([PreferredSubCategoryID] = @PreferredSubCategoryId OR @PreferredSubCategoryId IS NULL)
	AND ([PreferredSalaryID] = @PreferredSalaryId OR @PreferredSalaryId IS NULL)
	AND ([Subscribed] = @Subscribed OR @Subscribed IS NULL)
	AND ([MonthlyUpdate] = @MonthlyUpdate OR @MonthlyUpdate IS NULL)
	AND ([ReferringMemberID] = @ReferringMemberId OR @ReferringMemberId IS NULL)
	AND ([LastModifiedDate] = @LastModifiedDate OR @LastModifiedDate IS NULL)
	AND ([Valid] = @Valid OR @Valid IS NULL)
	AND ([EmailFormat] = @EmailFormat OR @EmailFormat IS NULL)
	AND ([LastLogon] = @LastLogon OR @LastLogon IS NULL)
	AND ([DateOfBirth] = @DateOfBirth OR @DateOfBirth IS NULL)
	AND ([Gender] = @Gender OR @Gender IS NULL)
	AND ([Tags] = @Tags OR @Tags IS NULL)
	AND ([Validated] = @Validated OR @Validated IS NULL)
	AND ([MemberURLExtension] = @MemberUrlExtension OR @MemberUrlExtension IS NULL)
	AND ([WebsiteURL] = @WebsiteUrl OR @WebsiteUrl IS NULL)
	AND ([AvailabilityID] = @AvailabilityId OR @AvailabilityId IS NULL)
	AND ([AvailabilityFromDate] = @AvailabilityFromDate OR @AvailabilityFromDate IS NULL)
	AND ([URLReferrer] = @UrlReferrer OR @UrlReferrer IS NULL)
	AND ([RequiredPasswordChange] = @RequiredPasswordChange OR @RequiredPasswordChange IS NULL)
	AND ([PreferredJobTitle] = @PreferredJobTitle OR @PreferredJobTitle IS NULL)
	AND ([PreferredAvailability] = @PreferredAvailability OR @PreferredAvailability IS NULL)
	AND ([PreferredAvailabilityType] = @PreferredAvailabilityType OR @PreferredAvailabilityType IS NULL)
	AND ([PreferredSalaryFrom] = @PreferredSalaryFrom OR @PreferredSalaryFrom IS NULL)
	AND ([PreferredSalaryTo] = @PreferredSalaryTo OR @PreferredSalaryTo IS NULL)
	AND ([CurrentSalaryFrom] = @CurrentSalaryFrom OR @CurrentSalaryFrom IS NULL)
	AND ([CurrentSalaryTo] = @CurrentSalaryTo OR @CurrentSalaryTo IS NULL)
	AND ([LookingFor] = @LookingFor OR @LookingFor IS NULL)
	AND ([Experience] = @Experience OR @Experience IS NULL)
	AND ([Skills] = @Skills OR @Skills IS NULL)
	AND ([Reasons] = @Reasons OR @Reasons IS NULL)
	AND ([Comments] = @Comments OR @Comments IS NULL)
	AND ([ProfileType] = @ProfileType OR @ProfileType IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MemberID]
	, [SiteID]
	, [Username]
	, [Password]
	, [Title]
	, [EmailAddress]
	, [Company]
	, [Position]
	, [HomePhone]
	, [WorkPhone]
	, [MobilePhone]
	, [Fax]
	, [Address1]
	, [Address2]
	, [LocationID]
	, [AreaID]
	, [PreferredCategoryID]
	, [PreferredSubCategoryID]
	, [PreferredSalaryID]
	, [Subscribed]
	, [MonthlyUpdate]
	, [ReferringMemberID]
	, [LastModifiedDate]
	, [Valid]
	, [EmailFormat]
	, [LastLogon]
	, [DateOfBirth]
	, [Gender]
	, [Tags]
	, [Validated]
	, [MemberURLExtension]
	, [WebsiteURL]
	, [AvailabilityID]
	, [AvailabilityFromDate]
	, [MySpaceHeading]
	, [MySpaceContent]
	, [URLReferrer]
	, [RequiredPasswordChange]
	, [PreferredJobTitle]
	, [PreferredAvailability]
	, [PreferredAvailabilityType]
	, [PreferredSalaryFrom]
	, [PreferredSalaryTo]
	, [CurrentSalaryFrom]
	, [CurrentSalaryTo]
	, [LookingFor]
	, [Experience]
	, [Skills]
	, [Reasons]
	, [Comments]
	, [ProfileType]
    FROM
	[dbo].[Members]
    WHERE 
	 ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([Username] = @Username AND @Username is not null)
	OR ([Password] = @Password AND @Password is not null)
	OR ([Title] = @Title AND @Title is not null)
	OR ([EmailAddress] = @EmailAddress AND @EmailAddress is not null)
	OR ([Company] = @Company AND @Company is not null)
	OR ([Position] = @Position AND @Position is not null)
	OR ([HomePhone] = @HomePhone AND @HomePhone is not null)
	OR ([WorkPhone] = @WorkPhone AND @WorkPhone is not null)
	OR ([MobilePhone] = @MobilePhone AND @MobilePhone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([Address1] = @Address1 AND @Address1 is not null)
	OR ([Address2] = @Address2 AND @Address2 is not null)
	OR ([LocationID] = @LocationId AND @LocationId is not null)
	OR ([AreaID] = @AreaId AND @AreaId is not null)
	OR ([PreferredCategoryID] = @PreferredCategoryId AND @PreferredCategoryId is not null)
	OR ([PreferredSubCategoryID] = @PreferredSubCategoryId AND @PreferredSubCategoryId is not null)
	OR ([PreferredSalaryID] = @PreferredSalaryId AND @PreferredSalaryId is not null)
	OR ([Subscribed] = @Subscribed AND @Subscribed is not null)
	OR ([MonthlyUpdate] = @MonthlyUpdate AND @MonthlyUpdate is not null)
	OR ([ReferringMemberID] = @ReferringMemberId AND @ReferringMemberId is not null)
	OR ([LastModifiedDate] = @LastModifiedDate AND @LastModifiedDate is not null)
	OR ([Valid] = @Valid AND @Valid is not null)
	OR ([EmailFormat] = @EmailFormat AND @EmailFormat is not null)
	OR ([LastLogon] = @LastLogon AND @LastLogon is not null)
	OR ([DateOfBirth] = @DateOfBirth AND @DateOfBirth is not null)
	OR ([Gender] = @Gender AND @Gender is not null)
	OR ([Tags] = @Tags AND @Tags is not null)
	OR ([Validated] = @Validated AND @Validated is not null)
	OR ([MemberURLExtension] = @MemberUrlExtension AND @MemberUrlExtension is not null)
	OR ([WebsiteURL] = @WebsiteUrl AND @WebsiteUrl is not null)
	OR ([AvailabilityID] = @AvailabilityId AND @AvailabilityId is not null)
	OR ([AvailabilityFromDate] = @AvailabilityFromDate AND @AvailabilityFromDate is not null)
	OR ([URLReferrer] = @UrlReferrer AND @UrlReferrer is not null)
	OR ([RequiredPasswordChange] = @RequiredPasswordChange AND @RequiredPasswordChange is not null)
	OR ([PreferredJobTitle] = @PreferredJobTitle AND @PreferredJobTitle is not null)
	OR ([PreferredAvailability] = @PreferredAvailability AND @PreferredAvailability is not null)
	OR ([PreferredAvailabilityType] = @PreferredAvailabilityType AND @PreferredAvailabilityType is not null)
	OR ([PreferredSalaryFrom] = @PreferredSalaryFrom AND @PreferredSalaryFrom is not null)
	OR ([PreferredSalaryTo] = @PreferredSalaryTo AND @PreferredSalaryTo is not null)
	OR ([CurrentSalaryFrom] = @CurrentSalaryFrom AND @CurrentSalaryFrom is not null)
	OR ([CurrentSalaryTo] = @CurrentSalaryTo AND @CurrentSalaryTo is not null)
	OR ([LookingFor] = @LookingFor AND @LookingFor is not null)
	OR ([Experience] = @Experience AND @Experience is not null)
	OR ([Skills] = @Skills AND @Skills is not null)
	OR ([Reasons] = @Reasons AND @Reasons is not null)
	OR ([Comments] = @Comments AND @Comments is not null)
	OR ([ProfileType] = @ProfileType AND @ProfileType is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Members_Delete]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Members table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_Delete]
(

	@MemberId int   
)
AS


				DELETE FROM [dbo].[Members] WITH (ROWLOCK) 
				WHERE
					[MemberID] = @MemberId
GO
/****** Object:  Table [dbo].[GlobalSettings]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GlobalSettings](
	[SiteID] [int] NOT NULL,
	[ParameterName] [varchar](255) NOT NULL,
	[ParameterValue] [varchar](255) NOT NULL,
	[LastModified] [datetime] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_GlobalSettings] ON [dbo].[GlobalSettings] 
(
	[SiteID] ASC,
	[ParameterName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[NewsCategoryID] [int] NOT NULL,
	[Subject] [nvarchar](255) NOT NULL,
	[Content] [ntext] NULL,
	[PostDate] [smalldatetime] NOT NULL,
	[Valid] [bit] NULL,
	[Sequence] [int] NULL,
	[LastModified] [datetime] NULL,
	[LastModifiedBy] [int] NOT NULL,
	[SearchField] [image] NULL,
	[Tags] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[News_GetBySiteId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the News table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[NewsID],
					[SiteID],
					[NewsCategoryID],
					[Subject],
					[Content],
					[PostDate],
					[Valid],
					[Sequence],
					[LastModified],
					[LastModifiedBy],
					[SearchField],
					[Tags]
				FROM
					[dbo].[News]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[News_GetByNewsId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the News table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_GetByNewsId]
(

	@NewsId int   
)
AS


				SELECT
					[NewsID],
					[SiteID],
					[NewsCategoryID],
					[Subject],
					[Content],
					[PostDate],
					[Valid],
					[Sequence],
					[LastModified],
					[LastModifiedBy],
					[SearchField],
					[Tags]
				FROM
					[dbo].[News]
				WHERE
					[NewsID] = @NewsId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[News_GetByNewsCategoryId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the News table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_GetByNewsCategoryId]
(

	@NewsCategoryId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[NewsID],
					[SiteID],
					[NewsCategoryID],
					[Subject],
					[Content],
					[PostDate],
					[Valid],
					[Sequence],
					[LastModified],
					[LastModifiedBy],
					[SearchField],
					[Tags]
				FROM
					[dbo].[News]
				WHERE
					[NewsCategoryID] = @NewsCategoryId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[News_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the News table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[NewsID],
					[SiteID],
					[NewsCategoryID],
					[Subject],
					[Content],
					[PostDate],
					[Valid],
					[Sequence],
					[LastModified],
					[LastModifiedBy],
					[SearchField],
					[Tags]
				FROM
					[dbo].[News]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[News_Get_List]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the News table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_Get_List]

AS


				
				SELECT
					[NewsID],
					[SiteID],
					[NewsCategoryID],
					[Subject],
					[Content],
					[PostDate],
					[Valid],
					[Sequence],
					[LastModified],
					[LastModifiedBy],
					[SearchField],
					[Tags]
				FROM
					[dbo].[News]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[News_Find]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the News table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_Find]
(

	@SearchUsingOR bit   = null ,

	@NewsId int   = null ,

	@SiteId int   = null ,

	@NewsCategoryId int   = null ,

	@Subject nvarchar (255)  = null ,

	@Content ntext   = null ,

	@PostDate smalldatetime   = null ,

	@Valid bit   = null ,

	@Sequence int   = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null ,

	@SearchField image   = null ,

	@Tags nvarchar (250)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [NewsID]
	, [SiteID]
	, [NewsCategoryID]
	, [Subject]
	, [Content]
	, [PostDate]
	, [Valid]
	, [Sequence]
	, [LastModified]
	, [LastModifiedBy]
	, [SearchField]
	, [Tags]
    FROM
	[dbo].[News]
    WHERE 
	 ([NewsID] = @NewsId OR @NewsId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([NewsCategoryID] = @NewsCategoryId OR @NewsCategoryId IS NULL)
	AND ([Subject] = @Subject OR @Subject IS NULL)
	AND ([PostDate] = @PostDate OR @PostDate IS NULL)
	AND ([Valid] = @Valid OR @Valid IS NULL)
	AND ([Sequence] = @Sequence OR @Sequence IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
	AND ([Tags] = @Tags OR @Tags IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [NewsID]
	, [SiteID]
	, [NewsCategoryID]
	, [Subject]
	, [Content]
	, [PostDate]
	, [Valid]
	, [Sequence]
	, [LastModified]
	, [LastModifiedBy]
	, [SearchField]
	, [Tags]
    FROM
	[dbo].[News]
    WHERE 
	 ([NewsID] = @NewsId AND @NewsId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([NewsCategoryID] = @NewsCategoryId AND @NewsCategoryId is not null)
	OR ([Subject] = @Subject AND @Subject is not null)
	OR ([PostDate] = @PostDate AND @PostDate is not null)
	OR ([Valid] = @Valid AND @Valid is not null)
	OR ([Sequence] = @Sequence AND @Sequence is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	OR ([Tags] = @Tags AND @Tags is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[News_Delete]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the News table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_Delete]
(

	@NewsId int   
)
AS


				DELETE FROM [dbo].[News] WITH (ROWLOCK) 
				WHERE
					[NewsID] = @NewsId
GO
/****** Object:  StoredProcedure [dbo].[Members_Update]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Members table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_Update]
(

	@MemberId int   ,

	@SiteId int   ,

	@Username nvarchar (255)  ,

	@Password nvarchar (255)  ,

	@Title nvarchar (100)  ,

	@EmailAddress varchar (255)  ,

	@Company varchar (255)  ,

	@Position varchar (255)  ,

	@HomePhone char (40)  ,

	@WorkPhone char (40)  ,

	@MobilePhone char (40)  ,

	@Fax char (40)  ,

	@Address1 nvarchar (500)  ,

	@Address2 nvarchar (500)  ,

	@LocationId int   ,

	@AreaId int   ,

	@PreferredCategoryId int   ,

	@PreferredSubCategoryId int   ,

	@PreferredSalaryId int   ,

	@Subscribed bit   ,

	@MonthlyUpdate bit   ,

	@ReferringMemberId int   ,

	@LastModifiedDate datetime   ,

	@Valid bit   ,

	@EmailFormat int   ,

	@LastLogon datetime   ,

	@DateOfBirth smalldatetime   ,

	@Gender char (1)  ,

	@Tags nvarchar (1000)  ,

	@Validated bit   ,

	@MemberUrlExtension varchar (255)  ,

	@WebsiteUrl varchar (500)  ,

	@AvailabilityId int   ,

	@AvailabilityFromDate smalldatetime   ,

	@MySpaceHeading ntext   ,

	@MySpaceContent ntext   ,

	@UrlReferrer varchar (500)  ,

	@RequiredPasswordChange bit   ,

	@PreferredJobTitle nvarchar (500)  ,

	@PreferredAvailability varchar (500)  ,

	@PreferredAvailabilityType int   ,

	@PreferredSalaryFrom varchar (100)  ,

	@PreferredSalaryTo varchar (100)  ,

	@CurrentSalaryFrom varchar (100)  ,

	@CurrentSalaryTo varchar (100)  ,

	@LookingFor nvarchar (500)  ,

	@Experience nvarchar (MAX)  ,

	@Skills nvarchar (MAX)  ,

	@Reasons nvarchar (MAX)  ,

	@Comments nvarchar (MAX)  ,

	@ProfileType varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Members]
				SET
					[SiteID] = @SiteId
					,[Username] = @Username
					,[Password] = @Password
					,[Title] = @Title
					,[EmailAddress] = @EmailAddress
					,[Company] = @Company
					,[Position] = @Position
					,[HomePhone] = @HomePhone
					,[WorkPhone] = @WorkPhone
					,[MobilePhone] = @MobilePhone
					,[Fax] = @Fax
					,[Address1] = @Address1
					,[Address2] = @Address2
					,[LocationID] = @LocationId
					,[AreaID] = @AreaId
					,[PreferredCategoryID] = @PreferredCategoryId
					,[PreferredSubCategoryID] = @PreferredSubCategoryId
					,[PreferredSalaryID] = @PreferredSalaryId
					,[Subscribed] = @Subscribed
					,[MonthlyUpdate] = @MonthlyUpdate
					,[ReferringMemberID] = @ReferringMemberId
					,[LastModifiedDate] = @LastModifiedDate
					,[Valid] = @Valid
					,[EmailFormat] = @EmailFormat
					,[LastLogon] = @LastLogon
					,[DateOfBirth] = @DateOfBirth
					,[Gender] = @Gender
					,[Tags] = @Tags
					,[Validated] = @Validated
					,[MemberURLExtension] = @MemberUrlExtension
					,[WebsiteURL] = @WebsiteUrl
					,[AvailabilityID] = @AvailabilityId
					,[AvailabilityFromDate] = @AvailabilityFromDate
					,[MySpaceHeading] = @MySpaceHeading
					,[MySpaceContent] = @MySpaceContent
					,[URLReferrer] = @UrlReferrer
					,[RequiredPasswordChange] = @RequiredPasswordChange
					,[PreferredJobTitle] = @PreferredJobTitle
					,[PreferredAvailability] = @PreferredAvailability
					,[PreferredAvailabilityType] = @PreferredAvailabilityType
					,[PreferredSalaryFrom] = @PreferredSalaryFrom
					,[PreferredSalaryTo] = @PreferredSalaryTo
					,[CurrentSalaryFrom] = @CurrentSalaryFrom
					,[CurrentSalaryTo] = @CurrentSalaryTo
					,[LookingFor] = @LookingFor
					,[Experience] = @Experience
					,[Skills] = @Skills
					,[Reasons] = @Reasons
					,[Comments] = @Comments
					,[ProfileType] = @ProfileType
				WHERE
[MemberID] = @MemberId
GO
/****** Object:  StoredProcedure [dbo].[Members_Insert]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Members table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_Insert]
(

	@MemberId int    OUTPUT,

	@SiteId int   ,

	@Username nvarchar (255)  ,

	@Password nvarchar (255)  ,

	@Title nvarchar (100)  ,

	@EmailAddress varchar (255)  ,

	@Company varchar (255)  ,

	@Position varchar (255)  ,

	@HomePhone char (40)  ,

	@WorkPhone char (40)  ,

	@MobilePhone char (40)  ,

	@Fax char (40)  ,

	@Address1 nvarchar (500)  ,

	@Address2 nvarchar (500)  ,

	@LocationId int   ,

	@AreaId int   ,

	@PreferredCategoryId int   ,

	@PreferredSubCategoryId int   ,

	@PreferredSalaryId int   ,

	@Subscribed bit   ,

	@MonthlyUpdate bit   ,

	@ReferringMemberId int   ,

	@LastModifiedDate datetime   ,

	@Valid bit   ,

	@EmailFormat int   ,

	@LastLogon datetime   ,

	@DateOfBirth smalldatetime   ,

	@Gender char (1)  ,

	@Tags nvarchar (1000)  ,

	@Validated bit   ,

	@MemberUrlExtension varchar (255)  ,

	@WebsiteUrl varchar (500)  ,

	@AvailabilityId int   ,

	@AvailabilityFromDate smalldatetime   ,

	@MySpaceHeading ntext   ,

	@MySpaceContent ntext   ,

	@UrlReferrer varchar (500)  ,

	@RequiredPasswordChange bit   ,

	@PreferredJobTitle nvarchar (500)  ,

	@PreferredAvailability varchar (500)  ,

	@PreferredAvailabilityType int   ,

	@PreferredSalaryFrom varchar (100)  ,

	@PreferredSalaryTo varchar (100)  ,

	@CurrentSalaryFrom varchar (100)  ,

	@CurrentSalaryTo varchar (100)  ,

	@LookingFor nvarchar (500)  ,

	@Experience nvarchar (MAX)  ,

	@Skills nvarchar (MAX)  ,

	@Reasons nvarchar (MAX)  ,

	@Comments nvarchar (MAX)  ,

	@ProfileType varchar (255)  
)
AS


				
				INSERT INTO [dbo].[Members]
					(
					[SiteID]
					,[Username]
					,[Password]
					,[Title]
					,[EmailAddress]
					,[Company]
					,[Position]
					,[HomePhone]
					,[WorkPhone]
					,[MobilePhone]
					,[Fax]
					,[Address1]
					,[Address2]
					,[LocationID]
					,[AreaID]
					,[PreferredCategoryID]
					,[PreferredSubCategoryID]
					,[PreferredSalaryID]
					,[Subscribed]
					,[MonthlyUpdate]
					,[ReferringMemberID]
					,[LastModifiedDate]
					,[Valid]
					,[EmailFormat]
					,[LastLogon]
					,[DateOfBirth]
					,[Gender]
					,[Tags]
					,[Validated]
					,[MemberURLExtension]
					,[WebsiteURL]
					,[AvailabilityID]
					,[AvailabilityFromDate]
					,[MySpaceHeading]
					,[MySpaceContent]
					,[URLReferrer]
					,[RequiredPasswordChange]
					,[PreferredJobTitle]
					,[PreferredAvailability]
					,[PreferredAvailabilityType]
					,[PreferredSalaryFrom]
					,[PreferredSalaryTo]
					,[CurrentSalaryFrom]
					,[CurrentSalaryTo]
					,[LookingFor]
					,[Experience]
					,[Skills]
					,[Reasons]
					,[Comments]
					,[ProfileType]
					)
				VALUES
					(
					@SiteId
					,@Username
					,@Password
					,@Title
					,@EmailAddress
					,@Company
					,@Position
					,@HomePhone
					,@WorkPhone
					,@MobilePhone
					,@Fax
					,@Address1
					,@Address2
					,@LocationId
					,@AreaId
					,@PreferredCategoryId
					,@PreferredSubCategoryId
					,@PreferredSalaryId
					,@Subscribed
					,@MonthlyUpdate
					,@ReferringMemberId
					,@LastModifiedDate
					,@Valid
					,@EmailFormat
					,@LastLogon
					,@DateOfBirth
					,@Gender
					,@Tags
					,@Validated
					,@MemberUrlExtension
					,@WebsiteUrl
					,@AvailabilityId
					,@AvailabilityFromDate
					,@MySpaceHeading
					,@MySpaceContent
					,@UrlReferrer
					,@RequiredPasswordChange
					,@PreferredJobTitle
					,@PreferredAvailability
					,@PreferredAvailabilityType
					,@PreferredSalaryFrom
					,@PreferredSalaryTo
					,@CurrentSalaryFrom
					,@CurrentSalaryTo
					,@LookingFor
					,@Experience
					,@Skills
					,@Reasons
					,@Comments
					,@ProfileType
					)
				
				-- Get the identity value
				SET @MemberId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[NewsCategories]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewsCategories](
	[NewsCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[NewsCategoryName] [nvarchar](500) NULL,
	[SiteID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[NewsCategoryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_Update]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the NewsCategories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_Update]
(

	@NewsCategoryId int   ,

	@NewsCategoryName nvarchar (500)  ,

	@SiteId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[NewsCategories]
				SET
					[NewsCategoryName] = @NewsCategoryName
					,[SiteID] = @SiteId
				WHERE
[NewsCategoryID] = @NewsCategoryId
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_Insert]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the NewsCategories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_Insert]
(

	@NewsCategoryId int    OUTPUT,

	@NewsCategoryName nvarchar (500)  ,

	@SiteId int   
)
AS


				
				INSERT INTO [dbo].[NewsCategories]
					(
					[NewsCategoryName]
					,[SiteID]
					)
				VALUES
					(
					@NewsCategoryName
					,@SiteId
					)
				
				-- Get the identity value
				SET @NewsCategoryId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_GetBySiteId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the NewsCategories table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[NewsCategoryID],
					[NewsCategoryName],
					[SiteID]
				FROM
					[dbo].[NewsCategories]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_GetByNewsCategoryId]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the NewsCategories table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_GetByNewsCategoryId]
(

	@NewsCategoryId int   
)
AS


				SELECT
					[NewsCategoryID],
					[NewsCategoryName],
					[SiteID]
				FROM
					[dbo].[NewsCategories]
				WHERE
					[NewsCategoryID] = @NewsCategoryId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_Get_List]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the NewsCategories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_Get_List]

AS


				
				SELECT
					[NewsCategoryID],
					[NewsCategoryName],
					[SiteID]
				FROM
					[dbo].[NewsCategories]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_Find]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the NewsCategories table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_Find]
(

	@SearchUsingOR bit   = null ,

	@NewsCategoryId int   = null ,

	@NewsCategoryName nvarchar (500)  = null ,

	@SiteId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [NewsCategoryID]
	, [NewsCategoryName]
	, [SiteID]
    FROM
	[dbo].[NewsCategories]
    WHERE 
	 ([NewsCategoryID] = @NewsCategoryId OR @NewsCategoryId IS NULL)
	AND ([NewsCategoryName] = @NewsCategoryName OR @NewsCategoryName IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [NewsCategoryID]
	, [NewsCategoryName]
	, [SiteID]
    FROM
	[dbo].[NewsCategories]
    WHERE 
	 ([NewsCategoryID] = @NewsCategoryId AND @NewsCategoryId is not null)
	OR ([NewsCategoryName] = @NewsCategoryName AND @NewsCategoryName is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_Delete]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the NewsCategories table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_Delete]
(

	@NewsCategoryId int   
)
AS


				DELETE FROM [dbo].[NewsCategories] WITH (ROWLOCK) 
				WHERE
					[NewsCategoryID] = @NewsCategoryId
GO
/****** Object:  StoredProcedure [dbo].[News_Update]    Script Date: 10/31/2010 21:46:49 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the News table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_Update]
(

	@NewsId int   ,

	@SiteId int   ,

	@NewsCategoryId int   ,

	@Subject nvarchar (255)  ,

	@Content ntext   ,

	@PostDate smalldatetime   ,

	@Valid bit   ,

	@Sequence int   ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@SearchField image   ,

	@Tags nvarchar (250)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[News]
				SET
					[SiteID] = @SiteId
					,[NewsCategoryID] = @NewsCategoryId
					,[Subject] = @Subject
					,[Content] = @Content
					,[PostDate] = @PostDate
					,[Valid] = @Valid
					,[Sequence] = @Sequence
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
					,[SearchField] = @SearchField
					,[Tags] = @Tags
				WHERE
[NewsID] = @NewsId
GO
/****** Object:  StoredProcedure [dbo].[News_Insert]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the News table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_Insert]
(

	@NewsId int    OUTPUT,

	@SiteId int   ,

	@NewsCategoryId int   ,

	@Subject nvarchar (255)  ,

	@Content ntext   ,

	@PostDate smalldatetime   ,

	@Valid bit   ,

	@Sequence int   ,

	@LastModified datetime   ,

	@LastModifiedBy int   ,

	@SearchField image   ,

	@Tags nvarchar (250)  
)
AS


				
				INSERT INTO [dbo].[News]
					(
					[SiteID]
					,[NewsCategoryID]
					,[Subject]
					,[Content]
					,[PostDate]
					,[Valid]
					,[Sequence]
					,[LastModified]
					,[LastModifiedBy]
					,[SearchField]
					,[Tags]
					)
				VALUES
					(
					@SiteId
					,@NewsCategoryId
					,@Subject
					,@Content
					,@PostDate
					,@Valid
					,@Sequence
					,@LastModified
					,@LastModifiedBy
					,@SearchField
					,@Tags
					)
				
				-- Get the identity value
				SET @NewsId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[Folders]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Folders](
	[FolderID] [int] IDENTITY(1,1) NOT NULL,
	[ParentFolderID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[FolderName] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FolderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Folders] ON [dbo].[Folders] 
(
	[SiteID] ASC,
	[FolderID] ASC,
	[ParentFolderID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Folders_Update]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Folders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_Update]
(

	@FolderId int   ,

	@ParentFolderId int   ,

	@SiteId int   ,

	@FolderName nvarchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Folders]
				SET
					[ParentFolderID] = @ParentFolderId
					,[SiteID] = @SiteId
					,[FolderName] = @FolderName
				WHERE
[FolderID] = @FolderId
GO
/****** Object:  StoredProcedure [dbo].[Folders_Insert]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Folders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_Insert]
(

	@FolderId int    OUTPUT,

	@ParentFolderId int   ,

	@SiteId int   ,

	@FolderName nvarchar (255)  
)
AS


				
				INSERT INTO [dbo].[Folders]
					(
					[ParentFolderID]
					,[SiteID]
					,[FolderName]
					)
				VALUES
					(
					@ParentFolderId
					,@SiteId
					,@FolderName
					)
				
				-- Get the identity value
				SET @FolderId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Folders_GetBySiteIdFolderIdParentFolderId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Folders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_GetBySiteIdFolderIdParentFolderId]
(

	@SiteId int   ,

	@FolderId int   ,

	@ParentFolderId int   
)
AS


				SELECT
					[FolderID],
					[ParentFolderID],
					[SiteID],
					[FolderName]
				FROM
					[dbo].[Folders]
				WHERE
					[SiteID] = @SiteId
					AND [FolderID] = @FolderId
					AND [ParentFolderID] = @ParentFolderId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Folders_GetBySiteId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Folders table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[FolderID],
					[ParentFolderID],
					[SiteID],
					[FolderName]
				FROM
					[dbo].[Folders]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Folders_GetByFolderId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Folders table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_GetByFolderId]
(

	@FolderId int   
)
AS


				SELECT
					[FolderID],
					[ParentFolderID],
					[SiteID],
					[FolderName]
				FROM
					[dbo].[Folders]
				WHERE
					[FolderID] = @FolderId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Folders_Get_List]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Folders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_Get_List]

AS


				
				SELECT
					[FolderID],
					[ParentFolderID],
					[SiteID],
					[FolderName]
				FROM
					[dbo].[Folders]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Folders_Find]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Folders table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_Find]
(

	@SearchUsingOR bit   = null ,

	@FolderId int   = null ,

	@ParentFolderId int   = null ,

	@SiteId int   = null ,

	@FolderName nvarchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FolderID]
	, [ParentFolderID]
	, [SiteID]
	, [FolderName]
    FROM
	[dbo].[Folders]
    WHERE 
	 ([FolderID] = @FolderId OR @FolderId IS NULL)
	AND ([ParentFolderID] = @ParentFolderId OR @ParentFolderId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([FolderName] = @FolderName OR @FolderName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FolderID]
	, [ParentFolderID]
	, [SiteID]
	, [FolderName]
    FROM
	[dbo].[Folders]
    WHERE 
	 ([FolderID] = @FolderId AND @FolderId is not null)
	OR ([ParentFolderID] = @ParentFolderId AND @ParentFolderId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([FolderName] = @FolderName AND @FolderName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Folders_Delete]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Folders table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_Delete]
(

	@FolderId int   
)
AS


				DELETE FROM [dbo].[Folders] WITH (ROWLOCK) 
				WHERE
					[FolderID] = @FolderId
GO
/****** Object:  Table [dbo].[MemberFiles]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberFiles](
	[MemberFileID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[MemberFileTypeID] [int] NOT NULL,
	[MemberFileName] [nvarchar](500) NOT NULL,
	[MemberFileTitle] [nvarchar](500) NOT NULL,
	[LastModifiedDate] [datetime] NOT NULL,
	[PrivacyLevelID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberFileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_MemberFiles] ON [dbo].[MemberFiles] 
(
	[MemberID] ASC,
	[MemberFileName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Update]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the MemberFiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_Update]
(

	@MemberFileId int   ,

	@MemberId int   ,

	@MemberFileTypeId int   ,

	@MemberFileName nvarchar (500)  ,

	@MemberFileTitle nvarchar (500)  ,

	@LastModifiedDate datetime   ,

	@PrivacyLevelId int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[MemberFiles]
				SET
					[MemberID] = @MemberId
					,[MemberFileTypeID] = @MemberFileTypeId
					,[MemberFileName] = @MemberFileName
					,[MemberFileTitle] = @MemberFileTitle
					,[LastModifiedDate] = @LastModifiedDate
					,[PrivacyLevelID] = @PrivacyLevelId
				WHERE
[MemberFileID] = @MemberFileId
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Insert]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the MemberFiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_Insert]
(

	@MemberFileId int    OUTPUT,

	@MemberId int   ,

	@MemberFileTypeId int   ,

	@MemberFileName nvarchar (500)  ,

	@MemberFileTitle nvarchar (500)  ,

	@LastModifiedDate datetime   ,

	@PrivacyLevelId int   
)
AS


				
				INSERT INTO [dbo].[MemberFiles]
					(
					[MemberID]
					,[MemberFileTypeID]
					,[MemberFileName]
					,[MemberFileTitle]
					,[LastModifiedDate]
					,[PrivacyLevelID]
					)
				VALUES
					(
					@MemberId
					,@MemberFileTypeId
					,@MemberFileName
					,@MemberFileTitle
					,@LastModifiedDate
					,@PrivacyLevelId
					)
				
				-- Get the identity value
				SET @MemberFileId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberIdMemberFileName]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberIdMemberFileName]
(

	@MemberId int   ,

	@MemberFileName nvarchar (500)  
)
AS


				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileTitle],
					[LastModifiedDate],
					[PrivacyLevelID]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberID] = @MemberId
					AND [MemberFileName] = @MemberFileName
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberId]
(

	@MemberId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileTitle],
					[LastModifiedDate],
					[PrivacyLevelID]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberID] = @MemberId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberFileTypeId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberFileTypeId]
(

	@MemberFileTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileTitle],
					[LastModifiedDate],
					[PrivacyLevelID]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberFileTypeID] = @MemberFileTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetByMemberFileId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFiles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_GetByMemberFileId]
(

	@MemberFileId int   
)
AS


				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileTitle],
					[LastModifiedDate],
					[PrivacyLevelID]
				FROM
					[dbo].[MemberFiles]
				WHERE
					[MemberFileID] = @MemberFileId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Get_List]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the MemberFiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_Get_List]

AS


				
				SELECT
					[MemberFileID],
					[MemberID],
					[MemberFileTypeID],
					[MemberFileName],
					[MemberFileTitle],
					[LastModifiedDate],
					[PrivacyLevelID]
				FROM
					[dbo].[MemberFiles]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Find]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the MemberFiles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_Find]
(

	@SearchUsingOR bit   = null ,

	@MemberFileId int   = null ,

	@MemberId int   = null ,

	@MemberFileTypeId int   = null ,

	@MemberFileName nvarchar (500)  = null ,

	@MemberFileTitle nvarchar (500)  = null ,

	@LastModifiedDate datetime   = null ,

	@PrivacyLevelId int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MemberFileID]
	, [MemberID]
	, [MemberFileTypeID]
	, [MemberFileName]
	, [MemberFileTitle]
	, [LastModifiedDate]
	, [PrivacyLevelID]
    FROM
	[dbo].[MemberFiles]
    WHERE 
	 ([MemberFileID] = @MemberFileId OR @MemberFileId IS NULL)
	AND ([MemberID] = @MemberId OR @MemberId IS NULL)
	AND ([MemberFileTypeID] = @MemberFileTypeId OR @MemberFileTypeId IS NULL)
	AND ([MemberFileName] = @MemberFileName OR @MemberFileName IS NULL)
	AND ([MemberFileTitle] = @MemberFileTitle OR @MemberFileTitle IS NULL)
	AND ([LastModifiedDate] = @LastModifiedDate OR @LastModifiedDate IS NULL)
	AND ([PrivacyLevelID] = @PrivacyLevelId OR @PrivacyLevelId IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MemberFileID]
	, [MemberID]
	, [MemberFileTypeID]
	, [MemberFileName]
	, [MemberFileTitle]
	, [LastModifiedDate]
	, [PrivacyLevelID]
    FROM
	[dbo].[MemberFiles]
    WHERE 
	 ([MemberFileID] = @MemberFileId AND @MemberFileId is not null)
	OR ([MemberID] = @MemberId AND @MemberId is not null)
	OR ([MemberFileTypeID] = @MemberFileTypeId AND @MemberFileTypeId is not null)
	OR ([MemberFileName] = @MemberFileName AND @MemberFileName is not null)
	OR ([MemberFileTitle] = @MemberFileTitle AND @MemberFileTitle is not null)
	OR ([LastModifiedDate] = @LastModifiedDate AND @LastModifiedDate is not null)
	OR ([PrivacyLevelID] = @PrivacyLevelId AND @PrivacyLevelId is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_Delete]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the MemberFiles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_Delete]
(

	@MemberFileId int   
)
AS


				DELETE FROM [dbo].[MemberFiles] WITH (ROWLOCK) 
				WHERE
					[MemberFileID] = @MemberFileId
GO
/****** Object:  Table [dbo].[Files]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Files](
	[FileID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[FolderID] [int] NOT NULL,
	[FileName] [nvarchar](500) NOT NULL,
	[FileSystemName] [nvarchar](500) NOT NULL,
	[FileTypeID] [int] NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Files] ON [dbo].[Files] 
(
	[FolderID] ASC,
	[SiteID] ASC,
	[FileName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Files_Update]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Files table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_Update]
(

	@FileId int   ,

	@SiteId int   ,

	@FolderId int   ,

	@FileName nvarchar (500)  ,

	@FileSystemName nvarchar (500)  ,

	@FileTypeId int   ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Files]
				SET
					[SiteID] = @SiteId
					,[FolderID] = @FolderId
					,[FileName] = @FileName
					,[FileSystemName] = @FileSystemName
					,[FileTypeID] = @FileTypeId
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
				WHERE
[FileID] = @FileId
GO
/****** Object:  StoredProcedure [dbo].[Files_Insert]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Files table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_Insert]
(

	@FileId int    OUTPUT,

	@SiteId int   ,

	@FolderId int   ,

	@FileName nvarchar (500)  ,

	@FileSystemName nvarchar (500)  ,

	@FileTypeId int   ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				INSERT INTO [dbo].[Files]
					(
					[SiteID]
					,[FolderID]
					,[FileName]
					,[FileSystemName]
					,[FileTypeID]
					,[LastModified]
					,[LastModifiedBy]
					)
				VALUES
					(
					@SiteId
					,@FolderId
					,@FileName
					,@FileSystemName
					,@FileTypeId
					,@LastModified
					,@LastModifiedBy
					)
				
				-- Get the identity value
				SET @FileId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Files_GetBySiteId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Files_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Files_GetByFolderIdSiteIdFileName]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetByFolderIdSiteIdFileName]
(

	@FolderId int   ,

	@SiteId int   ,

	@FileName nvarchar (500)  
)
AS


				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[FolderID] = @FolderId
					AND [SiteID] = @SiteId
					AND [FileName] = @FileName
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Files_GetByFolderId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetByFolderId]
(

	@FolderId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[FolderID] = @FolderId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Files_GetByFileTypeId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetByFileTypeId]
(

	@FileTypeId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[FileTypeID] = @FileTypeId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Files_GetByFileId]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Files table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetByFileId]
(

	@FileId int   
)
AS


				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
				WHERE
					[FileID] = @FileId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Files_Get_List]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Files table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_Get_List]

AS


				
				SELECT
					[FileID],
					[SiteID],
					[FolderID],
					[FileName],
					[FileSystemName],
					[FileTypeID],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[Files]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Files_Find]    Script Date: 10/31/2010 21:46:50 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Files table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_Find]
(

	@SearchUsingOR bit   = null ,

	@FileId int   = null ,

	@SiteId int   = null ,

	@FolderId int   = null ,

	@FileName nvarchar (500)  = null ,

	@FileSystemName nvarchar (500)  = null ,

	@FileTypeId int   = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FileID]
	, [SiteID]
	, [FolderID]
	, [FileName]
	, [FileSystemName]
	, [FileTypeID]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[Files]
    WHERE 
	 ([FileID] = @FileId OR @FileId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([FolderID] = @FolderId OR @FolderId IS NULL)
	AND ([FileName] = @FileName OR @FileName IS NULL)
	AND ([FileSystemName] = @FileSystemName OR @FileSystemName IS NULL)
	AND ([FileTypeID] = @FileTypeId OR @FileTypeId IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FileID]
	, [SiteID]
	, [FolderID]
	, [FileName]
	, [FileSystemName]
	, [FileTypeID]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[Files]
    WHERE 
	 ([FileID] = @FileId AND @FileId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([FolderID] = @FolderId AND @FolderId is not null)
	OR ([FileName] = @FileName AND @FileName is not null)
	OR ([FileSystemName] = @FileSystemName AND @FileSystemName is not null)
	OR ([FileTypeID] = @FileTypeId AND @FileTypeId is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Files_Delete]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Files table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_Delete]
(

	@FileId int   
)
AS


				DELETE FROM [dbo].[Files] WITH (ROWLOCK) 
				WHERE
					[FileID] = @FileId
GO
/****** Object:  Table [dbo].[Enquiries]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Enquiries](
	[EnquiryID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[Name] [nvarchar](500) NOT NULL,
	[Email] [varchar](500) NULL,
	[ContactPhone] [char](40) NULL,
	[Content] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[EnquiryID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_Update]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Enquiries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_Update]
(

	@EnquiryId int   ,

	@SiteId int   ,

	@Name nvarchar (500)  ,

	@Email varchar (500)  ,

	@ContactPhone char (40)  ,

	@Content ntext   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Enquiries]
				SET
					[SiteID] = @SiteId
					,[Name] = @Name
					,[Email] = @Email
					,[ContactPhone] = @ContactPhone
					,[Content] = @Content
				WHERE
[EnquiryID] = @EnquiryId
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_Insert]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Enquiries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_Insert]
(

	@EnquiryId int    OUTPUT,

	@SiteId int   ,

	@Name nvarchar (500)  ,

	@Email varchar (500)  ,

	@ContactPhone char (40)  ,

	@Content ntext   
)
AS


				
				INSERT INTO [dbo].[Enquiries]
					(
					[SiteID]
					,[Name]
					,[Email]
					,[ContactPhone]
					,[Content]
					)
				VALUES
					(
					@SiteId
					,@Name
					,@Email
					,@ContactPhone
					,@Content
					)
				
				-- Get the identity value
				SET @EnquiryId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_GetBySiteId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Enquiries table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[EnquiryID],
					[SiteID],
					[Name],
					[Email],
					[ContactPhone],
					[Content]
				FROM
					[dbo].[Enquiries]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_GetByEnquiryId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Enquiries table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_GetByEnquiryId]
(

	@EnquiryId int   
)
AS


				SELECT
					[EnquiryID],
					[SiteID],
					[Name],
					[Email],
					[ContactPhone],
					[Content]
				FROM
					[dbo].[Enquiries]
				WHERE
					[EnquiryID] = @EnquiryId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_Get_List]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Enquiries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_Get_List]

AS


				
				SELECT
					[EnquiryID],
					[SiteID],
					[Name],
					[Email],
					[ContactPhone],
					[Content]
				FROM
					[dbo].[Enquiries]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_Find]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Enquiries table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_Find]
(

	@SearchUsingOR bit   = null ,

	@EnquiryId int   = null ,

	@SiteId int   = null ,

	@Name nvarchar (500)  = null ,

	@Email varchar (500)  = null ,

	@ContactPhone char (40)  = null ,

	@Content ntext   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EnquiryID]
	, [SiteID]
	, [Name]
	, [Email]
	, [ContactPhone]
	, [Content]
    FROM
	[dbo].[Enquiries]
    WHERE 
	 ([EnquiryID] = @EnquiryId OR @EnquiryId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([Name] = @Name OR @Name IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([ContactPhone] = @ContactPhone OR @ContactPhone IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EnquiryID]
	, [SiteID]
	, [Name]
	, [Email]
	, [ContactPhone]
	, [Content]
    FROM
	[dbo].[Enquiries]
    WHERE 
	 ([EnquiryID] = @EnquiryId AND @EnquiryId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([Name] = @Name AND @Name is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([ContactPhone] = @ContactPhone AND @ContactPhone is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_Delete]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Enquiries table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_Delete]
(

	@EnquiryId int   
)
AS


				DELETE FROM [dbo].[Enquiries] WITH (ROWLOCK) 
				WHERE
					[EnquiryID] = @EnquiryId
GO
/****** Object:  Table [dbo].[DynamicPageTemplates]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicPageTemplates](
	[DynamicPageTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NULL,
	[DynamicPageTemplateName] [nvarchar](500) NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DynamicPageTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPageTemplates table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DynamicPageTemplateID],
					[SiteID],
					[DynamicPageTemplateName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageTemplates]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_GetByDynamicPageTemplateId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPageTemplates table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_GetByDynamicPageTemplateId]
(

	@DynamicPageTemplateId int   
)
AS


				SELECT
					[DynamicPageTemplateID],
					[SiteID],
					[DynamicPageTemplateName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageTemplates]
				WHERE
					[DynamicPageTemplateID] = @DynamicPageTemplateId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_Get_List]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DynamicPageTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_Get_List]

AS


				
				SELECT
					[DynamicPageTemplateID],
					[SiteID],
					[DynamicPageTemplateName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageTemplates]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_Find]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DynamicPageTemplates table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_Find]
(

	@SearchUsingOR bit   = null ,

	@DynamicPageTemplateId int   = null ,

	@SiteId int   = null ,

	@DynamicPageTemplateName nvarchar (500)  = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DynamicPageTemplateID]
	, [SiteID]
	, [DynamicPageTemplateName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPageTemplates]
    WHERE 
	 ([DynamicPageTemplateID] = @DynamicPageTemplateId OR @DynamicPageTemplateId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([DynamicPageTemplateName] = @DynamicPageTemplateName OR @DynamicPageTemplateName IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DynamicPageTemplateID]
	, [SiteID]
	, [DynamicPageTemplateName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPageTemplates]
    WHERE 
	 ([DynamicPageTemplateID] = @DynamicPageTemplateId AND @DynamicPageTemplateId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([DynamicPageTemplateName] = @DynamicPageTemplateName AND @DynamicPageTemplateName is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_Delete]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DynamicPageTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_Delete]
(

	@DynamicPageTemplateId int   
)
AS


				DELETE FROM [dbo].[DynamicPageTemplates] WITH (ROWLOCK) 
				WHERE
					[DynamicPageTemplateID] = @DynamicPageTemplateId
GO
/****** Object:  Table [dbo].[DynamicPageWebPartTemplatesLink]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicPageWebPartTemplatesLink](
	[DynamicPageWebPartTemplateID] [int] NOT NULL,
	[SiteWebPartID] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_DynamicPageWebPartTemplatesLink] ON [dbo].[DynamicPageWebPartTemplatesLink] 
(
	[DynamicPageWebPartTemplateID] ASC,
	[SiteWebPartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DynamicPageWebPartTemplates]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicPageWebPartTemplates](
	[DynamicPageWebPartTemplateID] [int] IDENTITY(1,1) NOT NULL,
	[DynamicPageWebPartName] [nvarchar](255) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DynamicPageWebPartTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_Update]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DynamicPageWebPartTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_Update]
(

	@DynamicPageWebPartTemplateId int   ,

	@DynamicPageWebPartName nvarchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DynamicPageWebPartTemplates]
				SET
					[DynamicPageWebPartName] = @DynamicPageWebPartName
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
				WHERE
[DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_Insert]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DynamicPageWebPartTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_Insert]
(

	@DynamicPageWebPartTemplateId int    OUTPUT,

	@DynamicPageWebPartName nvarchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				INSERT INTO [dbo].[DynamicPageWebPartTemplates]
					(
					[DynamicPageWebPartName]
					,[LastModified]
					,[LastModifiedBy]
					)
				VALUES
					(
					@DynamicPageWebPartName
					,@LastModified
					,@LastModifiedBy
					)
				
				-- Get the identity value
				SET @DynamicPageWebPartTemplateId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPageWebPartTemplates table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DynamicPageWebPartTemplateID],
					[DynamicPageWebPartName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageWebPartTemplates]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPageWebPartTemplates table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_GetByDynamicPageWebPartTemplateId]
(

	@DynamicPageWebPartTemplateId int   
)
AS


				SELECT
					[DynamicPageWebPartTemplateID],
					[DynamicPageWebPartName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageWebPartTemplates]
				WHERE
					[DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_Get_List]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DynamicPageWebPartTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_Get_List]

AS


				
				SELECT
					[DynamicPageWebPartTemplateID],
					[DynamicPageWebPartName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPageWebPartTemplates]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_Find]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DynamicPageWebPartTemplates table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_Find]
(

	@SearchUsingOR bit   = null ,

	@DynamicPageWebPartTemplateId int   = null ,

	@DynamicPageWebPartName nvarchar (255)  = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DynamicPageWebPartTemplateID]
	, [DynamicPageWebPartName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPageWebPartTemplates]
    WHERE 
	 ([DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId OR @DynamicPageWebPartTemplateId IS NULL)
	AND ([DynamicPageWebPartName] = @DynamicPageWebPartName OR @DynamicPageWebPartName IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DynamicPageWebPartTemplateID]
	, [DynamicPageWebPartName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPageWebPartTemplates]
    WHERE 
	 ([DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId AND @DynamicPageWebPartTemplateId is not null)
	OR ([DynamicPageWebPartName] = @DynamicPageWebPartName AND @DynamicPageWebPartName is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_Delete]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DynamicPageWebPartTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_Delete]
(

	@DynamicPageWebPartTemplateId int   
)
AS


				DELETE FROM [dbo].[DynamicPageWebPartTemplates] WITH (ROWLOCK) 
				WHERE
					[DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_Update]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DynamicPageTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_Update]
(

	@DynamicPageTemplateId int   ,

	@SiteId int   ,

	@DynamicPageTemplateName nvarchar (500)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DynamicPageTemplates]
				SET
					[SiteID] = @SiteId
					,[DynamicPageTemplateName] = @DynamicPageTemplateName
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
				WHERE
[DynamicPageTemplateID] = @DynamicPageTemplateId
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_Insert]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DynamicPageTemplates table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_Insert]
(

	@DynamicPageTemplateId int    OUTPUT,

	@SiteId int   ,

	@DynamicPageTemplateName nvarchar (500)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				INSERT INTO [dbo].[DynamicPageTemplates]
					(
					[SiteID]
					,[DynamicPageTemplateName]
					,[LastModified]
					,[LastModifiedBy]
					)
				VALUES
					(
					@SiteId
					,@DynamicPageTemplateName
					,@LastModified
					,@LastModifiedBy
					)
				
				-- Get the identity value
				SET @DynamicPageTemplateId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[AdminUsers]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminUsers](
	[AdminUserID] [int] IDENTITY(1,1) NOT NULL,
	[AdminAdminRoleID] [int] NOT NULL,
	[SiteID] [int] NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[UserPassword] [varchar](255) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[Surname] [nvarchar](500) NOT NULL,
	[Email] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_AdminUsers] ON [dbo].[AdminUsers] 
(
	[SiteID] ASC,
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_GetBySiteIdEmail]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdminUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_GetBySiteIdEmail]
(

	@SiteId int   ,

	@Email varchar (255)  
)
AS


				SELECT
					[AdminUserID],
					[AdminAdminRoleID],
					[SiteID],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email]
				FROM
					[dbo].[AdminUsers]
				WHERE
					[SiteID] = @SiteId
					AND [Email] = @Email
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_GetBySiteId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdminUsers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdminUserID],
					[AdminAdminRoleID],
					[SiteID],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email]
				FROM
					[dbo].[AdminUsers]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_GetByAdminUserId]    Script Date: 10/31/2010 21:46:51 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdminUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_GetByAdminUserId]
(

	@AdminUserId int   
)
AS


				SELECT
					[AdminUserID],
					[AdminAdminRoleID],
					[SiteID],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email]
				FROM
					[dbo].[AdminUsers]
				WHERE
					[AdminUserID] = @AdminUserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_GetByAdminAdminRoleId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdminUsers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_GetByAdminAdminRoleId]
(

	@AdminAdminRoleId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdminUserID],
					[AdminAdminRoleID],
					[SiteID],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email]
				FROM
					[dbo].[AdminUsers]
				WHERE
					[AdminAdminRoleID] = @AdminAdminRoleId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_Get_List]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AdminUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_Get_List]

AS


				
				SELECT
					[AdminUserID],
					[AdminAdminRoleID],
					[SiteID],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email]
				FROM
					[dbo].[AdminUsers]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_Find]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AdminUsers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_Find]
(

	@SearchUsingOR bit   = null ,

	@AdminUserId int   = null ,

	@AdminAdminRoleId int   = null ,

	@SiteId int   = null ,

	@UserName varchar (255)  = null ,

	@UserPassword varchar (255)  = null ,

	@FirstName nvarchar (500)  = null ,

	@Surname nvarchar (500)  = null ,

	@Email varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdminUserID]
	, [AdminAdminRoleID]
	, [SiteID]
	, [UserName]
	, [UserPassword]
	, [FirstName]
	, [Surname]
	, [Email]
    FROM
	[dbo].[AdminUsers]
    WHERE 
	 ([AdminUserID] = @AdminUserId OR @AdminUserId IS NULL)
	AND ([AdminAdminRoleID] = @AdminAdminRoleId OR @AdminAdminRoleId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([UserPassword] = @UserPassword OR @UserPassword IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Surname] = @Surname OR @Surname IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdminUserID]
	, [AdminAdminRoleID]
	, [SiteID]
	, [UserName]
	, [UserPassword]
	, [FirstName]
	, [Surname]
	, [Email]
    FROM
	[dbo].[AdminUsers]
    WHERE 
	 ([AdminUserID] = @AdminUserId AND @AdminUserId is not null)
	OR ([AdminAdminRoleID] = @AdminAdminRoleId AND @AdminAdminRoleId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([UserPassword] = @UserPassword AND @UserPassword is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Surname] = @Surname AND @Surname is not null)
	OR ([Email] = @Email AND @Email is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_Delete]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AdminUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_Delete]
(

	@AdminUserId int   
)
AS


				DELETE FROM [dbo].[AdminUsers] WITH (ROWLOCK) 
				WHERE
					[AdminUserID] = @AdminUserId
GO
/****** Object:  Table [dbo].[Advertisers]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Advertisers](
	[AdvertiserID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NULL,
	[AccountTypeID] [int] NOT NULL,
	[CompanyName] [nvarchar](255) NULL,
	[BusinessNumber] [nvarchar](255) NULL,
	[StreetAddress1] [nvarchar](255) NULL,
	[StreetAddress2] [nvarchar](255) NULL,
	[LastModified] [datetime] NOT NULL,
	[AccountStatusID] [int] NOT NULL,
	[PostalAddress1] [nvarchar](255) NULL,
	[PostalAddress2] [nvarchar](255) NULL,
	[WebAddress] [varchar](255) NULL,
	[NoOfEmployees] [varchar](10) NULL,
	[BusinessTypeID] [int] NULL,
	[FirstApprovedDate] [smalldatetime] NULL,
	[Profile] [ntext] NULL,
	[CharityNumber] [varchar](50) NULL,
	[SearchField] [image] NULL,
	[FreeTrialStartDate] [smalldatetime] NULL,
	[FreeTrialEndDate] [smalldatetime] NULL,
	[AccountsPayableEmail] [varchar](255) NULL,
	[RequireLogonForExternalApplication] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdvertiserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetBySiteId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AccountTypeID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[AccountStatusID],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[BusinessTypeID],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication]
				FROM
					[dbo].[Advertisers]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetByAdvertiserId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Advertisers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SELECT
					[AdvertiserID],
					[SiteID],
					[AccountTypeID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[AccountStatusID],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[BusinessTypeID],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication]
				FROM
					[dbo].[Advertisers]
				WHERE
					[AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Get_List]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Advertisers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_Get_List]

AS


				
				SELECT
					[AdvertiserID],
					[SiteID],
					[AccountTypeID],
					[CompanyName],
					[BusinessNumber],
					[StreetAddress1],
					[StreetAddress2],
					[LastModified],
					[AccountStatusID],
					[PostalAddress1],
					[PostalAddress2],
					[WebAddress],
					[NoOfEmployees],
					[BusinessTypeID],
					[FirstApprovedDate],
					[Profile],
					[CharityNumber],
					[SearchField],
					[FreeTrialStartDate],
					[FreeTrialEndDate],
					[AccountsPayableEmail],
					[RequireLogonForExternalApplication]
				FROM
					[dbo].[Advertisers]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Find]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Advertisers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_Find]
(

	@SearchUsingOR bit   = null ,

	@AdvertiserId int   = null ,

	@SiteId int   = null ,

	@AccountTypeId int   = null ,

	@CompanyName nvarchar (255)  = null ,

	@BusinessNumber nvarchar (255)  = null ,

	@StreetAddress1 nvarchar (255)  = null ,

	@StreetAddress2 nvarchar (255)  = null ,

	@LastModified datetime   = null ,

	@AccountStatusId int   = null ,

	@PostalAddress1 nvarchar (255)  = null ,

	@PostalAddress2 nvarchar (255)  = null ,

	@WebAddress varchar (255)  = null ,

	@NoOfEmployees varchar (10)  = null ,

	@BusinessTypeId int   = null ,

	@FirstApprovedDate smalldatetime   = null ,

	@Profile ntext   = null ,

	@CharityNumber varchar (50)  = null ,

	@SearchField image   = null ,

	@FreeTrialStartDate smalldatetime   = null ,

	@FreeTrialEndDate smalldatetime   = null ,

	@AccountsPayableEmail varchar (255)  = null ,

	@RequireLogonForExternalApplication bit   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvertiserID]
	, [SiteID]
	, [AccountTypeID]
	, [CompanyName]
	, [BusinessNumber]
	, [StreetAddress1]
	, [StreetAddress2]
	, [LastModified]
	, [AccountStatusID]
	, [PostalAddress1]
	, [PostalAddress2]
	, [WebAddress]
	, [NoOfEmployees]
	, [BusinessTypeID]
	, [FirstApprovedDate]
	, [Profile]
	, [CharityNumber]
	, [SearchField]
	, [FreeTrialStartDate]
	, [FreeTrialEndDate]
	, [AccountsPayableEmail]
	, [RequireLogonForExternalApplication]
    FROM
	[dbo].[Advertisers]
    WHERE 
	 ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([AccountTypeID] = @AccountTypeId OR @AccountTypeId IS NULL)
	AND ([CompanyName] = @CompanyName OR @CompanyName IS NULL)
	AND ([BusinessNumber] = @BusinessNumber OR @BusinessNumber IS NULL)
	AND ([StreetAddress1] = @StreetAddress1 OR @StreetAddress1 IS NULL)
	AND ([StreetAddress2] = @StreetAddress2 OR @StreetAddress2 IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([AccountStatusID] = @AccountStatusId OR @AccountStatusId IS NULL)
	AND ([PostalAddress1] = @PostalAddress1 OR @PostalAddress1 IS NULL)
	AND ([PostalAddress2] = @PostalAddress2 OR @PostalAddress2 IS NULL)
	AND ([WebAddress] = @WebAddress OR @WebAddress IS NULL)
	AND ([NoOfEmployees] = @NoOfEmployees OR @NoOfEmployees IS NULL)
	AND ([BusinessTypeID] = @BusinessTypeId OR @BusinessTypeId IS NULL)
	AND ([FirstApprovedDate] = @FirstApprovedDate OR @FirstApprovedDate IS NULL)
	AND ([CharityNumber] = @CharityNumber OR @CharityNumber IS NULL)
	AND ([FreeTrialStartDate] = @FreeTrialStartDate OR @FreeTrialStartDate IS NULL)
	AND ([FreeTrialEndDate] = @FreeTrialEndDate OR @FreeTrialEndDate IS NULL)
	AND ([AccountsPayableEmail] = @AccountsPayableEmail OR @AccountsPayableEmail IS NULL)
	AND ([RequireLogonForExternalApplication] = @RequireLogonForExternalApplication OR @RequireLogonForExternalApplication IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvertiserID]
	, [SiteID]
	, [AccountTypeID]
	, [CompanyName]
	, [BusinessNumber]
	, [StreetAddress1]
	, [StreetAddress2]
	, [LastModified]
	, [AccountStatusID]
	, [PostalAddress1]
	, [PostalAddress2]
	, [WebAddress]
	, [NoOfEmployees]
	, [BusinessTypeID]
	, [FirstApprovedDate]
	, [Profile]
	, [CharityNumber]
	, [SearchField]
	, [FreeTrialStartDate]
	, [FreeTrialEndDate]
	, [AccountsPayableEmail]
	, [RequireLogonForExternalApplication]
    FROM
	[dbo].[Advertisers]
    WHERE 
	 ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([AccountTypeID] = @AccountTypeId AND @AccountTypeId is not null)
	OR ([CompanyName] = @CompanyName AND @CompanyName is not null)
	OR ([BusinessNumber] = @BusinessNumber AND @BusinessNumber is not null)
	OR ([StreetAddress1] = @StreetAddress1 AND @StreetAddress1 is not null)
	OR ([StreetAddress2] = @StreetAddress2 AND @StreetAddress2 is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([AccountStatusID] = @AccountStatusId AND @AccountStatusId is not null)
	OR ([PostalAddress1] = @PostalAddress1 AND @PostalAddress1 is not null)
	OR ([PostalAddress2] = @PostalAddress2 AND @PostalAddress2 is not null)
	OR ([WebAddress] = @WebAddress AND @WebAddress is not null)
	OR ([NoOfEmployees] = @NoOfEmployees AND @NoOfEmployees is not null)
	OR ([BusinessTypeID] = @BusinessTypeId AND @BusinessTypeId is not null)
	OR ([FirstApprovedDate] = @FirstApprovedDate AND @FirstApprovedDate is not null)
	OR ([CharityNumber] = @CharityNumber AND @CharityNumber is not null)
	OR ([FreeTrialStartDate] = @FreeTrialStartDate AND @FreeTrialStartDate is not null)
	OR ([FreeTrialEndDate] = @FreeTrialEndDate AND @FreeTrialEndDate is not null)
	OR ([AccountsPayableEmail] = @AccountsPayableEmail AND @AccountsPayableEmail is not null)
	OR ([RequireLogonForExternalApplication] = @RequireLogonForExternalApplication AND @RequireLogonForExternalApplication is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Delete]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Advertisers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_Delete]
(

	@AdvertiserId int   
)
AS


				DELETE FROM [dbo].[Advertisers] WITH (ROWLOCK) 
				WHERE
					[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_Update]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AdminUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_Update]
(

	@AdminUserId int   ,

	@AdminAdminRoleId int   ,

	@SiteId int   ,

	@UserName varchar (255)  ,

	@UserPassword varchar (255)  ,

	@FirstName nvarchar (500)  ,

	@Surname nvarchar (500)  ,

	@Email varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AdminUsers]
				SET
					[AdminAdminRoleID] = @AdminAdminRoleId
					,[SiteID] = @SiteId
					,[UserName] = @UserName
					,[UserPassword] = @UserPassword
					,[FirstName] = @FirstName
					,[Surname] = @Surname
					,[Email] = @Email
				WHERE
[AdminUserID] = @AdminUserId
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_Insert]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AdminUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_Insert]
(

	@AdminUserId int    OUTPUT,

	@AdminAdminRoleId int   ,

	@SiteId int   ,

	@UserName varchar (255)  ,

	@UserPassword varchar (255)  ,

	@FirstName nvarchar (500)  ,

	@Surname nvarchar (500)  ,

	@Email varchar (255)  
)
AS


				
				INSERT INTO [dbo].[AdminUsers]
					(
					[AdminAdminRoleID]
					,[SiteID]
					,[UserName]
					,[UserPassword]
					,[FirstName]
					,[Surname]
					,[Email]
					)
				VALUES
					(
					@AdminAdminRoleId
					,@SiteId
					,@UserName
					,@UserPassword
					,@FirstName
					,@Surname
					,@Email
					)
				
				-- Get the identity value
				SET @AdminUserId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[AdvertiserUsers]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdvertiserUsers](
	[AdvertiserUserID] [int] IDENTITY(1,1) NOT NULL,
	[AdvertiserID] [int] NOT NULL,
	[PrimaryAccount] [bit] NOT NULL,
	[UserName] [varchar](255) NOT NULL,
	[UserPassword] [varchar](255) NOT NULL,
	[FirstName] [nvarchar](500) NOT NULL,
	[Surname] [nvarchar](500) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[ApplicationEmailAddress] [varchar](255) NULL,
	[Phone] [char](40) NULL,
	[Fax] [char](40) NULL,
	[AccountStatus] [int] NULL,
	[Newsletter] [bit] NOT NULL,
	[NewsletterFormat] [int] NOT NULL,
	[EmailFormat] [int] NOT NULL,
	[Validated] [bit] NULL,
	[ValidateGUID] [uniqueidentifier] NULL,
	[Description] [ntext] NULL,
	[LastLoginDate] [datetime] NULL,
	[LastModified] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AdvertiserUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_AdvertiserUsers] ON [dbo].[AdvertiserUsers] 
(
	[UserName] ASC,
	[AdvertiserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetByUserNameAdvertiserId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByUserNameAdvertiserId]
(

	@UserName varchar (255)  ,

	@AdvertiserId int   
)
AS


				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
				WHERE
					[UserName] = @UserName
					AND [AdvertiserID] = @AdvertiserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetByNewsletterFormat]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserUsers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByNewsletterFormat]
(

	@NewsletterFormat int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
				WHERE
					[NewsletterFormat] = @NewsletterFormat
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetByEmailFormat]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserUsers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByEmailFormat]
(

	@EmailFormat int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
				WHERE
					[EmailFormat] = @EmailFormat
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetByAdvertiserUserId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserUsers table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByAdvertiserUserId]
(

	@AdvertiserUserId int   
)
AS


				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
				WHERE
					[AdvertiserUserID] = @AdvertiserUserId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetByAdvertiserId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdvertiserUsers table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetByAdvertiserId]
(

	@AdvertiserId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
				WHERE
					[AdvertiserID] = @AdvertiserId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_Get_List]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AdvertiserUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_Get_List]

AS


				
				SELECT
					[AdvertiserUserID],
					[AdvertiserID],
					[PrimaryAccount],
					[UserName],
					[UserPassword],
					[FirstName],
					[Surname],
					[Email],
					[ApplicationEmailAddress],
					[Phone],
					[Fax],
					[AccountStatus],
					[Newsletter],
					[NewsletterFormat],
					[EmailFormat],
					[Validated],
					[ValidateGUID],
					[Description],
					[LastLoginDate],
					[LastModified]
				FROM
					[dbo].[AdvertiserUsers]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_Find]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AdvertiserUsers table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_Find]
(

	@SearchUsingOR bit   = null ,

	@AdvertiserUserId int   = null ,

	@AdvertiserId int   = null ,

	@PrimaryAccount bit   = null ,

	@UserName varchar (255)  = null ,

	@UserPassword varchar (255)  = null ,

	@FirstName nvarchar (500)  = null ,

	@Surname nvarchar (500)  = null ,

	@Email varchar (255)  = null ,

	@ApplicationEmailAddress varchar (255)  = null ,

	@Phone char (40)  = null ,

	@Fax char (40)  = null ,

	@AccountStatus int   = null ,

	@Newsletter bit   = null ,

	@NewsletterFormat int   = null ,

	@EmailFormat int   = null ,

	@Validated bit   = null ,

	@ValidateGuid uniqueidentifier   = null ,

	@Description ntext   = null ,

	@LastLoginDate datetime   = null ,

	@LastModified datetime   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdvertiserUserID]
	, [AdvertiserID]
	, [PrimaryAccount]
	, [UserName]
	, [UserPassword]
	, [FirstName]
	, [Surname]
	, [Email]
	, [ApplicationEmailAddress]
	, [Phone]
	, [Fax]
	, [AccountStatus]
	, [Newsletter]
	, [NewsletterFormat]
	, [EmailFormat]
	, [Validated]
	, [ValidateGUID]
	, [Description]
	, [LastLoginDate]
	, [LastModified]
    FROM
	[dbo].[AdvertiserUsers]
    WHERE 
	 ([AdvertiserUserID] = @AdvertiserUserId OR @AdvertiserUserId IS NULL)
	AND ([AdvertiserID] = @AdvertiserId OR @AdvertiserId IS NULL)
	AND ([PrimaryAccount] = @PrimaryAccount OR @PrimaryAccount IS NULL)
	AND ([UserName] = @UserName OR @UserName IS NULL)
	AND ([UserPassword] = @UserPassword OR @UserPassword IS NULL)
	AND ([FirstName] = @FirstName OR @FirstName IS NULL)
	AND ([Surname] = @Surname OR @Surname IS NULL)
	AND ([Email] = @Email OR @Email IS NULL)
	AND ([ApplicationEmailAddress] = @ApplicationEmailAddress OR @ApplicationEmailAddress IS NULL)
	AND ([Phone] = @Phone OR @Phone IS NULL)
	AND ([Fax] = @Fax OR @Fax IS NULL)
	AND ([AccountStatus] = @AccountStatus OR @AccountStatus IS NULL)
	AND ([Newsletter] = @Newsletter OR @Newsletter IS NULL)
	AND ([NewsletterFormat] = @NewsletterFormat OR @NewsletterFormat IS NULL)
	AND ([EmailFormat] = @EmailFormat OR @EmailFormat IS NULL)
	AND ([Validated] = @Validated OR @Validated IS NULL)
	AND ([ValidateGUID] = @ValidateGuid OR @ValidateGuid IS NULL)
	AND ([LastLoginDate] = @LastLoginDate OR @LastLoginDate IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdvertiserUserID]
	, [AdvertiserID]
	, [PrimaryAccount]
	, [UserName]
	, [UserPassword]
	, [FirstName]
	, [Surname]
	, [Email]
	, [ApplicationEmailAddress]
	, [Phone]
	, [Fax]
	, [AccountStatus]
	, [Newsletter]
	, [NewsletterFormat]
	, [EmailFormat]
	, [Validated]
	, [ValidateGUID]
	, [Description]
	, [LastLoginDate]
	, [LastModified]
    FROM
	[dbo].[AdvertiserUsers]
    WHERE 
	 ([AdvertiserUserID] = @AdvertiserUserId AND @AdvertiserUserId is not null)
	OR ([AdvertiserID] = @AdvertiserId AND @AdvertiserId is not null)
	OR ([PrimaryAccount] = @PrimaryAccount AND @PrimaryAccount is not null)
	OR ([UserName] = @UserName AND @UserName is not null)
	OR ([UserPassword] = @UserPassword AND @UserPassword is not null)
	OR ([FirstName] = @FirstName AND @FirstName is not null)
	OR ([Surname] = @Surname AND @Surname is not null)
	OR ([Email] = @Email AND @Email is not null)
	OR ([ApplicationEmailAddress] = @ApplicationEmailAddress AND @ApplicationEmailAddress is not null)
	OR ([Phone] = @Phone AND @Phone is not null)
	OR ([Fax] = @Fax AND @Fax is not null)
	OR ([AccountStatus] = @AccountStatus AND @AccountStatus is not null)
	OR ([Newsletter] = @Newsletter AND @Newsletter is not null)
	OR ([NewsletterFormat] = @NewsletterFormat AND @NewsletterFormat is not null)
	OR ([EmailFormat] = @EmailFormat AND @EmailFormat is not null)
	OR ([Validated] = @Validated AND @Validated is not null)
	OR ([ValidateGUID] = @ValidateGuid AND @ValidateGuid is not null)
	OR ([LastLoginDate] = @LastLoginDate AND @LastLoginDate is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_Delete]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AdvertiserUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_Delete]
(

	@AdvertiserUserId int   
)
AS


				DELETE FROM [dbo].[AdvertiserUsers] WITH (ROWLOCK) 
				WHERE
					[AdvertiserUserID] = @AdvertiserUserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Update]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Advertisers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_Update]
(

	@AdvertiserId int   ,

	@SiteId int   ,

	@AccountTypeId int   ,

	@CompanyName nvarchar (255)  ,

	@BusinessNumber nvarchar (255)  ,

	@StreetAddress1 nvarchar (255)  ,

	@StreetAddress2 nvarchar (255)  ,

	@LastModified datetime   ,

	@AccountStatusId int   ,

	@PostalAddress1 nvarchar (255)  ,

	@PostalAddress2 nvarchar (255)  ,

	@WebAddress varchar (255)  ,

	@NoOfEmployees varchar (10)  ,

	@BusinessTypeId int   ,

	@FirstApprovedDate smalldatetime   ,

	@Profile ntext   ,

	@CharityNumber varchar (50)  ,

	@SearchField image   ,

	@FreeTrialStartDate smalldatetime   ,

	@FreeTrialEndDate smalldatetime   ,

	@AccountsPayableEmail varchar (255)  ,

	@RequireLogonForExternalApplication bit   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Advertisers]
				SET
					[SiteID] = @SiteId
					,[AccountTypeID] = @AccountTypeId
					,[CompanyName] = @CompanyName
					,[BusinessNumber] = @BusinessNumber
					,[StreetAddress1] = @StreetAddress1
					,[StreetAddress2] = @StreetAddress2
					,[LastModified] = @LastModified
					,[AccountStatusID] = @AccountStatusId
					,[PostalAddress1] = @PostalAddress1
					,[PostalAddress2] = @PostalAddress2
					,[WebAddress] = @WebAddress
					,[NoOfEmployees] = @NoOfEmployees
					,[BusinessTypeID] = @BusinessTypeId
					,[FirstApprovedDate] = @FirstApprovedDate
					,[Profile] = @Profile
					,[CharityNumber] = @CharityNumber
					,[SearchField] = @SearchField
					,[FreeTrialStartDate] = @FreeTrialStartDate
					,[FreeTrialEndDate] = @FreeTrialEndDate
					,[AccountsPayableEmail] = @AccountsPayableEmail
					,[RequireLogonForExternalApplication] = @RequireLogonForExternalApplication
				WHERE
[AdvertiserID] = @AdvertiserId
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_Insert]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Advertisers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_Insert]
(

	@AdvertiserId int    OUTPUT,

	@SiteId int   ,

	@AccountTypeId int   ,

	@CompanyName nvarchar (255)  ,

	@BusinessNumber nvarchar (255)  ,

	@StreetAddress1 nvarchar (255)  ,

	@StreetAddress2 nvarchar (255)  ,

	@LastModified datetime   ,

	@AccountStatusId int   ,

	@PostalAddress1 nvarchar (255)  ,

	@PostalAddress2 nvarchar (255)  ,

	@WebAddress varchar (255)  ,

	@NoOfEmployees varchar (10)  ,

	@BusinessTypeId int   ,

	@FirstApprovedDate smalldatetime   ,

	@Profile ntext   ,

	@CharityNumber varchar (50)  ,

	@SearchField image   ,

	@FreeTrialStartDate smalldatetime   ,

	@FreeTrialEndDate smalldatetime   ,

	@AccountsPayableEmail varchar (255)  ,

	@RequireLogonForExternalApplication bit   
)
AS


				
				INSERT INTO [dbo].[Advertisers]
					(
					[SiteID]
					,[AccountTypeID]
					,[CompanyName]
					,[BusinessNumber]
					,[StreetAddress1]
					,[StreetAddress2]
					,[LastModified]
					,[AccountStatusID]
					,[PostalAddress1]
					,[PostalAddress2]
					,[WebAddress]
					,[NoOfEmployees]
					,[BusinessTypeID]
					,[FirstApprovedDate]
					,[Profile]
					,[CharityNumber]
					,[SearchField]
					,[FreeTrialStartDate]
					,[FreeTrialEndDate]
					,[AccountsPayableEmail]
					,[RequireLogonForExternalApplication]
					)
				VALUES
					(
					@SiteId
					,@AccountTypeId
					,@CompanyName
					,@BusinessNumber
					,@StreetAddress1
					,@StreetAddress2
					,@LastModified
					,@AccountStatusId
					,@PostalAddress1
					,@PostalAddress2
					,@WebAddress
					,@NoOfEmployees
					,@BusinessTypeId
					,@FirstApprovedDate
					,@Profile
					,@CharityNumber
					,@SearchField
					,@FreeTrialStartDate
					,@FreeTrialEndDate
					,@AccountsPayableEmail
					,@RequireLogonForExternalApplication
					)
				
				-- Get the identity value
				SET @AdvertiserId = SCOPE_IDENTITY()
GO
/****** Object:  Table [dbo].[DynamicPagesLinkCategories]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicPagesLinkCategories](
	[DynamicPageParentID] [int] NOT NULL,
	[DynamicPageID] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_DynamicPagesLinkCategories] ON [dbo].[DynamicPagesLinkCategories] 
(
	[DynamicPageParentID] ASC,
	[DynamicPageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DynamicPageShell]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DynamicPageShell](
	[DynamicPageTemplateID] [int] NOT NULL,
	[DynamicPageID] [int] NOT NULL
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_DynamicPageShell] ON [dbo].[DynamicPageShell] 
(
	[DynamicPageTemplateID] ASC,
	[DynamicPageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DynamicPages]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DynamicPages](
	[DynamicPageID] [int] IDENTITY(1,1) NOT NULL,
	[SiteID] [int] NOT NULL,
	[ParentDynamicPageID] [int] NOT NULL,
	[PageName] [varchar](255) NOT NULL,
	[PageTitle] [varchar](255) NOT NULL,
	[PageContent] [ntext] NOT NULL,
	[DynamicPageWebPartTemplateID] [int] NULL,
	[HyperLink] [varchar](255) NOT NULL,
	[Valid] [bit] NOT NULL,
	[OpenInNewWindow] [bit] NOT NULL,
	[Sequence] [int] NOT NULL,
	[FullScreen] [bit] NOT NULL,
	[OnTopNav] [bit] NOT NULL,
	[OnLeftNav] [bit] NOT NULL,
	[OnBottomNav] [bit] NOT NULL,
	[OnSiteMap] [bit] NOT NULL,
	[Searchable] [bit] NOT NULL,
	[SearchField] [image] NULL,
	[SearchFieldExtension] [varchar](8) NOT NULL,
	[MetaKeywords] [varchar](255) NOT NULL,
	[MetaDescription] [varchar](512) NOT NULL,
	[PageFriendlyName] [varchar](255) NOT NULL,
	[LastModified] [datetime] NOT NULL,
	[LastModifiedBy] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DynamicPageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_DynamicPages] ON [dbo].[DynamicPages] 
(
	[SiteID] ASC,
	[PageName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_Update]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the DynamicPages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_Update]
(

	@DynamicPageId int   ,

	@SiteId int   ,

	@ParentDynamicPageId int   ,

	@PageName varchar (255)  ,

	@PageTitle varchar (255)  ,

	@PageContent ntext   ,

	@DynamicPageWebPartTemplateId int   ,

	@HyperLink varchar (255)  ,

	@Valid bit   ,

	@OpenInNewWindow bit   ,

	@Sequence int   ,

	@FullScreen bit   ,

	@OnTopNav bit   ,

	@OnLeftNav bit   ,

	@OnBottomNav bit   ,

	@OnSiteMap bit   ,

	@Searchable bit   ,

	@SearchField image   ,

	@SearchFieldExtension varchar (8)  ,

	@MetaKeywords varchar (255)  ,

	@MetaDescription varchar (512)  ,

	@PageFriendlyName varchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[DynamicPages]
				SET
					[SiteID] = @SiteId
					,[ParentDynamicPageID] = @ParentDynamicPageId
					,[PageName] = @PageName
					,[PageTitle] = @PageTitle
					,[PageContent] = @PageContent
					,[DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId
					,[HyperLink] = @HyperLink
					,[Valid] = @Valid
					,[OpenInNewWindow] = @OpenInNewWindow
					,[Sequence] = @Sequence
					,[FullScreen] = @FullScreen
					,[OnTopNav] = @OnTopNav
					,[OnLeftNav] = @OnLeftNav
					,[OnBottomNav] = @OnBottomNav
					,[OnSiteMap] = @OnSiteMap
					,[Searchable] = @Searchable
					,[SearchField] = @SearchField
					,[SearchFieldExtension] = @SearchFieldExtension
					,[MetaKeywords] = @MetaKeywords
					,[MetaDescription] = @MetaDescription
					,[PageFriendlyName] = @PageFriendlyName
					,[LastModified] = @LastModified
					,[LastModifiedBy] = @LastModifiedBy
				WHERE
[DynamicPageID] = @DynamicPageId
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_Insert]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the DynamicPages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_Insert]
(

	@DynamicPageId int    OUTPUT,

	@SiteId int   ,

	@ParentDynamicPageId int   ,

	@PageName varchar (255)  ,

	@PageTitle varchar (255)  ,

	@PageContent ntext   ,

	@DynamicPageWebPartTemplateId int   ,

	@HyperLink varchar (255)  ,

	@Valid bit   ,

	@OpenInNewWindow bit   ,

	@Sequence int   ,

	@FullScreen bit   ,

	@OnTopNav bit   ,

	@OnLeftNav bit   ,

	@OnBottomNav bit   ,

	@OnSiteMap bit   ,

	@Searchable bit   ,

	@SearchField image   ,

	@SearchFieldExtension varchar (8)  ,

	@MetaKeywords varchar (255)  ,

	@MetaDescription varchar (512)  ,

	@PageFriendlyName varchar (255)  ,

	@LastModified datetime   ,

	@LastModifiedBy int   
)
AS


				
				INSERT INTO [dbo].[DynamicPages]
					(
					[SiteID]
					,[ParentDynamicPageID]
					,[PageName]
					,[PageTitle]
					,[PageContent]
					,[DynamicPageWebPartTemplateID]
					,[HyperLink]
					,[Valid]
					,[OpenInNewWindow]
					,[Sequence]
					,[FullScreen]
					,[OnTopNav]
					,[OnLeftNav]
					,[OnBottomNav]
					,[OnSiteMap]
					,[Searchable]
					,[SearchField]
					,[SearchFieldExtension]
					,[MetaKeywords]
					,[MetaDescription]
					,[PageFriendlyName]
					,[LastModified]
					,[LastModifiedBy]
					)
				VALUES
					(
					@SiteId
					,@ParentDynamicPageId
					,@PageName
					,@PageTitle
					,@PageContent
					,@DynamicPageWebPartTemplateId
					,@HyperLink
					,@Valid
					,@OpenInNewWindow
					,@Sequence
					,@FullScreen
					,@OnTopNav
					,@OnLeftNav
					,@OnBottomNav
					,@OnSiteMap
					,@Searchable
					,@SearchField
					,@SearchFieldExtension
					,@MetaKeywords
					,@MetaDescription
					,@PageFriendlyName
					,@LastModified
					,@LastModifiedBy
					)
				
				-- Get the identity value
				SET @DynamicPageId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetBySiteIdPageName]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPages table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetBySiteIdPageName]
(

	@SiteId int   ,

	@PageName varchar (255)  
)
AS


				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
				WHERE
					[SiteID] = @SiteId
					AND [PageName] = @PageName
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetBySiteId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPages table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetBySiteId]
(

	@SiteId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
				WHERE
					[SiteID] = @SiteId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetByLastModifiedBy]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPages table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetByLastModifiedBy]
(

	@LastModifiedBy int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
				WHERE
					[LastModifiedBy] = @LastModifiedBy
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetByDynamicPageWebPartTemplateId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPages table through a foreign key
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetByDynamicPageWebPartTemplateId]
(

	@DynamicPageWebPartTemplateId int   
)
AS


				SET ANSI_NULLS OFF
				
				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
				WHERE
					[DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId
				
				SELECT @@ROWCOUNT
				SET ANSI_NULLS ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetByDynamicPageId]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the DynamicPages table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetByDynamicPageId]
(

	@DynamicPageId int   
)
AS


				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
				WHERE
					[DynamicPageID] = @DynamicPageId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_Get_List]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the DynamicPages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_Get_List]

AS


				
				SELECT
					[DynamicPageID],
					[SiteID],
					[ParentDynamicPageID],
					[PageName],
					[PageTitle],
					[PageContent],
					[DynamicPageWebPartTemplateID],
					[HyperLink],
					[Valid],
					[OpenInNewWindow],
					[Sequence],
					[FullScreen],
					[OnTopNav],
					[OnLeftNav],
					[OnBottomNav],
					[OnSiteMap],
					[Searchable],
					[SearchField],
					[SearchFieldExtension],
					[MetaKeywords],
					[MetaDescription],
					[PageFriendlyName],
					[LastModified],
					[LastModifiedBy]
				FROM
					[dbo].[DynamicPages]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_Find]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the DynamicPages table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_Find]
(

	@SearchUsingOR bit   = null ,

	@DynamicPageId int   = null ,

	@SiteId int   = null ,

	@ParentDynamicPageId int   = null ,

	@PageName varchar (255)  = null ,

	@PageTitle varchar (255)  = null ,

	@PageContent ntext   = null ,

	@DynamicPageWebPartTemplateId int   = null ,

	@HyperLink varchar (255)  = null ,

	@Valid bit   = null ,

	@OpenInNewWindow bit   = null ,

	@Sequence int   = null ,

	@FullScreen bit   = null ,

	@OnTopNav bit   = null ,

	@OnLeftNav bit   = null ,

	@OnBottomNav bit   = null ,

	@OnSiteMap bit   = null ,

	@Searchable bit   = null ,

	@SearchField image   = null ,

	@SearchFieldExtension varchar (8)  = null ,

	@MetaKeywords varchar (255)  = null ,

	@MetaDescription varchar (512)  = null ,

	@PageFriendlyName varchar (255)  = null ,

	@LastModified datetime   = null ,

	@LastModifiedBy int   = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [DynamicPageID]
	, [SiteID]
	, [ParentDynamicPageID]
	, [PageName]
	, [PageTitle]
	, [PageContent]
	, [DynamicPageWebPartTemplateID]
	, [HyperLink]
	, [Valid]
	, [OpenInNewWindow]
	, [Sequence]
	, [FullScreen]
	, [OnTopNav]
	, [OnLeftNav]
	, [OnBottomNav]
	, [OnSiteMap]
	, [Searchable]
	, [SearchField]
	, [SearchFieldExtension]
	, [MetaKeywords]
	, [MetaDescription]
	, [PageFriendlyName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPages]
    WHERE 
	 ([DynamicPageID] = @DynamicPageId OR @DynamicPageId IS NULL)
	AND ([SiteID] = @SiteId OR @SiteId IS NULL)
	AND ([ParentDynamicPageID] = @ParentDynamicPageId OR @ParentDynamicPageId IS NULL)
	AND ([PageName] = @PageName OR @PageName IS NULL)
	AND ([PageTitle] = @PageTitle OR @PageTitle IS NULL)
	AND ([DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId OR @DynamicPageWebPartTemplateId IS NULL)
	AND ([HyperLink] = @HyperLink OR @HyperLink IS NULL)
	AND ([Valid] = @Valid OR @Valid IS NULL)
	AND ([OpenInNewWindow] = @OpenInNewWindow OR @OpenInNewWindow IS NULL)
	AND ([Sequence] = @Sequence OR @Sequence IS NULL)
	AND ([FullScreen] = @FullScreen OR @FullScreen IS NULL)
	AND ([OnTopNav] = @OnTopNav OR @OnTopNav IS NULL)
	AND ([OnLeftNav] = @OnLeftNav OR @OnLeftNav IS NULL)
	AND ([OnBottomNav] = @OnBottomNav OR @OnBottomNav IS NULL)
	AND ([OnSiteMap] = @OnSiteMap OR @OnSiteMap IS NULL)
	AND ([Searchable] = @Searchable OR @Searchable IS NULL)
	AND ([SearchFieldExtension] = @SearchFieldExtension OR @SearchFieldExtension IS NULL)
	AND ([MetaKeywords] = @MetaKeywords OR @MetaKeywords IS NULL)
	AND ([MetaDescription] = @MetaDescription OR @MetaDescription IS NULL)
	AND ([PageFriendlyName] = @PageFriendlyName OR @PageFriendlyName IS NULL)
	AND ([LastModified] = @LastModified OR @LastModified IS NULL)
	AND ([LastModifiedBy] = @LastModifiedBy OR @LastModifiedBy IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [DynamicPageID]
	, [SiteID]
	, [ParentDynamicPageID]
	, [PageName]
	, [PageTitle]
	, [PageContent]
	, [DynamicPageWebPartTemplateID]
	, [HyperLink]
	, [Valid]
	, [OpenInNewWindow]
	, [Sequence]
	, [FullScreen]
	, [OnTopNav]
	, [OnLeftNav]
	, [OnBottomNav]
	, [OnSiteMap]
	, [Searchable]
	, [SearchField]
	, [SearchFieldExtension]
	, [MetaKeywords]
	, [MetaDescription]
	, [PageFriendlyName]
	, [LastModified]
	, [LastModifiedBy]
    FROM
	[dbo].[DynamicPages]
    WHERE 
	 ([DynamicPageID] = @DynamicPageId AND @DynamicPageId is not null)
	OR ([SiteID] = @SiteId AND @SiteId is not null)
	OR ([ParentDynamicPageID] = @ParentDynamicPageId AND @ParentDynamicPageId is not null)
	OR ([PageName] = @PageName AND @PageName is not null)
	OR ([PageTitle] = @PageTitle AND @PageTitle is not null)
	OR ([DynamicPageWebPartTemplateID] = @DynamicPageWebPartTemplateId AND @DynamicPageWebPartTemplateId is not null)
	OR ([HyperLink] = @HyperLink AND @HyperLink is not null)
	OR ([Valid] = @Valid AND @Valid is not null)
	OR ([OpenInNewWindow] = @OpenInNewWindow AND @OpenInNewWindow is not null)
	OR ([Sequence] = @Sequence AND @Sequence is not null)
	OR ([FullScreen] = @FullScreen AND @FullScreen is not null)
	OR ([OnTopNav] = @OnTopNav AND @OnTopNav is not null)
	OR ([OnLeftNav] = @OnLeftNav AND @OnLeftNav is not null)
	OR ([OnBottomNav] = @OnBottomNav AND @OnBottomNav is not null)
	OR ([OnSiteMap] = @OnSiteMap AND @OnSiteMap is not null)
	OR ([Searchable] = @Searchable AND @Searchable is not null)
	OR ([SearchFieldExtension] = @SearchFieldExtension AND @SearchFieldExtension is not null)
	OR ([MetaKeywords] = @MetaKeywords AND @MetaKeywords is not null)
	OR ([MetaDescription] = @MetaDescription AND @MetaDescription is not null)
	OR ([PageFriendlyName] = @PageFriendlyName AND @PageFriendlyName is not null)
	OR ([LastModified] = @LastModified AND @LastModified is not null)
	OR ([LastModifiedBy] = @LastModifiedBy AND @LastModifiedBy is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_Delete]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the DynamicPages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_Delete]
(

	@DynamicPageId int   
)
AS


				DELETE FROM [dbo].[DynamicPages] WITH (ROWLOCK) 
				WHERE
					[DynamicPageID] = @DynamicPageId
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_Update]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AdvertiserUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_Update]
(

	@AdvertiserUserId int   ,

	@AdvertiserId int   ,

	@PrimaryAccount bit   ,

	@UserName varchar (255)  ,

	@UserPassword varchar (255)  ,

	@FirstName nvarchar (500)  ,

	@Surname nvarchar (500)  ,

	@Email varchar (255)  ,

	@ApplicationEmailAddress varchar (255)  ,

	@Phone char (40)  ,

	@Fax char (40)  ,

	@AccountStatus int   ,

	@Newsletter bit   ,

	@NewsletterFormat int   ,

	@EmailFormat int   ,

	@Validated bit   ,

	@ValidateGuid uniqueidentifier   ,

	@Description ntext   ,

	@LastLoginDate datetime   ,

	@LastModified datetime   
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AdvertiserUsers]
				SET
					[AdvertiserID] = @AdvertiserId
					,[PrimaryAccount] = @PrimaryAccount
					,[UserName] = @UserName
					,[UserPassword] = @UserPassword
					,[FirstName] = @FirstName
					,[Surname] = @Surname
					,[Email] = @Email
					,[ApplicationEmailAddress] = @ApplicationEmailAddress
					,[Phone] = @Phone
					,[Fax] = @Fax
					,[AccountStatus] = @AccountStatus
					,[Newsletter] = @Newsletter
					,[NewsletterFormat] = @NewsletterFormat
					,[EmailFormat] = @EmailFormat
					,[Validated] = @Validated
					,[ValidateGUID] = @ValidateGuid
					,[Description] = @Description
					,[LastLoginDate] = @LastLoginDate
					,[LastModified] = @LastModified
				WHERE
[AdvertiserUserID] = @AdvertiserUserId
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_Insert]    Script Date: 10/31/2010 21:46:52 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AdvertiserUsers table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_Insert]
(

	@AdvertiserUserId int    OUTPUT,

	@AdvertiserId int   ,

	@PrimaryAccount bit   ,

	@UserName varchar (255)  ,

	@UserPassword varchar (255)  ,

	@FirstName nvarchar (500)  ,

	@Surname nvarchar (500)  ,

	@Email varchar (255)  ,

	@ApplicationEmailAddress varchar (255)  ,

	@Phone char (40)  ,

	@Fax char (40)  ,

	@AccountStatus int   ,

	@Newsletter bit   ,

	@NewsletterFormat int   ,

	@EmailFormat int   ,

	@Validated bit   ,

	@ValidateGuid uniqueidentifier   ,

	@Description ntext   ,

	@LastLoginDate datetime   ,

	@LastModified datetime   
)
AS


				
				INSERT INTO [dbo].[AdvertiserUsers]
					(
					[AdvertiserID]
					,[PrimaryAccount]
					,[UserName]
					,[UserPassword]
					,[FirstName]
					,[Surname]
					,[Email]
					,[ApplicationEmailAddress]
					,[Phone]
					,[Fax]
					,[AccountStatus]
					,[Newsletter]
					,[NewsletterFormat]
					,[EmailFormat]
					,[Validated]
					,[ValidateGUID]
					,[Description]
					,[LastLoginDate]
					,[LastModified]
					)
				VALUES
					(
					@AdvertiserId
					,@PrimaryAccount
					,@UserName
					,@UserPassword
					,@FirstName
					,@Surname
					,@Email
					,@ApplicationEmailAddress
					,@Phone
					,@Fax
					,@AccountStatus
					,@Newsletter
					,@NewsletterFormat
					,@EmailFormat
					,@Validated
					,@ValidateGuid
					,@Description
					,@LastLoginDate
					,@LastModified
					)
				
				-- Get the identity value
				SET @AdvertiserUserId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[AdvertiserUsers_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AdvertiserUsers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdvertiserUsers_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AdvertiserUserID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AdvertiserUserID]'
				SET @SQL = @SQL + ', [AdvertiserID]'
				SET @SQL = @SQL + ', [PrimaryAccount]'
				SET @SQL = @SQL + ', [UserName]'
				SET @SQL = @SQL + ', [UserPassword]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [Surname]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [ApplicationEmailAddress]'
				SET @SQL = @SQL + ', [Phone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [AccountStatus]'
				SET @SQL = @SQL + ', [Newsletter]'
				SET @SQL = @SQL + ', [NewsletterFormat]'
				SET @SQL = @SQL + ', [EmailFormat]'
				SET @SQL = @SQL + ', [Validated]'
				SET @SQL = @SQL + ', [ValidateGUID]'
				SET @SQL = @SQL + ', [Description]'
				SET @SQL = @SQL + ', [LastLoginDate]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ' FROM [dbo].[AdvertiserUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdvertiserUserID],'
				SET @SQL = @SQL + ' [AdvertiserID],'
				SET @SQL = @SQL + ' [PrimaryAccount],'
				SET @SQL = @SQL + ' [UserName],'
				SET @SQL = @SQL + ' [UserPassword],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [Surname],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [ApplicationEmailAddress],'
				SET @SQL = @SQL + ' [Phone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [AccountStatus],'
				SET @SQL = @SQL + ' [Newsletter],'
				SET @SQL = @SQL + ' [NewsletterFormat],'
				SET @SQL = @SQL + ' [EmailFormat],'
				SET @SQL = @SQL + ' [Validated],'
				SET @SQL = @SQL + ' [ValidateGUID],'
				SET @SQL = @SQL + ' [Description],'
				SET @SQL = @SQL + ' [LastLoginDate],'
				SET @SQL = @SQL + ' [LastModified]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AdvertiserUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Advertisers_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Advertisers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Advertisers_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AdvertiserID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AdvertiserID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [AccountTypeID]'
				SET @SQL = @SQL + ', [CompanyName]'
				SET @SQL = @SQL + ', [BusinessNumber]'
				SET @SQL = @SQL + ', [StreetAddress1]'
				SET @SQL = @SQL + ', [StreetAddress2]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [AccountStatusID]'
				SET @SQL = @SQL + ', [PostalAddress1]'
				SET @SQL = @SQL + ', [PostalAddress2]'
				SET @SQL = @SQL + ', [WebAddress]'
				SET @SQL = @SQL + ', [NoOfEmployees]'
				SET @SQL = @SQL + ', [BusinessTypeID]'
				SET @SQL = @SQL + ', [FirstApprovedDate]'
				SET @SQL = @SQL + ', [Profile]'
				SET @SQL = @SQL + ', [CharityNumber]'
				SET @SQL = @SQL + ', [SearchField]'
				SET @SQL = @SQL + ', [FreeTrialStartDate]'
				SET @SQL = @SQL + ', [FreeTrialEndDate]'
				SET @SQL = @SQL + ', [AccountsPayableEmail]'
				SET @SQL = @SQL + ', [RequireLogonForExternalApplication]'
				SET @SQL = @SQL + ' FROM [dbo].[Advertisers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdvertiserID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [AccountTypeID],'
				SET @SQL = @SQL + ' [CompanyName],'
				SET @SQL = @SQL + ' [BusinessNumber],'
				SET @SQL = @SQL + ' [StreetAddress1],'
				SET @SQL = @SQL + ' [StreetAddress2],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [AccountStatusID],'
				SET @SQL = @SQL + ' [PostalAddress1],'
				SET @SQL = @SQL + ' [PostalAddress2],'
				SET @SQL = @SQL + ' [WebAddress],'
				SET @SQL = @SQL + ' [NoOfEmployees],'
				SET @SQL = @SQL + ' [BusinessTypeID],'
				SET @SQL = @SQL + ' [FirstApprovedDate],'
				SET @SQL = @SQL + ' [Profile],'
				SET @SQL = @SQL + ' [CharityNumber],'
				SET @SQL = @SQL + ' [SearchField],'
				SET @SQL = @SQL + ' [FreeTrialStartDate],'
				SET @SQL = @SQL + ' [FreeTrialEndDate],'
				SET @SQL = @SQL + ' [AccountsPayableEmail],'
				SET @SQL = @SQL + ' [RequireLogonForExternalApplication]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Advertisers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[AdminUsers_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AdminUsers table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminUsers_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AdminUserID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AdminUserID]'
				SET @SQL = @SQL + ', [AdminAdminRoleID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [UserName]'
				SET @SQL = @SQL + ', [UserPassword]'
				SET @SQL = @SQL + ', [FirstName]'
				SET @SQL = @SQL + ', [Surname]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ' FROM [dbo].[AdminUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdminUserID],'
				SET @SQL = @SQL + ' [AdminAdminRoleID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [UserName],'
				SET @SQL = @SQL + ' [UserPassword],'
				SET @SQL = @SQL + ' [FirstName],'
				SET @SQL = @SQL + ' [Surname],'
				SET @SQL = @SQL + ' [Email]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AdminUsers]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageTemplates_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DynamicPageTemplates table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageTemplates_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DynamicPageTemplateID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DynamicPageTemplateID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [DynamicPageTemplateName]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPageTemplates]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DynamicPageTemplateID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [DynamicPageTemplateName],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPageTemplates]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[DynamicPages_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DynamicPages table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPages_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DynamicPageID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DynamicPageID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [ParentDynamicPageID]'
				SET @SQL = @SQL + ', [PageName]'
				SET @SQL = @SQL + ', [PageTitle]'
				SET @SQL = @SQL + ', [PageContent]'
				SET @SQL = @SQL + ', [DynamicPageWebPartTemplateID]'
				SET @SQL = @SQL + ', [HyperLink]'
				SET @SQL = @SQL + ', [Valid]'
				SET @SQL = @SQL + ', [OpenInNewWindow]'
				SET @SQL = @SQL + ', [Sequence]'
				SET @SQL = @SQL + ', [FullScreen]'
				SET @SQL = @SQL + ', [OnTopNav]'
				SET @SQL = @SQL + ', [OnLeftNav]'
				SET @SQL = @SQL + ', [OnBottomNav]'
				SET @SQL = @SQL + ', [OnSiteMap]'
				SET @SQL = @SQL + ', [Searchable]'
				SET @SQL = @SQL + ', [SearchField]'
				SET @SQL = @SQL + ', [SearchFieldExtension]'
				SET @SQL = @SQL + ', [MetaKeywords]'
				SET @SQL = @SQL + ', [MetaDescription]'
				SET @SQL = @SQL + ', [PageFriendlyName]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPages]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DynamicPageID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [ParentDynamicPageID],'
				SET @SQL = @SQL + ' [PageName],'
				SET @SQL = @SQL + ' [PageTitle],'
				SET @SQL = @SQL + ' [PageContent],'
				SET @SQL = @SQL + ' [DynamicPageWebPartTemplateID],'
				SET @SQL = @SQL + ' [HyperLink],'
				SET @SQL = @SQL + ' [Valid],'
				SET @SQL = @SQL + ' [OpenInNewWindow],'
				SET @SQL = @SQL + ' [Sequence],'
				SET @SQL = @SQL + ' [FullScreen],'
				SET @SQL = @SQL + ' [OnTopNav],'
				SET @SQL = @SQL + ' [OnLeftNav],'
				SET @SQL = @SQL + ' [OnBottomNav],'
				SET @SQL = @SQL + ' [OnSiteMap],'
				SET @SQL = @SQL + ' [Searchable],'
				SET @SQL = @SQL + ' [SearchField],'
				SET @SQL = @SQL + ' [SearchFieldExtension],'
				SET @SQL = @SQL + ' [MetaKeywords],'
				SET @SQL = @SQL + ' [MetaDescription],'
				SET @SQL = @SQL + ' [PageFriendlyName],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPages]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  Table [dbo].[AdminRoles]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdminRoles](
	[AdminRoleID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AdminRoleID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[DynamicPageWebPartTemplates_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the DynamicPageWebPartTemplates table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[DynamicPageWebPartTemplates_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[DynamicPageWebPartTemplateID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [DynamicPageWebPartTemplateID]'
				SET @SQL = @SQL + ', [DynamicPageWebPartName]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPageWebPartTemplates]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [DynamicPageWebPartTemplateID],'
				SET @SQL = @SQL + ' [DynamicPageWebPartName],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[DynamicPageWebPartTemplates]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the AdminRoles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[AdminRoleID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [AdminRoleID]'
				SET @SQL = @SQL + ', [RoleName]'
				SET @SQL = @SQL + ' FROM [dbo].[AdminRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [AdminRoleID],'
				SET @SQL = @SQL + ' [RoleName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[AdminRoles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  Table [dbo].[EmailFormats]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmailFormats](
	[EmailFormatID] [int] IDENTITY(1,1) NOT NULL,
	[EmailFormatName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EmailFormatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Enquiries_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Enquiries table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Enquiries_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EnquiryID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EnquiryID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [Name]'
				SET @SQL = @SQL + ', [Email]'
				SET @SQL = @SQL + ', [ContactPhone]'
				SET @SQL = @SQL + ', [Content]'
				SET @SQL = @SQL + ' FROM [dbo].[Enquiries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EnquiryID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [Name],'
				SET @SQL = @SQL + ' [Email],'
				SET @SQL = @SQL + ' [ContactPhone],'
				SET @SQL = @SQL + ' [Content]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Enquiries]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  Table [dbo].[FileTypes]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FileTypes](
	[FileTypeID] [int] IDENTITY(1,1) NOT NULL,
	[FileTypeName] [varchar](255) NOT NULL,
	[FileTypeExtension] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[FileTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the EmailFormats table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[EmailFormatID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [EmailFormatID]'
				SET @SQL = @SQL + ', [EmailFormatName]'
				SET @SQL = @SQL + ' FROM [dbo].[EmailFormats]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [EmailFormatID],'
				SET @SQL = @SQL + ' [EmailFormatName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[EmailFormats]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the FileTypes table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FileTypeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FileTypeID]'
				SET @SQL = @SQL + ', [FileTypeName]'
				SET @SQL = @SQL + ', [FileTypeExtension]'
				SET @SQL = @SQL + ' FROM [dbo].[FileTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FileTypeID],'
				SET @SQL = @SQL + ' [FileTypeName],'
				SET @SQL = @SQL + ' [FileTypeExtension]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[FileTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[News_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the News table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[News_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[NewsID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [NewsID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [NewsCategoryID]'
				SET @SQL = @SQL + ', [Subject]'
				SET @SQL = @SQL + ', [Content]'
				SET @SQL = @SQL + ', [PostDate]'
				SET @SQL = @SQL + ', [Valid]'
				SET @SQL = @SQL + ', [Sequence]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ', [SearchField]'
				SET @SQL = @SQL + ', [Tags]'
				SET @SQL = @SQL + ' FROM [dbo].[News]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [NewsID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [NewsCategoryID],'
				SET @SQL = @SQL + ' [Subject],'
				SET @SQL = @SQL + ' [Content],'
				SET @SQL = @SQL + ' [PostDate],'
				SET @SQL = @SQL + ' [Valid],'
				SET @SQL = @SQL + ' [Sequence],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy],'
				SET @SQL = @SQL + ' [SearchField],'
				SET @SQL = @SQL + ' [Tags]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[News]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Members_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Members table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Members_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MemberID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MemberID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [Username]'
				SET @SQL = @SQL + ', [Password]'
				SET @SQL = @SQL + ', [Title]'
				SET @SQL = @SQL + ', [EmailAddress]'
				SET @SQL = @SQL + ', [Company]'
				SET @SQL = @SQL + ', [Position]'
				SET @SQL = @SQL + ', [HomePhone]'
				SET @SQL = @SQL + ', [WorkPhone]'
				SET @SQL = @SQL + ', [MobilePhone]'
				SET @SQL = @SQL + ', [Fax]'
				SET @SQL = @SQL + ', [Address1]'
				SET @SQL = @SQL + ', [Address2]'
				SET @SQL = @SQL + ', [LocationID]'
				SET @SQL = @SQL + ', [AreaID]'
				SET @SQL = @SQL + ', [PreferredCategoryID]'
				SET @SQL = @SQL + ', [PreferredSubCategoryID]'
				SET @SQL = @SQL + ', [PreferredSalaryID]'
				SET @SQL = @SQL + ', [Subscribed]'
				SET @SQL = @SQL + ', [MonthlyUpdate]'
				SET @SQL = @SQL + ', [ReferringMemberID]'
				SET @SQL = @SQL + ', [LastModifiedDate]'
				SET @SQL = @SQL + ', [Valid]'
				SET @SQL = @SQL + ', [EmailFormat]'
				SET @SQL = @SQL + ', [LastLogon]'
				SET @SQL = @SQL + ', [DateOfBirth]'
				SET @SQL = @SQL + ', [Gender]'
				SET @SQL = @SQL + ', [Tags]'
				SET @SQL = @SQL + ', [Validated]'
				SET @SQL = @SQL + ', [MemberURLExtension]'
				SET @SQL = @SQL + ', [WebsiteURL]'
				SET @SQL = @SQL + ', [AvailabilityID]'
				SET @SQL = @SQL + ', [AvailabilityFromDate]'
				SET @SQL = @SQL + ', [MySpaceHeading]'
				SET @SQL = @SQL + ', [MySpaceContent]'
				SET @SQL = @SQL + ', [URLReferrer]'
				SET @SQL = @SQL + ', [RequiredPasswordChange]'
				SET @SQL = @SQL + ', [PreferredJobTitle]'
				SET @SQL = @SQL + ', [PreferredAvailability]'
				SET @SQL = @SQL + ', [PreferredAvailabilityType]'
				SET @SQL = @SQL + ', [PreferredSalaryFrom]'
				SET @SQL = @SQL + ', [PreferredSalaryTo]'
				SET @SQL = @SQL + ', [CurrentSalaryFrom]'
				SET @SQL = @SQL + ', [CurrentSalaryTo]'
				SET @SQL = @SQL + ', [LookingFor]'
				SET @SQL = @SQL + ', [Experience]'
				SET @SQL = @SQL + ', [Skills]'
				SET @SQL = @SQL + ', [Reasons]'
				SET @SQL = @SQL + ', [Comments]'
				SET @SQL = @SQL + ', [ProfileType]'
				SET @SQL = @SQL + ' FROM [dbo].[Members]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MemberID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [Username],'
				SET @SQL = @SQL + ' [Password],'
				SET @SQL = @SQL + ' [Title],'
				SET @SQL = @SQL + ' [EmailAddress],'
				SET @SQL = @SQL + ' [Company],'
				SET @SQL = @SQL + ' [Position],'
				SET @SQL = @SQL + ' [HomePhone],'
				SET @SQL = @SQL + ' [WorkPhone],'
				SET @SQL = @SQL + ' [MobilePhone],'
				SET @SQL = @SQL + ' [Fax],'
				SET @SQL = @SQL + ' [Address1],'
				SET @SQL = @SQL + ' [Address2],'
				SET @SQL = @SQL + ' [LocationID],'
				SET @SQL = @SQL + ' [AreaID],'
				SET @SQL = @SQL + ' [PreferredCategoryID],'
				SET @SQL = @SQL + ' [PreferredSubCategoryID],'
				SET @SQL = @SQL + ' [PreferredSalaryID],'
				SET @SQL = @SQL + ' [Subscribed],'
				SET @SQL = @SQL + ' [MonthlyUpdate],'
				SET @SQL = @SQL + ' [ReferringMemberID],'
				SET @SQL = @SQL + ' [LastModifiedDate],'
				SET @SQL = @SQL + ' [Valid],'
				SET @SQL = @SQL + ' [EmailFormat],'
				SET @SQL = @SQL + ' [LastLogon],'
				SET @SQL = @SQL + ' [DateOfBirth],'
				SET @SQL = @SQL + ' [Gender],'
				SET @SQL = @SQL + ' [Tags],'
				SET @SQL = @SQL + ' [Validated],'
				SET @SQL = @SQL + ' [MemberURLExtension],'
				SET @SQL = @SQL + ' [WebsiteURL],'
				SET @SQL = @SQL + ' [AvailabilityID],'
				SET @SQL = @SQL + ' [AvailabilityFromDate],'
				SET @SQL = @SQL + ' [MySpaceHeading],'
				SET @SQL = @SQL + ' [MySpaceContent],'
				SET @SQL = @SQL + ' [URLReferrer],'
				SET @SQL = @SQL + ' [RequiredPasswordChange],'
				SET @SQL = @SQL + ' [PreferredJobTitle],'
				SET @SQL = @SQL + ' [PreferredAvailability],'
				SET @SQL = @SQL + ' [PreferredAvailabilityType],'
				SET @SQL = @SQL + ' [PreferredSalaryFrom],'
				SET @SQL = @SQL + ' [PreferredSalaryTo],'
				SET @SQL = @SQL + ' [CurrentSalaryFrom],'
				SET @SQL = @SQL + ' [CurrentSalaryTo],'
				SET @SQL = @SQL + ' [LookingFor],'
				SET @SQL = @SQL + ' [Experience],'
				SET @SQL = @SQL + ' [Skills],'
				SET @SQL = @SQL + ' [Reasons],'
				SET @SQL = @SQL + ' [Comments],'
				SET @SQL = @SQL + ' [ProfileType]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Members]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  Table [dbo].[Languages]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Languages](
	[LanguageID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LanguageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[Folders_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Folders table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Folders_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FolderID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FolderID]'
				SET @SQL = @SQL + ', [ParentFolderID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [FolderName]'
				SET @SQL = @SQL + ' FROM [dbo].[Folders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FolderID],'
				SET @SQL = @SQL + ' [ParentFolderID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [FolderName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Folders]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[MemberFiles_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the MemberFiles table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFiles_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MemberFileID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MemberFileID]'
				SET @SQL = @SQL + ', [MemberID]'
				SET @SQL = @SQL + ', [MemberFileTypeID]'
				SET @SQL = @SQL + ', [MemberFileName]'
				SET @SQL = @SQL + ', [MemberFileTitle]'
				SET @SQL = @SQL + ', [LastModifiedDate]'
				SET @SQL = @SQL + ', [PrivacyLevelID]'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFiles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MemberFileID],'
				SET @SQL = @SQL + ' [MemberID],'
				SET @SQL = @SQL + ' [MemberFileTypeID],'
				SET @SQL = @SQL + ' [MemberFileName],'
				SET @SQL = @SQL + ' [MemberFileTitle],'
				SET @SQL = @SQL + ' [LastModifiedDate],'
				SET @SQL = @SQL + ' [PrivacyLevelID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFiles]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Files_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Files table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Files_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[FileID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [FileID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [FolderID]'
				SET @SQL = @SQL + ', [FileName]'
				SET @SQL = @SQL + ', [FileSystemName]'
				SET @SQL = @SQL + ', [FileTypeID]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM [dbo].[Files]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [FileID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [FolderID],'
				SET @SQL = @SQL + ' [FileName],'
				SET @SQL = @SQL + ' [FileSystemName],'
				SET @SQL = @SQL + ' [FileTypeID],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Files]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Languages_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Languages table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[LanguageID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [LanguageID]'
				SET @SQL = @SQL + ', [LanguageName]'
				SET @SQL = @SQL + ' FROM [dbo].[Languages]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [LanguageID],'
				SET @SQL = @SQL + ' [LanguageName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Languages]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[Sites_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the Sites table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Sites_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SiteID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [SiteName]'
				SET @SQL = @SQL + ', [SiteURL]'
				SET @SQL = @SQL + ', [SiteDescription]'
				SET @SQL = @SQL + ', [LastModified]'
				SET @SQL = @SQL + ', [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM [dbo].[Sites]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [SiteName],'
				SET @SQL = @SQL + ' [SiteURL],'
				SET @SQL = @SQL + ' [SiteDescription],'
				SET @SQL = @SQL + ' [LastModified],'
				SET @SQL = @SQL + ' [LastModifiedBy]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[Sites]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[NewsCategories_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the NewsCategories table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[NewsCategories_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[NewsCategoryID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [NewsCategoryID]'
				SET @SQL = @SQL + ', [NewsCategoryName]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ' FROM [dbo].[NewsCategories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [NewsCategoryID],'
				SET @SQL = @SQL + ' [NewsCategoryName],'
				SET @SQL = @SQL + ' [SiteID]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[NewsCategories]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  Table [dbo].[SiteWebPartTypes]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SiteWebPartTypes](
	[SiteWebPartTypeID] [int] IDENTITY(1,1) NOT NULL,
	[SiteWebPartName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SiteWebPartTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Table [dbo].[MemberFileTypes]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MemberFileTypes](
	[MemberFileTypeID] [int] IDENTITY(1,1) NOT NULL,
	[MemberFileTypeName] [varchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberFileTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the MemberFileTypes table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[MemberFileTypeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [MemberFileTypeID]'
				SET @SQL = @SQL + ', [MemberFileTypeName]'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFileTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [MemberFileTypeID],'
				SET @SQL = @SQL + ' [MemberFileTypeName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[MemberFileTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the SiteWebPartTypes table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SiteWebPartTypeID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SiteWebPartTypeID]'
				SET @SQL = @SQL + ', [SiteWebPartName]'
				SET @SQL = @SQL + ' FROM [dbo].[SiteWebPartTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SiteWebPartTypeID],'
				SET @SQL = @SQL + ' [SiteWebPartName]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SiteWebPartTypes]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[SiteWebParts_GetPaged]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets records from the SiteWebParts table passing page index and page count parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebParts_GetPaged]
(

	@WhereClause varchar (2000)  ,

	@OrderBy varchar (2000)  ,

	@PageIndex int   ,

	@PageSize int   
)
AS


				
				BEGIN
				DECLARE @PageLowerBound int
				DECLARE @PageUpperBound int
				
				-- Set the page bounds
				SET @PageLowerBound = @PageSize * @PageIndex
				SET @PageUpperBound = @PageLowerBound + @PageSize

				IF (@OrderBy IS NULL OR LEN(@OrderBy) < 1)
				BEGIN
					-- default order by to first column
					SET @OrderBy = '[SiteWebPartID]'
				END

				-- SQL Server 2005 Paging
				DECLARE @SQL AS nvarchar(MAX)
				SET @SQL = 'WITH PageIndex AS ('
				SET @SQL = @SQL + ' SELECT'
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' TOP ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ROW_NUMBER() OVER (ORDER BY ' + @OrderBy + ') as RowIndex'
				SET @SQL = @SQL + ', [SiteWebPartID]'
				SET @SQL = @SQL + ', [SiteID]'
				SET @SQL = @SQL + ', [SiteWebPartTypeID]'
				SET @SQL = @SQL + ', [SiteWebPartHTML]'
				SET @SQL = @SQL + ' FROM [dbo].[SiteWebParts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				SET @SQL = @SQL + ' ) SELECT'
				SET @SQL = @SQL + ' [SiteWebPartID],'
				SET @SQL = @SQL + ' [SiteID],'
				SET @SQL = @SQL + ' [SiteWebPartTypeID],'
				SET @SQL = @SQL + ' [SiteWebPartHTML]'
				SET @SQL = @SQL + ' FROM PageIndex'
				SET @SQL = @SQL + ' WHERE RowIndex > ' + CONVERT(nvarchar, @PageLowerBound)
				IF @PageSize > 0
				BEGIN
					SET @SQL = @SQL + ' AND RowIndex <= ' + CONVERT(nvarchar, @PageUpperBound)
				END
				SET @SQL = @SQL + ' ORDER BY ' + @OrderBy
				EXEC sp_executesql @SQL
				
				-- get row count
				SET @SQL = 'SELECT COUNT(*) AS TotalRowCount'
				SET @SQL = @SQL + ' FROM [dbo].[SiteWebParts]'
				IF LEN(@WhereClause) > 0
				BEGIN
					SET @SQL = @SQL + ' WHERE ' + @WhereClause
				END
				EXEC sp_executesql @SQL
			
				END
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_Update]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the SiteWebPartTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_Update]
(

	@SiteWebPartTypeId int   ,

	@SiteWebPartName varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[SiteWebPartTypes]
				SET
					[SiteWebPartName] = @SiteWebPartName
				WHERE
[SiteWebPartTypeID] = @SiteWebPartTypeId
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_Insert]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the SiteWebPartTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_Insert]
(

	@SiteWebPartTypeId int    OUTPUT,

	@SiteWebPartName varchar (255)  
)
AS


				
				INSERT INTO [dbo].[SiteWebPartTypes]
					(
					[SiteWebPartName]
					)
				VALUES
					(
					@SiteWebPartName
					)
				
				-- Get the identity value
				SET @SiteWebPartTypeId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_GetBySiteWebPartTypeId]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the SiteWebPartTypes table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_GetBySiteWebPartTypeId]
(

	@SiteWebPartTypeId int   
)
AS


				SELECT
					[SiteWebPartTypeID],
					[SiteWebPartName]
				FROM
					[dbo].[SiteWebPartTypes]
				WHERE
					[SiteWebPartTypeID] = @SiteWebPartTypeId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_Get_List]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the SiteWebPartTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_Get_List]

AS


				
				SELECT
					[SiteWebPartTypeID],
					[SiteWebPartName]
				FROM
					[dbo].[SiteWebPartTypes]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_Find]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the SiteWebPartTypes table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_Find]
(

	@SearchUsingOR bit   = null ,

	@SiteWebPartTypeId int   = null ,

	@SiteWebPartName varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [SiteWebPartTypeID]
	, [SiteWebPartName]
    FROM
	[dbo].[SiteWebPartTypes]
    WHERE 
	 ([SiteWebPartTypeID] = @SiteWebPartTypeId OR @SiteWebPartTypeId IS NULL)
	AND ([SiteWebPartName] = @SiteWebPartName OR @SiteWebPartName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [SiteWebPartTypeID]
	, [SiteWebPartName]
    FROM
	[dbo].[SiteWebPartTypes]
    WHERE 
	 ([SiteWebPartTypeID] = @SiteWebPartTypeId AND @SiteWebPartTypeId is not null)
	OR ([SiteWebPartName] = @SiteWebPartName AND @SiteWebPartName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[SiteWebPartTypes_Delete]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the SiteWebPartTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[SiteWebPartTypes_Delete]
(

	@SiteWebPartTypeId int   
)
AS


				DELETE FROM [dbo].[SiteWebPartTypes] WITH (ROWLOCK) 
				WHERE
					[SiteWebPartTypeID] = @SiteWebPartTypeId
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_GetByMemberFileTypeId]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the MemberFileTypes table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_GetByMemberFileTypeId]
(

	@MemberFileTypeId int   
)
AS


				SELECT
					[MemberFileTypeID],
					[MemberFileTypeName]
				FROM
					[dbo].[MemberFileTypes]
				WHERE
					[MemberFileTypeID] = @MemberFileTypeId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_Get_List]    Script Date: 10/31/2010 21:46:53 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the MemberFileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_Get_List]

AS


				
				SELECT
					[MemberFileTypeID],
					[MemberFileTypeName]
				FROM
					[dbo].[MemberFileTypes]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_Find]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the MemberFileTypes table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_Find]
(

	@SearchUsingOR bit   = null ,

	@MemberFileTypeId int   = null ,

	@MemberFileTypeName varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [MemberFileTypeID]
	, [MemberFileTypeName]
    FROM
	[dbo].[MemberFileTypes]
    WHERE 
	 ([MemberFileTypeID] = @MemberFileTypeId OR @MemberFileTypeId IS NULL)
	AND ([MemberFileTypeName] = @MemberFileTypeName OR @MemberFileTypeName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [MemberFileTypeID]
	, [MemberFileTypeName]
    FROM
	[dbo].[MemberFileTypes]
    WHERE 
	 ([MemberFileTypeID] = @MemberFileTypeId AND @MemberFileTypeId is not null)
	OR ([MemberFileTypeName] = @MemberFileTypeName AND @MemberFileTypeName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_Delete]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the MemberFileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_Delete]
(

	@MemberFileTypeId int   
)
AS


				DELETE FROM [dbo].[MemberFileTypes] WITH (ROWLOCK) 
				WHERE
					[MemberFileTypeID] = @MemberFileTypeId
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_Update]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the MemberFileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_Update]
(

	@MemberFileTypeId int   ,

	@MemberFileTypeName varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[MemberFileTypes]
				SET
					[MemberFileTypeName] = @MemberFileTypeName
				WHERE
[MemberFileTypeID] = @MemberFileTypeId
GO
/****** Object:  StoredProcedure [dbo].[MemberFileTypes_Insert]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the MemberFileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[MemberFileTypes_Insert]
(

	@MemberFileTypeId int    OUTPUT,

	@MemberFileTypeName varchar (255)  
)
AS


				
				INSERT INTO [dbo].[MemberFileTypes]
					(
					[MemberFileTypeName]
					)
				VALUES
					(
					@MemberFileTypeName
					)
				
				-- Get the identity value
				SET @MemberFileTypeId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[Languages_GetByLanguageId]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the Languages table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_GetByLanguageId]
(

	@LanguageId int   
)
AS


				SELECT
					[LanguageID],
					[LanguageName]
				FROM
					[dbo].[Languages]
				WHERE
					[LanguageID] = @LanguageId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Languages_Get_List]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the Languages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_Get_List]

AS


				
				SELECT
					[LanguageID],
					[LanguageName]
				FROM
					[dbo].[Languages]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[Languages_Find]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the Languages table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_Find]
(

	@SearchUsingOR bit   = null ,

	@LanguageId int   = null ,

	@LanguageName varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [LanguageID]
	, [LanguageName]
    FROM
	[dbo].[Languages]
    WHERE 
	 ([LanguageID] = @LanguageId OR @LanguageId IS NULL)
	AND ([LanguageName] = @LanguageName OR @LanguageName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [LanguageID]
	, [LanguageName]
    FROM
	[dbo].[Languages]
    WHERE 
	 ([LanguageID] = @LanguageId AND @LanguageId is not null)
	OR ([LanguageName] = @LanguageName AND @LanguageName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[Languages_Delete]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the Languages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_Delete]
(

	@LanguageId int   
)
AS


				DELETE FROM [dbo].[Languages] WITH (ROWLOCK) 
				WHERE
					[LanguageID] = @LanguageId
GO
/****** Object:  StoredProcedure [dbo].[Languages_Update]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the Languages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_Update]
(

	@LanguageId int   ,

	@LanguageName varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[Languages]
				SET
					[LanguageName] = @LanguageName
				WHERE
[LanguageID] = @LanguageId
GO
/****** Object:  StoredProcedure [dbo].[Languages_Insert]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the Languages table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[Languages_Insert]
(

	@LanguageId int    OUTPUT,

	@LanguageName varchar (255)  
)
AS


				
				INSERT INTO [dbo].[Languages]
					(
					[LanguageName]
					)
				VALUES
					(
					@LanguageName
					)
				
				-- Get the identity value
				SET @LanguageId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_Update]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the FileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_Update]
(

	@FileTypeId int   ,

	@FileTypeName varchar (255)  ,

	@FileTypeExtension varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[FileTypes]
				SET
					[FileTypeName] = @FileTypeName
					,[FileTypeExtension] = @FileTypeExtension
				WHERE
[FileTypeID] = @FileTypeId
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_Insert]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the FileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_Insert]
(

	@FileTypeId int    OUTPUT,

	@FileTypeName varchar (255)  ,

	@FileTypeExtension varchar (255)  
)
AS


				
				INSERT INTO [dbo].[FileTypes]
					(
					[FileTypeName]
					,[FileTypeExtension]
					)
				VALUES
					(
					@FileTypeName
					,@FileTypeExtension
					)
				
				-- Get the identity value
				SET @FileTypeId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_GetByFileTypeId]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the FileTypes table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_GetByFileTypeId]
(

	@FileTypeId int   
)
AS


				SELECT
					[FileTypeID],
					[FileTypeName],
					[FileTypeExtension]
				FROM
					[dbo].[FileTypes]
				WHERE
					[FileTypeID] = @FileTypeId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_Get_List]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the FileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_Get_List]

AS


				
				SELECT
					[FileTypeID],
					[FileTypeName],
					[FileTypeExtension]
				FROM
					[dbo].[FileTypes]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_Find]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the FileTypes table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_Find]
(

	@SearchUsingOR bit   = null ,

	@FileTypeId int   = null ,

	@FileTypeName varchar (255)  = null ,

	@FileTypeExtension varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [FileTypeID]
	, [FileTypeName]
	, [FileTypeExtension]
    FROM
	[dbo].[FileTypes]
    WHERE 
	 ([FileTypeID] = @FileTypeId OR @FileTypeId IS NULL)
	AND ([FileTypeName] = @FileTypeName OR @FileTypeName IS NULL)
	AND ([FileTypeExtension] = @FileTypeExtension OR @FileTypeExtension IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [FileTypeID]
	, [FileTypeName]
	, [FileTypeExtension]
    FROM
	[dbo].[FileTypes]
    WHERE 
	 ([FileTypeID] = @FileTypeId AND @FileTypeId is not null)
	OR ([FileTypeName] = @FileTypeName AND @FileTypeName is not null)
	OR ([FileTypeExtension] = @FileTypeExtension AND @FileTypeExtension is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[FileTypes_Delete]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the FileTypes table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[FileTypes_Delete]
(

	@FileTypeId int   
)
AS


				DELETE FROM [dbo].[FileTypes] WITH (ROWLOCK) 
				WHERE
					[FileTypeID] = @FileTypeId
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_GetByEmailFormatId]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the EmailFormats table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_GetByEmailFormatId]
(

	@EmailFormatId int   
)
AS


				SELECT
					[EmailFormatID],
					[EmailFormatName]
				FROM
					[dbo].[EmailFormats]
				WHERE
					[EmailFormatID] = @EmailFormatId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_Get_List]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the EmailFormats table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_Get_List]

AS


				
				SELECT
					[EmailFormatID],
					[EmailFormatName]
				FROM
					[dbo].[EmailFormats]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_Find]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the EmailFormats table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_Find]
(

	@SearchUsingOR bit   = null ,

	@EmailFormatId int   = null ,

	@EmailFormatName varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [EmailFormatID]
	, [EmailFormatName]
    FROM
	[dbo].[EmailFormats]
    WHERE 
	 ([EmailFormatID] = @EmailFormatId OR @EmailFormatId IS NULL)
	AND ([EmailFormatName] = @EmailFormatName OR @EmailFormatName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [EmailFormatID]
	, [EmailFormatName]
    FROM
	[dbo].[EmailFormats]
    WHERE 
	 ([EmailFormatID] = @EmailFormatId AND @EmailFormatId is not null)
	OR ([EmailFormatName] = @EmailFormatName AND @EmailFormatName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_Delete]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the EmailFormats table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_Delete]
(

	@EmailFormatId int   
)
AS


				DELETE FROM [dbo].[EmailFormats] WITH (ROWLOCK) 
				WHERE
					[EmailFormatID] = @EmailFormatId
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_Update]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the EmailFormats table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_Update]
(

	@EmailFormatId int   ,

	@EmailFormatName varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[EmailFormats]
				SET
					[EmailFormatName] = @EmailFormatName
				WHERE
[EmailFormatID] = @EmailFormatId
GO
/****** Object:  StoredProcedure [dbo].[EmailFormats_Insert]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the EmailFormats table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[EmailFormats_Insert]
(

	@EmailFormatId int    OUTPUT,

	@EmailFormatName varchar (255)  
)
AS


				
				INSERT INTO [dbo].[EmailFormats]
					(
					[EmailFormatName]
					)
				VALUES
					(
					@EmailFormatName
					)
				
				-- Get the identity value
				SET @EmailFormatId = SCOPE_IDENTITY()
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_GetByAdminRoleId]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Select records from the AdminRoles table through an index
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_GetByAdminRoleId]
(

	@AdminRoleId int   
)
AS


				SELECT
					[AdminRoleID],
					[RoleName]
				FROM
					[dbo].[AdminRoles]
				WHERE
					[AdminRoleID] = @AdminRoleId
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_Get_List]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Gets all records from the AdminRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_Get_List]

AS


				
				SELECT
					[AdminRoleID],
					[RoleName]
				FROM
					[dbo].[AdminRoles]
					
				SELECT @@ROWCOUNT
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_Find]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Finds records in the AdminRoles table passing nullable parameters
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_Find]
(

	@SearchUsingOR bit   = null ,

	@AdminRoleId int   = null ,

	@RoleName varchar (255)  = null 
)
AS


				
  IF ISNULL(@SearchUsingOR, 0) <> 1
  BEGIN
    SELECT
	  [AdminRoleID]
	, [RoleName]
    FROM
	[dbo].[AdminRoles]
    WHERE 
	 ([AdminRoleID] = @AdminRoleId OR @AdminRoleId IS NULL)
	AND ([RoleName] = @RoleName OR @RoleName IS NULL)
						
  END
  ELSE
  BEGIN
    SELECT
	  [AdminRoleID]
	, [RoleName]
    FROM
	[dbo].[AdminRoles]
    WHERE 
	 ([AdminRoleID] = @AdminRoleId AND @AdminRoleId is not null)
	OR ([RoleName] = @RoleName AND @RoleName is not null)
	SELECT @@ROWCOUNT			
  END
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_Delete]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Deletes a record in the AdminRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_Delete]
(

	@AdminRoleId int   
)
AS


				DELETE FROM [dbo].[AdminRoles] WITH (ROWLOCK) 
				WHERE
					[AdminRoleID] = @AdminRoleId
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_Update]    Script Date: 10/31/2010 21:46:54 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Updates a record in the AdminRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_Update]
(

	@AdminRoleId int   ,

	@RoleName varchar (255)  
)
AS


				
				
				-- Modify the updatable columns
				UPDATE
					[dbo].[AdminRoles]
				SET
					[RoleName] = @RoleName
				WHERE
[AdminRoleID] = @AdminRoleId
GO
/****** Object:  StoredProcedure [dbo].[AdminRoles_Insert]    Script Date: 10/31/2010 21:46:55 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
/*
----------------------------------------------------------------------------------------------------

-- Created By:  ()
-- Purpose: Inserts a record into the AdminRoles table
----------------------------------------------------------------------------------------------------
*/


CREATE PROCEDURE [dbo].[AdminRoles_Insert]
(

	@AdminRoleId int    OUTPUT,

	@RoleName varchar (255)  
)
AS


				
				INSERT INTO [dbo].[AdminRoles]
					(
					[RoleName]
					)
				VALUES
					(
					@RoleName
					)
				
				-- Get the identity value
				SET @AdminRoleId = SCOPE_IDENTITY()
GO
/****** Object:  Default [DF__Sites__LastModif__6E01572D]    Script Date: 10/31/2010 21:46:26 ******/
ALTER TABLE [dbo].[Sites] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__Members__LastMod__68487DD7]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[Members] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]
GO
/****** Object:  Default [DF__Members__LastLog__693CA210]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[Members] ADD  DEFAULT (getdate()) FOR [LastLogon]
GO
/****** Object:  Default [DF__GlobalSet__LastM__66603565]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[GlobalSettings] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__News__PostDate__6A30C649]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News] ADD  DEFAULT (getdate()) FOR [PostDate]
GO
/****** Object:  Default [DF__News__Valid__6B24EA82]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News] ADD  DEFAULT ((0)) FOR [Valid]
GO
/****** Object:  Default [DF__News__Sequence__6C190EBB]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News] ADD  DEFAULT ((0)) FOR [Sequence]
GO
/****** Object:  Default [DF__News__LastModifi__6D0D32F4]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__Folders__ParentF__656C112C]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Folders] ADD  DEFAULT ((0)) FOR [ParentFolderID]
GO
/****** Object:  Default [DF__MemberFil__LastM__6754599E]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[MemberFiles] ADD  DEFAULT (getdate()) FOR [LastModifiedDate]
GO
/****** Object:  Default [DF__Files__LastModif__6477ECF3]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Files] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__DynamicPa__LastM__628FA481]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageTemplates] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__DynamicPa__LastM__6383C8BA]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageWebPartTemplates] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__Advertise__LastM__5165187F]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[Advertisers] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__Advertise__Requi__52593CB8]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[Advertisers] ADD  DEFAULT ((0)) FOR [RequireLogonForExternalApplication]
GO
/****** Object:  Default [DF__Advertise__Prima__534D60F1]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers] ADD  DEFAULT ((0)) FOR [PrimaryAccount]
GO
/****** Object:  Default [DF__Advertise__Newsl__5441852A]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers] ADD  DEFAULT ((0)) FOR [Newsletter]
GO
/****** Object:  Default [DF__Advertise__Valid__5535A963]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers] ADD  DEFAULT ((0)) FOR [Validated]
GO
/****** Object:  Default [DF__Advertise__LastL__5629CD9C]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers] ADD  DEFAULT (getdate()) FOR [LastLoginDate]
GO
/****** Object:  Default [DF__Advertise__LastM__571DF1D5]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  Default [DF__DynamicPa__Paren__5812160E]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [ParentDynamicPageID]
GO
/****** Object:  Default [DF__DynamicPa__Valid__59063A47]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((1)) FOR [Valid]
GO
/****** Object:  Default [DF__DynamicPa__OpenI__59FA5E80]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [OpenInNewWindow]
GO
/****** Object:  Default [DF__DynamicPa__Seque__5AEE82B9]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((1)) FOR [Sequence]
GO
/****** Object:  Default [DF__DynamicPa__FullS__5BE2A6F2]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [FullScreen]
GO
/****** Object:  Default [DF__DynamicPa__OnTop__5CD6CB2B]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [OnTopNav]
GO
/****** Object:  Default [DF__DynamicPa__OnLef__5DCAEF64]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [OnLeftNav]
GO
/****** Object:  Default [DF__DynamicPa__OnBot__5EBF139D]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [OnBottomNav]
GO
/****** Object:  Default [DF__DynamicPa__OnSit__5FB337D6]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [OnSiteMap]
GO
/****** Object:  Default [DF__DynamicPa__Searc__60A75C0F]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT ((0)) FOR [Searchable]
GO
/****** Object:  Default [DF__DynamicPa__LastM__619B8048]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages] ADD  DEFAULT (getdate()) FOR [LastModified]
GO
/****** Object:  ForeignKey [FK__Sites__LastModif__0E6E26BF]    Script Date: 10/31/2010 21:46:26 ******/
ALTER TABLE [dbo].[Sites]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
/****** Object:  ForeignKey [FK_SiteWebParts_Sites]    Script Date: 10/31/2010 21:46:48 ******/
ALTER TABLE [dbo].[SiteWebParts]  WITH CHECK ADD  CONSTRAINT [FK_SiteWebParts_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[SiteWebParts] CHECK CONSTRAINT [FK_SiteWebParts_Sites]
GO
/****** Object:  ForeignKey [FK_SiteWebParts_SiteWebPartTypes]    Script Date: 10/31/2010 21:46:48 ******/
ALTER TABLE [dbo].[SiteWebParts]  WITH CHECK ADD  CONSTRAINT [FK_SiteWebParts_SiteWebPartTypes] FOREIGN KEY([SiteWebPartTypeID])
REFERENCES [dbo].[SiteWebPartTypes] ([SiteWebPartTypeID])
GO
ALTER TABLE [dbo].[SiteWebParts] CHECK CONSTRAINT [FK_SiteWebParts_SiteWebPartTypes]
GO
/****** Object:  ForeignKey [FK__Members__EmailFo__08B54D69]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[Members]  WITH CHECK ADD FOREIGN KEY([EmailFormat])
REFERENCES [dbo].[EmailFormats] ([EmailFormatID])
GO
/****** Object:  ForeignKey [FK__Members__SiteID__09A971A2]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[Members]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
/****** Object:  ForeignKey [FK_GlobalSettings_Sites]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[GlobalSettings]  WITH CHECK ADD  CONSTRAINT [FK_GlobalSettings_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[GlobalSettings] CHECK CONSTRAINT [FK_GlobalSettings_Sites]
GO
/****** Object:  ForeignKey [FK__News__LastModifi__0C85DE4D]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
/****** Object:  ForeignKey [FK__News__NewsCatego__0B91BA14]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([NewsCategoryID])
REFERENCES [dbo].[NewsCategories] ([NewsCategoryID])
GO
/****** Object:  ForeignKey [FK__News__SiteID__0A9D95DB]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[News]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
/****** Object:  ForeignKey [FK__NewsCateg__SiteI__0D7A0286]    Script Date: 10/31/2010 21:46:49 ******/
ALTER TABLE [dbo].[NewsCategories]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
/****** Object:  ForeignKey [FK_Folders_Sites]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Folders]  WITH CHECK ADD  CONSTRAINT [FK_Folders_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[Folders] CHECK CONSTRAINT [FK_Folders_Sites]
GO
/****** Object:  ForeignKey [FK__MemberFil__Membe__06CD04F7]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[MemberFiles]  WITH CHECK ADD FOREIGN KEY([MemberID])
REFERENCES [dbo].[Members] ([MemberID])
GO
/****** Object:  ForeignKey [FK__MemberFil__Membe__07C12930]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[MemberFiles]  WITH CHECK ADD FOREIGN KEY([MemberFileTypeID])
REFERENCES [dbo].[MemberFileTypes] ([MemberFileTypeID])
GO
/****** Object:  ForeignKey [FK_Files_AdminUsers]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_AdminUsers] FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_AdminUsers]
GO
/****** Object:  ForeignKey [FK_Files_FileTypes]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_FileTypes] FOREIGN KEY([FileTypeID])
REFERENCES [dbo].[FileTypes] ([FileTypeID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_FileTypes]
GO
/****** Object:  ForeignKey [FK_Files_Folders]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Folders] FOREIGN KEY([FolderID])
REFERENCES [dbo].[Folders] ([FolderID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Folders]
GO
/****** Object:  ForeignKey [FK_Files_Sites]    Script Date: 10/31/2010 21:46:50 ******/
ALTER TABLE [dbo].[Files]  WITH CHECK ADD  CONSTRAINT [FK_Files_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[Files] CHECK CONSTRAINT [FK_Files_Sites]
GO
/****** Object:  ForeignKey [FK__Enquiries__SiteI__00200768]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[Enquiries]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__LastM__7C4F7684]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageTemplates]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__7E37BEF6]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageWebPartTemplatesLink]  WITH CHECK ADD FOREIGN KEY([DynamicPageWebPartTemplateID])
REFERENCES [dbo].[DynamicPageWebPartTemplates] ([DynamicPageWebPartTemplateID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__SiteW__7F2BE32F]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageWebPartTemplatesLink]  WITH CHECK ADD FOREIGN KEY([SiteWebPartID])
REFERENCES [dbo].[SiteWebParts] ([SiteWebPartID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__LastM__7D439ABD]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[DynamicPageWebPartTemplates]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
/****** Object:  ForeignKey [FK_AdminUsers_AdminRoles]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[AdminUsers]  WITH CHECK ADD  CONSTRAINT [FK_AdminUsers_AdminRoles] FOREIGN KEY([AdminAdminRoleID])
REFERENCES [dbo].[AdminRoles] ([AdminRoleID])
GO
ALTER TABLE [dbo].[AdminUsers] CHECK CONSTRAINT [FK_AdminUsers_AdminRoles]
GO
/****** Object:  ForeignKey [FK_AdminUsers_Sites]    Script Date: 10/31/2010 21:46:51 ******/
ALTER TABLE [dbo].[AdminUsers]  WITH CHECK ADD  CONSTRAINT [FK_AdminUsers_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[AdminUsers] CHECK CONSTRAINT [FK_AdminUsers_Sites]
GO
/****** Object:  ForeignKey [FK__Advertise__SiteI__70DDC3D8]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[Advertisers]  WITH CHECK ADD FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
/****** Object:  ForeignKey [FK__Advertise__Adver__71D1E811]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers]  WITH CHECK ADD FOREIGN KEY([AdvertiserID])
REFERENCES [dbo].[Advertisers] ([AdvertiserID])
GO
/****** Object:  ForeignKey [FK__Advertise__Email__73BA3083]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers]  WITH CHECK ADD FOREIGN KEY([EmailFormat])
REFERENCES [dbo].[EmailFormats] ([EmailFormatID])
GO
/****** Object:  ForeignKey [FK__Advertise__Newsl__72C60C4A]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[AdvertiserUsers]  WITH CHECK ADD FOREIGN KEY([NewsletterFormat])
REFERENCES [dbo].[EmailFormats] ([EmailFormatID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__7A672E12]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPagesLinkCategories]  WITH CHECK ADD FOREIGN KEY([DynamicPageParentID])
REFERENCES [dbo].[DynamicPages] ([DynamicPageID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__7B5B524B]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPagesLinkCategories]  WITH CHECK ADD FOREIGN KEY([DynamicPageID])
REFERENCES [dbo].[DynamicPages] ([DynamicPageID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__787EE5A0]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPageShell]  WITH CHECK ADD FOREIGN KEY([DynamicPageTemplateID])
REFERENCES [dbo].[DynamicPageTemplates] ([DynamicPageTemplateID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__797309D9]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPageShell]  WITH CHECK ADD FOREIGN KEY([DynamicPageID])
REFERENCES [dbo].[DynamicPages] ([DynamicPageID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__Dynam__74AE54BC]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages]  WITH CHECK ADD FOREIGN KEY([DynamicPageWebPartTemplateID])
REFERENCES [dbo].[DynamicPageWebPartTemplates] ([DynamicPageWebPartTemplateID])
GO
/****** Object:  ForeignKey [FK__DynamicPa__LastM__75A278F5]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages]  WITH CHECK ADD FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
/****** Object:  ForeignKey [FK_DynamicPages_AdminUsers]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages]  WITH CHECK ADD  CONSTRAINT [FK_DynamicPages_AdminUsers] FOREIGN KEY([LastModifiedBy])
REFERENCES [dbo].[AdminUsers] ([AdminUserID])
GO
ALTER TABLE [dbo].[DynamicPages] CHECK CONSTRAINT [FK_DynamicPages_AdminUsers]
GO
/****** Object:  ForeignKey [FK_DynamicPages_Sites]    Script Date: 10/31/2010 21:46:52 ******/
ALTER TABLE [dbo].[DynamicPages]  WITH CHECK ADD  CONSTRAINT [FK_DynamicPages_Sites] FOREIGN KEY([SiteID])
REFERENCES [dbo].[Sites] ([SiteID])
GO
ALTER TABLE [dbo].[DynamicPages] CHECK CONSTRAINT [FK_DynamicPages_Sites]
GO
