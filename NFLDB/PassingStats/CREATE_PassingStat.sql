CREATE PROCEDURE [dbo].[CREATE_PassingStat]
    @GameId UNIQUEIDENTIFIER, 
    @PlayerId UNIQUEIDENTIFIER, 
    @Attempts INT = 0, 
    @Completions INT = 0, 
    @Yards INT = 0, 
    @Touchdowns INT = 0, 
    @Interceptions INT = 0, 
    @TwoPointAttempts INT = 0, 
    @TwoPointMakes INT = 0,
	@GsisId NVARCHAR(50),
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS

	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO PassingStats (PassingStatsId, GameId, PlayerId, Attempts, Completions, Yards, Touchdowns, Interceptions, TwoPointAttempts,
								  TwoPointMakes, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @Attempts, @Completions, @Yards, @Touchdowns, @Interceptions, @TwoPointAttempts, @TwoPointMakes, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0		
	END CATCH
