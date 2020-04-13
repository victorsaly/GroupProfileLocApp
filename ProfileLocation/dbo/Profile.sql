CREATE TABLE [dbo].[Profile]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Username] [varchar](250) NULL,
	[Name] [varchar](250) NOT NULL,
	[Bio] NVARCHAR(MAX) NULL,
	[Nicknames] [varchar](250) NULL,
	[Email] [varchar](250) NULL,
	[Country] [varchar](3) NULL,
	[Mobile] [varchar](250) NULL,
	[LocationId] [int] NULL,
	[PhotoURL] [varchar](250) NULL,
	[PhotoEmbedded] VARCHAR(MAX) null,
	[IsApproved] [bit] NOT NULL DEFAULT 0,
	[IsAdmin] [bit] NOT NULL DEFAULT 0,
	[IsActive] [bit] NOT NULL DEFAULT 0, 
    [Guid] UNIQUEIDENTIFIER NOT NULL DEFAULT newid(), 
    CONSTRAINT [FK_Profile_Location] FOREIGN KEY ([LocationId]) REFERENCES [Location]([Id]), 
    
)
