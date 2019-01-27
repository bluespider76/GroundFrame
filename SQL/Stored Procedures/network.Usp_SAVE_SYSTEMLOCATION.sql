/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_SYSTEMLOCATION.sql
** Name:	network.Usp_SAVE_SYSTEMLOCATION
** Desc:	Saves a TSYSTEMLOCATION record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_SYSTEMLOCATION'))
BEGIN
	DROP PROC [network].[Usp_SAVE_SYSTEMLOCATION]
END
GO

CREATE PROC [network].[Usp_SAVE_SYSTEMLOCATION]
(
	@itemno INT,
	@system_name NVARCHAR(128)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF EXISTS (SELECT 1 FROM network.TSYSTEMLOCATION WHERE [system_name] = @system_name) AND @itemno = 0
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_SYSTEMSECTOR]:- SystemLocation ' + @system_name + ' already exists in the database.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END

	IF ISNULL(@itemno,0) != 0
	BEGIN
		SELECT
			[itemno] = @itemno,
			[system_name] = @system_name;
	END
	ELSE
	BEGIN
		INSERT INTO network.TSYSTEMLOCATION
		(
			[system_name]
		)
		VALUES
		(
			@system_name
		)
		
		SELECT
			@itemno = CONVERT(INT, SCOPE_IDENTITY());
		
		SELECT
			[itemno] = @itemno,
			[system_name] = @system_name;
	END

	SET NOCOUNT OFF;
END
GO
