/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_RAKE_REGIONS.sql
** Name:	rollingstock.Usp_GET_RAKE_ELEMENTS
** Desc:	Gets a list of regions the rake can be sourced from
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_RAKE_REGIONS'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_RAKE_REGIONS];
END
GO

CREATE PROC [rollingstock].[Usp_GET_RAKE_REGIONS]
(
	@rake_itemno INT
)
AS
BEGIN
	SELECT
		region_itemno
	FROM [rollingstock].[TRAKEREGION] AS RD
	WHERE
		RD.[rake_itemno] = @rake_itemno;
END
GO
