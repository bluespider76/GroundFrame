/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\peppermint.Usp_GET_TSYSTEMLOCATIONS.sql
** Name:	peppermint.Usp_GET_TSYSTEMLOCATIONS
** Desc:	Returns all System Locations
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_TSYSTEMLOCATIONS'))
BEGIN
	DROP PROC [network].Usp_GET_TSYSTEMLOCATIONS
END
GO

CREATE PROC [network].[Usp_GET_TSYSTEMLOCATIONS]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[system_itemno],
		[system_name]
	FROM [network].[TSYSTEMLOCATION];
	
	SET NOCOUNT OFF;
END
GO
