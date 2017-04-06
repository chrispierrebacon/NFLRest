CREATE PROCEDURE [dbo].[CREATE_DefensiveStat]
    @GameId UNIQUEIDENTIFIER,
    @PlayerId UNIQUEIDENTIFIER,
    @Tackles INT = 0,
    @Assists INT = 0,
    @Sacks INT = 0,
    @Interceptions INT = 0,
    @ForcedFumbles INT = 0,
	@GsisId nvarchar(50),
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO DefensiveStats (DefensiveStatsId, GameId, PlayerId, Tackles, Assists, Sacks, Interceptions, ForcedFumbles, GsisId)
		VALUES (@Id, @GameId, @PlayerId, @Tackles, @Assists, @Sacks, @Interceptions, @ForcedFumbles, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH
