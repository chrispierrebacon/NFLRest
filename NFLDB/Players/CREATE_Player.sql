CREATE PROCEDURE [dbo].[CREATE_Player]
	@FirstName nvarchar(50) = '',
	@LastName nvarchar(50) = '',
	@Position nvarchar(10) = '',
	@Team nvarchar(10) = '',
	@Birthdate datetime = '1753-1-1',
	@College nvarchar(50) = '',
	@FullName nvarchar(50) = '',
	@GsisId nvarchar(50) = '',
	@GsisName nvarchar(50) = '',
	@Height int = -1,
	@Number int = -1,
	@ProfileId nvarchar(50) = -1,
	@ProfileUrl nvarchar(50) = -1,
	@Status nvarchar(10) = '',
	@Weight int = -1,
	@YearsPro int = -1,
	@Id UNIQUEIDENTIFIER OUTPUT,
	@ErrorMessage NVARCHAR(256) OUTPUT,
	@ErrorNumber INT OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO [dbo].[Players] (PlayerId, FirstName, LastName, Position, Team, Birthdate, College, FullName, GsisId, GsisName, Height, Number, ProfileId, ProfileUrl, Status, Weight, YearsPro)
		VALUES (@Id, @FirstName, @LastName, @Position, @Team, @Birthdate, @College, @FullName, @GsisId, @GsisName, @Height, @Number, @ProfileId, @ProfileUrl, @Status, @Weight, @YearsPro)
		RETURN 1
	END TRY
	BEGIN CATCH
		SET @ErrorMessage = ERROR_MESSAGE()
		SET @ErrorNumber = ERROR_NUMBER()
		RETURN 0
	END CATCH