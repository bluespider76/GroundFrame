/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TDEPOT.sql
** Name:	network.[Usp_SAVE_TDEPOT
** Desc:	Retieves all depot records for a given system location and ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_TDEPOT'))
BEGIN
	DROP PROC [network].[Usp_SAVE_TDEPOT]
END
GO

CREATE PROC [network].[Usp_SAVE_TDEPOT]
(
	@location_itemno INT,
	@ymdv INT,
	@code NVARCHAR(16),
	@ease_of_access DECIMAL(16,6),
	@percentage_visible_from_train DECIMAL(16,6),
	@capabilities INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@location_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TDEPOT]:- You must provide a Location (@location_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TDEPOT] WHERE [start_ymdv] = @ymdv AND [location_itemno] = @location_itemno),0);

	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [network].[TDEPOT]
		SET
			[code] = @code,
			[ease_of_access] = @ease_of_access,
			[percentage_visible_from_train] = @percentage_visible_from_train,
			[capabilities] = @capabilities
		WHERE
			[itemno] = @existing_record_itemno;

		SELECT
			[itemno] = @existing_record_itemno;
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TDEPOT] WHERE [location_itemno] = @location_itemno AND [end_ymdv] IS NULL),18500101);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TDEPOT] WHERE [location_itemno] = @location_itemno AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [network].[TDEPOT]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END

	INSERT INTO [network].[TDEPOT]
	(
		[location_itemno],
		[start_ymdv],
		[code],
		[ease_of_access],
		[percentage_visible_from_train],
		[capabilities]
	)
	VALUES
	(
		@location_itemno,
		@ymdv,
		@code,
		@ease_of_access,
		@percentage_visible_from_train,
		@capabilities
	);

	SELECT
		[itemno] = SCOPE_IDENTITY();

	SET NOCOUNT OFF;
END
GO
