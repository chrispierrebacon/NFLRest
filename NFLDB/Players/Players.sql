CREATE TABLE [dbo].[Players]
(
	[Id] INT NOT NULL IDENTITY,
	[PlayerId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Position] NVARCHAR(50) NOT NULL, 
    [Team] NVARCHAR(10) NOT NULL,
	[Birthdate] DATETIME NOT NULL, 
    [College] NVARCHAR(50) NOT NULL, 
    [FullName] NVARCHAR(50) NOT NULL, 
    [GsisId] NVARCHAR(50) NOT NULL UNIQUE, 
    [GsisName] NVARCHAR(50) NOT NULL, 
    [Height] INT NOT NULL, 
    [Number] INT NOT NULL, 
    [ProfileId] INT NOT NULL, 
    [ProfileUrl] NVARCHAR(50) NOT NULL, 
    [Status] NVARCHAR(10) NOT NULL, 
    [Weight] INT NOT NULL, 
    [YearsPro] INT NOT NULL, 
    FOREIGN KEY (Position) REFERENCES Positions(Name),
	FOREIGN KEY (Team) REFERENCES Teams(Prefix)
)
