/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_GET_REGION_BY_ID.sql
** Name:	logical.Usp_GET_REGION_BY_ID
** Desc:	Gets a region by the ID
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_GET_REGION_BY_ID'))
BEGIN
	DROP PROC [logical].[Usp_GET_REGION_BY_ID]
END
GO

CREATE PROC [logical].[Usp_GET_REGION_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[name],
		[description]
	FROM [logical].[TREGION]
	WHERE
		[itemno] = @itemno;
END
GO
