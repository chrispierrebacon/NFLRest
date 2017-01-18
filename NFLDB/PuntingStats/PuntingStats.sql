CREATE TABLE [dbo].[PuntingStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PuntingStatsId] UNIQUEIDENTIFIER NOT NULL,
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [Punts] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [Average] INT NOT NULL, 
    [InsideTwenty] INT NOT NULL, 
    [Long] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
