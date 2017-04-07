CREATE PROCEDURE [dbo].[UPDATE_Game]
	@GameId UNIQUEIDENTIFIER,
	@HomeTeam NVARCHAR(10) = '',
	@AwayTeam NVARCHAR(10) = '',
	@DateTime DATETIME = '1753-1-1',
	@SeasonType VARCHAR(10) = 'NONE',
	@Season INT = 0,
	@Eid INT = 0,
	@GameKey INT = 0,
	@Week INT = 0,
	@HTScoreFirstQtr INT = 0,
	@HTScoreSecondQtr INT = 0,
	@HTScoreThirdQtr INT = 0,
	@HTScoreFourthQtr INT = 0,
	@HTScoreOT INT = 0,
	@HTScoreFinal INT = 0,
	@ATScoreFirstQtr INT = 0,
	@ATScoreSecondQtr INT = 0,
	@ATScoreThirdQtr INT = 0,
	@ATScoreFourthQtr INT = 0,
	@ATScoreOT INT = 0,
	@ATScoreFinal INT = 0, 
	@NeutralField BIT = 0,
	@ErrorMessage NVARCHAR(256) = '' OUTPUT,
	@ErrorNumber INT = '' OUTPUT
AS	
	SELECT * INTO #tGame
	FROM Games
	WHERE GameId = @GameId
	
	IF @HomeTeam = ''
	BEGIN
		SET @HomeTeam = (SELECT HomeTeam FROM #tGame)
	END

	IF @AwayTeam = ''
	BEGIN
		SET @AwayTeam = (SELECT AwayTeam FROM #tGame)
	END

	IF @DateTime = '1753-1-1'
	BEGIN
		SET @DateTime = (SELECT DateTime FROM #tGame)
	END

	IF @SeasonType = 'NONE'
	BEGIN
		SET @SeasonType = (SELECT SeasonType FROM #tGame)
	END

	IF @Season = 0
	BEGIN
		SET @Season = (SELECT Season FROM #tGame)
	END

	IF @Eid = -1
	BEGIN
		SET @Eid = (SELECT Eid FROM #tGame)
	END

	IF @GameKey = -1
	BEGIN
		SET @GameKey = (SELECT GameKey FROM #tGame)
	END

	IF @Week = -1
	BEGIN
		SET @Week = (SELECT Week FROM #tGame)
	END

	IF @HTScoreFirstQtr = -1
	BEGIN
		SET @HTScoreFirstQtr = (SELECT HTScoreFirstQtr FROM #tGame)
	END

	IF @HTScoreSecondQtr = -1
	BEGIN
		SET @HTScoreSecondQtr = (SELECT HTScoreSecondQtr FROM #tGame)
	END

	IF @HTScoreThirdQtr = -1
	BEGIN
		SET @HTScoreThirdQtr = (SELECT HTScoreThirdQtr FROM #tGame)
	END

	IF @HTScoreFourthQtr = -1
	BEGIN
		SET @HTScoreFourthQtr = (SELECT HTScoreFourthQtr FROM #tGame)
	END

	IF @HTScoreOT = -1
	BEGIN
		SET @HTScoreOT = (SELECT HTScoreOT FROM #tGame)
	END

	IF @HTScoreFinal = -1
	BEGIN
		SET @HTScoreFinal = (SELECT HTScoreFinal FROM #tGame)
	END

	IF @ATScoreFirstQtr = -1
	BEGIN
		SET @ATScoreFirstQtr = (SELECT ATScoreFirstQtr FROM #tGame)
	END

	IF @ATScoreSecondQtr = -1
	BEGIN
		SET @ATScoreSecondQtr = (SELECT ATScoreSecondQtr FROM #tGame)
	END

	IF @ATScoreThirdQtr = -1
	BEGIN
		SET @ATScoreThirdQtr = (SELECT ATScoreThirdQtr FROM #tGame)
	END

	IF @ATScoreFourthQtr = -1
	BEGIN
		SET @ATScoreFourthQtr = (SELECT ATScoreFourthQtr FROM #tGame)
	END

	IF @ATScoreOT = -1
	BEGIN
		SET @ATScoreOT = (SELECT ATScoreOT FROM #tGame)
	END

	IF @ATScoreFinal = -1
	BEGIN
		SET @ATScoreFinal = (SELECT ATScoreFinal FROM #tGame)
	END

	BEGIN TRY
		DELETE FROM Games
		WHERE @GameId = GameId

		INSERT INTO [dbo].[Games] (GameId, HomeTeam, AwayTeam, DateTime, SeasonType, Season, Eid, GameKey, Week, HTScoreFirstQtr, HTScoreSecondQtr, HTScoreThirdQtr, HTScoreFourthQtr,
								   HTScoreOT, HTScoreFinal, ATScoreFirstQtr, ATScoreSecondQtr, ATScoreThirdQtr, ATScoreFourthQtr, ATScoreOT, ATScoreFinal, NeutralField)
		VALUES (@GameId, @HomeTeam, @AwayTeam, @DateTime, @SeasonType, @Season, @Eid, @GameKey, @Week, @HTScoreFirstQtr, @HTScoreSecondQtr, @HTScoreThirdQtr, @HTScoreFourthQtr,
				@HTScoreOT, @HTScoreFinal, @ATScoreFirstQtr, @ATScoreSecondQtr, @ATScoreThirdQtr, @ATScoreFourthQtr, @ATScoreOT, @ATScoreFinal, @NeutralField)

		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH
	IF OBJECT_ID('tempdb..#tGame') IS NOT NULL -- Check for table existence
		DROP TABLE #tGame;
