/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TTRACTIONCLASS.sql
** Name:	rollingstock.Usp_SAVE_TTRACTIONCLASS
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_SAVE_TTRACTIONCLASS'))
BEGIN
	DROP PROC [rollingstock].Usp_SAVE_TTRACTIONCLASS
END
GO

CREATE PROC [rollingstock].[Usp_SAVE_TTRACTIONCLASS]
(
	@itemno INT,
	@start_ymdv INT,
	@end_ymdv INT,
	@name NVARCHAR(128),
	@description NVARCHAR(2048),
	@parent_itemno INT,
	@traction_type_itemno TINYINT,
	@length DECIMAL(16,6),
	@route_availability TINYINT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@name,'') IS NULL
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONCLASS]:- You must provide a name for the traction class';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	
	IF @start_ymdv = 0 
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONCLASS]:- You must provide a Start YMDV for the traction class';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @itemno = 0 AND EXISTS (SELECT 1 FROM [rollingstock].[TTRACTIONCLASS] WHERE name = @name)
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONCLASS]:- The traction class ' + @name + ' already exists in the database';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	IF @itemno != 0
	BEGIN
		UPDATE [rollingstock].[TTRACTIONCLASS]
		SET
			[start_ymdv] = @start_ymdv,
			[end_ymdv] =  ISNULL(@end_ymdv,0),
			[description] = @description,
			[parent_itemno] = NULLIF(@parent_itemno,0),
			[traction_type_itemno] = ISNULL(@traction_type_itemno,0),
			[length] = ISNULL(@length,0),
			[route_availability] = NULLIF(@route_availability,0)
		WHERE
			[itemno] = @itemno
			
		SELECT
			itemno = @itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		INSERT INTO [rollingstock].[TTRACTIONCLASS]
		(
			[start_ymdv],
			[end_ymdv],
			[name],
			[description],
			[parent_itemno],
			[traction_type_itemno],
			[length],
			[route_availability]
		)
		VALUES
		(
			@start_ymdv,
			ISNULL(@end_ymdv,0),
			@name,
			@description,
			NULLIF(@parent_itemno,0),
			ISNULL(@traction_type_itemno,0),
			ISNULL(@length,0),
			NULLIF(@route_availability,0)
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
