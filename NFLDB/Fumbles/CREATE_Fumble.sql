CREATE PROCEDURE [dbo].[CREATE_Fumble]
    @GameId UNIQUEIDENTIFIER, 
    @PlayerId UNIQUEIDENTIFIER, 
	@Team NVARCHAR(10),
    @Total INT = 0, 
    @Recovered INT = 0, 
    @TeamRecovered INT = 0, 
    @Yards INT = 0,
    @Lost INT = 0,
	@GsisId nvarchar(50),
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO Fumbles (FumblesId, GameId, PlayerId, Team, Total, Recovered, TeamRecovered, Yards, Lost, GsisId)
		VALUES (@Id, @GameId, @PlayerId, @Team, @Total, @Recovered, @TeamRecovered, @Yards, @Lost, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH
