/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_SAVE_SECTOR.sql
** Name:	logical.Usp_SAVE_SECTOR
** Desc:	Saves a TSECTOR record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_SAVE_SECTOR'))
BEGIN
	DROP PROC [logical].[Usp_SAVE_SECTOR]
END
GO

CREATE PROC [logical].[Usp_SAVE_SECTOR]
(
	@code_itemno INT,
	@ymdv INT,
	@description NVARCHAR(2048)
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@code_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_SECTOR]:- You must provide a @code_itemno (@code_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [logical].[TSECTOR] WHERE [start_ymdv] = @ymdv AND [code_itemno] = @code_itemno),0);

	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [logical].[TSECTOR]
		SET
			[description] = @description
		WHERE
			[itemno] = @existing_record_itemno;
		
		DECLARE @end_ymdv INT = (SELECT [end_ymdv] FROM [logical].[TSECTOR] WHERE itemno = @existing_record_itemno);

		SELECT
			[itemno] = @existing_record_itemno,
			[end_ymdv] = @end_ymdv;
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [logical].[TSECTOR] WHERE [code_itemno] = @code_itemno AND [end_ymdv] IS NULL),18500101);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [logical].[TSECTOR] WHERE [code_itemno] = @code_itemno AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [logical].[TSECTOR]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END

	INSERT INTO [logical].[TSECTOR]
	(
		[description],
		[start_ymdv],
		[code_itemno]
	)
	VALUES
	(
		@description,
		@ymdv,
		@code_itemno
	);

	SELECT
		[itemno] = SCOPE_IDENTITY(),
		[end_ymdv] = NULL;

	SET NOCOUNT OFF;
END
GO
