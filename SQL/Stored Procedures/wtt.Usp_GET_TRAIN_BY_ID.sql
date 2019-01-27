/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\wtt.Usp_GET_TRAIN_BY_ID.sql
** Name:	wtt.Usp_GET_TRAIN_BY_ID
** Desc:	Gets a train ID based on the itemno passed
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('wtt.Usp_GET_TRAIN_BY_ID'))
BEGIN
	DROP PROC [wtt].[Usp_GET_TRAIN_BY_ID]
END
GO

CREATE PROC [wtt].[Usp_GET_TRAIN_BY_ID]
(
	@itemno	INT
)
AS
BEGIN
	SELECT
		[headcode],
		[description],
		[start_location_itemno],
		[end_location_itemno],
		[mp_next_train_itemno],
		[mp_next_train_perc],
		[mp_next_train_min_turnaround],
		[stock_next_train_itemno], 
		[stock_next_train_perc], 
		[stock_next_train_min_turnaround], 
		[parent_train_itemno],
		[mins_allocation_on_tops],
		[start_time], 
		[days], 
		[brake_types], 
		[heat_types],
		[configuration], 
		[max_speed],
		[max_speed_if_late],
		[run_as_required],
		[run_as_required_perc],
		[runs_once]
	FROM [wtt].[TTRAIN]
	WHERE
		[itemno] = @itemno;
END
GO
