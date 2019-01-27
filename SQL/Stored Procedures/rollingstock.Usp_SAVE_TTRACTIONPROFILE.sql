/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_SAVE_TTRACTIONPROFILE.sql
** Name:	rollingstock.Usp_SAVE_TTRACTIONPROFILE
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_SAVE_TTRACTIONPROFILE'))
BEGIN
	DROP PROC [rollingstock].Usp_SAVE_TTRACTIONPROFILE
END
GO

CREATE PROC [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]
(
	@traction_class_itemno NVARCHAR(128),
	@max_speed INT,
	@max_speed_light_loco INT,
	@power_itemno INT,
	@tractive_effort INT,
	@horse_power INT

)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(512);
	
	IF NULLIF(@traction_class_itemno,0) IS NULL
	BEGIN
		SET @message = N'Error executing [rollingstock].[Usp_SAVE_TTRACTIONPROFILE]:- You must provide a traction type. @traction_class_itemno IS NULL';
		RAISERROR (@message, 16 ,1);
		RETURN;
	END
	
	--Check to see if a record has been created for @ymdv. If so we'll need to update this record
	DECLARE @existing_record_itemno INT = ISNULL((SELECT [itemno] FROM [rollingstock].[TTRACTIONPROFILE] WHERE [traction_class_itemno] = @traction_class_itemno AND [power_itemno] = @power_itemno),0);
	
	IF @existing_record_itemno != 0
	BEGIN
		UPDATE [rollingstock].[TTRACTIONPROFILE]
		SET
			[max_speed] = @max_speed,
			[tractive_effort] = @tractive_effort,
			[horse_power] = @horse_power
		WHERE
			[itemno] = @existing_record_itemno
			
		SELECT
			itemno = @existing_record_itemno;
		
		RETURN;
	END
	ELSE
	BEGIN
		INSERT INTO [rollingstock].[TTRACTIONPROFILE]
		(
			[traction_class_itemno],
			[power_itemno],
			[max_speed],
			[max_speed_light_loco],
			[tractive_effort],
			[horse_power]
		)
		VALUES
		(
			@traction_class_itemno,
			@power_itemno,
			@max_speed,
			@max_speed_light_loco,
			@tractive_effort,
			@horse_power
		);
		
		SELECT
			itemno = SCOPE_IDENTITY();
	END
	
	SET NOCOUNT OFF;
END
GO
