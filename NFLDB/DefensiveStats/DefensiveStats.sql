CREATE TABLE [dbo].[DefensiveStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[DefensiveStatsId] UNIQUEIDENTIFIER NOT NULL,
    [GameId] UNIQUEIDENTIFIER NOT NULL,
    [PlayerId] UNIQUEIDENTIFIER NOT NULL,
    [Tackles] INT NOT NULL,
    [Assists] INT NOT NULL,
    [Sacks] INT NOT NULL,
    [Interceptions] INT NOT NULL,
    [ForcedFumbles] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)	
)
