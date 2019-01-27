/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\peppermint.Usp_GET_SYSTEMPATHS.sql
** Name:	peppermint.Usp_GET_SYSTEMPATHS
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_SYSTEMPATHS'))
BEGIN
	DROP PROC [network].Usp_GET_SYSTEMPATHS
END
GO

CREATE PROC [network].[Usp_GET_SYSTEMPATHS]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[system_itemno],
		[system_name],
		[system_description],
		[system_start_location_itemno],
		[system_end_location_itemno]
	FROM [network].[TSYSTEMPATH];
	
	SET NOCOUNT OFF;
END
GO
