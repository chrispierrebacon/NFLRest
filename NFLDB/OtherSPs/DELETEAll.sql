﻿CREATE PROCEDURE [dbo].[DELETEAll]

AS
	EXEC DELETEStats
	DELETE FROM Games
	DELETE FROM Players
RETURN 0
