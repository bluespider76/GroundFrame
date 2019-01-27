/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\network.Usp_GET_TTRACTIONCLASSES_BY_TYPE.sql
** Name:	rollingstock.Usp_GET_TTRACTIONCLASSES_BY_TYPE
** Desc:	Gets a Traction class record based on the ID
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('rollingstock.Usp_GET_TTRACTIONCLASSES_BY_TYPE'))
BEGIN
	DROP PROC [rollingstock].[Usp_GET_TTRACTIONCLASSES_BY_TYPE];
END
GO

CREATE PROC [rollingstock].[Usp_GET_TTRACTIONCLASSES_BY_TYPE]
(
	@traction_type_itemno INT
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		itemno, 
		start_ymdv, 
		end_ymdv, 
		name, 
		[description], 
		parent_itemno, 
		traction_type_itemno, 
		[length], 
		route_availability
	FROM [rollingstock].TTRACTIONCLASS
	WHERE
		traction_type_itemno = @traction_type_itemno
	
	SET NOCOUNT OFF;
END
GO
