CREATE TABLE [dbo].[Fumbles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[FumblesId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [Total] INT NOT NULL, 
    [Recovered] INT NOT NULL, 
    [TeamRecovered] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [Lost] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
