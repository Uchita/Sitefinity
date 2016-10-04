CREATE TABLE [dbo].[ExceptionTable]
(
	[ExceptionID]					[int]			IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[DateEntered]					[datetime]		NOT NULL DEFAULT (getdate()),
	[ExceptionApplicationSource]	[varchar](500)  NOT NULL,
	[ClientIPAddress]				[varchar](255)  NOT NULL,
	[HostIPAddress]					[varchar](255)  NOT NULL,
	[ExceptionUrl]					[varchar](4000) NOT NULL,
	[ExceptionMessage]				[text]			NOT NULL,
	[ExceptionStackTrace]			[text]			NULL,
	[ErrorParamsMessage]			[text]			NULL
)
