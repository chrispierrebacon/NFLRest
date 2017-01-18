CREATE TABLE [dbo].[PassingStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[PassingStatsId] UNIQUEIDENTIFIER NOT NULL,
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [Attempts] INT NOT NULL, 
    [Completions] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [Touchdowns] INT NOT NULL, 
    [Interceptions] INT NOT NULL, 
    [TwoPointAttempts] INT NOT NULL, 
    [TwoPointMakes] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
