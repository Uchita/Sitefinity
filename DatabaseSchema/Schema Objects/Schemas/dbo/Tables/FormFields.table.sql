CREATE TABLE [dbo].[FormFields]
(
	FormFieldID INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	FormFieldName NVARCHAR(MAX),
	FormFieldDataType VARCHAR(255)
)
