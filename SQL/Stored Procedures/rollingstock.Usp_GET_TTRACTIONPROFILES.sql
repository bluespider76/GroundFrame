/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_TTRACTIONPROFILES.sql
** Name:	rollingstock.Usp_GET_TTRACTIONPROFILES
** Desc:	Gets a Traction profile record based on the Traction Class and YMDV
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_TTRACTIONPROFILES'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_TTRACTIONPROFILES];
END
GO

CREATE PROC [rollingstock].[Usp_GET_TTRACTIONPROFILES]
(
	@traction_class_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		[itemno],
		[max_speed],
		[max_speed_light_loco],
		[power_itemno],
		[tractive_effort],
		[horse_power]
	FROM [rollingstock].TTRACTIONPROFILE
	WHERE
		[traction_class_itemno] = @traction_class_itemno
	
	SET NOCOUNT OFF;
END
GO
