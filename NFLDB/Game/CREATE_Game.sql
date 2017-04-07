CREATE PROCEDURE [dbo].[CREATE_Game]
	@HomeTeam NVARCHAR(10),
	@AwayTeam NVARCHAR(10),
	@DateTime DATETIME,
	@SeasonType NVARCHAR(5),
	@Season INT,
	@Eid INT,
	@GameKey INT,
	@Week INT,
	@WTScoreFirstQtr INT = -1,
	@WTScoreSecondQtr INT = -1,
	@WTScoreThirdQtr INT = -1,
	@WTScoreFourthQtr INT = -1,
	@WTScoreOT INT = -1,
	@WTScoreFinal INT = -1,
	@LTScoreFirstQtr INT = -1,
	@LTScoreSecondQtr INT = -1,
	@LTScoreThirdQtr INT = -1,
	@LTScoreFourthQtr INT = -1,
	@LTScoreOT INT = -1,
	@LTScoreFinal INT = -1, 
	@NeutralField BIT = 0,
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT

AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO [dbo].[Games] (GameId, HomeTeam, AwayTeam, DateTime, SeasonType, Season, Eid, GameKey, Week, HTScoreFirstQtr, HTScoreSecondQtr, HTScoreThirdQtr, HTScoreFourthQtr,
								   HTScoreOT, HTScoreFinal, ATScoreFirstQtr, ATScoreSecondQtr, ATScoreThirdQtr, ATScoreFourthQtr, ATScoreOT, ATScoreFinal, NeutralField)
		VALUES (@Id, @HomeTeam, @AwayTeam, @DateTime, @SeasonType, @Season, @Eid, @GameKey, @Week, @WTScoreFirstQtr, @WTScoreSecondQtr, @WTScoreThirdQtr, @WTScoreFourthQtr,
				@WTScoreOT, @WTScoreFinal, @LTScoreFirstQtr, @LTScoreSecondQtr, @LTScoreThirdQtr, @LTScoreFourthQtr, @LTScoreOT, @LTScoreFinal, @NeutralField)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH

