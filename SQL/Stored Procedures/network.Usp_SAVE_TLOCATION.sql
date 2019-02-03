/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TLOCATION.sql
** Name:	network.Usp_SAVE_TLOCATION
** Desc:	Saves a new instance of a location and closes and previous open record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_TLOCATION'))
BEGIN
	DROP PROC [network].Usp_SAVE_TLOCATION
END
GO

CREATE PROC [network].[Usp_SAVE_TLOCATION]
(
	@itemno INT,
	@start_ymdv INT,
	@end_ymdv INT,
	@location_itemno INT,
	@name NVARCHAR(128),
	@tiploc NVARCHAR(16),
	@stanox INT = 0,
	@stanme NVARCHAR(32),
	@nlc INT,
	@location_typeitemno INT,
	@latitude DECIMAL(16,6),
	@longitude DECIMAL(16,6),
	@parent_location_itemno INT = NULL,
	@length DECIMAL(16,6),
	@disembark_passengers BIT,
	@embark_passengers BIT,
	@freight_only BIT,
	@single_train_working BIT,
	@token_itemno INT,
	@berths SMALLINT,
	@direction TINYINT,
	@score SMALLINT,
	@use_as_timing_point BIT,
	@options BIGINT,
	@permissible_power BIGINT,
	@tops_office BIT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF ISNULL(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You must provide a valid name in @name.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NULL AND NULLIF(@parent_location_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- System Location and Parent Location cannot both be NULL. Please supply either @location_itemno or @parent_location_itemno.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NOT NULL AND NULLIF(@latitude,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You are updating a parent location. Please supply @latitude.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NOT NULL AND NULLIF(@longitude,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TLOCATION]:- You are updating a parent location. Please supply @longitude.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF NULLIF(@location_itemno,0) IS NULL
	BEGIN
		SET @latitude = NULL;
		SET @longitude = NULL;
	END			
	
	IF @start_ymdv = 0 
	BEGIN
		SET @start_ymdv = 18500101;
	END
	
	DECLARE @existing_record_itemno INT 
	
	IF NULLIF(@location_itemno,0) IS NOT NULL
	BEGIN
		SET @existing_record_itemno = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [start_ymdv] = @start_ymdv AND [location_itemno] = ISNULL(@location_itemno,0) AND ISNULL([parent_itemno],0) = 0),0);
	END
	ELSE
	BEGIN
		SET @existing_record_itemno = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [start_ymdv] = @start_ymdv AND [parent_itemno] = @parent_location_itemno AND [name] = @name),0);
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	IF ((@existing_record_itemno != 0 AND @itemno = 0) OR @itemno != 0)
	BEGIN
		SET @existing_record_itemno = @itemno;

		UPDATE [network].[TLOCATION]
		SET
			[name] = CASE WHEN ISNULL(@location_itemno,0) = 0 THEN [name] ELSE @name END, --Child Records cannot have their name changed
			[start_ymdv] = @start_ymdv,
			[end_ymdv] = NULLIF(@end_ymdv,0),
			[tiploc] = NULLIF(@tiploc,''),
			[stanox] = ISNULL(@stanox,0),
			[stanme] = NULLIF(@stanme,''),
			[nlc] = ISNULL(@nlc,0),
			[location_type_itemno] = @location_typeitemno,
			[latitude] = @latitude,
			[longitude] = @longitude,
			[parent_itemno] = NULLIF(@parent_location_itemno,0),
			[length] = @length,
			[disembark_passengers] = @disembark_passengers,
			[embark_passengers] = @embark_passengers,
			[freight_only] = @freight_only,
			[single_train_working] = @single_train_working,
			[token_itemno] = NULLIF(@token_itemno,0),
			[berths] = @berths,
			[direction] = @direction,
			[score] = @score,
			[use_as_timing_point] = @use_as_timing_point,
			[options] = ISNULL(@options,0),
			[permissible_power] = ISNULL(@permissible_power,0),
			[tops_office] = ISNULL(@tops_office,0)
		WHERE
			[itemno] = @existing_record_itemno;
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TLOCATION] WHERE [location_itemno] = @location_itemno AND [end_ymdv] IS NULL AND [start_ymdv] <= @start_ymdv),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TLOCATION] WHERE [location_itemno] = @location_itemno AND [start_ymdv] = @prev_start_ymdv),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@start_ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [network].[TLOCATION]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [network].[TLOCATION]
		(
			[location_itemno], 
			[start_ymdv], 
			[name], 
			[tiploc], 
			[stanox], 
			[stanme], 
			[nlc], 
			[location_type_itemno],
			[latitude],
			[longitude],
			[parent_itemno],
			[length], 
			[disembark_passengers],
			[embark_passengers],
			[freight_only],
			[single_train_working],
			[token_itemno],
			[berths],
			[direction],
			[score],
			[use_as_timing_point],
			[options],
			[permissible_power],
			[tops_office]
		)
		VALUES
		(
			@location_itemno,
			@start_ymdv,
			@name,
			@tiploc,
			ISNULL(@stanox,0),
			@stanme,
			@nlc,
			@location_typeitemno,
			@latitude,
			@longitude,
			NULLIF(@parent_location_itemno,0),
			@length,
			@disembark_passengers,
			@embark_passengers,
			@freight_only,
			@single_train_working,
			NULLIF(@token_itemno,0),
			@berths,
			@direction,
			@score,
			@use_as_timing_point,
			ISNULL(@options,0),
			ISNULL(@permissible_power,0),
			ISNULL(@tops_office,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
