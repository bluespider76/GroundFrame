/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_PATHS_BY_LOCATION_AND_YMDV.sql
** Name:	network.Usp_GET_PATHS_BY_LOCATION_AND_YMDV
** Desc:	Retieves all path records for a given ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_PATHS_BY_LOCATION_AND_YMDV'))
BEGIN
	DROP PROC [network].[Usp_GET_PATHS_BY_LOCATION_AND_YMDV]
END
GO

CREATE PROC [network].[Usp_GET_PATHS_BY_LOCATION_AND_YMDV]
(
	@location_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		*
	FROM [network].[TPATH]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)
		AND start_location_itemno = @location_itemno;
	
	SET NOCOUNT OFF;
END
GO
