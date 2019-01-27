/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\wtt.Usp_GET_TRAINRAKEALLOCATIONS.sql
** Name:	wtt.Usp_GET_TRAINRAKEALLOCATIONS
** Desc:	Gets all train rake allocations from the database for the specified YMDV and train
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('wtt.Usp_GET_TRAINRAKEALLOCATIONS'))
BEGIN
	DROP PROC [wtt].[Usp_GET_TRAINRAKEALLOCATIONS]
END
GO

CREATE PROC [wtt].[Usp_GET_TRAINRAKEALLOCATIONS]
(
	@ymdv	INT,
	@train_itemno INT
)
AS
BEGIN
	SELECT
		[itemno]
	FROM [wtt].[TTRAINRAKEALLOCATION]
	WHERE
		@ymdv BETWEEN [start_ymdv] AND ISNULL([end_ymdv],@ymdv)
		and [train_itemno] = @train_itemno;
END
GO
