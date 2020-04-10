CREATE TABLE [dbo].[Social]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[SocialTypeId] [int] NOT NULL,
	[Value] [nvarchar](250) NOT NULL,
	[PhotoUrl] [varchar](250) NULL,
	[IsDeleted] [bit] NOT NULL DEFAULT 0,
	[ProfileId] [int] NOT NULL, 
    CONSTRAINT [FK_Social_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [Profile]([Id]), 
    CONSTRAINT [FK_Social_SocialType] FOREIGN KEY ([SocialTypeId]) REFERENCES [SocialType]([Id]),
)
