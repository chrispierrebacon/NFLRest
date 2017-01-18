CREATE TABLE [dbo].[RushingStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[RushingStatsId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [Attempts] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [Touchdowns] INT NOT NULL, 
    [Long] INT NOT NULL, 
    [TwoPointAttempts] INT NOT NULL, 
    [TwoPointsMade] INT NOT NULL,
	[GsisId] NVARCHAR(50) NULL, 
    FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
