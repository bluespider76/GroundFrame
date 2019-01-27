/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_DEPOTS.sql
** Name:	network.Usp_GET_DEPOTS
** Desc:	Retieves all depot records for a given system location and ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_DEPOTS'))
BEGIN
	DROP PROC [network].[Usp_GET_DEPOTS]
END
GO

CREATE PROC [network].[Usp_GET_DEPOTS]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		itemno, 
		location_itemno, 
		start_ymdv, 
		end_ymdv, 
		code, 
		ease_of_access, 
		percentage_visible_from_train, 
		capabilities
	FROM [network].[TDEPOT]
	WHERE
		(@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv], @ymdv));
	
	SET NOCOUNT OFF;
END
GO
