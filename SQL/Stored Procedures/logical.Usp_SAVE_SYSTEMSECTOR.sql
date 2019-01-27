/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_SAVE_SYSTEMSECTOR.sql
** Name:	logical.Usp_SAVE_SYSTEMSECTOR
** Desc:	Saves a TSYSTEMSECTOR record
** Auth:	Tim Caceres
** Date:	2018-04-13
**************************
** Change History
**************************
** Ver	Date		Author		Description 
** ---  --------	-------		------------------------------------
** 1    2018-07-19  TC			Initial Script creation
**
*******************************/
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_SAVE_SYSTEMSECTOR'))
BEGIN
	DROP PROC [logical].[Usp_SAVE_SYSTEMSECTOR]
END
GO

CREATE PROC [logical].[Usp_SAVE_SYSTEMSECTOR]
(
	@itemno INT,
	@code NVARCHAR(4)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF EXISTS (SELECT 1 FROM logical.TSYSTEMSECTOR WHERE code = @code)
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_SYSTEMSECTOR]:- SystemSector ' + @code + ' already exists in the database.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END

	IF @itemno != 0
	BEGIN
		SELECT
			[code] = @code;
	END
	ELSE
	BEGIN
		INSERT INTO logical.TSYSTEMSECTOR
		(
			[code]
		)
		VALUES
		(
			@code
		)
		
		SELECT
			@itemno = CONVERT(INT, SCOPE_IDENTITY());
		
		SELECT
			[itemno] = @itemno,
			[code] = @code;
	END

	SET NOCOUNT OFF;
END
GO
