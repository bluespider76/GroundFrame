/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_CHILD_LOCATIONS.sql
** Name:	network.Usp_GET_CHILD_LOCATIONS
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_CHILD_LOCATIONS'))
BEGIN
	DROP PROC [network].[Usp_GET_CHILD_LOCATIONS]
END
GO

CREATE PROC [network].[Usp_GET_CHILD_LOCATIONS]
(
	@parent_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [network].[TLOCATION]
	WHERE
		[parent_itemno] = @parent_itemno;
	
	SET NOCOUNT OFF;
END
GO
