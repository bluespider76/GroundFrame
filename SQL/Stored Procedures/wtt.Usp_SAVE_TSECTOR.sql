/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\wtt.Usp_SAVE_TTRAIN.sql
** Name:	wtt.Usp_SAVE_TTRAIN
** Desc:	Saves a TRAIN record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('wtt.Usp_SAVE_TTRAIN'))
BEGIN
	DROP PROC [wtt].[Usp_SAVE_TTRAIN]
END
GO

CREATE PROC [wtt].[Usp_SAVE_TTRAIN]
(
	@itemno								INT = 0,
	@ymdv								INT,
	@headcode							NVARCHAR(8),
	@description						NVARCHAR(2048),
	@start_location_itemno				INT,
	@end_location_itemno				INT,
	@mp_next_train_itemno				INT,
	@mp_next_train_perc					DECIMAL,
	@mp_next_train_min_turnaround		TINYINT,
	@stock_next_train_itemno			INT,
	@stock_next_train_perc				DECIMAL,
	@stock_next_train_min_turnaround	TINYINT,
	@parent_train_itemno				INT,
	@mins_allocation_on_tops			TINYINT,
	@start_time							BIGINT, --Stored as Ticks
	@days								TINYINT,
	@brake_types						TINYINT,
	@heat_types							TINYINT,
	@configuration						BIGINT,
	@max_speed							SMALLINT,
	@max_speed_if_late					SMALLINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@headcode,'') IS NULL
	BEGIN
		SET @message = N'Error executing [wtt].[Usp_SAVE_TTRAIN]:- You must provide a headcode (@headcode IS NULL)';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	
	IF @itemno = 0
	BEGIN	
		 SET @itemno = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [start_ymdv] = @ymdv AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	END
	
	IF @itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[headcode] = NULLIF(@headcode, ''), 
			[description] = NULLIF(@description, ''), 
			[start_location_itemno] = NULLIF(@start_location_itemno,0), 
			[end_location_itemno] = NULLIF(@end_location_itemno,0),  
			[mp_next_train_itemno] = NULLIF(@mp_next_train_itemno,0),
			[mp_next_train_perc] = NULLIF(@mp_next_train_perc,0),
			[mp_next_train_min_turnaround] = NULLIF(@mp_next_train_min_turnaround,0),
			[stock_next_train_itemno] = NULLIF(@stock_next_train_itemno,0),
			[stock_next_train_perc] = NULLIF(@stock_next_train_perc,0), 
			[stock_next_train_min_turnaround] = NULLIF(@stock_next_train_min_turnaround,0), 
			[parent_train_itemno] = NULLIF(@parent_train_itemno,0), 
			[mins_allocation_on_tops] = NULLIF(@mins_allocation_on_tops,0), 
			[start_time] = NULLIF(@start_time,0), 
			[days] = NULLIF(@days,0),  
			[brake_types] = NULLIF(@brake_types,0), 
			[heat_types] = NULLIF(@heat_types,0), 
			[configuration] = NULLIF(@configuration,0), 
			[max_speed] = NULLIF(@max_speed,0), 
			[max_speed_if_late] = NULLIF(@max_speed_if_late,0)
		WHERE
			[itemno] = @itemno
			
		RETURN;
	END;

	DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [wtt].[TTRAIN] WHERE [end_ymdv] IS NULL AND [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0)),0);
	DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [wtt].[TTRAIN] WHERE [headcode] = NULLIF(@headcode,'') AND [start_location_itemno] = NULLIF(@start_location_itemno,0) and [end_location_itemno] = NULLIF(@end_location_itemno,0) AND [start_time] = NULLIF(@start_time,0) AND [start_ymdv] = @prev_start_ymdv),0);
	DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
	IF @prev_record_itemno != 0
	BEGIN
		UPDATE [wtt].[TTRAIN]
		SET
			[end_ymdv] = @new_end_ymdv
		WHERE
			[itemno] = @prev_record_itemno;
	END
	
	INSERT INTO [wtt].[TTRAIN]
	(
		[headcode], 
		[description], 
		[start_location_itemno], 
		[end_location_itemno],  
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno],
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno], 
		[mins_allocation_on_tops], 
		[start_time], 
		[days],  
		[brake_types], 
		[heat_types], 
		[configuration], 
		[max_speed], 
		[max_speed_if_late]
	)
	VALUES
	(
		NULLIF(@headcode, ''), 
		NULLIF(@description, ''), 
		NULLIF(@start_location_itemno,0), 
		NULLIF(@end_location_itemno,0),  
		NULLIF(@mp_next_train_itemno,0),
		NULLIF(@mp_next_train_perc,0),
		NULLIF(@mp_next_train_min_turnaround,0),
		NULLIF(@stock_next_train_itemno,0),
		NULLIF(@stock_next_train_perc,0), 
		NULLIF(@stock_next_train_min_turnaround,0), 
		NULLIF(@parent_train_itemno,0), 
		NULLIF(@mins_allocation_on_tops,0), 
		NULLIF(@start_time,0), 
		NULLIF(@days,0),  
		NULLIF(@brake_types,0), 
		NULLIF(@heat_types,0), 
		NULLIF(@configuration,0), 
		NULLIF(@max_speed,0), 
		NULLIF(@max_speed_if_late,0)
	);
	
	SET NOCOUNT OFF;
END
GO
