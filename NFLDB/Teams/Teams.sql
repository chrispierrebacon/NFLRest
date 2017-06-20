CREATE TABLE [dbo].[Teams] (
    [Id]         INT              IDENTITY (1, 1) NOT NULL,
    [Prefix]     NVARCHAR (10)    NOT NULL,
    [TeamId]     UNIQUEIDENTIFIER NOT NULL,
    [NickName]   NVARCHAR (50)    NOT NULL,
    [City]       NVARCHAR (50)    NOT NULL,
    [Conference] VARCHAR (3)      NOT NULL,
    [Division]   VARCHAR (10)     NOT NULL,
    [Logo]       VARCHAR (MAX)    NULL,
    PRIMARY KEY CLUSTERED ([Prefix]),
    FOREIGN KEY ([Conference]) REFERENCES [dbo].[Conferences] ([Name]),
    FOREIGN KEY ([Division]) REFERENCES [dbo].[Divisions] ([Name])
);


