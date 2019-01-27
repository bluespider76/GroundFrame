/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV.sql
** Name:	network.Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV
** Desc:	Retieves all location records for a given ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV'))
BEGIN
	DROP PROC [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV]
END
GO

CREATE PROC [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATIONANDYMDV]
(
	@location_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[location_itemno],
		[start_ymdv],
		[end_ymdv],
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
	FROM [network].[TLOCATION] AS L
	WHERE
		(
			([location_itemno] = @location_itemno AND NOT EXISTS (SELECT 1 FROM [network].[TLOCATION] AS PL1 WHERE L.itemno = PL1.parent_itemno)) 
			OR EXISTS (SELECT 1 FROM [network].[TLOCATION] AS PL WHERE PL.location_itemno = @location_itemno AND PL.itemno = L.parent_itemno)
		)
		AND (@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv));
	
	SET NOCOUNT OFF;
END
GO
