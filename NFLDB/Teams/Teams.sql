CREATE TABLE [dbo].[Teams]
(
	[Id] INT NOT NULL IDENTITY,
	[Prefix] NVARCHAR(10)  NOT NULL PRIMARY KEY,
	[TeamId] UNIQUEIDENTIFIER NOT NULL, 
    [NickName] NVARCHAR(50) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Conference] VARCHAR(3) NOT NULL, 
    [Division] VARCHAR(10) NOT NULL,
	FOREIGN KEY (Conference) REFERENCES Conferences(Name),
	FOREIGN KEY (Division) REFERENCES Divisions(Name)
)
