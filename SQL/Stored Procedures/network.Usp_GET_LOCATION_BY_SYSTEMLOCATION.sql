/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_LOCATION_BY_SYSTEMLOCATION.sql
** Name:	network.Usp_GET_LOCATION_BY_SYSTEMLOCATION
** Desc:	Retieves all location records for a given system location.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_LOCATION_BY_SYSTEMLOCATION'))
BEGIN
	DROP PROC [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATION]
END
GO

CREATE PROC [network].[Usp_GET_LOCATION_BY_SYSTEMLOCATION]
(
	@location_itemno INT
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
	FROM [network].[TLOCATION]
	WHERE
		[location_itemno] = @location_itemno;
	
	SET NOCOUNT OFF;
END
GO
