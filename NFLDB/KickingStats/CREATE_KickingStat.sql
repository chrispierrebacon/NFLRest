CREATE PROCEDURE [dbo].[CREATE_KickingStat]
    @GameId UNIQUEIDENTIFIER,
    @PlayerId UNIQUEIDENTIFIER,
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
	@Id UNIQUEIDENTIFIER OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO KickingStats (KickingStatsId, GameId, PlayerId, FieldGoalsMade, FieldGoalsAttempted, Yards, TotalPoints, ExtraPointsMade,
								  ExtraPointsMissed, ExtraPointsAttempted, ExtraPointsBlocked, ExtraPointsTotal, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @FieldGoalsMade, @FieldGoalsAttempted, @Yards, @TotalPoints, @ExtraPointsMade, @ExtraPointsMissed,
			   @ExtraPointsAttempted, @ExtraPointsBlocked, @ExtraPointsTotal, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
