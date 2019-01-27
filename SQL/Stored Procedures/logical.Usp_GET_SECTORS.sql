/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_GET_SECTORS.sql
** Name:	logical.Usp_GET_SECTORS
** Desc:	Gets all sectors for a specific YMDV
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_GET_SECTORS'))
BEGIN
	DROP PROC [logical].[Usp_GET_SECTORS]
END
GO

CREATE PROC [logical].[Usp_GET_SECTORS]
AS
BEGIN
	SELECT
		[itemno],
		[code_itemno],
		[start_ymdv],
		[end_ymdv],
		[description]
	FROM [logical].[TSECTOR]
END
GO
