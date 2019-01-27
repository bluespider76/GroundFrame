/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_SYSTEMPATH.sql
** Name:	network.Usp_SAVE_SYSTEMPATH
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_SYSTEMPATH'))
BEGIN
	DROP PROC [network].[Usp_SAVE_SYSTEMPATH]
END
GO

CREATE PROC [network].[Usp_SAVE_SYSTEMPATH]
(
	@itemno INT,
	@system_name NVARCHAR(128),
	@system_description NVARCHAR(2048),
	@system_start_location_itemno INT,
	@system_end_location_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF EXISTS (SELECT 1 FROM network.TSYSTEMPATH WHERE [system_name] = NULLIF(@system_name,'')) AND @itemno = 0
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_SYSTEMPATH]:- SystemPath ' + @system_name + ' already exists in the database.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF ISNULL(@system_name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_SYSTEMPATH]:- You must provide a name. It cannot be <null> or an empty string.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END

	IF @itemno != 0
	BEGIN
		UPDATE [network].[TSYSTEMPATH]
		SET 
			[system_description] = ISNULL(NULLIF(@system_description,''),[system_description])
		WHERE
			[system_itemno] = @itemno;
	
		SELECT
			[system_itemno],
			[system_name],
			[system_description],
			[system_start_location_itemno],
			[system_end_location_itemno]
		FROM [network].[TSYSTEMPATH]
		WHERE
			[system_itemno] = @itemno;
	END
	ELSE
	BEGIN
		INSERT INTO network.[TSYSTEMPATH]
		(
			[system_name],
			[system_description],
			[system_start_location_itemno],
			[system_end_location_itemno]
		)
		VALUES
		(
			@system_name,
			NULLIF(@system_description,''),
			@system_start_location_itemno,
			@system_end_location_itemno
		)
		
		SELECT
			@itemno = CONVERT(INT, SCOPE_IDENTITY());
		
		SELECT
			[system_itemno],
			[system_name],
			[system_description],
			[system_start_location_itemno],
			[system_end_location_itemno]
		FROM [network].[TSYSTEMPATH]
		WHERE
			[system_itemno] = @itemno;
	END

	SET NOCOUNT OFF;
END
GO
