/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_RAKE_DEPOTS.sql
** Name:	rollingstock.Usp_GET_RAKE_DEPOTS
** Desc:	Gets the all depots for a rake
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_RAKE_DEPOTS'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_RAKE_DEPOTS];
END
GO

CREATE PROC [rollingstock].[Usp_GET_RAKE_DEPOTS]
(
	@rake_itemno INT,
	@ymdv INT
)
AS
BEGIN
	SELECT DISTINCT
		D.location_itemno
	FROM [rollingstock].[TRAKEDEPOT] AS RD
	INNER JOIN [network].[TDEPOT] AS D ON RD.depot_location_itemno = D.location_itemno
	WHERE
		RD.rake_itemno = @rake_itemno
		AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv);
END
GO
