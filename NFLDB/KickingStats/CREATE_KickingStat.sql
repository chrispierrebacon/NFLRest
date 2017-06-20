CREATE PROCEDURE [dbo].[CREATE_KickingStat]
    @GameId UNIQUEIDENTIFIER,
    @PlayerId UNIQUEIDENTIFIER,
	@Team NVARCHAR(10),
    @FieldGoalsMade INT = 0,
    @FieldGoalsAttempted INT = 0,
    @Yards INT = 0,
    @TotalPoints INT = 0, 
    @ExtraPointsMade INT = 0, 
	@ExtraPointsMissed INT = 0,
    @ExtraPointsAttempted INT = 0,
	@ExtraPointsBlocked INT = 0,
	@ExtraPointsTotal INT = 0,
	@GsisId nvarchar(50),	
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO KickingStats (KickingStatsId, GameId, PlayerId, Team, FieldGoalsMade, FieldGoalsAttempted, Yards, TotalPoints, ExtraPointsMade,
								  ExtraPointsMissed, ExtraPointsAttempted, ExtraPointsBlocked, ExtraPointsTotal, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @Team, @FieldGoalsMade, @FieldGoalsAttempted, @Yards, @TotalPoints, @ExtraPointsMade, @ExtraPointsMissed,
			   @ExtraPointsAttempted, @ExtraPointsBlocked, @ExtraPointsTotal, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH
