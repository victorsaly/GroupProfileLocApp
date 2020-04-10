CREATE TABLE [dbo].[Group]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] [nvarchar](250) NOT NULL UNIQUE,
	[Slug] [nvarchar](250) NOT NULL UNIQUE,
	[Description] [nvarchar](max) NULL,
	[Created] [datetime] NOT NULL DEFAULT getdate(),
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
)
