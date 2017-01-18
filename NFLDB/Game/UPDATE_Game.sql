CREATE PROCEDURE [dbo].[UPDATE_Game]
	@GameId UNIQUEIDENTIFIER,
	@HomeTeam NVARCHAR(10) = '',
	@AwayTeam NVARCHAR(10) = '',
	@DateTime DATETIME = '1753-1-1',
	@SeasonType VARCHAR(10) = 'NONE',
	@Eid INT = 0,
	@GameKey INT = 0,
	@Week INT = 0,
	@WT NVARCHAR(10) = '',
	@LT NVARCHAR(10) = '',
	@WTScoreFirstQtr INT = 0,
	@WTScoreSecondQtr INT = 0,
	@WTScoreThirdQtr INT = 0,
	@WTScoreFourthQtr INT = 0,
	@WTScoreOT INT = 0,
	@WTScoreFinal INT = 0,
	@LTScoreFirstQtr INT = 0,
	@LTScoreSecondQtr INT = 0,
	@LTScoreThirdQtr INT = 0,
	@LTScoreFourthQtr INT = 0,
	@LTScoreOT INT = 0,
	@LTScoreFinal INT = 0, 
	@NeutralField BIT = 0
AS	
	SELECT * INTO tGame
	FROM Games
	WHERE GameId = @GameId
	
	IF @HomeTeam = ''
	BEGIN
		SET @HomeTeam = (SELECT HomeTeam FROM tGame)
	END

	IF @AwayTeam = ''
	BEGIN
		SET @AwayTeam = (SELECT AwayTeam FROM tGame)
	END

	IF @DateTime = '1753-1-1'
	BEGIN
		SET @DateTime = (SELECT DateTime FROM tGame)
	END

	IF @SeasonType = 'NONE'
	BEGIN
		SET @SeasonType = (SELECT SeasonType FROM tGame)
	END

	IF @Eid = -1
	BEGIN
		SET @Eid = (SELECT Eid FROM tGame)
	END

	IF @GameKey = -1
	BEGIN
		SET @GameKey = (SELECT GameKey FROM tGame)
	END

	IF @Week = -1
	BEGIN
		SET @Week = (SELECT Week FROM tGame)
	END

	IF @WT = ''
	BEGIN
		SET @WT = (SELECT WT FROM tGame)
	END

	IF @LT = ''
	BEGIN
		SET @LT = (SELECT LT FROM tGame)
	END

	IF @WTScoreFirstQtr = -1
	BEGIN
		SET @WTScoreFirstQtr = (SELECT WTScoreFirstQtr FROM tGame)
	END

	IF @WTScoreSecondQtr = -1
	BEGIN
		SET @WTScoreSecondQtr = (SELECT WTScoreSecondQtr FROM tGame)
	END

	IF @WTScoreThirdQtr = -1
	BEGIN
		SET @WTScoreThirdQtr = (SELECT WTScoreThirdQtr FROM tGame)
	END

	IF @WTScoreFourthQtr = -1
	BEGIN
		SET @WTScoreFourthQtr = (SELECT WTScoreFourthQtr FROM tGame)
	END

	IF @WTScoreOT = -1
	BEGIN
		SET @WTScoreOT = (SELECT WTScoreOT FROM tGame)
	END

	IF @WTScoreFinal = -1
	BEGIN
		SET @WTScoreFinal = (SELECT WTScoreFinal FROM tGame)
	END

	IF @LTScoreFirstQtr = -1
	BEGIN
		SET @LTScoreFirstQtr = (SELECT LTScoreFirstQtr FROM tGame)
	END

	IF @LTScoreSecondQtr = -1
	BEGIN
		SET @LTScoreSecondQtr = (SELECT LTScoreSecondQtr FROM tGame)
	END

	IF @LTScoreThirdQtr = -1
	BEGIN
		SET @LTScoreThirdQtr = (SELECT LTScoreThirdQtr FROM tGame)
	END

	IF @LTScoreFourthQtr = -1
	BEGIN
		SET @LTScoreFourthQtr = (SELECT LTScoreFourthQtr FROM tGame)
	END

	IF @LTScoreOT = -1
	BEGIN
		SET @LTScoreOT = (SELECT LTScoreOT FROM tGame)
	END

	IF @LTScoreFinal = -1
	BEGIN
		SET @LTScoreFinal = (SELECT LTScoreFinal FROM tGame)
	END

	BEGIN TRY
		DELETE FROM Games
		WHERE @GameId = GameId

		INSERT INTO [dbo].[Games] (GameId, HomeTeam, AwayTeam, DateTime, SeasonType, Eid, GameKey, Week, WT, LT, WTScoreFirstQtr, WTScoreSecondQtr, WTScoreThirdQtr, WTScoreFourthQtr,
								   WTScoreOT, WTScoreFinal, LTScoreFirstQtr, LTScoreSecondQtr, LTScoreThirdQtr, LTScoreFourthQtr, LTScoreOT, LTScoreFinal, NeutralField)
		VALUES (@GameId, @HomeTeam, @AwayTeam, @DateTime, @SeasonType, @Eid, @GameKey, @Week, @WT, @LT, @WTScoreFirstQtr, @WTScoreSecondQtr, @WTScoreThirdQtr, @WTScoreFourthQtr,
				@WTScoreOT, @WTScoreFinal, @LTScoreFirstQtr, @LTScoreSecondQtr, @LTScoreThirdQtr, @LTScoreFourthQtr, @LTScoreOT, @LTScoreFinal, @NeutralField)

		DROP TABLE tGame
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
