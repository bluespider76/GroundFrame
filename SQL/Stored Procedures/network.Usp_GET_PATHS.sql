/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_PATHS.sql
** Name:	network.Usp_GET_PATHS
** Desc:	Retieves all path records for a given ymdv.
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('network.Usp_GET_PATHS'))
BEGIN
	DROP PROC [network].[Usp_GET_PATHS]
END
GO

CREATE PROC [network].[Usp_GET_PATHS]
(
	@ymdv INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno]
	FROM [network].[TPATH]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv);
	
	SET NOCOUNT OFF;
END
GO
