/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\wtt.Usp_GET_CALLINGPOINTS.sql
** Name:	wtt.Usp_GET_CALLINGPOINTS
** Desc:	Gets a trains calling points
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('wtt.Usp_GET_CALLINGPOINTS'))
BEGIN
	DROP PROC [wtt].[Usp_GET_CALLINGPOINTS]
END
GO

CREATE PROC [wtt].[Usp_GET_CALLINGPOINTS]
(
	@train_itemno INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [wtt].[TCALLINGPOINT]
	WHERE
		[train_itemno] = @train_itemno
	ORDER BY
		[order] ASC;
END
GO
