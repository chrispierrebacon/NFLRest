﻿CREATE PROCEDURE [dbo].[CREATE_ReceivingStat]
    @GameId UNIQUEIDENTIFIER, 
    @PlayerId UNIQUEIDENTIFIER, 
	@Team NVARCHAR(10),
    @Receptions INT = 0, 
    @Yards INT = 0, 
    @Touchdowns INT = 0, 
    @Long INT = 0, 
    @TwoPointAttempts INT = 0, 
    @TwoPointsMade INT = 0,
	@GsisId nvarchar(50),
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO ReceivingStats (ReceivingStatsId, GameId, PlayerId, Team, Receptions, Yards, Touchdowns, Long, TwoPointAttempts, TwoPointsMade, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @Team, @Receptions, @Yards, @Touchdowns, @Long, @TwoPointAttempts, @TwoPointsMade, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH
