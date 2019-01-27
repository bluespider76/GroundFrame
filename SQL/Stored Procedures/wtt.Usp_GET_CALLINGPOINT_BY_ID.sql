/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\wtt.Usp_GET_CALLINGPOINT_BY_ID.sql
** Name:	wtt.Usp_GET_CALLINGPOINT_BY_ID
** Desc:	Gets a train calling point by the ID
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('wtt.Usp_GET_CALLINGPOINT_BY_ID'))
BEGIN
	DROP PROC [wtt].[Usp_GET_CALLINGPOINT_BY_ID]
END
GO

CREATE PROC [wtt].[Usp_GET_CALLINGPOINT_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[train_itemno],
		[location_itemno],
		[arr],
		[dep],
		[setdownonly],
		[pickuponly],
		[mindwelltime],
		[order]
	FROM [wtt].[TCALLINGPOINT]
	WHERE
		[itemno] = @itemno;
END
GO
