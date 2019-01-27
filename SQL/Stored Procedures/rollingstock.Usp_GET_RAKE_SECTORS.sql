/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_RAKE_SECTORS.sql
** Name:	rollingstock.Usp_GET_RAKE_SECTORS
** Desc:	Gets a list of sectors for the supplied rake itemno
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_RAKE_SECTORS'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_RAKE_SECTORS];
END
GO

CREATE PROC [rollingstock].[Usp_GET_RAKE_SECTORS]
(
	@rake_itemno INT
)
AS
BEGIN
	SELECT
		S.[itemno],
		S.[code_itemno],
		S.[start_ymdv],
		S.[end_ymdv],
		S.[description]
	FROM [rollingstock].[TRAKESECTOR] AS RD
	INNER JOIN [logical].[TSECTOR] AS S ON RD.sector_itemno = S.itemno
	WHERE
		RD.[rake_itemno] = @rake_itemno;
END
GO
