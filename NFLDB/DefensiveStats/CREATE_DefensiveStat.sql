CREATE PROCEDURE [dbo].[CREATE_DefensiveStat]
    @GameId UNIQUEIDENTIFIER,
    @PlayerId UNIQUEIDENTIFIER,
    @Tackles INT = 0,
    @Assists INT = 0,
    @Sacks INT = 0,
    @Interceptions INT = 0,
    @ForcedFumbles INT = 0,
	@GsisId nvarchar(50),
	@Id UNIQUEIDENTIFIER OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO DefensiveStats (DefensiveStatsId, GameId, PlayerId, Tackles, Assists, Sacks, Interceptions, ForcedFumbles, GsisId)
		VALUES (@Id, @GameId, @PlayerId, @Tackles, @Assists, @Sacks, @Interceptions, @ForcedFumbles, @GsisId)
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
