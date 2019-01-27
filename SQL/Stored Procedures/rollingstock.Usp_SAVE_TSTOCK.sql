/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_SAVE_TSTOCK.sql
** Name:	rollingstock.Usp_SAVE_TSTOCK
** Desc:	Saves a new instance of a stock item and closes any previous open record
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_SAVE_TSTOCK'))
BEGIN
	DROP PROC [rollingstock].Usp_SAVE_TSTOCK
END
GO

CREATE PROC [rollingstock].[Usp_SAVE_TSTOCK]
(
	@ymdv INT,
	@type_itemno TINYINT,
	@name NVARCHAR(128),
	@description NVARCHAR(2048),
	@coupling_types SMALLINT,
	@brake_types SMALLINT,
	@heating_types SMALLINT,
	@max_speed SMALLINT,
	@length SMALLINT,
	@options INT,
	@eth_index SMALLINT,
	@weight SMALLINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF ISNULL(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [network].[Usp_SAVE_TSTOCK]:- You must provide a valid name in @name.';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @ymdv = 0 
	BEGIN
		SET @ymdv = 18500101;
	END
	
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TSTOCK] WHERE [start_ymdv] = @ymdv AND [name] = @name AND [type_itemno] = @type_itemno),0); 
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [rollingstock].[TSTOCK]
		SET
			[description] = NULLIF(@description,''),
			[coupling_types] = NULLIF(@coupling_types, 0),
			[brake_types] = NULLIF(@brake_types, 0),	
			[heating_types] = NULLIF(@heating_types, 0),	
			[max_speed]	= NULLIF(@max_speed, 0),		
			[length] = NULLIF(@length, 0),			
			[options] = NULLIF(@options, 0),			
			[eth_index]	 = NULLIF(@eth_index, 0),
			[weight] = NULLIF(@weight,0)			
		WHERE
			[itemno] = @existing_record_itemno;
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		DECLARE @prev_start_ymdv INT = ISNULL((SELECT [start_ymdv] FROM [rollingstock].[TSTOCK] WHERE [name] = @name AND [type_itemno] = @type_itemno AND [end_ymdv] IS NULL),18500101);
		DECLARE @prev_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TSTOCK] WHERE [name] = @name AND [type_itemno] = @type_itemno AND [start_ymdv] = @prev_start_ymdv),0);
		DECLARE @new_end_ymdv INT = (SELECT [common].[Fn_YMDV_ADD](@ymdv,-1));
	
		IF @prev_record_itemno != 0
		BEGIN
			UPDATE [rollingstock].[TSTOCK]
			SET
				[end_ymdv] = @new_end_ymdv
			WHERE
				[itemno] = @prev_record_itemno;
		END
		
		INSERT INTO [rollingstock].[TSTOCK]
		(
			[start_ymdv],
			[type_itemno],
			[name],
			[description],
			[coupling_types],
			[brake_types],
			[heating_types],
			[max_speed],
			[length],
			[options],
			[eth_index],
			[weight]
		)
		VALUES
		(
			@ymdv,
			@type_itemno,
			NULLIF(@name,''),
			NULLIF(@description,''),
			NULLIF(@coupling_types, 0),
			NULLIF(@brake_types, 0),
			NULLIF(@heating_types, 0),
			NULLIF(@max_speed, 0),
			NULLIF(@length, 0),		
			NULLIF(@options, 0),
			NULLIF(@eth_index, 0),
			NULLIF(@weight,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
