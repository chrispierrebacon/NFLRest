CREATE TABLE [dbo].[KickReturnStats]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[KickReturnStatsId] UNIQUEIDENTIFIER NOT NULL, 
    [GameId] UNIQUEIDENTIFIER NOT NULL, 
    [PlayerId] UNIQUEIDENTIFIER NOT NULL, 
	[Returns] INT NOT NULL,
    [Average] INT NOT NULL, 
    [Touchdowns] INT NOT NULL, 
    [Long] INT NOT NULL, 
    [LongTouchdown] INT NOT NULL,
	[GsisId] nvarchar(50),
	FOREIGN KEY (GameId) REFERENCES Games(GameId),
	FOREIGN KEY (PlayerId) REFERENCES Players(PlayerId)
)
