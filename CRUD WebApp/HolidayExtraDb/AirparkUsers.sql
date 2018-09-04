CREATE TABLE [dbo].[AirparkUsers]
(
	[id] INT IDENTITY(1,1) PRIMARY KEY,
	[email] VARCHAR(MAX) NULL,
	[givenName] VARCHAR(MAX) NULL,
	[familyName] VARCHAR(MAX) NULL,
	[created] DATETIME NULL
);
