/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Functions\network.Fn_GET_LOCATION_ID.sql
** Name:	network.Fn_GET_LOCATION_ID
** Desc:	Returns the location itemno for the given location name on the specific YMDV
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
IF EXISTS (SELECT 1 FROM sys.objects WHERE object_id = OBJECT_ID('network.Fn_GET_LOCATION_ID'))
BEGIN
	DROP FUNCTION [network].[Fn_GET_LOCATION_ID]
END
GO

CREATE FUNCTION [network].[Fn_GET_LOCATION_ID]
(
	@name NVARCHAR(128),
	@ymdv INT
)
RETURNS INT
AS
BEGIN
	RETURN (ISNULL((SELECT [itemno] FROM [network].TLOCATION WHERE [name] = @name AND @ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)),0))
END
GO