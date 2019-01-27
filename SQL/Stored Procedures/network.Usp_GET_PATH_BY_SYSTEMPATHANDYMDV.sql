/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_PATH_BY_SYSTEMPATHANDYMDV.sql
** Name:	network.Usp_GET_PATH_BY_SYSTEMPATHANDYMDV
** Desc:	Retieves the path for the given System Path and YMDV.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_PATH_BY_SYSTEMPATHANDYMDV'))
BEGIN
	DROP PROC [network].[Usp_GET_PATH_BY_SYSTEMPATHANDYMDV]
END
GO

CREATE PROC [network].[Usp_GET_PATH_BY_SYSTEMPATHANDYMDV]
(
	@path_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[path_itemno],
		[start_ymdv],
		[end_ymdv],
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
		[options],
		[permissible_power]
	FROM [network].[TPATH]
	WHERE
		[path_itemno] = @path_itemno
		AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
