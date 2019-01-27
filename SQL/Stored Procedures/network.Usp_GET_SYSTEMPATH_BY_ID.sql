/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_SYSTEMPATH_BY_ID.sql
** Name:	network.Usp_GET_SYSTEMPATH_BY_ID
** Desc:	Returns the System Path for the supplied ID
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_SYSTEMPATH_BY_ID'))
BEGIN
	DROP PROC [network].Usp_GET_SYSTEMPATH_BY_ID
END
GO

CREATE PROC [network].[Usp_GET_SYSTEMPATH_BY_ID]
(
	@system_path_itemno INT
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
		[system_itemno] = @system_path_itemno;
	
	SET NOCOUNT OFF;
END
GO
