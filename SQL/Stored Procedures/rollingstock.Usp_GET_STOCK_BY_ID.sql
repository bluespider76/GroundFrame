/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\rollingstock.Usp_GET_STOCK_BY_ID.sql
** Name:	rollingstock.Usp_GET_STOCK_BY_ID
** Desc:	Gets the stock record for the DB ID
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_STOCK_BY_ID'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_STOCK_BY_ID];
END
GO

CREATE PROC [rollingstock].[Usp_GET_STOCK_BY_ID]
(
	@itemno INT
)
AS
BEGIN
	SELECT
		[itemno],
		[start_ymdv],
		[end_ymdv],
		[type_itemno],
		[name],
		[description],
		[coupling_types],
		[brake_types],
		[heating_types],
		[max_speed],
		[length], 
		[options],
		[eth_index],
		[weight]
	FROM [rollingstock].[TSTOCK]
	WHERE
		[itemno] = @itemno;
END
GO
