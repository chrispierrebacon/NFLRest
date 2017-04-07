﻿CREATE TABLE [dbo].[Games] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [GameId]           UNIQUEIDENTIFIER NOT NULL,
    [HomeTeam]         NVARCHAR (10)    NOT NULL,
    [AwayTeam]         NVARCHAR (10)    NOT NULL,
    [DateTime]         DATETIME         NOT NULL,
    [SeasonType]       NVARCHAR(4)     NOT NULL,
	[Season]		   INT			NOT NULL,
    [Eid]              BIGINT              NOT NULL,
    [GameKey]          BIGINT              NOT NULL,
    [Week]             INT              NOT NULL,
    [HTScoreFirstQtr]  INT              NOT NULL,
    [HTScoreSecondQtr] INT              NOT NULL,
    [HTScoreThirdQtr]  INT              NOT NULL,
    [HTScoreFourthQtr] INT              NOT NULL,
    [HTScoreOT]        INT              NOT NULL,
    [HTScoreFinal]     INT              NOT NULL,
    [ATScoreFirstQtr]  INT              NOT NULL,
    [ATScoreSecondQtr] INT              NOT NULL,
    [ATScoreThirdQtr]  INT              NOT NULL,
    [ATScoreFourthQtr] INT              NOT NULL,
    [ATScoreOT]        INT              NOT NULL,
    [ATScoreFinal]     INT              NOT NULL,
    [NeutralField]     BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC),
    FOREIGN KEY ([AwayTeam]) REFERENCES [dbo].[Teams] ([Prefix]),
    FOREIGN KEY ([HomeTeam]) REFERENCES [dbo].[Teams] ([Prefix]),
	FOREIGN KEY ([SeasonType]) REFERENCES [dbo].[SeasonType] (Name)
);