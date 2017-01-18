CREATE TABLE [dbo].[KickingStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[KickingStatsId] UNIQUEIDENTIFIER NOT NULL,
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
    [FieldGoalsMade] INT NOT NULL, 
    [FieldGoalsAttempted] INT NOT NULL, 
    [Yards] INT NOT NULL, 
    [TotalPoints] INT NOT NULL, 
    [ExtraPointsMade] INT NOT NULL, 
	[ExtraPointsMissed] INT NOT NULL,
    [ExtraPointsAttempted] INT NOT NULL,
	[ExtraPointsBlocked] INT NOT NULL,
	[ExtraPointsTotal] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
