CREATE PROCEDURE [dbo].[CREATE_PuntingStat]
    @GameId UNIQUEIDENTIFIER, 
    @PlayerId UNIQUEIDENTIFIER, 
    @Punts INT = 0, 
    @Yards INT = 0, 
    @Average INT = 0, 
    @InsideTwenty INT = 0, 
    @Long INT = 0,
	@GsisId nvarchar(50),
	@Id UNIQUEIDENTIFIER OUTPUT

AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO PuntingStats (PuntingStatsId, GameId, PlayerId, Punts, Yards, Average, InsideTwenty, Long, GsisId)
		VALUES(@Id, @GameId, @PlayerId, @Punts, @Yards, @Average, @InsideTwenty, @Long, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
