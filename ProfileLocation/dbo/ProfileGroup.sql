CREATE TABLE [dbo].[ProfileGroup]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProfileId] INT NOT NULL, 
    [GroupId] INT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 0, 
    [IsDeleted] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_ProfileGroup_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [Profile]([Id]),
    CONSTRAINT [FK_ProfileGroup_Group] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id])
)
