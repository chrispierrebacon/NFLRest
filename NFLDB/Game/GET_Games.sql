CREATE PROCEDURE [dbo].[GET_Games]
	@Year INT
AS
BEGIN
	SELECT * FROM Games g
	WHERE g.Season = @Year
END
