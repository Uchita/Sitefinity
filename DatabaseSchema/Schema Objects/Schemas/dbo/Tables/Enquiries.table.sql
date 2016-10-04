CREATE TABLE [dbo].[Enquiries]
(
	EnquiryID INT IDENTITY(1,1) PRIMARY KEY,
	SiteID INT NOT NULL REFERENCES Sites(SiteID),
	Name NVARCHAR(500) NOT NULL,
	Email VARCHAR(500),
	ContactPhone CHAR(40),
	Content NTEXT,
	[Date] smalldatetime NOT NULL DEFAULT (getdate()),
	[IpAddress] VARCHAR(150) NOT NULL DEFAULT ('')
)
