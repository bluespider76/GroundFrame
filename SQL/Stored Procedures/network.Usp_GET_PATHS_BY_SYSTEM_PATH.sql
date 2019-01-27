/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_PATHS_BY_SYSTEM_PATH.sql
** Name:	network.Usp_GET_PATHS_BY_SYSTEM_PATH
** Desc:	Retieves all path records for a given system path.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_PATHS_BY_SYSTEM_PATH'))
BEGIN
	DROP PROC [network].[Usp_GET_PATHS_BY_SYSTEM_PATH]
END
GO

CREATE PROC [network].[Usp_GET_PATHS_BY_SYSTEM_PATH]
(
	@system_path_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		itemno,
		path_itemno,
		start_ymdv,
		end_ymdv,
		start_location_itemno,
		end_location_itemno, 
		distance, direction,
		token_itemno,
		type_itemno,
		route_availability,
		berths,
		permissible_power,
		crossing_count,
		score,
		freight_only,
		max_speed,
		rating,
		signal_type_itemno,
		options
	FROM [network].[TPATH]
	WHERE
		path_itemno = @system_path_itemno;
	
	SET NOCOUNT OFF;
END
GO
