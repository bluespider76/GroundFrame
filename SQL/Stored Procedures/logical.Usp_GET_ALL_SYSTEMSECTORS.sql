/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\logical.Usp_GET_ALL_SYSTEMSECTORS.sql
** Name:	logical.Usp_GET_ALL_SYSTEMSECTORS
** Desc:	Gets all system sectors
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('logical.Usp_GET_ALL_SYSTEMSECTORS'))
BEGIN
	DROP PROC [logical].[Usp_GET_ALL_SYSTEMSECTORS]
END
GO

CREATE PROC [logical].[Usp_GET_ALL_SYSTEMSECTORS]
AS
BEGIN
	SELECT
		[itemno],
		[code]
	FROM [logical].TSYSTEMSECTOR
END
GO
