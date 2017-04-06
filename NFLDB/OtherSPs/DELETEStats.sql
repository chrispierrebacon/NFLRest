CREATE PROCEDURE [dbo].[DELETEStats]
AS
	DELETE FROM PassingStats
	DELETE FROM RushingStats
	DELETE FROM ReceivingStats
	DELETE FROM DefensiveStats
	DELETE FROM KickingStats
	DELETE FROM KickReturnStats
	DELETE FROM PuntingStats
	DELETE FROM PuntReturnStats
	DELETE FROM Fumbles
RETURN 0
