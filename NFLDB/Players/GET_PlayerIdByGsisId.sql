﻿CREATE PROCEDURE [dbo].[GET_PlayerIdByGsisId]
	@Gsid NVARCHAR(50)
AS
BEGIN
	SELECT TOP 1 PlayerId FROM Players
	WHERE @Gsid = GsisId
END
