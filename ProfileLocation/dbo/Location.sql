CREATE TABLE [dbo].[Location]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Address] VARCHAR(250) NOT NULL,
	[ViewPort] VARCHAR(250) NULL,
	[Location] VARCHAR(250) NULL,
	[PlaceId] [int] NULL,
	[ProfileId] [int] NOT NULL,
)
