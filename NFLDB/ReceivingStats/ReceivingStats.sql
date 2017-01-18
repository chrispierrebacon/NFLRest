CREATE TABLE [dbo].[ReceivingStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ReceivingStatsId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [Receptions] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [Touchdowns] INT NOT NULL, 
    [Long] INT NOT NULL, 
    [TwoPointAttempts] INT NOT NULL, 
    [TwoPointsMade] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
