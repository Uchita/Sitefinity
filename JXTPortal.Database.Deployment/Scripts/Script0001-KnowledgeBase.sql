CREATE TABLE [dbo].[KnowledgeBaseCategories](
      [Id] [int] IDENTITY(1,1) NOT NULL,
      [KnowledgeBaseCategoryName] [nvarchar](500) NULL,
	  [ParentId] [int],
      [Valid] [bit] NOT NULL,
      [Sequence] [int] NOT NULL,
      [LastModified] [datetime] NOT NULL,
      [LastModifiedBy] [int] NOT NULL,
	  CONSTRAINT [PK_KnowledgeBaseCategories] PRIMARY KEY CLUSTERED ([Id] ASC)
	  )
GO
CREATE TABLE [dbo].[KnowledgeBase](
      [Id] [int] IDENTITY(1,1) NOT NULL,
      [KnowledgeBaseCategoryID] [int] NOT NULL,
      [Subject] [nvarchar](255) NOT NULL,
      [Content] [ntext] NULL,
      [Valid] [bit] NULL,
      [Sequence] [int] NULL,
      [LastModified] [datetime] NULL,
      [LastModifiedBy] [int] NOT NULL,
      [SearchField] [nvarchar](max) NULL,
      [Tags] [nvarchar](250) NULL,
	  CONSTRAINT FK_KnowledgeBaseCategory FOREIGN KEY (KnowledgeBaseCategoryID)
	  REFERENCES KnowledgeBaseCategories(Id),
	  CONSTRAINT [PK_KnowledgeBase] PRIMARY KEY CLUSTERED ([Id] ASC)
	)
GO