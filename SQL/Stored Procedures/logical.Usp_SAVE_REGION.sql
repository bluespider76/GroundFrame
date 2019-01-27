/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_SAVE_REGION.sql
** Name:	logical.Usp_GET_REGIONS_BY_YMDV
** Desc:	Save a region
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_SAVE_REGION'))
BEGIN
	DROP PROC [logical].[Usp_SAVE_REGION]
END
GO

CREATE PROC [logical].[Usp_SAVE_REGION]
(
	@itemno INT,
	@name NVARCHAR(128),
	@description NVARCHAR(2056),
	@start_ymdv	INT,
	@end_ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	DECLARE @message NVARCHAR(1028);

	IF EXISTS (SELECT 1 FROM [logical].[TREGION] WHERE [name] = @name AND [itemno] != ISNULL(@itemno,0))
	BEGIN
		SET @message = 'Region with name ' + @name + ' already exists. Save aborted';
		RAISERROR(@message, 16, 1);
		RETURN;
	END
	
	IF @itemno = 0
	BEGIN
		INSERT INTO [logical].[TREGION]
		(
			[name],
			[description],
			[start_ymdv],
			[end_ymdv]
		)
		VALUES
		(
			@name,
			@description,
			@start_ymdv,
			@end_ymdv
		)
		
		SELECT
			[itemno] = CONVERT(INT, SCOPE_IDENTITY());
	END
	ELSE
	BEGIN
		UPDATE R
		SET
			[name] = NULLIF(@name,''),
			[description] = NULLIF(@description,''),
			[start_ymdv] = @start_ymdv,
			[end_ymdv] = @end_ymdv
		FROM [logical].[TREGION] AS R
		WHERE
			[itemno] = @itemno;
			
		SELECT
			[itemno] = @itemno;
	END
	
	SET NOCOUNT OFF;		
END
GO
