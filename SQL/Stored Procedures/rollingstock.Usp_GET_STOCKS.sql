/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_STOCKS.sql
** Name:	rollingstock.Usp_GET_STOCKS
** Desc:	Gets the all stock records for the YMDV
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_STOCKS'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_STOCKS];
END
GO

CREATE PROC [rollingstock].[Usp_GET_STOCKS]
(
	@ymdv INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [rollingstock].[TSTOCK]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
END
GO
