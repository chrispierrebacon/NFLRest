CREATE PROCEDURE [dbo].[CREATE_Team]
	@Prefix NVARCHAR(50) ,
	@City NVARCHAR(50) = '',
	@NickName NVARCHAR(50) = '',
	@Conference NVARCHAR(50),
	@Division NVARCHAR(50),
	@Id UNIQUEIDENTIFIER OUTPUT
AS
	SET @Id = NEWID()
	BEGIN TRY
		INSERT INTO [dbo].[Teams] (TeamId, Prefix, City, NickName, Conference, Division)
		VALUES (@Id, @Prefix, @City, @NickName, @Conference, @Division)
		RETURN 1
	END TRY
	BEGIN CATCH
		RETURN 0
	END CATCH
