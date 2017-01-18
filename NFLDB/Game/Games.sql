﻿CREATE TABLE [dbo].[Games] (
    [Id]               INT              IDENTITY (1, 1) NOT NULL,
    [GameId]           UNIQUEIDENTIFIER NOT NULL,
    [HomeTeam]         NVARCHAR (10)    NOT NULL,
    [AwayTeam]         NVARCHAR (10)    NOT NULL,
    [DateTime]         DATETIME         NOT NULL,
    [SeasonType]       NVARCHAR(10)     NOT NULL,
    [Eid]              BIGINT              NOT NULL,
    [GameKey]          BIGINT              NOT NULL,
    [Week]             INT              NOT NULL,
    [WT]               NVARCHAR (10)    NOT NULL,
    [LT]               NVARCHAR (10)    NOT NULL,
    [WTScoreFirstQtr]  INT              NOT NULL,
    [WTScoreSecondQtr] INT              NOT NULL,
    [WTScoreThirdQtr]  INT              NOT NULL,
    [WTScoreFourthQtr] INT              NOT NULL,
    [WTScoreOT]        INT              NOT NULL,
    [WTScoreFinal]     INT              NOT NULL,
    [LTScoreFirstQtr]  INT              NOT NULL,
    [LTScoreSecondQtr] INT              NOT NULL,
    [LTScoreThirdQtr]  INT              NOT NULL,
    [LTScoreFourthQtr] INT              NOT NULL,
    [LTScoreOT]        INT              NOT NULL,
    [LTScoreFinal]     INT              NOT NULL,
    [NeutralField]     BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([GameId] ASC),
    FOREIGN KEY ([AwayTeam]) REFERENCES [dbo].[Teams] ([Prefix]),
    FOREIGN KEY ([HomeTeam]) REFERENCES [dbo].[Teams] ([Prefix])
);




