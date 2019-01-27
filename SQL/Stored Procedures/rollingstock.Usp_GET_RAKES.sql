/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_RAKES.sql
** Name:	rollingstock.Usp_GET_RAKES
** Desc:	Gets a list of all rakes for the specific YMV
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_RAKES'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_RAKES];
END
GO

CREATE PROC [rollingstock].[Usp_GET_RAKES]
(
	@ymdv INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [rollingstock].[TRAKE]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv)
END
GO
