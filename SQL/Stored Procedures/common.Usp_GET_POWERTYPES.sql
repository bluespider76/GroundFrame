/******************************
** File:    C:\Users\tcaceres\Documents\SQL Server Management Studio\Projects\Horizon4\GF\Stored Procedures\common.Usp_GET_POWERTYPES.sql
** Name:	logical.Usp_GET_POWERTYPES
** Desc:	Gets all sectors for a specific YMDV
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
IF EXISTS (SELECT 1 FROM sys.procedures WHERE object_id = OBJECT_ID('common.Usp_GET_POWERTYPES'))
BEGIN
	DROP PROC [common].[Usp_GET_POWERTYPES]
END
GO

CREATE PROC [common].[Usp_GET_POWERTYPES]
AS
BEGIN
	SELECT
		[itemno],
		[name],
		[description]
	FROM [common].[TPOWERTYPE]
	ORDER BY 
		[itemno]
END
GO
