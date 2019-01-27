/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_SYSTEMPATHS_BY_LOCATION.sql
** Name:	network.Usp_GET_SYSTEMPATHS_BY_LOCATION
** Desc:	Returns all System Paths
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_SYSTEMPATHS_BY_LOCATION'))
BEGIN
	DROP PROC [network].Usp_GET_SYSTEMPATHS_BY_LOCATION
END
GO

CREATE PROC [network].[Usp_GET_SYSTEMPATHS_BY_LOCATION]
(
	@system_location_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[system_itemno],
		[system_name],
		[system_description],
		[system_start_location_itemno],
		[system_end_location_itemno]
	FROM [network].[TSYSTEMPATH]
	WHERE
		[system_start_location_itemno] = @system_location_itemno or [system_end_location_itemno] = @system_location_itemno
	ORDER BY
		[system_name];
	
	SET NOCOUNT OFF;
END
GO
