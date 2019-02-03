/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TPATH.sql
** Name:	network.Usp_SAVE_TLOCATIONS
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_SAVE_TPATH'))
BEGIN
	DROP PROC [network].Usp_SAVE_TPATH
END
GO

CREATE PROC [network].[Usp_SAVE_TPATH]
(
	@itemno INT = 0,
	@start_ymdv INT,
	@end_ymdv INT,
	@path_itemno INT,
	@start_location_itemno INT,
	@end_location_itemno INT,
	@distance INT, -- Meters
	@direction TINYINT,
	@token_itemno INT,
	@type_itemno SMALLINT,
	@route_availability SMALLINT,
	@berths SMALLINT,
	@permissible_power SMALLINT,
	@cross_count SMALLINT,
	@score SMALLINT,
	@freight_only BIT,
	@max_speed SMALLINT,
	@rating DECIMAL(16,6),
	@signal_type_itemno SMALLINT,
	@options BIGINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@path_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- You must provide a SystemPath (@path_itemno IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	--IF NOT EXISTS (SELECT 1 FROM [network].[TLOCATION] AS L WHERE L.[itemno] = @start_location_itemno AND @start_ymdv BETWEEN L.[start_ymdv] AND ISNULL(L.[end_ymdv], @start_ymdv))
	--BEGIN
	--	SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- No location exists with a @start_location_itemno of ' + CONVERT(NVARCHAR(8), @start_location_itemno) + ' which was active at YMDV ' + CONVERT(NVARCHAR(8), @start_ymdv) + '.';
	--	RAISERROR (@message, 16 ,1);
	--	RETURN;
	--END
	
	--IF NOT EXISTS (SELECT 1 FROM [network].[TLOCATION] AS L WHERE L.[itemno] = @end_location_itemno AND @start_ymdv BETWEEN L.[start_ymdv] AND ISNULL(L.[end_ymdv], @start_ymdv))
	--BEGIN
	--	SET @message = N'Error executing [network].[Usp_SAVE_TPATH]:- No location exists with a @end_location_itemno of ' + CONVERT(NVARCHAR(8), @end_location_itemno) + ' which was active at YMDV ' + CONVERT(NVARCHAR(8), @start_ymdv) + '.';
	--	RAISERROR (@message, 16 ,1);
	--	RETURN;
	--END
	
	IF @itemno != 0
	BEGIN
		UPDATE [network].[TPATH]
		SET
			[start_ymdv] = @start_ymdv,
			[end_ymdv] = NULLIF(@end_ymdv,0),
			[start_location_itemno] = @start_location_itemno,
			[end_location_itemno] = @end_location_itemno,
			[distance] = @distance,
			[direction] = @direction,
			[token_itemno] = NULLIF(@token_itemno,0),
			[type_itemno] = @type_itemno,
			[route_availability] = @route_availability,
			[berths] = @berths,
			[permissible_power] = @permissible_power,
			[crossing_count] = @cross_count,
			[score] = @score,
			[freight_only] = @freight_only,
			[max_speed] = @max_speed,
			[rating] = @rating,
			[signal_type_itemno] = @signal_type_itemno,
			[options] = @options 
		WHERE
			[itemno] = @itemno
			
		SELECT
			itemno = @itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [network].[TPATH] WHERE [path_itemno] = @path_itemno AND [end_ymdv] IS NULL AND [start_location_itemno] = @start_location_itemno AND [end_location_itemno] = @end_location_itemno),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [network].[TPATH] WHERE [path_itemno] = @path_itemno AND [start_ymdv] = @prev_start_ymdv AND [end_location_itemno] = @end_location_itemno),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@start_ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [network].[TPATH]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [network].[TPATH]
		(
			[path_itemno], 
			[start_ymdv],
			[start_location_itemno],
			[end_location_itemno],
			[distance],
			[direction],
			[token_itemno],
			[type_itemno],
			[route_availability],
			[berths],
			[permissible_power],
			[crossing_count],
			[score],
			[freight_only],
			[max_speed],
			[rating],
			[signal_type_itemno],
			[options]
		)
		VALUES
		(
			@path_itemno,
			@start_ymdv,
			ISNULL(@start_location_itemno,0),
			ISNULL(@end_location_itemno,0),
			@distance,
			@direction,
			NULLIF(@token_itemno,0),
			@type_itemno,
			@route_availability,
			@berths,
			@permissible_power,
			@cross_count,
			@score,
			@freight_only,
			@max_speed,
			@rating,
			@signal_type_itemno,
			@options
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
