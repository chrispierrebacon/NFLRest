CREATE PROCEDURE [dbo].[CREATE_KickReturnStat]
    @GameId UNIQUEIDENTIFIER, 
    @PlayerId UNIQUEIDENTIFIER, 
	@Returns INT = 0,
    @Average INT = 0, 
    @Touchdowns INT = 0, 
    @Long INT = 0, 
    @LongTouchdown INT = 0,
	@GsisId NVARCHAR(50),
	@Id UNIQUEIDENTIFIER OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO KickReturnStats (KickReturnStatsId, GameId, PlayerId, Returns, Average, Touchdowns, Long, LongTouchdown, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @Returns, @Average, @Touchdowns, @Long, @LongTouchdown, @GsisId)
			RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
